# SSRS Brand Editor � Application Specification

## 1. Overview

**SSRS Brand Editor** is a WPF desktop application (.NET 8) that enables users to visually create, edit, preview, and export brand packages for the **SQL Server Reporting Services (SSRS)** and **Power BI Report Server** web portals � without manual JSON/XML editing.

An SSRS brand package is a **ZIP file** containing up to three items:

| File           | Required | Purpose                                                                                        |
| -------------- | -------- | ---------------------------------------------------------------------------------------------- |
| `metadata.xml` | ?        | Package manifest � declares the brand name, version, type, and references the contained items. |
| `colors.json`  | ?        | Defines the complete color scheme (interface + theme sections).                                |
| `logo.png`     | ?        | Optional logo image (PNG, ? 290 � 60 px) displayed in the portal header.                       |

> **Reference:** [Microsoft Docs � Brand the web portal](https://learn.microsoft.com/sql/reporting-services/branding-the-web-portal)

---

## 2. Solution Architecture

The solution follows a **Clean Architecture / Onion Architecture** pattern with the following layers:

```
?????????????????????????????????????????????????????
?  SSRS.Brand.Editor          (Host / Composition)  ?
?????????????????????????????????????????????????????
?  SSRS.Brand.Editor.Presentation     (WPF Views)  ?
?????????????????????????????????????????????????????
?  SSRS.Brand.Editor.Infrastructure   (I/O, Zip)   ?
?????????????????????????????????????????????????????
?  SSRS.Brand.Editor.Application  (ViewModels/Svc)  ?
?????????????????????????????????????????????????????
?  SSRS.Brand.Editor.Domain         (Models/Core)   ?
?????????????????????????????????????????????????????
```

Each layer has a corresponding `*.Tests` project (MSTest + Moq).

| Layer              | Responsibility                                                                                                                                                 |
| ------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Domain**         | Core models representing the brand package structure (`BrandPackage`, `ColorScheme`, `InterfaceColors`, `ThemeColors`, `Metadata`). No framework dependencies. |
| **Application**    | ViewModels, services (navigation, events), abstractions for infrastructure. Serialization/deserialization logic (`JsonColorConverter` already exists).         |
| **Infrastructure** | File system I/O (already abstracted via `IFileProvider`, `IDirectoryProvider`), ZIP archive handling, logging.                                                 |
| **Presentation**   | WPF windows, user controls, XAML resources, dialogs, color pickers.                                                                                            |
| **Host**           | Composition root, DI registration, `IHost` startup.                                                                                                            |

> **Note:** Persistence to a database is **not** in scope for v1 but the architecture (abstractions in Application, implementations in Infrastructure) already supports adding a repository layer later.

---

## 3. Domain Model

### 3.1 Brand Package Metadata (`metadata.xml`)

```xml
<SystemResourcePackage
  xmlns="http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata"
  type="UniversalBrand"
  version="2.0.2"
  name="My Custom Brand">
  <Contents>
    <Item key="colors" path="colors.json" />
    <Item key="logo"   path="logo.png" />   <!-- optional -->
  </Contents>
</SystemResourcePackage>
```

**Model properties:**

- `Name` (string, required) � brand display name.
- `Version` (string, default `"2.0.2"`) � package format version.
- `Type` (string, constant `"UniversalBrand"`).
- `HasLogo` (bool) � whether a logo item is included.

### 3.2 Color Scheme (`colors.json`)

The color scheme is composed of two top-level sections:

#### 3.2.1 Interface Colors

Controls the SSRS web portal UI. Grouped into:

| Group                 | Properties                                                                                                                                 |
| --------------------- | ------------------------------------------------------------------------------------------------------------------------------------------ |
| **Primary**           | `primary`, `primaryAlt`, `primaryAlt2`, `primaryAlt3`, `primaryAlt4`, `primaryContrast`                                                    |
| **Secondary**         | `secondary`, `secondaryAlt`, `secondaryAlt2`, `secondaryAlt3`, `secondaryContrast`                                                         |
| **Neutral Primary**   | `neutralPrimary`, `neutralPrimaryAlt`, `neutralPrimaryAlt2`, `neutralPrimaryAlt3`, `neutralPrimaryContrast`                                |
| **Neutral Secondary** | `neutralSecondary`, `neutralSecondaryAlt`, `neutralSecondaryAlt2`, `neutralSecondaryAlt3`, `neutralSecondaryContrast`                      |
| **Neutral Tertiary**  | `neutralTertiary`, `neutralTertiaryAlt`, `neutralTertiaryAlt2`, `neutralTertiaryAlt3`, `neutralTertiaryContrast`                           |
| **Status**            | `danger`, `success`, `warning`, `info` + their `*Contrast` variants                                                                        |
| **KPI**               | `kpiGood`, `kpiBad`, `kpiNeutral`, `kpiNone` + their `*Contrast` variants                                                                  |
| **Icons**             | `itemTypeIconColor`, `reportIconBackground`, `excelIconBackground`, `folderIconBackground`, `datasetIconBackground`, `otherIconBackground` |
| **Buttons**           | `primaryButton`, `primaryButtonHover`, `primaryButtonPressed`                                                                              |
| **Links**             | `link`, `linkHover`, `linkVisited`                                                                                                         |
| **Controls**          | `radioButtonCheckBox`, `radioButtonCheckBoxHover`                                                                                          |

#### 3.2.2 Theme Colors

Controls mobile report / chart theming:

| Group           | Properties                                                                                                                     |
| --------------- | ------------------------------------------------------------------------------------------------------------------------------ |
| **Data Points** | `dataPoints` (array of hex color strings)                                                                                      |
| **Status**      | `good`, `bad`, `neutral`, `none`                                                                                               |
| **Standard**    | `background`, `foreground`, `mapBase`, `panelBackground`, `panelForeground`, `panelAccent`, `tableAccent`                      |
| **Alt**         | `altBackground`, `altForeground`, `altMapBase`, `altPanelBackground`, `altPanelForeground`, `altPanelAccent`, `altTableAccent` |

#### 3.2.3 Top-Level Properties

- `name` (string) � brand name (mirrors metadata).
- `version` (string) � color scheme version.

### 3.3 Logo

- Format: **PNG** only.
- Recommended dimensions: **290 � 60 pixels** (scaled by the server).
- Stored as raw bytes in the domain model.

---

## 4. Functional Requirements

### 4.1 Brand Package Management

| ID   | Requirement                                                                  |
| ---- | ---------------------------------------------------------------------------- |
| F-01 | **New** � Create a new brand package from default/empty template.            |
| F-02 | **Open** � Import an existing brand package ZIP file and parse its contents. |
| F-03 | **Save / Save As** � Export the current brand package as a valid ZIP file.   |
| F-04 | **Close** � Close the current brand package (with unsaved-changes prompt).   |

### 4.2 Metadata Editing

| ID   | Requirement                                               |
| ---- | --------------------------------------------------------- |
| F-10 | Edit the brand package **name**.                          |
| F-11 | Display the package **version** and **type** (read-only). |

### 4.3 Color Editing

| ID   | Requirement                                                                |
| ---- | -------------------------------------------------------------------------- |
| F-20 | Display all interface color properties grouped by category (see �3.2.1).   |
| F-21 | Display all theme color properties grouped by category (see �3.2.2).       |
| F-22 | Edit any color via a **color picker** control (hex input + visual picker). |
| F-23 | Show a **live color swatch/preview** next to each property.                |
| F-24 | Manage the **data points** color array (add, remove, reorder entries).     |

### 4.4 Logo Management

| ID   | Requirement                                      |
| ---- | ------------------------------------------------ |
| F-30 | **Browse** and select a PNG logo file from disk. |
| F-31 | Display a **preview** of the selected logo.      |
| F-32 | **Remove** the logo from the brand package.      |
| F-33 | Validate the file is a valid PNG image.          |

### 4.5 Validation

| ID   | Requirement                                                                              |
| ---- | ---------------------------------------------------------------------------------------- |
| F-40 | Brand name must not be empty.                                                            |
| F-41 | All color values must be valid hex color strings (3 or 6 characters, prefixed with `#`). |
| F-42 | Logo file (if provided) must be a valid PNG.                                             |
| F-43 | Validation errors are displayed inline in the UI.                                        |

---

## 5. Non-Functional Requirements

| ID    | Requirement                                                                                                                                                |
| ----- | ---------------------------------------------------------------------------------------------------------------------------------------------------------- |
| NF-01 | **Target Framework:** .NET 8 (Windows), WPF.                                                                                                               |
| NF-02 | **Architecture:** Clean Architecture with DI (`Microsoft.Extensions.Hosting`).                                                                             |
| NF-03 | **Testability:** All services abstracted behind interfaces; unit tests per layer.                                                                          |
| NF-04 | **Extensibility:** Database persistence can be added later via a repository abstraction in the Application layer with an implementation in Infrastructure. |
| NF-05 | **Serialization:** `System.Text.Json` for `colors.json`; `System.Xml.Serialization` / `System.Xml.Linq` for `metadata.xml`.                                |
| NF-06 | **ZIP handling:** `System.IO.Compression.ZipArchive` for package creation/extraction.                                                                      |
| NF-07 | **Logging:** Via `Microsoft.Extensions.Logging` (console + EventLog already configured).                                                                   |
| NF-08 | **Central Package Management:** NuGet versions managed in `Directory.Packages.props`.                                                                      |

---

## 6. UI Wireframe (Conceptual)

```
????????????????????????????????????????????????????????????????
?  File   Help                                                 ?
????????????????????????????????????????????????????????????????
? ???????????????? ??????????????????????????????????????????? ?
? ?  Navigation   ? ?  Content Area                           ? ?
? ?              ? ?                                         ? ?
? ?  ? Metadata  ? ?  [Rendered view of selected section]    ? ?
? ?  ? Interface ? ?                                         ? ?
? ?  ? Theme     ? ?  e.g. Color group with swatches         ? ?
? ?  ? Logo      ? ?       and color picker controls         ? ?
? ?              ? ?                                         ? ?
? ???????????????? ??????????????????????????????????????????? ?
????????????????????????????????????????????????????????????????
?  Status Bar: user � environment � validation state           ?
????????????????????????????????????????????????????????????????
```

### Sections

1. **Metadata** � Brand name, version, type, logo toggle.
2. **Interface Colors** � Grouped color editors (Primary, Secondary, Neutral, Status, KPI, Icons, Buttons, Links, Controls).
3. **Theme Colors** � Grouped color editors (Data Points, Status, Standard, Alt).
4. **Logo** � Image picker, preview, remove button.

---

## 7. Key Technical Decisions

| Decision                                                                                     | Rationale                                                                                                              |
| -------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------- |
| Use `System.Windows.Media.Color` in models and `JsonColorConverter` for serialization.       | Already established in the codebase; avoids mixing `System.Drawing.Color` in the domain.                               |
| Models inherit from `ModelBase` / `ValidatableModelBase` (via `BB84.Notifications`).         | Provides `INotifyPropertyChanged` and validation infrastructure out of the box.                                        |
| Navigation via `INavigationService` with content-area swapping.                              | Already implemented; each editor section is a ViewModel + UserControl pair.                                            |
| ZIP operations abstracted behind an interface in Application, implemented in Infrastructure. | Keeps domain/application layers testable and infrastructure-agnostic.                                                  |
| No database in v1; file-based only.                                                          | Simplifies initial delivery. The abstraction layer allows adding persistence later without changing application logic. |

---

## 8. Deliverables Roadmap

| Phase                       | Scope                                                                                                                                               |
| --------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Phase 1 � Domain Models** | `BrandPackageModel`, `MetadataModel`, `InterfaceColorsModel`, `ThemeColorsModel` with validation. Unit tests.                                       |
| **Phase 2 � Serialization** | JSON read/write for `colors.json`, XML read/write for `metadata.xml`, ZIP pack/unpack. Unit tests.                                                  |
| **Phase 3 � ViewModels**    | `BrandEditorViewModel`, `MetadataViewModel`, `InterfaceColorsViewModel`, `ThemeColorsViewModel`, `LogoViewModel`. Commands for New/Open/Save/Close. |
| **Phase 4 � Presentation**  | WPF views for each section, color picker integration, logo preview, menu bar wiring.                                                                |
| **Phase 5 � Polish**        | Validation UX, unsaved-changes prompts, default brand template, about dialog updates.                                                               |

---

## 9. Phase 4 — Presentation (Detailed UI Specification)

The editor UI is split into two main areas: an **Editor Panel** (left) where the user modifies color values, metadata, and the logo, and a **Live Preview Panel** (right) that renders a simplified replica of the SSRS Web Portal, updating in real time as the user changes any color property. This gives the user a **WYSIWYG** experience.

### 9.1 Overall Layout

```
+------------------------------------------------------------------------------+
|  Menu Bar: File (New, Open, Save, Save As, Close, Quit) | Help (About)      |
+---------------------------------+--------------------------------------------+
|  EDITOR PANEL (left, ~400 px)   |  LIVE PREVIEW PANEL (right, fills rest)    |
|                                 |                                            |
|  +---------------------------+  |  +----------------------------------------+|
|  |  Tab: Metadata            |  |  |  Portal Title Bar                     ||
|  |  Tab: Interface           |  |  |  Search Bar                           ||
|  |  Tab: Theme               |  |  |  Content Tiles                        ||
|  |  Tab: Logo                |  |  |  Status Messages                      ||
|  +---------------------------+  |  |  KPI Indicators                       ||
|                                 |  +----------------------------------------+|
+---------------------------------+--------------------------------------------+
|  Status Bar: file path | user | environment                                  |
+------------------------------------------------------------------------------+
```

- The **Editor Panel** uses a `TabControl` with four tabs.
- The **Live Preview Panel** is a read-only, non-interactive mock-up of the SSRS Web Portal that reflects the current color values.
- A `GridSplitter` between the two panels allows resizing.
- When no brand package is loaded, both panels show a centered welcome message with "New" / "Open" buttons.

### 9.2 Menu Bar

The existing `MainWindow.xaml` menu bar is extended:

| Menu  | Item             | Command binding                       | Shortcut        | Enabled when   |
| ----- | ---------------- | ------------------------------------- | --------------- | -------------- |
| File  | **New**          | `BrandEditor.NewCommand`              | `Ctrl+N`        | Always         |
| File  | **Open...**      | `BrandEditor.OpenCommand`             | `Ctrl+O`        | Always         |
| File  | ---              |                                       |                 |                |
| File  | **Save**         | `BrandEditor.SaveCommand`             | `Ctrl+S`        | `HasPackage`   |
| File  | **Save As...**   | `BrandEditor.SaveAsCommand`           | `Ctrl+Shift+S`  | `HasPackage`   |
| File  | ---              |                                       |                 |                |
| File  | **Close**        | `BrandEditor.CloseCommand`            |                 | `HasPackage`   |
| File  | ---              |                                       |                 |                |
| File  | **Quit**         | `ExitCommand`                         | `Alt+F4`        | Always         |
| Help  | **About**        | `AboutCommand`                        |                 | Always         |

### 9.3 Editor Panel — Tab Details

#### 9.3.1 Metadata Tab

A simple form layout:

| Control       | Binding                          | Notes                                      |
| ------------- | -------------------------------- | ------------------------------------------ |
| TextBox       | `Metadata.Name`                  | Editable brand name.                       |
| TextBlock     | `Metadata.Version`               | Read-only, displays `"2.0.2"`.             |
| TextBlock     | `MetadataModel.PackageType`      | Read-only, displays `"UniversalBrand"`.    |
| CheckBox      | `Metadata.HasLogo`               | Read-only indicator (driven by Logo tab).  |

#### 9.3.2 Interface Colors Tab

Uses a `ScrollViewer` containing grouped `Expander` controls, one per color group. Each expander holds a vertical list of **Color Editor Rows**.

**Color Editor Row** (reusable `DataTemplate` or `UserControl`):

```
+------------------------------------------------------+
|  [#] color swatch (24x24)  |  Label  |  #RRGGBB hex |
+------------------------------------------------------+
```

- The **color swatch** is a small `Rectangle` filled with the current color.
- Clicking the swatch or the hex text opens a **color picker popup** (see 9.5).
- The hex `TextBox` supports direct text entry and validates on loss of focus.

**Expander groups** (one per section from 3.2.1):

| Expander Header      | Color properties                                                                                                   |
| -------------------- | ------------------------------------------------------------------------------------------------------------------ |
| Primary              | `Primary`, `PrimaryAlt`, `PrimaryAlt2`, `PrimaryAlt3`, `PrimaryAlt4`, `PrimaryContrast`                           |
| Secondary            | `Secondary`, `SecondaryAlt`, `SecondaryAlt2`, `SecondaryAlt3`, `SecondaryContrast`                                 |
| Neutral Primary      | `NeutralPrimary`, `NeutralPrimaryAlt`, `NeutralPrimaryAlt2`, `NeutralPrimaryAlt3`, `NeutralPrimaryContrast`        |
| Neutral Secondary    | `NeutralSecondary`, `NeutralSecondaryAlt`, `NeutralSecondaryAlt2`, `NeutralSecondaryAlt3`, `NeutralSecondaryContrast` |
| Neutral Tertiary     | `NeutralTertiary`, `NeutralTertiaryAlt`, `NeutralTertiaryAlt2`, `NeutralTertiaryAlt3`, `NeutralTertiaryContrast`   |
| Status               | `Danger`, `Success`, `Warning`, `Info` + `*Contrast` variants                                                      |
| KPI                  | `KpiGood`, `KpiBad`, `KpiNeutral`, `KpiNone` + `*Contrast` variants                                               |
| Icons                | `ItemTypeIconColor`, `ReportIconBackground`, `ExcelIconBackground`, `FolderIconBackground`, `DatasetIconBackground`, `OtherIconBackground` |
| Buttons              | `PrimaryButton`, `PrimaryButtonHover`, `PrimaryButtonPressed`                                                      |
| Links                | `Link`, `LinkHover`, `LinkVisited`                                                                                 |
| Controls             | `RadioButtonCheckBox`, `RadioButtonCheckBoxHover`                                                                  |

#### 9.3.3 Theme Colors Tab

Same layout pattern as Interface Colors, with these expanders:

| Expander Header | Color properties                                                                                          |
| --------------- | --------------------------------------------------------------------------------------------------------- |
| Data Points     | Dynamic list with Add/Remove buttons. Each row is a Color Editor Row.                                     |
| Status          | `Good`, `Bad`, `Neutral`, `None`                                                                          |
| Standard        | `Background`, `Foreground`, `MapBase`, `PanelBackground`, `PanelForeground`, `PanelAccent`, `TableAccent` |
| Alt             | `AltBackground`, `AltForeground`, `AltMapBase`, `AltPanelBackground`, `AltPanelForeground`, `AltPanelAccent`, `AltTableAccent` |

The **Data Points** expander has a toolbar row above the color list:

```
[ + Add ] [ - Remove ]           (3 of 12 data points)
```

#### 9.3.4 Logo Tab

| Control        | Binding / Command                   | Notes                                             |
| -------------- | ----------------------------------- | ------------------------------------------------- |
| Image          | `LogoViewModel.LogoBytes`           | Preview at approximately 290 x 60 px.             |
| Label          | "(No logo selected)"                | Shown when `HasLogo` is `false`.                  |
| Button Browse  | `LogoViewModel.BrowseCommand`       | Opens file dialog filtered to `*.png`.            |
| Button Remove  | `LogoViewModel.RemoveCommand`       | Enabled only when `HasLogo` is `true`.            |

### 9.4 Live Preview Panel — SSRS Portal Mock-Up

The preview is a read-only WPF rendering of a simplified SSRS Web Portal page. All elements are **non-interactive** (no click handlers) — they exist purely to visualize how the brand colors will look when deployed. Every shape/text element is data-bound to the matching color property so updates are instant.

#### 9.4.1 Portal Structure (top to bottom)

```
+-------------------------------------------------------------+
| +- Title Bar -----------------------------------------------+
| |  [Logo / Brand Name]          [Search]    [Gear icon]     |
| |  background: secondary                                    |
| |  text: secondaryContrast                                  |
| +-----------------------------------------------------------+
| +- Breadcrumb Bar ------------------------------------------+
| |  Home > Sample Folder                                     |
| |  background: neutralPrimaryAlt                            |
| |  text: neutralPrimaryContrast / link colors               |
| +-----------------------------------------------------------+
| +- Content Area ---------------------------------------------+
| |  background: neutralPrimary                                |
| |                                                            |
| |  +------+  +------+  +------+  +------+  +------+        |
| |  |Report|  |Report|  |Excel |  |Folder|  |Data  |        |
| |  | icon |  | icon |  | icon |  | icon |  | set  |        |
| |  |  bg  |  |  bg  |  |  bg  |  |  bg  |  | icon |        |
| |  +------+  +------+  +------+  +------+  +------+        |
| |  | name |  | name |  | name |  | name |  | name |        |
| |  +------+  +------+  +------+  +------+  +------+        |
| |                                                            |
| |  [ Primary Button ]  [ Link Example ]                     |
| |                                                            |
| |  +- Status Messages -------------------------------------+ |
| |  |  OK Success   /!\ Warning   X Danger   (i) Info      | |
| |  +-------------------------------------------------------+ |
| |                                                            |
| |  +- KPI Row ---------------------------------------------+ |
| |  |  * Good   * Bad   * Neutral   * None                 | |
| |  +-------------------------------------------------------+ |
| +------------------------------------------------------------+
| +- Settings Bar (Neutral Tertiary) -------------------------+
| |  background: neutralTertiary                               |
| |  text: neutralTertiaryContrast                             |
| +------------------------------------------------------------+
+-------------------------------------------------------------+
```

#### 9.4.2 Color Mapping — Preview Element to `colors.json` Property

| Preview Element                  | Background Color           | Foreground / Text Color     |
| -------------------------------- | -------------------------- | --------------------------- |
| **Title Bar**                    | `secondary`                | `secondaryContrast`         |
| Title Bar hover accent           | `secondaryAlt`             |                             |
| **Search Box background**        | `secondaryAlt2`            | `secondaryAlt3`             |
| **Logo / Brand Name**            | _(logo image or text)_     | `secondaryContrast`         |
| **Breadcrumb / Nav Bar**         | `neutralPrimaryAlt`        | `neutralPrimaryContrast`    |
| Breadcrumb links                 | ---                        | `link` / `linkHover`        |
| **Content Area**                 | `neutralPrimary`           | `neutralPrimaryContrast`    |
| Content Area alternating rows    | `neutralPrimaryAlt2`       |                             |
| **Report Icon tile**             | `reportIconBackground`     | `itemTypeIconColor`         |
| **Excel Icon tile**              | `excelIconBackground`      | `itemTypeIconColor`         |
| **Folder Icon tile**             | `folderIconBackground`     | `itemTypeIconColor`         |
| **Dataset Icon tile**            | `datasetIconBackground`    | `itemTypeIconColor`         |
| **Other Icon tile**              | `otherIconBackground`      | `itemTypeIconColor`         |
| **Primary Button**               | `primaryButton`            | `primaryContrast`           |
| Primary Button (hover state)     | `primaryButtonHover`       | `primaryContrast`           |
| Primary Button (pressed state)   | `primaryButtonPressed`     | `primaryContrast`           |
| **Hyperlinks**                   | ---                        | `link`                      |
| Hyperlink (hover)                | ---                        | `linkHover`                 |
| Hyperlink (visited)              | ---                        | `linkVisited`               |
| **Success message bar**          | `success`                  | `successContrast`           |
| **Warning message bar**          | `warning`                  | `warningContrast`           |
| **Danger message bar**           | `danger`                   | `dangerContrast`            |
| **Info message bar**             | `info`                     | `infoContrast`              |
| **KPI Good indicator**           | `kpiGood`                  | `kpiGoodContrast`           |
| **KPI Bad indicator**            | `kpiBad`                   | `kpiBadContrast`            |
| **KPI Neutral indicator**        | `kpiNeutral`               | `kpiNeutralContrast`        |
| **KPI None indicator**           | `kpiNone`                  | `kpiNoneContrast`           |
| **Text Box / Folder options bg** | `neutralSecondary`         | `neutralSecondaryContrast`  |
| Text Box border / secondary bg   | `neutralSecondaryAlt`      |                             |
| **Settings area**                | `neutralTertiary`          | `neutralTertiaryContrast`   |
| Settings area alt backgrounds    | `neutralTertiaryAlt` / `neutralTertiaryAlt2` / `neutralTertiaryAlt3` |  |
| **Radio / Checkbox accent**      | `radioButtonCheckBox`      |                             |
| Radio / Checkbox hover           | `radioButtonCheckBoxHover` |                             |
| **`primary` accent**             | `primary`                  | `primaryContrast`           |
| Primary hover tones              | `primaryAlt` / `primaryAlt2` / `primaryAlt3` / `primaryAlt4` |       |

#### 9.4.3 Preview — Tile Items

The content area shows 5 mock report/folder tiles in a horizontal `WrapPanel`:

| Tile               | Icon Symbol  | Background Property       |
| ------------------ | ------------ | ------------------------- |
| "Sales Report"     | (report)     | `reportIconBackground`    |
| "Monthly Summary"  | (report)     | `reportIconBackground`    |
| "Budget.xlsx"      | (excel)      | `excelIconBackground`     |
| "Finance"          | (folder)     | `folderIconBackground`    |
| "Customer Dataset" | (dataset)    | `datasetIconBackground`   |

Each tile is a `Border` with the icon background color, containing a centered glyph/text in `itemTypeIconColor`, with the item name label below in `neutralPrimaryContrast`.

### 9.5 Color Picker Control

Each color editor row, when clicked, opens a color picker. We use a simple **inline popup** approach rather than a separate window:

- A `Popup` with `StaysOpen="False"` anchored next to the clicked swatch.
- Contents: a hue/saturation rectangle, a brightness slider, and an RGB hex `TextBox`.
- Closing the popup commits the color change immediately (the model is already two-way bound).

> **Implementation note:** To avoid adding a third-party NuGet dependency, a minimal custom `ColorPickerPopup` user control will be implemented. If a suitable lightweight open-source WPF color picker exists and is well-maintained, it may be used instead — but this decision is deferred to implementation time.

### 9.6 WPF Control Inventory

| UserControl / File                  | ViewModel binding            | Purpose                                            |
| ----------------------------------- | ---------------------------- | -------------------------------------------------- |
| `BrandEditorControl.xaml`           | `BrandEditorViewModel`       | Top-level split: Editor Panel + Preview Panel.     |
| `MetadataEditorControl.xaml`        | `MetadataViewModel`          | Metadata tab content.                              |
| `InterfaceColorsEditorControl.xaml` | `InterfaceColorsViewModel`   | Interface Colors tab with grouped expanders.       |
| `ThemeColorsEditorControl.xaml`     | `ThemeColorsViewModel`       | Theme Colors tab with grouped expanders.           |
| `LogoEditorControl.xaml`            | `LogoViewModel`              | Logo tab with preview, browse, remove.             |
| `PortalPreviewControl.xaml`         | `BrandEditorViewModel`       | SSRS portal WYSIWYG mock-up (read-only).           |
| `ColorEditorRow.xaml`               | _(DataTemplate)_             | Reusable: swatch + label + hex input.              |
| `ColorPickerPopup.xaml`             | _(standalone)_               | Hue/saturation picker + hex entry.                 |

### 9.7 Data Template Wiring (ViewModel to View)

The existing `NavigationService` resolves views via `DataTemplate` in XAML resource dictionaries. The `BrandEditorViewModel` is rendered by `BrandEditorControl`. The child ViewModels are embedded directly inside the tab content areas (not via navigation), since they are always visible simultaneously.

```xml
<!-- App-level or Window-level Resources -->
<DataTemplate DataType="{x:Type vm:BrandEditorViewModel}">
    <controls:BrandEditorControl />
</DataTemplate>
<DataTemplate DataType="{x:Type vm:AboutViewModel}">
    <controls:AboutControl />
</DataTemplate>
```

### 9.8 Converters Required

| Converter                           | Input to Output                              | Purpose                                           |
| ----------------------------------- | -------------------------------------------- | ------------------------------------------------- |
| `DrawingColorToBrushConverter`      | `System.Drawing.Color` to `SolidColorBrush`  | Binds domain model colors to WPF fill/background. |
| `DrawingColorToMediaColorConverter` | `System.Drawing.Color` to `Media.Color`       | For color picker binding.                         |
| `ByteArrayToImageSourceConverter`   | `byte[]` to `BitmapImage`                     | Displays logo preview from raw bytes.             |
| `BoolToVisibilityConverter`         | `bool` to `Visibility`                        | Shows/hides elements based on `HasPackage`, etc.  |
| `InverseBoolToVisibilityConverter`  | `bool` to `Visibility` (inverted)             | Shows welcome screen when no package loaded.      |

### 9.9 Keyboard Shortcuts

| Shortcut       | Action     |
| -------------- | ---------- |
| `Ctrl+N`       | New        |
| `Ctrl+O`       | Open       |
| `Ctrl+S`       | Save       |
| `Ctrl+Shift+S` | Save As    |

Implemented as `InputBinding` / `KeyBinding` on the `MainWindow`.

---

## 10. References

- [Microsoft Docs -- Brand the web portal](https://learn.microsoft.com/sql/reporting-services/branding-the-web-portal?view=sql-server-ver17)
- [Microsoft Docs -- What is the report server web portal](https://learn.microsoft.com/sql/reporting-services/web-portal-ssrs-native-mode?view=sql-server-ver17)
- [Microsoft GitHub -- SSRS Branding Samples](https://github.com/microsoft/sql-server-samples/tree/master/samples/features/reporting-services/branding)
- [BB84.Notifications NuGet](https://www.nuget.org/packages/BB84.Notifications)
- [BB84.Extensions NuGet](https://www.nuget.org/packages/BB84.Extensions)

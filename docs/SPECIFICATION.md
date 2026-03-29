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

## 9. References

- [Microsoft Docs � Brand the web portal](https://learn.microsoft.com/sql/reporting-services/branding-the-web-portal?view=sql-server-ver17)
- [Microsoft GitHub � SSRS Branding Samples](https://github.com/microsoft/sql-server-samples/tree/master/samples/features/reporting-services/branding)
- [BB84.Notifications NuGet](https://www.nuget.org/packages/BB84.Notifications)
- [BB84.Extensions NuGet](https://www.nuget.org/packages/BB84.Extensions)

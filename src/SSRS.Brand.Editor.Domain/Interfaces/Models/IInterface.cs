using System.Drawing;

namespace SSRS.Brand.Editor.Domain.Interfaces.Models;
public interface IInterface
{
	Color Danger { get; set; }
	Color DangerContrast { get; set; }
	Color Info { get; set; }
	Color InfoContrast { get; set; }
	Color KpiBad { get; set; }
	Color KpiBadContrast { get; set; }
	Color KpiGood { get; set; }
	Color KpiGoodContrast { get; set; }
	Color KpiNeutral { get; set; }
	Color KpiNeutralContrast { get; set; }
	Color KpiNone { get; set; }
	Color KpiNoneContrast { get; set; }
	Color NeutralPrimary { get; set; }
	Color NeutralPrimaryAlt { get; set; }
	Color NeutralPrimaryAlt2 { get; set; }
	Color NeutralPrimaryAlt3 { get; set; }
	Color NeutralPrimaryContrast { get; set; }
	Color NeutralSecondary { get; set; }
	Color NeutralSecondaryAlt { get; set; }
	Color NeutralSecondaryAlt2 { get; set; }
	Color NeutralSecondaryAlt3 { get; set; }
	Color NeutralSecondaryContrast { get; set; }
	Color NeutralTertiary { get; set; }
	Color NeutralTertiaryAlt { get; set; }
	Color NeutralTertiaryAlt2 { get; set; }
	Color NeutralTertiaryAlt3 { get; set; }
	Color NeutralTertiaryContrast { get; set; }
	Color Primary { get; set; }
	Color PrimaryAlt { get; set; }
	Color PrimaryAlt2 { get; set; }
	Color PrimaryAlt3 { get; set; }
	Color PrimaryAlt4 { get; set; }
	Color PrimaryContrast { get; set; }
	Color Secondary { get; set; }
	Color SecondaryAlt { get; set; }
	Color SecondaryAlt2 { get; set; }
	Color SecondaryAlt3 { get; set; }
	Color SecondaryContrast { get; set; }
	Color Success { get; set; }
	Color SuccessContrast { get; set; }
	Color Warning { get; set; }
	Color WarningContrast { get; set; }
}
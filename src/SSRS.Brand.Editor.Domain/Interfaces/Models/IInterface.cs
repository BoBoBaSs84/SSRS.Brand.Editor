namespace SSRS.Brand.Editor.Domain.Interfaces.Models;

public interface IInterface
{
	string Danger { get; set; }
	string DangerContrast { get; set; }
	string Info { get; set; }
	string InfoContrast { get; set; }
	string KpiBad { get; set; }
	string KpiBadContrast { get; set; }
	string KpiGood { get; set; }
	string KpiGoodContrast { get; set; }
	string KpiNeutral { get; set; }
	string KpiNeutralContrast { get; set; }
	string KpiNone { get; set; }
	string KpiNoneContrast { get; set; }
	string NeutralPrimary { get; set; }
	string NeutralPrimaryAlt { get; set; }
	string NeutralPrimaryAlt2 { get; set; }
	string NeutralPrimaryAlt3 { get; set; }
	string NeutralPrimaryContrast { get; set; }
	string NeutralSecondary { get; set; }
	string NeutralSecondaryAlt { get; set; }
	string NeutralSecondaryAlt2 { get; set; }
	string NeutralSecondaryAlt3 { get; set; }
	string NeutralSecondaryContrast { get; set; }
	string NeutralTertiary { get; set; }
	string NeutralTertiaryAlt { get; set; }
	string NeutralTertiaryAlt2 { get; set; }
	string NeutralTertiaryAlt3 { get; set; }
	string NeutralTertiaryContrast { get; set; }
	string Primary { get; set; }
	string PrimaryAlt { get; set; }
	string PrimaryAlt2 { get; set; }
	string PrimaryAlt3 { get; set; }
	string PrimaryAlt4 { get; set; }
	string PrimaryContrast { get; set; }
	string Secondary { get; set; }
	string SecondaryAlt { get; set; }
	string SecondaryAlt2 { get; set; }
	string SecondaryAlt3 { get; set; }
	string SecondaryContrast { get; set; }
	string Success { get; set; }
	string SuccessContrast { get; set; }
	string Warning { get; set; }
	string WarningContrast { get; set; }
}
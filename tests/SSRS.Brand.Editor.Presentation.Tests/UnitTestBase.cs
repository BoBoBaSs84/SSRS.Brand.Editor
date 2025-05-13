using System.Reflection;
using System.Windows.Forms;

namespace SSRS.Brand.Editor.Presentation.Tests;
public abstract class UnitTestBase
{
	protected static object? GetNonPublicField(Form form, string fieldName)
	{
		FieldInfo? field = form.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(f => f.Name == fieldName);
		return field?.GetValue(form);
	}

	protected static object? GetNonPublicProperty(Form form, string propertyName)
	{
		PropertyInfo? property = form.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(p => p.Name == propertyName);
		return property?.GetValue(form);
	}

	protected static void InvokeNonPublicMethod(Form form, string methodName, params object[] args)
	{
		MethodInfo? method = form.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(m => m.Name == methodName);
		_ = method?.Invoke(form, args);
	}
}

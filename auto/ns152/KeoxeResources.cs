using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ns152;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class KeoxeResources
{
	private static ResourceManager resourceManager;

	private static CultureInfo culture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceManager == null)
			{
				ResourceManager resources = new ResourceManager("Keoxe365.Properties.Resources", typeof(KeoxeResources).Assembly);
				resourceManager = resources;
			}
			return resourceManager;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return culture;
		}
		set
		{
			culture = value;
		}
	}

	internal static byte[] Sign
	{
		get
		{
			object resource = ResourceManager.GetObject("Sign", culture);
			return (byte[])resource;
		}
	}

	internal KeoxeResources()
	{
	}
}

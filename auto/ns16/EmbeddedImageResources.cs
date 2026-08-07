using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ns16;

[DebuggerNonUserCode]
[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
internal class EmbeddedImageResources
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
				resourceManager = new ResourceManager("EmbeddedImageResources", typeof(EmbeddedImageResources).Assembly);
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

	internal static Bitmap OpenIcon
	{
		get
		{
			object resource = ResourceManager.GetObject("0", culture);
			return (Bitmap)resource;
		}
	}

	internal static Bitmap SaveIcon
	{
		get
		{
			object resource = ResourceManager.GetObject("1", culture);
			return (Bitmap)resource;
		}
	}

	internal static Bitmap WritePathIcon
	{
		get
		{
			object resource = ResourceManager.GetObject("2", culture);
			return (Bitmap)resource;
		}
	}

	internal static Bitmap StopWritePathIcon
	{
		get
		{
			object resource = ResourceManager.GetObject("3", culture);
			return (Bitmap)resource;
		}
	}

	internal static Bitmap QuantityInputBackground
	{
		get
		{
			object resource = ResourceManager.GetObject("nhapsoluong", culture);
			return (Bitmap)resource;
		}
	}

	internal EmbeddedImageResources()
	{
	}
}

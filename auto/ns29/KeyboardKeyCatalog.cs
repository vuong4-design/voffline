namespace ns29;

internal class KeyboardKeyCatalog
{
	public static int int_0 = 1187916127;

	public static int virtualKeyF1 = 112;

	public static int virtualKeyF2 = 113;

	public static int virtualKeyF7 = 118;

	public static int virtualKeyF8 = 119;

	public static int virtualKeyF9 = 120;

	public static int virtualKeyF10 = 121;

	public static int virtualKeyNumpadAdd = 107;

	public static int virtualKeyOemPlus = 187;

	public static int virtualKeyNumpadSubtract = 109;

	public static int virtualKeyOemMinus = 189;

	public static int virtualKeyZ = 90;

	public static int virtualKeyX = 88;

	public static int virtualKeyK = 75;

	public static int virtualKeyA = 65;

	public static int virtualKeyS = 83;

	public static int virtualKeyF = 70;

	public static int virtualKeyG = 71;

	public static int virtualKey1 = 49;

	public static GStruct42[] gstruct42_0 = new GStruct42[10]
	{
		new GStruct42
		{
			string_0 = "A",
			int_0 = 65
		},
		new GStruct42
		{
			string_0 = "S",
			int_0 = 83
		},
		new GStruct42
		{
			string_0 = "Z",
			int_0 = 90
		},
		new GStruct42
		{
			string_0 = "X",
			int_0 = 88
		},
		new GStruct42
		{
			string_0 = "4",
			int_0 = 52
		},
		new GStruct42
		{
			string_0 = "5",
			int_0 = 53
		},
		new GStruct42
		{
			string_0 = "6",
			int_0 = 54
		},
		new GStruct42
		{
			string_0 = "7",
			int_0 = 55
		},
		new GStruct42
		{
			string_0 = "8",
			int_0 = 56
		},
		new GStruct42
		{
			string_0 = "9",
			int_0 = 57
		}
	};

	public static GStruct42[] gstruct42_1 = new GStruct42[9]
	{
		new GStruct42
		{
			string_0 = "1",
			int_0 = 49
		},
		new GStruct42
		{
			string_0 = "2",
			int_0 = 50
		},
		new GStruct42
		{
			string_0 = "3",
			int_0 = 51
		},
		new GStruct42
		{
			string_0 = "4",
			int_0 = 52
		},
		new GStruct42
		{
			string_0 = "5",
			int_0 = 53
		},
		new GStruct42
		{
			string_0 = "6",
			int_0 = 54
		},
		new GStruct42
		{
			string_0 = "7",
			int_0 = 55
		},
		new GStruct42
		{
			string_0 = "8",
			int_0 = 56
		},
		new GStruct42
		{
			string_0 = "9",
			int_0 = 57
		}
	};

	public static GStruct42[] gstruct42_2 = new GStruct42[2]
	{
		new GStruct42
		{
			string_0 = "F2",
			int_0 = 113
		},
		new GStruct42
		{
			string_0 = "A",
			int_0 = 65
		}
	};

	public static int GetVirtualKeyCode(GStruct42[] gstruct42_3, string string_0)
	{
		int num = 0;
		while (true)
		{
			if (num < gstruct42_3.GetLength(0))
			{
				if (string_0 == gstruct42_3[num].string_0)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return gstruct42_3[num].int_0;
	}

	public static string GetKeyLabel(GStruct42[] gstruct42_3, int int_19)
	{
		for (int i = 0; i < gstruct42_3.GetLength(0); i++)
		{
			if (int_19 == gstruct42_3[i].int_0)
			{
				return gstruct42_3[i].string_0;
			}
		}
		return null;
	}
}

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

	public static KeyboardKeyEntry[] gstruct42_0 = new KeyboardKeyEntry[10]
	{
		new KeyboardKeyEntry
		{
			keyLabel = "A",
			virtualKeyCode = 65
		},
		new KeyboardKeyEntry
		{
			keyLabel = "S",
			virtualKeyCode = 83
		},
		new KeyboardKeyEntry
		{
			keyLabel = "Z",
			virtualKeyCode = 90
		},
		new KeyboardKeyEntry
		{
			keyLabel = "X",
			virtualKeyCode = 88
		},
		new KeyboardKeyEntry
		{
			keyLabel = "4",
			virtualKeyCode = 52
		},
		new KeyboardKeyEntry
		{
			keyLabel = "5",
			virtualKeyCode = 53
		},
		new KeyboardKeyEntry
		{
			keyLabel = "6",
			virtualKeyCode = 54
		},
		new KeyboardKeyEntry
		{
			keyLabel = "7",
			virtualKeyCode = 55
		},
		new KeyboardKeyEntry
		{
			keyLabel = "8",
			virtualKeyCode = 56
		},
		new KeyboardKeyEntry
		{
			keyLabel = "9",
			virtualKeyCode = 57
		}
	};

	public static KeyboardKeyEntry[] gstruct42_1 = new KeyboardKeyEntry[9]
	{
		new KeyboardKeyEntry
		{
			keyLabel = "1",
			virtualKeyCode = 49
		},
		new KeyboardKeyEntry
		{
			keyLabel = "2",
			virtualKeyCode = 50
		},
		new KeyboardKeyEntry
		{
			keyLabel = "3",
			virtualKeyCode = 51
		},
		new KeyboardKeyEntry
		{
			keyLabel = "4",
			virtualKeyCode = 52
		},
		new KeyboardKeyEntry
		{
			keyLabel = "5",
			virtualKeyCode = 53
		},
		new KeyboardKeyEntry
		{
			keyLabel = "6",
			virtualKeyCode = 54
		},
		new KeyboardKeyEntry
		{
			keyLabel = "7",
			virtualKeyCode = 55
		},
		new KeyboardKeyEntry
		{
			keyLabel = "8",
			virtualKeyCode = 56
		},
		new KeyboardKeyEntry
		{
			keyLabel = "9",
			virtualKeyCode = 57
		}
	};

	public static KeyboardKeyEntry[] gstruct42_2 = new KeyboardKeyEntry[2]
	{
		new KeyboardKeyEntry
		{
			keyLabel = "F2",
			virtualKeyCode = 113
		},
		new KeyboardKeyEntry
		{
			keyLabel = "A",
			virtualKeyCode = 65
		}
	};

	public static int GetVirtualKeyCode(KeyboardKeyEntry[] gstruct42_3, string string_0)
	{
		int num = 0;
		while (true)
		{
			if (num < gstruct42_3.GetLength(0))
			{
				if (string_0 == gstruct42_3[num].keyLabel)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return gstruct42_3[num].virtualKeyCode;
	}

	public static string GetKeyLabel(KeyboardKeyEntry[] gstruct42_3, int int_19)
	{
		for (int i = 0; i < gstruct42_3.GetLength(0); i++)
		{
			if (int_19 == gstruct42_3[i].virtualKeyCode)
			{
				return gstruct42_3[i].keyLabel;
			}
		}
		return null;
	}
}

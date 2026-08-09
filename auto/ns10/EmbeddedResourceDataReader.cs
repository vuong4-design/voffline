using System;
using System.IO;
using System.Reflection;
using System.Text;
using ns12;

namespace ns10;

internal class EmbeddedResourceDataReader
{
	internal static readonly byte[] ResourceData;

	internal readonly int int_0;

	static EmbeddedResourceDataReader()
	{
		if (ResourceData == null)
		{
			string s = "S2VveGUzNjUuU2lnbg==";
			byte[] array = Convert.FromBase64String(s);
			s = Encoding.UTF8.GetString(array, 0, array.Length);
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(s);
			ResourceData = EmbeddedResourceDecoder.DecodeResourceStream(97L, manifestResourceStream);
		}
	}

	internal static int ReadInt32(int int_1)
	{
		return BitConverter.ToInt32(ResourceData, int_1);
	}

	internal static long ReadInt64(int int_1)
	{
		return BitConverter.ToInt64(ResourceData, int_1);
	}

	internal static float ReadSingle(int int_1)
	{
		return BitConverter.ToSingle(ResourceData, int_1);
	}

	internal static double ReadDouble(int int_1)
	{
		return BitConverter.ToDouble(ResourceData, int_1);
	}

	internal static void CopyLengthPrefixedBlock(Array array_0, int int_1)
	{
		int num = 0;
		if ((ResourceData[int_1] & 0x80) == 0)
		{
			num = ResourceData[int_1];
			int_1++;
		}
		else if ((ResourceData[int_1] & 0x40) == 0)
		{
			num = (ResourceData[int_1] & -129) << 8;
			num |= ResourceData[int_1 + 1];
			int_1 += 2;
		}
		else
		{
			num = (ResourceData[int_1] & -193) << 24;
			num |= ResourceData[int_1 + 1] << 16;
			num |= ResourceData[int_1 + 2] << 8;
			num |= ResourceData[int_1 + 3];
			int_1 += 4;
		}
		if (num >= 1)
		{
			Buffer.BlockCopy(ResourceData, int_1, array_0, 0, num);
		}
	}

	internal static string ConvertBytePairsToString(byte[] byte_1)
	{
		char[] array = new char[byte_1.Length / 2];
		Buffer.BlockCopy(byte_1, 0, array, 0, byte_1.Length);
		return new string(array);
	}
}

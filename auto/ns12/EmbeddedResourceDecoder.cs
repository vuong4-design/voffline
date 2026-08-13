using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Security.Cryptography;

namespace ns12;

internal class EmbeddedResourceDecoder
{
	private static readonly object decodeBufferLock;

	private static readonly int decryptedBufferCapacityOverride;

	private static readonly int decompressedBufferCapacityOverride;

	private static readonly MemoryStream decryptedResourceBuffer;

	private static readonly MemoryStream decompressedResourceBuffer;

	private static readonly byte byte_0;

	static EmbeddedResourceDecoder()
	{
		decryptedResourceBuffer = null;
		decompressedResourceBuffer = null;
		decryptedBufferCapacityOverride = int.MaxValue;
		decompressedBufferCapacityOverride = int.MinValue;
		decryptedResourceBuffer = new MemoryStream(0);
		decompressedResourceBuffer = new MemoryStream(0);
		decodeBufferLock = new object();
	}

	private static string GetAssemblySimpleName(Assembly assembly_0)
	{
		string text = assembly_0.FullName;
		int num = text.IndexOf(',');
		if (num >= 0)
		{
			text = text.Substring(0, num);
		}
		return text;
	}

	private static byte[] GetAssemblyPublicKeyTokenBytes(Assembly assembly_0)
	{
		try
		{
			string fullName = assembly_0.FullName;
			int num = fullName.IndexOf("PublicKeyToken=");
			if (num < 0)
			{
				num = fullName.IndexOf("publickeytoken=");
			}
			if (num >= 0)
			{
				num += 15;
				if (fullName[num] != 'n' && fullName[num] != 'N')
				{
					string s = fullName.Substring(num, 16);
					long value = long.Parse(s, NumberStyles.HexNumber);
					byte[] bytes = BitConverter.GetBytes(value);
					Array.Reverse(bytes);
					return bytes;
				}
				return null;
			}
			return null;
		}
		catch
		{
		}
		return null;
	}

	internal static byte[] DecodeProtectedResourceStream(Stream stream_0)
	{
		lock (decodeBufferLock)
		{
			return DecodeProtectedResourcePayload(97L, stream_0);
		}
	}

	internal static byte[] DecodeResourceStream(long long_0, Stream stream_0)
	{
		try
		{
			return DecodeProtectedResourceStream(stream_0);
		}
		catch
		{
			return DecodeProtectedResourcePayload(97L, stream_0);
		}
	}

	internal static byte[] DecodeProtectedResourcePayload(long long_0, object object_1)
	{
		Stream stream = object_1 as Stream;
		Stream stream2 = stream;
		MemoryStream memoryStream = null;
		for (int i = 1; i < 4; i++)
		{
			stream.ReadByte();
		}
		ushort num = (ushort)stream.ReadByte();
		num = (ushort)(~num);
		if ((num & 2) != 0)
		{
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			byte[] array = new byte[8];
			stream.Read(array, 0, 8);
			dESCryptoServiceProvider.IV = array;
			byte[] array2 = new byte[8];
			stream.Read(array2, 0, 8);
			bool flag = true;
			byte[] array3 = array2;
			for (int j = 0; j < array3.Length; j++)
			{
				if (array3[j] != 0)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				array2 = GetAssemblyPublicKeyTokenBytes(Assembly.GetExecutingAssembly());
			}
			dESCryptoServiceProvider.Key = array2;
			if (decryptedResourceBuffer == null)
			{
				if (decryptedBufferCapacityOverride != int.MaxValue)
				{
					decryptedResourceBuffer.Capacity = decryptedBufferCapacityOverride;
				}
				else
				{
					decryptedResourceBuffer.Capacity = (int)stream.Length;
				}
			}
			decryptedResourceBuffer.Position = 0L;
			ICryptoTransform cryptoTransform = dESCryptoServiceProvider.CreateDecryptor();
			int inputBlockSize = cryptoTransform.InputBlockSize;
			_ = cryptoTransform.OutputBlockSize;
			byte[] array4 = new byte[cryptoTransform.OutputBlockSize];
			byte[] array5 = new byte[cryptoTransform.InputBlockSize];
			int k;
			for (k = (int)stream.Position; k + inputBlockSize < stream.Length; k += inputBlockSize)
			{
				stream.Read(array5, 0, inputBlockSize);
				int count = cryptoTransform.TransformBlock(array5, 0, inputBlockSize, array4, 0);
				decryptedResourceBuffer.Write(array4, 0, count);
			}
			stream.Read(array5, 0, (int)(stream.Length - k));
			byte[] array6 = cryptoTransform.TransformFinalBlock(array5, 0, (int)(stream.Length - k));
			decryptedResourceBuffer.Write(array6, 0, array6.Length);
			stream2 = decryptedResourceBuffer;
			stream2.Position = 0L;
			memoryStream = decryptedResourceBuffer;
		}
		if ((num & 8) != 0)
		{
			if (decompressedResourceBuffer == null)
			{
				if (decompressedBufferCapacityOverride != int.MinValue)
				{
					decompressedResourceBuffer.Capacity = decompressedBufferCapacityOverride;
				}
				else
				{
					decompressedResourceBuffer.Capacity = (int)stream2.Length * 2;
				}
			}
			decompressedResourceBuffer.Position = 0L;
			DeflateStream deflateStream = new DeflateStream(stream2, CompressionMode.Decompress);
			int num2 = 1000;
			byte[] buffer = new byte[1000];
			int num3;
			do
			{
				num3 = deflateStream.Read(buffer, 0, num2);
				if (num3 > 0)
				{
					decompressedResourceBuffer.Write(buffer, 0, num3);
				}
			}
			while (num3 >= num2);
			memoryStream = decompressedResourceBuffer;
		}
		if (memoryStream == null)
		{
			byte[] array7 = new byte[stream.Length - stream.Position];
			stream.Read(array7, 0, array7.Length);
			return array7;
		}
		return memoryStream.ToArray();
	}
}

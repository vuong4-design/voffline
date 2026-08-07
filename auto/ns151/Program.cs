using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns100;

namespace ns151;

internal static class Program
{
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern IntPtr LoadLibrary(string libraryPath);

	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		try
		{
			string debugLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "debug_log.txt");
			if (File.Exists(debugLogPath))
			{
				try
				{
					File.Delete(debugLogPath);
				}
				catch (Exception ex)
				{
					File.AppendAllText("Error_Log.txt", $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Error: Không thể xóa debug_log.txt khi khởi động. Lỗi: {ex.Message}\n");
				}
			}
			string importDllPath = Path.Combine(Path.GetTempPath(), "import.dll");
			string eDllPath = Path.Combine(Path.GetTempPath(), "e.dll");
			ExtractAndLoadEmbeddedLibrary("import.dll", "Keoxe365.import.dll", importDllPath, debugLogPath);
			ExtractAndLoadEmbeddedLibrary("e.dll", "Keoxe365.e.dll", eDllPath, debugLogPath);
			string errorLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Error_Log.txt");
			Application.ApplicationExit += delegate
			{
				try
				{
					if (File.Exists(importDllPath))
					{
						File.Delete(importDllPath);
					}
					if (File.Exists(eDllPath))
					{
						File.Delete(eDllPath);
					}
					if (File.Exists(debugLogPath))
					{
						File.Delete(debugLogPath);
					}
					if (File.Exists(errorLogPath))
					{
						File.Delete(errorLogPath);
					}
				}
				catch (Exception)
				{
				}
			};
			Application.Run(new Form1());
		}
		catch (Exception ex2)
		{
			File.AppendAllText("Error_Log.txt", $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Error: {ex2.Message}\n");
		}
	}

	private static void ExtractAndLoadEmbeddedLibrary(string libraryName, string resourceName, string outputPath, string debugLogPath)
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		using Stream stream = executingAssembly.GetManifestResourceStream(resourceName);
		if (stream == null)
		{
			throw new Exception("Không tìm thấy " + libraryName + " trong tài nguyên (" + resourceName + "). Kiểm tra lại tên tài nguyên hoặc build dự án.");
		}
		byte[] libraryBytes = new byte[stream.Length];
		stream.Read(libraryBytes, 0, libraryBytes.Length);
		try
		{
			File.WriteAllBytes(outputPath, libraryBytes);
		}
		catch (UnauthorizedAccessException ex)
		{
			throw new Exception("Không thể ghi " + libraryName + " vào " + outputPath + ". Vui lòng chạy ứng dụng với quyền Administrator. Lỗi: " + ex.Message);
		}
		IntPtr moduleHandle = LoadLibrary(outputPath);
		if (moduleHandle == IntPtr.Zero)
		{
			int lastWin32Error = Marshal.GetLastWin32Error();
			throw new Exception($"Không thể tải {libraryName}. Mã lỗi: {lastWin32Error}");
		}
		if (File.Exists(debugLogPath))
		{
			try
			{
				File.Delete(debugLogPath);
				return;
			}
			catch (Exception ex2)
			{
				File.AppendAllText("Error_Log.txt", $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Error: Không thể xóa debug_log.txt sau khi tải {libraryName}. Lỗi: {ex2.Message}\n");
				return;
			}
		}
	}
}

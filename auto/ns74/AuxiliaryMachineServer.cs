using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ns11;
using ns121;
using ns43;
using ns73;

namespace ns74;

internal class AuxiliaryMachineServer
{
	public TcpListener listener = null;

	private void HandleClient(object state)
	{
		TcpClient client = (TcpClient)state;
		NetworkStream stream = client.GetStream();
		byte[] buffer = new byte[80];
		string clientIdentity = null;
		string cachedUpdatePayload = null;
		Class77.long_0 = 0L;
		try
		{
			bool snapshotUnavailable = false;
			while (!Class11.bool_0 && Class77.int_0 > 0)
			{
				Class77.long_0++;
				Thread.Sleep(120);
				int bytesRead = stream.Read(buffer, 0, buffer.Length);
				if (bytesRead <= 0)
				{
					continue;
				}
				if (buffer[0] == 1)
				{
					if (!snapshotUnavailable)
					{
						string response = null;
						if (!AuxiliaryMachineManager.bool_8)
						{
							response = Class77.smethod_5();
						}
						else
						{
							if (AuxiliaryMachineManager.long_0 == 0L || cachedUpdatePayload == null)
							{
								AuxiliaryMachineManager.long_0 = Class11.smethod_27();
								cachedUpdatePayload = "UP:" + AuxiliaryMachineManager.smethod_0();
							}
							if (Class11.smethod_28(AuxiliaryMachineManager.long_0) < AuxiliaryMachineManager.long_1)
							{
								response = cachedUpdatePayload;
							}
							else
							{
								AuxiliaryMachineManager.bool_8 = false;
								AuxiliaryMachineManager.long_0 = 0L;
								cachedUpdatePayload = null;
							}
						}
						if (response != null && response != string.Empty)
						{
							byte[] responseBytes = Encoding.ASCII.GetBytes(response);
							stream.Write(responseBytes, 0, responseBytes.Length);
						}
					}
					else
					{
						byte[] placeholder = new byte[4] { 46, 46, 46, 0 };
						stream.Write(placeholder, 0, placeholder.Length);
						Thread.Sleep(180);
					}
					snapshotUnavailable = Class46.characterSyncSnapshot_0.int_0 <= 0;
				}
				else
				{
					string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
					if (0 > message.IndexOf("..."))
					{
						Class77.string_0 = message;
						continue;
					}
					clientIdentity = message;
					Class77.string_0 = Class77.smethod_2() + "\t" + clientIdentity + "client connect.";
				}
			}
		}
		catch
		{
		}
		try
		{
			if (clientIdentity != null)
			{
				Class77.string_0 = Class77.smethod_2() + "\t" + clientIdentity + "client exit.";
			}
			client.Close();
		}
		catch
		{
		}
	}

	public void Run()
	{
		if (Class77.string_1 != null && !(Class77.string_1 == string.Empty))
		{
			if (Class77.int_2 <= 0)
			{
				Class77.int_2 = new Random().Next(5000, 20000);
			}
			Class77.string_0 = Class77.smethod_2() + "\tKhởi tạo server...";
			try
			{
				IPAddress localAddress = IPAddress.Parse(Class77.string_1);
				listener = new TcpListener(localAddress, Class77.int_2);
				listener.Start();
				Class77.string_0 = Class77.smethod_2() + "\tThành công!";
				while (!Class11.bool_0 && Class77.int_0 > 0)
				{
					TcpClient client = listener.AcceptTcpClient();
					ThreadPool.QueueUserWorkItem(HandleClient, client);
					Thread.Sleep(600);
				}
				Class77.string_0 = Class77.smethod_2() + "\tKết thúc server.";
				Stop();
				return;
			}
			catch
			{
				Stop();
				if (Class77.int_0 > 0)
				{
					Class77.string_0 = Class77.smethod_2() + "\tSever có lỗi, hãy thử đổi password khác...";
					Class77.int_0 = 0;
				}
				return;
			}
		}
		Class77.string_0 = "Chưa thiết lập IP máy chính.";
		Stop();
		Class77.int_0 = 0;
	}

	public void Stop()
	{
		try
		{
			listener.Stop();
		}
		catch
		{
		}
	}
}

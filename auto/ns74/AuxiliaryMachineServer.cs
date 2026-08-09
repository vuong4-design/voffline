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
		AuxiliaryMachineSyncCoordinator.long_0 = 0L;
		try
		{
			bool snapshotUnavailable = false;
			while (!Class11.bool_0 && AuxiliaryMachineSyncCoordinator.int_0 > 0)
			{
				AuxiliaryMachineSyncCoordinator.long_0++;
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
							response = AuxiliaryMachineSyncCoordinator.BuildSyncMessage();
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
						AuxiliaryMachineSyncCoordinator.StatusMessage = message;
						continue;
					}
					clientIdentity = message;
					AuxiliaryMachineSyncCoordinator.StatusMessage = AuxiliaryMachineSyncCoordinator.GetTimestamp() + "\t" + clientIdentity + "client connect.";
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
				AuxiliaryMachineSyncCoordinator.StatusMessage = AuxiliaryMachineSyncCoordinator.GetTimestamp() + "\t" + clientIdentity + "client exit.";
			}
			client.Close();
		}
		catch
		{
		}
	}

	public void Run()
	{
		if (AuxiliaryMachineSyncCoordinator.LocalIpAddress != null && !(AuxiliaryMachineSyncCoordinator.LocalIpAddress == string.Empty))
		{
			if (AuxiliaryMachineSyncCoordinator.ServerPort <= 0)
			{
				AuxiliaryMachineSyncCoordinator.ServerPort = new Random().Next(5000, 20000);
			}
			AuxiliaryMachineSyncCoordinator.StatusMessage = AuxiliaryMachineSyncCoordinator.GetTimestamp() + "\tKhởi tạo server...";
			try
			{
				IPAddress localAddress = IPAddress.Parse(AuxiliaryMachineSyncCoordinator.LocalIpAddress);
				listener = new TcpListener(localAddress, AuxiliaryMachineSyncCoordinator.ServerPort);
				listener.Start();
				AuxiliaryMachineSyncCoordinator.StatusMessage = AuxiliaryMachineSyncCoordinator.GetTimestamp() + "\tThành công!";
				while (!Class11.bool_0 && AuxiliaryMachineSyncCoordinator.int_0 > 0)
				{
					TcpClient client = listener.AcceptTcpClient();
					ThreadPool.QueueUserWorkItem(HandleClient, client);
					Thread.Sleep(600);
				}
				AuxiliaryMachineSyncCoordinator.StatusMessage = AuxiliaryMachineSyncCoordinator.GetTimestamp() + "\tKết thúc server.";
				Stop();
				return;
			}
			catch
			{
				Stop();
				if (AuxiliaryMachineSyncCoordinator.int_0 > 0)
				{
					AuxiliaryMachineSyncCoordinator.StatusMessage = AuxiliaryMachineSyncCoordinator.GetTimestamp() + "\tSever có lỗi, hãy thử đổi password khác...";
					AuxiliaryMachineSyncCoordinator.int_0 = 0;
				}
				return;
			}
		}
		AuxiliaryMachineSyncCoordinator.StatusMessage = "Chưa thiết lập IP máy chính.";
		Stop();
		AuxiliaryMachineSyncCoordinator.int_0 = 0;
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

using System.Net.Sockets;
using System.Text;
using System.Threading;
using ns11;
using ns73;

namespace ns75;

internal class AuxiliaryMachineClient
{
	public TcpClient client = null;

	public NetworkStream stream = null;

	private long lastActivityTick = 0L;

	public void SendKeepAlive(object state)
	{
		try
		{
			NetworkStream keepAliveStream = (NetworkStream)state;
			byte[] keepAlive = new byte[1] { 1 };
			while (!CommonUtility.bool_0 && AuxiliaryMachineSyncCoordinator.int_0 > 0 && 0L <= lastActivityTick)
			{
				if (CommonUtility.GetElapsedMilliseconds(lastActivityTick) > 1000L)
				{
					keepAliveStream.Write(keepAlive, 0, 1);
					lastActivityTick = CommonUtility.GetCurrentTicks();
				}
				Thread.Sleep(300);
			}
		}
		catch
		{
		}
	}

	public void Run()
	{
		if (AuxiliaryMachineSyncCoordinator.RemoteIpAddress != null && !(AuxiliaryMachineSyncCoordinator.RemoteIpAddress == string.Empty))
		{
			if (AuxiliaryMachineSyncCoordinator.LocalIpAddress == null || AuxiliaryMachineSyncCoordinator.LocalIpAddress == string.Empty)
			{
				AuxiliaryMachineSyncCoordinator.LocalIpAddress = "127.0.0.0";
			}
			int defaultBufferSize = 256;
			byte[] keepAlive = new byte[1] { 1 };
			byte[] receiveBuffer = new byte[256];
			byte[] clientIdentity = Encoding.ASCII.GetBytes(AuxiliaryMachineSyncCoordinator.LocalIpAddress + "...");
			bool connectionStatusShown = false;
			int updateChunkCount = 0;
			while (true)
			{
				Thread.Sleep(600);
				if (CommonUtility.bool_0 || AuxiliaryMachineSyncCoordinator.int_0 <= 0)
				{
					break;
				}
				if (!connectionStatusShown)
				{
					AuxiliaryMachineSyncCoordinator.StatusMessage = AuxiliaryMachineSyncCoordinator.GetTimestamp() + "\tChờ kết nối đến " + AuxiliaryMachineSyncCoordinator.RemoteIpAddress + "...";
					connectionStatusShown = true;
				}
				try
				{
					client = new TcpClient(AuxiliaryMachineSyncCoordinator.RemoteIpAddress, AuxiliaryMachineSyncCoordinator.RemotePort);
					stream = client.GetStream();
					stream.Write(clientIdentity, 0, clientIdentity.Length);
					AuxiliaryMachineSyncCoordinator.StatusMessage = AuxiliaryMachineSyncCoordinator.GetTimestamp() + "\tKết nối thành công";
					connectionStatusShown = false;
					lastActivityTick = 0L;
					ThreadPool.QueueUserWorkItem(SendKeepAlive, stream);
					int emptyReadCount = 0;
					do
					{
						emptyReadCount++;
						AuxiliaryMachineSyncCoordinator.long_0++;
						Thread.Sleep(130);
						if (!CommonUtility.bool_0 && AuxiliaryMachineSyncCoordinator.int_0 > 0)
						{
							lastActivityTick = CommonUtility.GetCurrentTicks();
							int bytesRead = stream.Read(receiveBuffer, 0, receiveBuffer.Length);
							if (bytesRead > 0)
							{
								string message = Encoding.ASCII.GetString(receiveBuffer, 0, bytesRead);
								if (message != string.Empty && message != null)
								{
									if (updateChunkCount == 0)
									{
										if (message[0] == 'U' && message[1] == 'P')
										{
											receiveBuffer = new byte[2048];
											updateChunkCount = 1;
										}
									}
									else
									{
										updateChunkCount++;
										if (message[0] == '@' || updateChunkCount > 300)
										{
											receiveBuffer = new byte[defaultBufferSize];
											updateChunkCount = 0;
										}
									}
									AuxiliaryMachineSyncCoordinator.ApplySyncMessage(message);
								}
								emptyReadCount = 0;
							}
							stream.Write(keepAlive, 0, 1);
							continue;
						}
						stream.Close();
						return;
					}
					while (emptyReadCount < 60);
				}
				catch
				{
				}
				if (!connectionStatusShown)
				{
					AuxiliaryMachineSyncCoordinator.StatusMessage = AuxiliaryMachineSyncCoordinator.GetTimestamp() + "\tGián đoạn.";
				}
				Close();
				Thread.Sleep(999);
			}
			AuxiliaryMachineSyncCoordinator.StatusMessage = AuxiliaryMachineSyncCoordinator.GetTimestamp() + "\tKết thúc.";
			Close();
		}
		else
		{
			AuxiliaryMachineSyncCoordinator.StatusMessage = "Chưa thiết lập IP máy phụ.";
			Close();
		}
	}

	public void Close()
	{
		try
		{
			stream.Close();
		}
		catch
		{
		}
		try
		{
			client.Close();
		}
		catch
		{
		}
	}
}

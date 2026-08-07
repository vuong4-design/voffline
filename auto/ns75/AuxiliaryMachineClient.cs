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
			while (!Class11.bool_0 && Class77.int_0 > 0 && 0L <= lastActivityTick)
			{
				if (Class11.smethod_28(lastActivityTick) > 1000L)
				{
					keepAliveStream.Write(keepAlive, 0, 1);
					lastActivityTick = Class11.smethod_27();
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
		if (Class77.string_2 != null && !(Class77.string_2 == string.Empty))
		{
			if (Class77.string_1 == null || Class77.string_1 == string.Empty)
			{
				Class77.string_1 = "127.0.0.0";
			}
			int defaultBufferSize = 256;
			byte[] keepAlive = new byte[1] { 1 };
			byte[] receiveBuffer = new byte[256];
			byte[] clientIdentity = Encoding.ASCII.GetBytes(Class77.string_1 + "...");
			bool connectionStatusShown = false;
			int updateChunkCount = 0;
			while (true)
			{
				Thread.Sleep(600);
				if (Class11.bool_0 || Class77.int_0 <= 0)
				{
					break;
				}
				if (!connectionStatusShown)
				{
					Class77.string_0 = Class77.smethod_2() + "\tChờ kết nối đến " + Class77.string_2 + "...";
					connectionStatusShown = true;
				}
				try
				{
					client = new TcpClient(Class77.string_2, Class77.int_3);
					stream = client.GetStream();
					stream.Write(clientIdentity, 0, clientIdentity.Length);
					Class77.string_0 = Class77.smethod_2() + "\tKết nối thành công";
					connectionStatusShown = false;
					lastActivityTick = 0L;
					ThreadPool.QueueUserWorkItem(SendKeepAlive, stream);
					int emptyReadCount = 0;
					do
					{
						emptyReadCount++;
						Class77.long_0++;
						Thread.Sleep(130);
						if (!Class11.bool_0 && Class77.int_0 > 0)
						{
							lastActivityTick = Class11.smethod_27();
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
									Class77.smethod_4(message);
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
					Class77.string_0 = Class77.smethod_2() + "\tGián đoạn.";
				}
				Close();
				Thread.Sleep(999);
			}
			Class77.string_0 = Class77.smethod_2() + "\tKết thúc.";
			Close();
		}
		else
		{
			Class77.string_0 = "Chưa thiết lập IP máy phụ.";
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

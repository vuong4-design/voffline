using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ns100;
using ns23;
using ns31;
using ns53;
using ns83;

namespace ns148;

public class GForm0 : Form
{
	private string characterActionStateText = "";

	private bool useRaisedStatusImageOffset = false;

	private PointF? targetScreenPosition = null;

	private float targetOverlayStateValue = 0f;

	private uint targetEntityIndex = 0u;

	public static int int_0 = 0;

	public static string string_1 = "";

	public float float_1 = 230f;

	private float overlayCenterX;

	private float overlayCenterY;

	public float float_4 = 1.9f;

	public float float_5 = 1f;

	public float float_6 = 20f;

	public bool bool_1 = false;

	private const float float_7 = 1f;

	private const float float_8 = 1f;

	public float float_9 = 2.08f;

	public float float_10 = 0.92f;

	public float float_11 = -15f;

	private static Image animatedStatusImage;

	private float primaryFloatingTextOpacity = 0f;

	private float primaryFloatingTextYOffset = 0f;

	private string primaryFloatingText = "";

	private Timer primaryFloatingTextFadeTimer;

	private float secondaryFloatingTextOpacity = 0f;

	private float secondaryFloatingTextYOffset = 0f;

	private string secondaryFloatingText = "";

	private Timer secondaryFloatingTextFadeTimer;

	private bool secondaryFloatingTextFadeCompleted = true;

	private bool secondaryFloatingTextFadeStarted = false;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.ExStyle |= 524448;
			return createParams;
		}
	}

	public GForm0()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		base.FormBorderStyle = FormBorderStyle.None;
		base.ShowInTaskbar = false;
		base.TopMost = true;
		BackColor = Color.Magenta;
		base.TransparencyKey = Color.Magenta;
		base.Enabled = false;
		DoubleBuffered = true;
	}

	public void method_0(float float_16, float float_17 = 1f, float float_18 = 1f, float float_19 = 0f)
	{
		if (float_16 > 0f)
		{
			float_1 = float_16;
		}
		float_4 = ((float_17 > 0f) ? float_17 : 1f);
		float_5 = ((float_18 > 0f) ? float_18 : 1f);
		float_6 = Math.Max(0f, float_19);
		Invalidate();
	}

	public void method_1(string string_4)
	{
		if (animatedStatusImage != null)
		{
			ImageAnimator.StopAnimate(animatedStatusImage, InvalidateOnAnimatedImageFrameChanged);
			animatedStatusImage.Dispose();
			animatedStatusImage = null;
		}
		if (!string.IsNullOrEmpty(string_4) && File.Exists(string_4))
		{
			animatedStatusImage = Image.FromFile(string_4);
			ImageAnimator.Animate(animatedStatusImage, InvalidateOnAnimatedImageFrameChanged);
		}
	}

	private void InvalidateOnAnimatedImageFrameChanged(object sender, EventArgs e)
	{
		Invalidate();
	}

	private void StartPrimaryFloatingTextFade(string string_4)
	{
		primaryFloatingText = string_4;
		primaryFloatingTextOpacity = 1f;
		primaryFloatingTextYOffset = 0f;
		if (primaryFloatingTextFadeTimer == null)
		{
			primaryFloatingTextFadeTimer = new Timer();
			primaryFloatingTextFadeTimer.Interval = 50;
			primaryFloatingTextFadeTimer.Tick += delegate
			{
				primaryFloatingTextOpacity -= 0.05f;
				primaryFloatingTextYOffset -= 1.5f;
				if (primaryFloatingTextOpacity <= 0f)
				{
					primaryFloatingTextFadeTimer.Stop();
				}
				Invalidate();
			};
		}
		primaryFloatingTextFadeTimer.Start();
	}

	private void StartSecondaryFloatingTextFade(string string_4)
	{
		secondaryFloatingText = string_4;
		secondaryFloatingTextOpacity = 1f;
		secondaryFloatingTextYOffset = 0f;
		secondaryFloatingTextFadeCompleted = false;
		if (secondaryFloatingTextFadeTimer == null)
		{
			secondaryFloatingTextFadeTimer = new Timer();
			secondaryFloatingTextFadeTimer.Interval = 50;
			secondaryFloatingTextFadeTimer.Tick += delegate
			{
				secondaryFloatingTextOpacity -= 0.05f;
				secondaryFloatingTextYOffset -= 1.5f;
				if (secondaryFloatingTextOpacity <= 0f)
				{
					secondaryFloatingTextFadeTimer.Stop();
					secondaryFloatingTextFadeCompleted = true;
				}
				Invalidate();
			};
		}
		secondaryFloatingTextFadeTimer.Start();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		if (!string.IsNullOrEmpty(string_1) && !string.IsNullOrEmpty(string_1) && !string_1.Contains("Không hiện"))
		{
			using Font font = new Font("Tahoma", 14f, FontStyle.Bold);
			CharacterAccountConfig characterAccountConfig_ = default(CharacterAccountConfig);
			int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, Form1.mainAccountId);
			if (num >= 0)
			{
				characterAccountConfig_ = Form1.characterAccountConfig_1[num];
			}
			string s = Class32.CountInventoryItemsByName(characterAccountConfig_, string_1).ToString();
			Brush brush = new SolidBrush(Color.HotPink);
			e.Graphics.DrawString(s, font, brush, 50f, 100f);
			e.Graphics.MeasureString(s, font);
		}
		if (Form1.overlayRangeCircleEnabled)
		{
			string[] source = new string[5] { "Đánh", "Đánh phép thuật", "Chạy tấn công", "Nhảy tấn công", "Đánh liên tiếp" };
			Color color = (source.Any((string string_4) => string_4.Equals(characterActionStateText, StringComparison.OrdinalIgnoreCase)) ? Color.Red : Color.Lime);
			using Pen pen = new Pen(color, 2f);
			float num2 = float_1 * ((float_4 > 0f) ? float_4 : 1f);
			float num3 = float_1 * ((float_5 > 0f) ? float_5 : 1f);
			float num4 = ((float_6 > 0f) ? float_6 : 0f);
			float num5 = Math.Max(1f, num3 - num4 * 0.5f);
			float num6 = overlayCenterY + num4 * 0.5f;
			RectangleF rect = new RectangleF(overlayCenterX - num2, num6 - num5, num2 * 2f, num5 * 2f);
			e.Graphics.DrawEllipse(pen, rect);
		}
		if (animatedStatusImage != null && Form1.overlayStatusAnimationEnabled)
		{
			ImageAnimator.UpdateFrames(animatedStatusImage);
			float num7 = 80f;
			if (useRaisedStatusImageOffset)
			{
				num7 = 105f;
			}
			e.Graphics.DrawImage(animatedStatusImage, overlayCenterX - (float)animatedStatusImage.Width / 2f, overlayCenterY - (float)animatedStatusImage.Height - num7, animatedStatusImage.Width, animatedStatusImage.Height);
		}
		if (primaryFloatingTextOpacity > 0f)
		{
			using Font font2 = new Font("Arial", 16f, FontStyle.Bold);
			int alpha = Math.Max(0, Math.Min(255, (int)(primaryFloatingTextOpacity * 255f)));
			using Brush brush2 = new SolidBrush(Color.FromArgb(alpha, Color.Red));
			SizeF sizeF = e.Graphics.MeasureString(primaryFloatingText, font2);
			if (Form1.overlayFloatingTextEnabled)
			{
				e.Graphics.DrawString(primaryFloatingText, font2, brush2, overlayCenterX - sizeF.Width / 2f, overlayCenterY - 120f + primaryFloatingTextYOffset);
			}
		}
		if ((characterActionStateText == "Về dưỡng sức" || characterActionStateText == "Chết") && primaryFloatingTextOpacity <= 0f)
		{
			StartPrimaryFloatingTextFade("Oẳng Rồi");
		}
		if (!targetScreenPosition.HasValue)
		{
			return;
		}
		PointF value = targetScreenPosition.Value;
		float num8 = 10f;
		e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
		if (secondaryFloatingTextOpacity > 0f)
		{
			using Font font3 = new Font("Arial", 16f, FontStyle.Bold);
			int alpha2 = Math.Max(0, Math.Min(255, (int)(secondaryFloatingTextOpacity * 255f)));
			using Brush brush3 = new SolidBrush(Color.FromArgb(alpha2, Color.Red));
			SizeF sizeF2 = e.Graphics.MeasureString(secondaryFloatingText, font3);
			if (Form1.overlayFloatingTextEnabled)
			{
				e.Graphics.DrawString(secondaryFloatingText, font3, brush3, value.X - sizeF2.Width / 2f, value.Y - 120f + secondaryFloatingTextYOffset);
			}
		}
		if (targetOverlayStateValue == 0f)
		{
			if (!secondaryFloatingTextFadeStarted)
			{
				StartSecondaryFloatingTextFade("Lụm Lúa");
				secondaryFloatingTextFadeStarted = true;
			}
			if (secondaryFloatingTextFadeCompleted)
			{
				targetScreenPosition = null;
				secondaryFloatingTextFadeStarted = false;
			}
		}
		else
		{
			secondaryFloatingTextFadeStarted = false;
		}
		if (Form1.overlayTargetMarkerEnabled)
		{
			using (Pen pen2 = new Pen(Color.Yellow, 2f))
			{
				RectangleF rect2 = new RectangleF(value.X - num8, value.Y - num8, num8 * 2f, num8 * 2f);
				e.Graphics.DrawEllipse(pen2, rect2);
			}
			using (Pen pen3 = new Pen(Color.Red, 2f))
			{
				float num9 = num8 * (float)Math.Sqrt(2.0);
				e.Graphics.DrawLine(pen3, value.X - num9 / 2f, value.Y - num9 / 2f, value.X + num9 / 2f, value.Y + num9 / 2f);
				e.Graphics.DrawLine(pen3, value.X + num9 / 2f, value.Y - num9 / 2f, value.X - num9 / 2f, value.Y + num9 / 2f);
			}
			if (targetEntityIndex == 0 && secondaryFloatingTextFadeCompleted)
			{
				targetScreenPosition = null;
			}
		}
	}

	public void method_5(CharacterAccountConfig characterAccountConfig_0)
	{
		try
		{
			if (characterAccountConfig_0.process_0 == null)
			{
				Hide();
				return;
			}
			if (characterAccountConfig_0.process_0.HasExited)
			{
				Hide();
				return;
			}
			uint uint_ = (uint)(int)characterAccountConfig_0.process_0.MainWindowHandle;
			GStruct13 gstruct13_ = default(GStruct13);
			if (!WindowsInteropHelper.GetWindowRect(uint_, ref gstruct13_))
			{
				Hide();
				return;
			}
			int num = Math.Max(100, gstruct13_.int_2 - gstruct13_.int_0);
			int num2 = Math.Max(100, gstruct13_.int_3 - gstruct13_.int_1);
			if (base.Location.X != gstruct13_.int_0 || base.Location.Y != gstruct13_.int_1 || base.Width != num || base.Height != num2)
			{
				base.Location = new Point(gstruct13_.int_0, gstruct13_.int_1);
				base.Size = new Size(num, num2);
			}
			if ((IntPtr)WindowsInteropHelper.GetForegroundWindow() == characterAccountConfig_0.process_0.MainWindowHandle)
			{
				Show();
			}
			else
			{
				Hide();
			}
			uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
			uint num4 = WindowsInteropHelper.ReadProcessUInt32(num3 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137);
			uint num5 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
			uint num6 = GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
			uint num7 = num5 + num4 * num6;
			uint num8 = WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137);
			uint num9 = WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137);
			uint num10 = WindowsInteropHelper.ReadProcessUInt32(num7 + 236, characterAccountConfig_0.int_137);
			uint num11 = WindowsInteropHelper.ReadProcessUInt32(num7 + 6008, characterAccountConfig_0.int_137);
			targetEntityIndex = WindowsInteropHelper.ReadProcessUInt32(num7 + 5020, characterAccountConfig_0.int_137);
			WindowsInteropHelper.ReadProcessUInt32(num7 + 4168, characterAccountConfig_0.int_137);
			useRaisedStatusImageOffset = num11 == 1;
			if (num10 < GameConfigurationManager.string_24.Length)
			{
				characterActionStateText = GameConfigurationManager.string_24[num10];
			}
			else
			{
				characterActionStateText = $"Unknown({num10})";
			}
			overlayCenterX = (float)num * 0.5f;
			overlayCenterY = (float)num2 * 0.5f;
			byte[] array = new byte[4];
			int int_ = 0;
			int num12 = characterAccountConfig_0.int_97;
			if (characterAccountConfig_0.int_98 > 0)
			{
				num12 = characterAccountConfig_0.int_99;
			}
			if (characterAccountConfig_0.int_95 > 0 && characterAccountConfig_0.int_96 > 0)
			{
				num12 = characterAccountConfig_0.int_96;
			}
			if (num12 <= 0)
			{
				num12 = 500;
			}
			long num13 = (long)num12 * (long)num12;
			float num14 = 1f;
			try
			{
				float num15 = (float)Math.Min(num, num2) * 0.45f;
				num14 = ((num12 > 0) ? (num15 / (float)num12) : 1f);
				if (num14 <= 0f || float.IsNaN(num14) || float.IsInfinity(num14))
				{
					num14 = 1f;
				}
			}
			catch
			{
				num14 = 1f;
			}
			targetOverlayStateValue = 0f;
			uint num16 = num5 + targetEntityIndex * num6;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num16, array, 4, ref int_);
			int num17 = BitConverter.ToInt32(array, 0);
			if (num17 != 0 && num17 != -1)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num16 + 4168, array, 4, ref int_);
				targetOverlayStateValue = BitConverter.ToInt32(array, 0);
				if (!(targetOverlayStateValue <= 0f))
				{
					uint num18 = WindowsInteropHelper.ReadProcessUInt32(num16 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137);
					uint num19 = WindowsInteropHelper.ReadProcessUInt32(num16 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137);
					long num20 = (long)num18 - (long)num8;
					long num21 = (long)num19 - (long)num9;
					long num22 = num20 * num20 + num21 * num21;
					if (num22 <= num13 || characterAccountConfig_0.int_95 > 0)
					{
						float num23 = overlayCenterX + (float)num20 * num14;
						float num24 = overlayCenterY + (float)num21 * num14;
						if (!(num23 < -1000f) && !(num24 < -1000f) && !(num23 > (float)(num + 1000)) && !(num24 > (float)(num2 + 1000)))
						{
							targetScreenPosition = new PointF(num23, num24);
						}
					}
				}
			}
			Invalidate();
		}
		catch (Exception ex)
		{
			Console.WriteLine("[ERROR] Exception in UpdateOverlay: " + ex.Message + "\n" + ex.StackTrace);
		}
	}
}

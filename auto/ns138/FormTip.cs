using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns100;
using ns11;
using ns53;
using ns63;

namespace ns138;

public class FormTip : Form
{
	private IContainer icontainer_0 = null;

	private CheckBox checkBoxKhongHienthi;

	private Button buttonDong;

	private Timer timer_0;

	private RichTextBox richTextBoxStatus;

	private Button buttonCopy;

	public static bool isTipWindowOpen = false;

	public bool disableDontShowAgainCheckbox = false;

	public bool rawTextFormattingPreserved = false;

	public string messageText = null;

	public string windowTitle = null;

	public string suppressionRegistryValueName = null;

	public int popupAnchorX;

	public int popupAnchorY;

	public int ownerWindowWidth;

	public int ownerWindowHeight;

	public int autoCloseDelayMilliseconds = 0;

	public bool wordWrapDisabled = false;

	public bool customLayoutEnabled = false;

	public int customWindowWidth = 0;

	public int customWindowHeight = 0;

	public bool copyButtonVisible = false;

	public bool copySignatureEnabled = false;

	private string baseWindowTitle = null;

	private static long displayedAtTicks = 0L;

	public bool bool_7 = false;

	public string string_4 = null;

	private IContainer icontainer_1;

	private WebBrowser webBrowser1;

	public FormTip()
	{
		isTipWindowOpen = !isTipWindowOpen;
		InitializeComponent();
		webBrowser1 = new WebBrowser();
		webBrowser1.Location = richTextBoxStatus.Location;
		webBrowser1.MinimumSize = richTextBoxStatus.MaximumSize;
		webBrowser1.Name = "webBrowser1";
		webBrowser1.Size = richTextBoxStatus.Size;
		webBrowser1.TabIndex = 5;
		base.Controls.Add(webBrowser1);
		base.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.icontainer_1 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ns138.FormTip));
		this.checkBoxKhongHienthi = new System.Windows.Forms.CheckBox();
		this.buttonDong = new System.Windows.Forms.Button();
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_1);
		this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
		this.buttonCopy = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.checkBoxKhongHienthi.AutoSize = true;
		this.checkBoxKhongHienthi.BackColor = System.Drawing.Color.LightSteelBlue;
		this.checkBoxKhongHienthi.Location = new System.Drawing.Point(0, 307);
		this.checkBoxKhongHienthi.Name = "checkBoxKhongHienthi";
		this.checkBoxKhongHienthi.Size = new System.Drawing.Size(199, 17);
		this.checkBoxKhongHienthi.TabIndex = 1;
		this.checkBoxKhongHienthi.Text = "Không hiện bảng thông báo này nữa";
		this.checkBoxKhongHienthi.UseVisualStyleBackColor = false;
		this.checkBoxKhongHienthi.CheckedChanged += new System.EventHandler(checkBoxKhongHienthi_CheckedChanged);
		this.buttonDong.Location = new System.Drawing.Point(363, 303);
		this.buttonDong.Name = "buttonDong";
		this.buttonDong.Size = new System.Drawing.Size(77, 21);
		this.buttonDong.TabIndex = 2;
		this.buttonDong.Text = "Đóng";
		this.buttonDong.UseVisualStyleBackColor = true;
		this.buttonDong.Click += new System.EventHandler(buttonDong_Click);
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		this.richTextBoxStatus.BackColor = System.Drawing.Color.White;
		this.richTextBoxStatus.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.richTextBoxStatus.ForeColor = System.Drawing.SystemColors.WindowText;
		this.richTextBoxStatus.Location = new System.Drawing.Point(0, 0);
		this.richTextBoxStatus.Name = "richTextBoxStatus";
		this.richTextBoxStatus.Size = new System.Drawing.Size(443, 301);
		this.richTextBoxStatus.TabIndex = 3;
		this.richTextBoxStatus.Text = "Hướng dẫn sử dụng";
		this.richTextBoxStatus.TextChanged += new System.EventHandler(richTextBoxStatus_TextChanged);
		this.buttonCopy.Location = new System.Drawing.Point(282, 303);
		this.buttonCopy.Name = "buttonCopy";
		this.buttonCopy.Size = new System.Drawing.Size(77, 21);
		this.buttonCopy.TabIndex = 4;
		this.buttonCopy.Text = "Copy";
		this.buttonCopy.UseVisualStyleBackColor = true;
		this.buttonCopy.Click += new System.EventHandler(buttonCopy_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.LightSteelBlue;
		base.ClientSize = new System.Drawing.Size(444, 323);
		base.Controls.Add(this.buttonCopy);
		base.Controls.Add(this.checkBoxKhongHienthi);
		base.Controls.Add(this.richTextBoxStatus);
		base.Controls.Add(this.buttonDong);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.Name = "FormTip";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "HUONG DAN";
		base.Load += new System.EventHandler(FormTip_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	protected override void OnFormClosing(FormClosingEventArgs e)
	{
		isTipWindowOpen = false;
		rawTextFormattingPreserved = false;
		messageText = null;
		suppressionRegistryValueName = null;
		autoCloseDelayMilliseconds = -1;
		windowTitle = null;
		customWindowWidth = 0;
		customWindowHeight = 0;
		copyButtonVisible = false;
		copySignatureEnabled = false;
	}

	private void FormTip_Load(object sender, EventArgs e)
	{
		Hide();
		buttonCopy.Visible = copyButtonVisible;
		if (customLayoutEnabled)
		{
			buttonDong.Visible = false;
			if (customWindowWidth <= 0)
			{
				customWindowWidth = 281;
			}
			if (customWindowHeight <= 0)
			{
				customWindowHeight = 130;
			}
			richTextBoxStatus.Width = customWindowWidth - 7;
			richTextBoxStatus.Height = customWindowHeight - 27;
			richTextBoxStatus.Top = 0;
			richTextBoxStatus.Left = 0;
			richTextBoxStatus.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Width = customWindowWidth;
			if (copyButtonVisible)
			{
				base.Height = customWindowHeight + 30;
				buttonCopy.Top = richTextBoxStatus.Top + richTextBoxStatus.Height + 5;
				buttonCopy.Left = (base.Width - buttonCopy.Width) / 2;
			}
			else
			{
				base.Height = customWindowHeight + 2;
			}
		}
		else
		{
			base.StartPosition = FormStartPosition.CenterScreen;
		}
		if (popupAnchorX > 0 && popupAnchorY > 0)
		{
			checkBoxKhongHienthi.Visible = false;
			int num = popupAnchorX - base.Width - 5;
			int num2 = popupAnchorY - base.Height - 5;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			SetBounds(num, num2, base.Width, base.Height);
		}
		if (messageText != null)
		{
			string text = messageText;
			if (!rawTextFormattingPreserved)
			{
				text = text.Replace("|", GameConfigurationManager.string_7).Replace("\\n", GameConfigurationManager.string_7).Replace("\\t", '\t'.ToString());
			}
			richTextBoxStatus.Text = text;
		}
		checkBoxKhongHienthi.Enabled = !disableDontShowAgainCheckbox;
		richTextBoxStatus.WordWrap = !wordWrapDisabled;
		timer_0.Interval = 300;
		timer_0.Enabled = true;
		displayedAtTicks = CommonUtility.GetCurrentTicks();
		if (windowTitle != null)
		{
			Text = windowTitle;
		}
		baseWindowTitle = Text;
		base.TopMost = true;
		Show();
	}

	private void buttonDong_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void checkBoxKhongHienthi_CheckedChanged(object sender, EventArgs e)
	{
		if (Form1.versionUpdateNotes == null)
		{
			Form1.versionUpdateNotes = string.Empty;
		}
		string text = "Không hiện bảng thông báo này nữa";
		string text2 = string.Empty;
		if (!checkBoxKhongHienthi.Checked)
		{
			if (suppressionRegistryValueName != null && suppressionRegistryValueName != string.Empty)
			{
				WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), suppressionRegistryValueName, string.Empty, "", 0);
			}
			else
			{
				WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), "UpdateNew", 0, "", 0);
			}
		}
		else
		{
			if (suppressionRegistryValueName != null && suppressionRegistryValueName != string.Empty)
			{
				WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), suppressionRegistryValueName, messageText, "", 0);
			}
			else
			{
				WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), "UpdateNew", messageText.Length, "", 0);
			}
			text2 = " (có thể xem lại ở Phụ trợ - Phim)";
		}
		checkBoxKhongHienthi.Text = text + text2;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (!isTipWindowOpen)
		{
			Close();
		}
		else if (autoCloseDelayMilliseconds > 0)
		{
			long num = autoCloseDelayMilliseconds - CommonUtility.GetElapsedMilliseconds(displayedAtTicks);
			Text = baseWindowTitle + " (" + num / 1000L + "s)";
			if (num < 0L)
			{
				Close();
			}
		}
	}

	public static void ShowTipWindow(string title, string message, int autoCloseMilliseconds = 60000, int windowWidth = 345, int windowHeight = 200, bool disableWordWrap = false, int anchorX = -1, int anchorY = -1, bool showCopyButton = false, bool appendSignatureOnCopy = false, bool preserveRawTextFormatting = false)
	{
		if (windowWidth < 0)
		{
			windowWidth = 345;
		}
		if (windowHeight < 0)
		{
			windowHeight = 200;
		}
		if (autoCloseMilliseconds < 0)
		{
			autoCloseMilliseconds = 60000;
		}
		FormTip formTip = new FormTip();
		formTip.messageText = message;
		formTip.rawTextFormattingPreserved = preserveRawTextFormatting;
		if (anchorX >= 0 && anchorY >= 0)
		{
			formTip.popupAnchorX = anchorX + 5;
			formTip.popupAnchorY = anchorY + windowHeight + 5;
		}
		else
		{
			formTip.popupAnchorX = Cursor.Position.X;
			formTip.popupAnchorY = Cursor.Position.Y;
		}
		formTip.copyButtonVisible = showCopyButton;
		formTip.copySignatureEnabled = appendSignatureOnCopy;
		formTip.ownerWindowWidth = Form1.int_52[0];
		formTip.ownerWindowHeight = Form1.int_52[1];
		formTip.customLayoutEnabled = true;
		formTip.wordWrapDisabled = disableWordWrap;
		formTip.customWindowWidth = windowWidth;
		formTip.customWindowHeight = windowHeight;
		formTip.autoCloseDelayMilliseconds = autoCloseMilliseconds;
		formTip.windowTitle = title;
		formTip.Show();
	}

	private void buttonCopy_Click(object sender, EventArgs e)
	{
		try
		{
			string text = richTextBoxStatus.Text;
			if (text.IndexOf("\r") < 0)
			{
				text = text.Replace("\n", "\r\n");
			}
			if (copySignatureEnabled)
			{
				text = text + "\r\nSign: " + CommonUtility.EncodeBase64Utf8(text);
			}
			Clipboard.SetText(text);
		}
		catch
		{
		}
	}

	private void richTextBoxStatus_TextChanged(object sender, EventArgs e)
	{
	}
}

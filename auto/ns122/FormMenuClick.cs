using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns11;
using ns63;

namespace ns122;

public class FormMenuClick : Form
{
	private IContainer icontainer_0 = null;

	private RichTextBox richTextBox1;

	private ListView listView1;

	private ColumnHeader columnHeader_0;

	private Button buttonXoa;

	private ComboBox comboBoxDong;

	private Button buttonThem;

	private Button buttonDong;

	private Button buttonSua;

	private Label label1;

	private TextBox textBoxDiengiai;

	private Timer timer_0;

	private Button buttonXoahet;

	private Label label2;

	private Button buttonVidu;

	public static bool isMenuClickEditorOpen = false;

	public static bool menuClickSequenceChanged = false;

	public static string menuSequenceTargetKey = null;

	public int popupAnchorX = 0;

	public int popupAnchorY = 0;

	public static int[] menuClickSequence = null;

	public FormMenuClick()
	{
		isMenuClickEditorOpen = true;
		InitializeComponent();
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
		this.icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ns122.FormMenuClick));
		this.richTextBox1 = new System.Windows.Forms.RichTextBox();
		this.listView1 = new System.Windows.Forms.ListView();
		this.columnHeader_0 = new System.Windows.Forms.ColumnHeader();
		this.buttonXoa = new System.Windows.Forms.Button();
		this.comboBoxDong = new System.Windows.Forms.ComboBox();
		this.buttonThem = new System.Windows.Forms.Button();
		this.buttonDong = new System.Windows.Forms.Button();
		this.buttonSua = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.textBoxDiengiai = new System.Windows.Forms.TextBox();
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.buttonXoahet = new System.Windows.Forms.Button();
		this.label2 = new System.Windows.Forms.Label();
		this.buttonVidu = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.richTextBox1.Location = new System.Drawing.Point(3, 4);
		this.richTextBox1.Name = "richTextBox1";
		this.richTextBox1.Size = new System.Drawing.Size(204, 46);
		this.richTextBox1.TabIndex = 19;
		this.richTextBox1.Text = "Thứ tự dòng menu được tính từ số 1 trở đi (dòng menu đầu tiên là số 1).\nKhi menu hiển thị, auto sẽ tự động click lần lượt các dòng theo thứ tự từ trên xuống.";
		this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[1] { this.columnHeader_0 });
		this.listView1.ForeColor = System.Drawing.Color.Black;
		this.listView1.FullRowSelect = true;
		this.listView1.GridLines = true;
		this.listView1.HideSelection = false;
		this.listView1.Location = new System.Drawing.Point(3, 56);
		this.listView1.MultiSelect = false;
		this.listView1.Name = "listView1";
		this.listView1.Size = new System.Drawing.Size(125, 178);
		this.listView1.TabIndex = 20;
		this.listView1.UseCompatibleStateImageBehavior = false;
		this.listView1.View = System.Windows.Forms.View.Details;
		this.columnHeader_0.Text = "Click dòng thứ";
		this.columnHeader_0.Width = 100;
		this.buttonXoa.Location = new System.Drawing.Point(137, 196);
		this.buttonXoa.Name = "buttonXoa";
		this.buttonXoa.Size = new System.Drawing.Size(70, 26);
		this.buttonXoa.TabIndex = 21;
		this.buttonXoa.Text = "Xóa";
		this.buttonXoa.UseVisualStyleBackColor = true;
		this.buttonXoa.Click += new System.EventHandler(buttonXoa_Click);
		this.comboBoxDong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxDong.FormattingEnabled = true;
		this.comboBoxDong.Location = new System.Drawing.Point(88, 244);
		this.comboBoxDong.Name = "comboBoxDong";
		this.comboBoxDong.Size = new System.Drawing.Size(40, 21);
		this.comboBoxDong.TabIndex = 23;
		this.buttonThem.ForeColor = System.Drawing.Color.DarkBlue;
		this.buttonThem.Location = new System.Drawing.Point(3, 240);
		this.buttonThem.Name = "buttonThem";
		this.buttonThem.Size = new System.Drawing.Size(79, 26);
		this.buttonThem.TabIndex = 22;
		this.buttonThem.Text = "Thêm dòng";
		this.buttonThem.UseVisualStyleBackColor = true;
		this.buttonThem.Click += new System.EventHandler(buttonThem_Click);
		this.buttonDong.Location = new System.Drawing.Point(137, 290);
		this.buttonDong.Name = "buttonDong";
		this.buttonDong.Size = new System.Drawing.Size(70, 38);
		this.buttonDong.TabIndex = 25;
		this.buttonDong.Text = "Đóng";
		this.buttonDong.UseVisualStyleBackColor = true;
		this.buttonDong.Click += new System.EventHandler(buttonDong_Click);
		this.buttonSua.Location = new System.Drawing.Point(137, 239);
		this.buttonSua.Name = "buttonSua";
		this.buttonSua.Size = new System.Drawing.Size(70, 26);
		this.buttonSua.TabIndex = 24;
		this.buttonSua.Text = "Sửa";
		this.buttonSua.UseVisualStyleBackColor = true;
		this.buttonSua.Click += new System.EventHandler(buttonSua_Click);
		this.label1.Location = new System.Drawing.Point(2, 273);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(151, 36);
		this.label1.TabIndex = 27;
		this.label1.Text = "Diễn giải: auto sẽ lần lượt click menu các dòng sau";
		this.textBoxDiengiai.Location = new System.Drawing.Point(5, 306);
		this.textBoxDiengiai.Name = "textBoxDiengiai";
		this.textBoxDiengiai.ReadOnly = true;
		this.textBoxDiengiai.Size = new System.Drawing.Size(123, 20);
		this.textBoxDiengiai.TabIndex = 28;
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		this.buttonXoahet.Location = new System.Drawing.Point(137, 164);
		this.buttonXoahet.Name = "buttonXoahet";
		this.buttonXoahet.Size = new System.Drawing.Size(70, 26);
		this.buttonXoahet.TabIndex = 29;
		this.buttonXoahet.Text = "Xóa hết";
		this.buttonXoahet.UseVisualStyleBackColor = true;
		this.buttonXoahet.Click += new System.EventHandler(buttonXoahet_Click);
		this.label2.Location = new System.Drawing.Point(134, 58);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(73, 53);
		this.label2.TabIndex = 30;
		this.label2.Text = "Nhận nhiệm vụ 90 sát thủ Liên Hình Thái";
		this.buttonVidu.Location = new System.Drawing.Point(137, 114);
		this.buttonVidu.Name = "buttonVidu";
		this.buttonVidu.Size = new System.Drawing.Size(70, 26);
		this.buttonVidu.TabIndex = 31;
		this.buttonVidu.Text = "Xem ví dụ";
		this.buttonVidu.UseVisualStyleBackColor = true;
		this.buttonVidu.Click += new System.EventHandler(buttonVidu_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(210, 333);
		base.Controls.Add(this.buttonDong);
		base.Controls.Add(this.buttonVidu);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.buttonXoahet);
		base.Controls.Add(this.textBoxDiengiai);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.buttonSua);
		base.Controls.Add(this.comboBoxDong);
		base.Controls.Add(this.buttonThem);
		base.Controls.Add(this.buttonXoa);
		base.Controls.Add(this.listView1);
		base.Controls.Add(this.richTextBox1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "FormMenuClick";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "MENU CLICK";
		base.TopMost = true;
		base.Load += new System.EventHandler(FormMenuClick_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	protected override void OnFormClosing(FormClosingEventArgs e)
	{
		isMenuClickEditorOpen = false;
		menuClickSequenceChanged = false;
		menuSequenceTargetKey = null;
		menuClickSequence = null;
	}

	public static int[] SnapshotMenuClickSequenceAndOptionallySave(string string_1 = null)
	{
		int[] array = null;
		string text = string.Empty;
		if (menuClickSequence != null)
		{
			array = new int[menuClickSequence.Length];
			for (int i = 0; i < menuClickSequence.Length; i++)
			{
				array[i] = menuClickSequence[i];
				if (text != null && text != string.Empty)
				{
					text += ",";
				}
				text += menuClickSequence[i];
			}
		}
		if (string_1 != null && string_1 != string.Empty)
		{
			WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), string_1, text, "", 0);
		}
		return array;
	}

	private void FormMenuClick_Load(object sender, EventArgs e)
	{
		if (0 <= popupAnchorX && 0 <= popupAnchorY)
		{
			int num = popupAnchorX - base.Width - 10;
			int num2 = popupAnchorY - base.Height - 10;
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
		if (menuClickSequence != null)
		{
			for (int i = 0; i < menuClickSequence.Length; i++)
			{
				AppendMenuClickIndexToListView(listView1, menuClickSequence[i]);
			}
			textBoxDiengiai.Text = CommonUtility.JoinIntArray(menuClickSequence);
		}
		for (int j = 1; j < 30; j++)
		{
			comboBoxDong.Items.Add(j);
		}
		comboBoxDong.Text = "1";
		base.TopMost = true;
		timer_0.Interval = 300;
		timer_0.Enabled = true;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (!isMenuClickEditorOpen)
		{
			Close();
		}
	}

	public static void AppendMenuClickIndexToListView(ListView listView_0, int int_3)
	{
		try
		{
			ListViewItem value = new ListViewItem(int_3.ToString());
			listView_0.Items.Add(value);
		}
		catch
		{
		}
	}

	private void buttonThem_Click(object sender, EventArgs e)
	{
		int num = CommonUtility.ParseInt32OrZero(comboBoxDong.Text);
		if (menuClickSequence != null && menuClickSequence.Length != 0)
		{
			Array.Resize(ref menuClickSequence, menuClickSequence.Length + 1);
			menuClickSequence[menuClickSequence.Length - 1] = num;
		}
		else
		{
			menuClickSequence = new int[1] { num };
		}
		AppendMenuClickIndexToListView(listView1, num);
		textBoxDiengiai.Text = CommonUtility.JoinIntArray(menuClickSequence);
		menuClickSequenceChanged = true;
	}

	private void buttonXoa_Click(object sender, EventArgs e)
	{
		if (menuClickSequence != null && menuClickSequence.Length != 0)
		{
			int num = -1;
			for (int i = 0; i < listView1.Items.Count; i++)
			{
				if (listView1.Items[i].Selected)
				{
					num = i;
					break;
				}
			}
			if (num < 0)
			{
				return;
			}
			int num2 = 0;
			int[] array = new int[menuClickSequence.Length];
			for (int j = 0; j < menuClickSequence.Length; j++)
			{
				if (j != num)
				{
					array[num2] = menuClickSequence[j];
					num2++;
				}
			}
			if (num2 != 0)
			{
				listView1.Items.RemoveAt(num);
				menuClickSequence = new int[num2];
				for (int k = 0; k < num2; k++)
				{
					menuClickSequence[k] = array[k];
				}
			}
			else
			{
				listView1.Items.Clear();
				menuClickSequence = null;
			}
			textBoxDiengiai.Text = CommonUtility.JoinIntArray(menuClickSequence);
			menuClickSequenceChanged = true;
		}
		else
		{
			listView1.Items.Clear();
			menuClickSequence = null;
		}
	}

	private void buttonXoahet_Click(object sender, EventArgs e)
	{
		menuClickSequence = null;
		listView1.Items.Clear();
		textBoxDiengiai.Text = string.Empty;
		menuClickSequenceChanged = true;
	}

	private void buttonSua_Click(object sender, EventArgs e)
	{
		if (menuClickSequence == null || menuClickSequence.Length == 0)
		{
			return;
		}
		int num = CommonUtility.ParseInt32OrZero(comboBoxDong.Text);
		for (int i = 0; i < listView1.Items.Count; i++)
		{
			if (listView1.Items[i].Selected)
			{
				menuClickSequence[i] = num;
				listView1.Items[i].SubItems[0].Text = num.ToString();
				break;
			}
		}
		textBoxDiengiai.Text = CommonUtility.JoinIntArray(menuClickSequence);
		menuClickSequenceChanged = true;
	}

	private void buttonDong_Click(object sender, EventArgs e)
	{
		isMenuClickEditorOpen = false;
		Close();
	}

	private void buttonVidu_Click(object sender, EventArgs e)
	{
		menuClickSequence = new int[4] { 3, 11, 4, 1 };
		listView1.Items.Clear();
		for (int i = 0; i < menuClickSequence.Length; i++)
		{
			AppendMenuClickIndexToListView(listView1, menuClickSequence[i]);
		}
		textBoxDiengiai.Text = CommonUtility.JoinIntArray(menuClickSequence);
	}
}

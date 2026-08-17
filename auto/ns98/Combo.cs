using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns1;
using ns100;
using ns11;
using ns138;
using ns145;
using ns23;
using ns29;
using ns53;
using ns63;
using ns81;
using ns83;

namespace ns98;

public class Combo : Form
{
	private IContainer icontainer_0 = null;

	private Timer timer_0;

	private NumericUpDown numericUpDown1;

	private ListView listView2;

	private ColumnHeader columnHeader_0;

	private ColumnHeader columnHeader_1;

	private NumericUpDown numericUpDown2;

	private ColumnHeader columnHeader_2;

	private ListView listView1;

	private ComboBox comboBoxPhim;

	private ComboBox comboBoxThuoc;

	private Button buttonApdung;

	private Label labelStatus;

	private Button buttonXoaFilecauhinh;

	private CheckBox checkBoxDungchung;

	private Label labelXoaThuoc;

	private Label labelThemThuoc;

	private Label labelXoaPhim;

	private Button buttonTaoPhim;

	private Button buttonPhimHuongdan;

	private Label label3;

	private Label labelTile;

	private Label label2;

	private Label label4;

	private CheckBox checkBoxPhiChiendau;

	private Button button1;

	public static bool isComboFormOpen = false;

	public int ownerWindowLeft = 0;

	public int ownerWindowTop = 0;

	public int ownerWindowWidth;

	public int ownerWindowHeight;

	public static int medicinePumpRatioDivisor = WindowsRegistryHelper.ReadApplicationRegistryInt32("flagTileBom", 0, "1");

	public static int sharedMedicineRatioEnabled = WindowsRegistryHelper.ReadApplicationRegistryInt32("flagBomChungThuoc", 0, "0");

	public static int allowMedicinePumpInTownAndBattleAreasEnabled = WindowsRegistryHelper.ReadApplicationRegistryInt32("flagPhiCD", 0, "0");

	public CharacterAccountConfig characterAccountConfig_0 = default(CharacterAccountConfig);

	private static int selectedComboHotkeyRowIndex = -1;

	private static string[] medicineItemNameCandidates = null;

	public Combo()
	{
		isComboFormOpen = true;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ns98.Combo));
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
		this.listView2 = new System.Windows.Forms.ListView();
		this.columnHeader_0 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_1 = new System.Windows.Forms.ColumnHeader();
		this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
		this.columnHeader_2 = new System.Windows.Forms.ColumnHeader();
		this.listView1 = new System.Windows.Forms.ListView();
		this.comboBoxPhim = new System.Windows.Forms.ComboBox();
		this.comboBoxThuoc = new System.Windows.Forms.ComboBox();
		this.buttonApdung = new System.Windows.Forms.Button();
		this.labelStatus = new System.Windows.Forms.Label();
		this.checkBoxDungchung = new System.Windows.Forms.CheckBox();
		this.labelXoaPhim = new System.Windows.Forms.Label();
		this.labelXoaThuoc = new System.Windows.Forms.Label();
		this.labelThemThuoc = new System.Windows.Forms.Label();
		this.buttonXoaFilecauhinh = new System.Windows.Forms.Button();
		this.buttonTaoPhim = new System.Windows.Forms.Button();
		this.buttonPhimHuongdan = new System.Windows.Forms.Button();
		this.labelTile = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.checkBoxPhiChiendau = new System.Windows.Forms.CheckBox();
		this.button1 = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown2).BeginInit();
		base.SuspendLayout();
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		this.numericUpDown1.ForeColor = System.Drawing.Color.MediumBlue;
		this.numericUpDown1.Location = new System.Drawing.Point(337, 152);
		this.numericUpDown1.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
		this.numericUpDown1.Name = "numericUpDown1";
		this.numericUpDown1.Size = new System.Drawing.Size(83, 20);
		this.numericUpDown1.TabIndex = 72;
		this.numericUpDown1.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		this.numericUpDown1.ValueChanged += new System.EventHandler(numericUpDown1_ValueChanged);
		this.numericUpDown1.KeyUp += new System.Windows.Forms.KeyEventHandler(numericUpDown1_KeyUp);
		this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.columnHeader_0, this.columnHeader_1 });
		this.listView2.FullRowSelect = true;
		this.listView2.GridLines = true;
		this.listView2.HideSelection = false;
		this.listView2.Location = new System.Drawing.Point(120, 26);
		this.listView2.Name = "listView2";
		this.listView2.Size = new System.Drawing.Size(301, 123);
		this.listView2.TabIndex = 66;
		this.listView2.UseCompatibleStateImageBehavior = false;
		this.listView2.View = System.Windows.Forms.View.Details;
		this.listView2.MouseClick += new System.Windows.Forms.MouseEventHandler(listView2_MouseClick);
		this.listView2.MouseDown += new System.Windows.Forms.MouseEventHandler(listView2_MouseDown);
		this.columnHeader_0.Text = "Tên thuốc";
		this.columnHeader_0.Width = 210;
		this.columnHeader_1.Text = "Số lượng";
		this.columnHeader_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.columnHeader_1.Width = 70;
		this.numericUpDown2.ForeColor = System.Drawing.SystemColors.WindowText;
		this.numericUpDown2.Location = new System.Drawing.Point(264, 207);
		this.numericUpDown2.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
		this.numericUpDown2.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		this.numericUpDown2.Name = "numericUpDown2";
		this.numericUpDown2.Size = new System.Drawing.Size(52, 20);
		this.numericUpDown2.TabIndex = 76;
		this.numericUpDown2.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		this.numericUpDown2.ValueChanged += new System.EventHandler(numericUpDown2_ValueChanged);
		this.numericUpDown2.KeyUp += new System.Windows.Forms.KeyEventHandler(numericUpDown2_KeyUp);
		this.columnHeader_2.Text = "Phím bơm";
		this.columnHeader_2.Width = 85;
		this.listView1.BackColor = System.Drawing.SystemColors.Info;
		this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[1] { this.columnHeader_2 });
		this.listView1.FullRowSelect = true;
		this.listView1.GridLines = true;
		this.listView1.HideSelection = false;
		this.listView1.Location = new System.Drawing.Point(6, 26);
		this.listView1.Name = "listView1";
		this.listView1.Size = new System.Drawing.Size(108, 123);
		this.listView1.TabIndex = 65;
		this.listView1.UseCompatibleStateImageBehavior = false;
		this.listView1.View = System.Windows.Forms.View.Details;
		this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(listView1_MouseClick);
		this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(listView1_MouseDown);
		this.comboBoxPhim.BackColor = System.Drawing.Color.White;
		this.comboBoxPhim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxPhim.ForeColor = System.Drawing.Color.DarkBlue;
		this.comboBoxPhim.FormattingEnabled = true;
		this.comboBoxPhim.Location = new System.Drawing.Point(78, 152);
		this.comboBoxPhim.Name = "comboBoxPhim";
		this.comboBoxPhim.Size = new System.Drawing.Size(36, 21);
		this.comboBoxPhim.TabIndex = 73;
		this.comboBoxThuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxThuoc.DropDownWidth = 225;
		this.comboBoxThuoc.FormattingEnabled = true;
		this.comboBoxThuoc.Location = new System.Drawing.Point(121, 152);
		this.comboBoxThuoc.Name = "comboBoxThuoc";
		this.comboBoxThuoc.Size = new System.Drawing.Size(214, 21);
		this.comboBoxThuoc.TabIndex = 69;
		this.comboBoxThuoc.MouseDown += new System.Windows.Forms.MouseEventHandler(comboBoxThuoc_MouseDown);
		this.buttonApdung.BackColor = System.Drawing.SystemColors.Control;
		this.buttonApdung.ForeColor = System.Drawing.Color.Black;
		this.buttonApdung.Location = new System.Drawing.Point(325, 291);
		this.buttonApdung.Name = "buttonApdung";
		this.buttonApdung.Size = new System.Drawing.Size(89, 38);
		this.buttonApdung.TabIndex = 78;
		this.buttonApdung.Text = "Đóng";
		this.buttonApdung.UseVisualStyleBackColor = false;
		this.buttonApdung.Click += new System.EventHandler(buttonApdung_Click);
		this.labelStatus.AutoSize = true;
		this.labelStatus.BackColor = System.Drawing.SystemColors.Control;
		this.labelStatus.ForeColor = System.Drawing.Color.Black;
		this.labelStatus.Location = new System.Drawing.Point(3, 5);
		this.labelStatus.Name = "labelStatus";
		this.labelStatus.Size = new System.Drawing.Size(336, 13);
		this.labelStatus.TabIndex = 81;
		this.labelStatus.Text = "Bấm nút tạo phím, sau đó thêm tên thuốc và số lượng vào danh sách";
		this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.checkBoxDungchung.AutoSize = true;
		this.checkBoxDungchung.BackColor = System.Drawing.SystemColors.Control;
		this.checkBoxDungchung.ForeColor = System.Drawing.SystemColors.WindowText;
		this.checkBoxDungchung.Location = new System.Drawing.Point(6, 209);
		this.checkBoxDungchung.Name = "checkBoxDungchung";
		this.checkBoxDungchung.Size = new System.Drawing.Size(215, 17);
		this.checkBoxDungchung.TabIndex = 85;
		this.checkBoxDungchung.Text = "Các nhân vật còn lại đều bơm theo tỉ lệ:";
		this.checkBoxDungchung.UseVisualStyleBackColor = false;
		this.checkBoxDungchung.CheckedChanged += new System.EventHandler(checkBoxDungchung_CheckedChanged);
		this.labelXoaPhim.AutoSize = true;
		this.labelXoaPhim.Cursor = System.Windows.Forms.Cursors.Hand;
		this.labelXoaPhim.ForeColor = System.Drawing.Color.Blue;
		this.labelXoaPhim.Location = new System.Drawing.Point(10, 181);
		this.labelXoaPhim.Name = "labelXoaPhim";
		this.labelXoaPhim.Size = new System.Drawing.Size(65, 13);
		this.labelXoaPhim.TabIndex = 77;
		this.labelXoaPhim.Text = "[ Xóa phím ]";
		this.labelXoaPhim.Click += new System.EventHandler(labelXoaPhim_Click);
		this.labelXoaThuoc.AutoSize = true;
		this.labelXoaThuoc.Cursor = System.Windows.Forms.Cursors.Hand;
		this.labelXoaThuoc.ForeColor = System.Drawing.Color.Blue;
		this.labelXoaThuoc.Location = new System.Drawing.Point(200, 181);
		this.labelXoaThuoc.Name = "labelXoaThuoc";
		this.labelXoaThuoc.Size = new System.Drawing.Size(68, 13);
		this.labelXoaThuoc.TabIndex = 75;
		this.labelXoaThuoc.Text = "[ Xóa thuốc ]";
		this.labelXoaThuoc.Click += new System.EventHandler(labelXoaThuoc_Click);
		this.labelThemThuoc.AutoSize = true;
		this.labelThemThuoc.Cursor = System.Windows.Forms.Cursors.Hand;
		this.labelThemThuoc.ForeColor = System.Drawing.Color.Blue;
		this.labelThemThuoc.Location = new System.Drawing.Point(118, 181);
		this.labelThemThuoc.Name = "labelThemThuoc";
		this.labelThemThuoc.Size = new System.Drawing.Size(76, 13);
		this.labelThemThuoc.TabIndex = 74;
		this.labelThemThuoc.Text = "[ Thêm thuốc ]";
		this.labelThemThuoc.Click += new System.EventHandler(labelThemThuoc_Click);
		this.buttonXoaFilecauhinh.BackColor = System.Drawing.SystemColors.Control;
		this.buttonXoaFilecauhinh.ForeColor = System.Drawing.SystemColors.WindowText;
		this.buttonXoaFilecauhinh.Location = new System.Drawing.Point(6, 303);
		this.buttonXoaFilecauhinh.Name = "buttonXoaFilecauhinh";
		this.buttonXoaFilecauhinh.Size = new System.Drawing.Size(108, 26);
		this.buttonXoaFilecauhinh.TabIndex = 84;
		this.buttonXoaFilecauhinh.Text = "Xóa file cấu hình";
		this.buttonXoaFilecauhinh.UseVisualStyleBackColor = false;
		this.buttonXoaFilecauhinh.Click += new System.EventHandler(buttonXoaFilecauhinh_Click);
		this.buttonTaoPhim.ForeColor = System.Drawing.Color.DarkRed;
		this.buttonTaoPhim.Location = new System.Drawing.Point(6, 152);
		this.buttonTaoPhim.Name = "buttonTaoPhim";
		this.buttonTaoPhim.Size = new System.Drawing.Size(69, 21);
		this.buttonTaoPhim.TabIndex = 86;
		this.buttonTaoPhim.Text = "Tạo phím";
		this.buttonTaoPhim.UseVisualStyleBackColor = true;
		this.buttonTaoPhim.Click += new System.EventHandler(buttonTaoPhim_Click);
		this.buttonPhimHuongdan.BackColor = System.Drawing.SystemColors.Control;
		this.buttonPhimHuongdan.ForeColor = System.Drawing.SystemColors.WindowText;
		this.buttonPhimHuongdan.Location = new System.Drawing.Point(121, 303);
		this.buttonPhimHuongdan.Name = "buttonPhimHuongdan";
		this.buttonPhimHuongdan.Size = new System.Drawing.Size(100, 26);
		this.buttonPhimHuongdan.TabIndex = 87;
		this.buttonPhimHuongdan.Text = "Phim hướng dẫn";
		this.buttonPhimHuongdan.UseVisualStyleBackColor = false;
		this.buttonPhimHuongdan.Click += new System.EventHandler(buttonPhimHuongdan_Click);
		this.labelTile.AutoSize = true;
		this.labelTile.Cursor = System.Windows.Forms.Cursors.Hand;
		this.labelTile.ForeColor = System.Drawing.Color.Blue;
		this.labelTile.Location = new System.Drawing.Point(322, 211);
		this.labelTile.Name = "labelTile";
		this.labelTile.Size = new System.Drawing.Size(57, 13);
		this.labelTile.TabIndex = 89;
		this.labelTile.Text = "(giải thích)";
		this.labelTile.Click += new System.EventHandler(labelTile_Click);
		this.label3.AutoSize = true;
		this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
		this.label3.Location = new System.Drawing.Point(340, 176);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(49, 13);
		this.label3.TabIndex = 86;
		this.label3.Text = "Số lượng";
		this.label2.ForeColor = System.Drawing.Color.Red;
		this.label2.Location = new System.Drawing.Point(34, 261);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(199, 30);
		this.label2.TabIndex = 246;
		this.label2.Text = "Xem và kết hợp với mở túi thuốc ở phần Hậu cần nha các bạn !";
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(238, 211);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(21, 13);
		this.label4.TabIndex = 247;
		this.label4.Text = "1 /";
		this.checkBoxPhiChiendau.AutoSize = true;
		this.checkBoxPhiChiendau.ForeColor = System.Drawing.Color.DarkRed;
		this.checkBoxPhiChiendau.Location = new System.Drawing.Point(6, 235);
		this.checkBoxPhiChiendau.Name = "checkBoxPhiChiendau";
		this.checkBoxPhiChiendau.Size = new System.Drawing.Size(283, 17);
		this.checkBoxPhiChiendau.TabIndex = 248;
		this.checkBoxPhiChiendau.Text = "Sử dụng được luôn ở trong thành và nơi phi chiến đấu";
		this.checkBoxPhiChiendau.UseVisualStyleBackColor = true;
		this.checkBoxPhiChiendau.CheckedChanged += new System.EventHandler(checkBoxPhiChiendau_CheckedChanged);
		this.button1.BackColor = System.Drawing.SystemColors.Control;
		this.button1.ForeColor = System.Drawing.Color.DarkRed;
		this.button1.Location = new System.Drawing.Point(325, 242);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(89, 38);
		this.button1.TabIndex = 249;
		this.button1.Text = "Áp dụng cho tất cả ac";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.SystemColors.Control;
		base.ClientSize = new System.Drawing.Size(423, 340);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.checkBoxPhiChiendau);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.labelTile);
		base.Controls.Add(this.numericUpDown2);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.checkBoxDungchung);
		base.Controls.Add(this.buttonPhimHuongdan);
		base.Controls.Add(this.buttonXoaFilecauhinh);
		base.Controls.Add(this.buttonTaoPhim);
		base.Controls.Add(this.comboBoxPhim);
		base.Controls.Add(this.buttonApdung);
		base.Controls.Add(this.labelStatus);
		base.Controls.Add(this.labelXoaPhim);
		base.Controls.Add(this.labelXoaThuoc);
		base.Controls.Add(this.labelThemThuoc);
		base.Controls.Add(this.listView2);
		base.Controls.Add(this.numericUpDown1);
		base.Controls.Add(this.listView1);
		base.Controls.Add(this.comboBoxThuoc);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.Name = "Combo";
		this.Text = "COMBO NHOI THUOC";
		base.Load += new System.EventHandler(Combo_Load);
		((System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown2).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	protected override void OnFormClosing(FormClosingEventArgs e)
	{
		SaveComboConfigurationToAccounts();
		GlobalKeyboardHookManager.RemoveGlobalKeyboardHookAndResetState();
		GlobalKeyboardHookManager.InstallGlobalKeyboardHook();
		isComboFormOpen = false;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (!isComboFormOpen)
		{
			Close();
		}
	}

	private void Combo_Load(object sender, EventArgs e)
	{
		if (ownerWindowLeft > 0 && ownerWindowTop > 0)
		{
			int num = ownerWindowLeft - base.Width - 2;
			int num2 = ownerWindowTop + ownerWindowHeight - base.Height;
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
		if (characterAccountConfig_0.int_136 > 0)
		{
			SetWindowTitle("COMBO NHOI THUOC [ " + GameTextEncodingHelper.ConvertGameTextToDisplayText(characterAccountConfig_0.string_22, 1) + " ]");
			buttonApdung.Enabled = true;
		}
		else
		{
			SetWindowTitle("COMBO NHOI THUOC");
			buttonApdung.Enabled = false;
		}
		numericUpDown2.Value = medicinePumpRatioDivisor;
		comboBoxThuoc.Items.Clear();
		PopulateComboHotkeyAndMedicineLists(characterAccountConfig_0.medicineComboHotkeys);
		PopulateMedicineComboBoxFromFirstHotkey(characterAccountConfig_0.medicineComboHotkeys);
		PopulateAvailableHotkeyComboBox(KeyboardKeyCatalog.gstruct42_1, characterAccountConfig_0.medicineComboHotkeys);
		checkBoxDungchung.Checked = sharedMedicineRatioEnabled > 0;
		checkBoxPhiChiendau.Checked = allowMedicinePumpInTownAndBattleAreasEnabled > 0;
		timer_0.Interval = 300;
		timer_0.Enabled = true;
		base.TopMost = true;
	}

	private bool SaveComboConfigurationToAccounts(bool bool_1 = false)
	{
		if (Form1.characterAccountConfig_1 != null)
		{
			if (!bool_1)
			{
				for (int i = 0; i < Form1.characterAccountConfig_1.Length; i++)
				{
					if (Form1.characterAccountConfig_1[i].int_136 == characterAccountConfig_0.int_136)
					{
						Form1.characterAccountConfig_1[i].medicineComboHotkeys = characterAccountConfig_0.medicineComboHotkeys;
						GameConfigurationManager.SaveCharacterConfiguration(Form1.characterAccountConfig_1[i]);
						break;
					}
				}
			}
			else
			{
				for (int j = 0; j < Form1.characterAccountConfig_1.Length; j++)
				{
					Form1.characterAccountConfig_1[j].medicineComboHotkeys = characterAccountConfig_0.medicineComboHotkeys;
					GameConfigurationManager.SaveCharacterConfiguration(Form1.characterAccountConfig_1[j]);
				}
			}
			return true;
		}
		return false;
	}

	private void PopulateMedicineComboBoxFromFirstHotkey(MedicineComboHotkeyConfig[] medicineComboHotkeys)
	{
		if (medicineComboHotkeys != null && medicineComboHotkeys[0].medicineEntries != null)
		{
			medicineItemNameCandidates = null;
			for (int i = 0; i < medicineComboHotkeys[0].medicineEntries.Length; i++)
			{
				CommonUtility.AppendStringIfMissing(ref medicineItemNameCandidates, medicineComboHotkeys[0].medicineEntries[i].medicineName);
				comboBoxThuoc.Items.Add(GameTextEncodingHelper.ConvertGameTextToDisplayText(medicineComboHotkeys[0].medicineEntries[i].medicineName, 1));
			}
			comboBoxThuoc.Text = GameTextEncodingHelper.ConvertGameTextToDisplayText(medicineComboHotkeys[0].medicineEntries[0].medicineName, 1);
		}
	}

	private void PopulateAvailableHotkeyComboBox(KeyboardKeyEntry[] gstruct42_0, MedicineComboHotkeyConfig[] medicineComboHotkeys)
	{
		if (gstruct42_0 == null)
		{
			return;
		}
		string text = null;
		for (int i = 0; i < gstruct42_0.GetLength(0); i++)
		{
			bool flag = true;
			if (medicineComboHotkeys != null)
			{
				for (int j = 0; j < medicineComboHotkeys.Length; j++)
				{
					if (gstruct42_0[i].virtualKeyCode == medicineComboHotkeys[j].virtualKeyCode)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				if (text == null)
				{
					text = gstruct42_0[i].keyLabel;
				}
				comboBoxPhim.Items.Add(gstruct42_0[i].keyLabel);
			}
		}
		if (text != null)
		{
			comboBoxPhim.Text = text;
		}
	}

	private void PopulateComboHotkeyAndMedicineLists(MedicineComboHotkeyConfig[] medicineComboHotkeys)
	{
		selectedComboHotkeyRowIndex = -1;
		if (medicineComboHotkeys == null)
		{
			return;
		}
		for (int i = 0; i < medicineComboHotkeys.Length; i++)
		{
			string text = KeyboardKeyCatalog.GetKeyLabel(KeyboardKeyCatalog.gstruct42_1, medicineComboHotkeys[i].virtualKeyCode);
			listView1.Items.Add(new ListViewItem(text));
		}
		selectedComboHotkeyRowIndex = 0;
		ComboMedicineEntry[] comboMedicineEntry_ = medicineComboHotkeys[0].medicineEntries;
		if (comboMedicineEntry_ != null)
		{
			for (int j = 0; j < comboMedicineEntry_.Length; j++)
			{
				AppendComboMedicineListViewRow(GameTextEncodingHelper.ConvertGameTextToDisplayText(comboMedicineEntry_[j].medicineName, 1), comboMedicineEntry_[j].medicineCount);
			}
			listView1.Items[0].Focused = true;
			listView1.Items[0].Selected = true;
			listView2.Items[0].Focused = true;
			listView2.Items[0].Selected = true;
		}
	}

	private void AppendComboMedicineListViewRow(string string_1, int int_8)
	{
		try
		{
			ListViewItem listViewItem = new ListViewItem(string_1);
			listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, int_8.ToString()));
			listView2.Items.Add(listViewItem);
		}
		catch
		{
		}
	}

	private void RefreshSelectedHotkeyMedicineList(bool bool_1 = true)
	{
		int num = FindSelectedListViewItemIndex(listView1);
		labelThemThuoc.Enabled = num >= 0;
		labelXoaPhim.Enabled = num >= 0;
		if (num >= 0 && (!bool_1 || num != selectedComboHotkeyRowIndex))
		{
			int num2 = KeyboardKeyCatalog.GetVirtualKeyCode(KeyboardKeyCatalog.gstruct42_1, listView1.Items[num].SubItems[0].Text);
			if (num2 < 0)
			{
				return;
			}
			int num3 = FindComboHotkeyEntryIndex(characterAccountConfig_0.medicineComboHotkeys, num2);
			if (num3 < 0)
			{
				return;
			}
			selectedComboHotkeyRowIndex = num;
			MedicineComboHotkeyConfig gStruct = characterAccountConfig_0.medicineComboHotkeys[num3];
			listView2.Items.Clear();
			if (gStruct.medicineEntries != null)
			{
				for (int i = 0; i < gStruct.medicineEntries.Length; i++)
				{
					AppendComboMedicineListViewRow(GameTextEncodingHelper.ConvertGameTextToDisplayText(gStruct.medicineEntries[i].medicineName, 1), gStruct.medicineEntries[i].medicineCount);
				}
			}
		}
		else
		{
			selectedComboHotkeyRowIndex = num;
		}
	}

	private int FindSelectedListViewItemIndex(ListView listView_0)
	{
		if (listView_0.Items != null)
		{
			for (int i = 0; i < listView_0.Items.Count; i++)
			{
				if (listView_0.Items[i].Selected)
				{
					return i;
				}
			}
		}
		return -1;
	}

	public static int FindClickedListViewRowIndex(ListView listView_0, MouseEventArgs mouseEventArgs_0, int int_8 = 0)
	{
		ListViewItem itemAt = listView_0.GetItemAt(mouseEventArgs_0.X, mouseEventArgs_0.Y);
		if (itemAt != null)
		{
			string text = itemAt.SubItems[int_8].Text;
			for (int i = 0; i < listView_0.Items.Count; i++)
			{
				string text2 = listView_0.Items[i].SubItems[int_8].Text;
				if (text == text2)
				{
					return i;
				}
			}
		}
		return -1;
	}

	private static int FindComboHotkeyEntryIndex(MedicineComboHotkeyConfig[] medicineComboHotkeys, int int_8)
	{
		if (medicineComboHotkeys != null)
		{
			for (int i = 0; i < medicineComboHotkeys.Length; i++)
			{
				if (int_8 == medicineComboHotkeys[i].virtualKeyCode)
				{
					return i;
				}
			}
		}
		return -1;
	}

	private static int FindComboMedicineEntryIndexByName(ComboMedicineEntry[] medicineEntries, string string_1)
	{
		if (medicineEntries != null)
		{
			for (int i = 0; i < medicineEntries.Length; i++)
			{
				if (string_1 == medicineEntries[i].medicineName || GameTextEncodingHelper.ConvertGameTextToDisplayText(string_1, 1) == medicineEntries[i].medicineName || string_1 == GameTextEncodingHelper.ConvertGameTextToDisplayText(medicineEntries[i].medicineName, 1))
				{
					return i;
				}
			}
		}
		return -1;
	}

	private void RemoveComboHotkeyEntryByLabel(ref MedicineComboHotkeyConfig[] medicineComboHotkeys, string string_1)
	{
		int num = KeyboardKeyCatalog.GetVirtualKeyCode(KeyboardKeyCatalog.gstruct42_1, string_1);
		if (num < 0 || medicineComboHotkeys == null || medicineComboHotkeys.Length == 0)
		{
			return;
		}
		int num2 = 0;
		MedicineComboHotkeyConfig[] array = new MedicineComboHotkeyConfig[medicineComboHotkeys.Length];
		for (int i = 0; i < medicineComboHotkeys.Length; i++)
		{
			if (medicineComboHotkeys[i].virtualKeyCode != num)
			{
				ref MedicineComboHotkeyConfig reference = ref array[num2];
				reference = medicineComboHotkeys[i];
				num2++;
			}
		}
		if (num2 == 0)
		{
			medicineComboHotkeys = null;
			return;
		}
		MedicineComboHotkeyConfig[] array2 = new MedicineComboHotkeyConfig[num2];
		for (int j = 0; j < num2; j++)
		{
			ref MedicineComboHotkeyConfig reference2 = ref array2[j];
			reference2 = array[j];
		}
		medicineComboHotkeys = array2;
	}

	private void AppendComboHotkeyEntryIfMissing(ref MedicineComboHotkeyConfig[] medicineComboHotkeys, string string_1)
	{
		MedicineComboHotkeyConfig gStruct = new MedicineComboHotkeyConfig
		{
			virtualKeyCode = KeyboardKeyCatalog.GetVirtualKeyCode(KeyboardKeyCatalog.gstruct42_1, string_1),
			medicineEntries = null
		};
		if (medicineComboHotkeys != null && medicineComboHotkeys.Length != 0)
		{
			MedicineComboHotkeyConfig[] array = new MedicineComboHotkeyConfig[medicineComboHotkeys.Length + 1];
			int num = 0;
			while (true)
			{
				if (num < medicineComboHotkeys.Length)
				{
					ref MedicineComboHotkeyConfig reference = ref array[num];
					reference = medicineComboHotkeys[num];
					if (medicineComboHotkeys[num].virtualKeyCode != gStruct.virtualKeyCode)
					{
						num++;
						continue;
					}
					break;
				}
				array[array.Length - 1] = gStruct;
				medicineComboHotkeys = array;
				break;
			}
		}
		else
		{
			medicineComboHotkeys = new MedicineComboHotkeyConfig[1] { gStruct };
		}
	}

	private void AppendComboMedicineEntryIfMissing(ref ComboMedicineEntry[] medicineEntries, string string_1, int int_8)
	{
		ComboMedicineEntry comboMedicineEntry = new ComboMedicineEntry
		{
			medicineName = string_1,
			medicineCount = int_8
		};
		if (medicineEntries != null && medicineEntries.Length != 0)
		{
			ComboMedicineEntry[] array = new ComboMedicineEntry[medicineEntries.Length + 1];
			int num = 0;
			while (true)
			{
				if (num < medicineEntries.Length)
				{
					ref ComboMedicineEntry reference = ref array[num];
					reference = medicineEntries[num];
					if (!(medicineEntries[num].medicineName == string_1) || string_1 == null)
					{
						num++;
						continue;
					}
					break;
				}
				array[array.Length - 1] = comboMedicineEntry;
				medicineEntries = array;
				break;
			}
		}
		else
		{
			medicineEntries = new ComboMedicineEntry[1] { comboMedicineEntry };
		}
	}

	private void RemoveComboMedicineEntryByName(ref ComboMedicineEntry[] medicineEntries, string string_1)
	{
		if (string_1 == null || string_1 == "")
		{
			return;
		}
		int num = 0;
		ComboMedicineEntry[] array = new ComboMedicineEntry[medicineEntries.Length];
		for (int i = 0; i < medicineEntries.Length; i++)
		{
			if (!(medicineEntries[i].medicineName == string_1) && !(GameTextEncodingHelper.ConvertGameTextToDisplayText(medicineEntries[i].medicineName, 1) == string_1) && !(medicineEntries[i].medicineName == GameTextEncodingHelper.ConvertGameTextToDisplayText(string_1, 1)))
			{
				ref ComboMedicineEntry reference = ref array[num];
				reference = medicineEntries[i];
				num++;
			}
		}
		if (num != 0)
		{
			ComboMedicineEntry[] array2 = new ComboMedicineEntry[num];
			for (int j = 0; j < num; j++)
			{
				ref ComboMedicineEntry reference2 = ref array2[j];
				reference2 = array[j];
			}
			medicineEntries = array2;
		}
		else
		{
			medicineEntries = null;
		}
	}

	private void comboBoxThuoc_MouseDown(object sender, MouseEventArgs e)
	{
		string text = comboBoxThuoc.Text;
		string text2 = null;
		comboBoxThuoc.Items.Clear();
		if (characterAccountConfig_0.int_136 != 0 && WindowsInteropHelper.IsProcessIdRunning(characterAccountConfig_0.int_136))
		{
			medicineItemNameCandidates = InventoryItemMemoryHelper.CollectInventoryItemNames(characterAccountConfig_0);
			if (medicineItemNameCandidates != null)
			{
				Array.Sort(medicineItemNameCandidates);
				for (int i = 0; i < medicineItemNameCandidates.Length; i++)
				{
					string text3 = GameTextEncodingHelper.ConvertGameTextToDisplayText(medicineItemNameCandidates[i], 1);
					comboBoxThuoc.Items.Add(text3);
					if (text2 == null || text3 == text)
					{
						text2 = text;
					}
				}
			}
			if (text2 != null)
			{
				comboBoxThuoc.Text = text2;
			}
		}
		else if (characterAccountConfig_0.int_136 > 0)
		{
			buttonApdung.Enabled = false;
			characterAccountConfig_0.int_136 = 0;
		}
	}

	private void listView1_MouseDown(object sender, MouseEventArgs e)
	{
		int num = FindClickedListViewRowIndex(listView1, e);
		labelThemThuoc.Enabled = num >= 0;
	}

	private void listView1_MouseClick(object sender, MouseEventArgs e)
	{
		RefreshSelectedHotkeyMedicineList();
	}

	private void listView2_MouseDown(object sender, MouseEventArgs e)
	{
		int num = FindClickedListViewRowIndex(listView2, e);
		labelXoaThuoc.Enabled = num >= 0;
	}

	private void listView2_MouseClick(object sender, MouseEventArgs e)
	{
		int num = FindSelectedListViewItemIndex(listView2);
		labelXoaThuoc.Enabled = num >= 0;
		if (num >= 0)
		{
			comboBoxThuoc.Text = listView2.Items[num].SubItems[0].Text;
			numericUpDown1.Value = CommonUtility.ParseInt32OrZero(listView2.Items[num].SubItems[1].Text);
		}
	}

	private void UpdateSelectedMedicineCount()
	{
		int num = FindSelectedListViewItemIndex(listView2);
		if (num < 0 || selectedComboHotkeyRowIndex < 0 || selectedComboHotkeyRowIndex >= listView1.Items.Count)
		{
			return;
		}
		int num2 = KeyboardKeyCatalog.GetVirtualKeyCode(KeyboardKeyCatalog.gstruct42_1, listView1.Items[selectedComboHotkeyRowIndex].SubItems[0].Text);
		if (num2 < 0)
		{
			return;
		}
		int num3 = FindComboHotkeyEntryIndex(characterAccountConfig_0.medicineComboHotkeys, num2);
		if (num3 >= 0)
		{
			int num4 = FindComboMedicineEntryIndexByName(characterAccountConfig_0.medicineComboHotkeys[num3].medicineEntries, listView2.Items[num].SubItems[0].Text);
			if (num4 >= 0)
			{
				listView2.Items[num].SubItems[1].Text = numericUpDown1.Value.ToString();
				characterAccountConfig_0.medicineComboHotkeys[num3].medicineEntries[num4].medicineCount = (int)numericUpDown1.Value;
			}
		}
	}

	private void numericUpDown1_ValueChanged(object sender, EventArgs e)
	{
		UpdateSelectedMedicineCount();
	}

	private void numericUpDown1_KeyUp(object sender, KeyEventArgs e)
	{
		UpdateSelectedMedicineCount();
	}

	private void numericUpDown2_KeyUp(object sender, KeyEventArgs e)
	{
		if (timer_0.Enabled)
		{
			medicinePumpRatioDivisor = (int)numericUpDown2.Value;
			WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), "flagTileBom", medicinePumpRatioDivisor, "", 0);
		}
	}

	private void numericUpDown2_ValueChanged(object sender, EventArgs e)
	{
		if (timer_0.Enabled)
		{
			medicinePumpRatioDivisor = (int)numericUpDown2.Value;
			WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), "flagBomDelay", medicinePumpRatioDivisor, "", 0);
		}
	}

	private void buttonApdung_Click(object sender, EventArgs e)
	{
		string text = null;
		text = ((!SaveComboConfigurationToAccounts()) ? ("Lưu cấu hình thất bại (không tồn tại " + GameTextEncodingHelper.ConvertGameTextToDisplayText(characterAccountConfig_0.string_22, 1) + ").") : (GameTextEncodingHelper.ConvertGameTextToDisplayText(characterAccountConfig_0.string_22, 1) + ": đã lưu cấu hình combo."));
		GlobalKeyboardHookManager.RemoveGlobalKeyboardHookAndResetState();
		GlobalKeyboardHookManager.InstallGlobalKeyboardHook();
		CommonUtility.AppendStringIfMissing(ref CommonUtility.string_17, text);
		Close();
	}

	private void buttonXoaFilecauhinh_Click(object sender, EventArgs e)
	{
		CommonUtility.DeleteMatchingFilesAndMeasure(GameConfigurationManager.comboConfigDirectory);
		characterAccountConfig_0.medicineComboHotkeys = null;
		if (Form1.characterAccountConfig_1 != null)
		{
			for (int i = 0; i < Form1.characterAccountConfig_1.Length; i++)
			{
				Form1.characterAccountConfig_1[i].medicineComboHotkeys = null;
			}
		}
		comboBoxPhim.Items.Clear();
		if (KeyboardKeyCatalog.gstruct42_1 != null)
		{
			for (int j = 0; j < KeyboardKeyCatalog.gstruct42_1.Length; j++)
			{
				comboBoxPhim.Items.Add(KeyboardKeyCatalog.gstruct42_1[j].keyLabel);
			}
			comboBoxPhim.Text = KeyboardKeyCatalog.gstruct42_1[0].keyLabel;
		}
		listView1.Items.Clear();
		listView2.Items.Clear();
		labelStatus.Text = "Đã xóa cấu hình combo của tất cả nhân vật.";
	}

	private void checkBoxDungchung_CheckedChanged(object sender, EventArgs e)
	{
		if (timer_0.Enabled)
		{
			sharedMedicineRatioEnabled = Convert.ToByte(checkBoxDungchung.Checked);
			WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), "flagBomChungThuoc", sharedMedicineRatioEnabled, "", 0);
		}
	}

	private void labelThemThuoc_Click(object sender, EventArgs e)
	{
		if (medicineItemNameCandidates == null)
		{
			return;
		}
		string text = comboBoxThuoc.Text;
		if (!(text == "") && selectedComboHotkeyRowIndex >= 0 && selectedComboHotkeyRowIndex < listView1.Items.Count)
		{
			int num = KeyboardKeyCatalog.GetVirtualKeyCode(KeyboardKeyCatalog.gstruct42_1, listView1.Items[selectedComboHotkeyRowIndex].SubItems[0].Text);
			if (num >= 0)
			{
				int num2 = FindComboHotkeyEntryIndex(characterAccountConfig_0.medicineComboHotkeys, num);
				if (num2 >= 0)
				{
					if (listView2.Items.Count > 0)
					{
						for (int i = 0; i < listView2.Items.Count; i++)
						{
							if (text == listView2.Items[i].SubItems[0].Text)
							{
								return;
							}
						}
					}
					string text2 = null;
					for (int j = 0; j < medicineItemNameCandidates.Length; j++)
					{
						if (text == GameTextEncodingHelper.ConvertGameTextToDisplayText(medicineItemNameCandidates[j], 1))
						{
							text2 = medicineItemNameCandidates[j];
							break;
						}
					}
					if (text2 != null)
					{
						int int_ = (int)numericUpDown1.Value;
						AppendComboMedicineListViewRow(GameTextEncodingHelper.ConvertGameTextToDisplayText(text2, 1), int_);
						AppendComboMedicineEntryIfMissing(ref characterAccountConfig_0.medicineComboHotkeys[num2].medicineEntries, text2, int_);
					}
				}
				else
				{
					labelStatus.Text = "Hãy chọn phím bơm và chọn tên thuốc rồi bấm nút thêm.";
				}
			}
			else
			{
				labelStatus.Text = "Hãy chọn phím bơm và chọn tên thuốc rồi bấm nút thêm.";
			}
		}
		else
		{
			labelStatus.Text = "Hãy chọn phím bơm và chọn tên thuốc rồi bấm nút thêm.";
		}
	}

	private void labelXoaThuoc_Click(object sender, EventArgs e)
	{
		int num = FindSelectedListViewItemIndex(listView2);
		if (num < 0 || selectedComboHotkeyRowIndex < 0 || selectedComboHotkeyRowIndex >= listView1.Items.Count)
		{
			return;
		}
		int num2 = KeyboardKeyCatalog.GetVirtualKeyCode(KeyboardKeyCatalog.gstruct42_1, listView1.Items[selectedComboHotkeyRowIndex].SubItems[0].Text);
		if (num2 >= 0)
		{
			int num3 = FindComboHotkeyEntryIndex(characterAccountConfig_0.medicineComboHotkeys, num2);
			if (num3 >= 0)
			{
				RemoveComboMedicineEntryByName(ref characterAccountConfig_0.medicineComboHotkeys[num3].medicineEntries, listView2.Items[num].SubItems[0].Text);
				listView2.Items.RemoveAt(num);
				labelXoaThuoc.Enabled = listView2.Items.Count > 0;
			}
		}
	}

	private void labelXoaPhim_Click(object sender, EventArgs e)
	{
		int num = FindSelectedListViewItemIndex(listView1);
		if (num < 0)
		{
			return;
		}
		string text = listView1.Items[num].SubItems[0].Text;
		listView1.Items.RemoveAt(num);
		RemoveComboHotkeyEntryByLabel(ref characterAccountConfig_0.medicineComboHotkeys, text);
		if (num > listView1.Items.Count - 1)
		{
			num = listView1.Items.Count - 1;
		}
		labelXoaThuoc.Enabled = num >= 0;
		if (num < 0)
		{
			listView2.Items.Clear();
		}
		else
		{
			listView1.Items[num].Selected = true;
			listView1.Items[num].Focused = true;
			RefreshSelectedHotkeyMedicineList(bool_1: false);
		}
		selectedComboHotkeyRowIndex = num;
		int num2 = 0;
		while (true)
		{
			if (num2 < comboBoxPhim.Items.Count)
			{
				if (!(text == comboBoxPhim.Items[num2].ToString()))
				{
					num2++;
					continue;
				}
				break;
			}
			comboBoxPhim.Items.Add(text);
			comboBoxPhim.Sorted = true;
			if (comboBoxPhim.Text == "")
			{
				comboBoxPhim.Text = text;
			}
			labelXoaPhim.Enabled = listView1.Items.Count > 0;
			labelThemThuoc.Enabled = selectedComboHotkeyRowIndex >= 0;
			break;
		}
	}

	private void buttonTaoPhim_Click(object sender, EventArgs e)
	{
		string text = comboBoxPhim.Text;
		if (text == "")
		{
			return;
		}
		if (listView1.Items.Count > 0)
		{
			for (int i = 0; i < listView1.Items.Count; i++)
			{
				if (text == listView1.Items[i].SubItems[0].Text)
				{
					return;
				}
			}
		}
		listView1.Items.Add(new ListViewItem(text));
		AppendComboHotkeyEntryIfMissing(ref characterAccountConfig_0.medicineComboHotkeys, text);
		for (int j = 0; j < comboBoxPhim.Items.Count; j++)
		{
			if (text == comboBoxPhim.Items[j].ToString())
			{
				comboBoxPhim.Items.RemoveAt(j);
				if (j >= comboBoxPhim.Items.Count)
				{
					j = comboBoxPhim.Items.Count - 1;
				}
				if (j >= 0)
				{
					comboBoxPhim.Text = comboBoxPhim.Items[j].ToString();
				}
				break;
			}
		}
		labelXoaPhim.Enabled = listView1.Items.Count > 0;
	}

	private void buttonPhimHuongdan_Click(object sender, EventArgs e)
	{
		string string_ = "https://www.youtube.com/watch?v=1duqVxbJRKk";
		WindowsInteropHelper.StartProcess(WindowsRegistryHelper.GetDefaultHttpHandlerExecutablePath(), "", string_, 0);
	}

	private void labelTile_Click(object sender, EventArgs e)
	{
		string string_ = "Tỉ lệ bơm thuốc:|Giả sử ac thao tác để bơm Ngũ Hoa 10 bình, Cửu chuyển 10 bình thì:||Ví dụ tỉ lệ 1/2 (1 chia 2 = 0,50 => Số dư 0):|- Ac thao tác bơm đúng 10 bình Ngũ Hoa và 10 bình Cửu chuyển.|- Các ac còn lại bơm theo tỉ lệ 1/2 (tức 0,5) nên sẽ bơm 5 bình Ngũ Hoa và 5 bình Cửu chuyển.||Ví dụ tỉ lệ 1/3 (1 chia 3 = 0,33 => Số dư 3 > 0):|- Ac thao tác bơm đúng 10 bình Ngũ Hoa và 10 bình Cửu chuyển.|- Do số dư > 0 nên ac thao tác sẽ bơm với số lượng + 1, tức sẽ bơm 4 bình ngũ hoa và 4 bình Cửu chuyển.||Lưu ý: ac thao tác là ac trên cửa sổ game mà bạn đang cầm chuột điều khiển, bất kể đó là ac chính hay ac phụ cũng được. Khi combo, ac đang ở trong thành thì sẽ không bơm thuốc.";
		FormTip.ShowTipWindow("BOM THUOC", string_, 600000, 420, 250);
	}

	private void checkBoxPhiChiendau_CheckedChanged(object sender, EventArgs e)
	{
		if (timer_0.Enabled)
		{
			allowMedicinePumpInTownAndBattleAreasEnabled = Convert.ToByte(checkBoxPhiChiendau.Checked);
			WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), "flagPhiCD", allowMedicinePumpInTownAndBattleAreasEnabled, "", 0);
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		if (medicineItemNameCandidates == null)
		{
			return;
		}
		string text = comboBoxThuoc.Text;
		if (!(text == "") && selectedComboHotkeyRowIndex >= 0 && selectedComboHotkeyRowIndex < listView1.Items.Count)
		{
			int num = KeyboardKeyCatalog.GetVirtualKeyCode(KeyboardKeyCatalog.gstruct42_1, listView1.Items[selectedComboHotkeyRowIndex].SubItems[0].Text);
			if (num < 0)
			{
				labelStatus.Text = "Hãy chọn phím bơm và chọn tên thuốc rồi bấm nút thêm.";
				return;
			}
			int num2 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, characterAccountConfig_0.int_136);
			if (num2 < 0 || Form1.characterAccountConfig_1 == null)
			{
				return;
			}
			for (int i = 0; i < Form1.characterAccountConfig_1.Length; i++)
			{
				if (Form1.characterAccountConfig_1[i].int_136 == characterAccountConfig_0.int_136)
				{
					continue;
				}
				Form1.characterAccountConfig_1[i].medicineComboHotkeys = null;
				if (characterAccountConfig_0.medicineComboHotkeys != null)
				{
					Form1.characterAccountConfig_1[i].medicineComboHotkeys = new MedicineComboHotkeyConfig[characterAccountConfig_0.medicineComboHotkeys.GetLength(0)];
					for (int j = 0; j < characterAccountConfig_0.medicineComboHotkeys.Length; j++)
					{
						Form1.characterAccountConfig_1[i].medicineComboHotkeys[j].virtualKeyCode = characterAccountConfig_0.medicineComboHotkeys[j].virtualKeyCode;
						Form1.characterAccountConfig_1[i].medicineComboHotkeys[j].medicineEntries = null;
						if (characterAccountConfig_0.medicineComboHotkeys[j].medicineEntries != null)
						{
							Form1.characterAccountConfig_1[i].medicineComboHotkeys[j].medicineEntries = new ComboMedicineEntry[characterAccountConfig_0.medicineComboHotkeys[j].medicineEntries.Length];
							for (int k = 0; k < characterAccountConfig_0.medicineComboHotkeys[j].medicineEntries.GetLength(0); k++)
							{
								Form1.characterAccountConfig_1[i].medicineComboHotkeys[j].medicineEntries[k].medicineName = characterAccountConfig_0.medicineComboHotkeys[j].medicineEntries[k].medicineName;
								Form1.characterAccountConfig_1[i].medicineComboHotkeys[j].medicineEntries[k].medicineCount = characterAccountConfig_0.medicineComboHotkeys[j].medicineEntries[k].medicineCount;
							}
						}
					}
				}
				GameConfigurationManager.SaveCharacterConfiguration(Form1.characterAccountConfig_1[i]);
			}
		}
		else
		{
			labelStatus.Text = "Hãy chọn phím bơm và chọn tên thuốc rồi bấm nút thêm.";
		}
	}

	private void SetWindowTitle(string string_1)
	{
		base.Text = string_1;
	}
}

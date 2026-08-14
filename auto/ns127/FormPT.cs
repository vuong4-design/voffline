using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns1;
using ns100;
using ns11;
using ns3;
using ns53;
using ns83;

namespace ns127;

public class FormPT : Form
{
	private IContainer icontainer_0 = null;

	private ListView listView1;

	private ColumnHeader columnHeader_0;

	private ComboBox comboBoxAcc;

	private Button buttonThem;

	private Button buttonXoa;

	private Timer timer_0;

	private Button buttonThoat;

	private Label label1;

	private CheckBox checkBoxPTtheoBHO;

	private CheckBox checkBoxTheoDSnhom;

	private CheckBox checkBoxLuonLamDoitruong;

	private CheckBox checkBoxHienThiSonguoi;

	private Button buttonApdungAll;

	private Button buttonAllAc;

	public static bool isPartyFormOpen = false;

	public static CharacterAccountConfig characterAccountConfig_0 = default(CharacterAccountConfig);

	private static string[] availablePartyMemberNames = null;

	public int popupAnchorX;

	public int popupAnchorY;

	public int ownerWindowWidth;

	public int ownerWindowHeight;

	private int selectedPartyMemberRowIndex = -1;

	private bool partyControlsReady = false;

	public FormPT()
	{
		isPartyFormOpen = true;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ns127.FormPT));
		this.listView1 = new System.Windows.Forms.ListView();
		this.columnHeader_0 = new System.Windows.Forms.ColumnHeader();
		this.comboBoxAcc = new System.Windows.Forms.ComboBox();
		this.buttonThem = new System.Windows.Forms.Button();
		this.buttonXoa = new System.Windows.Forms.Button();
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.buttonThoat = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.checkBoxPTtheoBHO = new System.Windows.Forms.CheckBox();
		this.checkBoxTheoDSnhom = new System.Windows.Forms.CheckBox();
		this.checkBoxLuonLamDoitruong = new System.Windows.Forms.CheckBox();
		this.checkBoxHienThiSonguoi = new System.Windows.Forms.CheckBox();
		this.buttonApdungAll = new System.Windows.Forms.Button();
		this.buttonAllAc = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[1] { this.columnHeader_0 });
		this.listView1.FullRowSelect = true;
		this.listView1.GridLines = true;
		this.listView1.HideSelection = false;
		this.listView1.Location = new System.Drawing.Point(10, 27);
		this.listView1.MultiSelect = false;
		this.listView1.Name = "listView1";
		this.listView1.Size = new System.Drawing.Size(245, 158);
		this.listView1.TabIndex = 1;
		this.listView1.UseCompatibleStateImageBehavior = false;
		this.listView1.View = System.Windows.Forms.View.Details;
		this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(listView1_MouseClick);
		this.columnHeader_0.Text = "Nhân vật";
		this.columnHeader_0.Width = 200;
		this.comboBoxAcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxAcc.FormattingEnabled = true;
		this.comboBoxAcc.Location = new System.Drawing.Point(10, 191);
		this.comboBoxAcc.Name = "comboBoxAcc";
		this.comboBoxAcc.Size = new System.Drawing.Size(139, 21);
		this.comboBoxAcc.TabIndex = 2;
		this.comboBoxAcc.DropDown += new System.EventHandler(comboBoxAcc_DropDown);
		this.buttonThem.Location = new System.Drawing.Point(155, 189);
		this.buttonThem.Name = "buttonThem";
		this.buttonThem.Size = new System.Drawing.Size(55, 23);
		this.buttonThem.TabIndex = 3;
		this.buttonThem.Text = "Thêm";
		this.buttonThem.UseVisualStyleBackColor = true;
		this.buttonThem.Click += new System.EventHandler(buttonThem_Click);
		this.buttonXoa.Location = new System.Drawing.Point(212, 189);
		this.buttonXoa.Name = "buttonXoa";
		this.buttonXoa.Size = new System.Drawing.Size(42, 23);
		this.buttonXoa.TabIndex = 4;
		this.buttonXoa.Text = "Xóa";
		this.buttonXoa.UseVisualStyleBackColor = true;
		this.buttonXoa.Click += new System.EventHandler(buttonXoa_Click);
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		this.buttonThoat.Location = new System.Drawing.Point(155, 343);
		this.buttonThoat.Name = "buttonThoat";
		this.buttonThoat.Size = new System.Drawing.Size(99, 26);
		this.buttonThoat.TabIndex = 6;
		this.buttonThoat.Text = "Đóng";
		this.buttonThoat.UseVisualStyleBackColor = true;
		this.buttonThoat.Click += new System.EventHandler(buttonThoat_Click);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(8, 7);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(88, 13);
		this.label1.TabIndex = 7;
		this.label1.Text = "Danh sách nhóm";
		this.checkBoxPTtheoBHO.AutoSize = true;
		this.checkBoxPTtheoBHO.Location = new System.Drawing.Point(30, 282);
		this.checkBoxPTtheoBHO.Name = "checkBoxPTtheoBHO";
		this.checkBoxPTtheoBHO.Size = new System.Drawing.Size(128, 17);
		this.checkBoxPTtheoBHO.TabIndex = 8;
		this.checkBoxPTtheoBHO.Text = "Mời PT theo bang hội";
		this.checkBoxPTtheoBHO.UseVisualStyleBackColor = true;
		this.checkBoxPTtheoBHO.CheckedChanged += new System.EventHandler(checkBoxPTtheoBHO_CheckedChanged);
		this.checkBoxTheoDSnhom.AutoSize = true;
		this.checkBoxTheoDSnhom.Location = new System.Drawing.Point(30, 256);
		this.checkBoxTheoDSnhom.Name = "checkBoxTheoDSnhom";
		this.checkBoxTheoDSnhom.Size = new System.Drawing.Size(191, 17);
		this.checkBoxTheoDSnhom.TabIndex = 9;
		this.checkBoxTheoDSnhom.Text = "Mời hoặc nhận PT theo danh sách";
		this.checkBoxTheoDSnhom.UseVisualStyleBackColor = true;
		this.checkBoxTheoDSnhom.CheckedChanged += new System.EventHandler(checkBoxTheoDSnhom_CheckedChanged);
		this.checkBoxLuonLamDoitruong.AutoSize = true;
		this.checkBoxLuonLamDoitruong.Location = new System.Drawing.Point(10, 230);
		this.checkBoxLuonLamDoitruong.Name = "checkBoxLuonLamDoitruong";
		this.checkBoxLuonLamDoitruong.Size = new System.Drawing.Size(120, 17);
		this.checkBoxLuonLamDoitruong.TabIndex = 10;
		this.checkBoxLuonLamDoitruong.Text = "Luôn làm đội trưởng";
		this.checkBoxLuonLamDoitruong.UseVisualStyleBackColor = true;
		this.checkBoxLuonLamDoitruong.CheckedChanged += new System.EventHandler(checkBoxLuonLamDoitruong_CheckedChanged);
		this.checkBoxHienThiSonguoi.AutoSize = true;
		this.checkBoxHienThiSonguoi.Location = new System.Drawing.Point(10, 308);
		this.checkBoxHienThiSonguoi.Name = "checkBoxHienThiSonguoi";
		this.checkBoxHienThiSonguoi.Size = new System.Drawing.Size(161, 17);
		this.checkBoxHienThiSonguoi.TabIndex = 11;
		this.checkBoxHienThiSonguoi.Text = "Hiển thị số người trong nhóm";
		this.checkBoxHienThiSonguoi.UseVisualStyleBackColor = true;
		this.checkBoxHienThiSonguoi.CheckedChanged += new System.EventHandler(checkBoxHienThiSonguoi_CheckedChanged);
		this.buttonApdungAll.Location = new System.Drawing.Point(10, 343);
		this.buttonApdungAll.Name = "buttonApdungAll";
		this.buttonApdungAll.Size = new System.Drawing.Size(139, 26);
		this.buttonApdungAll.TabIndex = 13;
		this.buttonApdungAll.Text = "Áp dụng cho tất cả ac";
		this.buttonApdungAll.UseVisualStyleBackColor = true;
		this.buttonApdungAll.Click += new System.EventHandler(buttonApdungAll_Click);
		this.buttonAllAc.Location = new System.Drawing.Point(155, 216);
		this.buttonAllAc.Name = "buttonAllAc";
		this.buttonAllAc.Size = new System.Drawing.Size(99, 36);
		this.buttonAllAc.TabIndex = 14;
		this.buttonAllAc.Text = "Thêm tất cả ac trên auto";
		this.buttonAllAc.UseVisualStyleBackColor = true;
		this.buttonAllAc.Click += new System.EventHandler(buttonAllAc_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(268, 378);
		base.Controls.Add(this.buttonAllAc);
		base.Controls.Add(this.buttonApdungAll);
		base.Controls.Add(this.checkBoxHienThiSonguoi);
		base.Controls.Add(this.checkBoxLuonLamDoitruong);
		base.Controls.Add(this.checkBoxTheoDSnhom);
		base.Controls.Add(this.checkBoxPTtheoBHO);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.buttonThoat);
		base.Controls.Add(this.buttonXoa);
		base.Controls.Add(this.buttonThem);
		base.Controls.Add(this.comboBoxAcc);
		base.Controls.Add(this.listView1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormPT";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		this.Text = "PT";
		base.Load += new System.EventHandler(FormPT_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	protected override void OnFormClosing(FormClosingEventArgs e)
	{
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, characterAccountConfig_0.int_136);
		if (0 <= num)
		{
			Form1.characterAccountConfig_1[num].string_19 = characterAccountConfig_0.string_19;
			Form1.characterAccountConfig_1[num].int_121 = characterAccountConfig_0.int_121;
			GameConfigurationManager.SaveCharacterConfiguration(Form1.characterAccountConfig_1[num]);
		}
		characterAccountConfig_0.int_136 = 0;
		popupAnchorX = 0;
		popupAnchorY = 0;
		isPartyFormOpen = false;
	}

	private void FormPT_Load(object sender, EventArgs e)
	{
		partyControlsReady = false;
		if (characterAccountConfig_0.int_136 == 0)
		{
			Close();
			return;
		}
		if (popupAnchorX > 0 && popupAnchorY > 0)
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
		if (characterAccountConfig_0.string_19 != null && characterAccountConfig_0.string_19.Length != 0)
		{
			for (int i = 0; i < characterAccountConfig_0.string_19.Length; i++)
			{
				if (characterAccountConfig_0.string_19[i] != null && characterAccountConfig_0.string_19[i] != string.Empty)
				{
					AppendPartyListViewItem(listView1, GameTextEncodingHelper.ConvertGameTextToDisplayText(characterAccountConfig_0.string_19[i], 1));
				}
			}
		}
		if (characterAccountConfig_0.int_121 == null || characterAccountConfig_0.int_121.Length < 5)
		{
			characterAccountConfig_0.int_121 = new int[5] { 0, 0, 0, 0, 5 };
		}
		checkBoxLuonLamDoitruong.Checked = characterAccountConfig_0.int_121[1] > 0;
		checkBoxTheoDSnhom.Checked = characterAccountConfig_0.int_121[2] > 0;
		checkBoxPTtheoBHO.Checked = characterAccountConfig_0.int_121[3] > 0;
		checkBoxPTtheoBHO.Enabled = characterAccountConfig_0.int_121[1] > 0;
		checkBoxHienThiSonguoi.Checked = characterAccountConfig_0.int_121[4] > 0;
		timer_0.Interval = 300;
		timer_0.Enabled = true;
		base.TopMost = true;
		SetWindowTitle("PT ( " + GameTextEncodingHelper.ConvertGameTextToDisplayText(characterAccountConfig_0.string_22, 1) + " )");
		partyControlsReady = true;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (!isPartyFormOpen)
		{
			Close();
		}
	}

	private void AppendPartyListViewItem(ListView listView_0, string string_1)
	{
		try
		{
			ListViewItem value = new ListViewItem(string_1);
			listView_0.Items.Add(value);
		}
		catch
		{
		}
	}

	private void comboBoxAcc_DropDown(object sender, EventArgs e)
	{
		comboBoxAcc.Items.Clear();
		availablePartyMemberNames = null;
		GameEntityMemoryHelper.CollectEntityNames(characterAccountConfig_0, ref availablePartyMemberNames, 1, characterAccountConfig_0.string_19);
		if (availablePartyMemberNames != null)
		{
			for (int i = 0; i < availablePartyMemberNames.Length; i++)
			{
				comboBoxAcc.Items.Add(GameTextEncodingHelper.ConvertGameTextToDisplayText(availablePartyMemberNames[i], 1));
			}
		}
		comboBoxAcc.Text = string.Empty;
	}

	private void buttonThem_Click(object sender, EventArgs e)
	{
		string text = comboBoxAcc.Text;
		comboBoxAcc.Items.Clear();
		if (availablePartyMemberNames == null || text == string.Empty)
		{
			return;
		}
		string text2 = null;
		for (int i = 0; i < availablePartyMemberNames.Length; i++)
		{
			if (availablePartyMemberNames[i] == text || GameTextEncodingHelper.ConvertGameTextToDisplayText(availablePartyMemberNames[i], 1) == text)
			{
				text2 = availablePartyMemberNames[i];
				break;
			}
		}
		if (text2 == null)
		{
			return;
		}
		if (characterAccountConfig_0.string_19 != null && characterAccountConfig_0.string_19.Length != 0)
		{
			for (int j = 0; j < characterAccountConfig_0.string_19.Length; j++)
			{
				if (characterAccountConfig_0.string_19[j] == text2)
				{
					return;
				}
			}
		}
		CommonUtility.AppendStringIfMissing(ref characterAccountConfig_0.string_19, text2);
		AppendPartyListViewItem(listView1, GameTextEncodingHelper.ConvertGameTextToDisplayText(text2, 1));
	}

	private void buttonXoa_Click(object sender, EventArgs e)
	{
		string text = comboBoxAcc.Text;
		comboBoxAcc.Items.Clear();
		if (characterAccountConfig_0.string_19 == null || text == string.Empty)
		{
			return;
		}
		for (int i = 0; i < listView1.Items.Count; i++)
		{
			if (text == listView1.Items[i].SubItems[0].Text)
			{
				listView1.Items.RemoveAt(i);
				break;
			}
		}
		if (characterAccountConfig_0.string_19.Length == 1 && (characterAccountConfig_0.string_19[0] == text || GameTextEncodingHelper.ConvertGameTextToDisplayText(characterAccountConfig_0.string_19[0], 1) == text))
		{
			characterAccountConfig_0.string_19 = null;
			listView1.Items.Clear();
			return;
		}
		int num = 0;
		string[] array = new string[characterAccountConfig_0.string_19.Length];
		for (int j = 0; j < characterAccountConfig_0.string_19.Length; j++)
		{
			if (!(characterAccountConfig_0.string_19[j] == text) && !(GameTextEncodingHelper.ConvertGameTextToDisplayText(characterAccountConfig_0.string_19[j], 1) == text))
			{
				array[num] = characterAccountConfig_0.string_19[j];
				num++;
			}
		}
		if (num != 0)
		{
			characterAccountConfig_0.string_19 = new string[num];
			for (int k = 0; k < num; k++)
			{
				characterAccountConfig_0.string_19[k] = array[k];
			}
		}
		else
		{
			characterAccountConfig_0.string_19 = null;
			listView1.Items.Clear();
		}
	}

	private void listView1_MouseClick(object sender, MouseEventArgs e)
	{
		selectedPartyMemberRowIndex = -1;
		if (listView1.Items == null)
		{
			return;
		}
		string text = comboBoxAcc.Text;
		int num = 0;
		while (true)
		{
			if (num < listView1.Items.Count)
			{
				if (listView1.Items[num].Selected)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		selectedPartyMemberRowIndex = num;
		string text2 = listView1.Items[num].SubItems[0].Text;
		if (text != text2)
		{
			comboBoxAcc.Items.Clear();
			comboBoxAcc.Items.Add(text2);
			comboBoxAcc.Text = text2;
		}
	}

	private void buttonThoat_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void checkBoxLuonLamDoitruong_CheckedChanged(object sender, EventArgs e)
	{
		if (partyControlsReady)
		{
			characterAccountConfig_0.int_121[1] = Convert.ToByte(checkBoxLuonLamDoitruong.Checked);
			checkBoxPTtheoBHO.Enabled = characterAccountConfig_0.int_121[1] > 0;
		}
	}

	private void checkBoxTheoDSnhom_CheckedChanged(object sender, EventArgs e)
	{
		if (partyControlsReady)
		{
			characterAccountConfig_0.int_121[2] = Convert.ToByte(checkBoxTheoDSnhom.Checked);
		}
	}

	private void checkBoxPTtheoBHO_CheckedChanged(object sender, EventArgs e)
	{
		if (partyControlsReady)
		{
			characterAccountConfig_0.int_121[3] = Convert.ToByte(checkBoxPTtheoBHO.Checked);
		}
	}

	private void checkBoxHienThiSonguoi_CheckedChanged(object sender, EventArgs e)
	{
		if (partyControlsReady)
		{
			characterAccountConfig_0.int_121[4] = Convert.ToByte(checkBoxHienThiSonguoi.Checked);
		}
	}

	private void buttonApdungAll_Click(object sender, EventArgs e)
	{
		if (Form1.characterAccountConfig_1 == null || Form1.characterAccountConfig_1.Length == 0)
		{
			return;
		}
		for (int i = 0; i < Form1.characterAccountConfig_1.Length; i++)
		{
			if (Form1.characterAccountConfig_1[i].int_136 == characterAccountConfig_0.int_136)
			{
				continue;
			}
			Form1.characterAccountConfig_1[i].string_19 = null;
			if (characterAccountConfig_0.int_121 != null)
			{
				int num = 0;
				if (Form1.characterAccountConfig_1[i].int_121 != null)
				{
					num = Form1.characterAccountConfig_1[i].int_121[1];
				}
				else
				{
					Form1.characterAccountConfig_1[i].int_121 = new int[characterAccountConfig_0.int_121.Length];
				}
				for (int j = 0; j < characterAccountConfig_0.int_121.Length; j++)
				{
					Form1.characterAccountConfig_1[i].int_121[j] = characterAccountConfig_0.int_121[j];
				}
				Form1.characterAccountConfig_1[i].int_121[1] = num;
			}
			if (characterAccountConfig_0.string_19 != null)
			{
				Form1.characterAccountConfig_1[i].string_19 = new string[characterAccountConfig_0.string_19.Length];
				for (int k = 0; k < characterAccountConfig_0.string_19.Length; k++)
				{
					Form1.characterAccountConfig_1[i].string_19[k] = characterAccountConfig_0.string_19[k];
				}
			}
			GameConfigurationManager.SaveCharacterConfiguration(Form1.characterAccountConfig_1[i]);
		}
	}

	private void buttonAllAc_Click(object sender, EventArgs e)
	{
		if (Form1.characterAccountConfig_1 != null && Form1.characterAccountConfig_1.Length != 0)
		{
			listView1.Items.Clear();
			characterAccountConfig_0.string_19 = new string[Form1.characterAccountConfig_1.Length];
			for (int i = 0; i < Form1.characterAccountConfig_1.Length; i++)
			{
				characterAccountConfig_0.string_19[i] = Form1.characterAccountConfig_1[i].string_22;
				AppendPartyListViewItem(listView1, GameTextEncodingHelper.ConvertGameTextToDisplayText(Form1.characterAccountConfig_1[i].string_22, 1));
			}
		}
	}

	private void SetWindowTitle(string string_1)
	{
		base.Text = string_1;
	}
}

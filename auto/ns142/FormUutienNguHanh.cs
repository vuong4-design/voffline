using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns1;
using ns100;
using ns35;
using ns53;
using ns83;

namespace ns142;

public class FormUutienNguHanh : Form
{
	private struct PriorityOption
	{
		public string displayName;

		public byte value;
	}

	public static int selectedAccountId = 0;

	public static string selectedFactionIdentifier = null;

	public int ownerWindowX;

	public int ownerWindowY;

	private static int int_3 = 0;

	private static CharacterAccountConfig selectedAccountSnapshot = default(CharacterAccountConfig);

	private PriorityOption[] elementPriorityOptions = new PriorityOption[5]
	{
		new PriorityOption
		{
			value = 0,
			displayName = "Kim"
		},
		new PriorityOption
		{
			value = 1,
			displayName = "Mộc"
		},
		new PriorityOption
		{
			value = 2,
			displayName = "Thủy"
		},
		new PriorityOption
		{
			value = 3,
			displayName = "Hỏa"
		},
		new PriorityOption
		{
			value = 4,
			displayName = "Thổ"
		}
	};

	private PriorityOption[] factionPriorityOptions = new PriorityOption[11]
	{
		new PriorityOption
		{
			value = 1,
			displayName = "Thiếu Lâm"
		},
		new PriorityOption
		{
			value = 2,
			displayName = "Võ Đang"
		},
		new PriorityOption
		{
			value = 3,
			displayName = "Nga My"
		},
		new PriorityOption
		{
			value = 4,
			displayName = "Côn Lôn"
		},
		new PriorityOption
		{
			value = 5,
			displayName = "Đường Môn"
		},
		new PriorityOption
		{
			value = 6,
			displayName = "Thúy Yên"
		},
		new PriorityOption
		{
			value = 7,
			displayName = "Cái Bang"
		},
		new PriorityOption
		{
			value = 8,
			displayName = "Thiên Vương"
		},
		new PriorityOption
		{
			value = 9,
			displayName = "Ngũ Độc"
		},
		new PriorityOption
		{
			value = 10,
			displayName = "Thiên Nhẫn"
		},
		new PriorityOption
		{
			value = 11,
			displayName = "Hoa Sơn"
		}
	};

	private IContainer icontainer_0 = null;

	private Timer timer_0;

	private ListView listView1;

	private ColumnHeader columnHeader_0;

	private Button buttonLen1;

	private Button buttonXuong1;

	private ColumnHeader columnHeader_1;

	private Button buttonUuTienMacdinh;

	private Button buttonClose;

	private GroupBox groupBoxNguHanh;

	private GroupBox groupBox1;

	private Button buttonMacdinhMP;

	private Button buttonXuongMP;

	private Button buttonLenMP;

	private ListView listView2;

	private ColumnHeader columnHeader_2;

	private IContainer icontainer_1;

	private ColumnHeader columnHeader_3;

	private CheckBox checkBoxNguHanh;

	private CheckBox checkBoxMonPhai;

	public FormUutienNguHanh()
	{
		InitializeComponent();
		base.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
	}

	private void FormUutienNguHanh_Load(object sender, EventArgs e)
	{
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, selectedAccountId);
		if (num >= 0)
		{
			int_3 = selectedAccountId;
			selectedAccountSnapshot = Form1.characterAccountConfig_1[num];
			if (ownerWindowX >= 0 && ownerWindowY >= 0)
			{
				int num2 = ownerWindowX - base.Width;
				int num3 = ownerWindowY;
				if (num2 < 0)
				{
					num2 = 0;
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
				SetBounds(num2, num3, base.Width, base.Height);
			}
			for (int i = 0; i < selectedAccountSnapshot.int_90.Length; i++)
			{
				AppendNumberedPriorityListViewItem(listView1, elementPriorityOptions[selectedAccountSnapshot.int_90[i]].displayName);
			}
			for (int j = 0; j < selectedAccountSnapshot.int_91.Length; j++)
			{
				AppendNumberedPriorityListViewItem(listView2, factionPriorityOptions[selectedAccountSnapshot.int_91[j] - 1].displayName);
			}
			timer_0.Interval = 300;
			timer_0.Enabled = true;
			SetWindowTitle(GameTextEncodingHelper.ConvertGameTextToDisplayText(selectedAccountSnapshot.string_22, 1) + " ( hệ " + elementPriorityOptions[CurrentCharacterMemoryHelper.GetCharacterFiveElementIndex(selectedAccountSnapshot)].displayName + ")");
			base.TopMost = true;
			bool flag = selectedAccountSnapshot.int_143 == 0;
			checkBoxNguHanh.Checked = flag;
			checkBoxMonPhai.Checked = !flag;
			SetElementPriorityControlsEnabled(flag);
			SetFactionPriorityControlsEnabled(!flag);
		}
		else
		{
			selectedAccountId = 0;
			Close();
		}
	}

	protected override void OnFormClosing(FormClosingEventArgs e)
	{
		selectedAccountId = 0;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (selectedAccountId == 0)
		{
			Close();
		}
	}

	private void buttonLen1_Click(object sender, EventArgs e)
	{
		if (!checkBoxNguHanh.Checked)
		{
			return;
		}
		int num = FindSelectedListViewItemIndex(listView1);
		if (num > 0)
		{
			int num2 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, selectedAccountId);
			if (num2 >= 0)
			{
				int num3 = Form1.characterAccountConfig_1[num2].int_90[num];
				Form1.characterAccountConfig_1[num2].int_90[num] = Form1.characterAccountConfig_1[num2].int_90[num - 1];
				Form1.characterAccountConfig_1[num2].int_90[num - 1] = num3;
				GameConfigurationManager.SaveCharacterConfiguration(Form1.characterAccountConfig_1[num2]);
				string text = listView1.Items[num].SubItems[1].Text;
				listView1.Items[num].SubItems[1].Text = listView1.Items[num - 1].SubItems[1].Text;
				listView1.Items[num - 1].SubItems[1].Text = text;
				listView1.Items[num - 1].Selected = true;
				listView1.Items[num - 1].Focused = true;
			}
			else
			{
				selectedAccountId = 0;
				Close();
			}
		}
	}

	private void buttonXuong1_Click(object sender, EventArgs e)
	{
		if (!checkBoxNguHanh.Checked)
		{
			return;
		}
		int num = FindSelectedListViewItemIndex(listView1);
		if (num >= 0 && num < listView1.Items.Count - 1)
		{
			int num2 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, selectedAccountId);
			if (num2 >= 0)
			{
				int num3 = Form1.characterAccountConfig_1[num2].int_90[num];
				Form1.characterAccountConfig_1[num2].int_90[num] = Form1.characterAccountConfig_1[num2].int_90[num + 1];
				Form1.characterAccountConfig_1[num2].int_90[num + 1] = num3;
				GameConfigurationManager.SaveCharacterConfiguration(Form1.characterAccountConfig_1[num2]);
				string text = listView1.Items[num].SubItems[1].Text;
				listView1.Items[num].SubItems[1].Text = listView1.Items[num + 1].SubItems[1].Text;
				listView1.Items[num + 1].SubItems[1].Text = text;
				listView1.Items[num + 1].Selected = true;
				listView1.Items[num + 1].Focused = true;
			}
			else
			{
				selectedAccountId = 0;
				Close();
			}
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

	private void AppendNumberedPriorityListViewItem(ListView listView_0, string string_1)
	{
		try
		{
			ListViewItem listViewItem = new ListViewItem((listView_0.Items.Count + 1).ToString());
			listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, string_1));
			listView_0.Items.Add(listViewItem);
		}
		catch
		{
		}
	}

	private void buttonUuTienMacdinh_Click(object sender, EventArgs e)
	{
		if (!checkBoxNguHanh.Checked)
		{
			return;
		}
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, selectedAccountId);
		if (num < 0)
		{
			selectedAccountId = 0;
			Close();
			return;
		}
		int int_ = CurrentCharacterMemoryHelper.GetCharacterFiveElementIndex(Form1.characterAccountConfig_1[num]);
		Form1.characterAccountConfig_1[num].int_90 = GameConfigurationManager.CopyFiveValueConfigurationRow(int_);
		GameConfigurationManager.SaveCharacterConfiguration(Form1.characterAccountConfig_1[num]);
		CharacterAccountConfig characterAccountConfig = Form1.characterAccountConfig_1[num];
		listView1.Items.Clear();
		for (int i = 0; i < characterAccountConfig.int_90.Length; i++)
		{
			AppendNumberedPriorityListViewItem(listView1, elementPriorityOptions[characterAccountConfig.int_90[i]].displayName);
		}
	}

	private void buttonClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void buttonLenMP_Click(object sender, EventArgs e)
	{
		if (!checkBoxMonPhai.Checked)
		{
			return;
		}
		int num = FindSelectedListViewItemIndex(listView2);
		if (num > 0)
		{
			int num2 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, selectedAccountId);
			if (num2 >= 0)
			{
				int num3 = Form1.characterAccountConfig_1[num2].int_91[num];
				Form1.characterAccountConfig_1[num2].int_91[num] = Form1.characterAccountConfig_1[num2].int_91[num - 1];
				Form1.characterAccountConfig_1[num2].int_91[num - 1] = num3;
				GameConfigurationManager.SaveCharacterConfiguration(Form1.characterAccountConfig_1[num2]);
				string text = listView2.Items[num].SubItems[1].Text;
				listView2.Items[num].SubItems[1].Text = listView2.Items[num - 1].SubItems[1].Text;
				listView2.Items[num - 1].SubItems[1].Text = text;
				listView2.Items[num - 1].Selected = true;
				listView2.Items[num - 1].Focused = true;
			}
			else
			{
				selectedAccountId = 0;
				Close();
			}
		}
	}

	private void buttonXuongMP_Click(object sender, EventArgs e)
	{
		if (!checkBoxMonPhai.Checked)
		{
			return;
		}
		int num = FindSelectedListViewItemIndex(listView2);
		if (num >= 0 && num < listView2.Items.Count - 1)
		{
			int num2 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, selectedAccountId);
			if (num2 >= 0)
			{
				int num3 = Form1.characterAccountConfig_1[num2].int_91[num];
				Form1.characterAccountConfig_1[num2].int_91[num] = Form1.characterAccountConfig_1[num2].int_91[num + 1];
				Form1.characterAccountConfig_1[num2].int_91[num + 1] = num3;
				GameConfigurationManager.SaveCharacterConfiguration(Form1.characterAccountConfig_1[num2]);
				string text = listView2.Items[num].SubItems[1].Text;
				listView2.Items[num].SubItems[1].Text = listView2.Items[num + 1].SubItems[1].Text;
				listView2.Items[num + 1].SubItems[1].Text = text;
				listView2.Items[num + 1].Selected = true;
				listView2.Items[num + 1].Focused = true;
			}
			else
			{
				selectedAccountId = 0;
				Close();
			}
		}
	}

	private void buttonMacdinhMP_Click(object sender, EventArgs e)
	{
		if (!checkBoxMonPhai.Checked)
		{
			return;
		}
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, selectedAccountId);
		if (num < 0)
		{
			selectedAccountId = 0;
			Close();
			return;
		}
		Form1.characterAccountConfig_1[num].int_91 = new int[11];
		for (int i = 0; i < 11; i++)
		{
			Form1.characterAccountConfig_1[num].int_91[i] = i + 1;
		}
		GameConfigurationManager.SaveCharacterConfiguration(Form1.characterAccountConfig_1[num]);
		CharacterAccountConfig characterAccountConfig = Form1.characterAccountConfig_1[num];
		listView2.Items.Clear();
		for (int j = 0; j < characterAccountConfig.int_91.Length; j++)
		{
			AppendNumberedPriorityListViewItem(listView2, factionPriorityOptions[characterAccountConfig.int_91[j] - 1].displayName);
		}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ns142.FormUutienNguHanh));
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_1);
		this.listView1 = new System.Windows.Forms.ListView();
		this.columnHeader_0 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_1 = new System.Windows.Forms.ColumnHeader();
		this.buttonLen1 = new System.Windows.Forms.Button();
		this.buttonXuong1 = new System.Windows.Forms.Button();
		this.buttonUuTienMacdinh = new System.Windows.Forms.Button();
		this.buttonClose = new System.Windows.Forms.Button();
		this.groupBoxNguHanh = new System.Windows.Forms.GroupBox();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.buttonMacdinhMP = new System.Windows.Forms.Button();
		this.buttonXuongMP = new System.Windows.Forms.Button();
		this.buttonLenMP = new System.Windows.Forms.Button();
		this.listView2 = new System.Windows.Forms.ListView();
		this.columnHeader_2 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_3 = new System.Windows.Forms.ColumnHeader();
		this.checkBoxNguHanh = new System.Windows.Forms.CheckBox();
		this.checkBoxMonPhai = new System.Windows.Forms.CheckBox();
		this.groupBoxNguHanh.SuspendLayout();
		this.groupBox1.SuspendLayout();
		base.SuspendLayout();
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.columnHeader_0, this.columnHeader_1 });
		this.listView1.FullRowSelect = true;
		this.listView1.GridLines = true;
		this.listView1.HideSelection = false;
		this.listView1.Location = new System.Drawing.Point(8, 20);
		this.listView1.MultiSelect = false;
		this.listView1.Name = "listView1";
		this.listView1.Size = new System.Drawing.Size(130, 130);
		this.listView1.TabIndex = 10;
		this.listView1.UseCompatibleStateImageBehavior = false;
		this.listView1.View = System.Windows.Forms.View.Details;
		this.listView1.SelectedIndexChanged += new System.EventHandler(listView1_SelectedIndexChanged);
		this.columnHeader_0.Text = "STT";
		this.columnHeader_0.Width = 30;
		this.columnHeader_1.Text = "Ngũ hành";
		this.columnHeader_1.Width = 80;
		this.buttonLen1.BackColor = System.Drawing.SystemColors.Control;
		this.buttonLen1.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.buttonLen1.ForeColor = System.Drawing.Color.Black;
		this.buttonLen1.Location = new System.Drawing.Point(144, 43);
		this.buttonLen1.Name = "buttonLen1";
		this.buttonLen1.Size = new System.Drawing.Size(59, 28);
		this.buttonLen1.TabIndex = 134;
		this.buttonLen1.Text = "Lên";
		this.buttonLen1.UseVisualStyleBackColor = false;
		this.buttonLen1.Click += new System.EventHandler(buttonLen1_Click);
		this.buttonXuong1.BackColor = System.Drawing.SystemColors.Control;
		this.buttonXuong1.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.buttonXuong1.ForeColor = System.Drawing.Color.Black;
		this.buttonXuong1.Location = new System.Drawing.Point(144, 76);
		this.buttonXuong1.Name = "buttonXuong1";
		this.buttonXuong1.Size = new System.Drawing.Size(59, 28);
		this.buttonXuong1.TabIndex = 135;
		this.buttonXuong1.Text = "Xuống";
		this.buttonXuong1.UseVisualStyleBackColor = false;
		this.buttonXuong1.Click += new System.EventHandler(buttonXuong1_Click);
		this.buttonUuTienMacdinh.BackColor = System.Drawing.SystemColors.Control;
		this.buttonUuTienMacdinh.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.buttonUuTienMacdinh.ForeColor = System.Drawing.Color.Black;
		this.buttonUuTienMacdinh.Location = new System.Drawing.Point(144, 123);
		this.buttonUuTienMacdinh.Name = "buttonUuTienMacdinh";
		this.buttonUuTienMacdinh.Size = new System.Drawing.Size(59, 28);
		this.buttonUuTienMacdinh.TabIndex = 138;
		this.buttonUuTienMacdinh.Text = "Mặc định";
		this.buttonUuTienMacdinh.UseVisualStyleBackColor = false;
		this.buttonUuTienMacdinh.Click += new System.EventHandler(buttonUuTienMacdinh_Click);
		this.buttonClose.BackColor = System.Drawing.Color.SeaGreen;
		this.buttonClose.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.buttonClose.ForeColor = System.Drawing.Color.Black;
		this.buttonClose.Location = new System.Drawing.Point(145, 221);
		this.buttonClose.Name = "buttonClose";
		this.buttonClose.Size = new System.Drawing.Size(59, 28);
		this.buttonClose.TabIndex = 139;
		this.buttonClose.Text = "Đóng";
		this.buttonClose.UseVisualStyleBackColor = false;
		this.buttonClose.Click += new System.EventHandler(buttonClose_Click);
		this.groupBoxNguHanh.Controls.Add(this.checkBoxNguHanh);
		this.groupBoxNguHanh.Controls.Add(this.buttonUuTienMacdinh);
		this.groupBoxNguHanh.Controls.Add(this.buttonXuong1);
		this.groupBoxNguHanh.Controls.Add(this.buttonLen1);
		this.groupBoxNguHanh.Controls.Add(this.listView1);
		this.groupBoxNguHanh.Location = new System.Drawing.Point(1, 0);
		this.groupBoxNguHanh.Name = "groupBoxNguHanh";
		this.groupBoxNguHanh.Size = new System.Drawing.Size(210, 164);
		this.groupBoxNguHanh.TabIndex = 140;
		this.groupBoxNguHanh.TabStop = false;
		this.groupBoxNguHanh.Text = "Ngũ hành";
		this.groupBox1.Controls.Add(this.checkBoxMonPhai);
		this.groupBox1.Controls.Add(this.buttonClose);
		this.groupBox1.Controls.Add(this.buttonMacdinhMP);
		this.groupBox1.Controls.Add(this.buttonXuongMP);
		this.groupBox1.Controls.Add(this.buttonLenMP);
		this.groupBox1.Controls.Add(this.listView2);
		this.groupBox1.Location = new System.Drawing.Point(1, 168);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(210, 261);
		this.groupBox1.TabIndex = 141;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Môn phái";
		this.buttonMacdinhMP.BackColor = System.Drawing.SystemColors.Control;
		this.buttonMacdinhMP.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.buttonMacdinhMP.ForeColor = System.Drawing.Color.Black;
		this.buttonMacdinhMP.Location = new System.Drawing.Point(144, 141);
		this.buttonMacdinhMP.Name = "buttonMacdinhMP";
		this.buttonMacdinhMP.Size = new System.Drawing.Size(59, 28);
		this.buttonMacdinhMP.TabIndex = 138;
		this.buttonMacdinhMP.Text = "Mặc định";
		this.buttonMacdinhMP.UseVisualStyleBackColor = false;
		this.buttonMacdinhMP.Click += new System.EventHandler(buttonMacdinhMP_Click);
		this.buttonXuongMP.BackColor = System.Drawing.SystemColors.Control;
		this.buttonXuongMP.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.buttonXuongMP.ForeColor = System.Drawing.Color.Black;
		this.buttonXuongMP.Location = new System.Drawing.Point(144, 90);
		this.buttonXuongMP.Name = "buttonXuongMP";
		this.buttonXuongMP.Size = new System.Drawing.Size(59, 28);
		this.buttonXuongMP.TabIndex = 135;
		this.buttonXuongMP.Text = "Xuống";
		this.buttonXuongMP.UseVisualStyleBackColor = false;
		this.buttonXuongMP.Click += new System.EventHandler(buttonXuongMP_Click);
		this.buttonLenMP.BackColor = System.Drawing.SystemColors.Control;
		this.buttonLenMP.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.buttonLenMP.ForeColor = System.Drawing.Color.Black;
		this.buttonLenMP.Location = new System.Drawing.Point(144, 58);
		this.buttonLenMP.Name = "buttonLenMP";
		this.buttonLenMP.Size = new System.Drawing.Size(59, 28);
		this.buttonLenMP.TabIndex = 134;
		this.buttonLenMP.Text = "Lên";
		this.buttonLenMP.UseVisualStyleBackColor = false;
		this.buttonLenMP.Click += new System.EventHandler(buttonLenMP_Click);
		this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.columnHeader_2, this.columnHeader_3 });
		this.listView2.FullRowSelect = true;
		this.listView2.GridLines = true;
		this.listView2.HideSelection = false;
		this.listView2.Location = new System.Drawing.Point(8, 20);
		this.listView2.MultiSelect = false;
		this.listView2.Name = "listView2";
		this.listView2.Size = new System.Drawing.Size(130, 226);
		this.listView2.TabIndex = 10;
		this.listView2.UseCompatibleStateImageBehavior = false;
		this.listView2.View = System.Windows.Forms.View.Details;
		this.columnHeader_2.Text = "STT";
		this.columnHeader_2.Width = 30;
		this.columnHeader_3.Text = "Môn phái";
		this.columnHeader_3.Width = 80;
		this.checkBoxNguHanh.AutoSize = true;
		this.checkBoxNguHanh.Location = new System.Drawing.Point(144, 15);
		this.checkBoxNguHanh.Name = "checkBoxNguHanh";
		this.checkBoxNguHanh.Size = new System.Drawing.Size(72, 17);
		this.checkBoxNguHanh.TabIndex = 142;
		this.checkBoxNguHanh.Text = "Ngũ hành";
		this.checkBoxNguHanh.UseVisualStyleBackColor = true;
		this.checkBoxNguHanh.CheckedChanged += new System.EventHandler(checkBoxNguHanh_CheckedChanged);
		this.checkBoxMonPhai.AutoSize = true;
		this.checkBoxMonPhai.Location = new System.Drawing.Point(144, 15);
		this.checkBoxMonPhai.Name = "checkBoxMonPhai";
		this.checkBoxMonPhai.Size = new System.Drawing.Size(69, 17);
		this.checkBoxMonPhai.TabIndex = 143;
		this.checkBoxMonPhai.Text = "Môn phái";
		this.checkBoxMonPhai.UseVisualStyleBackColor = true;
		this.checkBoxMonPhai.CheckedChanged += new System.EventHandler(checkBoxMonPhai_CheckedChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.LightSteelBlue;
		base.ClientSize = new System.Drawing.Size(213, 431);
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.groupBoxNguHanh);
		this.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.Name = "FormUutienNguHanh";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "UU TIEN";
		base.TopMost = true;
		base.Load += new System.EventHandler(FormUutienNguHanh_Load);
		this.groupBoxNguHanh.ResumeLayout(false);
		this.groupBoxNguHanh.PerformLayout();
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		base.ResumeLayout(false);
	}

	private void SetWindowTitle(string string_1)
	{
		base.Text = string_1;
	}

	private void listView1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void checkBoxNguHanh_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBoxNguHanh.Checked)
		{
			checkBoxMonPhai.Checked = false;
			SetElementPriorityControlsEnabled(bool_0: true);
			SetFactionPriorityControlsEnabled(bool_0: false);
			ApplyPriorityModeAndSave(0);
		}
		else if (!checkBoxMonPhai.Checked)
		{
			checkBoxMonPhai.Checked = true;
		}
	}

	private void checkBoxMonPhai_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBoxMonPhai.Checked)
		{
			checkBoxNguHanh.Checked = false;
			SetFactionPriorityControlsEnabled(bool_0: true);
			SetElementPriorityControlsEnabled(bool_0: false);
			ApplyPriorityModeAndSave(1);
		}
		else if (!checkBoxNguHanh.Checked)
		{
			checkBoxNguHanh.Checked = true;
		}
	}

	private void SetElementPriorityControlsEnabled(bool bool_0)
	{
		listView1.Enabled = bool_0;
		buttonLen1.Enabled = bool_0;
		buttonXuong1.Enabled = bool_0;
		buttonUuTienMacdinh.Enabled = bool_0;
	}

	private void SetFactionPriorityControlsEnabled(bool bool_0)
	{
		listView2.Enabled = bool_0;
		buttonLenMP.Enabled = bool_0;
		buttonXuongMP.Enabled = bool_0;
		buttonMacdinhMP.Enabled = bool_0;
	}

	private void ApplyPriorityModeAndSave(int int_4)
	{
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, selectedAccountId);
		if (num >= 0)
		{
			Form1.characterAccountConfig_1[num].int_143 = int_4;
			Form1.characterAccountConfig_1[num].bool_11 = true;
			switch (int_4)
			{
			case 0:
				Form1.characterAccountConfig_1[num].int_88 = 1;
				break;
			case 1:
				Form1.characterAccountConfig_1[num].int_88 = 2;
				break;
			}
			UpdateMainFormPriorityModeLabels(int_4);
			GameConfigurationManager.SaveCharacterConfiguration(Form1.characterAccountConfig_1[num]);
		}
	}

	private void UpdateMainFormPriorityModeLabels(int int_4)
	{
		try
		{
			Form1 form = null;
			foreach (Form openForm in Application.OpenForms)
			{
				if (openForm is Form1)
				{
					form = (Form1)openForm;
					break;
				}
			}
			if (form != null && form.comboBoxUuTien != null)
			{
				switch (int_4)
				{
				case 0:
					form.comboBoxUuTien.Text = "Ngũ hành";
					form.buttonUuTien.Text = "Ưu tiên";
					break;
				case 1:
					form.comboBoxUuTien.Text = "Môn phái";
					form.buttonUuTien.Text = "Ưu tiên";
					break;
				}
			}
		}
		catch
		{
		}
	}

	public void method_7(string string_1)
	{
		try
		{
			if (string_1 == "Ngũ hành")
			{
				if (!checkBoxNguHanh.Checked)
				{
					checkBoxNguHanh.Checked = true;
				}
				ApplyPriorityModeAndSave(0);
			}
			else if (string_1 == "Môn phái")
			{
				if (!checkBoxMonPhai.Checked)
				{
					checkBoxMonPhai.Checked = true;
				}
				ApplyPriorityModeAndSave(1);
			}
		}
		catch
		{
		}
	}
}

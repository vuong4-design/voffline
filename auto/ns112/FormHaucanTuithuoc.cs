using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ns1;
using ns100;
using ns11;
using ns16;
using ns53;
using ns63;
using ns81;
using ns83;

namespace ns112;

public class FormHaucanTuithuoc : Form
{
	public static bool isMedicineBagSupportFormOpen = false;

	public static int selectedAccountId = 0;

	public static int loadedAccountId = -1;

	public int ownerWindowLeft;

	public int ownerWindowTop;

	public int ownerWindowWidth;

	public int ownerWindowHeight;

	private int selectedSupportRuleRowIndex = -1;

	private static bool supportRuleControlsReady = false;

	private static CharacterAccountConfig selectedAccountSnapshot = default(CharacterAccountConfig);

	private static string[] selectedAccountInventoryItemNames = null;

	private string[] quantityInputOptionLabels = new string[2] { "không", "có" };

	private static string[] secondaryInventoryItemNames = null;

	private IContainer icontainer_0 = null;

	private CheckBox checkBoxCoNhapSoluong;

	private ComboBox comboBoxTenTuiMauHotro;

	private ListView listView1;

	private ColumnHeader columnHeader_0;

	private Button buttonThem;

	private Button buttonXoa;

	private Button buttonClose;

	private System.Windows.Forms.Timer timer_0;

	private CheckBox checkBoxClickMenu;

	private ColumnHeader columnHeader_1;

	private ColumnHeader columnHeader_2;

	private ColumnHeader columnHeader_3;

	private ColumnHeader columnHeader_4;

	private TextBox textBoxMothuocKhicon;

	private CheckBox checkBoxMoTheoThoigian;

	private CheckBox checkBoxMoTheoSoluong;

	private TextBox textBoxThoigian;

	private Button buttonAppAll;

	private CheckBox checkBoxTrangThai;

	private ColumnHeader columnHeader_5;

	private CheckBox checkBoxTamDung;

	private TextBox textBoxMenu;

	private Label label3;

	private TextBox textBoxSoluongMax;

	private Label label2;

	private CheckBox checkBoxKhongMo;

	private Panel panel1;

	private CheckBox checkBox1;

	private Label label1;

	private Label label4;

	private ComboBox comboBoxTenMau2;

	private Label label5;

	private Label label6;

	public FormHaucanTuithuoc()
	{
		isMedicineBagSupportFormOpen = true;
		InitializeComponent();
		base.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
	}

	protected override void OnFormClosing(FormClosingEventArgs e)
	{
		bool flag = false;
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, selectedAccountId);
		if (0 <= num)
		{
			GameConfigurationManager.SaveCharacterConfiguration(Form1.characterAccountConfig_1[num]);
			flag = true;
		}
		if (!flag && Form1.characterAccountConfig_1 != null)
		{
			for (int i = 0; i < Form1.characterAccountConfig_1.Length; i++)
			{
				GameConfigurationManager.SaveCharacterConfiguration(Form1.characterAccountConfig_1[i]);
			}
		}
		ownerWindowLeft = 0;
		ownerWindowTop = 0;
		loadedAccountId = -1;
		selectedAccountId = 0;
		isMedicineBagSupportFormOpen = false;
	}

	private void FormHaucanTuithuoc_Load(object sender, EventArgs e)
	{
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, selectedAccountId);
		if (num < 0)
		{
			Close();
			return;
		}
		selectedAccountSnapshot = Form1.characterAccountConfig_1[num];
		if (ownerWindowLeft >= 0 && ownerWindowTop >= 0)
		{
			int num2 = ownerWindowLeft - base.Width;
			int num3 = ownerWindowTop + ownerWindowHeight - base.Height;
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
		textBoxSoluongMax.Text = Form1.medicineQuantityPerBagOpen.ToString();
		checkBoxKhongMo.Checked = Form1.skipMedicineBagOpeningEnabled > 0;
		timer_0.Interval = 300;
		timer_0.Enabled = true;
		supportRuleControlsReady = true;
		base.TopMost = true;
	}

	private void PopulateMedicineBagSupportRuleList(MedicineBagSupportRule[] gstruct36_0)
	{
		listView1.Items.Clear();
		selectedSupportRuleRowIndex = -1;
		if (gstruct36_0 != null && gstruct36_0.Length != 0)
		{
			for (int i = 0; i < gstruct36_0.Length; i++)
			{
				AppendMedicineBagSupportRuleListViewRow(listView1, gstruct36_0[i]);
			}
			selectedSupportRuleRowIndex = 0;
			listView1.Items[selectedSupportRuleRowIndex].Focused = true;
			listView1.Items[selectedSupportRuleRowIndex].Selected = true;
		}
	}

	private void LoadMedicineBagSupportRuleIntoControls(MedicineBagSupportRule gstruct36_0)
	{
		supportRuleControlsReady = false;
		comboBoxTenTuiMauHotro.Text = GameTextEncodingHelper.ConvertGameTextToDisplayText(gstruct36_0.medicineBagItemName, 1);
		checkBoxMoTheoThoigian.Checked = gstruct36_0.timeTriggerEnabled > 0;
		textBoxThoigian.Text = gstruct36_0.timeIntervalMilliseconds.ToString();
		checkBoxMoTheoSoluong.Checked = gstruct36_0.quantityTriggerEnabled > 0;
		textBoxMothuocKhicon.Text = gstruct36_0.remainingQuantityThreshold.ToString();
		checkBoxClickMenu.Checked = gstruct36_0.menuClickEnabled > 0;
		checkBox1.Checked = gstruct36_0.useSpecificMedicineNameEnabled > 0;
		comboBoxTenMau2.Text = GameTextEncodingHelper.ConvertGameTextToDisplayText(gstruct36_0.remainingMedicineItemName, 1);
		string text = "1,1";
		if (gstruct36_0.menuSelectionSequence != null)
		{
			text = null;
			for (int i = 0; i < gstruct36_0.menuSelectionSequence.Length; i++)
			{
				if (text != null)
				{
					text += ",";
				}
				text += gstruct36_0.menuSelectionSequence[i];
			}
		}
		textBoxMenu.Text = text;
		checkBoxCoNhapSoluong.Checked = gstruct36_0.quantityInputEnabled > 0;
		checkBoxTrangThai.Checked = gstruct36_0.stateChangeTriggerEnabled > 0;
		checkBoxTamDung.Checked = gstruct36_0.pauseAutomationWhileUsingEnabled > 0;
		checkBoxTamDung.Enabled = gstruct36_0.stateChangeTriggerEnabled > 0;
		Thread.Sleep(100);
		supportRuleControlsReady = true;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (!isMedicineBagSupportFormOpen)
		{
			Close();
		}
		else
		{
			if (loadedAccountId == selectedAccountId)
			{
				return;
			}
			loadedAccountId = selectedAccountId;
			int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, loadedAccountId);
			if (num >= 0)
			{
				buttonThem.Enabled = true;
				listView1.Enabled = true;
				selectedAccountSnapshot = Form1.characterAccountConfig_1[num];
				PopulateMedicineBagSupportRuleList(selectedAccountSnapshot.gstruct36_0);
				selectedSupportRuleRowIndex = -1;
				if (selectedAccountSnapshot.gstruct36_0 != null)
				{
					selectedSupportRuleRowIndex = 0;
					LoadMedicineBagSupportRuleIntoControls(selectedAccountSnapshot.gstruct36_0[0]);
				}
			}
			else
			{
				buttonThem.Enabled = false;
				listView1.Enabled = false;
			}
		}
	}

	private void AppendMedicineBagSupportRuleListViewRow(ListView listView_0, MedicineBagSupportRule gstruct36_0)
	{
		try
		{
			string text = gstruct36_0.remainingQuantityThreshold.ToString();
			if (gstruct36_0.quantityTriggerEnabled > 0)
			{
				text = "* " + text;
			}
			string text2 = gstruct36_0.timeIntervalMilliseconds.ToString();
			if (gstruct36_0.timeTriggerEnabled > 0)
			{
				text2 = "* " + text2;
			}
			string text3 = "không";
			if (gstruct36_0.menuClickEnabled > 0)
			{
				text3 = "có";
			}
			string[] array = new string[6]
			{
				GameTextEncodingHelper.ConvertGameTextToDisplayText(gstruct36_0.medicineBagItemName, 1),
				text,
				text2,
				quantityInputOptionLabels[Convert.ToByte(gstruct36_0.quantityInputEnabled > 0)],
				text3,
				gstruct36_0.stateChangeTriggerEnabled.ToString()
			};
			ListViewItem listViewItem = new ListViewItem(array[0]);
			if (array.Length > 1)
			{
				for (int i = 1; i < array.Length; i++)
				{
					ListViewItem.ListViewSubItem item = new ListViewItem.ListViewSubItem(listViewItem, array[i]);
					listViewItem.SubItems.Add(item);
				}
			}
			listView_0.Items.Add(listViewItem);
		}
		catch
		{
		}
	}

	private void listView1_MouseUp(object sender, MouseEventArgs e)
	{
		selectedSupportRuleRowIndex = -1;
		if (listView1.Items == null || listView1.Items.Count == 0)
		{
			return;
		}
		string text = null;
		for (int i = 0; i < listView1.Items.Count; i++)
		{
			if (listView1.Items[i].Selected)
			{
				selectedSupportRuleRowIndex = i;
				text = listView1.Items[i].SubItems[0].Text;
				break;
			}
		}
		if (selectedSupportRuleRowIndex < 0 || text == null)
		{
			return;
		}
		if (text != comboBoxTenTuiMauHotro.Text)
		{
			comboBoxTenTuiMauHotro.Items.Clear();
			comboBoxTenTuiMauHotro.Items.Add(text);
			comboBoxTenTuiMauHotro.Text = text;
		}
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, loadedAccountId);
		if (num < 0 || Form1.characterAccountConfig_1[num].gstruct36_0 == null)
		{
			return;
		}
		for (int j = 0; j < Form1.characterAccountConfig_1[num].gstruct36_0.Length; j++)
		{
			if (GameTextEncodingHelper.ConvertGameTextToDisplayText(Form1.characterAccountConfig_1[num].gstruct36_0[j].medicineBagItemName, 1) == text)
			{
				LoadMedicineBagSupportRuleIntoControls(Form1.characterAccountConfig_1[num].gstruct36_0[j]);
			}
		}
	}

	private void buttonClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void buttonXoa_Click(object sender, EventArgs e)
	{
		string text = comboBoxTenTuiMauHotro.Text;
		comboBoxTenTuiMauHotro.Items.Clear();
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, loadedAccountId);
		if (num >= 0 && Form1.characterAccountConfig_1[num].gstruct36_0 != null && Form1.characterAccountConfig_1[num].gstruct36_0.Length != 0)
		{
			if (Form1.characterAccountConfig_1[num].gstruct36_0.Length != 1)
			{
				MedicineBagSupportRule[] array = new MedicineBagSupportRule[Form1.characterAccountConfig_1[num].gstruct36_0.Length];
				int num2 = 0;
				for (int i = 0; i < Form1.characterAccountConfig_1[num].gstruct36_0.Length; i++)
				{
					if (!(GameTextEncodingHelper.ConvertGameTextToDisplayText(Form1.characterAccountConfig_1[num].gstruct36_0[i].medicineBagItemName, 1) != text))
					{
						continue;
					}
					array[num2].medicineBagItemName = Form1.characterAccountConfig_1[num].gstruct36_0[i].medicineBagItemName;
					array[num2].quantityTriggerEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[i].quantityTriggerEnabled;
					array[num2].remainingQuantityThreshold = Form1.characterAccountConfig_1[num].gstruct36_0[i].remainingQuantityThreshold;
					array[num2].timeTriggerEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[i].timeTriggerEnabled;
					array[num2].timeIntervalMilliseconds = Form1.characterAccountConfig_1[num].gstruct36_0[i].timeIntervalMilliseconds;
					array[num2].quantityInputEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[i].quantityInputEnabled;
					array[num2].menuClickEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[i].menuClickEnabled;
					if (Form1.characterAccountConfig_1[num].gstruct36_0[i].menuSelectionSequence != null)
					{
						array[num2].menuSelectionSequence = new int[Form1.characterAccountConfig_1[num].gstruct36_0[i].menuSelectionSequence.Length];
						for (int j = 0; j < Form1.characterAccountConfig_1[num].gstruct36_0[i].menuSelectionSequence.Length; j++)
						{
							array[num2].menuSelectionSequence[j] = Form1.characterAccountConfig_1[num].gstruct36_0[i].menuSelectionSequence[j];
						}
					}
					num2++;
				}
				for (int k = 0; k < listView1.Items.Count; k++)
				{
					if (listView1.Items[k].SubItems[0].Text == text)
					{
						listView1.Items.RemoveAt(k);
						break;
					}
				}
				if (num2 != Form1.characterAccountConfig_1[num].gstruct36_0.Length)
				{
					Form1.characterAccountConfig_1[num].gstruct36_0 = new MedicineBagSupportRule[num2];
					for (int l = 0; l < num2; l++)
					{
						Form1.characterAccountConfig_1[num].gstruct36_0[l].medicineBagItemName = array[l].medicineBagItemName;
						Form1.characterAccountConfig_1[num].gstruct36_0[l].quantityTriggerEnabled = array[l].quantityTriggerEnabled;
						Form1.characterAccountConfig_1[num].gstruct36_0[l].remainingQuantityThreshold = array[l].remainingQuantityThreshold;
						Form1.characterAccountConfig_1[num].gstruct36_0[l].timeTriggerEnabled = array[l].timeTriggerEnabled;
						Form1.characterAccountConfig_1[num].gstruct36_0[l].timeIntervalMilliseconds = array[l].timeIntervalMilliseconds;
						Form1.characterAccountConfig_1[num].gstruct36_0[l].quantityInputEnabled = array[l].quantityInputEnabled;
						Form1.characterAccountConfig_1[num].gstruct36_0[l].menuClickEnabled = array[l].menuClickEnabled;
						if (array[l].menuSelectionSequence != null)
						{
							Form1.characterAccountConfig_1[num].gstruct36_0[l].menuSelectionSequence = new int[array[l].menuSelectionSequence.Length];
							for (int m = 0; m < array[l].menuSelectionSequence.Length; m++)
							{
								Form1.characterAccountConfig_1[num].gstruct36_0[l].menuSelectionSequence[m] = array[l].menuSelectionSequence[m];
							}
						}
					}
					if (listView1.Items.Count <= selectedSupportRuleRowIndex)
					{
						selectedSupportRuleRowIndex--;
					}
					if (0 <= selectedSupportRuleRowIndex)
					{
						listView1.Items[selectedSupportRuleRowIndex].Focused = true;
						listView1.Items[selectedSupportRuleRowIndex].Selected = true;
						LoadMedicineBagSupportRuleIntoControls(Form1.characterAccountConfig_1[num].gstruct36_0[selectedSupportRuleRowIndex]);
					}
				}
				else
				{
					selectedSupportRuleRowIndex = 0;
					listView1.Items[selectedSupportRuleRowIndex].Focused = true;
					listView1.Items[selectedSupportRuleRowIndex].Selected = true;
					LoadMedicineBagSupportRuleIntoControls(Form1.characterAccountConfig_1[num].gstruct36_0[selectedSupportRuleRowIndex]);
				}
			}
			else if (GameTextEncodingHelper.ConvertGameTextToDisplayText(Form1.characterAccountConfig_1[num].gstruct36_0[0].medicineBagItemName, 1) == text)
			{
				Form1.characterAccountConfig_1[num].gstruct36_0 = null;
				selectedSupportRuleRowIndex = -1;
				listView1.Items.Clear();
			}
		}
		else
		{
			if (listView1.Items.Count > 0)
			{
				listView1.Items.Clear();
			}
			selectedSupportRuleRowIndex = -1;
		}
	}

	private void comboBoxTenTuiMauHotro_MouseDown(object sender, MouseEventArgs e)
	{
		selectedAccountInventoryItemNames = Class85.CollectInventoryItemNames(selectedAccountSnapshot);
		comboBoxTenTuiMauHotro.Items.Clear();
		if (selectedAccountInventoryItemNames != null)
		{
			Array.Sort(selectedAccountInventoryItemNames);
			for (int i = 0; i < selectedAccountInventoryItemNames.Length; i++)
			{
				comboBoxTenTuiMauHotro.Items.Add(GameTextEncodingHelper.ConvertGameTextToDisplayText(selectedAccountInventoryItemNames[i], 1));
			}
		}
	}

	private void checkBoxMoTheoSoluong_CheckedChanged(object sender, EventArgs e)
	{
		if (!timer_0.Enabled || !supportRuleControlsReady)
		{
			return;
		}
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, loadedAccountId);
		if (num < 0)
		{
			return;
		}
		string text = "0";
		string text2 = comboBoxTenTuiMauHotro.Text;
		if (Form1.characterAccountConfig_1[num].gstruct36_0 != null)
		{
			for (int i = 0; i < Form1.characterAccountConfig_1[num].gstruct36_0.Length; i++)
			{
				if (GameTextEncodingHelper.ConvertGameTextToDisplayText(Form1.characterAccountConfig_1[num].gstruct36_0[i].medicineBagItemName, 1) == text2)
				{
					Form1.characterAccountConfig_1[num].gstruct36_0[i].quantityTriggerEnabled = Convert.ToByte(checkBoxMoTheoSoluong.Checked);
					text = Form1.characterAccountConfig_1[num].gstruct36_0[i].remainingQuantityThreshold.ToString();
					break;
				}
			}
		}
		if (checkBoxMoTheoSoluong.Checked)
		{
			text = "* " + text;
		}
		int num2 = 0;
		while (true)
		{
			if (num2 < listView1.Items.Count)
			{
				if (listView1.Items[num2].SubItems[0].Text == text2)
				{
					break;
				}
				num2++;
				continue;
			}
			return;
		}
		listView1.Items[num2].SubItems[1].Text = text;
	}

	private void textBoxMothuocKhicon_TextChanged(object sender, EventArgs e)
	{
		if (!timer_0.Enabled || !supportRuleControlsReady)
		{
			return;
		}
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, loadedAccountId);
		if (num < 0)
		{
			return;
		}
		string text = "0";
		string text2 = comboBoxTenTuiMauHotro.Text;
		if (Form1.characterAccountConfig_1[num].gstruct36_0 != null)
		{
			for (int i = 0; i < Form1.characterAccountConfig_1[num].gstruct36_0.Length; i++)
			{
				if (GameTextEncodingHelper.ConvertGameTextToDisplayText(Form1.characterAccountConfig_1[num].gstruct36_0[i].medicineBagItemName, 1) == text2)
				{
					Form1.characterAccountConfig_1[num].gstruct36_0[i].remainingQuantityThreshold = CommonUtility.ParseInt32OrZero(textBoxMothuocKhicon.Text);
					text = Form1.characterAccountConfig_1[num].gstruct36_0[i].remainingQuantityThreshold.ToString();
					break;
				}
			}
		}
		if (checkBoxMoTheoSoluong.Checked)
		{
			text = "* " + text;
		}
		int num2 = 0;
		while (true)
		{
			if (num2 < listView1.Items.Count)
			{
				if (listView1.Items[num2].SubItems[0].Text == text2)
				{
					break;
				}
				num2++;
				continue;
			}
			return;
		}
		listView1.Items[num2].SubItems[1].Text = text;
	}

	private void checkBoxMoTheoThoigian_CheckedChanged(object sender, EventArgs e)
	{
		if (!timer_0.Enabled || !supportRuleControlsReady)
		{
			return;
		}
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, loadedAccountId);
		if (num < 0)
		{
			return;
		}
		string text = "0";
		string text2 = comboBoxTenTuiMauHotro.Text;
		if (Form1.characterAccountConfig_1[num].gstruct36_0 != null)
		{
			for (int i = 0; i < Form1.characterAccountConfig_1[num].gstruct36_0.Length; i++)
			{
				if (GameTextEncodingHelper.ConvertGameTextToDisplayText(Form1.characterAccountConfig_1[num].gstruct36_0[i].medicineBagItemName, 1) == text2)
				{
					Form1.characterAccountConfig_1[num].gstruct36_0[i].timeTriggerEnabled = Convert.ToByte(checkBoxMoTheoThoigian.Checked);
					text = Form1.characterAccountConfig_1[num].gstruct36_0[i].timeIntervalMilliseconds.ToString();
					break;
				}
			}
		}
		if (checkBoxMoTheoThoigian.Checked)
		{
			text = "* " + text;
		}
		int num2 = 0;
		while (true)
		{
			if (num2 < listView1.Items.Count)
			{
				if (listView1.Items[num2].SubItems[0].Text == text2)
				{
					break;
				}
				num2++;
				continue;
			}
			return;
		}
		listView1.Items[num2].SubItems[2].Text = text;
	}

	private void textBoxThoigian_TextChanged(object sender, EventArgs e)
	{
		if (!timer_0.Enabled || !supportRuleControlsReady)
		{
			return;
		}
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, loadedAccountId);
		if (num < 0)
		{
			return;
		}
		string text = "0";
		string text2 = comboBoxTenTuiMauHotro.Text;
		if (Form1.characterAccountConfig_1[num].gstruct36_0 != null)
		{
			for (int i = 0; i < Form1.characterAccountConfig_1[num].gstruct36_0.Length; i++)
			{
				if (GameTextEncodingHelper.ConvertGameTextToDisplayText(Form1.characterAccountConfig_1[num].gstruct36_0[i].medicineBagItemName, 1) == text2)
				{
					Form1.characterAccountConfig_1[num].gstruct36_0[i].timeIntervalMilliseconds = CommonUtility.ParseInt32OrZero(textBoxThoigian.Text);
					text = Form1.characterAccountConfig_1[num].gstruct36_0[i].timeIntervalMilliseconds.ToString();
					break;
				}
			}
		}
		if (checkBoxMoTheoThoigian.Checked)
		{
			text = "* " + text;
		}
		int num2 = 0;
		while (true)
		{
			if (num2 < listView1.Items.Count)
			{
				if (listView1.Items[num2].SubItems[0].Text == text2)
				{
					break;
				}
				num2++;
				continue;
			}
			return;
		}
		listView1.Items[num2].SubItems[2].Text = text;
	}

	private void checkBoxClickMenu_CheckedChanged(object sender, EventArgs e)
	{
		if (!timer_0.Enabled || !supportRuleControlsReady)
		{
			return;
		}
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, loadedAccountId);
		if (num < 0)
		{
			return;
		}
		string text = comboBoxTenTuiMauHotro.Text;
		if (Form1.characterAccountConfig_1[num].gstruct36_0 != null)
		{
			for (int i = 0; i < Form1.characterAccountConfig_1[num].gstruct36_0.Length; i++)
			{
				if (GameTextEncodingHelper.ConvertGameTextToDisplayText(Form1.characterAccountConfig_1[num].gstruct36_0[i].medicineBagItemName, 1) == text)
				{
					Form1.characterAccountConfig_1[num].gstruct36_0[i].menuClickEnabled = Convert.ToByte(checkBoxClickMenu.Checked);
					break;
				}
			}
		}
		string text2 = "không";
		if (checkBoxClickMenu.Checked)
		{
			text2 = "có";
		}
		for (int i = 0; i < listView1.Items.Count; i++)
		{
			if (listView1.Items[i].SubItems[0].Text == text)
			{
				listView1.Items[i].SubItems[4].Text = text2;
				break;
			}
		}
	}

	private void checkBoxCoNhapSoluong_CheckedChanged(object sender, EventArgs e)
	{
		if (!timer_0.Enabled || !supportRuleControlsReady)
		{
			return;
		}
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, loadedAccountId);
		if (num < 0)
		{
			return;
		}
		string text = comboBoxTenTuiMauHotro.Text;
		if (Form1.characterAccountConfig_1[num].gstruct36_0 != null)
		{
			for (int i = 0; i < Form1.characterAccountConfig_1[num].gstruct36_0.Length; i++)
			{
				if (GameTextEncodingHelper.ConvertGameTextToDisplayText(Form1.characterAccountConfig_1[num].gstruct36_0[i].medicineBagItemName, 1) == text)
				{
					Form1.characterAccountConfig_1[num].gstruct36_0[i].quantityInputEnabled = Convert.ToByte(checkBoxCoNhapSoluong.Checked);
					break;
				}
			}
		}
		string text2 = quantityInputOptionLabels[Convert.ToByte(checkBoxCoNhapSoluong.Checked)];
		for (int i = 0; i < listView1.Items.Count; i++)
		{
			if (listView1.Items[i].SubItems[0].Text == text)
			{
				listView1.Items[i].SubItems[3].Text = text2;
				break;
			}
		}
	}

	private void buttonThem_Click(object sender, EventArgs e)
	{
		if (!timer_0.Enabled || !supportRuleControlsReady || selectedAccountInventoryItemNames == null)
		{
			return;
		}
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, loadedAccountId);
		if (num < 0)
		{
			return;
		}
		MedicineBagSupportRule gstruct36_ = default(MedicineBagSupportRule);
		string text = comboBoxTenTuiMauHotro.Text;
		int num2 = Convert.ToByte(checkBox1.Checked);
		string text2 = string.Empty;
		if (num2 > 0 && secondaryInventoryItemNames != null)
		{
			string text3 = comboBoxTenMau2.Text;
			for (int i = 0; i < secondaryInventoryItemNames.Length; i++)
			{
				if (text3 == GameTextEncodingHelper.ConvertGameTextToDisplayText(secondaryInventoryItemNames[i], 1))
				{
					text2 = secondaryInventoryItemNames[i];
					break;
				}
			}
		}
		if (Form1.characterAccountConfig_1[num].gstruct36_0 != null)
		{
			for (int j = 0; j < Form1.characterAccountConfig_1[num].gstruct36_0.Length; j++)
			{
				if (GameTextEncodingHelper.ConvertGameTextToDisplayText(Form1.characterAccountConfig_1[num].gstruct36_0[j].medicineBagItemName, 1) == text)
				{
					string text4 = string.Empty;
					if (secondaryInventoryItemNames != null && secondaryInventoryItemNames.Length > j && secondaryInventoryItemNames[j] != null)
					{
						text4 = secondaryInventoryItemNames[j];
					}
					Form1.characterAccountConfig_1[num].gstruct36_0[j].remainingMedicineItemName = text4;
				}
			}
		}
		for (int k = 0; k < selectedAccountInventoryItemNames.Length; k++)
		{
			if (GameTextEncodingHelper.ConvertGameTextToDisplayText(selectedAccountInventoryItemNames[k], 1) == text)
			{
				gstruct36_.medicineBagItemName = selectedAccountInventoryItemNames[k];
				gstruct36_.quantityTriggerEnabled = Convert.ToByte(checkBoxMoTheoSoluong.Checked);
				gstruct36_.remainingQuantityThreshold = CommonUtility.ParseInt32OrZero(textBoxMothuocKhicon.Text);
				gstruct36_.timeTriggerEnabled = Convert.ToByte(checkBoxMoTheoThoigian.Checked);
				gstruct36_.timeIntervalMilliseconds = CommonUtility.ParseInt32OrZero(textBoxThoigian.Text);
				gstruct36_.quantityInputEnabled = Convert.ToByte(checkBoxCoNhapSoluong.Checked);
				gstruct36_.menuClickEnabled = Convert.ToByte(checkBoxClickMenu.Checked);
				gstruct36_.menuSelectionSequence = Form1.ParseDelimitedIntegerList(textBoxMenu.Text);
				gstruct36_.stateChangeTriggerEnabled = Convert.ToByte(checkBoxTrangThai.Checked);
				gstruct36_.pauseAutomationWhileUsingEnabled = Convert.ToByte(checkBoxTamDung.Checked);
				gstruct36_.useSpecificMedicineNameEnabled = Convert.ToByte(checkBox1.Checked);
				gstruct36_.remainingMedicineItemName = text2;
				break;
			}
		}
		if (gstruct36_.menuSelectionSequence == null)
		{
			gstruct36_.menuSelectionSequence = new int[2] { 1, 1 };
		}
		if (Form1.characterAccountConfig_1[num].gstruct36_0 != null && Form1.characterAccountConfig_1[num].gstruct36_0.Length != 0)
		{
			MedicineBagSupportRule[] array = new MedicineBagSupportRule[Form1.characterAccountConfig_1[num].gstruct36_0.Length + 1];
			for (int l = 0; l < Form1.characterAccountConfig_1[num].gstruct36_0.Length; l++)
			{
				if (!(gstruct36_.medicineBagItemName == Form1.characterAccountConfig_1[num].gstruct36_0[l].medicineBagItemName))
				{
					array[l].medicineBagItemName = Form1.characterAccountConfig_1[num].gstruct36_0[l].medicineBagItemName;
					array[l].quantityTriggerEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[l].quantityTriggerEnabled;
					array[l].remainingQuantityThreshold = Form1.characterAccountConfig_1[num].gstruct36_0[l].remainingQuantityThreshold;
					array[l].timeTriggerEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[l].timeTriggerEnabled;
					array[l].timeIntervalMilliseconds = Form1.characterAccountConfig_1[num].gstruct36_0[l].timeIntervalMilliseconds;
					array[l].quantityInputEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[l].quantityInputEnabled;
					array[l].menuClickEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[l].menuClickEnabled;
					if (Form1.characterAccountConfig_1[num].gstruct36_0[l].menuSelectionSequence == null)
					{
						Form1.characterAccountConfig_1[num].gstruct36_0[l].menuSelectionSequence = new int[2] { 1, 1 };
					}
					array[l].menuSelectionSequence = new int[Form1.characterAccountConfig_1[num].gstruct36_0[l].menuSelectionSequence.Length];
					for (int m = 0; m < array[l].menuSelectionSequence.Length; m++)
					{
						array[l].menuSelectionSequence[m] = Form1.characterAccountConfig_1[num].gstruct36_0[l].menuSelectionSequence[m];
					}
					array[l].stateChangeTriggerEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[l].stateChangeTriggerEnabled;
					array[l].pauseAutomationWhileUsingEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[l].pauseAutomationWhileUsingEnabled;
					array[l].useSpecificMedicineNameEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[0].useSpecificMedicineNameEnabled;
					array[l].remainingMedicineItemName = Form1.characterAccountConfig_1[num].gstruct36_0[0].remainingMedicineItemName;
					continue;
				}
				return;
			}
			int num3 = array.Length - 1;
			array[num3].medicineBagItemName = gstruct36_.medicineBagItemName;
			array[num3].quantityTriggerEnabled = gstruct36_.quantityTriggerEnabled;
			array[num3].remainingQuantityThreshold = gstruct36_.remainingQuantityThreshold;
			array[num3].timeTriggerEnabled = gstruct36_.timeTriggerEnabled;
			array[num3].timeIntervalMilliseconds = gstruct36_.timeIntervalMilliseconds;
			array[num3].quantityInputEnabled = gstruct36_.quantityInputEnabled;
			array[num3].menuClickEnabled = gstruct36_.menuClickEnabled;
			if (gstruct36_.menuSelectionSequence == null)
			{
				gstruct36_.menuSelectionSequence = new int[2] { 1, 1 };
			}
			array[num3].menuSelectionSequence = new int[gstruct36_.menuSelectionSequence.Length];
			for (int n = 0; n < gstruct36_.menuSelectionSequence.Length; n++)
			{
				array[num3].menuSelectionSequence[n] = gstruct36_.menuSelectionSequence[n];
			}
			array[num3].stateChangeTriggerEnabled = gstruct36_.stateChangeTriggerEnabled;
			array[num3].pauseAutomationWhileUsingEnabled = gstruct36_.pauseAutomationWhileUsingEnabled;
			array[num3].useSpecificMedicineNameEnabled = gstruct36_.useSpecificMedicineNameEnabled;
			array[num3].remainingMedicineItemName = gstruct36_.remainingMedicineItemName;
			Form1.characterAccountConfig_1[num].gstruct36_0 = new MedicineBagSupportRule[array.Length];
			for (int num4 = 0; num4 < Form1.characterAccountConfig_1[num].gstruct36_0.Length; num4++)
			{
				Form1.characterAccountConfig_1[num].gstruct36_0[num4].medicineBagItemName = array[num4].medicineBagItemName;
				Form1.characterAccountConfig_1[num].gstruct36_0[num4].quantityTriggerEnabled = array[num4].quantityTriggerEnabled;
				Form1.characterAccountConfig_1[num].gstruct36_0[num4].remainingQuantityThreshold = array[num4].remainingQuantityThreshold;
				Form1.characterAccountConfig_1[num].gstruct36_0[num4].timeTriggerEnabled = array[num4].timeTriggerEnabled;
				Form1.characterAccountConfig_1[num].gstruct36_0[num4].timeIntervalMilliseconds = array[num4].timeIntervalMilliseconds;
				Form1.characterAccountConfig_1[num].gstruct36_0[num4].quantityInputEnabled = array[num4].quantityInputEnabled;
				Form1.characterAccountConfig_1[num].gstruct36_0[num4].menuClickEnabled = array[num4].menuClickEnabled;
				Form1.characterAccountConfig_1[num].gstruct36_0[num4].menuSelectionSequence = new int[array[num4].menuSelectionSequence.Length];
				for (int num5 = 0; num5 < gstruct36_.menuSelectionSequence.Length; num5++)
				{
					Form1.characterAccountConfig_1[num].gstruct36_0[num4].menuSelectionSequence[num5] = array[num4].menuSelectionSequence[num5];
				}
				Form1.characterAccountConfig_1[num].gstruct36_0[num4].stateChangeTriggerEnabled = array[num4].stateChangeTriggerEnabled;
				Form1.characterAccountConfig_1[num].gstruct36_0[num4].pauseAutomationWhileUsingEnabled = array[num4].pauseAutomationWhileUsingEnabled;
				Form1.characterAccountConfig_1[num].gstruct36_0[num4].useSpecificMedicineNameEnabled = array[num4].useSpecificMedicineNameEnabled;
				Form1.characterAccountConfig_1[num].gstruct36_0[num4].remainingMedicineItemName = array[num4].remainingMedicineItemName;
			}
		}
		else
		{
			Form1.characterAccountConfig_1[num].gstruct36_0 = new MedicineBagSupportRule[1];
			Form1.characterAccountConfig_1[num].gstruct36_0[0].medicineBagItemName = gstruct36_.medicineBagItemName;
			Form1.characterAccountConfig_1[num].gstruct36_0[0].quantityTriggerEnabled = gstruct36_.quantityTriggerEnabled;
			Form1.characterAccountConfig_1[num].gstruct36_0[0].remainingQuantityThreshold = gstruct36_.remainingQuantityThreshold;
			Form1.characterAccountConfig_1[num].gstruct36_0[0].timeTriggerEnabled = gstruct36_.timeTriggerEnabled;
			Form1.characterAccountConfig_1[num].gstruct36_0[0].timeIntervalMilliseconds = gstruct36_.timeIntervalMilliseconds;
			Form1.characterAccountConfig_1[num].gstruct36_0[0].quantityInputEnabled = gstruct36_.quantityInputEnabled;
			Form1.characterAccountConfig_1[num].gstruct36_0[0].menuClickEnabled = gstruct36_.menuClickEnabled;
			Form1.characterAccountConfig_1[num].gstruct36_0[0].menuSelectionSequence = new int[gstruct36_.menuSelectionSequence.Length];
			for (int num6 = 0; num6 < gstruct36_.menuSelectionSequence.Length; num6++)
			{
				Form1.characterAccountConfig_1[num].gstruct36_0[0].menuSelectionSequence[num6] = gstruct36_.menuSelectionSequence[num6];
			}
			Form1.characterAccountConfig_1[num].gstruct36_0[0].stateChangeTriggerEnabled = gstruct36_.stateChangeTriggerEnabled;
			Form1.characterAccountConfig_1[num].gstruct36_0[0].pauseAutomationWhileUsingEnabled = gstruct36_.pauseAutomationWhileUsingEnabled;
			Form1.characterAccountConfig_1[num].gstruct36_0[0].useSpecificMedicineNameEnabled = gstruct36_.useSpecificMedicineNameEnabled;
			Form1.characterAccountConfig_1[num].gstruct36_0[0].remainingMedicineItemName = gstruct36_.remainingMedicineItemName;
			listView1.Items.Clear();
			selectedSupportRuleRowIndex = 0;
		}
		AppendMedicineBagSupportRuleListViewRow(listView1, gstruct36_);
		if (0 <= selectedSupportRuleRowIndex && selectedSupportRuleRowIndex < listView1.Items.Count)
		{
			listView1.Items[selectedSupportRuleRowIndex].Focused = true;
			listView1.Items[selectedSupportRuleRowIndex].Selected = true;
		}
	}

	private void buttonAppAll_Click(object sender, EventArgs e)
	{
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, loadedAccountId);
		if (num < 0 || Form1.characterAccountConfig_1 == null)
		{
			return;
		}
		for (int i = 0; i < Form1.characterAccountConfig_1.Length; i++)
		{
			if (i == num)
			{
				continue;
			}
			Form1.characterAccountConfig_1[i].gstruct36_0 = null;
			if (Form1.characterAccountConfig_1[num].gstruct36_0 == null || Form1.characterAccountConfig_1[num].gstruct36_0.Length == 0)
			{
				continue;
			}
			Form1.characterAccountConfig_1[i].gstruct36_0 = new MedicineBagSupportRule[Form1.characterAccountConfig_1[num].gstruct36_0.Length];
			for (int j = 0; j < Form1.characterAccountConfig_1[num].gstruct36_0.Length; j++)
			{
				Form1.characterAccountConfig_1[i].gstruct36_0[j].medicineBagItemName = Form1.characterAccountConfig_1[num].gstruct36_0[j].medicineBagItemName;
				Form1.characterAccountConfig_1[i].gstruct36_0[j].quantityTriggerEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[j].quantityTriggerEnabled;
				Form1.characterAccountConfig_1[i].gstruct36_0[j].remainingQuantityThreshold = Form1.characterAccountConfig_1[num].gstruct36_0[j].remainingQuantityThreshold;
				Form1.characterAccountConfig_1[i].gstruct36_0[j].timeTriggerEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[j].timeTriggerEnabled;
				Form1.characterAccountConfig_1[i].gstruct36_0[j].timeIntervalMilliseconds = Form1.characterAccountConfig_1[num].gstruct36_0[j].timeIntervalMilliseconds;
				Form1.characterAccountConfig_1[i].gstruct36_0[j].menuClickEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[j].menuClickEnabled;
				if (Form1.characterAccountConfig_1[num].gstruct36_0[j].menuSelectionSequence == null)
				{
					Form1.characterAccountConfig_1[num].gstruct36_0[j].menuSelectionSequence = new int[2] { 1, 1 };
				}
				Form1.characterAccountConfig_1[i].gstruct36_0[j].menuSelectionSequence = new int[Form1.characterAccountConfig_1[num].gstruct36_0[j].menuSelectionSequence.Length];
				for (int k = 0; k < Form1.characterAccountConfig_1[num].gstruct36_0[j].menuSelectionSequence.Length; k++)
				{
					Form1.characterAccountConfig_1[i].gstruct36_0[j].menuSelectionSequence[k] = Form1.characterAccountConfig_1[num].gstruct36_0[j].menuSelectionSequence[k];
				}
				Form1.characterAccountConfig_1[i].gstruct36_0[j].quantityInputEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[j].quantityInputEnabled;
				Form1.characterAccountConfig_1[i].gstruct36_0[j].stateChangeTriggerEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[j].stateChangeTriggerEnabled;
				Form1.characterAccountConfig_1[i].gstruct36_0[j].pauseAutomationWhileUsingEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[j].pauseAutomationWhileUsingEnabled;
				Form1.characterAccountConfig_1[i].gstruct36_0[j].useSpecificMedicineNameEnabled = Form1.characterAccountConfig_1[num].gstruct36_0[j].useSpecificMedicineNameEnabled;
				Form1.characterAccountConfig_1[i].gstruct36_0[j].remainingMedicineItemName = Form1.characterAccountConfig_1[num].gstruct36_0[j].remainingMedicineItemName;
				GameConfigurationManager.SaveCharacterConfiguration(Form1.characterAccountConfig_1[i]);
			}
		}
	}

	private void checkBoxTrangThai_CheckedChanged(object sender, EventArgs e)
	{
		if (!timer_0.Enabled || !supportRuleControlsReady)
		{
			return;
		}
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, loadedAccountId);
		if (num < 0)
		{
			return;
		}
		string text = "0";
		string text2 = comboBoxTenTuiMauHotro.Text;
		int num2 = Convert.ToByte(checkBoxTrangThai.Checked);
		if (Form1.characterAccountConfig_1[num].gstruct36_0 != null)
		{
			for (int i = 0; i < Form1.characterAccountConfig_1[num].gstruct36_0.Length; i++)
			{
				if (GameTextEncodingHelper.ConvertGameTextToDisplayText(Form1.characterAccountConfig_1[num].gstruct36_0[i].medicineBagItemName, 1) == text2)
				{
					Form1.characterAccountConfig_1[num].gstruct36_0[i].stateChangeTriggerEnabled = num2;
					text = num2.ToString();
					break;
				}
			}
		}
		for (int j = 0; j < listView1.Items.Count; j++)
		{
			if (listView1.Items[j].SubItems[0].Text == text2)
			{
				listView1.Items[j].SubItems[5].Text = text;
				break;
			}
		}
		checkBoxTamDung.Enabled = num2 > 0;
	}

	private void checkBoxTamDung_CheckedChanged(object sender, EventArgs e)
	{
		if (!timer_0.Enabled || !supportRuleControlsReady)
		{
			return;
		}
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, loadedAccountId);
		if (num < 0)
		{
			return;
		}
		string text = comboBoxTenTuiMauHotro.Text;
		if (Form1.characterAccountConfig_1[num].gstruct36_0 == null)
		{
			return;
		}
		int num2 = 0;
		while (true)
		{
			if (num2 < Form1.characterAccountConfig_1[num].gstruct36_0.Length)
			{
				if (GameTextEncodingHelper.ConvertGameTextToDisplayText(Form1.characterAccountConfig_1[num].gstruct36_0[num2].medicineBagItemName, 1) == text)
				{
					break;
				}
				num2++;
				continue;
			}
			return;
		}
		Form1.characterAccountConfig_1[num].gstruct36_0[num2].pauseAutomationWhileUsingEnabled = Convert.ToByte(checkBoxTamDung.Checked);
	}

	private void textBoxMenu_TextChanged(object sender, EventArgs e)
	{
		if (!timer_0.Enabled || !supportRuleControlsReady)
		{
			return;
		}
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, loadedAccountId);
		if (num < 0)
		{
			return;
		}
		string text = comboBoxTenTuiMauHotro.Text;
		if (Form1.characterAccountConfig_1[num].gstruct36_0 != null)
		{
			for (int i = 0; i < Form1.characterAccountConfig_1[num].gstruct36_0.Length; i++)
			{
				if (GameTextEncodingHelper.ConvertGameTextToDisplayText(Form1.characterAccountConfig_1[num].gstruct36_0[i].medicineBagItemName, 1) == text)
				{
					Form1.characterAccountConfig_1[num].gstruct36_0[i].menuSelectionSequence = Form1.ParseDelimitedIntegerList(textBoxMenu.Text);
					break;
				}
			}
		}
		string text2 = "không";
		if (checkBoxClickMenu.Checked)
		{
			text2 = "có";
		}
		int num2 = 0;
		while (true)
		{
			if (num2 < listView1.Items.Count)
			{
				if (listView1.Items[num2].SubItems[0].Text == text)
				{
					break;
				}
				num2++;
				continue;
			}
			return;
		}
		listView1.Items[num2].SubItems[4].Text = text2;
	}

	private void textBoxSoluongMax_TextChanged(object sender, EventArgs e)
	{
		if (timer_0.Enabled && supportRuleControlsReady)
		{
			Form1.medicineQuantityPerBagOpen = CommonUtility.ParseInt32OrZero(textBoxSoluongMax.Text);
			WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), "SoluongThuocMoilanMo", Form1.medicineQuantityPerBagOpen, "", 0);
		}
	}

	private void checkBoxKhongMo_CheckedChanged(object sender, EventArgs e)
	{
		if (timer_0.Enabled && supportRuleControlsReady)
		{
			Form1.skipMedicineBagOpeningEnabled = Convert.ToByte(checkBoxKhongMo.Checked);
			WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), "PCDKhongMoTui", Form1.skipMedicineBagOpeningEnabled, "", 0);
		}
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (!timer_0.Enabled || !supportRuleControlsReady)
		{
			return;
		}
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, loadedAccountId);
		if (num < 0)
		{
			return;
		}
		string text = comboBoxTenTuiMauHotro.Text;
		if (Form1.characterAccountConfig_1[num].gstruct36_0 == null)
		{
			return;
		}
		for (int i = 0; i < Form1.characterAccountConfig_1[num].gstruct36_0.Length; i++)
		{
			if (GameTextEncodingHelper.ConvertGameTextToDisplayText(Form1.characterAccountConfig_1[num].gstruct36_0[i].medicineBagItemName, 1) == text)
			{
				Form1.characterAccountConfig_1[num].gstruct36_0[i].useSpecificMedicineNameEnabled = Convert.ToByte(checkBox1.Checked);
			}
		}
	}

	private void comboBoxTenMau2_MouseDown(object sender, MouseEventArgs e)
	{
		if (!timer_0.Enabled || !supportRuleControlsReady)
		{
			return;
		}
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, loadedAccountId);
		if (num < 0)
		{
			return;
		}
		supportRuleControlsReady = false;
		secondaryInventoryItemNames = Class85.CollectInventoryItemNames(Form1.characterAccountConfig_1[num]);
		comboBoxTenMau2.Items.Clear();
		if (secondaryInventoryItemNames != null)
		{
			Array.Sort(secondaryInventoryItemNames);
			for (int i = 0; i < secondaryInventoryItemNames.Length; i++)
			{
				comboBoxTenMau2.Items.Add(GameTextEncodingHelper.ConvertGameTextToDisplayText(secondaryInventoryItemNames[i], 1));
			}
		}
		Thread.Sleep(10);
		supportRuleControlsReady = true;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ns112.FormHaucanTuithuoc));
		this.checkBoxCoNhapSoluong = new System.Windows.Forms.CheckBox();
		this.comboBoxTenTuiMauHotro = new System.Windows.Forms.ComboBox();
		this.listView1 = new System.Windows.Forms.ListView();
		this.columnHeader_0 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_1 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_2 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_3 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_4 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_5 = new System.Windows.Forms.ColumnHeader();
		this.buttonThem = new System.Windows.Forms.Button();
		this.buttonXoa = new System.Windows.Forms.Button();
		this.buttonClose = new System.Windows.Forms.Button();
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.checkBoxClickMenu = new System.Windows.Forms.CheckBox();
		this.textBoxMothuocKhicon = new System.Windows.Forms.TextBox();
		this.checkBoxMoTheoThoigian = new System.Windows.Forms.CheckBox();
		this.checkBoxMoTheoSoluong = new System.Windows.Forms.CheckBox();
		this.textBoxThoigian = new System.Windows.Forms.TextBox();
		this.buttonAppAll = new System.Windows.Forms.Button();
		this.checkBoxTrangThai = new System.Windows.Forms.CheckBox();
		this.checkBoxTamDung = new System.Windows.Forms.CheckBox();
		this.textBoxMenu = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.textBoxSoluongMax = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.checkBoxKhongMo = new System.Windows.Forms.CheckBox();
		this.panel1 = new System.Windows.Forms.Panel();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.comboBoxTenMau2 = new System.Windows.Forms.ComboBox();
		this.label5 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.checkBoxCoNhapSoluong.AutoSize = true;
		this.checkBoxCoNhapSoluong.BackColor = System.Drawing.SystemColors.Control;
		this.checkBoxCoNhapSoluong.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
		this.checkBoxCoNhapSoluong.ForeColor = System.Drawing.Color.DarkGreen;
		this.checkBoxCoNhapSoluong.Location = new System.Drawing.Point(11, 168);
		this.checkBoxCoNhapSoluong.Name = "checkBoxCoNhapSoluong";
		this.checkBoxCoNhapSoluong.Size = new System.Drawing.Size(343, 17);
		this.checkBoxCoNhapSoluong.TabIndex = 210;
		this.checkBoxCoNhapSoluong.Text = "Có nhập số lượng khi mở túi thuốc (không có nhập thì đừng check)";
		this.checkBoxCoNhapSoluong.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		this.checkBoxCoNhapSoluong.UseVisualStyleBackColor = false;
		this.checkBoxCoNhapSoluong.CheckedChanged += new System.EventHandler(checkBoxCoNhapSoluong_CheckedChanged);
		this.comboBoxTenTuiMauHotro.FormattingEnabled = true;
		this.comboBoxTenTuiMauHotro.Location = new System.Drawing.Point(11, 139);
		this.comboBoxTenTuiMauHotro.Name = "comboBoxTenTuiMauHotro";
		this.comboBoxTenTuiMauHotro.Size = new System.Drawing.Size(229, 21);
		this.comboBoxTenTuiMauHotro.TabIndex = 217;
		this.comboBoxTenTuiMauHotro.MouseDown += new System.Windows.Forms.MouseEventHandler(comboBoxTenTuiMauHotro_MouseDown);
		this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[6] { this.columnHeader_0, this.columnHeader_1, this.columnHeader_2, this.columnHeader_3, this.columnHeader_4, this.columnHeader_5 });
		this.listView1.FullRowSelect = true;
		this.listView1.GridLines = true;
		this.listView1.HideSelection = false;
		this.listView1.Location = new System.Drawing.Point(11, 26);
		this.listView1.Name = "listView1";
		this.listView1.Size = new System.Drawing.Size(453, 108);
		this.listView1.TabIndex = 218;
		this.listView1.UseCompatibleStateImageBehavior = false;
		this.listView1.View = System.Windows.Forms.View.Details;
		this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(listView1_MouseUp);
		this.columnHeader_0.Text = "Tên túi máu, vật phẩm";
		this.columnHeader_0.Width = 130;
		this.columnHeader_1.Text = "Theo SL";
		this.columnHeader_1.Width = 65;
		this.columnHeader_2.Text = "Theo time";
		this.columnHeader_2.Width = 65;
		this.columnHeader_3.Text = "Box nhập";
		this.columnHeader_3.Width = 65;
		this.columnHeader_4.Text = "Click menu";
		this.columnHeader_4.Width = 65;
		this.columnHeader_5.Text = "TT";
		this.columnHeader_5.Width = 40;
		this.buttonThem.ForeColor = System.Drawing.Color.DarkBlue;
		this.buttonThem.Location = new System.Drawing.Point(246, 139);
		this.buttonThem.Name = "buttonThem";
		this.buttonThem.Size = new System.Drawing.Size(148, 23);
		this.buttonThem.TabIndex = 219;
		this.buttonThem.Text = "Thêm vào danh sách";
		this.buttonThem.UseVisualStyleBackColor = true;
		this.buttonThem.Click += new System.EventHandler(buttonThem_Click);
		this.buttonXoa.Location = new System.Drawing.Point(400, 139);
		this.buttonXoa.Name = "buttonXoa";
		this.buttonXoa.Size = new System.Drawing.Size(64, 23);
		this.buttonXoa.TabIndex = 220;
		this.buttonXoa.Text = "Xóa";
		this.buttonXoa.UseVisualStyleBackColor = true;
		this.buttonXoa.Click += new System.EventHandler(buttonXoa_Click);
		this.buttonClose.Location = new System.Drawing.Point(368, 363);
		this.buttonClose.Name = "buttonClose";
		this.buttonClose.Size = new System.Drawing.Size(96, 27);
		this.buttonClose.TabIndex = 222;
		this.buttonClose.Text = "Đóng";
		this.buttonClose.UseVisualStyleBackColor = true;
		this.buttonClose.Click += new System.EventHandler(buttonClose_Click);
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		this.checkBoxClickMenu.AutoSize = true;
		this.checkBoxClickMenu.BackColor = System.Drawing.SystemColors.Control;
		this.checkBoxClickMenu.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
		this.checkBoxClickMenu.ForeColor = System.Drawing.Color.Black;
		this.checkBoxClickMenu.Location = new System.Drawing.Point(11, 353);
		this.checkBoxClickMenu.Name = "checkBoxClickMenu";
		this.checkBoxClickMenu.Size = new System.Drawing.Size(268, 17);
		this.checkBoxClickMenu.TabIndex = 223;
		this.checkBoxClickMenu.Text = "Có menu và cần click vào các dòng...(ví dụ: 4,2,1)";
		this.checkBoxClickMenu.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		this.checkBoxClickMenu.UseVisualStyleBackColor = false;
		this.checkBoxClickMenu.CheckedChanged += new System.EventHandler(checkBoxClickMenu_CheckedChanged);
		this.textBoxMothuocKhicon.ForeColor = System.Drawing.Color.Black;
		this.textBoxMothuocKhicon.Location = new System.Drawing.Point(259, 195);
		this.textBoxMothuocKhicon.Name = "textBoxMothuocKhicon";
		this.textBoxMothuocKhicon.Size = new System.Drawing.Size(48, 20);
		this.textBoxMothuocKhicon.TabIndex = 226;
		this.textBoxMothuocKhicon.TextChanged += new System.EventHandler(textBoxMothuocKhicon_TextChanged);
		this.checkBoxMoTheoThoigian.AutoSize = true;
		this.checkBoxMoTheoThoigian.BackColor = System.Drawing.SystemColors.Control;
		this.checkBoxMoTheoThoigian.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
		this.checkBoxMoTheoThoigian.ForeColor = System.Drawing.Color.Black;
		this.checkBoxMoTheoThoigian.Location = new System.Drawing.Point(11, 281);
		this.checkBoxMoTheoThoigian.Name = "checkBoxMoTheoThoigian";
		this.checkBoxMoTheoThoigian.Size = new System.Drawing.Size(238, 17);
		this.checkBoxMoTheoThoigian.TabIndex = 227;
		this.checkBoxMoTheoThoigian.Text = "Sử dụng theo thời gian (ms) (1giây = 1000ms)";
		this.checkBoxMoTheoThoigian.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		this.checkBoxMoTheoThoigian.UseVisualStyleBackColor = false;
		this.checkBoxMoTheoThoigian.CheckedChanged += new System.EventHandler(checkBoxMoTheoThoigian_CheckedChanged);
		this.checkBoxMoTheoSoluong.AutoSize = true;
		this.checkBoxMoTheoSoluong.BackColor = System.Drawing.SystemColors.Control;
		this.checkBoxMoTheoSoluong.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
		this.checkBoxMoTheoSoluong.ForeColor = System.Drawing.Color.Black;
		this.checkBoxMoTheoSoluong.Location = new System.Drawing.Point(11, 196);
		this.checkBoxMoTheoSoluong.Name = "checkBoxMoTheoSoluong";
		this.checkBoxMoTheoSoluong.Size = new System.Drawing.Size(244, 17);
		this.checkBoxMoTheoSoluong.TabIndex = 228;
		this.checkBoxMoTheoSoluong.Text = "Sử dụng khi số lượng thuốc phục hồi máu còn";
		this.checkBoxMoTheoSoluong.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		this.checkBoxMoTheoSoluong.UseVisualStyleBackColor = false;
		this.checkBoxMoTheoSoluong.CheckedChanged += new System.EventHandler(checkBoxMoTheoSoluong_CheckedChanged);
		this.textBoxThoigian.ForeColor = System.Drawing.Color.Black;
		this.textBoxThoigian.Location = new System.Drawing.Point(285, 279);
		this.textBoxThoigian.Name = "textBoxThoigian";
		this.textBoxThoigian.Size = new System.Drawing.Size(73, 20);
		this.textBoxThoigian.TabIndex = 229;
		this.textBoxThoigian.TextChanged += new System.EventHandler(textBoxThoigian_TextChanged);
		this.buttonAppAll.ForeColor = System.Drawing.Color.DarkRed;
		this.buttonAppAll.Location = new System.Drawing.Point(368, 315);
		this.buttonAppAll.Name = "buttonAppAll";
		this.buttonAppAll.Size = new System.Drawing.Size(96, 42);
		this.buttonAppAll.TabIndex = 231;
		this.buttonAppAll.Text = "Áp dụng cho tất cả ac";
		this.buttonAppAll.UseVisualStyleBackColor = true;
		this.buttonAppAll.Click += new System.EventHandler(buttonAppAll_Click);
		this.checkBoxTrangThai.AutoSize = true;
		this.checkBoxTrangThai.BackColor = System.Drawing.SystemColors.Control;
		this.checkBoxTrangThai.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
		this.checkBoxTrangThai.ForeColor = System.Drawing.Color.Black;
		this.checkBoxTrangThai.Location = new System.Drawing.Point(11, 307);
		this.checkBoxTrangThai.Name = "checkBoxTrangThai";
		this.checkBoxTrangThai.Size = new System.Drawing.Size(327, 17);
		this.checkBoxTrangThai.TabIndex = 234;
		this.checkBoxTrangThai.Text = "Sử dụng khi thay đổi bản đồ hoặc thay đổi trạng thái chiến đấu";
		this.checkBoxTrangThai.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		this.checkBoxTrangThai.UseVisualStyleBackColor = false;
		this.checkBoxTrangThai.CheckedChanged += new System.EventHandler(checkBoxTrangThai_CheckedChanged);
		this.checkBoxTamDung.AutoSize = true;
		this.checkBoxTamDung.ForeColor = System.Drawing.Color.DarkGreen;
		this.checkBoxTamDung.Location = new System.Drawing.Point(40, 330);
		this.checkBoxTamDung.Name = "checkBoxTamDung";
		this.checkBoxTamDung.Size = new System.Drawing.Size(203, 17);
		this.checkBoxTamDung.TabIndex = 237;
		this.checkBoxTamDung.Text = "Tạm dừng mọi hoạt động khi sử dụng";
		this.checkBoxTamDung.UseVisualStyleBackColor = true;
		this.checkBoxTamDung.CheckedChanged += new System.EventHandler(checkBoxTamDung_CheckedChanged);
		this.textBoxMenu.ForeColor = System.Drawing.Color.Black;
		this.textBoxMenu.Location = new System.Drawing.Point(285, 351);
		this.textBoxMenu.Name = "textBoxMenu";
		this.textBoxMenu.Size = new System.Drawing.Size(73, 20);
		this.textBoxMenu.TabIndex = 241;
		this.textBoxMenu.TextChanged += new System.EventHandler(textBoxMenu_TextChanged);
		this.label3.AutoSize = true;
		this.label3.ForeColor = System.Drawing.Color.DarkRed;
		this.label3.Location = new System.Drawing.Point(363, 198);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(108, 13);
		this.label3.TabIndex = 242;
		this.label3.Text = "(Số lượng mỗi lần mở)";
		this.textBoxSoluongMax.ForeColor = System.Drawing.Color.Black;
		this.textBoxSoluongMax.Location = new System.Drawing.Point(311, 195);
		this.textBoxSoluongMax.Name = "textBoxSoluongMax";
		this.textBoxSoluongMax.Size = new System.Drawing.Size(47, 20);
		this.textBoxSoluongMax.TabIndex = 243;
		this.textBoxSoluongMax.TextChanged += new System.EventHandler(textBoxSoluongMax_TextChanged);
		this.label2.AutoSize = true;
		this.label2.ForeColor = System.Drawing.Color.Red;
		this.label2.Location = new System.Drawing.Point(8, 381);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(313, 13);
		this.label2.TabIndex = 245;
		this.label2.Text = "Xem và kết hợp với phần <Hậu cần - nhồi thuốc > nha các bạn !";
		this.checkBoxKhongMo.AutoSize = true;
		this.checkBoxKhongMo.ForeColor = System.Drawing.Color.DarkRed;
		this.checkBoxKhongMo.Location = new System.Drawing.Point(11, 3);
		this.checkBoxKhongMo.Name = "checkBoxKhongMo";
		this.checkBoxKhongMo.Size = new System.Drawing.Size(436, 17);
		this.checkBoxKhongMo.TabIndex = 246;
		this.checkBoxKhongMo.Text = "Không mở túi ở nơi phi chiến đấu (không áp dụng cho thay đổi bản đồ hoặc trạng thái)";
		this.checkBoxKhongMo.UseVisualStyleBackColor = true;
		this.checkBoxKhongMo.CheckedChanged += new System.EventHandler(checkBoxKhongMo_CheckedChanged);
		this.panel1.BackgroundImage = ns16.EmbeddedImageResources.QuantityInputBackground;
		this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.panel1.Location = new System.Drawing.Point(368, 164);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(93, 28);
		this.panel1.TabIndex = 247;
		this.checkBox1.AutoSize = true;
		this.checkBox1.ForeColor = System.Drawing.Color.DarkGreen;
		this.checkBox1.Location = new System.Drawing.Point(40, 221);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(131, 17);
		this.checkBox1.TabIndex = 248;
		this.checkBox1.Text = "Thuốc khi mở túi ra là ";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(16, 216);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(21, 13);
		this.label1.TabIndex = 249;
		this.label1.Text = "|__";
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(16, 327);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(21, 13);
		this.label4.TabIndex = 250;
		this.label4.Text = "|__";
		this.comboBoxTenMau2.BackColor = System.Drawing.SystemColors.Info;
		this.comboBoxTenMau2.DropDownWidth = 180;
		this.comboBoxTenMau2.ForeColor = System.Drawing.Color.Black;
		this.comboBoxTenMau2.FormattingEnabled = true;
		this.comboBoxTenMau2.Location = new System.Drawing.Point(178, 219);
		this.comboBoxTenMau2.Name = "comboBoxTenMau2";
		this.comboBoxTenMau2.Size = new System.Drawing.Size(180, 21);
		this.comboBoxTenMau2.TabIndex = 333;
		this.comboBoxTenMau2.MouseDown += new System.Windows.Forms.MouseEventHandler(comboBoxTenMau2_MouseDown);
		this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
		this.label5.Location = new System.Drawing.Point(69, 244);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(362, 30);
		this.label5.TabIndex = 334;
		this.label5.Text = "nếu không bơm được thuốc sau khi mở bung túi, thì bên tab Phục hồi hãy check vào bơm mức 2 và chọn tên thuốc trên";
		this.label6.AutoSize = true;
		this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
		this.label6.Location = new System.Drawing.Point(42, 244);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(21, 13);
		this.label6.TabIndex = 335;
		this.label6.Text = "|__";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(471, 406);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.comboBoxTenMau2);
		base.Controls.Add(this.checkBox1);
		base.Controls.Add(this.checkBoxTamDung);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.buttonXoa);
		base.Controls.Add(this.buttonThem);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.checkBoxKhongMo);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.textBoxSoluongMax);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.textBoxMenu);
		base.Controls.Add(this.checkBoxClickMenu);
		base.Controls.Add(this.checkBoxTrangThai);
		base.Controls.Add(this.buttonAppAll);
		base.Controls.Add(this.textBoxThoigian);
		base.Controls.Add(this.checkBoxMoTheoSoluong);
		base.Controls.Add(this.checkBoxMoTheoThoigian);
		base.Controls.Add(this.textBoxMothuocKhicon);
		base.Controls.Add(this.buttonClose);
		base.Controls.Add(this.comboBoxTenTuiMauHotro);
		base.Controls.Add(this.checkBoxCoNhapSoluong);
		base.Controls.Add(this.listView1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.Name = "FormHaucanTuithuoc";
		base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		this.Text = "MO TUI VAT PHAM";
		base.Load += new System.EventHandler(FormHaucanTuithuoc_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}

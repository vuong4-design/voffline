using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ns1;
using ns10;
using ns100;
using ns11;
using ns121;
using ns13;
using ns23;
using ns3;
using ns35;
using ns36;
using ns41;
using ns44;
using ns53;
using ns56;
using ns61;
using ns63;
using ns71;
using ns81;
using ns83;
using ns88;

namespace ns133;

public class FormTapKet : Form
{
	private IContainer icontainer_0 = null;

	private ListView listView1;

	private ColumnHeader columnHeader_0;

	private Button buttonThem;

	private Button buttonXoa;

	private Button buttonClose;

	private System.Windows.Forms.Timer timer_0;

	private ColumnHeader columnHeader_1;

	private ColumnHeader columnHeader_2;

	private Label label1;

	private TextBox textBoxMenu;

	private ColumnHeader columnHeader_3;

	private ColumnHeader columnHeader_4;

	private Button buttonHelp;

	private ComboBox comboBoxChon;

	private RichTextBox richTextBox1;

	private Button buttonSua;

	private CheckBox checkBoxNhapSL;

	private TextBox textBoxNhapSL;

	private ColumnHeader columnHeader_5;

	private CheckBox checkBoxMatMa;

	private ColumnHeader columnHeader_6;

	private Label label2;

	private ComboBox comboBoxNpc;

	public static bool isTapKetFormOpen = false;

	public static int selectedAccountId = 0;

	public static bool tapKetEntriesLoaded = false;

	public static GStruct64[] gstruct64_0 = null;

	public int popupAnchorX;

	public int popupAnchorY;

	public int ownerWindowWidth;

	public int ownerWindowHeight;

	private static string[] targetTypeLabels = new string[2] { "NPC", "Vật phẩm" };

	private static GStruct25[] npcLocationCandidates = null;

	private IContainer icontainer_1;

	private static string[] inventoryItemCandidates = null;

	public FormTapKet()
	{
		isTapKetFormOpen = true;
		InitializeComponent();
		base.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
	}

	private void method_0(bool bool_2)
	{
		if (bool_2 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		method_0(bool_2);
	}

	private void InitializeComponent()
	{
		this.icontainer_1 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ns133.FormTapKet));
		this.listView1 = new System.Windows.Forms.ListView();
		this.columnHeader_0 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_1 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_2 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_3 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_4 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_5 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_6 = new System.Windows.Forms.ColumnHeader();
		this.buttonThem = new System.Windows.Forms.Button();
		this.buttonXoa = new System.Windows.Forms.Button();
		this.buttonClose = new System.Windows.Forms.Button();
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_1);
		this.label1 = new System.Windows.Forms.Label();
		this.textBoxMenu = new System.Windows.Forms.TextBox();
		this.buttonHelp = new System.Windows.Forms.Button();
		this.comboBoxChon = new System.Windows.Forms.ComboBox();
		this.richTextBox1 = new System.Windows.Forms.RichTextBox();
		this.buttonSua = new System.Windows.Forms.Button();
		this.checkBoxNhapSL = new System.Windows.Forms.CheckBox();
		this.textBoxNhapSL = new System.Windows.Forms.TextBox();
		this.checkBoxMatMa = new System.Windows.Forms.CheckBox();
		this.label2 = new System.Windows.Forms.Label();
		this.comboBoxNpc = new System.Windows.Forms.ComboBox();
		base.SuspendLayout();
		this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[7] { this.columnHeader_0, this.columnHeader_1, this.columnHeader_2, this.columnHeader_3, this.columnHeader_4, this.columnHeader_5, this.columnHeader_6 });
		this.listView1.FullRowSelect = true;
		this.listView1.GridLines = true;
		this.listView1.HideSelection = false;
		this.listView1.Location = new System.Drawing.Point(4, 96);
		this.listView1.Name = "listView1";
		this.listView1.Size = new System.Drawing.Size(419, 109);
		this.listView1.TabIndex = 218;
		this.listView1.UseCompatibleStateImageBehavior = false;
		this.listView1.View = System.Windows.Forms.View.Details;
		this.columnHeader_0.Text = "STT";
		this.columnHeader_0.Width = 35;
		this.columnHeader_1.Text = "NPC / Vật phẩm";
		this.columnHeader_1.Width = 130;
		this.columnHeader_2.Text = "Tọa độ";
		this.columnHeader_3.Text = "Menu";
		this.columnHeader_3.Width = 40;
		this.columnHeader_4.Text = "Bản đồ";
		this.columnHeader_4.Width = 50;
		this.columnHeader_5.Text = "Nhập số lượng";
		this.columnHeader_5.Width = 50;
		this.columnHeader_6.Text = "Có mật mã";
		this.columnHeader_6.Width = 30;
		this.buttonThem.ForeColor = System.Drawing.Color.DarkRed;
		this.buttonThem.Location = new System.Drawing.Point(34, 339);
		this.buttonThem.Name = "buttonThem";
		this.buttonThem.Size = new System.Drawing.Size(103, 31);
		this.buttonThem.TabIndex = 219;
		this.buttonThem.Text = "Thêm vào";
		this.buttonThem.UseVisualStyleBackColor = true;
		this.buttonThem.Click += new System.EventHandler(buttonThem_Click);
		this.buttonXoa.Location = new System.Drawing.Point(320, 211);
		this.buttonXoa.Name = "buttonXoa";
		this.buttonXoa.Size = new System.Drawing.Size(93, 26);
		this.buttonXoa.TabIndex = 220;
		this.buttonXoa.Text = "Xóa";
		this.buttonXoa.UseVisualStyleBackColor = true;
		this.buttonXoa.Click += new System.EventHandler(buttonXoa_Click);
		this.buttonClose.Location = new System.Drawing.Point(320, 341);
		this.buttonClose.Name = "buttonClose";
		this.buttonClose.Size = new System.Drawing.Size(93, 29);
		this.buttonClose.TabIndex = 222;
		this.buttonClose.Text = "Đóng";
		this.buttonClose.UseVisualStyleBackColor = true;
		this.buttonClose.Click += new System.EventHandler(buttonClose_Click);
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(26, 289);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(143, 13);
		this.label1.TabIndex = 223;
		this.label1.Text = "Có click vào các dòng menu";
		this.textBoxMenu.Location = new System.Drawing.Point(186, 286);
		this.textBoxMenu.Name = "textBoxMenu";
		this.textBoxMenu.Size = new System.Drawing.Size(75, 20);
		this.textBoxMenu.TabIndex = 224;
		this.buttonHelp.ForeColor = System.Drawing.Color.MediumBlue;
		this.buttonHelp.Location = new System.Drawing.Point(320, 304);
		this.buttonHelp.Name = "buttonHelp";
		this.buttonHelp.Size = new System.Drawing.Size(93, 29);
		this.buttonHelp.TabIndex = 225;
		this.buttonHelp.Text = "Hướng dẫn";
		this.buttonHelp.UseVisualStyleBackColor = true;
		this.buttonHelp.Click += new System.EventHandler(buttonHelp_Click);
		this.comboBoxChon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxChon.FormattingEnabled = true;
		this.comboBoxChon.Location = new System.Drawing.Point(8, 234);
		this.comboBoxChon.Name = "comboBoxChon";
		this.comboBoxChon.Size = new System.Drawing.Size(253, 21);
		this.comboBoxChon.TabIndex = 226;
		this.comboBoxChon.MouseDown += new System.Windows.Forms.MouseEventHandler(comboBoxChon_MouseDown);
		this.richTextBox1.Location = new System.Drawing.Point(4, 3);
		this.richTextBox1.Name = "richTextBox1";
		this.richTextBox1.Size = new System.Drawing.Size(419, 87);
		this.richTextBox1.TabIndex = 227;
		this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
		this.buttonSua.Location = new System.Drawing.Point(152, 339);
		this.buttonSua.Name = "buttonSua";
		this.buttonSua.Size = new System.Drawing.Size(75, 31);
		this.buttonSua.TabIndex = 228;
		this.buttonSua.Text = "Sửa";
		this.buttonSua.UseVisualStyleBackColor = true;
		this.buttonSua.Click += new System.EventHandler(buttonSua_Click);
		this.checkBoxNhapSL.AutoSize = true;
		this.checkBoxNhapSL.Location = new System.Drawing.Point(8, 311);
		this.checkBoxNhapSL.Name = "checkBoxNhapSL";
		this.checkBoxNhapSL.Size = new System.Drawing.Size(109, 17);
		this.checkBoxNhapSL.TabIndex = 230;
		this.checkBoxNhapSL.Text = "Có nhập số lượng";
		this.checkBoxNhapSL.UseVisualStyleBackColor = true;
		this.textBoxNhapSL.Location = new System.Drawing.Point(186, 309);
		this.textBoxNhapSL.Name = "textBoxNhapSL";
		this.textBoxNhapSL.Size = new System.Drawing.Size(75, 20);
		this.textBoxNhapSL.TabIndex = 231;
		this.checkBoxMatMa.AutoSize = true;
		this.checkBoxMatMa.Location = new System.Drawing.Point(10, 262);
		this.checkBoxMatMa.Name = "checkBoxMatMa";
		this.checkBoxMatMa.Size = new System.Drawing.Size(243, 17);
		this.checkBoxMatMa.TabIndex = 232;
		this.checkBoxMatMa.Text = "Có cần nhập mật mã ngẫu nhiên khi click npc";
		this.checkBoxMatMa.UseVisualStyleBackColor = true;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(3, 212);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(134, 13);
		this.label2.TabIndex = 233;
		this.label2.Text = "Đây là npc hay vật phẩm ?";
		this.comboBoxNpc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxNpc.FormattingEnabled = true;
		this.comboBoxNpc.Location = new System.Drawing.Point(152, 208);
		this.comboBoxNpc.Name = "comboBoxNpc";
		this.comboBoxNpc.Size = new System.Drawing.Size(109, 21);
		this.comboBoxNpc.TabIndex = 234;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(425, 374);
		base.Controls.Add(this.comboBoxNpc);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.checkBoxMatMa);
		base.Controls.Add(this.textBoxNhapSL);
		base.Controls.Add(this.checkBoxNhapSL);
		base.Controls.Add(this.textBoxMenu);
		base.Controls.Add(this.buttonSua);
		base.Controls.Add(this.richTextBox1);
		base.Controls.Add(this.comboBoxChon);
		base.Controls.Add(this.buttonHelp);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.buttonClose);
		base.Controls.Add(this.buttonXoa);
		base.Controls.Add(this.buttonThem);
		base.Controls.Add(this.listView1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.Name = "FormTapKet";
		base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		this.Text = "TAP KET";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormTapKet_FormClosing);
		base.Load += new System.EventHandler(FormTapKet_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	public static int EnsureTapKetEntriesLoadedAndRunAutomation(int int_5)
	{
		try
		{
			if (!tapKetEntriesLoaded)
			{
				tapKetEntriesLoaded = true;
				LoadTapKetEntries();
			}
			return RunTapKetAutomation(int_5);
		}
		catch
		{
		}
		return -1;
	}

	public static int RunTapKetAutomation(int int_5)
	{
		int result = 0;
		int num = 0;
		CharacterAccountConfig characterAccountConfig = default(CharacterAccountConfig);
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		string text = null;
		string text2 = null;
		uint[] array = null;
		uint[] array2 = null;
		long long_ = 0L;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		int num11 = 0;
		while (true)
		{
			Thread.Sleep(300);
			int num12 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_5);
			uint num16;
			int num19;
			string[] array7;
			int num22;
			if (!CommonUtility.bool_0 && num12 >= 0 && Form1.gatheringPointEnabled > 0 && Form1.pkModeIndex == 0 && gstruct64_0 != null && !AuxiliaryMachineManager.bool_7)
			{
				characterAccountConfig = Form1.characterAccountConfig_1[num12];
				if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_48, 4) > 0 || !characterAccountConfig.bool_25 || characterAccountConfig.int_20[0] > 0 || characterAccountConfig.int_133[0] > 0 || characterAccountConfig.bool_54 || characterAccountConfig.int_25 > 0 || characterAccountConfig.bool_15)
				{
					break;
				}
				uint num13 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig.int_137);
				uint num14 = WindowsInteropHelper.ReadProcessUInt32(num13 + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig.int_137);
				uint num15 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig.int_137);
				num16 = num15 + num14 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
				int num17 = (int)WindowsInteropHelper.ReadProcessUInt32(num16 + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, characterAccountConfig.int_137);
				int num18 = (int)WindowsInteropHelper.ReadProcessUInt32(num16 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, characterAccountConfig.int_137);
				num19 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig.int_137);
				if (AuxiliaryMachineManager.bool_6 && TongKimBattlefieldHelper.FindBattlefieldMapGroupPosition(num19) != null)
				{
					break;
				}
				if (num17 != 10 && num17 != 21 && num18 != 0 && num17 != 0 && num19 != 0)
				{
					int num20 = (int)WindowsInteropHelper.ReadProcessUInt32(num16 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, characterAccountConfig.int_137);
					if (num20 <= 0)
					{
						num3 = 0;
						num8 = 0;
						num9 = 0;
						while (num3 < 255)
						{
							num3++;
							if (gstruct64_0.Length > num2)
							{
								if (gstruct64_0[num2].targetTypeIndex == 0 && gstruct64_0[num2].mapId != num19)
								{
									num2++;
									Thread.Sleep(100);
									continue;
								}
								text = gstruct64_0[num2].targetName;
								array = gstruct64_0[num2].targetCoordinates;
								text2 = gstruct64_0[num2].menuSelectionText;
								num8 = gstruct64_0[num2].quantityInputEnabled;
								num9 = gstruct64_0[num2].inputQuantity;
								num10 = gstruct64_0[num2].passwordEnabled;
								num11 = gstruct64_0[num2].targetTypeIndex;
								num7 = 0;
								break;
							}
							goto IL_0958;
						}
						num = 0;
						uint[] array3 = new uint[2]
						{
							WindowsInteropHelper.ReadProcessUInt32(num16 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig.int_137),
							WindowsInteropHelper.ReadProcessUInt32(num16 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig.int_137)
						};
						if (num11 <= 0)
						{
							if (array == null || array[0] == 0 || array[1] == 0)
							{
								goto IL_08c2;
							}
							long num21 = Class64.GetSquaredCoordinateDistance(array3, array);
							if (num21 > 800000L)
							{
								Class64.SwitchHorseStateIfNeeded(characterAccountConfig, bool_0: false);
								if (num4 < 6)
								{
									uint[,] array4 = MapRouteCatalog.FindRoute(num19, array3, array);
									if (array4 == null)
									{
										num4 = 6;
									}
									else
									{
										Class64.FollowCoordinateRoute(characterAccountConfig, array4, array3, array, num19, bool_0: true, 100000);
									}
									num4++;
									continue;
								}
								if (array2 == null)
								{
									array2 = new uint[2]
									{
										array3[0],
										array3[1]
									};
									num5 = 0;
								}
								if (num5 > 6)
								{
									bool flag = array2 != null && Class64.GetSquaredCoordinateDistance(array2, array3) < 180000L;
									array2 = null;
									if (flag)
									{
										Class64.MoveToApproachCoordinateAndWaitForMovementState(characterAccountConfig, array3, array, 600);
										continue;
									}
									num5 = 0;
								}
								if (CommonUtility.GetElapsedMilliseconds(long_) > 4500L)
								{
									if (CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, array) <= 0)
									{
										Class64.TryRecoverStuckMovement(characterAccountConfig);
									}
									num5++;
									long_ = CommonUtility.GetCurrentTicks();
								}
							}
							num3 = 0;
							CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
							NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig);
							Thread.Sleep(100);
							while (!CommonUtility.bool_0)
							{
								array3 = new uint[2]
								{
									WindowsInteropHelper.ReadProcessUInt32(num16 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig.int_137),
									WindowsInteropHelper.ReadProcessUInt32(num16 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig.int_137)
								};
								if (Class64.GetSquaredCoordinateDistance(array3, array) <= 22500L)
								{
									break;
								}
								if (num3 <= 15)
								{
									GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, array);
									num3++;
									Thread.Sleep(300);
									continue;
								}
								CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, array);
								Thread.Sleep(3000);
								break;
							}
							CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
							if (num7 <= 0)
							{
								Thread.Sleep(300);
								num7 = GameEntityMemoryHelper.FindMatchingEntityIndexByNameAndType(characterAccountConfig, text, 3, 0 <= text.IndexOf("Xa phu"));
							}
							if (num7 <= 0)
							{
								Class64.TryShowStatusMessageIfDue(characterAccountConfig, "Dang tim " + text + " !");
								num6++;
								if (num6 > 6)
								{
									Class64.TryRecoverStuckMovement(characterAccountConfig);
									num6 = 0;
								}
								continue;
							}
						}
						num6 = 0;
						num3 = 0;
						while (true)
						{
							if (!CommonUtility.bool_0)
							{
								if (Form1.gatheringPointEnabled <= 0)
								{
									break;
								}
								if (num10 > 0 && WindowsInteropHelper.ReadProcessUInt32(characterAccountConfig.uint_7 + GameConfigurationManager.memorySignatureScanConfig_172.resolvedValue, characterAccountConfig.int_137) != 0)
								{
									string string_ = InventoryItemHelper.GetDialogPromptText(characterAccountConfig);
									InventoryItemHelper.SetDialogInputText(characterAccountConfig, CommonUtility.ParseEmbeddedIntegerDigits(string_).ToString(), bool_0: true);
									Thread.Sleep(300);
								}
								if (num3 % 10 == 0)
								{
									if (num11 > 0)
									{
										uint[] array5 = Class85.FindInventoryItemInfoByName(characterAccountConfig, text);
										if (array5 == null)
										{
											goto IL_08c2;
										}
										GameProcessInteractionHelper.UseInventoryItemByRecordIndexAndPosition(characterAccountConfig, array5[0], (int)array5[2], (int)array5[3]);
									}
									else
									{
										CurrentCharacterMemoryHelper.SetCurrentTargetEntityIndex(characterAccountConfig, (uint)num7);
									}
									Thread.Sleep(300);
									num6++;
								}
								Thread.Sleep(100);
								if (0 > NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig))
								{
									if (!NpcDialogHelper.PopupMessageHelper.IsActive(characterAccountConfig))
									{
										num3++;
										if (num6 > 6)
										{
											Class64.TryRecoverStuckMovement(characterAccountConfig);
											num6 = 0;
											break;
										}
										continue;
									}
									NpcDialogHelper.PopupMessageHelper.Dismiss(characterAccountConfig);
								}
							}
							Thread.Sleep(150);
							string text3 = text2;
							char[] array6 = new char[4];
							EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array6, 17646);
							array7 = text3.Split(array6);
							num22 = 0;
							goto IL_083d;
						}
						continue;
					}
					result = 1;
					break;
				}
				if (num18 == 0 || num17 == 0)
				{
					num++;
					if (num < 10)
					{
						Thread.Sleep(100);
						continue;
					}
				}
				result = -1;
				break;
			}
			result = 0;
			break;
			IL_083d:
			while (true)
			{
				if (num22 < array7.Length)
				{
					if (NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig) < 0)
					{
						break;
					}
					int num23 = CommonUtility.ParseInt32OrZero(array7[num22]) - 1;
					if (num23 < 0)
					{
						goto IL_0837;
					}
					int num24 = NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig);
					int num25 = NpcDialogHelper.GetMenuOptionCount(characterAccountConfig, num24);
					string text4 = string.Empty;
					for (int i = 0; i < num25; i++)
					{
						text4 += NpcDialogHelper.GetMenuOptionText(characterAccountConfig, i, num24, 128);
					}
					NpcDialogHelper.SelectMenuOption(characterAccountConfig, num23);
					Thread.Sleep(300);
					for (num3 = 0; num3 < 10; num3++)
					{
						int num26 = NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig);
						if (num26 != num24)
						{
							break;
						}
						int num27 = NpcDialogHelper.GetMenuOptionCount(characterAccountConfig, num26);
						if (num27 != num25)
						{
							break;
						}
						string text5 = string.Empty;
						for (int j = 0; j < num27; j++)
						{
							text5 += NpcDialogHelper.GetMenuOptionText(characterAccountConfig, j, num26, 128);
						}
						if (text4 != text5)
						{
							break;
						}
						Thread.Sleep(100);
					}
					Thread.Sleep(150);
					int num28 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig.int_137);
					int num29 = (int)WindowsInteropHelper.ReadProcessUInt32(num16 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, characterAccountConfig.int_137);
					if ((num28 == 0 || num28 == num19) && num29 <= 0)
					{
						goto IL_0837;
					}
				}
				if (num8 <= 0)
				{
					break;
				}
				num3 = 0;
				while (num3 < 10)
				{
					if (WindowsInteropHelper.ReadProcessUInt32(characterAccountConfig.uint_7 + GameConfigurationManager.memorySignatureScanConfig_172.resolvedValue, characterAccountConfig.int_137) == 0)
					{
						num3++;
						Thread.Sleep(100);
						continue;
					}
					num3 = -1;
					break;
				}
				if (CommonUtility.ParseDigitsOnlyOrMinusOne(InventoryItemHelper.GetDialogInputText(characterAccountConfig)) > 1)
				{
					WindowsInteropHelper.PostKeyPressWithScanCode(characterAccountConfig.uint_4, 13u);
				}
				else
				{
					InventoryItemHelper.SetDialogInputText(characterAccountConfig, num9.ToString(), bool_0: true);
				}
				break;
				IL_0837:
				num22++;
			}
			goto IL_08c2;
			IL_08c2:
			int num30 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig.int_137);
			int num31 = (int)WindowsInteropHelper.ReadProcessUInt32(num16 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, characterAccountConfig.int_137);
			if ((num30 == 0 || num30 == num19) && num31 <= 0)
			{
				num2++;
				NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig);
				continue;
			}
			result = 1;
			break;
			IL_0958:
			result = 1;
			break;
		}
		return result;
	}

	public static void LoadTapKetEntries()
	{
		gstruct64_0 = null;
		string text = CommonUtility.ReadAllTextWithEncodingOption(GameConfigurationManager.configDirectory + "\\Tapket.txt", 0, 0, 1);
		if (text == null || text == string.Empty)
		{
			return;
		}
		string[] array = text.Split('\r', '\n');
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == null || array[i] == string.Empty)
			{
				continue;
			}
			string[] array2 = array[i].Split(';');
			if (array2.Length < 5)
			{
				continue;
			}
			string text2 = array2[0];
			uint num = CommonUtility.ParseUInt32OrZero(array2[1]);
			uint num2 = CommonUtility.ParseUInt32OrZero(array2[2]);
			string text3 = array2[3];
			int num3 = CommonUtility.ParseInt32OrZero(array2[4]);
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			if (array2.Length > 6)
			{
				num4 = CommonUtility.ParseInt32OrZero(array2[5]);
				num5 = CommonUtility.ParseInt32OrZero(array2[6]);
			}
			if (array2.Length > 7)
			{
				num6 = CommonUtility.ParseInt32OrZero(array2[7]);
			}
			if (array2.Length > 8)
			{
				num7 = CommonUtility.ParseInt32OrZero(array2[8]);
			}
			if (text2 != null && !(text2 == string.Empty) && ((num != 0 && num2 != 0 && text3 != null && !(text3 == string.Empty)) || num7 != 0))
			{
				if (gstruct64_0 != null)
				{
					Array.Resize(ref gstruct64_0, gstruct64_0.Length + 1);
				}
				else
				{
					gstruct64_0 = new GStruct64[1];
				}
				gstruct64_0[gstruct64_0.Length - 1].targetName = text2;
				gstruct64_0[gstruct64_0.Length - 1].targetCoordinates = new uint[2] { num, num2 };
				gstruct64_0[gstruct64_0.Length - 1].menuSelectionText = text3;
				gstruct64_0[gstruct64_0.Length - 1].mapId = num3;
				gstruct64_0[gstruct64_0.Length - 1].quantityInputEnabled = num4;
				gstruct64_0[gstruct64_0.Length - 1].inputQuantity = num5;
				gstruct64_0[gstruct64_0.Length - 1].passwordEnabled = num6;
				gstruct64_0[gstruct64_0.Length - 1].targetTypeIndex = num7;
			}
		}
	}

	private static void SaveTapKetEntries()
	{
		string text = string.Empty;
		if (gstruct64_0 != null)
		{
			for (int i = 0; i < gstruct64_0.Length; i++)
			{
				if (gstruct64_0[i].targetName != null && !(gstruct64_0[i].targetName == string.Empty) && ((gstruct64_0[i].targetCoordinates != null && gstruct64_0[i].targetCoordinates[0] != 0 && gstruct64_0[i].targetCoordinates[1] != 0) || gstruct64_0[i].targetTypeIndex != 0))
				{
					if (gstruct64_0[i].menuSelectionText == null)
					{
						gstruct64_0[i].menuSelectionText = string.Empty;
					}
					gstruct64_0[i].menuSelectionText = gstruct64_0[i].menuSelectionText.Replace(";", ",");
					if (text != string.Empty)
					{
						text += GameConfigurationManager.lineSeparator;
					}
					object obj = text;
					text = string.Concat(obj, gstruct64_0[i].targetName, ";", gstruct64_0[i].targetCoordinates[0], ";", gstruct64_0[i].targetCoordinates[1], ";", gstruct64_0[i].menuSelectionText, ";", gstruct64_0[i].mapId, ";", gstruct64_0[i].quantityInputEnabled, ";", gstruct64_0[i].inputQuantity, ";", gstruct64_0[i].passwordEnabled, ";", gstruct64_0[i].targetTypeIndex);
				}
			}
		}
		CommonUtility.WriteAllTextWithEncodingOption(GameConfigurationManager.configDirectory + "\\Tapket.txt", text, 1);
	}

	private void FormTapKet_Load(object sender, EventArgs e)
	{
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
		if (!tapKetEntriesLoaded)
		{
			tapKetEntriesLoaded = true;
			LoadTapKetEntries();
		}
		if (gstruct64_0 != null)
		{
			for (int i = 0; i < gstruct64_0.Length; i++)
			{
				int int_ = gstruct64_0[i].mapId;
				if (gstruct64_0[i].targetTypeIndex > 0)
				{
					int_ = -1;
				}
				AppendTapKetEntryListViewRow(listView1, gstruct64_0[i].targetName, gstruct64_0[i].targetCoordinates, gstruct64_0[i].menuSelectionText, int_, gstruct64_0[i].quantityInputEnabled, gstruct64_0[i].inputQuantity, gstruct64_0[i].passwordEnabled);
			}
			for (int j = 0; j < gstruct64_0.Length; j++)
			{
				if (j < listView1.Items.Count && gstruct64_0[j].targetTypeIndex > 0)
				{
					listView1.Items[j].ForeColor = Color.Blue;
				}
			}
		}
		for (int k = 0; k < targetTypeLabels.Length; k++)
		{
			comboBoxNpc.Items.Add(targetTypeLabels[k]);
		}
		comboBoxNpc.Text = targetTypeLabels[0];
		timer_0.Interval = 300;
		timer_0.Enabled = true;
		base.TopMost = true;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (!isTapKetFormOpen)
		{
			Close();
		}
	}

	private void AppendTapKetEntryListViewRow(ListView listView_0, string string_2, uint[] uint_0, string string_3, int int_5, int int_6, int int_7, int int_8)
	{
		try
		{
			string text = "1";
			if (listView_0.Items != null && listView_0.Items.Count > 0)
			{
				text = (listView_0.Items.Count + 1).ToString();
			}
			string empty = string.Empty;
			if (int_5 < 0)
			{
				empty = "Vật phẩm";
			}
			else
			{
				empty = GameMapCatalog.GetMapName(int_5, bool_0: true);
				if (empty == null || empty == string.Empty)
				{
					empty = int_5.ToString();
				}
			}
			string[] array = new string[7]
			{
				text,
				GameTextEncodingHelper.ConvertGameTextToDisplayText(string_2, 1),
				uint_0[0] + "," + uint_0[1],
				string_3,
				empty,
				int_6 + ":" + int_7,
				int_8.ToString()
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

	private void buttonClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void buttonThem_Click(object sender, EventArgs e)
	{
		string text = comboBoxChon.Text;
		int num = 0;
		for (int i = 0; i < targetTypeLabels.Length; i++)
		{
			if (comboBoxNpc.Text == targetTypeLabels[i])
			{
				num = i;
				break;
			}
		}
		if (text == null || text == string.Empty || (num <= 0 && npcLocationCandidates == null) || (num > 0 && inventoryItemCandidates == null))
		{
			return;
		}
		string text2 = textBoxMenu.Text;
		text2 = ((text2 == null || text2 == string.Empty) ? "0" : text2.Replace(";", ","));
		string text3 = null;
		uint[] array = null;
		int int_ = 0;
		if (num <= 0)
		{
			for (int j = 0; j < npcLocationCandidates.Length; j++)
			{
				if (text == GameTextEncodingHelper.ConvertGameTextToDisplayText(npcLocationCandidates[j].name, 1))
				{
					text3 = npcLocationCandidates[j].name;
					array = ((npcLocationCandidates[j].coordinates != null) ? new uint[2]
					{
						npcLocationCandidates[j].coordinates[0],
						npcLocationCandidates[j].coordinates[1]
					} : new uint[2] { 1u, 1u });
					int_ = npcLocationCandidates[j].mapId;
					break;
				}
			}
		}
		else
		{
			for (int k = 0; k < inventoryItemCandidates.Length; k++)
			{
				if (text == GameTextEncodingHelper.ConvertGameTextToDisplayText(inventoryItemCandidates[k], 1))
				{
					text3 = inventoryItemCandidates[k];
					array = new uint[2] { 1u, 1u };
					break;
				}
			}
			int_ = -1;
		}
		if (text3 != null && !(text3 == string.Empty))
		{
			if (gstruct64_0 != null)
			{
				Array.Resize(ref gstruct64_0, gstruct64_0.Length + 1);
			}
			else
			{
				gstruct64_0 = new GStruct64[1];
			}
			int num2 = gstruct64_0.Length;
			int int_2 = Convert.ToByte(checkBoxNhapSL.Checked);
			int int_3 = CommonUtility.ParseInt32OrZero(textBoxNhapSL.Text);
			int int_4 = Convert.ToByte(checkBoxMatMa.Checked);
			gstruct64_0[num2 - 1].targetName = text3;
			gstruct64_0[num2 - 1].targetCoordinates = new uint[2]
			{
				array[0],
				array[1]
			};
			gstruct64_0[num2 - 1].mapId = int_;
			gstruct64_0[num2 - 1].menuSelectionText = text2;
			gstruct64_0[num2 - 1].quantityInputEnabled = int_2;
			gstruct64_0[num2 - 1].inputQuantity = int_3;
			gstruct64_0[num2 - 1].passwordEnabled = int_4;
			gstruct64_0[num2 - 1].targetTypeIndex = num;
			AppendTapKetEntryListViewRow(listView1, text3, array, text2, int_, int_2, int_3, int_4);
			if (num > 0)
			{
				listView1.Items[listView1.Items.Count - 1].ForeColor = Color.Blue;
			}
		}
	}

	private void buttonXoa_Click(object sender, EventArgs e)
	{
		if (gstruct64_0 != null)
		{
			int num = -1;
			for (int i = 0; i < listView1.Items.Count; i++)
			{
				if (listView1.Items[i].Selected)
				{
					num = i;
					listView1.Items.RemoveAt(num);
					break;
				}
			}
			if (num < 0)
			{
				return;
			}
			int num2 = 0;
			GStruct64[] array = new GStruct64[gstruct64_0.Length];
			for (int j = 0; j < gstruct64_0.Length; j++)
			{
				if (num != j)
				{
					array[num2] = gstruct64_0[j];
					num2++;
				}
			}
			if (num2 != 0)
			{
				gstruct64_0 = new GStruct64[num2];
				for (int k = 0; k < num2; k++)
				{
					gstruct64_0[k] = array[k];
				}
			}
			else
			{
				listView1.Items.Clear();
				gstruct64_0 = null;
			}
		}
		else
		{
			listView1.Items.Clear();
		}
	}

	private void comboBoxChon_MouseDown(object sender, MouseEventArgs e)
	{
		npcLocationCandidates = null;
		inventoryItemCandidates = null;
		int num = 0;
		for (int i = 0; i < targetTypeLabels.Length; i++)
		{
			if (comboBoxNpc.Text == targetTypeLabels[i])
			{
				num = i;
				break;
			}
		}
		if (num > 0)
		{
			int num2 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, selectedAccountId);
			if (0 <= num2)
			{
				inventoryItemCandidates = Class85.CollectInventoryItemNames(Form1.characterAccountConfig_1[num2], null, 0);
			}
			if (inventoryItemCandidates == null && Form1.characterAccountConfig_1 != null)
			{
				for (int j = 0; j < Form1.characterAccountConfig_1.Length; j++)
				{
					Class85.MergeFilteredInventoryItemNames(Form1.characterAccountConfig_1[j], ref inventoryItemCandidates);
				}
			}
		}
		else
		{
			int num3 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, selectedAccountId);
			if (0 <= num3)
			{
				GameEntityMemoryHelper.CollectEntityLocationRecords(Form1.characterAccountConfig_1[num3], ref npcLocationCandidates, 3);
			}
			if (npcLocationCandidates == null && Form1.characterAccountConfig_1 != null)
			{
				for (int k = 0; k < Form1.characterAccountConfig_1.Length; k++)
				{
					GameEntityMemoryHelper.CollectEntityLocationRecords(Form1.characterAccountConfig_1[k], ref npcLocationCandidates, 3);
				}
			}
		}
		string text = comboBoxChon.Text;
		string text2 = string.Empty;
		comboBoxChon.Items.Clear();
		if (num > 0)
		{
			if (inventoryItemCandidates != null)
			{
				for (int l = 0; l < inventoryItemCandidates.Length; l++)
				{
					string text3 = GameTextEncodingHelper.ConvertGameTextToDisplayText(inventoryItemCandidates[l], 1);
					comboBoxChon.Items.Add(text3);
					if (l == 0 || text3 == text)
					{
						text2 = text3;
					}
				}
			}
		}
		else if (npcLocationCandidates != null)
		{
			for (int m = 0; m < npcLocationCandidates.Length; m++)
			{
				string text4 = GameTextEncodingHelper.ConvertGameTextToDisplayText(npcLocationCandidates[m].name, 1);
				comboBoxChon.Items.Add(text4);
				if (m == 0 || text4 == text)
				{
					text2 = text4;
				}
			}
		}
		comboBoxChon.Text = text2;
	}

	private void buttonSua_Click(object sender, EventArgs e)
	{
		int num = 0;
		for (int i = 0; i < targetTypeLabels.Length; i++)
		{
			if (comboBoxNpc.Text == targetTypeLabels[i])
			{
				num = i;
				break;
			}
		}
		int num2 = -1;
		for (int j = 0; j < listView1.Items.Count; j++)
		{
			if (listView1.Items[j].Selected)
			{
				num2 = j;
				break;
			}
		}
		if (num2 < 0)
		{
			return;
		}
		if (gstruct64_0 != null && gstruct64_0.Length > num2)
		{
			string text = comboBoxChon.Text;
			string text2 = textBoxMenu.Text;
			if (text2 == null || text2 == string.Empty)
			{
				text2 = "0";
			}
			int num3 = Convert.ToByte(checkBoxNhapSL.Checked);
			int num4 = CommonUtility.ParseInt32OrZero(textBoxNhapSL.Text);
			int num5 = Convert.ToByte(checkBoxMatMa.Checked);
			if (text != null && !(text == string.Empty))
			{
				string text3 = string.Empty;
				string empty = string.Empty;
				uint[] array = null;
				int num6 = 0;
				if (num > 0)
				{
					for (int k = 0; k < inventoryItemCandidates.Length; k++)
					{
						if (text == GameTextEncodingHelper.ConvertGameTextToDisplayText(inventoryItemCandidates[k], 1))
						{
							text3 = inventoryItemCandidates[k];
							array = new uint[2] { 1u, 1u };
							break;
						}
					}
					empty = "Vật phẩm";
				}
				else
				{
					for (int l = 0; l < npcLocationCandidates.Length; l++)
					{
						if (text == GameTextEncodingHelper.ConvertGameTextToDisplayText(npcLocationCandidates[l].name, 1))
						{
							text3 = npcLocationCandidates[l].name;
							if (npcLocationCandidates[l].coordinates != null)
							{
								array = new uint[2]
								{
									npcLocationCandidates[l].coordinates[0],
									npcLocationCandidates[l].coordinates[1]
								};
							}
							num6 = npcLocationCandidates[l].mapId;
							break;
						}
					}
					empty = GameMapCatalog.GetMapName(num6, bool_0: true);
					if (empty == null || empty == string.Empty)
					{
						empty = num6.ToString();
					}
				}
				gstruct64_0[num2].quantityInputEnabled = num3;
				gstruct64_0[num2].inputQuantity = num4;
				gstruct64_0[num2].menuSelectionText = text2;
				gstruct64_0[num2].passwordEnabled = num5;
				gstruct64_0[num2].targetTypeIndex = num;
				gstruct64_0[num2].mapId = num6;
				gstruct64_0[num2].targetName = text3;
				listView1.Items[num2].SubItems[1].Text = text;
				listView1.Items[num2].SubItems[3].Text = text2;
				listView1.Items[num2].SubItems[4].Text = empty;
				listView1.Items[num2].SubItems[5].Text = num3 + ":" + num4;
				listView1.Items[num2].SubItems[6].Text = num5.ToString();
				if (array != null)
				{
					gstruct64_0[num2].targetCoordinates = new uint[2]
					{
						array[0],
						array[1]
					};
					listView1.Items[num2].SubItems[2].Text = array[0] + "," + array[1];
				}
				if (num != 0)
				{
					listView1.Items[num2].ForeColor = Color.Blue;
				}
				else
				{
					listView1.Items[num2].ForeColor = Color.Black;
				}
			}
			else
			{
				gstruct64_0[num2].quantityInputEnabled = num3;
				gstruct64_0[num2].inputQuantity = num4;
				gstruct64_0[num2].menuSelectionText = text2;
				gstruct64_0[num2].passwordEnabled = num5;
				gstruct64_0[num2].targetTypeIndex = num;
				listView1.Items[num2].SubItems[3].Text = text2;
				listView1.Items[num2].SubItems[5].Text = num3 + ":" + num4;
				listView1.Items[num2].SubItems[6].Text = num5.ToString();
			}
		}
		else
		{
			listView1.Items.Clear();
			gstruct64_0 = null;
		}
	}

	private void buttonHelp_Click(object sender, EventArgs e)
	{
		string string_ = Environment.GetEnvironmentVariable("programfiles") + "\\Google\\Chrome\\Application\\chrome.exe";
		if (!CommonUtility.FileExists(string_))
		{
			string_ = WindowsRegistryHelper.GetDefaultHttpHandlerExecutablePath();
		}
		WindowsInteropHelper.StartProcess(string_, "", "https://youtu.be/TRVdeyXbW94", 0);
	}

	private void FormTapKet_FormClosing(object sender, FormClosingEventArgs e)
	{
		SaveTapKetEntries();
		popupAnchorX = 0;
		popupAnchorY = 0;
		selectedAccountId = 0;
		isTapKetFormOpen = false;
	}
}

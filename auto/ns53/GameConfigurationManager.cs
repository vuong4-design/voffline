using System;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using ns10;
using ns100;
using ns11;
using ns23;
using ns27;
using ns35;
using ns47;
using ns63;
using ns67;
using ns7;
using ns71;
using ns77;
using ns79;
using ns83;
using ns85;

namespace ns53;

internal class GameConfigurationManager
{
	public static int int_0;

	public static byte[] byte_0;

	public static uint[] uint_0;

	public static uint uint_1;

	public static uint uint_2;

	public static uint uint_3;

	public static uint uint_4;

	public static uint uint_5;

	public static string string_0;

	public static string string_1;

	public static string string_2;

	public static MemorySignatureScanConfig[] memorySignatureScanConfig_0;

	public static GStruct52[] gstruct52_0;

	public static string string_3;

	public static string string_4;

	public static string string_5;

	public static string[] string_6;

	public static char[] char_0;

	public static char[] char_1;

	public static string lineSeparator;

	public static string applicationDirectory;

	public static string configDirectory;

	public static string allUserConfigDirectory;

	public static string comboConfigDirectory;

	public static string skillConfigDirectory;

	public static string offlineNameFilePath;

	public static string medicineConfigFilePath;

	public static string auxiliaryMachineConfigFilePath;

	public static string mapDirectory;

	public static string gameDataFileName;

	public static string string_18;

	public static string string_19;

	public static string string_20;

	public static string gameWindowClassName;

	public static string string_22;

	public static string string_23;

	public static int int_1;

	public static int[] int_2;

	public static int[] int_3;

	public static int[] int_4;

	public static uint[] uint_6;

	public static string[] string_24;

	public static string[,] string_25;

	public static ByteSignature[] byteSignature_0;

	public static uint uint_7;

	public static uint uint_8;

	public static uint uint_9;

	public static uint uint_10;

	public static uint uint_11;

	public static uint uint_12;

	public static int int_5;

	public static int int_6;

	public static uint[] uint_13;

	public static MemorySignatureScanConfig memorySignatureScanConfig_1;

	public static MemorySignatureScanConfig memorySignatureScanConfig_2;

	public static MemorySignatureScanConfig memorySignatureScanConfig_3;

	public static MemorySignatureScanConfig memorySignatureScanConfig_4;

	public static MemorySignatureScanConfig memorySignatureScanConfig_5;

	public static MemorySignatureScanConfig memorySignatureScanConfig_6;

	public static MemorySignatureScanConfig memorySignatureScanConfig_7;

	public static MemorySignatureScanConfig memorySignatureScanConfig_8;

	public static MemorySignatureScanConfig memorySignatureScanConfig_9;

	public static MemorySignatureScanConfig memorySignatureScanConfig_10;

	public static MemorySignatureScanConfig memorySignatureScanConfig_11;

	public static MemorySignatureScanConfig memorySignatureScanConfig_12;

	public static MemorySignatureScanConfig memorySignatureScanConfig_13;

	public static MemorySignatureScanConfig memorySignatureScanConfig_14;

	public static MemorySignatureScanConfig memorySignatureScanConfig_15;

	public static MemorySignatureScanConfig memorySignatureScanConfig_16;

	public static MemorySignatureScanConfig memorySignatureScanConfig_17;

	public static MemorySignatureScanConfig memorySignatureScanConfig_18;

	public static MemorySignatureScanConfig memorySignatureScanConfig_19;

	public static MemorySignatureScanConfig memorySignatureScanConfig_20;

	public static MemorySignatureScanConfig memorySignatureScanConfig_21;

	public static MemorySignatureScanConfig memorySignatureScanConfig_22;

	public static MemorySignatureScanConfig memorySignatureScanConfig_23;

	public static MemorySignatureScanConfig memorySignatureScanConfig_24;

	public static MemorySignatureScanConfig memorySignatureScanConfig_25;

	public static MemorySignatureScanConfig memorySignatureScanConfig_26;

	public static MemorySignatureScanConfig memorySignatureScanConfig_27;

	public static MemorySignatureScanConfig memorySignatureScanConfig_28;

	public static MemorySignatureScanConfig memorySignatureScanConfig_29;

	public static MemorySignatureScanConfig memorySignatureScanConfig_30;

	public static MemorySignatureScanConfig memorySignatureScanConfig_31;

	public static MemorySignatureScanConfig memorySignatureScanConfig_32;

	public static MemorySignatureScanConfig memorySignatureScanConfig_33;

	public static MemorySignatureScanConfig memorySignatureScanConfig_34;

	public static MemorySignatureScanConfig memorySignatureScanConfig_35;

	public static MemorySignatureScanConfig memorySignatureScanConfig_36;

	public static MemorySignatureScanConfig memorySignatureScanConfig_37;

	public static MemorySignatureScanConfig memorySignatureScanConfig_38;

	public static MemorySignatureScanConfig memorySignatureScanConfig_39;

	public static MemorySignatureScanConfig memorySignatureScanConfig_40;

	public static MemorySignatureScanConfig memorySignatureScanConfig_41;

	public static MemorySignatureScanConfig memorySignatureScanConfig_42;

	public static MemorySignatureScanConfig memorySignatureScanConfig_43;

	public static MemorySignatureScanConfig memorySignatureScanConfig_44;

	public static MemorySignatureScanConfig memorySignatureScanConfig_45;

	public static MemorySignatureScanConfig memorySignatureScanConfig_46;

	public static MemorySignatureScanConfig memorySignatureScanConfig_47;

	public static MemorySignatureScanConfig memorySignatureScanConfig_48;

	public static MemorySignatureScanConfig memorySignatureScanConfig_49;

	public static MemorySignatureScanConfig memorySignatureScanConfig_50;

	public static MemorySignatureScanConfig memorySignatureScanConfig_51;

	public static MemorySignatureScanConfig memorySignatureScanConfig_52;

	public static MemorySignatureScanConfig memorySignatureScanConfig_53;

	public static MemorySignatureScanConfig memorySignatureScanConfig_54;

	public static MemorySignatureScanConfig memorySignatureScanConfig_55;

	public static MemorySignatureScanConfig memorySignatureScanConfig_56;

	public static MemorySignatureScanConfig memorySignatureScanConfig_57;

	public static MemorySignatureScanConfig memorySignatureScanConfig_58;

	public static MemorySignatureScanConfig memorySignatureScanConfig_59;

	public static MemorySignatureScanConfig memorySignatureScanConfig_60;

	public static MemorySignatureScanConfig memorySignatureScanConfig_61;

	public static MemorySignatureScanConfig memorySignatureScanConfig_62;

	public static MemorySignatureScanConfig memorySignatureScanConfig_63;

	public static MemorySignatureScanConfig memorySignatureScanConfig_64;

	public static MemorySignatureScanConfig memorySignatureScanConfig_65;

	public static MemorySignatureScanConfig memorySignatureScanConfig_66;

	public static MemorySignatureScanConfig memorySignatureScanConfig_67;

	public static MemorySignatureScanConfig memorySignatureScanConfig_68;

	public static MemorySignatureScanConfig memorySignatureScanConfig_69;

	public static MemorySignatureScanConfig memorySignatureScanConfig_70;

	public static MemorySignatureScanConfig memorySignatureScanConfig_71;

	public static MemorySignatureScanConfig memorySignatureScanConfig_72;

	public static MemorySignatureScanConfig memorySignatureScanConfig_73;

	public static MemorySignatureScanConfig memorySignatureScanConfig_74;

	public static MemorySignatureScanConfig memorySignatureScanConfig_75;

	public static MemorySignatureScanConfig memorySignatureScanConfig_76;

	public static MemorySignatureScanConfig memorySignatureScanConfig_77;

	public static MemorySignatureScanConfig memorySignatureScanConfig_78;

	public static MemorySignatureScanConfig memorySignatureScanConfig_79;

	public static MemorySignatureScanConfig memorySignatureScanConfig_80;

	public static MemorySignatureScanConfig memorySignatureScanConfig_81;

	public static MemorySignatureScanConfig memorySignatureScanConfig_82;

	public static MemorySignatureScanConfig memorySignatureScanConfig_83;

	public static MemorySignatureScanConfig memorySignatureScanConfig_84;

	public static MemorySignatureScanConfig memorySignatureScanConfig_85;

	public static MemorySignatureScanConfig memorySignatureScanConfig_86;

	public static MemorySignatureScanConfig memorySignatureScanConfig_87;

	public static MemorySignatureScanConfig memorySignatureScanConfig_88;

	public static MemorySignatureScanConfig memorySignatureScanConfig_89;

	public static MemorySignatureScanConfig memorySignatureScanConfig_90;

	public static MemorySignatureScanConfig memorySignatureScanConfig_91;

	public static MemorySignatureScanConfig memorySignatureScanConfig_92;

	public static MemorySignatureScanConfig memorySignatureScanConfig_93;

	public static MemorySignatureScanConfig memorySignatureScanConfig_94;

	public static MemorySignatureScanConfig memorySignatureScanConfig_95;

	public static MemorySignatureScanConfig memorySignatureScanConfig_96;

	public static MemorySignatureScanConfig memorySignatureScanConfig_97;

	public static MemorySignatureScanConfig memorySignatureScanConfig_98;

	public static MemorySignatureScanConfig memorySignatureScanConfig_99;

	public static MemorySignatureScanConfig memorySignatureScanConfig_100;

	public static MemorySignatureScanConfig memorySignatureScanConfig_101;

	public static MemorySignatureScanConfig memorySignatureScanConfig_102;

	public static MemorySignatureScanConfig memorySignatureScanConfig_103;

	public static MemorySignatureScanConfig memorySignatureScanConfig_104;

	public static MemorySignatureScanConfig memorySignatureScanConfig_105;

	public static MemorySignatureScanConfig memorySignatureScanConfig_106;

	public static MemorySignatureScanConfig memorySignatureScanConfig_107;

	public static MemorySignatureScanConfig memorySignatureScanConfig_108;

	public static MemorySignatureScanConfig memorySignatureScanConfig_109;

	public static MemorySignatureScanConfig memorySignatureScanConfig_110;

	public static MemorySignatureScanConfig memorySignatureScanConfig_111;

	public static MemorySignatureScanConfig memorySignatureScanConfig_112;

	public static MemorySignatureScanConfig memorySignatureScanConfig_113;

	public static MemorySignatureScanConfig memorySignatureScanConfig_114;

	public static MemorySignatureScanConfig memorySignatureScanConfig_115;

	public static MemorySignatureScanConfig memorySignatureScanConfig_116;

	public static MemorySignatureScanConfig memorySignatureScanConfig_117;

	public static MemorySignatureScanConfig memorySignatureScanConfig_118;

	public static MemorySignatureScanConfig memorySignatureScanConfig_119;

	public static MemorySignatureScanConfig memorySignatureScanConfig_120;

	public static MemorySignatureScanConfig memorySignatureScanConfig_121;

	public static MemorySignatureScanConfig memorySignatureScanConfig_122;

	public static MemorySignatureScanConfig memorySignatureScanConfig_123;

	public static MemorySignatureScanConfig memorySignatureScanConfig_124;

	public static MemorySignatureScanConfig memorySignatureScanConfig_125;

	public static MemorySignatureScanConfig memorySignatureScanConfig_126;

	public static MemorySignatureScanConfig memorySignatureScanConfig_127;

	public static MemorySignatureScanConfig memorySignatureScanConfig_128;

	public static MemorySignatureScanConfig memorySignatureScanConfig_129;

	public static MemorySignatureScanConfig memorySignatureScanConfig_130;

	public static MemorySignatureScanConfig memorySignatureScanConfig_131;

	public static MemorySignatureScanConfig memorySignatureScanConfig_132;

	public static MemorySignatureScanConfig memorySignatureScanConfig_133;

	public static MemorySignatureScanConfig memorySignatureScanConfig_134;

	public static MemorySignatureScanConfig memorySignatureScanConfig_135;

	public static MemorySignatureScanConfig memorySignatureScanConfig_136;

	public static MemorySignatureScanConfig memorySignatureScanConfig_137;

	public static MemorySignatureScanConfig memorySignatureScanConfig_138;

	public static MemorySignatureScanConfig memorySignatureScanConfig_139;

	public static MemorySignatureScanConfig memorySignatureScanConfig_140;

	public static MemorySignatureScanConfig memorySignatureScanConfig_141;

	public static MemorySignatureScanConfig memorySignatureScanConfig_142;

	public static MemorySignatureScanConfig memorySignatureScanConfig_143;

	public static MemorySignatureScanConfig memorySignatureScanConfig_144;

	public static MemorySignatureScanConfig memorySignatureScanConfig_145;

	public static MemorySignatureScanConfig memorySignatureScanConfig_146;

	public static MemorySignatureScanConfig memorySignatureScanConfig_147;

	public static MemorySignatureScanConfig memorySignatureScanConfig_148;

	public static MemorySignatureScanConfig memorySignatureScanConfig_149;

	public static MemorySignatureScanConfig memorySignatureScanConfig_150;

	public static MemorySignatureScanConfig memorySignatureScanConfig_151;

	public static MemorySignatureScanConfig memorySignatureScanConfig_152;

	public static MemorySignatureScanConfig memorySignatureScanConfig_153;

	public static MemorySignatureScanConfig memorySignatureScanConfig_154;

	public static MemorySignatureScanConfig memorySignatureScanConfig_155;

	public static MemorySignatureScanConfig memorySignatureScanConfig_156;

	public static MemorySignatureScanConfig memorySignatureScanConfig_157;

	public static MemorySignatureScanConfig memorySignatureScanConfig_158;

	public static MemorySignatureScanConfig memorySignatureScanConfig_159;

	public static MemorySignatureScanConfig memorySignatureScanConfig_160;

	public static MemorySignatureScanConfig memorySignatureScanConfig_161;

	public static MemorySignatureScanConfig memorySignatureScanConfig_162;

	public static MemorySignatureScanConfig memorySignatureScanConfig_163;

	public static MemorySignatureScanConfig memorySignatureScanConfig_164;

	public static MemorySignatureScanConfig memorySignatureScanConfig_165;

	public static MemorySignatureScanConfig memorySignatureScanConfig_166;

	public static MemorySignatureScanConfig memorySignatureScanConfig_167;

	public static MemorySignatureScanConfig memorySignatureScanConfig_168;

	public static MemorySignatureScanConfig memorySignatureScanConfig_169;

	public static MemorySignatureScanConfig memorySignatureScanConfig_170;

	public static MemorySignatureScanConfig memorySignatureScanConfig_171;

	public static MemorySignatureScanConfig memorySignatureScanConfig_172;

	public static MemorySignatureScanConfig memorySignatureScanConfig_173;

	public static MemorySignatureScanConfig memorySignatureScanConfig_174;

	public static MemorySignatureScanConfig memorySignatureScanConfig_175;

	public static MemorySignatureScanConfig memorySignatureScanConfig_176;

	public static MemorySignatureScanConfig memorySignatureScanConfig_177;

	public static MemorySignatureScanConfig memorySignatureScanConfig_178;

	public static MemorySignatureScanConfig memorySignatureScanConfig_179;

	public static MemorySignatureScanConfig memorySignatureScanConfig_180;

	public static MemorySignatureScanConfig memorySignatureScanConfig_181;

	public static MemorySignatureScanConfig memorySignatureScanConfig_182;

	public static MemorySignatureScanConfig memorySignatureScanConfig_183;

	public static MemorySignatureScanConfig memorySignatureScanConfig_184;

	public static MemorySignatureScanConfig memorySignatureScanConfig_185;

	public static MemorySignatureScanConfig memorySignatureScanConfig_186;

	public static MemorySignatureScanConfig memorySignatureScanConfig_187;

	public static MemorySignatureScanConfig memorySignatureScanConfig_188;

	public static MemorySignatureScanConfig memorySignatureScanConfig_189;

	public static MemorySignatureScanConfig memorySignatureScanConfig_190;

	public static MemorySignatureScanConfig memorySignatureScanConfig_191;

	public static MemorySignatureScanConfig memorySignatureScanConfig_192;

	public static MemorySignatureScanConfig memorySignatureScanConfig_193;

	public static MemorySignatureScanConfig memorySignatureScanConfig_194;

	public static MemorySignatureScanConfig memorySignatureScanConfig_195;

	public static MemorySignatureScanConfig memorySignatureScanConfig_196;

	public static MemorySignatureScanConfig memorySignatureScanConfig_197;

	public static MemorySignatureScanConfig memorySignatureScanConfig_198;

	public static MemorySignatureScanConfig memorySignatureScanConfig_199;

	public static MemorySignatureScanConfig memorySignatureScanConfig_200;

	public static MemorySignatureScanConfig memorySignatureScanConfig_201;

	public static MemorySignatureScanConfig memorySignatureScanConfig_202;

	public static MemorySignatureScanConfig memorySignatureScanConfig_203;

	public static MemorySignatureScanConfig memorySignatureScanConfig_204;

	public static MemorySignatureScanConfig memorySignatureScanConfig_205;

	public static MemorySignatureScanConfig memorySignatureScanConfig_206;

	public static MemorySignatureScanConfig memorySignatureScanConfig_207;

	public static MemorySignatureScanConfig memorySignatureScanConfig_208;

	public static MemorySignatureScanConfig memorySignatureScanConfig_209;

	public static MemorySignatureScanConfig memorySignatureScanConfig_210;

	public static MemorySignatureScanConfig memorySignatureScanConfig_211;

	public static MemorySignatureScanConfig memorySignatureScanConfig_212;

	public static MemorySignatureScanConfig memorySignatureScanConfig_213;

	public static MemorySignatureScanConfig memorySignatureScanConfig_214;

	public static MemorySignatureScanConfig memorySignatureScanConfig_215;

	public static MemorySignatureScanConfig memorySignatureScanConfig_216;

	public static MemorySignatureScanConfig memorySignatureScanConfig_217;

	public static MemorySignatureScanConfig memorySignatureScanConfig_218;

	public static MemorySignatureScanConfig memorySignatureScanConfig_219;

	public static MemorySignatureScanConfig memorySignatureScanConfig_220;

	public static MemorySignatureScanConfig memorySignatureScanConfig_221;

	public static MemorySignatureScanConfig memorySignatureScanConfig_222;

	public static MemorySignatureScanConfig memorySignatureScanConfig_223;

	public static MemorySignatureScanConfig memorySignatureScanConfig_224;

	public static MemorySignatureScanConfig memorySignatureScanConfig_225;

	public static MemorySignatureScanConfig memorySignatureScanConfig_226;

	public static MemorySignatureScanConfig memorySignatureScanConfig_227;

	public static MemorySignatureScanConfig memorySignatureScanConfig_228;

	public static MemorySignatureScanConfig memorySignatureScanConfig_229;

	public static MemorySignatureScanConfig memorySignatureScanConfig_230;

	public static MemorySignatureScanConfig memorySignatureScanConfig_231;

	public static MemorySignatureScanConfig memorySignatureScanConfig_232;

	public static MemorySignatureScanConfig memorySignatureScanConfig_233;

	public static MemorySignatureScanConfig memorySignatureScanConfig_234;

	public static MemorySignatureScanConfig memorySignatureScanConfig_235;

	public static MemorySignatureScanConfig memorySignatureScanConfig_236;

	public static MemorySignatureScanConfig memorySignatureScanConfig_237;

	public static MemorySignatureScanConfig memorySignatureScanConfig_238;

	public static MemorySignatureScanConfig memorySignatureScanConfig_239;

	public static MemorySignatureScanConfig memorySignatureScanConfig_240;

	public static MemorySignatureScanConfig memorySignatureScanConfig_241;

	public static MemorySignatureScanConfig memorySignatureScanConfig_242;

	public static MemorySignatureScanConfig memorySignatureScanConfig_243;

	public static MemorySignatureScanConfig memorySignatureScanConfig_244;

	public static MemorySignatureScanConfig memorySignatureScanConfig_245;

	public static MemorySignatureScanConfig memorySignatureScanConfig_246;

	public static MemorySignatureScanConfig memorySignatureScanConfig_247;

	public static MemorySignatureScanConfig memorySignatureScanConfig_248;

	public static MemorySignatureScanConfig memorySignatureScanConfig_249;

	public static MemorySignatureScanConfig memorySignatureScanConfig_250;

	public static MemorySignatureScanConfig memorySignatureScanConfig_251;

	public static MemorySignatureScanConfig memorySignatureScanConfig_252;

	public static MemorySignatureScanConfig memorySignatureScanConfig_253;

	public static MemorySignatureScanConfig memorySignatureScanConfig_254;

	public static MemorySignatureScanConfig memorySignatureScanConfig_255;

	public static MemorySignatureScanConfig memorySignatureScanConfig_256;

	public static MemorySignatureScanConfig memorySignatureScanConfig_257;

	public static MemorySignatureScanConfig memorySignatureScanConfig_258;

	public static MemorySignatureScanConfig memorySignatureScanConfig_259;

	public static MemorySignatureScanConfig memorySignatureScanConfig_260;

	public static MemorySignatureScanConfig memorySignatureScanConfig_261;

	public static MemorySignatureScanConfig memorySignatureScanConfig_262;

	public static MemorySignatureScanConfig memorySignatureScanConfig_263;

	public static MemorySignatureScanConfig memorySignatureScanConfig_264;

	public static MemorySignatureScanConfig memorySignatureScanConfig_265;

	public static MemorySignatureScanConfig memorySignatureScanConfig_266;

	public static MemorySignatureScanConfig memorySignatureScanConfig_267;

	public static MemorySignatureScanConfig memorySignatureScanConfig_268;

	public static bool memorySignatureDataValid;

	public static bool memorySignatureLoadCompleted;

	public static string missingSignatureIndexes;

	public static string memorySignatureDiagnostics;

	public static int int_7;

	public static int int_8;

	private static int[,] fiveValueConfigurationTable;

	private static int[,] tenValueConfigurationTable;

	public static MemorySignatureScanConfig memorySignatureScanConfig_269;

	static GameConfigurationManager()
	{
		int_0 = 1500;
		byte_0 = CommonUtility.ConvertStringToSingleByteArray("_mouse drag");
		uint_0 = null;
		uint_1 = 0u;
		uint_2 = 3u;
		uint_3 = 4u;
		uint_4 = 5u;
		uint_5 = 6u;
		string_0 = null;
		string_1 = null;
		string_2 = null;
		memorySignatureScanConfig_0 = null;
		gstruct52_0 = null;
		string_3 = CommonUtility.DecompressBase64DeflateUtf8("C/Z3Cwl3DHKN8Y70Ts2vSAUA");
		string_4 = CommonUtility.DecompressBase64DeflateUtf8("83dz8/H0cwUA");
		string_5 = CommonUtility.DecompressBase64DeflateUtf8("c0nMywhOTM7wyU/MLCkqBQA=");
		string_6 = CommonUtility.DecodeBase64Utf8(WindowsRegistryHelper.ReadApplicationRegistryString(string_5, 0)).Split('|');
		char_0 = new char[6] { 'ᓦ', 'ᓘ', 'ᓝ', 'ᓓ', 'ᓘ', 'ᓡ' };
		char_1 = new char[20]
		{
			'ᓰ', 'ᓶ', 'ᓰ', 'ᓱ', 'ᓢ', 'ᓪ', 'ᒰ', 'ᒯ', 'ᓙ', 'ᓡ',
			'ᓯ', 'ᓦ', 'ᓳ', 'ᓢ', 'ᓯ', 'ᓰ', 'ᓙ', 'ᓢ', 'ᓱ', 'ᓠ'
		};
		lineSeparator = '\r' + "\n";
		applicationDirectory = Directory.GetCurrentDirectory().ToString();
		configDirectory = applicationDirectory + "\\Config";
		allUserConfigDirectory = configDirectory + "\\AllUser";
		comboConfigDirectory = configDirectory + "\\Combo";
		skillConfigDirectory = configDirectory + "\\Skill";
		offlineNameFilePath = configDirectory + "\\OfflineName.txt";
		medicineConfigFilePath = configDirectory + "\\Medicin.txt";
		auxiliaryMachineConfigFilePath = configDirectory + "\\tbMayphu.txt";
		mapDirectory = applicationDirectory + "\\Map";
		gameDataFileName = "GameData.dat";
		string_18 = string.Empty;
		string_19 = string.Empty;
		string_20 = "GameSum";
		gameWindowClassName = "Sword3 Class";
		string_22 = "Qu¶ H";
		string_23 = null;
		int_1 = 600;
		int_2 = new int[18]
		{
			7, 8, 9, 10, 11, 12, 22, 26, 27, 28,
			54, 58, 59, 60, 63, 64, 65, 66
		};
		int_3 = new int[20]
		{
			35300, 33300, 32300, 31300, 30300, 28300, 27300, 26300, 25300, 24300,
			22300, 21300, 20300, 19300, 18300, 17300, 16300, 16300, 15300, 15300
		};
		int_4 = new int[20]
		{
			45300, 43300, 42300, 40300, 39300, 37300, 36300, 35300, 33300, 32300,
			30300, 29300, 27300, 26300, 25300, 24300, 23300, 22300, 21300, 20300
		};
		uint_6 = new uint[24]
		{
			1749327351u, 2228031257u, 4243888759u, 1673389038u, 2125211990u, 2733778391u, 1348791440u, 3009527130u, 3847658661u, 2579403001u,
			1940221416u, 2863624449u, 2043181059u, 2529356268u, 3058263379u, 1197734020u, 2569642226u, 2059715740u, 2321403062u, 3672844282u,
			63513748u, 692461516u, 2531711669u, 790030748u
		};
		string_24 = new string[22]
		{
			"None", "Đứng im", "Đi bộ", "Chạy", "Nhảy", "Buff", "Đánh phép thuật", "Đánh", "Ngồi", "Bị đánh",
			"Chết", "Phòng thủ", "Nghỉ ngơi", "SpecialSkill", "Special1", "Special2", "Special3", "Special4", "Chạy tấn công", "Đánh liên tiếp",
			"Nhảy tấn công", "Về dưỡng sức"
		};
		string_25 = new string[5, 3]
		{
			{ "Ngò Hoa Ngäc Lé Hoµn", "Thõa Tiªn MËt", null },
			{ "Cöu ChuyÓn Hoµn Hån ®an", "Håi Thiªn ®an", "Kim S\u00b8ng D\u00adîc" },
			{ "¤ ®Çu Hoµn thÇn ®an", "§¹i Bæ t\u00b8n", "Ng\u00adng ThÇn ®an" },
			{ "Ng©n KiÒu Khø ®éc ®an", "Ho¾c H\u00ad¬ng ChÝnh khÝ hoµn", null },
			{ "Tam Hoa T\u00b8n", null, null }
		};
		byteSignature_0 = new ByteSignature[3]
		{
			new ByteSignature
			{
				byte_0 = new byte[4] { 144, 236, 100, 80 }
			},
			new ByteSignature
			{
				byte_0 = new byte[4] { 182, 204, 93, 138 }
			},
			new ByteSignature
			{
				byte_0 = new byte[4] { 132, 11, 31, 92 }
			}
		};
		uint_7 = 70432u;
		uint_8 = 70436u;
		uint_9 = 70440u;
		uint_10 = 4368u;
		uint_11 = 4372u;
		uint_12 = 4412u;
		int_5 = 639615638;
		int_6 = 994025516;
		uint_13 = new uint[2] { 1648u, 1660u };
		memorySignatureScanConfig_1 = new MemorySignatureScanConfig
		{
			signatureName = "KEY_PRESS_COUNT",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 4,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_2 = new MemorySignatureScanConfig
		{
			signatureName = "INFECT_SIZE",
			primaryResultByteCount = 4,
			primaryMatchCount = 1,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_3 = new MemorySignatureScanConfig
		{
			signatureName = "INFECT_LENGTH",
			primaryResultByteCount = 4,
			primaryMatchCount = 1,
			primaryResultOffset = 23
		};
		memorySignatureScanConfig_4 = new MemorySignatureScanConfig
		{
			signatureName = "KTabFileLoad",
			primaryResultByteCount = 0,
			primaryMatchCount = 1,
			primaryResultOffset = 4
		};
		memorySignatureScanConfig_5 = new MemorySignatureScanConfig
		{
			signatureName = "ENGINE_HANDLE",
			primaryResultByteCount = 4,
			primaryMatchCount = 1,
			primaryResultOffset = 2,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_6 = new MemorySignatureScanConfig
		{
			signatureName = "MOUSE_POS",
			primaryResultByteCount = 1,
			primaryMatchCount = 1,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_7 = new MemorySignatureScanConfig
		{
			signatureName = "MSVCR80_invalid_parameter_noinfo",
			primaryResultByteCount = 4,
			primaryMatchCount = 1,
			primaryResultOffset = 9,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_8 = new MemorySignatureScanConfig
		{
			signatureName = "FUNC_BAO_DANH",
			primaryResultByteCount = 0,
			primaryMatchCount = 1,
			primaryResultOffset = 0
		};
		memorySignatureScanConfig_9 = new MemorySignatureScanConfig
		{
			signatureName = "NPC_COUNT_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 13,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_10 = new MemorySignatureScanConfig
		{
			signatureName = "NPC_COUNT_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 9
		};
		memorySignatureScanConfig_11 = new MemorySignatureScanConfig
		{
			signatureName = "KPLAYER_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_12 = new MemorySignatureScanConfig
		{
			signatureName = "KPLAYER_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 10
		};
		memorySignatureScanConfig_13 = new MemorySignatureScanConfig
		{
			signatureName = "PLAYER_INDEX_OFF",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 31
		};
		memorySignatureScanConfig_14 = new MemorySignatureScanConfig
		{
			signatureName = "NPC_BASE_ADD",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 37
		};
		memorySignatureScanConfig_15 = new MemorySignatureScanConfig
		{
			signatureName = "NPC_DATA_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 43
		};
		memorySignatureScanConfig_16 = new MemorySignatureScanConfig
		{
			signatureName = "NPC_NAME_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 50
		};
		memorySignatureScanConfig_17 = new MemorySignatureScanConfig
		{
			signatureName = "NPC_SEX_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 9
		};
		memorySignatureScanConfig_18 = new MemorySignatureScanConfig
		{
			signatureName = "KSHOP_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_19 = new MemorySignatureScanConfig
		{
			signatureName = "KITEM_INFO_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 38,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_20 = new MemorySignatureScanConfig
		{
			signatureName = "KITEM_INFO_KEY",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 2,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 1,
			secondaryResultOffset = 4
		};
		memorySignatureScanConfig_21 = new MemorySignatureScanConfig
		{
			signatureName = "KINFO_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 20,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 17
		};
		memorySignatureScanConfig_22 = new MemorySignatureScanConfig
		{
			signatureName = "KINFO_TEXT",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 33,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 23
		};
		memorySignatureScanConfig_23 = new MemorySignatureScanConfig
		{
			signatureName = "NPC_LEVEL_CAPTION",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 4
		};
		memorySignatureScanConfig_24 = new MemorySignatureScanConfig
		{
			signatureName = "NPC_EXP_1",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 18
		};
		memorySignatureScanConfig_25 = default(MemorySignatureScanConfig);
		memorySignatureScanConfig_26 = new MemorySignatureScanConfig
		{
			signatureName = "NPC_GOLD",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_27 = new MemorySignatureScanConfig
		{
			signatureName = "MAPID_BASE_ADDR",
			primaryResultByteCount = 4,
			primaryMatchCount = 1,
			primaryResultOffset = -4
		};
		memorySignatureScanConfig_28 = new MemorySignatureScanConfig
		{
			signatureName = "MAP_NAME_BASE_ADDR",
			primaryResultByteCount = 4,
			primaryMatchCount = 1,
			primaryResultOffset = 6,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_29 = new MemorySignatureScanConfig
		{
			signatureName = "MAP_NAME_SIZE",
			primaryResultByteCount = 4,
			primaryMatchCount = 1,
			primaryResultOffset = 6,
			moduleRelativeResultEnabled = 0
		};
		memorySignatureScanConfig_30 = new MemorySignatureScanConfig
		{
			signatureName = "KNPC_BASE_SIZE",
			primaryResultByteCount = 4,
			primaryMatchCount = 1,
			primaryResultOffset = 18,
			moduleRelativeResultEnabled = 0
		};
		memorySignatureScanConfig_31 = new MemorySignatureScanConfig
		{
			signatureName = "ATTACK_RANGE",
			primaryResultByteCount = 4,
			primaryMatchCount = 1,
			primaryResultOffset = 2,
			moduleRelativeResultEnabled = 0
		};
		memorySignatureScanConfig_32 = new MemorySignatureScanConfig
		{
			signatureName = "BUFF_BASE_ADDR",
			primaryResultByteCount = 4,
			primaryMatchCount = 1,
			primaryResultOffset = 7,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_33 = new MemorySignatureScanConfig
		{
			signatureName = "BUFF_BASE_SIZE",
			primaryResultByteCount = 4,
			primaryMatchCount = 1,
			primaryResultOffset = 13,
			moduleRelativeResultEnabled = 0
		};
		memorySignatureScanConfig_34 = new MemorySignatureScanConfig
		{
			signatureName = "BUFF_BASE_OFFSET",
			primaryResultByteCount = 1,
			primaryMatchCount = 1,
			primaryResultOffset = 19,
			moduleRelativeResultEnabled = 0
		};
		memorySignatureScanConfig_35 = new MemorySignatureScanConfig
		{
			signatureName = "BUFF_DOING_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 8
		};
		memorySignatureScanConfig_36 = new MemorySignatureScanConfig
		{
			signatureName = "BUFF_SKILL_ID_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 18
		};
		memorySignatureScanConfig_37 = new MemorySignatureScanConfig
		{
			signatureName = "BUFF_POS_X_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 28
		};
		memorySignatureScanConfig_38 = new MemorySignatureScanConfig
		{
			signatureName = "BUFF_POS_Y_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 34
		};
		memorySignatureScanConfig_39 = new MemorySignatureScanConfig
		{
			signatureName = "BUFF_COUNT_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 4
		};
		memorySignatureScanConfig_40 = new MemorySignatureScanConfig
		{
			signatureName = "BUFF_COMPARE_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 4
		};
		memorySignatureScanConfig_41 = new MemorySignatureScanConfig
		{
			signatureName = "BUFF_TIME_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 39
		};
		memorySignatureScanConfig_42 = new MemorySignatureScanConfig
		{
			signatureName = "BUFF_TIME_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_43 = new MemorySignatureScanConfig
		{
			signatureName = "CHAR_FIGHT_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 10
		};
		memorySignatureScanConfig_44 = new MemorySignatureScanConfig
		{
			signatureName = "RIDE_HORSE_OFFSE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 6
		};
		memorySignatureScanConfig_45 = new MemorySignatureScanConfig
		{
			signatureName = "HP1_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 4
		};
		memorySignatureScanConfig_46 = new MemorySignatureScanConfig
		{
			signatureName = "MP1_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 12
		};
		memorySignatureScanConfig_47 = new MemorySignatureScanConfig
		{
			signatureName = "HP2_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 48
		};
		memorySignatureScanConfig_48 = new MemorySignatureScanConfig
		{
			signatureName = "MP2_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 66
		};
		memorySignatureScanConfig_49 = new MemorySignatureScanConfig
		{
			signatureName = "NPC_INDEX_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 17
		};
		memorySignatureScanConfig_50 = new MemorySignatureScanConfig
		{
			signatureName = "NPC_EXISTS_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 16
		};
		memorySignatureScanConfig_51 = new MemorySignatureScanConfig
		{
			resolvedValue = 0u
		};
		memorySignatureScanConfig_52 = new MemorySignatureScanConfig
		{
			resolvedValue = 0u
		};
		memorySignatureScanConfig_53 = new MemorySignatureScanConfig
		{
			resolvedValue = 0u
		};
		memorySignatureScanConfig_54 = new MemorySignatureScanConfig
		{
			signatureName = "NPC_COLOR_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 15
		};
		memorySignatureScanConfig_55 = new MemorySignatureScanConfig
		{
			signatureName = "NPC_DOING_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_56 = new MemorySignatureScanConfig
		{
			signatureName = "KILLER_STATUS_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 35
		};
		memorySignatureScanConfig_57 = new MemorySignatureScanConfig
		{
			signatureName = "POS_BASE_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 17
		};
		memorySignatureScanConfig_58 = new MemorySignatureScanConfig
		{
			signatureName = "POS_X_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 4
		};
		memorySignatureScanConfig_59 = new MemorySignatureScanConfig
		{
			signatureName = "POS_Y_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 7
		};
		memorySignatureScanConfig_60 = new MemorySignatureScanConfig
		{
			signatureName = "KNPC_NAME_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 15
		};
		memorySignatureScanConfig_61 = default(MemorySignatureScanConfig);
		memorySignatureScanConfig_62 = default(MemorySignatureScanConfig);
		memorySignatureScanConfig_63 = default(MemorySignatureScanConfig);
		memorySignatureScanConfig_64 = default(MemorySignatureScanConfig);
		memorySignatureScanConfig_65 = default(MemorySignatureScanConfig);
		memorySignatureScanConfig_66 = new MemorySignatureScanConfig
		{
			signatureName = "NPC_PROFILE_STATUS_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_67 = new MemorySignatureScanConfig
		{
			signatureName = "SCRIPT_LEFT_SKILL_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0
		};
		memorySignatureScanConfig_68 = new MemorySignatureScanConfig
		{
			signatureName = "KPLAYER_LEFT_SKILL",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 66
		};
		memorySignatureScanConfig_69 = new MemorySignatureScanConfig
		{
			signatureName = "SCRIPT_RIGHT_SKILL_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0
		};
		memorySignatureScanConfig_70 = new MemorySignatureScanConfig
		{
			signatureName = "KPLAYER_RIGHT_SKILL",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 63
		};
		memorySignatureScanConfig_71 = new MemorySignatureScanConfig
		{
			signatureName = "TOTAL_POIN_SKILL_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_72 = new MemorySignatureScanConfig
		{
			signatureName = "m_nPeopleIdx",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 15
		};
		memorySignatureScanConfig_73 = new MemorySignatureScanConfig
		{
			signatureName = "MONEY_1_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 4
		};
		memorySignatureScanConfig_74 = new MemorySignatureScanConfig
		{
			signatureName = "MONEY_2_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 18
		};
		memorySignatureScanConfig_75 = new MemorySignatureScanConfig
		{
			signatureName = "MONEY_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 16
		};
		memorySignatureScanConfig_76 = new MemorySignatureScanConfig
		{
			signatureName = "STATS_TOTAL_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 12
		};
		memorySignatureScanConfig_77 = default(MemorySignatureScanConfig);
		memorySignatureScanConfig_78 = default(MemorySignatureScanConfig);
		memorySignatureScanConfig_79 = default(MemorySignatureScanConfig);
		memorySignatureScanConfig_80 = default(MemorySignatureScanConfig);
		memorySignatureScanConfig_81 = default(MemorySignatureScanConfig);
		memorySignatureScanConfig_82 = default(MemorySignatureScanConfig);
		memorySignatureScanConfig_83 = default(MemorySignatureScanConfig);
		memorySignatureScanConfig_84 = default(MemorySignatureScanConfig);
		memorySignatureScanConfig_85 = new MemorySignatureScanConfig
		{
			resolvedValue = 48u
		};
		memorySignatureScanConfig_86 = new MemorySignatureScanConfig
		{
			signatureName = "TONG_GLOBAL_BASE_ADDR"
		};
		memorySignatureScanConfig_87 = new MemorySignatureScanConfig
		{
			signatureName = "TONG_GLOBAL_BASE_SIZE"
		};
		memorySignatureScanConfig_88 = new MemorySignatureScanConfig
		{
			signatureName = "TONG_NAME_2ID",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 9
		};
		memorySignatureScanConfig_89 = new MemorySignatureScanConfig
		{
			signatureName = "TONG_NAME_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2,
			secondaryMatchCount = 1,
			secondaryResultOffset = 2,
			secondaryResultByteCount = 4
		};
		memorySignatureScanConfig_90 = new MemorySignatureScanConfig
		{
			signatureName = "FUNC_SWITCH_KETHOP",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 13,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_91 = new MemorySignatureScanConfig
		{
			signatureName = "SORTCUT_BASE_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_92 = new MemorySignatureScanConfig
		{
			signatureName = "SORTCUT_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 8,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_93 = new MemorySignatureScanConfig
		{
			signatureName = "SORTCUT_NAME_OFF",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 15
		};
		memorySignatureScanConfig_94 = new MemorySignatureScanConfig
		{
			signatureName = "SERVER_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 18,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_95 = new MemorySignatureScanConfig
		{
			signatureName = "SERVER_NAME_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 19,
			secondaryMatchCount = 1,
			secondaryResultOffset = 10,
			secondaryResultByteCount = 4
		};
		memorySignatureScanConfig_96 = new MemorySignatureScanConfig
		{
			signatureName = "CHECK_STATUS_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_97 = new MemorySignatureScanConfig
		{
			signatureName = "KITEM_BASE_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 8
		};
		memorySignatureScanConfig_98 = new MemorySignatureScanConfig
		{
			signatureName = "KITEM_NEXT_SEARCH_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 7
		};
		memorySignatureScanConfig_99 = new MemorySignatureScanConfig
		{
			signatureName = "KITEM_ID_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 12,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 15
		};
		memorySignatureScanConfig_100 = new MemorySignatureScanConfig
		{
			signatureName = "KITEM_POS_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 1,
			secondaryResultOffset = 2
		};
		memorySignatureScanConfig_101 = new MemorySignatureScanConfig
		{
			signatureName = "KITEM_SET_PRICE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 3,
			secondaryMatchCount = 1,
			secondaryResultOffset = 3,
			secondaryResultByteCount = 1
		};
		memorySignatureScanConfig_102 = new MemorySignatureScanConfig
		{
			signatureName = "KPLAYER_MOVEITEM",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0
		};
		memorySignatureScanConfig_103 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_IDKEY",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 9
		};
		memorySignatureScanConfig_104 = new MemorySignatureScanConfig
		{
			signatureName = "FUNC_SHOP_BUY",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 15,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_105 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_BASE_ADD",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_106 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_DATA_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 8
		};
		memorySignatureScanConfig_107 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_NAME_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 15
		};
		memorySignatureScanConfig_108 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_KIND",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_109 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_COLOR",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 13
		};
		memorySignatureScanConfig_110 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_GENRE",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 12
		};
		memorySignatureScanConfig_111 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_WIDTH",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 12
		};
		memorySignatureScanConfig_112 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_HEIGHT",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 8
		};
		memorySignatureScanConfig_113 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_PRICE",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_114 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_LEVEL",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 11
		};
		memorySignatureScanConfig_115 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_SERIES",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 12
		};
		memorySignatureScanConfig_116 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_INTRO",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 10
		};
		memorySignatureScanConfig_117 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_REQUIRE_ATTRIB",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 20
		};
		memorySignatureScanConfig_118 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_MAGIC_ATTRIB",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 20
		};
		memorySignatureScanConfig_119 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_DURATION",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 15
		};
		memorySignatureScanConfig_120 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_LOCK_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 5
		};
		memorySignatureScanConfig_121 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_USE_FUNC_ADD",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0
		};
		memorySignatureScanConfig_122 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_THROW_FUNC_ADD",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0
		};
		memorySignatureScanConfig_123 = new MemorySignatureScanConfig
		{
			signatureName = "ITEM_HOLD_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 11,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 10
		};
		memorySignatureScanConfig_124 = new MemorySignatureScanConfig
		{
			signatureName = "OBJECT_COUNT_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 9,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_125 = new MemorySignatureScanConfig
		{
			signatureName = "OBJECT_COUNT_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 11
		};
		memorySignatureScanConfig_126 = new MemorySignatureScanConfig
		{
			signatureName = "OBJECT_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 8
		};
		memorySignatureScanConfig_127 = new MemorySignatureScanConfig
		{
			signatureName = "OBJECT_BASE_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_128 = new MemorySignatureScanConfig
		{
			signatureName = "OBJECT_KIND_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 15
		};
		memorySignatureScanConfig_129 = new MemorySignatureScanConfig
		{
			signatureName = "OBJECT_COLOR_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 80
		};
		memorySignatureScanConfig_130 = new MemorySignatureScanConfig
		{
			signatureName = "OBJECT_SIZE_X_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 46
		};
		memorySignatureScanConfig_131 = new MemorySignatureScanConfig
		{
			signatureName = "OBJECT_SIZE_Y_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 67
		};
		memorySignatureScanConfig_132 = new MemorySignatureScanConfig
		{
			signatureName = "OBJECT_STACKCOUNT_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 13
		};
		memorySignatureScanConfig_133 = new MemorySignatureScanConfig
		{
			signatureName = "OBJECT_POS_X",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 8
		};
		memorySignatureScanConfig_134 = new MemorySignatureScanConfig
		{
			signatureName = "OBJECT_POS_Y",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_135 = new MemorySignatureScanConfig
		{
			signatureName = "m_nObjectIdx",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 9
		};
		memorySignatureScanConfig_136 = new MemorySignatureScanConfig
		{
			signatureName = "OBJECT_SERI_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 3
		};
		memorySignatureScanConfig_137 = new MemorySignatureScanConfig
		{
			signatureName = "OBJECT_TIME_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_138 = new MemorySignatureScanConfig
		{
			signatureName = "OBJECT_NAME_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 12
		};
		memorySignatureScanConfig_139 = new MemorySignatureScanConfig
		{
			signatureName = "OBJECT_TYPE_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_140 = new MemorySignatureScanConfig
		{
			signatureName = "OBJ_EXIST",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 14
		};
		memorySignatureScanConfig_141 = new MemorySignatureScanConfig
		{
			signatureName = "OBJ_GROWN",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 10
		};
		memorySignatureScanConfig_142 = new MemorySignatureScanConfig
		{
			signatureName = "PICKUP_OBJECT_FUNC_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0
		};
		memorySignatureScanConfig_143 = new MemorySignatureScanConfig
		{
			signatureName = "MENU_00_01_FLAG_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_144 = new MemorySignatureScanConfig
		{
			signatureName = "FUNC_MENU_0_CLICK_INDEX",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 0,
			secondaryResultOffset = 0
		};
		memorySignatureScanConfig_145 = new MemorySignatureScanConfig
		{
			signatureName = "FUNC_MENU_1_CLICK_INDEX",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 0,
			secondaryResultOffset = -1
		};
		memorySignatureScanConfig_146 = new MemorySignatureScanConfig
		{
			signatureName = "MENU_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 2
		};
		memorySignatureScanConfig_147 = new MemorySignatureScanConfig
		{
			signatureName = "MENU_0_COUNT_BASE_OFFSET",
			primaryMatchCount = 1,
			secondaryMatchCount = 1,
			primaryResultByteCount = 4,
			secondaryResultByteCount = 4,
			primaryResultOffset = 2,
			secondaryResultOffset = -4,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_148 = new MemorySignatureScanConfig
		{
			signatureName = "MENU_0_COUNT_SIZE",
			primaryMatchCount = 1,
			secondaryMatchCount = 1,
			primaryResultByteCount = 4,
			secondaryResultByteCount = 4,
			primaryResultOffset = 20,
			secondaryResultOffset = 11
		};
		memorySignatureScanConfig_149 = new MemorySignatureScanConfig
		{
			signatureName = "MENU_1_COUNT_BASE_OFFSET",
			primaryMatchCount = 1,
			secondaryMatchCount = 1,
			primaryResultByteCount = 4,
			secondaryResultByteCount = 4,
			primaryResultOffset = 2,
			secondaryResultOffset = -4,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_150 = new MemorySignatureScanConfig
		{
			signatureName = "MENU_1_COUNT_SIZE",
			primaryMatchCount = 2,
			primaryResultByteCount = 4,
			primaryResultOffset = 20,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 2
		};
		memorySignatureScanConfig_151 = new MemorySignatureScanConfig
		{
			signatureName = "MENU_1_VISABLE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_152 = new MemorySignatureScanConfig
		{
			signatureName = "DIALOG_FUNC_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 15,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 2,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_153 = new MemorySignatureScanConfig
		{
			signatureName = "DIALOG_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 21,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_154 = new MemorySignatureScanConfig
		{
			signatureName = "DIALOG_INDEX_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_155 = new MemorySignatureScanConfig
		{
			signatureName = "DIALOG_COUNT_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 8
		};
		memorySignatureScanConfig_156 = new MemorySignatureScanConfig
		{
			signatureName = "DIALOG_TEXT_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 2,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 1,
			secondaryResultOffset = 2
		};
		memorySignatureScanConfig_157 = new MemorySignatureScanConfig
		{
			signatureName = "DIALOG_TEXT_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 2
		};
		memorySignatureScanConfig_158 = new MemorySignatureScanConfig
		{
			signatureName = "BOX_THUTHAP_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = -4,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_159 = new MemorySignatureScanConfig
		{
			signatureName = "BOX_THUTHAP_SHOW",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_160 = new MemorySignatureScanConfig
		{
			signatureName = "SKILL_DIRECT_SHORTCUT_BASE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 5,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_161 = new MemorySignatureScanConfig
		{
			signatureName = "SKILL_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 16
		};
		memorySignatureScanConfig_162 = new MemorySignatureScanConfig
		{
			signatureName = "SKILL_START_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_163 = new MemorySignatureScanConfig
		{
			signatureName = "SKILL_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 12
		};
		memorySignatureScanConfig_164 = new MemorySignatureScanConfig
		{
			signatureName = "SKILL_INC_LEVEL_FUNC_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 21,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 20,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_165 = new MemorySignatureScanConfig
		{
			signatureName = "SMS_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 8
		};
		memorySignatureScanConfig_166 = new MemorySignatureScanConfig
		{
			signatureName = "SMS_BASE_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 15
		};
		memorySignatureScanConfig_167 = new MemorySignatureScanConfig
		{
			signatureName = "SMS_TEXT_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 15,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 1,
			secondaryResultOffset = 3
		};
		memorySignatureScanConfig_168 = new MemorySignatureScanConfig
		{
			signatureName = "SMS_FLAG_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 3,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 6
		};
		memorySignatureScanConfig_169 = new MemorySignatureScanConfig
		{
			signatureName = "CLEAR_SMS_FUNC_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 19,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 6,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_170 = new MemorySignatureScanConfig
		{
			resolvedValue = 1100u
		};
		memorySignatureScanConfig_171 = new MemorySignatureScanConfig
		{
			signatureName = "BOX_TEXT_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 5
		};
		memorySignatureScanConfig_172 = new MemorySignatureScanConfig
		{
			signatureName = "BOX_GLOBAL_ENTER_NUMBER",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 6,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_173 = new MemorySignatureScanConfig
		{
			signatureName = "BOX_GLOBAL_ENTER_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 12
		};
		memorySignatureScanConfig_174 = new MemorySignatureScanConfig
		{
			signatureName = "FLAG_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 12,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_175 = new MemorySignatureScanConfig
		{
			signatureName = "FLAG_BOX_TITLE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 23,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_176 = new MemorySignatureScanConfig
		{
			signatureName = "FLAG_BOXENTER_FUNC_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 29,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_177 = new MemorySignatureScanConfig
		{
			signatureName = "BOX_VANSUTHONG_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 11,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_178 = new MemorySignatureScanConfig
		{
			signatureName = "FLAG_IS_STICK",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 5,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_179 = new MemorySignatureScanConfig
		{
			signatureName = "BOX_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 6,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_180 = new MemorySignatureScanConfig
		{
			signatureName = "BOX_BASE_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 14,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 15
		};
		memorySignatureScanConfig_181 = new MemorySignatureScanConfig
		{
			signatureName = "BOX_OPEN_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 17,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 1,
			secondaryResultOffset = 14
		};
		memorySignatureScanConfig_182 = new MemorySignatureScanConfig
		{
			signatureName = "OPEN_FUNC_SPEC",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0
		};
		memorySignatureScanConfig_183 = new MemorySignatureScanConfig
		{
			signatureName = "BOX_COUNT_ITEM_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 6
		};
		memorySignatureScanConfig_184 = new MemorySignatureScanConfig
		{
			signatureName = "BOX_COUNT_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_185 = new MemorySignatureScanConfig
		{
			signatureName = "BOX_ACCEPT_FUNC",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 18,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_186 = new MemorySignatureScanConfig
		{
			signatureName = "BOX_INC_POINT_FUNC_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 14,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 7,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_187 = new MemorySignatureScanConfig
		{
			signatureName = "BOX_UNLOCK_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_188 = new MemorySignatureScanConfig
		{
			signatureName = "TONG_ENTER_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_189 = new MemorySignatureScanConfig
		{
			signatureName = "TONG_BASE_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 9
		};
		memorySignatureScanConfig_190 = new MemorySignatureScanConfig
		{
			signatureName = "TONG_PUSH_MONEY_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 8
		};
		memorySignatureScanConfig_191 = new MemorySignatureScanConfig
		{
			signatureName = "TONG_PUSH_MONEY_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = -4,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_192 = new MemorySignatureScanConfig
		{
			signatureName = "TONG_PUSH_MONEY_FUNC",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 1,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_193 = new MemorySignatureScanConfig
		{
			signatureName = "TONG_BASE_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 8,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_194 = new MemorySignatureScanConfig
		{
			signatureName = "TONG_FUNC_GET_BASE_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 13,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_195 = new MemorySignatureScanConfig
		{
			signatureName = "TONG_FUNC_ACCEPT_CHANGE_COLOR",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = -19
		};
		memorySignatureScanConfig_196 = new MemorySignatureScanConfig
		{
			signatureName = "TONG_SPEC_FUNC",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0
		};
		memorySignatureScanConfig_197 = new MemorySignatureScanConfig
		{
			signatureName = "TONG_TUYENCHI_BASE_ADDR"
		};
		memorySignatureScanConfig_198 = new MemorySignatureScanConfig
		{
			resolvedValue = 32u
		};
		memorySignatureScanConfig_199 = new MemorySignatureScanConfig
		{
			resolvedValue = 4u
		};
		memorySignatureScanConfig_200 = default(MemorySignatureScanConfig);
		memorySignatureScanConfig_201 = new MemorySignatureScanConfig
		{
			signatureName = "TEAM_CREATE",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_202 = new MemorySignatureScanConfig
		{
			signatureName = "TEAM_MEMBER",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_203 = new MemorySignatureScanConfig
		{
			signatureName = "TEAM_LIST_NAME_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 13,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_204 = new MemorySignatureScanConfig
		{
			signatureName = "TEAM_CAPTAIN_NAME_OFF",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 14
		};
		memorySignatureScanConfig_205 = new MemorySignatureScanConfig
		{
			signatureName = "TEAM_CAPTAIN_NAME_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 19
		};
		memorySignatureScanConfig_206 = new MemorySignatureScanConfig
		{
			signatureName = "TEAM_LEAVE_FUNC_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0
		};
		memorySignatureScanConfig_207 = new MemorySignatureScanConfig
		{
			signatureName = "LASTCHANEL_TOP_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 12
		};
		memorySignatureScanConfig_208 = new MemorySignatureScanConfig
		{
			signatureName = "LASTCHANEL_BOTTOM_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 17
		};
		memorySignatureScanConfig_209 = new MemorySignatureScanConfig
		{
			signatureName = "LASTCHANEL_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 12
		};
		memorySignatureScanConfig_210 = new MemorySignatureScanConfig
		{
			signatureName = "LASTCHANEL_FUNC",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 1,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_211 = new MemorySignatureScanConfig
		{
			signatureName = "LASTCHANEL_COUNT_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_212 = new MemorySignatureScanConfig
		{
			signatureName = "LASTCHANEL_GETTEXT_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 11
		};
		memorySignatureScanConfig_213 = new MemorySignatureScanConfig
		{
			signatureName = "LASTCHANEL_TEXT_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 43
		};
		memorySignatureScanConfig_214 = new MemorySignatureScanConfig
		{
			signatureName = "LASTCHANEL_ITEM_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 2
		};
		memorySignatureScanConfig_215 = new MemorySignatureScanConfig
		{
			signatureName = "LASTCHANEL_TABBUTTON_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_216 = new MemorySignatureScanConfig
		{
			signatureName = "LASTCHANEL_TABBUTTON_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 12
		};
		memorySignatureScanConfig_217 = new MemorySignatureScanConfig
		{
			signatureName = "PLAYER_CHAT_FUNC_ADD",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 30,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 18,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_218 = new MemorySignatureScanConfig
		{
			signatureName = "PLAYER_SAY_FUNC_ADDR",
			primaryMatchCount = 1,
			secondaryMatchCount = 1,
			primaryResultByteCount = 4,
			secondaryResultByteCount = 4,
			primaryResultOffset = 1,
			secondaryResultOffset = 1,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_219 = new MemorySignatureScanConfig
		{
			signatureName = "PLAYER_PRINT_FUNC_ADD",
			primaryMatchCount = 1,
			secondaryMatchCount = 1,
			primaryResultByteCount = 4,
			secondaryResultByteCount = 4,
			primaryResultOffset = 20,
			secondaryResultOffset = 8,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_220 = new MemorySignatureScanConfig
		{
			signatureName = "REPLY_INVITE_FUNC_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0
		};
		memorySignatureScanConfig_221 = new MemorySignatureScanConfig
		{
			signatureName = "DOSCRIPT_FUNC_ADD",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 15,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_222 = new MemorySignatureScanConfig
		{
			signatureName = "CLICKTO_FUNC_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0
		};
		memorySignatureScanConfig_223 = new MemorySignatureScanConfig
		{
			signatureName = "RUNTO_FUNC_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0
		};
		memorySignatureScanConfig_224 = new MemorySignatureScanConfig
		{
			signatureName = "FUNC_SPEC_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 16
		};
		memorySignatureScanConfig_225 = new MemorySignatureScanConfig
		{
			signatureName = "FUNC_SPEC_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 21,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_226 = new MemorySignatureScanConfig
		{
			signatureName = "TRADE_FUNC_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 1,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_227 = new MemorySignatureScanConfig
		{
			signatureName = "TRADE_ACCEPT_FUNC_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0
		};
		memorySignatureScanConfig_228 = new MemorySignatureScanConfig
		{
			signatureName = "TRADE_APPLY_FUNC_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0
		};
		memorySignatureScanConfig_229 = new MemorySignatureScanConfig
		{
			signatureName = "TRADE_PUT_MONEY_FUNC_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 0
		};
		memorySignatureScanConfig_230 = new MemorySignatureScanConfig
		{
			signatureName = "TRADE_GET_MONEY_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 19
		};
		memorySignatureScanConfig_231 = new MemorySignatureScanConfig
		{
			signatureName = "TRADE_PUT_MONEY_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 7
		};
		memorySignatureScanConfig_232 = new MemorySignatureScanConfig
		{
			signatureName = "KYTRANCAC_CLOSE_FUNC",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 3,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 3,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_233 = new MemorySignatureScanConfig
		{
			signatureName = "FOLLOW_INDEX_FUNC_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 14,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_234 = new MemorySignatureScanConfig
		{
			signatureName = "RETURNCITY_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 26,
			secondaryMatchCount = 1,
			secondaryResultOffset = 16,
			secondaryResultByteCount = 4,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_235 = new MemorySignatureScanConfig
		{
			signatureName = "RETURNCITY_SIZE",
			primaryMatchCount = 2,
			primaryResultByteCount = 4,
			primaryResultOffset = 38,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 29
		};
		memorySignatureScanConfig_236 = new MemorySignatureScanConfig
		{
			signatureName = "KSHOP_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_237 = new MemorySignatureScanConfig
		{
			signatureName = "REPAIR_FUNC",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 7,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_238 = new MemorySignatureScanConfig
		{
			signatureName = "REPAIR_MONEY_FUNC",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 1,
			relativeCallResultEnabled = 1
		};
		memorySignatureScanConfig_239 = new MemorySignatureScanConfig
		{
			signatureName = "HELP_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 7,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 4,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_240 = new MemorySignatureScanConfig
		{
			signatureName = "HELP_BASE_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 13,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 10
		};
		memorySignatureScanConfig_241 = new MemorySignatureScanConfig
		{
			signatureName = "HELP_COUNT_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 4,
			secondaryResultOffset = 2
		};
		memorySignatureScanConfig_242 = new MemorySignatureScanConfig
		{
			signatureName = "STRING_INPUT_SIZE",
			primaryResultByteCount = 4,
			primaryMatchCount = 1,
			primaryResultOffset = 7
		};
		memorySignatureScanConfig_243 = new MemorySignatureScanConfig
		{
			signatureName = "MAP_EXIST_SIZE",
			primaryResultByteCount = 4,
			primaryMatchCount = 1,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_244 = new MemorySignatureScanConfig
		{
			signatureName = "MAP_NEXT_SIZE",
			primaryResultByteCount = 4,
			primaryMatchCount = 1,
			primaryResultOffset = 29
		};
		memorySignatureScanConfig_245 = new MemorySignatureScanConfig
		{
			signatureName = "CPU_GIAM_MUC_1",
			primaryResultByteCount = 0,
			primaryMatchCount = 1,
			primaryResultOffset = 13
		};
		memorySignatureScanConfig_246 = new MemorySignatureScanConfig
		{
			signatureName = "CPU_GIAM_MUC_2",
			primaryResultByteCount = 0,
			primaryMatchCount = 1,
			primaryResultOffset = 4
		};
		memorySignatureScanConfig_247 = new MemorySignatureScanConfig
		{
			signatureName = "CPU_SLEEP_1",
			primaryResultByteCount = 0,
			primaryMatchCount = 1,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_248 = new MemorySignatureScanConfig
		{
			signatureName = "CPU_SLEEP_2",
			primaryResultByteCount = 0,
			primaryMatchCount = 1,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_249 = new MemorySignatureScanConfig
		{
			signatureName = "CPU_SLEEP_3",
			primaryResultByteCount = 0,
			primaryMatchCount = 2,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_250 = new MemorySignatureScanConfig
		{
			signatureName = "FLAG_SHOW_GAME",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 9
		};
		memorySignatureScanConfig_251 = new MemorySignatureScanConfig
		{
			signatureName = "DANHHIEU_STATUS_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_252 = new MemorySignatureScanConfig
		{
			signatureName = "TONGKIM_SOLUONG_NGUOI",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_253 = new MemorySignatureScanConfig
		{
			signatureName = "GET_TICK_COUNT",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 9,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_254 = new MemorySignatureScanConfig
		{
			signatureName = "TONGKIM_THOIGIAN_BATDAU",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 10,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_255 = new MemorySignatureScanConfig
		{
			signatureName = "TONGKIM_THOIGIAN_HIENTAI",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_256 = new MemorySignatureScanConfig
		{
			signatureName = "TONGKIM_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = -4,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_257 = new MemorySignatureScanConfig
		{
			signatureName = "TONGKIM_PLAYER_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_258 = new MemorySignatureScanConfig
		{
			signatureName = "TONGKIM_POINT_MAX_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 1,
			primaryResultOffset = 2
		};
		memorySignatureScanConfig_259 = new MemorySignatureScanConfig
		{
			signatureName = "GATEWAY_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 5,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_260 = new MemorySignatureScanConfig
		{
			signatureName = "GATEWAY_CONNECT_OFFSET",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 2,
			secondaryResultByteCount = 4,
			secondaryMatchCount = 1,
			secondaryResultOffset = 2
		};
		memorySignatureScanConfig_261 = new MemorySignatureScanConfig
		{
			signatureName = "BOX_SHORTCUT_SIZE",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 29
		};
		memorySignatureScanConfig_262 = new MemorySignatureScanConfig
		{
			signatureName = "BOX_CHETAO_BASE_ADDR",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 13,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_263 = new MemorySignatureScanConfig
		{
			signatureName = "SKILL_INFO_BASE_0_ADDR",
			primaryBytePattern = "81 ?? ?? ?? ?? ?? 0F 87 ?? ?? ?? ?? 8B ?? C1 ?? 08 8B",
			primaryMatchCount = 1,
			primaryResultByteCount = 4,
			primaryResultOffset = 19,
			moduleRelativeResultEnabled = 1
		};
		memorySignatureScanConfig_264 = new MemorySignatureScanConfig
		{
			signatureName = "FUNC_MENU_0_CLOSE"
		};
		memorySignatureScanConfig_265 = new MemorySignatureScanConfig
		{
			signatureName = "QUEST_BASE_ADDR"
		};
		memorySignatureScanConfig_266 = new MemorySignatureScanConfig
		{
			signatureName = "QUEST_PRISE_0_SIZE"
		};
		memorySignatureScanConfig_267 = new MemorySignatureScanConfig
		{
			signatureName = "QUEST_PRISE_1_SIZE"
		};
		memorySignatureScanConfig_268 = new MemorySignatureScanConfig
		{
			signatureName = "QUEST_PRISE_2_SIZE"
		};
		memorySignatureDataValid = false;
		memorySignatureLoadCompleted = false;
		missingSignatureIndexes = null;
		memorySignatureDiagnostics = null;
		int_7 = 0;
		int_8 = 0;
		int[,] array_ = new int[5, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_, 254326);
		fiveValueConfigurationTable = array_;
		int[,] array_2 = new int[5, 10];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_2, 254435);
		tenValueConfigurationTable = array_2;
		memorySignatureScanConfig_269 = new MemorySignatureScanConfig
		{
			signatureName = "represent2.dll",
			primaryMatchCount = 1,
			primaryResultByteCount = 0,
			primaryResultOffset = 3,
			secondaryMatchCount = 1,
			secondaryResultByteCount = 0,
			secondaryResultOffset = 7
		};
	}

	public static string FindFirstConfiguredWindowExecutablePath()
	{
		string text = string.Empty;
		int[] array = WindowsInteropHelper.FindMatchingWindowProcessIds(gameWindowClassName);
		if (array != null && array.Length != 0)
		{
			for (int i = 0; i < array.Length; i++)
			{
				try
				{
					Process processById = Process.GetProcessById(array[i]);
					text = processById.MainModule.FileName;
					if (text != null && text != string.Empty)
					{
						return text;
					}
				}
				catch
				{
				}
			}
		}
		return text;
	}

	public static ItemAttributeFilterRule[] CreateDefaultItemAttributeFilterRules()
	{
		return new ItemAttributeFilterRule[59]
		{
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 43,
				int_2 = 0,
				string_0 = "Không thể phá hủy"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 139,
				int_2 = 0,
				string_0 = "Kỹ năng  Võ công vốn có"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 58,
				int_2 = 1,
				string_0 = "Bỏ qua né tránh: (x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 117,
				int_2 = 15,
				string_0 = "Phản đòn cận chiến: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 120,
				int_2 = 5,
				string_0 = "Phản đòn tầm xa: +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 134,
				int_2 = 8,
				string_0 = "Chuyển hóa sát thương thành nội lực: +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 135,
				int_2 = 1,
				string_0 = "May mắn: +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 166,
				int_2 = 250,
				string_0 = "Tỉ lệ công kích chính xác: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 111,
				int_2 = 25,
				string_0 = "Tốc độ di chuyển: +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 115,
				int_2 = 10,
				string_0 = "Tốc độ đánh - ngoại công: +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 116,
				int_2 = 30,
				string_0 = "Tốc độ đánh - nội công: +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 239,
				int_2 = 200,
				string_0 = "Tốc độ đánh - ngoại công (Dương): +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 240,
				int_2 = 140,
				string_0 = "Tốc độ đánh - nội công (Dương): +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 114,
				int_2 = 10,
				string_0 = "Kháng tất cả: +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 136,
				int_2 = 3,
				string_0 = "Hút sinh lực: +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 137,
				int_2 = 3,
				string_0 = "Hút nội lực: +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 106,
				int_2 = 30,
				string_0 = "Thời gian làm chậm: -(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 110,
				int_2 = 30,
				string_0 = "Thời gian choáng: -(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 108,
				int_2 = 30,
				string_0 = "Thời gian trúng độc: -(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 113,
				int_2 = 30,
				string_0 = "Thời gian phục hồi: -(x)"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 245,
				int_2 = 80,
				string_0 = "Thời gian phục hồi (Dương): -(x)"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 237,
				int_2 = 60,
				string_0 = "Triệt tiêu sát thương (Dương): +(x)"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 104,
				int_2 = 15,
				string_0 = "Phòng thủ vật lý: +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 101,
				int_2 = 25,
				string_0 = "Kháng độc: +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 102,
				int_2 = 20,
				string_0 = "Kháng hỏa: +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 103,
				int_2 = 20,
				string_0 = "Kháng lôi: +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 105,
				int_2 = 20,
				string_0 = "Kháng băng: +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 121,
				int_2 = 50,
				string_0 = "Sát thương vật lý - ngoại công: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 126,
				int_2 = 80,
				string_0 = "Sát thương vật lý - ngoại công: +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 168,
				int_2 = 100,
				string_0 = "Sát thương vật lý - nội công: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 244,
				int_2 = 80,
				string_0 = "Sát thương vật lý - nội công: +(x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 123,
				int_2 = 50,
				string_0 = "Băng sát - ngoại công: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 169,
				int_2 = 80,
				string_0 = "Băng sát - nội công: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 122,
				int_2 = 50,
				string_0 = "Hỏa sát - ngoại công: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 170,
				int_2 = 80,
				string_0 = "Hỏa sát - nội công: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 124,
				int_2 = 50,
				string_0 = "Lôi sát - ngoại công: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 171,
				int_2 = 80,
				string_0 = "Lôi sát - nội công: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 125,
				int_2 = 15,
				string_0 = "Độc sát - ngoại công: +(x) điểm/lần"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 172,
				int_2 = 15,
				string_0 = "Độc sát - nội công: +(x) điểm/lần"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 85,
				int_2 = 100,
				string_0 = "Sinh lực tối đa: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 99,
				int_2 = 10,
				string_0 = "Sinh khí: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 89,
				int_2 = 100,
				string_0 = "Nội lực tối đa: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 100,
				int_2 = 10,
				string_0 = "Nội công: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 93,
				int_2 = 160,
				string_0 = "Thể lực tối đa: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 97,
				int_2 = 10,
				string_0 = "Sức mạnh: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 98,
				int_2 = 10,
				string_0 = "Thân pháp: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 88,
				int_2 = 3,
				string_0 = "Phục hồi sinh lực mỗi nửa giây: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 1,
				int_1 = 92,
				int_2 = 1,
				string_0 = "Phục hồi nội lực mỗi nửa giây: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 96,
				int_2 = 5,
				string_0 = "Phục hồi thể lực mỗi nửa giây: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 220,
				int_2 = 8,
				string_0 = "Tạo thành thời gian choáng: (x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 219,
				int_2 = 40,
				string_0 = "Tạo thành sát thương có thời gian hoạt động: +(x) điểm"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 221,
				int_2 = 15,
				string_0 = "Xem nhẹ độc phòng của đối phương: (x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 222,
				int_2 = 15,
				string_0 = "Xem nhẹ hỏa phòng của đối phương: (x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 223,
				int_2 = 15,
				string_0 = "Xem nhẹ lôi phòng của đối phương: (x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 224,
				int_2 = 15,
				string_0 = "Xem nhẹ phổ phòng của đối phương: (x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 225,
				int_2 = 15,
				string_0 = "Xem nhẹ băng phòng của đối phương: (x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 70,
				int_2 = 5,
				string_0 = "Tấn công chí mạng: (x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 226,
				int_2 = 10,
				string_0 = "Xác suất hóa giải sát thương: (x) %"
			},
			new ItemAttributeFilterRule
			{
				int_0 = 0,
				int_1 = 227,
				int_2 = 8,
				string_0 = "Xác suất trọng kích: (x) %"
			}
		};
	}

	private static MemorySignatureScanConfig[] GetAllMemorySignatureScanConfigs()
	{
		return new MemorySignatureScanConfig[254]
		{
			GameCrashFixPatcher.memorySignatureScanConfig_16,
			GameCrashFixPatcher.memorySignatureScanConfig_17,
			GameCrashFixPatcher.memorySignatureScanConfig_18,
			GameCrashFixPatcher.memorySignatureScanConfig_19,
			GameCrashFixPatcher.memorySignatureScanConfig_20,
			GameCrashFixPatcher.memorySignatureScanConfig_21,
			GameCrashFixPatcher.memorySignatureScanConfig_22,
			GameCrashFixPatcher.memorySignatureScanConfig_23,
			GameCrashFixPatcher.memorySignatureScanConfig_24,
			GameCrashFixPatcher.memorySignatureScanConfig_25,
			GameCrashFixPatcher.memorySignatureScanConfig_26,
			GameCrashFixPatcher.memorySignatureScanConfig_27,
			GameCrashFixPatcher.memorySignatureScanConfig_28,
			GameCrashFixPatcher.memorySignatureScanConfig_29,
			GameCrashFixPatcher.memorySignatureScanConfig_30,
			GameCrashFixPatcher.memorySignatureScanConfig_31,
			memorySignatureScanConfig_259,
			memorySignatureScanConfig_260,
			memorySignatureScanConfig_1,
			memorySignatureScanConfig_250,
			memorySignatureScanConfig_262,
			memorySignatureScanConfig_247,
			memorySignatureScanConfig_248,
			memorySignatureScanConfig_249,
			memorySignatureScanConfig_245,
			memorySignatureScanConfig_246,
			memorySignatureScanConfig_243,
			memorySignatureScanConfig_244,
			memorySignatureScanConfig_242,
			memorySignatureScanConfig_261,
			memorySignatureScanConfig_4,
			memorySignatureScanConfig_2,
			memorySignatureScanConfig_3,
			memorySignatureScanConfig_6,
			memorySignatureScanConfig_5,
			memorySignatureScanConfig_7,
			memorySignatureScanConfig_251,
			memorySignatureScanConfig_252,
			memorySignatureScanConfig_253,
			memorySignatureScanConfig_254,
			memorySignatureScanConfig_255,
			memorySignatureScanConfig_256,
			memorySignatureScanConfig_257,
			memorySignatureScanConfig_258,
			memorySignatureScanConfig_11,
			memorySignatureScanConfig_12,
			memorySignatureScanConfig_13,
			memorySignatureScanConfig_18,
			memorySignatureScanConfig_19,
			memorySignatureScanConfig_20,
			memorySignatureScanConfig_21,
			memorySignatureScanConfig_22,
			memorySignatureScanConfig_9,
			memorySignatureScanConfig_10,
			memorySignatureScanConfig_14,
			memorySignatureScanConfig_15,
			memorySignatureScanConfig_16,
			memorySignatureScanConfig_17,
			memorySignatureScanConfig_23,
			memorySignatureScanConfig_26,
			memorySignatureScanConfig_27,
			memorySignatureScanConfig_28,
			memorySignatureScanConfig_29,
			memorySignatureScanConfig_30,
			memorySignatureScanConfig_31,
			memorySignatureScanConfig_32,
			memorySignatureScanConfig_33,
			memorySignatureScanConfig_34,
			memorySignatureScanConfig_35,
			memorySignatureScanConfig_36,
			memorySignatureScanConfig_37,
			memorySignatureScanConfig_38,
			memorySignatureScanConfig_39,
			memorySignatureScanConfig_40,
			memorySignatureScanConfig_41,
			memorySignatureScanConfig_42,
			memorySignatureScanConfig_43,
			memorySignatureScanConfig_44,
			memorySignatureScanConfig_45,
			memorySignatureScanConfig_46,
			memorySignatureScanConfig_47,
			memorySignatureScanConfig_48,
			memorySignatureScanConfig_49,
			memorySignatureScanConfig_50,
			memorySignatureScanConfig_54,
			memorySignatureScanConfig_55,
			memorySignatureScanConfig_56,
			memorySignatureScanConfig_57,
			memorySignatureScanConfig_58,
			memorySignatureScanConfig_59,
			memorySignatureScanConfig_60,
			memorySignatureScanConfig_66,
			memorySignatureScanConfig_72,
			memorySignatureScanConfig_73,
			memorySignatureScanConfig_74,
			memorySignatureScanConfig_75,
			memorySignatureScanConfig_233,
			memorySignatureScanConfig_76,
			memorySignatureScanConfig_90,
			memorySignatureScanConfig_91,
			memorySignatureScanConfig_92,
			memorySignatureScanConfig_93,
			memorySignatureScanConfig_94,
			memorySignatureScanConfig_95,
			memorySignatureScanConfig_96,
			memorySignatureScanConfig_234,
			memorySignatureScanConfig_235,
			memorySignatureScanConfig_97,
			memorySignatureScanConfig_98,
			memorySignatureScanConfig_99,
			memorySignatureScanConfig_100,
			memorySignatureScanConfig_101,
			memorySignatureScanConfig_102,
			memorySignatureScanConfig_105,
			memorySignatureScanConfig_106,
			memorySignatureScanConfig_107,
			memorySignatureScanConfig_108,
			memorySignatureScanConfig_109,
			memorySignatureScanConfig_111,
			memorySignatureScanConfig_112,
			memorySignatureScanConfig_110,
			memorySignatureScanConfig_113,
			memorySignatureScanConfig_114,
			memorySignatureScanConfig_115,
			memorySignatureScanConfig_116,
			memorySignatureScanConfig_118,
			memorySignatureScanConfig_117,
			memorySignatureScanConfig_119,
			memorySignatureScanConfig_120,
			memorySignatureScanConfig_121,
			memorySignatureScanConfig_122,
			memorySignatureScanConfig_123,
			memorySignatureScanConfig_103,
			memorySignatureScanConfig_104,
			memorySignatureScanConfig_124,
			memorySignatureScanConfig_125,
			memorySignatureScanConfig_126,
			memorySignatureScanConfig_127,
			memorySignatureScanConfig_128,
			memorySignatureScanConfig_129,
			memorySignatureScanConfig_130,
			memorySignatureScanConfig_131,
			memorySignatureScanConfig_132,
			memorySignatureScanConfig_133,
			memorySignatureScanConfig_134,
			memorySignatureScanConfig_135,
			memorySignatureScanConfig_136,
			memorySignatureScanConfig_137,
			memorySignatureScanConfig_138,
			memorySignatureScanConfig_139,
			memorySignatureScanConfig_140,
			memorySignatureScanConfig_141,
			memorySignatureScanConfig_142,
			memorySignatureScanConfig_143,
			memorySignatureScanConfig_145,
			memorySignatureScanConfig_144,
			memorySignatureScanConfig_146,
			memorySignatureScanConfig_147,
			memorySignatureScanConfig_148,
			memorySignatureScanConfig_149,
			memorySignatureScanConfig_150,
			memorySignatureScanConfig_151,
			memorySignatureScanConfig_153,
			memorySignatureScanConfig_155,
			memorySignatureScanConfig_154,
			memorySignatureScanConfig_152,
			memorySignatureScanConfig_156,
			memorySignatureScanConfig_157,
			memorySignatureScanConfig_158,
			memorySignatureScanConfig_159,
			memorySignatureScanConfig_263,
			memorySignatureScanConfig_160,
			memorySignatureScanConfig_67,
			memorySignatureScanConfig_68,
			memorySignatureScanConfig_69,
			memorySignatureScanConfig_70,
			memorySignatureScanConfig_71,
			memorySignatureScanConfig_161,
			memorySignatureScanConfig_163,
			memorySignatureScanConfig_162,
			memorySignatureScanConfig_164,
			memorySignatureScanConfig_165,
			memorySignatureScanConfig_166,
			memorySignatureScanConfig_167,
			memorySignatureScanConfig_168,
			memorySignatureScanConfig_169,
			memorySignatureScanConfig_179,
			memorySignatureScanConfig_180,
			memorySignatureScanConfig_181,
			memorySignatureScanConfig_182,
			memorySignatureScanConfig_183,
			memorySignatureScanConfig_184,
			memorySignatureScanConfig_185,
			memorySignatureScanConfig_186,
			memorySignatureScanConfig_187,
			memorySignatureScanConfig_232,
			memorySignatureScanConfig_236,
			memorySignatureScanConfig_237,
			memorySignatureScanConfig_238,
			memorySignatureScanConfig_171,
			memorySignatureScanConfig_172,
			memorySignatureScanConfig_173,
			memorySignatureScanConfig_174,
			memorySignatureScanConfig_175,
			memorySignatureScanConfig_176,
			memorySignatureScanConfig_177,
			memorySignatureScanConfig_178,
			memorySignatureScanConfig_188,
			memorySignatureScanConfig_89,
			memorySignatureScanConfig_88,
			memorySignatureScanConfig_189,
			memorySignatureScanConfig_190,
			memorySignatureScanConfig_191,
			memorySignatureScanConfig_192,
			memorySignatureScanConfig_196,
			memorySignatureScanConfig_193,
			memorySignatureScanConfig_194,
			memorySignatureScanConfig_195,
			memorySignatureScanConfig_201,
			memorySignatureScanConfig_202,
			memorySignatureScanConfig_203,
			memorySignatureScanConfig_204,
			memorySignatureScanConfig_205,
			memorySignatureScanConfig_206,
			memorySignatureScanConfig_220,
			memorySignatureScanConfig_226,
			memorySignatureScanConfig_227,
			memorySignatureScanConfig_228,
			memorySignatureScanConfig_229,
			memorySignatureScanConfig_231,
			memorySignatureScanConfig_230,
			memorySignatureScanConfig_207,
			memorySignatureScanConfig_208,
			memorySignatureScanConfig_209,
			memorySignatureScanConfig_210,
			memorySignatureScanConfig_211,
			memorySignatureScanConfig_212,
			memorySignatureScanConfig_213,
			memorySignatureScanConfig_214,
			memorySignatureScanConfig_215,
			memorySignatureScanConfig_216,
			memorySignatureScanConfig_225,
			memorySignatureScanConfig_224,
			memorySignatureScanConfig_221,
			memorySignatureScanConfig_217,
			memorySignatureScanConfig_218,
			memorySignatureScanConfig_219,
			memorySignatureScanConfig_222,
			memorySignatureScanConfig_223,
			memorySignatureScanConfig_239,
			memorySignatureScanConfig_240,
			memorySignatureScanConfig_241,
			memorySignatureScanConfig_264,
			memorySignatureScanConfig_265
		};
	}

	public static uint[] GetSelectedMemorySignatureOffsets()
	{
		return new uint[23]
		{
			memorySignatureScanConfig_109.resolvedValue,
			memorySignatureScanConfig_110.resolvedValue,
			memorySignatureScanConfig_114.resolvedValue,
			memorySignatureScanConfig_115.resolvedValue,
			memorySignatureScanConfig_111.resolvedValue,
			memorySignatureScanConfig_112.resolvedValue,
			memorySignatureScanConfig_113.resolvedValue,
			memorySignatureScanConfig_117.resolvedValue,
			memorySignatureScanConfig_117.resolvedValue + 4,
			memorySignatureScanConfig_117.resolvedValue + 8,
			memorySignatureScanConfig_117.resolvedValue + 12,
			memorySignatureScanConfig_118.resolvedValue,
			memorySignatureScanConfig_118.resolvedValue + 4,
			memorySignatureScanConfig_118.resolvedValue + 8,
			memorySignatureScanConfig_118.resolvedValue + 12,
			memorySignatureScanConfig_118.resolvedValue + 16,
			memorySignatureScanConfig_118.resolvedValue + 12,
			memorySignatureScanConfig_118.resolvedValue + 16,
			memorySignatureScanConfig_118.resolvedValue + 20,
			memorySignatureScanConfig_118.resolvedValue + 24,
			memorySignatureScanConfig_118.resolvedValue + 28,
			memorySignatureScanConfig_118.resolvedValue + 32,
			memorySignatureScanConfig_118.resolvedValue + 36
		};
	}

	private static int CollectMissingSignatureOffsetsAndDiagnostics(MemorySignatureScanConfig[] memorySignatureScanConfig_270, ref string string_28, ref string string_29)
	{
		int num = 0;
		string text = '\r' + "\n";
		for (int i = 0; i < memorySignatureScanConfig_270.Length; i++)
		{
			if (memorySignatureScanConfig_270[i].resolvedValue == 0)
			{
				string_28 = string_28 + i + "; ";
				num++;
			}
			if (Form1.testModeEnabled && memorySignatureScanConfig_270[i].signatureName != null)
			{
				string[] array = memorySignatureScanConfig_270[i].signatureName.Split('.');
				array[0] = array[array.Length - 1];
				string text2 = "\t";
				if (array[0].Length < 16)
				{
					text2 += text2;
				}
				while (array[0].Length < 20)
				{
					string[] array2;
					(array2 = array)[0] = array2[0] + " ";
				}
				string text3 = i + ". " + array[0] + " " + text2 + "= " + CommonUtility.FormatIntegerAsHex(memorySignatureScanConfig_270[i].resolvedValue, 8, bool_1: false);
				string_29 = string_29 + text3 + text;
			}
		}
		return num;
	}

	public static bool smethod_5(string string_28, string string_29 = null)
	{
		memorySignatureDataValid = false;
		memorySignatureLoadCompleted = false;
		memorySignatureLoadCompleted = true;
		return memorySignatureDataValid;
	}

	public static string smethod_6(string string_28, bool bool_2, bool bool_3)
	{
		return string.Empty;
	}

	public static void LoadEmbeddedGameConfigurationData()
	{
		missingSignatureIndexes = null;
		memorySignatureDiagnostics = null;
		memorySignatureDataValid = false;
		memorySignatureLoadCompleted = false;
		string text = "⓭⓾┣⓻⓱│┗┣⓾⓸⓱┍┢ⓙ┟⓲⓹ⓡ┃├⓮┖┓⓵⓭━⓶⓰┎⓳│┞⓰⓼⓶┏⓸ⓜ⓾┋┃┗⓶⓭⓷⓸⓮┎ⓠ⓪⓻ⓛ⓲┣┖⓴⓹⓭⓻⓾┋┣ⓢ⓵ⓘ⓲⓭⓻⓸⓬┟━┙│⓪┒┢⓰┠┟━⓶⓯┚┗ⓢ┞┕ⓠ⓮⓮┌─⓼┞⓽ⓠ┢┚⓷┎┚┢┕⓬ⓝ└┢ⓚⓘ⓬┊ⓔ⓺┏⓪┃━ⓜ⓷ⓟ⓹┍ⓔ┝ⓛ⓻┒⓳ⓚ┝⓶⓿⓮⓯┘┑⓵ⓞ⓰└┗⓫⓴ⓠ┖┍─ⓔ┍⓵ⓜ┣⓿┝┕┙⓽⓶⓼┙┚⓬┝┊⓱━ⓡ┖⓸├⓿┊┘⓴⓹⓵⓭⓳└ⓘ┍⓼ⓛ├┖━┣⓳┟ⓙ⓶ⓟ⓳┡ⓡ┗┢━━⓸⓱ⓟ⓴┙⓺┋ⓞ┛⓵┣┞⓪ⓔⓟⓠ┢ⓠ⓯ⓔ┑ⓔⓠ⓹├ⓡⓟ⓳⓽⓴┏ⓞⓡ┎⓲┚┃┃┐┍┎┐ⓢ┎┑┛⓴⓲⓿━⓱┠⓼ⓜ┠━⓪┚┋⓾ⓝ⓫⓽┞⓱┙┍⓴┚⓸ⓡ┠ⓝ─┃⓯┚┃├ⓘ┍ⓘⓟⓙ⓪ⓘ┏⓿ⓟ⓮⓪┠┙ⓘ┖┓┑⓿ⓞ┞┡ⓘ⓯⓸┎⓬⓲ⓠ━┢⓲⓫━┡├⓵─┏⓳┣┚⓶ⓠ┑┍┣⓪⓬ⓡ┍│┡┢ⓙⓠ┒┖⓶⓺┐⓮┛└⓾┋ⓚ⓾┓┃┟┌⓮⓴┣┗┗⓷ⓘ⓻⓭┏ⓠ⓳ⓠ┊┘┛⓶⓼⓳⓶┗┎ⓔ⓭⓼ⓛ⓷┝⓶ⓙ┙⓸⓮┝ⓜ┑┊┐┕┛┖⓰⓶⓱⓱┞┒ⓟⓟ┋⓻┊⓶┐┞┃━⓲⓻┘ⓘ┛⓺⓭┍⓰ⓜ⓽ⓚⓠ⓲┐ⓢ⓼━⓱ⓙ┣ⓞ⓵⓱┎┘│┃ⓔ⓶━⓿ⓢ┙⓻┓┛⓷⓷┋ⓙ⓿┢┠⓬└┙│⓭⓫┝┞┎┢⓻┘⓷⓴┡⓲⓴⓴┢┖┑│⓬┍⓴ⓚ├┏⓯━⓹┓├⓰├┙┑⓭┑⓮┓⓴⓭⓳⓵ⓟ┓┝⓶┋⓺┒┎┊ⓟ┛┘┃⓱┌┣┣⓽⓲ⓜ┊┞ⓔⓡⓜ⓸ⓢ┒┎┐⓮⓰┐⓲⓸⓹ⓠ├┡┚┡ⓠ┌┕┚ⓔⓝ━┟⓬┙┋⓮┟⓭│⓿┛┐┠⓳⓺ⓞ⓼┌┌⓴⓸┊┡┖⓻⓼⓻ⓢⓠ⓬┋⓽┖⓳┖⓺┠━┙━│┙ⓘⓜⓠ├┘⓪⓽├⓰└⓲┚┒⓴┖┏⓵⓳⓰ⓔ└┒⓯⓼ⓠ┠┖┠┘┗⓬⓻⓯┌ⓟ⓬┐┖┡ⓙ┎┠⓪⓭⓮┝┡┡⓲ⓛ⓹ⓘ┒┋┕ⓢ┃┣┐⓺⓺ⓚ┖┝┖ⓞ⓺┝┙┛ⓢ┍├┡┍⓸ⓞ⓯⓮┡ⓢ─ⓔ⓼⓽─ⓜ⓹┚ⓛ┊⓵┟│┠├┘━⓯┠┖─⓴⓬⓶⓿⓴⓯┟⓹⓫┟┎⓽ⓛ⓬ⓡ⓴⓺┏┡⓴┞⓼ⓡ┚┛⓼ⓜ┑ⓝⓝ│ⓡ┌┖⓲ⓙ┕┌⓹⓱┓ⓔ⓰┃└┡┢┢ⓚ┢─┌┚ⓟ┘⓶┒┑⓾┘⓱┊┏┚┊ⓛ⓼⓫┕┠⓲⓰⓫⓰⓬ⓜⓜ┒⓴┎┃⓾⓼┌⓹ⓞ┟ⓡ⓱⓱⓵┝┞┍┑┠┑ⓠⓜ┡⓳┑┘┞┋│⓼ⓘⓡ⓼┎─┞ⓟ└⓷┑⓵┎┟⓸│⓼⓷⓵⓻┎ⓘ┕┎┘┃⓴ⓢ└┣┍┙┟⓱⓱┃⓯┐┞┚┟ⓝ┃⓶⓯┡┛⓯⓾┙┖⓲⓪┞┍⓮⓾─│ⓢ┏┗⓶┘⓿ⓘ┓┞┣└⓰⓶┗┖┣┊┌ⓠ⓯⓱┓┝ⓜ⓽⓾┘⓷ⓜ┃⓾ⓢ└━┑⓵┎┃┙⓭┠┖┍ⓝ⓲┕┘⓸┎┍ⓛ⓵ⓔ┘⓰ⓘⓙ┡⓵├┃⓱┚┚┖├┢┏┚┒ⓘⓞ⓽─⓿⓪┖│┝ⓟ⓬⓱├⓸┛ⓟ⓮⓻ⓔ┌⓯ⓝ┃⓮⓮ⓔ┛⓿┠┗⓹⓮└⓺⓫ⓢ┏┠┞┍⓱⓭⓿┗⓰⓯ⓘ┑⓷┝┏⓵┃⓪ⓝ┌ⓚ┚⓺┞┚└┘⓷┕⓲⓮⓱ⓝ┏⓱┍⓮ⓙ┘⓶⓶⓪┎ⓘ┎┕ⓡⓞ⓹┘┑ⓝ⓱ⓡ⓲━┛⓮ⓢ┃ⓜ─┐⓽┍┘┖┙┐┊├⓸⓿┣┙└┗┊┓⓻ⓛ┑⓽⓽┌┋┓ⓙ⓶⓹⓲┘ⓛ⓹ⓞⓚ┗⓮┍⓭┍┢┘ⓢ⓪━┋⓮┕ⓞ⓫⓮┚⓯⓶┃⓪ⓢ┋⓮┋┡━⓶⓯⓶┡┞┞ⓔ⓽ⓢ⓫┍┌⓶┝⓻┕┏┎┝⓪⓳⓬┟⓴┋⓳⓾─┕┣┘┑⓳┣ⓟ⓶ⓛ┑⓹┠⓲┕ⓛ┡ⓡ┃ⓠ┝⓻⓸⓶└⓰┋┓ⓘ⓮┣┊⓼⓱ⓘⓞⓞ┝┗⓵┟⓪⓸⓽┕⓽⓱┋⓵⓺┛┑┋⓿┊⓹⓻┟┕└ⓠ┙⓹⓷─⓼┞┖⓶┠⓹⓳┒⓸┡ⓔ┍⓮⓻⓪ⓟ⓰─├ⓟ⓵⓻│━┣ⓝⓙ⓱⓿┖┊⓴⓽┠┙┏⓿┗┝┌⓳┛⓶ⓙ┗┍⓾⓯⓰┐⓶┍⓫┡⓻┝⓸┚⓼⓰┛┡⓿⓫┏│┊┢━┕┠⓱┟─│⓭⓾⓻ⓚⓠ┐┝┏⓭⓵⓯ⓙ┍ⓝⓛ┟⓯┐⓮⓹┘ⓢⓠ┘⓻┘┟⓰┠┝⓴┖┗┋⓬┌┚ⓟ│⓼┢┕┣ⓔ⓬┞ⓜ⓾ⓜ⓷┞━┍ⓢ┃⓹┐ⓝⓠⓟ│⓳┙ⓡ⓱┊┙┡┙└ⓜ⓼⓼ⓛ┃└⓵ⓝ└┟⓪⓫⓲⓭│ⓙ┠⓶┗┣⓱⓾━ⓝ┐ⓡⓜ┡⓯⓫⓼ⓚ┞┋┖ⓢ⓪┎⓵┓┍ⓔ⓵⓱⓽┏└⓾ⓚ⓰⓪⓬⓼┗┓⓺┛┋┏┊⓸ⓔ⓫⓮ⓠⓔ┏⓭┌ⓙⓘ┡ⓠ━ⓡ┐⓿ⓟ⓫┐ⓘ├ⓟⓟ┘━ⓝ┛┃⓫┕⓳└ⓝ┙ⓝ⓹ⓚ⓽┡┍⓪ⓝ┗ⓔ┊┓└⓮⓼└⓶⓲ⓛ├⓱┞⓬─┚┑┣⓾┝⓮┒┢┛⓲⓾⓪⓯┛⓲⓱⓰┓┠━ⓔⓟⓚ┋⓵┟ⓘ⓬┠┢⓬┌⓬┙⓱⓻┗⓱│⓽┖ⓘ⓭⓮ⓜ⓬┖ⓢ⓵⓸┓ⓞ┢└┘ⓟ┗ⓜ⓹┓ⓛ┖┊⓮┒⓫⓹⓰┙┣⓮ⓘ⓱ⓡⓞ┡┍┃┚┍⓪ⓝ┞┌┋┎⓱ⓜ┢┚┒┞ⓝ⓷⓻┍ⓚⓚ│⓷┘┎ⓙ⓯ⓝⓙⓚⓔ│ⓔ┖ⓘ⓱⓾ⓡ⓵┌⓲⓪━┐ⓝ┠┖┚⓱⓼┛│ⓜⓡ┕┍┘⓵⓸┋├ⓢ┏ⓚ⓶┣┙┘⓱ⓝ┋┕┕⓴┃┝⓭┃┢⓰⓺⓸┣⓼⓸┑⓭ⓡ┟┗┒│ⓢ┕┒⓿⓷┖⓼┍┗ⓠ┌ⓛ⓷│ⓙ⓭⓸⓳⓿┞┑ⓘⓜ⓫⓮┙┊ⓘⓡ┃┟┖ⓠ⓾⓻⓮┊│⓲┑┎┛┏⓴⓳⓾ⓚ┙⓹┙├ⓚ⓱⓫ⓡ┘┛ⓙ┖┖┘⓽ⓛ─├┚ⓔ⓬⓰┣ⓘ┍⓵⓰┗┒┚┌┒┟⓷⓸⓻⓫┗┊ⓝ┣ⓞ┣⓴⓳┏┑⓪┑┗⓽ⓝ┏ⓢ┊┒⓴└ⓡ⓻━┟┟⓽ⓙ⓼⓮⓯┍⓺┙┚⓭⓳┗ⓝⓠⓡ⓭┋⓳ⓜ┑⓳┃┡⓫┙ⓜ┏┐┝─┒⓴┏┓┛ⓝⓡ┖└└⓪⓸⓺┗⓮┑⓬│┒┟⓯┠┛┎┎┕ⓟ⓾⓻⓪⓭⓸ⓘ⓰┚⓷┑ⓘ⓺ⓜ⓵⓷┏┋ⓚ└⓷┒├┃⓶┝⓮│⓸⓳⓭ⓟ⓪⓮┃┐┞┗┌ⓜ┊┠┊━⓺⓺⓵⓶⓷⓫┞┒─┎ⓘ┟ⓘ⓵ⓚ⓽ⓞ┗━┑┣┛⓪⓷⓯⓹┣┌─┞┠└ⓘ⓭⓮⓬⓺⓴┍⓼ⓚ⓷┎┘⓹┟┗ⓞ⓶⓶ⓔⓔ┍┙├ⓛ├┖⓹└⓾┋ⓢⓔⓟ─┖ⓙ┊┙┍┠┍ⓠ┎└ⓛ⓶⓹┞━ⓛ┞┖┙ⓡⓛ⓽┊┏├┌⓫⓿⓪ⓞ┛┑┐⓼⓱⓲│├┒⓴┞⓪┛⓶⓼┗ⓔ⓾┏┚⓪┕┗┒ⓛⓔⓠ⓻⓰┑ⓚ⓬├⓺┑⓼┋⓹┋⓹⓹┚┡ⓞⓔⓛ⓷ⓚ┐ⓘ⓻┞⓭ⓚ┊⓼┙ⓜ⓪⓭ⓞ┛⓲⓻ⓝ⓽┒ⓡⓡ└│┋ⓝ┃┒⓵⓪┢⓱┣├ⓚ⓶┢ⓜ⓶┞ⓘ┒⓻ⓢ⓮└┕ⓡ┗ⓛ⓰ⓜ┠⓪⓴┖⓽┎┣⓭─┝⓲┚┗┞⓵⓪ⓘ┡ⓚ⓷⓵ⓚⓚ┗├┋⓸ⓜ⓭┗┚┙⓺├│┗ⓡⓟ⓳⓲⓾⓴ⓡ⓾┃ⓡ⓮┣⓸ⓜ┢⓷┏⓱┘┗⓱┑┏┘┃ⓟ┚⓸┞ⓡ⓯┚│⓯⓼⓺⓿ⓚ⓼┟ⓝ┢ⓟ┕ⓝ─┍⓻⓽┘⓭ⓞ┖┎⓴─⓽┝ⓠ┘⓭⓪┘⓼⓭ⓜ┊┗┏ⓘ⓱┐ⓚ├┌ⓡ⓶┖ⓝⓙ┏┍⓱ⓢ⓸ⓟ⓹⓹ⓟ┗┎┎┊┣⓽├ⓠⓟ⓪⓼⓾┑⓪┟┊┓ⓞ┌ⓘ⓼┘┏⓸┊⓲┞⓷┙┍ⓘ⓳┓ⓞ┞┠ⓘⓡ⓪⓾┢⓼⓻└┏⓽⓼⓸⓱┃ⓛ━ⓠⓔ┊ⓚ⓼ⓢ┘⓳━⓷━┚┒┙┡┒┐┟┎┎⓸━┗┟⓱┕┏⓴┊⓵ⓚⓚ⓳⓺┠⓴ⓢ⓱ⓞ⓲⓶─ⓙ⓭│┞ⓡ⓬━⓼⓭┟┕┗⓳⓫⓷┑⓿┣⓱ⓙ⓪┓┚┢ⓠ┝⓫┕⓫⓮ⓡ⓿ⓔ└ⓞⓠⓢ┘⓱⓱ⓢ━⓳┑ⓚ─├⓳⓸⓶ⓛ┑─┒┝┟⓫┊⓲ⓠ┒│┝⓷┛⓳┞├┋⓸┛⓸⓸⓪┝⓱⓬┒⓴┞┗⓫┋┙┝┊━⓵⓹⓪⓱ⓠ⓴⓴┏│⓴┊│⓳⓬⓬ⓜ┡⓿⓯⓾⓰⓷┎─ⓠ┌ⓔ┟ⓠ│ⓚ┌ⓛ⓰━│┡⓭┊ⓜ┎⓶⓽⓾┌┓ⓔ┑⓿─⓰┊ⓜ⓬┕━┌┓ⓚ┗ⓛ┞⓬┊┕⓻⓮⓴┝┡ⓠ⓲⓱⓴┃⓱⓮⓴┓ⓚ⓸┠⓸ⓝ⓬┟ⓟ⓶┣┐⓭┑⓫┐┛┌┙ⓠ┋ⓡ┍⓸┊⓭──┙┣⓯⓼┟⓻⓾┟ⓘ⓪┣┛┋⓫┖┑⓰│┓┃⓼⓪┑⓾┝⓰ⓛⓚ┢┟ⓞ⓻┎┊⓼⓫┛⓭⓶⓸┠⓹⓱⓺ⓡ⓴⓴ⓘ├┟ⓚ⓺─┐⓫⓼ⓜ├⓲⓭ⓝ┏┑┒⓲└⓵┕⓳⓷┝┟⓺⓭┓⓲┙⓯ⓡ⓭⓫ⓠⓛ━⓳ⓜⓘ⓽⓽⓺┎┠┚⓷┎┎⓹⓽┕ⓞ┒ⓛ┌⓿┠├┢ⓠ│ⓘⓘ┙┎┙┖⓷┗┞┍┐└⓽⓴┐┕┙⓫ⓙⓢ┑│└⓰└│┎⓱┚ⓚ⓼┍┓┟⓱⓪┖┢ⓜ┒├┊┙┑┊⓱⓽ⓜ┛⓰⓽┡⓪⓰⓺ⓛⓛ⓵┣┣ⓡⓡ⓮┙⓭┛⓱ⓠ┓⓲⓼┋ⓜ┐ⓡ┗⓶┏│┓┣⓮┞┛┠┡⓪┃┛┟ⓢ┖ⓢ├⓸┍┋┋┌ⓞ⓽⓷ⓢ┣┎┊┚ⓜⓔⓚ┋┠ⓟ⓼⓰ⓡ┓┗┣⓭⓹┛┓ⓝ┋└┟┠┌⓾┠┣ⓠ⓺│⓭ⓡ┚ⓚ┒ⓘ├⓳⓪┖ⓚ│ⓟⓙⓝ┞⓲┝┚ⓙ⓸⓮⓿⓮│┊⓭─ⓜⓞ⓰┙─┞━⓳┡⓸┏ⓟ⓻ⓜⓢ⓳┢├ⓝⓔ⓶ⓞⓠ⓫ⓝ┙┡⓷ⓠ⓿┒⓻ⓞ┓⓹⓯┙⓰━┙⓸ⓝ┘┠⓻ⓠ⓺┢┠┖⓾├┟ⓙ⓲┒⓰┝┡⓴⓬┓┞┢⓭┘⓫┣┡⓾ⓝ⓫┊┒ⓘⓠⓠ⓮⓶┞ⓞ┍┘ⓝ┒┡ⓝ┏┣┘ⓝ│┏┟⓭⓵┖┓⓹⓬┑┚┖⓸⓰┚⓺⓳⓽│ⓚ┏⓮⓫┚┡┖┌┋┖─┢┛└┙⓻─┗┡⓮⓳└┣ⓡ┠⓫━─⓮ⓞ⓶⓷⓽┓ⓡ─┖├⓲ⓠ⓸⓷⓱━┎⓻┕├┖┛┓⓺⓸ⓡ⓪⓬⓷│┓⓾⓼⓵┘⓫⓾⓹ⓛⓜ┏⓭┃┝⓰┊⓷ⓔ⓯⓷┣┚┋ⓞ┒⓸⓹┙⓳⓱ⓛ┚├⓪⓬┃ⓛ┖┘┠⓼┊ⓘ⓫⓪┛├⓼⓪⓼┌┡├⓸ⓙ⓸ⓠ⓼⓻┏⓽┋ⓟ┞ⓜ⓰┃⓽⓺─⓯┚ⓛ┚ⓠ⓻┃┗┠├┊┣ⓔ│⓫┢━ⓚ⓷┎┟⓮⓱⓷┒⓻⓴⓷⓹┕⓵⓾┙┌ⓛ└⓬⓸⓷ⓔ┗⓿┛⓶⓪⓷⓹ⓘⓙⓜ└┞ⓜ┏┛⓵─⓫⓭┢⓼⓱┙⓶┢┠┢⓺┋└⓱ⓠ⓿┙┝ⓜ⓱⓵ⓠ⓬ⓢⓙ┑ⓚⓞ┞⓭┘⓷┓├┋┝⓮┗─┋┊┖┏└┝┐ⓠ⓹⓮┝└ⓠ⓺⓶ⓟ⓾⓾⓸ⓙ┍⓭┠⓮┑⓫⓺│ⓜ┠┟┛┌⓱ⓜ⓳┟┑⓲⓿⓪┖⓺ⓟ┎ⓝ⓶┃ⓘ┘⓴┣┝┑┖ⓔ┝┛ⓘⓡⓜ┗┣ⓔ┘⓬⓪ⓛ⓲┓ⓢ⓽│ⓔ⓷━┊ⓟⓔ┚┝⓸ⓝ┖┕⓶⓴⓴┚┏⓽┡┞⓴⓷⓬ⓜ⓫ⓙ┠┐┐⓽┏⓼⓺⓯┖ⓢ⓾⓾┙┞│⓫ⓝ┎┛⓴┏⓭⓵⓭┗┝ⓠ⓪┎┚⓾┑┛ⓞⓚ┍⓼┖⓹⓴ⓛⓝ⓯┊ⓝ⓹┑⓭┋⓷⓸⓽ⓙ├⓲┌┏ⓢ⓬┊ⓡ⓺⓯⓲⓶⓹┃⓮┏ⓝ┘├┐ⓟ⓷⓶⓫┘⓷⓿┒┎⓵┍┞⓹┑┓ⓘ┊⓫ⓟ├ⓞ⓶┞─┟┛┊┃│⓳⓶├⓶┠⓹ⓢ⓱┕┒⓵⓼┡⓽⓭ⓜⓠⓘ┢─└⓹⓪⓴│⓷┟ⓡ⓹┌⓷┡ⓡ┘⓯┓⓳ⓡⓙ⓺⓿┟━⓽⓷⓶┒⓵└┞┢┑┊┡┡⓹ⓢ┝ⓡ┗⓬┞┃┙┖┢ⓙ┟⓫⓯⓬⓽┊┖⓴├ⓠⓔⓝⓜ┣│⓺┓ⓢ⓶ⓛ⓮├ⓞ⓭⓴┕┠┕ⓙ━┟ⓠ┃⓪⓬┌ⓛ⓼⓳⓷┠┙┊⓱┃⓱⓺ⓔ⓳⓮⓾ⓡ┐⓱└└ⓠ⓸┟┙⓼┙ⓛ┖┊┡┟└┍ⓠ┖⓪├⓵┘┖┢┍⓱⓹ⓟ┊⓼┊ⓘ⓿⓹┍┍⓵┢┣ⓚ┘⓽⓻┌ⓠ⓸┋┒─⓳┃⓪⓳┊⓪┕┞⓲⓵⓶┊│┚┕┙⓵⓻⓾⓭│ⓞ⓵ⓢⓞ⓷│┠┢┟⓾ⓝⓟ┃ⓚ┚┐ⓜ⓽─┌┢⓫┡┒⓮┖┃⓰ⓘ┙ⓡ┠━ⓙ┒⓿┟⓶⓱ⓠ┢┗┕│┋┗⓼┞│┣⓽┍ⓛ⓳┐┝⓸┛⓲⓯┌ⓠ⓱│┘⓲⓫┘┍┞⓴┏┙⓸⓾┑⓬⓳⓻┙ⓝ⓼┖ⓘ┘⓽┞⓳┌⓸ⓝ⓺┚⓫ⓡ⓬⓾┌─ⓚ┊┋┗┚━ⓘ┙⓬│⓾┐┋⓷ⓔⓛ┝┑┌ⓢ⓱ⓝ⓸ⓞ⓸⓱ⓘ⓲ⓢⓝ└ⓞ⓸ⓔⓔ└┋├┐┓┑┞⓹┛ⓙ┘⓭┞┝┠┖┓ⓙ⓴⓭⓷├┣┠ⓞⓜ⓹ⓝ┏⓳┘┘⓷━├⓾ⓛⓝ⓷⓽⓽ⓔ⓳⓶└⓹⓰ⓛⓠ⓾⓫┚⓾┚⓪⓭⓲┝⓱⓮┑─┙┃┓┎⓮ⓟ⓿┋⓰ⓡ⓴┓⓪ⓜ┟⓷┠┖⓿┝┠┝┛─⓯┖⓼┝ⓟⓘⓞ┍┞┠ⓠ┐┗⓿ⓡⓟ┕┋─┍⓱⓯┗⓿├⓽ⓞ━ⓔ─ⓡ┞⓰ⓡ┙┗┌┛┊ⓞ⓷┝⓱⓻┃⓮⓯ⓠ┢⓵┠─⓶┠┋┍┝┎┐ⓙ⓯⓺⓳┕⓲⓹┛┟┃└┞┞┙┏┍ⓘ┢┣⓷ⓞⓜ│┖ⓞ├┊┍⓪ⓡ┑⓳│⓷⓽ⓟ⓲┙┍⓴┚┑⓾⓺┙├┃┙⓾⓹ⓠⓞⓙ┝ⓘ┣⓿ⓢ⓲ⓠ┊└⓲├⓾⓸⓬┏┊┞⓹┓┝│ⓡⓡ⓮┒⓻┘⓯ⓜ⓴⓴ⓢ⓺┍ⓜ⓿┗┖┝┏ⓠ⓫┟ⓚ⓫┍┘ⓛ│┐┓⓯┋┝┖⓲ⓔ├ⓜ⓶┏ⓘ┠⓷⓬⓯ⓝⓠⓔ━┊┑⓳⓽┒⓹⓯┢ⓔⓙⓛ│━ⓚⓝⓢ⓵⓬┌┟⓸ⓝ┓┃ⓚ⓼⓰┓┓─⓰┐┋ⓞ⓲┘┟┝┛⓿⓯ⓙ┑┢⓹┠⓷⓳⓴┑┑━┖ⓟ┑┣⓵┐⓷⓼┊┕ⓙⓘ┃ⓚ⓵⓸⓬⓺⓲┏ⓘ⓭┒├ⓜ├┚⓱┐⓱⓴┕ⓜ┋└┖⓵└┝⓶├┝ⓚⓟ┛└┗┝ⓔ┘┝┒─┑⓯┣⓻┢ⓢ⓺⓹⓬ⓚ⓵└ⓔ⓯⓽┛┍ⓔ┠⓬⓪┝⓶┏⓶⓳⓫⓪┢⓰┝⓫┃⓭┚⓵┐⓵┛┡⓭┃ⓔ⓭┖┌┊⓱┌┏┗⓿┓┖⓴ⓘ┒⓴┖└┠⓫─┐⓼┕⓵┒ⓙ⓭⓯⓽┖│ⓘ┟⓯ⓔ⓮⓹┗ⓚ┃⓹⓻⓬⓰┛⓽⓵┟ⓞ┠┢│ⓔ┢┘┊┚━⓶⓲├ⓞ⓻⓷⓭┣⓶ⓘ⓷⓸│ⓢ⓳⓻┖┞⓯┘ⓔ┟ⓢ⓲ⓛ┕┊┕ⓠ┗┙┣⓭⓰⓸⓯ⓘ⓾⓫⓲ⓜ┗ⓛ⓳⓯ⓟ⓪⓴┌⓪┡⓴│━━┟⓿└⓴⓹┟┓┟⓹⓼⓶ⓔ┓┐⓺┡─━┌┋┐┃⓼⓻⓱ⓔⓠ⓷⓷ⓝ└⓵⓲└┙⓲⓵┃┛┞┕⓴⓲┝ⓞ⓻⓶ⓠ⓬⓹⓬┞└┝┢┃┋┘⓴┝ⓡ┠┓┚ⓟ┣⓳⓱ⓙ┟⓱┃⓳┖┏⓶";
		string text2 = CommonUtility.DecodeLengthShiftedString(text);
		string text3 = CommonUtility.DecryptRijndaelBase64String(text2, Form1.configurationDecryptionKey.ToLower(), new byte[8]);
		string text4 = CommonUtility.DecompressBase64DeflateUtf8(text3);
		if (text4 != null && !(text4 == string.Empty))
		{
			string[] array = text4.Split('\u0001');
			string[,] array2 = new string[array.Length, 2];
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null && !(array[i] == string.Empty))
				{
					string[] array3 = array[i].Split('=');
					if (array3.Length > 1)
					{
						array2[i, 0] = array3[0];
						array2[i, 1] = array3[1];
					}
				}
			}
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref GameCrashFixPatcher.memorySignatureScanConfig_0, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref GameCrashFixPatcher.memorySignatureScanConfig_16, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref GameCrashFixPatcher.memorySignatureScanConfig_17, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref GameCrashFixPatcher.memorySignatureScanConfig_18, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref GameCrashFixPatcher.memorySignatureScanConfig_19, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref GameCrashFixPatcher.memorySignatureScanConfig_20, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref GameCrashFixPatcher.memorySignatureScanConfig_21, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref GameCrashFixPatcher.memorySignatureScanConfig_22, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref GameCrashFixPatcher.memorySignatureScanConfig_23, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref GameCrashFixPatcher.memorySignatureScanConfig_24, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref GameCrashFixPatcher.memorySignatureScanConfig_25, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref GameCrashFixPatcher.memorySignatureScanConfig_26, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref GameCrashFixPatcher.memorySignatureScanConfig_27, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref GameCrashFixPatcher.memorySignatureScanConfig_28, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref GameCrashFixPatcher.memorySignatureScanConfig_29, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref GameCrashFixPatcher.memorySignatureScanConfig_30, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref GameCrashFixPatcher.memorySignatureScanConfig_31, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_6, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_5, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_7, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_246, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_245, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_247, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_248, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_249, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_243, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_244, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_1, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_250, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_262, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_260, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_259, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_261, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_242, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_4, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_2, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_3, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_251, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_252, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_253, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_254, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_255, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_256, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_258, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_257, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_11, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_12, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_13, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_18, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_19, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_20, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_21, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_22, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_9, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_10, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_14, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_15, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_16, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_49, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_17, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_23, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_24, array2);
			memorySignatureScanConfig_25.resolvedValue = memorySignatureScanConfig_24.resolvedValue + 8;
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_26, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_27, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_28, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_29, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_30, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_31, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_32, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_33, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_34, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_35, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_36, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_37, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_38, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_39, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_40, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_41, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_42, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_43, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_44, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_45, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_46, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_47, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_48, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_50, array2);
			if (memorySignatureScanConfig_50.resolvedValue != 0)
			{
				memorySignatureScanConfig_51.resolvedValue = memorySignatureScanConfig_50.resolvedValue + 4;
				memorySignatureScanConfig_52.resolvedValue = memorySignatureScanConfig_50.resolvedValue + 8;
				memorySignatureScanConfig_53.resolvedValue = memorySignatureScanConfig_50.resolvedValue + 12;
			}
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_54, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_55, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_56, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_57, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_58, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_59, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_60, array2);
			if (memorySignatureScanConfig_60.resolvedValue != 0)
			{
				memorySignatureScanConfig_61.resolvedValue = memorySignatureScanConfig_60.resolvedValue - 8;
				memorySignatureScanConfig_62.resolvedValue = memorySignatureScanConfig_60.resolvedValue - 12;
				memorySignatureScanConfig_63.resolvedValue = 152u;
				memorySignatureScanConfig_64.resolvedValue = 184u;
				memorySignatureScanConfig_65.resolvedValue = 88u;
			}
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_66, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_72, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_73, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_74, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_75, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_233, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_76, array2);
			if (memorySignatureScanConfig_76.resolvedValue != 0)
			{
				memorySignatureScanConfig_77.resolvedValue = memorySignatureScanConfig_76.resolvedValue + 8;
				memorySignatureScanConfig_78.resolvedValue = memorySignatureScanConfig_76.resolvedValue + 32;
				memorySignatureScanConfig_79.resolvedValue = memorySignatureScanConfig_76.resolvedValue + 8 + 4;
				memorySignatureScanConfig_80.resolvedValue = memorySignatureScanConfig_76.resolvedValue + 32 + 4;
				memorySignatureScanConfig_81.resolvedValue = memorySignatureScanConfig_76.resolvedValue + 8 + 8;
				memorySignatureScanConfig_82.resolvedValue = memorySignatureScanConfig_76.resolvedValue + 32 + 8;
				memorySignatureScanConfig_83.resolvedValue = memorySignatureScanConfig_76.resolvedValue + 8 + 12;
				memorySignatureScanConfig_84.resolvedValue = memorySignatureScanConfig_76.resolvedValue + 32 + 12;
			}
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_90, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_91, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_92, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_93, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_94, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_95, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_96, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_234, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_235, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_97, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_98, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_99, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_100, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_101, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_102, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_105, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_106, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_107, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_108, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_109, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_111, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_112, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_110, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_113, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_114, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_115, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_116, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_118, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_117, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_119, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_120, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_121, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_122, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_123, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_103, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_104, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_124, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_125, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_126, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_127, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_128, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_129, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_130, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_131, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_132, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_133, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_134, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_135, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_136, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_137, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_138, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_139, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_140, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_141, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_142, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_143, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_145, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_144, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_146, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_147, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_148, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_149, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_150, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_151, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_153, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_155, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_154, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_152, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_156, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_157, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_158, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_159, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_263, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_160, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_68, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_71, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_70, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_67, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_69, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_161, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_163, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_162, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_164, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_165, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_166, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_167, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_168, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_169, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_171, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_172, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_173, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_174, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_175, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_176, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_178, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_179, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_180, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_181, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_182, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_183, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_184, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_185, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_186, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_187, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_177, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_232, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_236, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_237, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_238, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_86, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_87, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_188, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_89, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_189, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_88, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_190, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_191, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_192, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_196, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_193, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_194, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_195, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_197, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_201, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_202, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_203, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_204, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_205, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_206, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_220, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_226, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_227, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_228, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_229, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_231, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_230, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_207, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_208, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_209, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_210, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_211, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_212, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_213, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_214, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_215, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_216, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_225, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_224, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_221, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_217, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_218, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_219, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_222, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_223, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_239, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_240, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_241, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_264, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_265, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_266, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_267, array2);
			ProcessMemorySignatureScanner.TryLoadCachedSignatureAddress(ref memorySignatureScanConfig_268, array2);
			MemorySignatureScanConfig[] memorySignatureScanConfig_ = GetAllMemorySignatureScanConfigs();
			memorySignatureDataValid = CollectMissingSignatureOffsetsAndDiagnostics(memorySignatureScanConfig_, ref missingSignatureIndexes, ref memorySignatureDiagnostics) == 0;
			uint_0 = null;
			if (memorySignatureDataValid)
			{
				uint_0 = GetSelectedMemorySignatureOffsets();
			}
			memorySignatureLoadCompleted = true;
		}
		else
		{
			memorySignatureDataValid = false;
			memorySignatureLoadCompleted = true;
			missingSignatureIndexes = "0";
			memorySignatureDiagnostics = "Chưa có dữ liệu data game.";
		}
	}

	public static CharacterAccountConfig InitializeCharacterAccountFromProcess(int int_11)
	{
		CharacterAccountConfig characterAccountConfig_ = new CharacterAccountConfig
		{
			int_136 = 0,
			uint_17 = 0u,
			uint_18 = 0u,
			gstruct44_0 = null,
			bool_25 = false
		};
		if (memorySignatureLoadCompleted && memorySignatureDataValid)
		{
			try
			{
				characterAccountConfig_.process_0 = Process.GetProcessById(int_11);
				characterAccountConfig_.uint_7 = (uint)(int)characterAccountConfig_.process_0.MainModule.BaseAddress;
				uint[] array = WindowsInteropHelper.GetModuleBaseAddressesByNames(int_11, "engine.dll|lualibdll.dll|rainbow.dll|msvcr80.dll|jx.dll");
				if (array != null)
				{
					if (array.Length != 0)
					{
						characterAccountConfig_.uint_8 = array[0];
					}
					if (array.Length > 1)
					{
						characterAccountConfig_.uint_9 = array[1];
					}
					if (array.Length > 2)
					{
						characterAccountConfig_.uint_10 = array[2];
					}
					if (array.Length > 3)
					{
						characterAccountConfig_.uint_11 = array[3];
					}
					if (array.Length > 4)
					{
						characterAccountConfig_.uint_14 = array[4];
					}
				}
			}
			catch
			{
				CommonUtility.AppendStringIfMissing(ref CommonUtility.string_17, "Khởi tạo game thất bại.");
				return characterAccountConfig_;
			}
			characterAccountConfig_.int_137 = WindowsInteropHelper.OpenProcess(2035711, bool_0: false, int_11);
			characterAccountConfig_.string_22 = CurrentCharacterMemoryHelper.GetCharacterName(characterAccountConfig_);
			characterAccountConfig_.string_20 = GuildAutomationHelper.ReadGuildName(characterAccountConfig_);
			characterAccountConfig_.string_21 = GuildAutomationHelper.ReadGuildBaseText(characterAccountConfig_);
			characterAccountConfig_.int_97 = 500;
			characterAccountConfig_.uint_5 = WindowsInteropHelper.FindTopLevelWindowHandlesByClass(int_11, gameWindowClassName);
			if (characterAccountConfig_.uint_5 != null && characterAccountConfig_.uint_5.Length != 0)
			{
				characterAccountConfig_.uint_4 = characterAccountConfig_.uint_5[0];
			}
			else
			{
				GStruct8[] array2 = WindowsInteropHelper.FindProcessWindowsAndControls(int_11, "WIN_CLASS:" + gameWindowClassName);
				if (array2 != null && array2.Length != 0)
				{
					characterAccountConfig_.uint_4 = array2[0].uint_0;
				}
			}
			uint num = 3164u;
			if (3164 < memorySignatureScanConfig_143.resolvedValue)
			{
				num = memorySignatureScanConfig_143.resolvedValue;
			}
			characterAccountConfig_.uint_18 = 0u;
			characterAccountConfig_.uint_17 = WindowsInteropHelper.AllocateRemoteMemory(characterAccountConfig_.int_137, GameProcessInteractionHelper.remoteMemoryReserveSize + num + 4096);
			if (characterAccountConfig_.uint_17 != 0)
			{
				characterAccountConfig_.uint_22 = 0u;
				characterAccountConfig_.uint_21 = WindowsInteropHelper.AllocateRemoteMemory(characterAccountConfig_.int_137, 12288u);
				if (characterAccountConfig_.uint_21 == 0)
				{
					return characterAccountConfig_;
				}
				characterAccountConfig_.uint_16 = WindowsInteropHelper.AllocateRemoteMemory(characterAccountConfig_.int_137, 4096u);
				characterAccountConfig_.uint_15 = WindowsInteropHelper.AllocateRemoteMemory(characterAccountConfig_.int_137);
				characterAccountConfig_.uint_19 = WindowsInteropHelper.AllocateRemoteMemory(characterAccountConfig_.int_137, 256u);
				characterAccountConfig_.int_136 = int_11 * Convert.ToByte(characterAccountConfig_.uint_7 != 0 && characterAccountConfig_.uint_17 != 0 && characterAccountConfig_.uint_4 != 0);
				if (characterAccountConfig_.int_136 == 0)
				{
					return characterAccountConfig_;
				}
				characterAccountConfig_.uint_20 = WindowsInteropHelper.AllocateRemoteMemory(characterAccountConfig_.int_137, 4096u);
				GameProcessInteractionHelper.InitializeRemoteActionStubs(ref characterAccountConfig_);
				PopulateCharacterRuntimeDataWithRetry(ref characterAccountConfig_);
				ApplicationRuntimeCoordinator.long_0 = 0L;
				return characterAccountConfig_;
			}
			return characterAccountConfig_;
		}
		return characterAccountConfig_;
	}

	public static void PopulateCharacterRuntimeDataWithRetry(ref CharacterAccountConfig characterAccountConfig_0, string string_28 = null)
	{
		bool flag = false;
		while (true)
		{
			try
			{
				LoadCharacterConfigurationValues(ref characterAccountConfig_0, string_28, flag);
				break;
			}
			catch
			{
				if (flag)
				{
					break;
				}
				flag = true;
			}
		}
	}

	private static void LoadCharacterConfigurationValues(ref CharacterAccountConfig characterAccountConfig_0, string string_28 = null, bool bool_2 = false)
	{
		if (string_28 == null || string_28 == string.Empty)
		{
			string_28 = allUserConfigDirectory + "\\" + CommonUtility.ConvertNonAlphanumericCharsToByteValues(characterAccountConfig_0.string_22) + ".cfg";
		}
		string[] array = null;
		if (!bool_2)
		{
			string text = CommonUtility.ReadAllTextWithEncodingOption(string_28, 0, 0, 3);
			if (text != null && text != string.Empty)
			{
				array = text.Split('|');
			}
		}
		else
		{
			CommonUtility.DeleteFileIfExists(string_28);
		}
		characterAccountConfig_0.bool_22 = false;
		if (string_6 != null)
		{
			for (int i = 0; i < string_6.Length; i++)
			{
				if (characterAccountConfig_0.string_22 == string_6[i])
				{
					characterAccountConfig_0.bool_22 = true;
					break;
				}
			}
		}
		characterAccountConfig_0.int_95 = GetNamedIntegerArrayEntry(array, "flagTiepcanF", new int[1] { 1 })[0];
		characterAccountConfig_0.int_96 = GetNamedIntegerArrayEntry(array, "ValueTiepcan", new int[1] { 512 })[0];
		characterAccountConfig_0.int_98 = GetNamedIntegerArrayEntry(array, "flagTamQuet_", new int[1] { 1 })[0];
		characterAccountConfig_0.int_99 = GetNamedIntegerArrayEntry(array, "ValueTamQuet_s", new int[1] { 550 })[0];
		characterAccountConfig_0.int_143 = GetNamedIntegerArrayEntry(array, "UuTienMode", new int[1])[0];
		characterAccountConfig_0.int_144 = GetNamedIntegerArrayEntry(array, "UuTienTabPageMode", new int[1])[0];
		string[] array2 = GetNamedStringArrayEntry(array, "AscBomThuoc", null);
		if (array2 != null && array2.Length != 0)
		{
			array2[0] = CommonUtility.DecodeBase64Utf8(array2[0]);
			if (array2[0] != string.Empty && array2[0] != null)
			{
				string[] array3 = array2[0].Split('|');
				characterAccountConfig_0.gstruct44_0 = new GStruct44[array3.Length];
				for (int j = 0; j < array3.Length; j++)
				{
					string[] array4 = array3[j].Split(':');
					characterAccountConfig_0.gstruct44_0[j].int_0 = CommonUtility.ParseInt32OrZero(array4[0]);
					string[] array5 = array4[1].Split('/');
					characterAccountConfig_0.gstruct44_0[j].comboMedicineEntry_0 = new ComboMedicineEntry[array5.Length];
					for (int k = 0; k < array5.Length; k++)
					{
						string[] array6 = array5[k].Split('=');
						characterAccountConfig_0.gstruct44_0[j].comboMedicineEntry_0[k].int_0 = CommonUtility.ParseInt32OrZero(array6[0]);
						characterAccountConfig_0.gstruct44_0[j].comboMedicineEntry_0[k].string_0 = array6[1];
					}
				}
			}
		}
		characterAccountConfig_0.string_15 = string.Empty;
		string[] array7 = GetNamedStringArrayEntry(array, "PassRuong", null);
		if (array7 != null && array7.Length != 0)
		{
			characterAccountConfig_0.string_15 = CommonUtility.DecodeBase64Utf8(array7[0]);
		}
		string[] string_29 = array;
		int[] int_ = new int[1];
		characterAccountConfig_0.int_37 = GetNamedIntegerArrayEntry(string_29, "flagXepdo", int_)[0];
		characterAccountConfig_0.int_38 = GetNamedIntegerArrayEntry(array, "TimerXepdo", new int[1] { 15000 })[0];
		string[] string_30 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_39 = GetNamedIntegerArrayEntry(string_30, "flagNhatTrongthanh", int_)[0];
		string[] string_31 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_40 = GetNamedIntegerArrayEntry(string_31, "flagNhatTheoThuoctinh", int_)[0];
		string[] string_32 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_41 = GetNamedIntegerArrayEntry(string_32, "flagThoahetThuoctinh", int_)[0];
		characterAccountConfig_0.int_42 = GetNamedIntegerArrayEntry(array, "flagKhongNhatdoTim", new int[1] { 1 })[0];
		string[] string_33 = array;
		int_ = new int[2];
		characterAccountConfig_0.int_43 = GetNamedIntegerArrayEntry(string_33, "GiuNhan", int_);
		string[] string_34 = array;
		int_ = new int[2];
		characterAccountConfig_0.int_44 = GetNamedIntegerArrayEntry(string_34, "GiuDC", int_);
		string[] string_35 = array;
		int_ = new int[2];
		characterAccountConfig_0.int_45 = GetNamedIntegerArrayEntry(string_35, "GiuNB", int_);
		characterAccountConfig_0.int_51 = GetNamedIntegerArrayEntry(array, "flagPhamviNhatdo", new int[1] { 1 })[0];
		characterAccountConfig_0.int_52 = GetNamedIntegerArrayEntry(array, "PhamviNhatdo", new int[1] { 600 })[0];
		characterAccountConfig_0.int_53 = GetNamedIntegerArrayEntry(array, "RuongCatdo", new int[5] { 1, 0, 0, 0, 0 });
		characterAccountConfig_0.string_5 = null;
		string[] array8 = GetNamedStringArrayEntry(array, "tbKeepItem", null);
		if (array8 != null && array8.Length != 0)
		{
			array8[0] = CommonUtility.DecodeBase64Utf8(array8[0]);
			if (array8[0] != string.Empty && array8[0] != null)
			{
				characterAccountConfig_0.string_5 = array8[0].Split('|');
			}
		}
		characterAccountConfig_0.int_2 = 0;
		string[] string_36 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_54 = GetNamedIntegerArrayEntry(string_36, "Luomrac", int_)[0];
		string[] string_37 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_55 = GetNamedIntegerArrayEntry(string_37, "LuomracAccept", int_)[0];
		string[] string_38 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_56 = GetNamedIntegerArrayEntry(string_38, "LuomracThuoctinh", int_)[0];
		string[] string_39 = array;
		int_ = new int[2];
		characterAccountConfig_0.int_46 = GetNamedIntegerArrayEntry(string_39, "flagVeBando", int_);
		characterAccountConfig_0.int_47 = GetNamedIntegerArrayEntry(array, "GiudoTheoCap", new int[2] { 0, 9 });
		string[] string_40 = array;
		int_ = new int[2];
		characterAccountConfig_0.int_48 = GetNamedIntegerArrayEntry(string_40, "GiudoTheoHe", int_);
		string[] string_41 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_49 = GetNamedIntegerArrayEntry(string_41, "GiudoTim", int_)[0];
		string[] string_42 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_50 = GetNamedIntegerArrayEntry(string_42, "GiudoTheoThuoctinh", int_)[0];
		characterAccountConfig_0.itemAttributeFilterRule_0 = CreateDefaultItemAttributeFilterRules();
		int[] array9 = GetNamedIntegerArrayEntry(array, "tbFlagItemMagic", null);
		int[] array10 = GetNamedIntegerArrayEntry(array, "tbValueItemMagic", null);
		int[] array11 = GetNamedIntegerArrayEntry(array, "tbValueDong", null);
		if (array9 != null && array9.Length == characterAccountConfig_0.itemAttributeFilterRule_0.Length && array10 != null && array10.Length == characterAccountConfig_0.itemAttributeFilterRule_0.Length)
		{
			for (int l = 0; l < characterAccountConfig_0.itemAttributeFilterRule_0.Length; l++)
			{
				characterAccountConfig_0.itemAttributeFilterRule_0[l].int_0 = array9[l];
				characterAccountConfig_0.itemAttributeFilterRule_0[l].int_2 = array10[l];
			}
		}
		if (array11 != null && array11.Length == characterAccountConfig_0.itemAttributeFilterRule_0.Length)
		{
			for (int m = 0; m < characterAccountConfig_0.itemAttributeFilterRule_0.Length; m++)
			{
				characterAccountConfig_0.itemAttributeFilterRule_0[m].int_3 = array11[m];
			}
		}
		characterAccountConfig_0.int_18 = GetNamedIntegerArrayEntry(array, "SinhlucThoat", new int[1] { 200 })[0];
		string[] string_43 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_19 = GetNamedIntegerArrayEntry(string_43, "flagSinhlucThoat", int_)[0];
		string[] string_44 = array;
		int_ = new int[2];
		characterAccountConfig_0.int_60 = GetNamedIntegerArrayEntry(string_44, "TDPKhiHetruong", int_);
		characterAccountConfig_0.int_57 = GetNamedIntegerArrayEntry(array, "flagTranhBossvang", new int[1] { 1 })[0];
		string[] string_45 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_58 = GetNamedIntegerArrayEntry(string_45, "AnTTL", int_)[0];
		characterAccountConfig_0.int_59 = GetNamedIntegerArrayEntry(array, "TDPKhiSaiMap", new int[1] { 1 })[0];
		characterAccountConfig_0.int_61 = GetNamedIntegerArrayEntry(array, "flagNhatdos", new int[1] { 1 })[0];
		string[] string_46 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_62 = GetNamedIntegerArrayEntry(string_46, "flagNhatdoIndex", int_)[0];
		string[] string_47 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_63 = GetNamedIntegerArrayEntry(string_47, "flagCanThuocLag", int_)[0];
		characterAccountConfig_0.int_64 = GetNamedIntegerArrayEntry(array, "fThuocTocdo", new int[3] { 0, 0, 3 });
		characterAccountConfig_0.string_7 = null;
		characterAccountConfig_0.string_8 = null;
		string[] array12 = GetNamedStringArrayEntry(array, "ThuocTocdoDanh", null);
		if (array12 != null && array12.Length != 0)
		{
			array12[0] = CommonUtility.DecodeBase64Utf8(array12[0]);
			if (array12[0] != string.Empty && array12[0] != null)
			{
				characterAccountConfig_0.string_7 = array12[0].Split('|');
			}
		}
		array12 = GetNamedStringArrayEntry(array, "ThuocTocdoThuong", null);
		if (array12 != null && array12.Length != 0)
		{
			array12[0] = CommonUtility.DecodeBase64Utf8(array12[0]);
			if (array12[0] != string.Empty && array12[0] != null)
			{
				characterAccountConfig_0.string_8 = array12[0].Split('|');
			}
		}
		characterAccountConfig_0.string_6 = null;
		array12 = GetNamedStringArrayEntry(array, "tbThuocLag", null);
		if (array12 != null && array12.Length != 0)
		{
			array12[0] = CommonUtility.DecodeBase64Utf8(array12[0]);
			if (array12[0] != string.Empty && array12[0] != null)
			{
				characterAccountConfig_0.string_6 = array12[0].Split('|');
			}
		}
		if (characterAccountConfig_0.string_6 == null)
		{
			string text2 = "L«i Phßng hoµn|Tr\u00adêng MÖnh hoµn|Gia Bµo hoµn|Cao Trung hoµn|§éc Phßng hoµn|Cao ThiÓm hoµn|Háa Phßng hoµn|Gia Bµo hoµn|B\u00a8ng Phßng hoµn|Háa Phßng hoµn|B\u00b8ch Qu¶ Lé|Thiªn s¬n  B¶o Lé|Thiªn s¬n B¶o Lé";
			characterAccountConfig_0.string_6 = text2.Split('|');
		}
		characterAccountConfig_0.string_4 = null;
		array12 = GetNamedStringArrayEntry(array, "IBadlist", null);
		if (array12 != null && array12.Length != 0)
		{
			array12[0] = CommonUtility.DecodeBase64Utf8(array12[0]);
			if (array12[0] != string.Empty && array12[0] != null)
			{
				characterAccountConfig_0.string_4 = array12[0].Split('|');
			}
		}
		if (characterAccountConfig_0.string_4 == null)
		{
			characterAccountConfig_0.string_4 = new string[4] { "Th\u00adëng", "Ph¹t", "ThÇn bÝ ®å chÝ", "§Æc Th\u00b8m B¶o R\u00ad¬ng" };
		}
		characterAccountConfig_0.int_67 = GetNamedIntegerArrayEntry(array, "TienGuiBho", new int[3] { 0, 15, 100000 });
		characterAccountConfig_0.int_65 = GetNamedIntegerArrayEntry(array, "flagTienMangtheo", new int[1] { 1 })[0];
		characterAccountConfig_0.int_66 = GetNamedIntegerArrayEntry(array, "TienMangtheo", new int[1] { 15000 })[0];
		characterAccountConfig_0.int_68 = GetNamedIntegerArrayEntry(array, "TheoSau", new int[3] { 0, 200, 0 });
		characterAccountConfig_0.string_9 = string.Empty;
		array12 = GetNamedStringArrayEntry(array, "NameTheoSau", null);
		if (array12 != null && array12.Length != 0)
		{
			characterAccountConfig_0.string_9 = CommonUtility.DecodeBase64Utf8(array12[0]);
		}
		string[] string_48 = array;
		int_ = new int[2];
		characterAccountConfig_0.int_138 = GetNamedIntegerArrayEntry(string_48, "GanChieuTrai", int_);
		string[] string_49 = array;
		int_ = new int[2];
		characterAccountConfig_0.int_139 = GetNamedIntegerArrayEntry(string_49, "GanChieuPhai", int_);
		characterAccountConfig_0.int_140 = GetNamedIntegerArrayEntry(array, "Tran1Phai", new int[3] { 0, 10000, 90000 });
		characterAccountConfig_0.int_141 = GetNamedIntegerArrayEntry(array, "Tran2Phai", new int[3] { 0, 10000, 80000 });
		characterAccountConfig_0.int_142 = GetNamedIntegerArrayEntry(array, "Tran3Phai", new int[3] { 0, 10000, 70000 });
		if (characterAccountConfig_0.int_140[1] == 10000 || characterAccountConfig_0.int_141[1] == 10000 || characterAccountConfig_0.int_142[1] == 10000)
		{
			characterAccountConfig_0.int_140[1] = 0;
			characterAccountConfig_0.int_141[1] = 0;
			characterAccountConfig_0.int_142[1] = 0;
			int[] array13 = CharacterSkillHelper.GetDefaultRightSkillIdsForCurrentFaction(characterAccountConfig_0);
			if (array13 != null)
			{
				if (array13.Length != 0)
				{
					characterAccountConfig_0.int_140[0] = Convert.ToByte(CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, array13[0]) > 0);
					characterAccountConfig_0.int_140[1] = array13[0];
				}
				if (array13.Length > 1)
				{
					characterAccountConfig_0.int_141[0] = Convert.ToByte(CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, array13[1]) > 0);
					characterAccountConfig_0.int_141[1] = array13[1];
				}
				if (array13.Length > 2)
				{
					characterAccountConfig_0.int_142[0] = Convert.ToByte(CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, array13[2]) > 0);
					characterAccountConfig_0.int_142[1] = array13[2];
				}
			}
		}
		int num = CharacterSkillHelper.ReadLeftSkillId(characterAccountConfig_0);
		int num2 = CharacterSkillHelper.ReadRightSkillId(characterAccountConfig_0);
		string[] string_50 = array;
		int_ = new int[12]
		{
			0, 0, 600, 0, 0, 0, 600, 0, 0, 0,
			600, 0
		};
		int_[1] = num;
		int_[5] = num;
		int_[9] = num;
		int[] array14 = GetNamedIntegerArrayEntry(string_50, "tbChuyenTR", int_);
		characterAccountConfig_0.gstruct48_0 = new GStruct48[3]
		{
			new GStruct48
			{
				int_0 = array14[0],
				int_1 = array14[1],
				int_2 = array14[2],
				int_3 = array14[3]
			},
			new GStruct48
			{
				int_0 = array14[4],
				int_1 = array14[5],
				int_2 = array14[6],
				int_3 = array14[7]
			},
			new GStruct48
			{
				int_0 = array14[8],
				int_1 = array14[9],
				int_2 = array14[10],
				int_3 = array14[11]
			}
		};
		string[] string_51 = array;
		int_ = new int[12]
		{
			0, 0, 600, 0, 0, 0, 600, 0, 0, 0,
			600, 0
		};
		int_[1] = num2;
		int_[5] = num2;
		int_[9] = num2;
		int[] array15 = GetNamedIntegerArrayEntry(string_51, "tbChuyenPH", int_);
		characterAccountConfig_0.gstruct48_1 = new GStruct48[3]
		{
			new GStruct48
			{
				int_0 = array15[0],
				int_1 = array15[1],
				int_2 = array15[2],
				int_3 = array15[3]
			},
			new GStruct48
			{
				int_0 = array15[4],
				int_1 = array15[5],
				int_2 = array15[6],
				int_3 = array15[7]
			},
			new GStruct48
			{
				int_0 = array15[8],
				int_1 = array15[9],
				int_2 = array15[10],
				int_3 = array15[11]
			}
		};
		int[] array16 = GetNamedIntegerArrayEntry(array, "GapBossChieu", new int[4] { 0, num, 1, 100 });
		characterAccountConfig_0.gstruct48_2 = new GStruct48
		{
			int_0 = array16[0],
			int_1 = array16[1],
			int_3 = array16[2],
			int_2 = array16[3]
		};
		characterAccountConfig_0.string_10 = "null";
		string[] array17 = GetNamedStringArrayEntry(array, "tRaovat", null);
		if (array17 != null && array17.Length != 0)
		{
			array17[0] = CommonUtility.DecodeBase64Utf8(array17[0]);
			if (array17[0] != string.Empty && array17[0] != null)
			{
				characterAccountConfig_0.string_10 = array17[0];
			}
		}
		characterAccountConfig_0.int_69 = GetNamedIntegerArrayEntry(array, "fRao", new int[5] { 0, 0, 30000, 0, 1 });
		characterAccountConfig_0.gstruct49_0.targetName = string_22;
		array17 = GetNamedStringArrayEntry(array, "NhatQuaName", null);
		if (array17 != null && array17.Length != 0)
		{
			array17[0] = CommonUtility.DecodeBase64Utf8(array17[0]);
			if (array17[0] != string.Empty && array17[0] != null)
			{
				characterAccountConfig_0.gstruct49_0.targetName = array17[0];
			}
		}
		int[] array18 = GetNamedIntegerArrayEntry(array, "tbNhatQua", new int[9] { 0, 0, 12, 5, 1, 150, 0, 20000, 1 });
		characterAccountConfig_0.gstruct49_0.pickupEnabled = 0;
		characterAccountConfig_0.gstruct49_0.scheduledStartEnabled = array18[1];
		characterAccountConfig_0.gstruct49_0.startHour = array18[2];
		characterAccountConfig_0.gstruct49_0.startMinute = array18[3];
		characterAccountConfig_0.gstruct49_0.startSecond = array18[4];
		characterAccountConfig_0.gstruct49_0.pickupRadius = array18[5];
		characterAccountConfig_0.gstruct49_0.collectionBoxEnabled = array18[6];
		characterAccountConfig_0.gstruct49_0.collectionBoxTimeoutMilliseconds = array18[7];
		characterAccountConfig_0.gstruct49_0.fixedPositionEnabled = array18[8];
		characterAccountConfig_0.int_133 = GetNamedIntegerArrayEntry(array, "BosST", new int[5] { 0, 0, 80, 0, 0 });
		string[] string_52 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_134 = GetNamedIntegerArrayEntry(string_52, "STHaucan", int_)[0];
		string[] string_53 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_135 = GetNamedIntegerArrayEntry(string_53, "VSTClick", int_)[0];
		string[] string_54 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_126 = GetNamedIntegerArrayEntry(string_54, "fNotDame", int_)[0];
		string[] string_55 = array;
		int_ = new int[5];
		characterAccountConfig_0.int_127 = GetNamedIntegerArrayEntry(string_55, "DameChieu12", int_);
		string[] string_56 = array;
		int_ = new int[7];
		characterAccountConfig_0.int_128 = GetNamedIntegerArrayEntry(string_56, "DMBoom", int_);
		characterAccountConfig_0.int_129 = GetNamedIntegerArrayEntry(array, "tbKeyXuat", new int[6] { 0, 0, 0, 114, 115, 116 });
		characterAccountConfig_0.int_130 = GetNamedIntegerArrayEntry(array, "tbCaudame", new int[2] { 0, 250 });
		int[] array19 = GetNamedIntegerArrayEntry(array, "tbTienSkill", new int[10] { 0, 0, 0, 8000, 0, 1, 6, 120, 1, 400 });
		characterAccountConfig_0.gstruct50_0 = new GStruct50
		{
			enabled = array19[0],
			skillId = array19[1],
			triggerMode = array19[2],
			triggerIntervalMilliseconds = array19[3],
			combinedCastModeEnabled = array19[4],
			monsterTargetEnabled = array19[5],
			minimumCastIntervalSeconds = array19[6],
			targetDistanceThreshold = array19[7],
			postCastSearchDistanceAdjustmentEnabled = array19[8],
			postCastSearchDistance = array19[9]
		};
		string[] string_57 = array;
		int_ = new int[2];
		characterAccountConfig_0.int_131 = GetNamedIntegerArrayEntry(string_57, "fQuangthuoc", int_);
		characterAccountConfig_0.int_131[1] = 0;
		characterAccountConfig_0.int_74 = GetNamedIntegerArrayEntry(array, "flagTuGiaidoc", new int[3] { 0, 4500, 1 });
		string[] string_58 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_79 = GetNamedIntegerArrayEntry(string_58, "RuongBH", int_)[0];
		characterAccountConfig_0.int_76 = GetNamedIntegerArrayEntry(array, "ChThuoc", new int[5] { 0, 0, 0, 5, 0 });
		array17 = GetNamedStringArrayEntry(array, "fTenThuoc", null);
		characterAccountConfig_0.string_14 = "H·y chän 1 vËt phÈm";
		if (array17 != null && array17.Length != 0)
		{
			array17[0] = CommonUtility.DecodeBase64Utf8(array17[0]);
			if (array17[0] != string.Empty && array17[0] != null)
			{
				characterAccountConfig_0.string_14 = array17[0];
			}
		}
		string[] string_59 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_78 = GetNamedIntegerArrayEntry(string_59, "MuaFree", int_)[0];
		string[] string_60 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_77 = GetNamedIntegerArrayEntry(string_60, "MuaKTC", int_)[0];
		string[] string_61 = array;
		string[] string_62 = new string[3];
		array17 = GetNamedStringArrayEntry(string_61, "tbKTCTabName", string_62);
		string[] string_63 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_70 = GetNamedIntegerArrayEntry(string_63, "flagMuaNgamy", int_)[0];
		characterAccountConfig_0.int_71 = GetNamedIntegerArrayEntry(array, "flagMuaThuocHP", new int[3] { 0, 0, 40 });
		characterAccountConfig_0.string_11 = "H·y mua tr\u00adíc 1 b×nh thuèc";
		array17 = GetNamedStringArrayEntry(array, "TenHP", null);
		if (array17 != null && array17.Length != 0)
		{
			array17[0] = CommonUtility.DecodeBase64Utf8(array17[0]);
			if (array17[0] != string.Empty && array17[0] != null)
			{
				characterAccountConfig_0.string_11 = array17[0];
			}
		}
		characterAccountConfig_0.int_72 = GetNamedIntegerArrayEntry(array, "flagMuaThuocMP", new int[3] { 0, 0, 15 });
		characterAccountConfig_0.string_12 = "H·y mua tr\u00adíc 1 b×nh thuèc";
		array17 = GetNamedStringArrayEntry(array, "TenMP", null);
		if (array17 != null && array17.Length != 0)
		{
			array17[0] = CommonUtility.DecodeBase64Utf8(array17[0]);
			if (array17[0] != string.Empty && array17[0] != null)
			{
				characterAccountConfig_0.string_12 = array17[0];
			}
		}
		characterAccountConfig_0.int_73 = GetNamedIntegerArrayEntry(array, "flagMuaGiaiDoc", new int[3] { 0, 0, 10 });
		characterAccountConfig_0.string_13 = "H·y mua tr\u00adíc 1 b×nh thuèc";
		array17 = GetNamedStringArrayEntry(array, "TenGiaiDoc", null);
		if (array17 != null && array17.Length != 0)
		{
			array17[0] = CommonUtility.DecodeBase64Utf8(array17[0]);
			if (array17[0] != string.Empty && array17[0] != null)
			{
				characterAccountConfig_0.string_13 = array17[0];
			}
		}
		characterAccountConfig_0.int_75 = GetNamedIntegerArrayEntry(array, "GanTenthuoc", new int[5] { 0, 2, 0, 0, 0 });
		characterAccountConfig_0.int_92 = GetNamedIntegerArrayEntry(array, "flagDoiPk", new int[1] { 1 })[0];
		characterAccountConfig_0.int_93 = GetNamedIntegerArrayEntry(array, "flagXuongngua", new int[1] { 1 })[0];
		string[] string_64 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_94 = GetNamedIntegerArrayEntry(string_64, "ChetNamIm", int_)[0];
		string[] string_65 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_100 = GetNamedIntegerArrayEntry(string_65, "flagDanhphim", int_)[0];
		string[] string_66 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_119 = GetNamedIntegerArrayEntry(string_66, "flagTuCastBua", int_)[0];
		string[] string_67 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_103 = GetNamedIntegerArrayEntry(string_67, "flagTuPT", int_)[0];
		characterAccountConfig_0.int_104 = GetNamedIntegerArrayEntry(array, "TDPKhiPk", new int[2] { 1, 9 });
		string[] string_68 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_105 = GetNamedIntegerArrayEntry(string_68, "flagTuChayMuaThuocHoaSon", int_)[0];
		string[] string_69 = array;
		int_ = new int[2];
		characterAccountConfig_0.int_12 = GetNamedIntegerArrayEntry(string_69, "fBanEvent", int_);
		int num3 = 0;
		array12 = GetNamedStringArrayEntry(array, "MoTuiThuoc", null);
		if (array12 != null && array12.Length != 0)
		{
			string text3 = CommonUtility.DecodeBase64Utf8(array12[0]);
			if (array12[0] != string.Empty && array12[0] != null)
			{
				string[] array20 = text3.Split('|');
				GStruct36[] array21 = new GStruct36[array20.Length];
				for (int n = 0; n < array21.Length; n++)
				{
					string text4 = array20[n];
					if (text4 == null || text4 == string.Empty)
					{
						continue;
					}
					string[] array22 = text4.Split('\u0001');
					if (array22.Length < 8)
					{
						continue;
					}
					array21[num3].medicineBagItemName = array22[0];
					array21[num3].quantityInputEnabled = CommonUtility.ParseInt32OrZero(array22[1]);
					array21[num3].timeTriggerEnabled = CommonUtility.ParseInt32OrZero(array22[2]);
					array21[num3].remainingQuantityThreshold = CommonUtility.ParseInt32OrZero(array22[3]);
					array21[num3].menuSelectionSequence = new int[2] { 1, 1 };
					string[] array23 = array22[4].Split('_');
					if (array23 != null)
					{
						array21[num3].menuSelectionSequence = new int[array23.Length];
						for (int num4 = 0; num4 < array23.Length; num4++)
						{
							array21[num3].menuSelectionSequence[num4] = CommonUtility.ParseInt32OrZero(array23[num4]);
						}
					}
					array21[num3].timeIntervalMilliseconds = CommonUtility.ParseInt32OrZero(array22[5]);
					array21[num3].quantityTriggerEnabled = CommonUtility.ParseInt32OrZero(array22[6]);
					array21[num3].menuClickEnabled = CommonUtility.ParseInt32OrZero(array22[7]);
					if (array22.Length > 8)
					{
						array21[num3].stateChangeTriggerEnabled = CommonUtility.ParseInt32OrZero(array22[8]);
					}
					if (array22.Length > 9)
					{
						array21[num3].pauseAutomationWhileUsingEnabled = CommonUtility.ParseInt32OrZero(array22[9]);
					}
					if (array22.Length > 11)
					{
						array21[num3].useSpecificMedicineNameEnabled = CommonUtility.ParseInt32OrZero(array22[10]);
					}
					if (array22.Length > 10)
					{
						array21[num3].remainingMedicineItemName = array22[11];
					}
					num3++;
				}
				if (num3 > 0)
				{
					characterAccountConfig_0.gstruct36_0 = new GStruct36[num3];
					for (int num5 = 0; num5 < num3; num5++)
					{
						characterAccountConfig_0.gstruct36_0[num5].medicineBagItemName = array21[num5].medicineBagItemName;
						characterAccountConfig_0.gstruct36_0[num5].quantityInputEnabled = array21[num5].quantityInputEnabled;
						characterAccountConfig_0.gstruct36_0[num5].timeTriggerEnabled = array21[num5].timeTriggerEnabled;
						characterAccountConfig_0.gstruct36_0[num5].remainingQuantityThreshold = array21[num5].remainingQuantityThreshold;
						characterAccountConfig_0.gstruct36_0[num5].menuSelectionSequence = new int[2] { 1, 1 };
						if (array21[num5].menuSelectionSequence != null)
						{
							characterAccountConfig_0.gstruct36_0[num5].menuSelectionSequence = new int[array21[num5].menuSelectionSequence.Length];
							for (int num6 = 0; num6 < array21[num5].menuSelectionSequence.Length; num6++)
							{
								characterAccountConfig_0.gstruct36_0[num5].menuSelectionSequence[num6] = array21[num5].menuSelectionSequence[num6];
							}
						}
						characterAccountConfig_0.gstruct36_0[num5].timeIntervalMilliseconds = array21[num5].timeIntervalMilliseconds;
						characterAccountConfig_0.gstruct36_0[num5].quantityTriggerEnabled = array21[num5].quantityTriggerEnabled;
						characterAccountConfig_0.gstruct36_0[num5].menuClickEnabled = array21[num5].menuClickEnabled;
						characterAccountConfig_0.gstruct36_0[num5].stateChangeTriggerEnabled = array21[num5].stateChangeTriggerEnabled;
						characterAccountConfig_0.gstruct36_0[num5].pauseAutomationWhileUsingEnabled = array21[num5].pauseAutomationWhileUsingEnabled;
						characterAccountConfig_0.gstruct36_0[num5].useSpecificMedicineNameEnabled = array21[num5].useSpecificMedicineNameEnabled;
						characterAccountConfig_0.gstruct36_0[num5].remainingMedicineItemName = array21[num5].remainingMedicineItemName;
					}
				}
			}
		}
		if (num3 == 0)
		{
			characterAccountConfig_0.gstruct36_0 = new GStruct36[1]
			{
				new GStruct36
				{
					medicineBagItemName = "Håi thiªn t\u00b8i t¹o lÔ bao",
					remainingMedicineItemName = "Ngò Hoa Ngäc Lé Hoµn",
					useSpecificMedicineNameEnabled = 0,
					timeTriggerEnabled = 0,
					stateChangeTriggerEnabled = 0,
					pauseAutomationWhileUsingEnabled = 0,
					timeIntervalMilliseconds = 60000,
					quantityTriggerEnabled = 0,
					remainingQuantityThreshold = 5,
					quantityInputEnabled = 1,
					menuClickEnabled = 0,
					menuSelectionSequence = new int[2] { 1, 1 }
				}
			};
		}
		characterAccountConfig_0.int_101 = GetNamedIntegerArrayEntry(array, "fNgamyBuff", new int[8] { 0, 0, 0, 101, 800, 400, 0, 0 });
		characterAccountConfig_0.int_106 = GetNamedIntegerArrayEntry(array, "BomHPDiem", new int[4] { 0, 1000, 1500, 1 });
		characterAccountConfig_0.int_107 = GetNamedIntegerArrayEntry(array, "BomMPDiem", new int[4] { 0, 200, 2500, 1 });
		characterAccountConfig_0.int_109 = GetNamedIntegerArrayEntry(array, "BomHPRatio", new int[4] { 1, 85, 1500, 1 });
		characterAccountConfig_0.int_110 = GetNamedIntegerArrayEntry(array, "BomM2HPRatio", new int[4] { 1, 75, 1500, 1 });
		characterAccountConfig_0.int_111 = GetNamedIntegerArrayEntry(array, "BomMPRatio", new int[4] { 1, 25, 2500, 1 });
		characterAccountConfig_0.int_112 = GetNamedIntegerArrayEntry(array, "BomM2MPRatio", new int[4] { 0, 0, 1500, 1 });
		string[] string_70 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_108 = GetNamedIntegerArrayEntry(string_70, "flagUuTienBomCuuChuyen", int_)[0];
		characterAccountConfig_0.int_113 = GetNamedIntegerArrayEntry(array, "HPTdp", new int[2] { 0, 40 });
		characterAccountConfig_0.int_114 = GetNamedIntegerArrayEntry(array, "MPTdp", new int[2] { 0, 30 });
		string[] string_71 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_115 = GetNamedIntegerArrayEntry(string_71, "flagTDPKhiSoluongMau", int_)[0];
		string[] string_72 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_116 = GetNamedIntegerArrayEntry(string_72, "TDPSoluongMauConlai", int_)[0];
		string[] string_73 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_117 = GetNamedIntegerArrayEntry(string_73, "flagTDPKhiSoluongMana", int_)[0];
		string[] string_74 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_118 = GetNamedIntegerArrayEntry(string_74, "TDPSoluongManaConlai", int_)[0];
		characterAccountConfig_0.string_16 = "Ngò Hoa Ngäc Lé Hoµn";
		characterAccountConfig_0.string_17 = "¤ ®Çu Hoµn thÇn ®an";
		array17 = GetNamedStringArrayEntry(array, "TenMauMuc2", null);
		if (array17 != null && array17.Length != 0)
		{
			array17[0] = CommonUtility.DecodeBase64Utf8(array17[0]);
			if (array17[0] != string.Empty && array17[0] != null)
			{
				characterAccountConfig_0.string_16 = array17[0];
			}
		}
		array17 = GetNamedStringArrayEntry(array, "TenManaMuc2", null);
		if (array17 != null && array17.Length != 0)
		{
			array17[0] = CommonUtility.DecodeBase64Utf8(array17[0]);
			if (array17[0] != string.Empty && array17[0] != null)
			{
				characterAccountConfig_0.string_17 = array17[0];
			}
		}
		characterAccountConfig_0.string_18 = null;
		array12 = GetNamedStringArrayEntry(array, "DanhsachCuusat", null);
		if (array12 != null && array12.Length != 0)
		{
			array12[0] = CommonUtility.DecodeBase64Utf8(array12[0]);
			if (array12[0] != string.Empty && array12[0] != null)
			{
				characterAccountConfig_0.string_18 = array12[0].Split('|');
			}
		}
		string[] string_75 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_120 = GetNamedIntegerArrayEntry(string_75, "flagCuusatTheodanhsach", int_)[0];
		characterAccountConfig_0.string_19 = null;
		array17 = GetNamedStringArrayEntry(array, "PTDanhsach", null);
		if (array17 != null && array17.Length != 0)
		{
			array17[0] = CommonUtility.DecodeBase64Utf8(array17[0]);
			if (array17[0] != string.Empty && array17[0] != null)
			{
				characterAccountConfig_0.string_19 = array17[0].Split('|');
			}
		}
		string[] string_76 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_122 = GetNamedIntegerArrayEntry(string_76, "fTuchayToadoVA", int_)[0];
		string[] string_77 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_123 = GetNamedIntegerArrayEntry(string_77, "fClickNTT", int_)[0];
		string[] string_78 = array;
		int_ = new int[5];
		characterAccountConfig_0.int_125 = GetNamedIntegerArrayEntry(string_78, "fDenToado", int_);
		characterAccountConfig_0.int_124 = new int[3]
		{
			characterAccountConfig_0.int_125[2],
			characterAccountConfig_0.int_125[3],
			characterAccountConfig_0.int_125[4]
		};
		string[] string_79 = array;
		int_ = new int[5];
		characterAccountConfig_0.int_121 = GetNamedIntegerArrayEntry(string_79, "PTflag", int_);
		characterAccountConfig_0.int_89 = GetNamedIntegerArrayEntry(array, "GiamCpuLevel", new int[1] { 1 })[0];
		characterAccountConfig_0.int_1 = GetNamedIntegerArrayEntry(array, "fBaoBoss", new int[1] { 1 })[0];
		int int_2 = CurrentCharacterMemoryHelper.GetCharacterFiveElementIndex(characterAccountConfig_0);
		string[] string_80 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_88 = GetNamedIntegerArrayEntry(string_80, "KieuDanh", int_)[0];
		characterAccountConfig_0.int_90 = GetNamedIntegerArrayEntry(array, "tbNguhanh", CopyFiveValueConfigurationRow(int_2));
		int[] array24 = new int[CharacterSkillHelper.gstruct57_0.Length];
		for (int num7 = 0; num7 < CharacterSkillHelper.gstruct57_0.Length; num7++)
		{
			array24[num7] = CharacterSkillHelper.gstruct57_0[num7].int_0;
		}
		characterAccountConfig_0.int_91 = GetNamedIntegerArrayEntry(array, "tbMonPhai", array24);
		characterAccountConfig_0.string_23 = CharacterSkillHelper.ResolveFactionIdentifier(characterAccountConfig_0);
		characterAccountConfig_0.int_3 = null;
		characterAccountConfig_0.int_4 = null;
		int[] array25 = GetNamedIntegerArrayEntry(array, "tbValueMagic", null);
		if (characterAccountConfig_0.string_23 == "NGUDOC" || characterAccountConfig_0.string_23 == "THIENNHAN" || characterAccountConfig_0.string_23 == "CONLON")
		{
			characterAccountConfig_0.int_4 = GetNamedFactionPairTable(characterAccountConfig_0.string_23);
			if (array25 != null)
			{
				int num8 = 0;
				int[] array26 = new int[array25.Length];
				int[] array27 = new int[array25.Length];
				for (int num9 = 0; num9 < array26.Length; num9++)
				{
					if (array25[num9] > 0)
					{
						int num10 = CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, array25[num9]);
						if (num10 > 0)
						{
							array26[num8] = array25[num9];
							array27[num8] = num10;
							num8++;
						}
					}
				}
				if (num8 > 0)
				{
					if (num8 > 4)
					{
						num8 = 4;
					}
					characterAccountConfig_0.int_3 = new int[num8, 2];
					for (int num11 = 0; num11 < num8; num11++)
					{
						characterAccountConfig_0.int_3[num11, 0] = array26[num11];
						characterAccountConfig_0.int_3[num11, 1] = array27[num11];
					}
				}
			}
		}
		string[] string_81 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_5 = GetNamedIntegerArrayEntry(string_81, "flagBuffDoituong", int_)[0];
		string[] string_82 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_6 = GetNamedIntegerArrayEntry(string_82, "flagChiBuffKhongDanh", int_)[0];
		characterAccountConfig_0.int_80 = Convert.ToByte(characterAccountConfig_0.string_23 == "VODANG") * GetNamedIntegerArrayEntry(array, "flagTuGiaiBua", new int[1] { 1 })[0];
		characterAccountConfig_0.int_81 = GetNamedIntegerArrayEntry(array, "flagGiaibuaBangsat", new int[1] { 1 })[0];
		string[] string_83 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_82 = GetNamedIntegerArrayEntry(string_83, "flagGiaibuaTheoThoigian", int_)[0];
		byte b = Convert.ToByte(characterAccountConfig_0.string_23 == "THIENNHAN");
		string[] string_84 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_83 = b * GetNamedIntegerArrayEntry(string_84, "flagTNXuatChieu120", int_)[0];
		string[] string_85 = array;
		int_ = new int[2];
		characterAccountConfig_0.int_84 = GetNamedIntegerArrayEntry(string_85, "flagCLon", int_);
		if (characterAccountConfig_0.int_84 == null)
		{
			characterAccountConfig_0.int_84 = new int[2];
		}
		characterAccountConfig_0.int_84[0] = Convert.ToByte(characterAccountConfig_0.string_23 == "CONLON") * characterAccountConfig_0.int_84[0];
		characterAccountConfig_0.int_84[1] = Convert.ToByte(characterAccountConfig_0.string_23 == "CONLON") * characterAccountConfig_0.int_84[1];
		characterAccountConfig_0.int_85 = GetNamedIntegerArrayEntry(array, "TimerTuGiaibua", new int[1] { 6500 })[0];
		characterAccountConfig_0.int_87 = GetNamedIntegerArrayEntry(array, "TimerTheoThoigian", new int[1] { 28000 })[0];
		characterAccountConfig_0.int_86 = GetNamedIntegerArrayEntry(array, "TamBuffbua", new int[1] { 440 })[0];
		characterAccountConfig_0.string_0 = "Tæng qu¶n ThÝ luyÖn ph\u00adêng";
		array17 = GetNamedStringArrayEntry(array, "ClickNPCName", null);
		if (array17 != null && array17.Length != 0)
		{
			array17[0] = CommonUtility.DecodeBase64Utf8(array17[0]);
			if (array17[0] != string.Empty && array17[0] != null)
			{
				characterAccountConfig_0.string_0 = array17[0];
			}
		}
		characterAccountConfig_0.int_7 = GetNamedIntegerArrayEntry(array, "ClickNPCSolan", new int[2] { 0, 3 });
		characterAccountConfig_0.int_9 = GetNamedIntegerArrayEntry(array, "tbClickNpcMenu", new int[4] { 1, 2, 1, 1 });
		string[] string_86 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_8 = GetNamedIntegerArrayEntry(string_86, "fClickNpcMenu", int_)[0];
		characterAccountConfig_0.int_10 = GetNamedIntegerArrayEntry(array, "ClickNPCTocdo", new int[1] { 300 })[0];
		characterAccountConfig_0.int_11 = GetNamedIntegerArrayEntry(array, "ClickLocTocdo", new int[1] { 300 })[0];
		characterAccountConfig_0.int_13 = GetNamedIntegerArrayEntry(array, "fClickNPC_Sudung", new int[4] { 0, 0, 1, 0 });
		string[] string_87 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_15 = GetNamedIntegerArrayEntry(string_87, "flagClickNpcSau", int_)[0];
		characterAccountConfig_0.int_14 = GetNamedIntegerArrayEntry(array, "MenuVatphamNpc", new int[2] { 1, 2 });
		characterAccountConfig_0.string_1 = "CÈm nang t©n thñ";
		array17 = GetNamedStringArrayEntry(array, "TenVatphamNpc", null);
		if (array17 != null && array17.Length != 0)
		{
			array17[0] = CommonUtility.DecodeBase64Utf8(array17[0]);
			if (array17[0] != string.Empty && array17[0] != null)
			{
				characterAccountConfig_0.string_1 = array17[0];
			}
		}
		characterAccountConfig_0.int_16 = GetNamedIntegerArrayEntry(array, "fClickNPC_Nop", new int[2] { 0, 1 });
		characterAccountConfig_0.gstruct33_0 = null;
		array17 = GetNamedStringArrayEntry(array, "ClickNPC_Nop", null);
		if (array17 != null && array17.Length != 0)
		{
			array17[0] = CommonUtility.DecodeBase64Utf8(array17[0]);
			if (array17[0] != null && array17[0] != string.Empty)
			{
				array17 = array17[0].Split('|');
				characterAccountConfig_0.gstruct33_0 = new GStruct33[array17.Length];
				int num12 = 0;
				for (int num13 = 0; num13 < array17.Length; num13++)
				{
					if (array17[num13] != null && !(array17[num13] == string.Empty))
					{
						string[] array28 = array17[num13].Split('=');
						if (array28.Length == 2)
						{
							ref GStruct33 reference = ref characterAccountConfig_0.gstruct33_0[num12];
							reference = new GStruct33
							{
								string_0 = array28[0],
								int_4 = CommonUtility.ParseInt32OrZero(array28[1])
							};
							num12++;
						}
					}
				}
				if (num12 != 0)
				{
					if (num12 < characterAccountConfig_0.gstruct33_0.Length)
					{
						Array.Resize(ref characterAccountConfig_0.gstruct33_0, num12);
					}
				}
				else
				{
					characterAccountConfig_0.gstruct33_0 = null;
				}
			}
		}
		characterAccountConfig_0.int_17 = GetNamedIntegerArrayEntry(array, "fClickNPC_MuaVP", new int[5] { 0, 1, 1, 1, 0 });
		characterAccountConfig_0.string_2 = null;
		array17 = GetNamedStringArrayEntry(array, "ClickNPC_TabKTC", null);
		if (array17 != null && array17.Length != 0)
		{
			characterAccountConfig_0.string_2 = CommonUtility.DecodeBase64Utf8(array17[0]);
		}
		characterAccountConfig_0.gstruct33_1 = default(GStruct33);
		array17 = GetNamedStringArrayEntry(array, "ClickNPC_Mua", null);
		if (array17 != null && array17.Length != 0)
		{
			array17[0] = CommonUtility.DecodeBase64Utf8(array17[0]);
			if (array17[0] != null && array17[0] != string.Empty)
			{
				array17 = array17[0].Split('=');
				characterAccountConfig_0.gstruct33_1.string_0 = array17[0];
				characterAccountConfig_0.gstruct33_1.int_4 = CommonUtility.ParseInt32OrZero(array17[1]);
			}
		}
		string[] string_88 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_33 = GetNamedIntegerArrayEntry(string_88, "XulyDosat", int_)[0];
		string[] string_89 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_25 = GetNamedIntegerArrayEntry(string_89, "flagTrains", int_)[0];
		string[] string_90 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_26 = GetNamedIntegerArrayEntry(string_90, "flagTucheHT", int_)[0];
		characterAccountConfig_0.int_27 = GetNamedIntegerArrayEntry(array, "DanhQuaiTrain", new int[1] { 1 })[0];
		string[] string_91 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_32 = GetNamedIntegerArrayEntry(string_91, "MapIDTrain", int_)[0];
		characterAccountConfig_0.int_28 = GetNamedIntegerArrayEntry(array, "TDPHettien", new int[1] { 1 })[0];
		string[] string_92 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_29 = GetNamedIntegerArrayEntry(string_92, "ToadoVong", int_)[0];
		characterAccountConfig_0.int_30 = GetNamedIntegerArrayEntry(array, "DanhTrenDuongdi", new int[1] { 1 })[0];
		string[] string_93 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_31 = GetNamedIntegerArrayEntry(string_93, "QuayQuai", int_)[0];
		array17 = GetNamedStringArrayEntry(array, "ToadoTrain", null);
		if (array17 != null && array17.Length != 0)
		{
			array17 = CommonUtility.DecodeBase64Utf8(array17[0]).Split('|');
			int num14 = 0;
			uint[,] array29 = new uint[array17.Length, 2];
			for (int num15 = 0; num15 < array17.Length; num15++)
			{
				string[] array30 = array17[num15].Split(';');
				if (array30.Length > 1)
				{
					uint num16 = CommonUtility.ParseUInt32OrZero(array30[0]);
					uint num17 = CommonUtility.ParseUInt32OrZero(array30[1]);
					if (num16 != 0 && num17 != 0)
					{
						array29[num14, 0] = num16;
						array29[num14, 1] = num17;
						num14++;
					}
				}
			}
			if (num14 > 0)
			{
				characterAccountConfig_0.uint_0 = new uint[num14, 2];
				for (int num18 = 0; num18 < num14; num18++)
				{
					characterAccountConfig_0.uint_0[num18, 0] = array29[num18, 0];
					characterAccountConfig_0.uint_0[num18, 1] = array29[num18, 1];
				}
			}
		}
		string[] string_94 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_34 = GetNamedIntegerArrayEntry(string_94, "flagChayPkNguoidung", int_)[0];
		string[] string_95 = array;
		int_ = new int[2];
		characterAccountConfig_0.int_20 = GetNamedIntegerArrayEntry(string_95, "fTinSu", int_);
		string[] string_96 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_35 = GetNamedIntegerArrayEntry(string_96, "MapIDPk1", int_)[0];
		string[] string_97 = array;
		int_ = new int[1];
		characterAccountConfig_0.int_36 = GetNamedIntegerArrayEntry(string_97, "MapIDPk2", int_)[0];
		array17 = GetNamedStringArrayEntry(array, "ToadoPk1", null);
		if (array17 != null && array17.Length != 0)
		{
			array17 = CommonUtility.DecodeBase64Utf8(array17[0]).Split('|');
			int num19 = 0;
			uint[,] array31 = new uint[array17.Length, 2];
			for (int num20 = 0; num20 < array17.Length; num20++)
			{
				string[] array32 = array17[num20].Split(';');
				if (array32.Length > 1)
				{
					uint num21 = CommonUtility.ParseUInt32OrZero(array32[0]);
					uint num22 = CommonUtility.ParseUInt32OrZero(array32[1]);
					if (num21 != 0 && num22 != 0)
					{
						array31[num19, 0] = num21;
						array31[num19, 1] = num22;
						num19++;
					}
				}
			}
			if (num19 > 0)
			{
				characterAccountConfig_0.uint_2 = new uint[num19, 2];
				for (int num23 = 0; num23 < num19; num23++)
				{
					characterAccountConfig_0.uint_2[num23, 0] = array31[num23, 0];
					characterAccountConfig_0.uint_2[num23, 1] = array31[num23, 1];
				}
			}
		}
		array17 = GetNamedStringArrayEntry(array, "ToadoPk2", null);
		if (array17 != null && array17.Length != 0)
		{
			array17 = CommonUtility.DecodeBase64Utf8(array17[0]).Split('|');
			int num24 = 0;
			uint[,] array33 = new uint[array17.Length, 2];
			for (int num25 = 0; num25 < array17.Length; num25++)
			{
				string[] array34 = array17[num25].Split(';');
				if (array34.Length > 1)
				{
					uint num26 = CommonUtility.ParseUInt32OrZero(array34[0]);
					uint num27 = CommonUtility.ParseUInt32OrZero(array34[1]);
					if (num26 != 0 && num27 != 0)
					{
						array33[num24, 0] = num26;
						array33[num24, 1] = num27;
						num24++;
					}
				}
			}
			if (num24 > 0)
			{
				characterAccountConfig_0.uint_3 = new uint[num24, 2];
				for (int num28 = 0; num28 < num24; num28++)
				{
					characterAccountConfig_0.uint_3[num28, 0] = array33[num28, 0];
					characterAccountConfig_0.uint_3[num28, 1] = array33[num28, 1];
				}
			}
		}
		characterAccountConfig_0.bool_5 = true;
		characterAccountConfig_0.int_21 = 5;
		characterAccountConfig_0.byte_0 = new byte[11];
		characterAccountConfig_0.gstruct47_0 = new GStruct47[2];
		array17 = GetNamedStringArrayEntry(array, "TenVukhi", null);
		if (array17 != null && array17.Length != 0)
		{
			array17 = CommonUtility.DecodeBase64Utf8(array17[0]).Split('|');
			characterAccountConfig_0.gstruct47_0[0].string_0 = array17[0];
			if (array17.Length > 1)
			{
				characterAccountConfig_0.gstruct47_0[1].string_0 = array17[1];
			}
		}
		int[] array35 = GetNamedIntegerArrayEntry(array, "tbVukhi0", new int[5] { 0, 0, 0, 500, 0 });
		characterAccountConfig_0.gstruct47_0[0].int_0 = array35[0];
		characterAccountConfig_0.gstruct47_0[0].int_1 = array35[1];
		characterAccountConfig_0.gstruct47_0[0].int_3 = array35[2];
		characterAccountConfig_0.gstruct47_0[0].int_2 = array35[3];
		characterAccountConfig_0.gstruct47_0[0].int_4 = array35[4];
		characterAccountConfig_0.gstruct47_0[0].int_5 = GetNamedIntegerArrayEntry(array, "TTVukhi0", null);
		array35 = GetNamedIntegerArrayEntry(array, "tbVukhi1", new int[5] { 0, 0, 0, 500, 0 });
		characterAccountConfig_0.gstruct47_0[1].int_0 = array35[0];
		characterAccountConfig_0.gstruct47_0[1].int_1 = array35[1];
		characterAccountConfig_0.gstruct47_0[1].int_3 = array35[2];
		characterAccountConfig_0.gstruct47_0[1].int_2 = array35[3];
		characterAccountConfig_0.gstruct47_0[1].int_4 = array35[4];
		characterAccountConfig_0.gstruct47_0[1].int_5 = GetNamedIntegerArrayEntry(array, "TTVukhi1", null);
		if (characterAccountConfig_0.gstruct47_0[0].int_5 == null || characterAccountConfig_0.gstruct47_0[0].int_5.Length != uint_0.Length)
		{
			characterAccountConfig_0.gstruct47_0[0].int_5 = null;
			characterAccountConfig_0.gstruct47_0[0].string_0 = null;
		}
		if (characterAccountConfig_0.gstruct47_0[1].int_5 == null || characterAccountConfig_0.gstruct47_0[1].int_5.Length != uint_0.Length)
		{
			characterAccountConfig_0.gstruct47_0[1].int_5 = null;
			characterAccountConfig_0.gstruct47_0[1].string_0 = null;
		}
	}

	public static void QueueCharacterPostAttachInitialization(int int_11)
	{
		int num = 0;
		while (!CommonUtility.bool_0 && int_8 > 0 && num < 10)
		{
			num++;
			Thread.Sleep(30);
		}
		try
		{
			int_8 = int_11;
			new Thread(RunCharacterPostAttachInitialization).Start();
		}
		catch
		{
		}
	}

	private static void RunCharacterPostAttachInitialization()
	{
		int num = int_8;
		int_8 = 0;
		int num2 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, num);
		if (num2 < 0)
		{
			return;
		}
		Form1.characterAccountConfig_1[num2].bool_2 = true;
		CharacterAccountConfig characterAccountConfig_ = Form1.characterAccountConfig_1[num2];
		string[] array = new string[8]
		{
			"<color=yellow>" + Form1.currentWindowTitle.ToUpper(),
			"-----------------------------------------|",
			"<bclr=blue>=========================================|",
			"<bclr=greend><color=green>  Auto Free cho Vâ L©m TruyÒn Kú Offline",
			"<bclr=greend><color=green>  Server ®­îc ph¸t triÓn bëi MEL",
			"<bclr=greend><color=green>  Chóc Anh Em ch¬i game vui vÎ!",
			"<bclr=blue>=========================================|",
			"-----------------------------------------|"
		};
		if (Form1.changeWindowTitleEnabled == 0 && array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig_, array[i]);
				if (array[i].IndexOf("F7") > 0)
				{
					string text = GameInterfaceMemoryHelper.ReadLatestTopChannelText(characterAccountConfig_);
					if (text != null && text != string.Empty && text.IndexOf("F7") > 0)
					{
						text = text.Replace("F7,", "F7 -");
						GameInterfaceMemoryHelper.WriteLatestTopChannelText(characterAccountConfig_, text);
					}
				}
				Thread.Sleep(80);
			}
		}
		num2 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, num);
		if (0 <= num2)
		{
			Form1.characterAccountConfig_1[num2].bool_2 = false;
			GameCrashFixPatcher.ApplyCrashFixPatches(characterAccountConfig_);
			CpuReductionPatch.ApplyReductionLevel(characterAccountConfig_, characterAccountConfig_.int_89);
			GameInterfaceMemoryHelper.ResetBoxAndNpcDialogState(characterAccountConfig_);
		}
	}

	public static void SaveCharacterConfiguration(CharacterAccountConfig characterAccountConfig_0, string string_28 = null)
	{
		string text = null;
		if (characterAccountConfig_0.gstruct47_0 == null)
		{
			characterAccountConfig_0.gstruct47_0 = new GStruct47[2];
		}
		text = text + "|TenVukhi;" + CommonUtility.EncodeBase64Utf8(characterAccountConfig_0.gstruct47_0[0].string_0 + "|" + characterAccountConfig_0.gstruct47_0[1].string_0);
		int[] object_ = new int[5]
		{
			characterAccountConfig_0.gstruct47_0[0].int_0,
			characterAccountConfig_0.gstruct47_0[0].int_1,
			characterAccountConfig_0.gstruct47_0[0].int_3,
			characterAccountConfig_0.gstruct47_0[0].int_2,
			characterAccountConfig_0.gstruct47_0[0].int_4
		};
		AppendSerializedIntegerField(ref text, "tbVukhi0", object_);
		object_ = new int[5]
		{
			characterAccountConfig_0.gstruct47_0[1].int_0,
			characterAccountConfig_0.gstruct47_0[1].int_1,
			characterAccountConfig_0.gstruct47_0[1].int_3,
			characterAccountConfig_0.gstruct47_0[1].int_2,
			characterAccountConfig_0.gstruct47_0[1].int_4
		};
		AppendSerializedIntegerField(ref text, "tbVukhi1", object_);
		AppendSerializedIntegerField(ref text, "TTVukhi0", characterAccountConfig_0.gstruct47_0[0].int_5);
		AppendSerializedIntegerField(ref text, "TTVukhi1", characterAccountConfig_0.gstruct47_0[1].int_5);
		AppendSerializedIntegerField(ref text, "flagXepdo", characterAccountConfig_0.int_37);
		AppendSerializedIntegerField(ref text, "TimerXepdo", characterAccountConfig_0.int_38);
		AppendSerializedIntegerField(ref text, "flagNhatTrongthanh", characterAccountConfig_0.int_39);
		AppendSerializedIntegerField(ref text, "flagNhatTheoThuoctinh", characterAccountConfig_0.int_40);
		AppendSerializedIntegerField(ref text, "flagThoahetThuoctinh", characterAccountConfig_0.int_41);
		AppendSerializedIntegerField(ref text, "flagKhongNhatdoTim", characterAccountConfig_0.int_42);
		AppendSerializedIntegerField(ref text, "GiuNhan", characterAccountConfig_0.int_43);
		AppendSerializedIntegerField(ref text, "GiuDC", characterAccountConfig_0.int_44);
		AppendSerializedIntegerField(ref text, "GiuNB", characterAccountConfig_0.int_45);
		AppendSerializedIntegerField(ref text, "flagPhamviNhatdo", characterAccountConfig_0.int_51);
		AppendSerializedIntegerField(ref text, "RuongCatdo", characterAccountConfig_0.int_53);
		if (characterAccountConfig_0.string_5 != null && characterAccountConfig_0.string_5.Length != 0)
		{
			string text2 = null;
			for (int i = 0; i < characterAccountConfig_0.string_5.Length; i++)
			{
				if (characterAccountConfig_0.string_5[i] != null && characterAccountConfig_0.string_5[i] != string.Empty)
				{
					if (text2 != null)
					{
						text2 += "|";
					}
					text2 += characterAccountConfig_0.string_5[i];
				}
			}
			if (text2 != null)
			{
				text = text + "|tbKeepItem;" + CommonUtility.EncodeBase64Utf8(text2);
			}
		}
		AppendSerializedIntegerField(ref text, "PhamviNhatdo", characterAccountConfig_0.int_52);
		AppendSerializedIntegerField(ref text, "flagVeBando", characterAccountConfig_0.int_46);
		AppendSerializedIntegerField(ref text, "GiudoTheoCap", characterAccountConfig_0.int_47);
		AppendSerializedIntegerField(ref text, "GiudoTheoHe", characterAccountConfig_0.int_48);
		AppendSerializedIntegerField(ref text, "GiudoTim", characterAccountConfig_0.int_49);
		AppendSerializedIntegerField(ref text, "GiudoTheoThuoctinh", characterAccountConfig_0.int_50);
		AppendSerializedIntegerField(ref text, "Luomrac", characterAccountConfig_0.int_54);
		AppendSerializedIntegerField(ref text, "LuomracAccept", characterAccountConfig_0.int_55);
		AppendSerializedIntegerField(ref text, "LuomracThuoctinh", characterAccountConfig_0.int_56);
		AppendSerializedIntegerField(ref text, "SinhlucThoat", characterAccountConfig_0.int_18);
		AppendSerializedIntegerField(ref text, "flagSinhlucThoat", characterAccountConfig_0.int_19);
		AppendSerializedIntegerField(ref text, "TDPKhiHetruong", characterAccountConfig_0.int_60);
		AppendSerializedIntegerField(ref text, "flagTranhBossvang", characterAccountConfig_0.int_57);
		AppendSerializedIntegerField(ref text, "AnTTL", characterAccountConfig_0.int_58);
		AppendSerializedIntegerField(ref text, "TDPKhiSaiMap", characterAccountConfig_0.int_59);
		AppendSerializedIntegerField(ref text, "GiamCpuLevel", characterAccountConfig_0.int_89);
		AppendSerializedIntegerField(ref text, "flagNhatdos", characterAccountConfig_0.int_61);
		AppendSerializedIntegerField(ref text, "flagNhatdoIndex", characterAccountConfig_0.int_62);
		AppendSerializedIntegerField(ref text, "flagCanThuocLag", characterAccountConfig_0.int_63);
		AppendSerializedIntegerField(ref text, "fThuocTocdo", characterAccountConfig_0.int_64);
		AppendSerializedIntegerField(ref text, "flagBuffDoituong", characterAccountConfig_0.int_5);
		AppendSerializedIntegerField(ref text, "flagChiBuffKhongDanh", characterAccountConfig_0.int_6);
		AppendSerializedIntegerField(ref text, "flagTuGiaiBua", characterAccountConfig_0.int_80);
		AppendSerializedIntegerField(ref text, "flagGiaibuaBangsat", characterAccountConfig_0.int_81);
		AppendSerializedIntegerField(ref text, "flagGiaibuaTheoThoigian", characterAccountConfig_0.int_82);
		AppendSerializedIntegerField(ref text, "flagTNXuatChieu120", characterAccountConfig_0.int_83);
		AppendSerializedIntegerField(ref text, "flagCLon", characterAccountConfig_0.int_84);
		AppendSerializedIntegerField(ref text, "TimerTuGiaibua", characterAccountConfig_0.int_85);
		AppendSerializedIntegerField(ref text, "TimerTheoThoigian", characterAccountConfig_0.int_87);
		AppendSerializedIntegerField(ref text, "TamBuffbua", characterAccountConfig_0.int_86);
		AppendSerializedIntegerField(ref text, "flagTuGiaidoc", characterAccountConfig_0.int_74);
		AppendSerializedIntegerField(ref text, "TheoSau", characterAccountConfig_0.int_68);
		text = text + "|NameTheoSau;" + CommonUtility.EncodeBase64Utf8(characterAccountConfig_0.string_9);
		AppendSerializedIntegerField(ref text, "GanChieuTrai", characterAccountConfig_0.int_138);
		AppendSerializedIntegerField(ref text, "GanChieuPhai", characterAccountConfig_0.int_139);
		int[] object_2 = new int[12]
		{
			characterAccountConfig_0.gstruct48_0[0].int_0,
			characterAccountConfig_0.gstruct48_0[0].int_1,
			characterAccountConfig_0.gstruct48_0[0].int_2,
			characterAccountConfig_0.gstruct48_0[0].int_3,
			characterAccountConfig_0.gstruct48_0[1].int_0,
			characterAccountConfig_0.gstruct48_0[1].int_1,
			characterAccountConfig_0.gstruct48_0[1].int_2,
			characterAccountConfig_0.gstruct48_0[1].int_3,
			characterAccountConfig_0.gstruct48_0[2].int_0,
			characterAccountConfig_0.gstruct48_0[2].int_1,
			characterAccountConfig_0.gstruct48_0[2].int_2,
			characterAccountConfig_0.gstruct48_0[2].int_3
		};
		AppendSerializedIntegerField(ref text, "tbChuyenTR", object_2);
		int[] object_3 = new int[12]
		{
			characterAccountConfig_0.gstruct48_1[0].int_0,
			characterAccountConfig_0.gstruct48_1[0].int_1,
			characterAccountConfig_0.gstruct48_1[0].int_2,
			characterAccountConfig_0.gstruct48_1[0].int_3,
			characterAccountConfig_0.gstruct48_1[1].int_0,
			characterAccountConfig_0.gstruct48_1[1].int_1,
			characterAccountConfig_0.gstruct48_1[1].int_2,
			characterAccountConfig_0.gstruct48_1[1].int_3,
			characterAccountConfig_0.gstruct48_1[2].int_0,
			characterAccountConfig_0.gstruct48_1[2].int_1,
			characterAccountConfig_0.gstruct48_1[2].int_2,
			characterAccountConfig_0.gstruct48_1[2].int_3
		};
		AppendSerializedIntegerField(ref text, "tbChuyenPH", object_3);
		int[] object_4 = new int[4]
		{
			characterAccountConfig_0.gstruct48_2.int_0,
			characterAccountConfig_0.gstruct48_2.int_1,
			characterAccountConfig_0.gstruct48_2.int_3,
			characterAccountConfig_0.gstruct48_2.int_2
		};
		AppendSerializedIntegerField(ref text, "GapBossChieu", object_4);
		AppendSerializedIntegerField(ref text, "Tran1Phai", characterAccountConfig_0.int_140);
		AppendSerializedIntegerField(ref text, "Tran2Phai", characterAccountConfig_0.int_141);
		AppendSerializedIntegerField(ref text, "Tran3Phai", characterAccountConfig_0.int_142);
		text = text + "|NhatQuaName;" + CommonUtility.EncodeBase64Utf8(characterAccountConfig_0.gstruct49_0.targetName);
		int[] object_5 = new int[9]
		{
			characterAccountConfig_0.gstruct49_0.pickupEnabled,
			characterAccountConfig_0.gstruct49_0.scheduledStartEnabled,
			characterAccountConfig_0.gstruct49_0.startHour,
			characterAccountConfig_0.gstruct49_0.startMinute,
			characterAccountConfig_0.gstruct49_0.startSecond,
			characterAccountConfig_0.gstruct49_0.pickupRadius,
			characterAccountConfig_0.gstruct49_0.collectionBoxEnabled,
			characterAccountConfig_0.gstruct49_0.collectionBoxTimeoutMilliseconds,
			characterAccountConfig_0.gstruct49_0.fixedPositionEnabled
		};
		AppendSerializedIntegerField(ref text, "tbNhatQua", object_5);
		AppendSerializedIntegerField(ref text, "BosST", characterAccountConfig_0.int_133);
		AppendSerializedIntegerField(ref text, "STHaucan", characterAccountConfig_0.int_134);
		AppendSerializedIntegerField(ref text, "VSTClick", characterAccountConfig_0.int_135);
		AppendSerializedIntegerField(ref text, "fNotDame", characterAccountConfig_0.int_126);
		AppendSerializedIntegerField(ref text, "DameChieu12", characterAccountConfig_0.int_127);
		AppendSerializedIntegerField(ref text, "DMBoom", characterAccountConfig_0.int_128);
		AppendSerializedIntegerField(ref text, "tbKeyXuat", characterAccountConfig_0.int_129);
		AppendSerializedIntegerField(ref text, "tbCaudame", characterAccountConfig_0.int_130);
		int[] object_6 = new int[10]
		{
			characterAccountConfig_0.gstruct50_0.enabled,
			characterAccountConfig_0.gstruct50_0.skillId,
			characterAccountConfig_0.gstruct50_0.triggerMode,
			characterAccountConfig_0.gstruct50_0.triggerIntervalMilliseconds,
			characterAccountConfig_0.gstruct50_0.combinedCastModeEnabled,
			characterAccountConfig_0.gstruct50_0.monsterTargetEnabled,
			characterAccountConfig_0.gstruct50_0.minimumCastIntervalSeconds,
			characterAccountConfig_0.gstruct50_0.targetDistanceThreshold,
			characterAccountConfig_0.gstruct50_0.postCastSearchDistanceAdjustmentEnabled,
			characterAccountConfig_0.gstruct50_0.postCastSearchDistance
		};
		AppendSerializedIntegerField(ref text, "tbTienSkill", object_6);
		AppendSerializedIntegerField(ref text, "fQuangthuoc", characterAccountConfig_0.int_131);
		AppendSerializedIntegerField(ref text, "TienGuiBho", characterAccountConfig_0.int_67);
		AppendSerializedIntegerField(ref text, "flagTienMangtheo", characterAccountConfig_0.int_65);
		AppendSerializedIntegerField(ref text, "TienMangtheo", characterAccountConfig_0.int_66);
		AppendSerializedIntegerField(ref text, "RuongBH", characterAccountConfig_0.int_79);
		AppendSerializedIntegerField(ref text, "flagMuaNgamy", characterAccountConfig_0.int_70);
		AppendSerializedIntegerField(ref text, "fRao", characterAccountConfig_0.int_69);
		text = text + "|tRaovat;" + CommonUtility.EncodeBase64Utf8(characterAccountConfig_0.string_10);
		AppendSerializedIntegerField(ref text, "ChThuoc", characterAccountConfig_0.int_76);
		text = text + "|fTenThuoc;" + CommonUtility.EncodeBase64Utf8(characterAccountConfig_0.string_14);
		AppendSerializedIntegerField(ref text, "flagMuaThuocHP", characterAccountConfig_0.int_71);
		text = text + "|TenHP;" + CommonUtility.EncodeBase64Utf8(characterAccountConfig_0.string_11);
		AppendSerializedIntegerField(ref text, "flagMuaThuocMP", characterAccountConfig_0.int_72);
		text = text + "|TenMP;" + CommonUtility.EncodeBase64Utf8(characterAccountConfig_0.string_12);
		AppendSerializedIntegerField(ref text, "flagMuaGiaiDoc", characterAccountConfig_0.int_73);
		text = text + "|TenGiaiDoc;" + CommonUtility.EncodeBase64Utf8(characterAccountConfig_0.string_13);
		AppendSerializedIntegerField(ref text, "MuaFree", characterAccountConfig_0.int_78);
		AppendSerializedIntegerField(ref text, "MuaKTC", characterAccountConfig_0.int_77);
		AppendSerializedIntegerField(ref text, "GanTenthuoc", characterAccountConfig_0.int_75);
		AppendSerializedIntegerField(ref text, "fNgamyBuff", characterAccountConfig_0.int_101);
		AppendSerializedIntegerField(ref text, "BomHPDiem", characterAccountConfig_0.int_106);
		AppendSerializedIntegerField(ref text, "BomMPDiem", characterAccountConfig_0.int_107);
		AppendSerializedIntegerField(ref text, "BomHPRatio", characterAccountConfig_0.int_109);
		AppendSerializedIntegerField(ref text, "BomM2HPRatio", characterAccountConfig_0.int_110);
		AppendSerializedIntegerField(ref text, "BomMPRatio", characterAccountConfig_0.int_111);
		AppendSerializedIntegerField(ref text, "BomM2MPRatio", characterAccountConfig_0.int_112);
		AppendSerializedIntegerField(ref text, "flagDoiPk", characterAccountConfig_0.int_92);
		AppendSerializedIntegerField(ref text, "flagXuongngua", characterAccountConfig_0.int_93);
		AppendSerializedIntegerField(ref text, "ChetNamIm", characterAccountConfig_0.int_94);
		AppendSerializedIntegerField(ref text, "fBaoBoss", characterAccountConfig_0.int_1);
		AppendSerializedIntegerField(ref text, "flagTuCastBua", characterAccountConfig_0.int_119);
		int[] array = null;
		if (characterAccountConfig_0.int_3 != null)
		{
			array = new int[characterAccountConfig_0.int_3.GetLength(0)];
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = characterAccountConfig_0.int_3[j, 0];
			}
		}
		AppendSerializedIntegerField(ref text, "tbValueMagic", array);
		AppendSerializedIntegerField(ref text, "flagDanhphim", characterAccountConfig_0.int_100);
		AppendSerializedIntegerField(ref text, "flagTuPT", characterAccountConfig_0.int_103);
		AppendSerializedIntegerField(ref text, "flagTiepcanF", characterAccountConfig_0.int_95);
		AppendSerializedIntegerField(ref text, "ValueTiepcan", characterAccountConfig_0.int_96);
		AppendSerializedIntegerField(ref text, "flagTamQuet_", characterAccountConfig_0.int_98);
		AppendSerializedIntegerField(ref text, "ValueTamQuet_s", characterAccountConfig_0.int_99);
		AppendSerializedIntegerField(ref text, "UuTienMode", characterAccountConfig_0.int_143);
		AppendSerializedIntegerField(ref text, "UuTienTabPageMode", characterAccountConfig_0.int_144);
		AppendSerializedIntegerField(ref text, "TDPKhiPk", characterAccountConfig_0.int_104);
		AppendSerializedIntegerField(ref text, "flagTuChayMuaThuocHoaSon", characterAccountConfig_0.int_105);
		AppendSerializedIntegerField(ref text, "fBanEvent", characterAccountConfig_0.int_12);
		string text3 = string.Empty;
		if (characterAccountConfig_0.gstruct36_0 != null)
		{
			for (int k = 0; k < characterAccountConfig_0.gstruct36_0.Length; k++)
			{
				if (text3 != string.Empty)
				{
					text3 += "|";
				}
				if (characterAccountConfig_0.gstruct36_0[k].menuSelectionSequence == null)
				{
					characterAccountConfig_0.gstruct36_0[k].menuSelectionSequence = new int[2] { 1, 1 };
				}
				string text4 = string.Empty;
				for (int l = 0; l < characterAccountConfig_0.gstruct36_0[k].menuSelectionSequence.Length; l++)
				{
					if (text4 != string.Empty)
					{
						text4 += "_";
					}
					text4 += characterAccountConfig_0.gstruct36_0[k].menuSelectionSequence[l];
				}
				object obj = text3;
				text3 = string.Concat(obj, characterAccountConfig_0.gstruct36_0[k].medicineBagItemName, '\u0001', characterAccountConfig_0.gstruct36_0[k].quantityInputEnabled, '\u0001', characterAccountConfig_0.gstruct36_0[k].timeTriggerEnabled, '\u0001', characterAccountConfig_0.gstruct36_0[k].remainingQuantityThreshold, '\u0001', text4, '\u0001', characterAccountConfig_0.gstruct36_0[k].timeIntervalMilliseconds, '\u0001', characterAccountConfig_0.gstruct36_0[k].quantityTriggerEnabled, '\u0001', characterAccountConfig_0.gstruct36_0[k].menuClickEnabled, '\u0001', characterAccountConfig_0.gstruct36_0[k].stateChangeTriggerEnabled, '\u0001', characterAccountConfig_0.gstruct36_0[k].pauseAutomationWhileUsingEnabled, '\u0001', characterAccountConfig_0.gstruct36_0[k].useSpecificMedicineNameEnabled, '\u0001', characterAccountConfig_0.gstruct36_0[k].remainingMedicineItemName);
			}
			text3 = CommonUtility.EncodeBase64Utf8(text3);
		}
		text = text + "|MoTuiThuoc;" + text3;
		AppendSerializedIntegerField(ref text, "HPTdp", characterAccountConfig_0.int_113);
		AppendSerializedIntegerField(ref text, "MPTdp", characterAccountConfig_0.int_114);
		AppendSerializedIntegerField(ref text, "flagUuTienBomCuuChuyen", characterAccountConfig_0.int_108);
		AppendSerializedIntegerField(ref text, "flagTDPKhiSoluongMau", characterAccountConfig_0.int_115);
		AppendSerializedIntegerField(ref text, "TDPSoluongMauConlai", characterAccountConfig_0.int_116);
		AppendSerializedIntegerField(ref text, "flagTDPKhiSoluongMana", characterAccountConfig_0.int_117);
		AppendSerializedIntegerField(ref text, "TDPSoluongManaConlai", characterAccountConfig_0.int_118);
		AppendSerializedIntegerField(ref text, "KieuDanh", characterAccountConfig_0.int_88);
		AppendSerializedIntegerField(ref text, "tbNguhanh", characterAccountConfig_0.int_90);
		AppendSerializedIntegerField(ref text, "tbMonPhai", characterAccountConfig_0.int_91);
		AppendSerializedIntegerField(ref text, "flagCuusatTheodanhsach", characterAccountConfig_0.int_120);
		text = text + "|TenMauMuc2;" + CommonUtility.EncodeBase64Utf8(characterAccountConfig_0.string_16);
		text = text + "|TenManaMuc2;" + CommonUtility.EncodeBase64Utf8(characterAccountConfig_0.string_17);
		if (characterAccountConfig_0.string_18 != null && characterAccountConfig_0.string_18.Length != 0)
		{
			string text5 = null;
			for (int m = 0; m < characterAccountConfig_0.string_18.Length; m++)
			{
				if (characterAccountConfig_0.string_18[m] != null && characterAccountConfig_0.string_18[m] != string.Empty)
				{
					if (text5 != null)
					{
						text5 += "|";
					}
					text5 += characterAccountConfig_0.string_18[m];
				}
			}
			if (text5 != null)
			{
				text = text + "|DanhsachCuusat;" + CommonUtility.EncodeBase64Utf8(text5);
			}
		}
		text = text + "|PassRuong;" + CommonUtility.EncodeBase64Utf8(characterAccountConfig_0.string_15);
		if (characterAccountConfig_0.string_19 != null && characterAccountConfig_0.string_19.Length != 0)
		{
			string text6 = null;
			for (int n = 0; n < characterAccountConfig_0.string_19.Length; n++)
			{
				if (characterAccountConfig_0.string_19[n] != null && characterAccountConfig_0.string_19[n] != string.Empty)
				{
					if (text6 != null)
					{
						text6 += "|";
					}
					text6 += characterAccountConfig_0.string_19[n];
				}
			}
			if (text6 != null)
			{
				text = text + "|PTDanhsach;" + CommonUtility.EncodeBase64Utf8(text6);
			}
		}
		AppendSerializedIntegerField(ref text, "PTflag", characterAccountConfig_0.int_121);
		AppendSerializedIntegerField(ref text, "fDenToado", characterAccountConfig_0.int_125);
		AppendSerializedIntegerField(ref text, "fTuchayToadoVA", characterAccountConfig_0.int_122);
		AppendSerializedIntegerField(ref text, "fClickNTT", characterAccountConfig_0.int_123);
		AppendSerializedIntegerField(ref text, "ClickNPCSolan", characterAccountConfig_0.int_7);
		AppendSerializedIntegerField(ref text, "tbClickNpcMenu", characterAccountConfig_0.int_9);
		AppendSerializedIntegerField(ref text, "fClickNpcMenu", characterAccountConfig_0.int_8);
		text = text + "|ClickNPCName;" + CommonUtility.EncodeBase64Utf8(characterAccountConfig_0.string_0);
		AppendSerializedIntegerField(ref text, "ClickNPCTocdo", characterAccountConfig_0.int_10);
		AppendSerializedIntegerField(ref text, "ClickLocTocdo", characterAccountConfig_0.int_11);
		text = text + "|TenVatphamNpc;" + CommonUtility.EncodeBase64Utf8(characterAccountConfig_0.string_1);
		AppendSerializedIntegerField(ref text, "MenuVatphamNpc", characterAccountConfig_0.int_14);
		AppendSerializedIntegerField(ref text, "fClickNPC_Sudung", characterAccountConfig_0.int_13);
		AppendSerializedIntegerField(ref text, "flagClickNpcSau", characterAccountConfig_0.int_15);
		AppendSerializedIntegerField(ref text, "fClickNPC_Nop", characterAccountConfig_0.int_16);
		if (characterAccountConfig_0.gstruct33_0 != null)
		{
			string text7 = string.Empty;
			for (int num = 0; num < characterAccountConfig_0.gstruct33_0.Length; num++)
			{
				if (characterAccountConfig_0.gstruct33_0[num].int_4 > 0 && characterAccountConfig_0.gstruct33_0[num].string_0 != null && !(characterAccountConfig_0.gstruct33_0[num].string_0 == string.Empty))
				{
					if (text7 != null && text7 != string.Empty)
					{
						text7 += "|";
					}
					object obj2 = text7;
					text7 = string.Concat(obj2, characterAccountConfig_0.gstruct33_0[num].string_0, "=", characterAccountConfig_0.gstruct33_0[num].int_4);
				}
			}
			if (text7 != null && text7 != string.Empty)
			{
				text = text + "|ClickNPC_Nop;" + CommonUtility.EncodeBase64Utf8(text7);
			}
		}
		AppendSerializedIntegerField(ref text, "fClickNPC_MuaVP", characterAccountConfig_0.int_17);
		if (characterAccountConfig_0.string_2 != null && characterAccountConfig_0.string_2 != string.Empty)
		{
			text = text + "|ClickNPC_TabKTC;" + CommonUtility.EncodeBase64Utf8(characterAccountConfig_0.string_2);
		}
		if (characterAccountConfig_0.gstruct33_1.int_4 > 0 && characterAccountConfig_0.gstruct33_1.string_0 != null && characterAccountConfig_0.gstruct33_1.string_0 != string.Empty)
		{
			text = text + "|ClickNPC_Mua;" + CommonUtility.EncodeBase64Utf8(characterAccountConfig_0.gstruct33_1.string_0 + "=" + characterAccountConfig_0.gstruct33_1.int_4);
		}
		AppendSerializedIntegerField(ref text, "flagTrains", characterAccountConfig_0.int_25);
		AppendSerializedIntegerField(ref text, "flagTucheHT", characterAccountConfig_0.int_26);
		AppendSerializedIntegerField(ref text, "DanhQuaiTrain", characterAccountConfig_0.int_27);
		AppendSerializedIntegerField(ref text, "TDPHettien", characterAccountConfig_0.int_28);
		AppendSerializedIntegerField(ref text, "ToadoVong", characterAccountConfig_0.int_29);
		AppendSerializedIntegerField(ref text, "MapIDTrain", characterAccountConfig_0.int_32);
		AppendSerializedIntegerField(ref text, "XulyDosat", characterAccountConfig_0.int_33);
		string text8 = null;
		if (characterAccountConfig_0.uint_0 != null)
		{
			for (int num2 = 0; num2 < characterAccountConfig_0.uint_0.GetLength(0); num2++)
			{
				if (text8 != null)
				{
					text8 += "|";
				}
				object obj3 = text8;
				text8 = string.Concat(obj3, characterAccountConfig_0.uint_0[num2, 0], ";", characterAccountConfig_0.uint_0[num2, 1]);
			}
			text = text + "|ToadoTrain;" + CommonUtility.EncodeBase64Utf8(text8);
		}
		AppendSerializedIntegerField(ref text, "SoDiemTrinhsat", characterAccountConfig_0.int_21);
		AppendSerializedIntegerField(ref text, "flagChayPkNguoidung", characterAccountConfig_0.int_34);
		AppendSerializedIntegerField(ref text, "fTinSu", characterAccountConfig_0.int_20);
		AppendSerializedIntegerField(ref text, "MapIDPk1", characterAccountConfig_0.int_35);
		AppendSerializedIntegerField(ref text, "MapIDPk2", characterAccountConfig_0.int_36);
		text8 = null;
		if (characterAccountConfig_0.uint_2 != null)
		{
			for (int num3 = 0; num3 < characterAccountConfig_0.uint_2.GetLength(0); num3++)
			{
				if (text8 != null)
				{
					text8 += "|";
				}
				object obj4 = text8;
				text8 = string.Concat(obj4, characterAccountConfig_0.uint_2[num3, 0], ";", characterAccountConfig_0.uint_2[num3, 1]);
			}
			text = text + "|ToadoPk1;" + CommonUtility.EncodeBase64Utf8(text8);
		}
		text8 = null;
		if (characterAccountConfig_0.uint_3 != null)
		{
			for (int num4 = 0; num4 < characterAccountConfig_0.uint_3.GetLength(0); num4++)
			{
				if (text8 != null)
				{
					text8 += "|";
				}
				object obj5 = text8;
				text8 = string.Concat(obj5, characterAccountConfig_0.uint_3[num4, 0], ";", characterAccountConfig_0.uint_3[num4, 1]);
			}
			text = text + "|ToadoPk2;" + CommonUtility.EncodeBase64Utf8(text8);
		}
		if (characterAccountConfig_0.itemAttributeFilterRule_0 != null)
		{
			int[] array2 = new int[characterAccountConfig_0.itemAttributeFilterRule_0.Length];
			int[] array3 = new int[characterAccountConfig_0.itemAttributeFilterRule_0.Length];
			int[] array4 = new int[characterAccountConfig_0.itemAttributeFilterRule_0.Length];
			for (int num5 = 0; num5 < characterAccountConfig_0.itemAttributeFilterRule_0.Length; num5++)
			{
				array2[num5] = characterAccountConfig_0.itemAttributeFilterRule_0[num5].int_0;
				array3[num5] = characterAccountConfig_0.itemAttributeFilterRule_0[num5].int_2;
				array4[num5] = characterAccountConfig_0.itemAttributeFilterRule_0[num5].int_3;
			}
			AppendSerializedIntegerField(ref text, "tbFlagItemMagic", array2);
			AppendSerializedIntegerField(ref text, "tbValueItemMagic", array3);
			AppendSerializedIntegerField(ref text, "tbValueDong", array4);
		}
		if (characterAccountConfig_0.string_7 != null && characterAccountConfig_0.string_7.Length != 0)
		{
			string text9 = null;
			for (int num6 = 0; num6 < characterAccountConfig_0.string_7.Length; num6++)
			{
				if (characterAccountConfig_0.string_7[num6] != null && characterAccountConfig_0.string_7[num6] != string.Empty)
				{
					if (text9 != null)
					{
						text9 += "|";
					}
					text9 += characterAccountConfig_0.string_7[num6];
				}
			}
			if (text9 != null)
			{
				text = text + "|ThuocTocdoDanh;" + CommonUtility.EncodeBase64Utf8(text9);
			}
		}
		if (characterAccountConfig_0.string_8 != null && characterAccountConfig_0.string_8.Length != 0)
		{
			string text10 = null;
			for (int num7 = 0; num7 < characterAccountConfig_0.string_8.Length; num7++)
			{
				if (characterAccountConfig_0.string_8[num7] != null && characterAccountConfig_0.string_8[num7] != string.Empty)
				{
					if (text10 != null)
					{
						text10 += "|";
					}
					text10 += characterAccountConfig_0.string_8[num7];
				}
			}
			if (text10 != null)
			{
				text = text + "|ThuocTocdoThuong;" + CommonUtility.EncodeBase64Utf8(text10);
			}
		}
		if (characterAccountConfig_0.string_6 != null && characterAccountConfig_0.string_6.Length != 0)
		{
			string text11 = null;
			for (int num8 = 0; num8 < characterAccountConfig_0.string_6.Length; num8++)
			{
				if (characterAccountConfig_0.string_6[num8] != null && characterAccountConfig_0.string_6[num8] != string.Empty)
				{
					if (text11 != null)
					{
						text11 += "|";
					}
					text11 += characterAccountConfig_0.string_6[num8];
				}
			}
			if (text11 != null)
			{
				text = text + "|tbThuocLag;" + CommonUtility.EncodeBase64Utf8(text11);
			}
		}
		if (characterAccountConfig_0.string_4 != null && characterAccountConfig_0.string_4.Length != 0)
		{
			string text12 = null;
			for (int num9 = 0; num9 < characterAccountConfig_0.string_4.Length; num9++)
			{
				if (characterAccountConfig_0.string_4[num9] != null && characterAccountConfig_0.string_4[num9] != string.Empty)
				{
					if (text12 != null)
					{
						text12 += "|";
					}
					text12 += characterAccountConfig_0.string_4[num9];
				}
			}
			if (text12 != null)
			{
				text = text + "|IBadlist;" + CommonUtility.EncodeBase64Utf8(text12);
			}
		}
		if (characterAccountConfig_0.gstruct44_0 != null && characterAccountConfig_0.gstruct44_0.Length != 0)
		{
			string text13 = null;
			for (int num10 = 0; num10 < characterAccountConfig_0.gstruct44_0.Length; num10++)
			{
				ComboMedicineEntry[] comboMedicineEntry_ = characterAccountConfig_0.gstruct44_0[num10].comboMedicineEntry_0;
				if (comboMedicineEntry_ == null)
				{
					continue;
				}
				string text14 = null;
				for (int num11 = 0; num11 < comboMedicineEntry_.Length; num11++)
				{
					if (text14 != null)
					{
						text14 += "/";
					}
					text14 = text14 + comboMedicineEntry_[num11].int_0 + "=" + comboMedicineEntry_[num11].string_0;
				}
				if (text13 != null)
				{
					text13 += "|";
				}
				text13 = text13 + characterAccountConfig_0.gstruct44_0[num10].int_0 + ":" + text14;
			}
			if (text13 != null)
			{
				text = text + "|AscBomThuoc;" + CommonUtility.EncodeBase64Utf8(text13);
			}
		}
		if (string_28 != null && !(string_28 == string.Empty))
		{
			string[] array5 = CommonUtility.SplitPrefixAndLastSegment(string_28);
			CommonUtility.EnsureDirectoryExists(array5[0]);
			CommonUtility.WriteAllTextWithEncodingOption(string_28, text, 3);
		}
		else
		{
			CommonUtility.EnsureDirectoryExists(allUserConfigDirectory);
			CommonUtility.WriteAllTextWithEncodingOption(allUserConfigDirectory + "\\" + CommonUtility.ConvertNonAlphanumericCharsToByteValues(characterAccountConfig_0.string_22) + ".cfg", text, 3);
		}
	}

	public static int[] CopyFiveValueConfigurationRow(int int_11)
	{
		int[] array = new int[5];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = fiveValueConfigurationTable[int_11, i];
		}
		return array;
	}

	public static int[] CopyTenValueConfigurationRow(int int_11)
	{
		int[] array = new int[10];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = tenValueConfigurationTable[int_11, i];
		}
		return array;
	}

	public static int[] GetAvailableFactionSkillIds(CharacterAccountConfig characterAccountConfig_0, string string_28 = null)
	{
		if (string_28 == null || string_28 == string.Empty)
		{
			string_28 = CharacterSkillHelper.ResolveFactionIdentifier(characterAccountConfig_0);
		}
		int[] array = new int[7];
		switch (string_28)
		{
		case "CONLON":
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 394) > 0)
			{
				array[0] = 394;
			}
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 392) > 0)
			{
				array[1] = 392;
			}
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 174) > 0)
			{
				array[2] = 174;
			}
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 393) > 0)
			{
				array[3] = 393;
			}
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 175) > 0)
			{
				array[4] = 175;
			}
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 90) > 0)
			{
				array[5] = 90;
			}
			break;
		case "NGUDOC":
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 73) > 0)
			{
				array[0] = 73;
			}
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 390) > 0)
			{
				array[1] = 390;
			}
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 356) > 0)
			{
				array[2] = 356;
			}
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 72) > 0)
			{
				array[3] = 72;
			}
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 64) > 0)
			{
				array[4] = 64;
			}
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 70) > 0)
			{
				array[5] = 70;
			}
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 67) > 0)
			{
				array[6] = 67;
			}
			break;
		case "THIENNHAN":
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 391) > 0)
			{
				array[0] = 391;
			}
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 136) > 0)
			{
				array[1] = 136;
			}
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 137) > 0)
			{
				array[2] = 137;
			}
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 140) > 0)
			{
				array[3] = 140;
			}
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 364) > 0)
			{
				array[4] = 364;
			}
			if (CharacterSkillHelper.ReadSkillLevel(characterAccountConfig_0, 143) > 0)
			{
				array[5] = 143;
			}
			break;
		}
		return array;
	}

	public static int[,] GetNamedFactionPairTable(string string_28)
	{
		int[,] result = null;
		switch (string_28)
		{
		case "CONLON":
		{
			int[,] array3 = new int[6, 2];
			EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array3, 249004);
			result = array3;
			break;
		}
		case "THIENNHAN":
		{
			int[,] array2 = new int[6, 2];
			EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array2, 248943);
			result = array2;
			break;
		}
		case "NGUDOC":
		{
			int[,] array = new int[7, 2];
			EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array, 248874);
			result = array;
			break;
		}
		}
		return result;
	}

	private static void AppendSerializedIntegerField(ref string string_28, string string_29, object object_0)
	{
		try
		{
			int[] array = null;
			if (object_0 == null)
			{
				object_0 = string.Empty;
			}
			string[] array2 = typeof(int).ToString().Split('.');
			string value = array2[array2.Length - 1].ToUpper();
			string text = object_0.GetType().ToString().ToUpper();
			if (0 < text.IndexOf(value))
			{
				array = ((CommonUtility.FindSubstringIndex(text, "[") > 0) ? ((int[])object_0) : new int[1] { CommonUtility.ParseInt32OrZero(object_0.ToString()) });
			}
			if (string_28 != null && string_28 != string.Empty)
			{
				string_28 += "|";
			}
			string_28 += string_29;
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					string_28 = string_28 + ";" + array[i];
				}
			}
		}
		catch
		{
		}
	}

	public static int[] GetNamedIntegerArrayEntry(string[] string_28, string string_29, int[] int_11)
	{
		string_29 = string_29.ToUpper();
		if (string_28 != null && string_28.Length != 0)
		{
			for (int i = 0; i < string_28.Length; i++)
			{
				if (string_28[i] == null || !(string_28[i] != ""))
				{
					continue;
				}
				string[] array = string_28[i].Split(';');
				if (!(array[0].Trim().ToUpper() == string_29))
				{
					continue;
				}
				int[] array2 = null;
				if (array.Length > 1)
				{
					array2 = new int[array.Length - 1];
					for (int j = 1; j < array.Length; j++)
					{
						if (array[j] != null && !(array[j] == string.Empty))
						{
							array2[j - 1] = CommonUtility.ParseInt32OrZero(array[j].Trim());
							continue;
						}
						array2 = null;
						break;
					}
				}
				if (array2 == null)
				{
					break;
				}
				return array2;
			}
		}
		return int_11;
	}

	public static uint[,] GetNamedUInt32PairTableEntry(string[] string_28, string string_29, uint[,] uint_14)
	{
		string_29 = string_29.ToUpper();
		if (string_28 != null && string_28.Length != 0)
		{
			for (int i = 0; i < string_28.Length; i++)
			{
				if (string_28[i] == null || !(string_28[i] != ""))
				{
					continue;
				}
				string[] array = string_28[i].Split(';');
				if (!(array[0].Trim().ToUpper() == string_29))
				{
					continue;
				}
				uint[,] array2 = null;
				if (array.Length > 1)
				{
					array2 = new uint[array.Length - 1, 2];
					int num = 0;
					for (int j = 1; j < array.Length; j++)
					{
						string text = array[j].Trim();
						if (!(text == ""))
						{
							string[] array3 = text.Split(',');
							if (array3.Length > 1)
							{
								array2[num, 0] = CommonUtility.ParseUInt32OrZero(array3[0].Trim());
								array2[num, 1] = CommonUtility.ParseUInt32OrZero(array3[1].Trim());
							}
							num++;
						}
					}
					if (num == 0)
					{
						array2 = null;
					}
					else if (num < array2.GetLength(0))
					{
						uint[,] array4 = new uint[num, 2];
						for (int k = 0; k < num; k++)
						{
							array4[k, 0] = array2[k, 0];
							array4[k, 1] = array2[k, 1];
						}
						array2 = array4;
					}
				}
				return array2;
			}
		}
		return uint_14;
	}

	public static string[] GetNamedStringArrayEntry(string[] string_28, string string_29, string[] string_30, bool bool_2 = false)
	{
		string_29 = string_29.ToUpper();
		if (string_28 != null && string_28.Length != 0)
		{
			for (int i = 0; i < string_28.Length; i++)
			{
				if (string_28[i] == null || !(string_28[i] != ""))
				{
					continue;
				}
				string[] array = string_28[i].Split(';');
				if (!(array[0].Trim().ToUpper() == string_29))
				{
					continue;
				}
				if (array.Length < 2)
				{
					return null;
				}
				string[] array2 = new string[array.Length - 1];
				int num = 0;
				for (int j = 1; j < array.Length; j++)
				{
					string text = array[j].Trim();
					if (!bool_2 || !(text == ""))
					{
						array2[num] = text;
						num++;
					}
				}
				if (num == 0)
				{
					return null;
				}
				if (num != array2.Length)
				{
					string[] array3 = new string[num];
					for (int k = 0; k < num; k++)
					{
						array3[k] = array2[k];
					}
					return array3;
				}
				return array2;
			}
		}
		return string_30;
	}

	private static bool TryResolveRepresent2PatchAddress(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.GetModuleBaseAddressByName(characterAccountConfig_0.int_136, memorySignatureScanConfig_269.signatureName);
		uint[] array = WindowsInteropHelper.ReadPeSectionSizeAndRvaWithRetry(characterAccountConfig_0.int_137, num, ".text|slowfbeq|default");
		if (array != null && array[0] != 0)
		{
			int int_ = 0;
			byte[] array2 = new byte[array[0]];
			if (!WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num + array[1], array2, array2.Length, ref int_))
			{
				return false;
			}
			ProcessMemorySignatureScanner.ScanSignature(array[1], array2, ref memorySignatureScanConfig_269);
			return memorySignatureScanConfig_269.resolvedValue != 0;
		}
		return false;
	}

	public static bool SetRepresent2PatchEnabled(CharacterAccountConfig characterAccountConfig_0, bool bool_2)
	{
		if (memorySignatureScanConfig_269.resolvedValue == 0 && !TryResolveRepresent2PatchAddress(Form1.characterAccountConfig_1[0]))
		{
			return false;
		}
		int int_ = 0;
		byte[] array = null;
		array = (bool_2 ? new byte[2] { 144, 233 } : new byte[2] { 15, 135 });
		uint num = WindowsInteropHelper.GetModuleBaseAddressByName(characterAccountConfig_0.int_136, memorySignatureScanConfig_269.signatureName);
		if (num == 0)
		{
			return false;
		}
		return WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num + memorySignatureScanConfig_269.resolvedValue, array, array.Length, ref int_);
	}

	public static void SetTcpLatencyRegistryTweaksEnabled(bool bool_2)
	{
		string text = "SYSTEM\\CurrentControlSet\\services\\Tcpip\\Parameters";
		string text2 = "ForwardBufferMemory";
		string text3 = "NumForwardPackets";
		string text4 = "DisableTaskOffload";
		string text5 = "SOFTWARE\\Microsoft\\MSMQ\\Parameters";
		string text6 = "TCPNoDelay";
		string text7 = text + "\\Interfaces";
		string text8 = "TcpAckFrequency";
		string[] array = WindowsRegistryHelper.GetRegistrySubKeyNames(text7);
		if (!bool_2)
		{
			WindowsRegistryHelper.DeleteRegistryValue(text, text2, 0);
			WindowsRegistryHelper.DeleteRegistryValue(text, text3, 0);
			WindowsRegistryHelper.DeleteRegistryValue(text, text4, 0);
			WindowsRegistryHelper.DeleteRegistryValue(text, text6, 0);
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					WindowsRegistryHelper.DeleteRegistryValue(text7 + "\\" + array[i], text8, 0);
				}
			}
			WindowsRegistryHelper.DeleteRegistryValue(text5, text6, 0);
			return;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 582;
		int num4 = 148992;
		try
		{
			NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			NetworkInterface[] array2 = allNetworkInterfaces;
			NetworkInterface[] array3 = array2;
			foreach (NetworkInterface networkInterface in array3)
			{
				if (networkInterface.Supports(NetworkInterfaceComponent.IPv4))
				{
					IPInterfaceProperties iPProperties = networkInterface.GetIPProperties();
					IPv4InterfaceProperties iPv4Properties = iPProperties.GetIPv4Properties();
					if (iPv4Properties != null)
					{
						num += iPv4Properties.Mtu;
						num2++;
					}
				}
			}
		}
		catch
		{
		}
		if (num2 > 0)
		{
			num /= num2;
			num3 = num * 100;
			num3 /= 256;
			num4 = num3 * 256;
		}
		WindowsRegistryHelper.SetRegistryValue(text, text3, num3, "DWORD", 0);
		WindowsRegistryHelper.SetRegistryValue(text, text2, num4, "DWORD", 0);
		WindowsRegistryHelper.SetRegistryValue(text, text4, 0, "DWORD", 0);
		WindowsRegistryHelper.SetRegistryValue(text, text6, 1, "DWORD", 0);
		if (array != null)
		{
			for (int k = 0; k < array.Length; k++)
			{
				WindowsRegistryHelper.SetRegistryValue(text7 + "\\" + array[k], text8, 1, "DWORD", 0);
			}
		}
		WindowsRegistryHelper.SetRegistryValue(text5, text6, 1, "DWORD", 0);
	}

	public static void WriteTextFileAndOptionallyOpenNotepad(string string_28, string string_29, bool bool_2 = false, string string_30 = "", int int_11 = 0, int int_12 = 0, int int_13 = 0, int int_14 = 0, int int_15 = 0)
	{
		try
		{
			CommonUtility.WriteAllTextWithEncodingOption(string_28, string_29, 1);
			if (bool_2)
			{
				string text = "Software\\Microsoft\\Notepad";
				if (string_30 != "")
				{
					WindowsRegistryHelper.SetRegistryValue(text, "lfFaceName", string_30, "", 1);
				}
				if (int_11 != 0)
				{
					WindowsRegistryHelper.SetRegistryValue(text, "iPointSize", int_11 * 10, "DWORD", 1);
				}
				if (int_12 != 0)
				{
					WindowsRegistryHelper.SetRegistryValue(text, "iWindowPosDX", int_12, "DWORD", 1);
				}
				if (int_13 != 0)
				{
					WindowsRegistryHelper.SetRegistryValue(text, "iWindowPosDY", int_13, "DWORD", 1);
				}
				if (int_14 != 0)
				{
					WindowsRegistryHelper.SetRegistryValue(text, "iWindowPosX", int_14, "DWORD", 1);
				}
				if (int_15 != 0)
				{
					WindowsRegistryHelper.SetRegistryValue(text, "iWindowPosY", int_15, "DWORD", 1);
				}
				WindowsRegistryHelper.SetRegistryValue(text, "fWrap", 0, "DWORD", 1);
				WindowsRegistryHelper.SetRegistryValue(text, "lfItalic", 0, "DWORD", 1);
				WindowsInteropHelper.StartProcess("Notepad.exe", "", string_28, 0);
			}
		}
		catch
		{
		}
	}

	public static string ShowOpenFileDialog(string string_28 = "", string string_29 = "", string string_30 = "", string string_31 = "")
	{
		string result = "";
		string initialDirectory = string_28;
		if (string_28 == "")
		{
			initialDirectory = applicationDirectory;
		}
		if (string_30 == "")
		{
			string_30 = "*.txt";
		}
		string text = "Request files (" + string_30 + ")|" + string_30 + "|All files (*.*)|*.*";
		if (string_31 != null && string_31 != "")
		{
			if (string_31.IndexOf("|") < 0)
			{
				string_31 = string_31 + "|" + string_31;
			}
			text = string_31 + "|" + text;
		}
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = initialDirectory;
		openFileDialog.Filter = text;
		openFileDialog.FileName = string_29;
		openFileDialog.FilterIndex = 1;
		openFileDialog.RestoreDirectory = true;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			result = openFileDialog.FileName;
		}
		openFileDialog = null;
		return result;
	}

	public static string ShowSaveFileDialog(string string_28 = "", string string_29 = "")
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		string result = string.Empty;
		string text = string.Empty;
		if (string_29 != null)
		{
			string[] array = string_29.Split('.');
			text = array[array.Length - 1];
		}
		text = ((text == string.Empty) ? "xyz files (*.xyz)|*.xyz" : (text + " file (*." + text + ")|*." + text));
		saveFileDialog.Filter = text + "|All files (*.*)|*.*";
		saveFileDialog.FilterIndex = 1;
		saveFileDialog.RestoreDirectory = true;
		saveFileDialog.InitialDirectory = string_28;
		saveFileDialog.FileName = string_29;
		Stream stream;
		if (saveFileDialog.ShowDialog() == DialogResult.OK && (stream = saveFileDialog.OpenFile()) != null)
		{
			result = saveFileDialog.FileName;
			stream.Close();
		}
		return result;
	}

	public static string SelectFolderPath(string string_28)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		folderBrowserDialog.SelectedPath = string_28;
		folderBrowserDialog.ShowNewFolderButton = true;
		FolderBrowserDialog folderBrowserDialog2 = folderBrowserDialog;
		DialogResult dialogResult = folderBrowserDialog2.ShowDialog();
		if (dialogResult != DialogResult.OK)
		{
			return null;
		}
		return folderBrowserDialog2.SelectedPath;
	}
}

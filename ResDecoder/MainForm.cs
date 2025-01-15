using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResDecoder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessResFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProcessResFile()
        {
            string iPath = textBox1.Text;
            string oPath = textBox2.Text;
            DecodeParam.NumberOfCharacter = Convert.ToInt32(numericUpDown1.Value);
            string versionPrefix = "";
            if (radioButton1.Checked)
                versionPrefix = "";
            else if (radioButton2.Checked)
                versionPrefix = "_KOR";
            else if (radioButton3.Checked)
                versionPrefix = "_JPN";
            else if (radioButton4.Checked)
                versionPrefix = "_TWN";
            else if (radioButton5.Checked)
                versionPrefix = "_ENG";
            else
                versionPrefix = "";
            DecodeParam.SelectedRegion = versionPrefix;


            // for tb_Achievement_Script.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_Achievement_Script{0}", versionPrefix), new TbAchievementScript());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_Achievement_Script", new TbAchievementScript());
            }

            // for tb_Akashic_Parts.res
            //ProcessFile(iPath, oPath, "tb_Akashic_Parts", new TbAkashicParts());

            // for tb_Appearance.res
            ProcessFile(iPath, oPath, "tb_Appearance", new TbAppearance());

            // for tb_Booster.res
            ProcessFile(iPath, oPath, "tb_Booster", new TbBooster());

            // for tb_Booster_Script.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_Booster_Script{0}", versionPrefix), new TbBoosterScript());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_Booster_Script", new TbBoosterScript());
            }

            // for tb_Buff_Script.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_Buff_Script{0}", versionPrefix), new TbBuffScript());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_Buff_Script", new TbBuffScript());
            }

            // for tb_Character_Info.res
            ProcessFile(iPath, oPath, "tb_Character_Info", new TbCharacterInfo());

            // for tb_Character_Parts.res
            //ProcessFile(iPath, oPath, "tb_Character_Parts", new TbCharacterParts());

            // for Tb_Chattingcommand.res
            ProcessFile(iPath, oPath, "Tb_Chattingcommand", new TbChattingCommand());

            // for tb_ChattingFilter.res
            ProcessFile(iPath, oPath, "tb_ChattingFilter", new TbChattingFilter());

            // for tb_cinema_string.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_Cinema_String{0}", versionPrefix), new TbCinemaString());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_Cinema_String", new TbCinemaString());
            }

            // for Tb_Class_Form.res
            //ProcessFile(iPath, oPath, "Tb_Class_Form", new TbClassForm());

            // for Tb_Class_Speech.res
            //ProcessFile(iPath, oPath, "Tb_Class_Speech", new TbClassSpeech());

            // for tb_Cutscene_String.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_Cutscene_String{0}", versionPrefix), new TbCutsceneString());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_Cutscene_String", new TbCutsceneString());
            }

            // Where's "tb_Help_PopUp" and "tb_Help"
            // both have versionPrefix


            // for tb_item_script.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_item_script{0}", versionPrefix), new TbItemScript());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_item_script", new TbItemScript());
            }

            // for tb_LeagueSkill_Script.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_LeagueSkill_Script{0}", versionPrefix), new TbLeagueSkillScript());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_LeagueSkill_Script", new TbLeagueSkillScript());
            }

            // for tb_Loading_Img.res
            ProcessFile(iPath, oPath, "tb_Loading_Img", new TbLoadingImg());

            // for tb_Loading_Img.res
            ProcessFile(iPath, oPath, "tb_Loading_String", new TbLoadingString());

            // for tb_MazeReward_GoldDirect.res
            ProcessFile(iPath, oPath, "tb_MazeReward_GoldDirect", new TbMazeRewardGoldDirect());

            // for tb_Monster_script.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_Monster_script{0}", versionPrefix), new TbMonsterScript());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_Monster_script", new TbMonsterScript());
            }

            // for Tb_Namefilter.res
            /*
            try
            {
                ProcessFile(iPath, oPath, string.Format("Tb_Namefilter{0}", versionPrefix), new TbNameFilter());
            }
            catch
            {
                ProcessFile(iPath, oPath, "Tb_Namefilter", new TbNameFilter());
            }
            */
            ProcessFile(iPath, oPath, "Tb_Namefilter", new TbNameFilter());

            // for tb_NPC_Script.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_NPC_Script{0}", versionPrefix), new TbNPCScript());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_NPC_Script", new TbNPCScript());
            }

            // for tb_Quest_Script.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_Quest_Script{0}", versionPrefix), new TbQuestScript());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_Quest_Script", new TbQuestScript());
            }

            // for tb_Shop_String.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_Shop_String{0}", versionPrefix), new TbShopString());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_Shop_String", new TbShopString());
            }

            // for tb_Skill.res
            ProcessFile(iPath, oPath, "tb_Skill", new TbSkill());

            // for tb_Skill_Script.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_Skill_Script{0}", versionPrefix), new TbSkillScript());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_Skill_Script", new TbSkillScript());
            }

            // for tb_soul_metry.res
            //ProcessFile(path, "tb_soul_metry", new TbSoulMetry());

            // for tb_soul_metry_string.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_soul_metry_string{0}", versionPrefix), new TbSoulMetryString());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_soul_metry_string", new TbSoulMetryString());
            }

            // for tb_Speech.res
            ProcessFile(iPath, oPath, "tb_Speech", new TbSpeech());

            // for tb_Speech_String.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_Speech_String{0}", versionPrefix), new TbSpeechString());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_Speech_String", new TbSpeechString());
            }

            // for tb_Speech_tag.res
            ProcessFile(iPath, oPath, "tb_Speech_tag", new TbSpeechTag());

            // for tb_SystemMail.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_SystemMail{0}", versionPrefix), new TbSystemMail());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_SystemMail", new TbSystemMail());
            }

            // for Tb_Talk.res
            ProcessFile(iPath, oPath, "Tb_Talk", new TbTalk());

            // for Tb_Talk_List.res
            ProcessFile(iPath, oPath, "Tb_Talk_List", new TbTalkList());
            
            // for Tb_Talk_String.res
            ProcessFile(iPath, oPath, "Tb_Talk_String", new TbTalkString());

            // for Tb_Title_Info.res
            ProcessFile(iPath, oPath, "Tb_Title_Info", new TbTitleInfo());

            // for tb_Title_String.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_Title_String{0}", versionPrefix), new TbTitleString());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_Title_String", new TbTitleString());
            }

            // for tb_Tooltip_String.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_Tooltip_String{0}", versionPrefix), new TbTooltipString());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_Tooltip_String", new TbTooltipString());
            }

            // Where's tb_UI_Img???
            // it has versionPrefix

            // for tb_ui_string.res
            try
            {
                ProcessFile(iPath, oPath, string.Format("tb_ui_string{0}", versionPrefix), new TbUIString());
            }
            catch
            {
                ProcessFile(iPath, oPath, "tb_ui_string", new TbUIString());
            }

            MessageBox.Show("finish");
            }

        private void ProcessFile<T>(string iPath, string oPath, string name, T type) where T : IResReader, new()
        {
            string file = name;
            string inputFilename = Path.Combine(iPath, file + ".res");
            string outputFilename = Path.Combine(oPath, file + ".txt");
            if (!File.Exists(inputFilename))
                throw new Exception(inputFilename + " not exist!");

            List<T> tbs;
            Read(inputFilename, out tbs);
            Write(outputFilename, tbs);
        }

        private void Read<T>(string filename, out List<T>lists) where T : IResReader, new()
        {
            lists = new List<T>();
            using (FileStream fs = File.Open(filename, FileMode.Open))
            {
                EntryCount entryCount = new EntryCount();
                entryCount.Read(fs);

                for (int i = 0; i < entryCount.count; i++)
                {
                    T tb = new T();
                    tb.Read(fs);
                    lists.Add(tb);
                }
            }
        }

        private void Write<T>(string filename, List<T> lists) where T : IResReader, new()
        {
            MyStreamWriter writer = new MyStreamWriter(filename);
            StringBuilder sb = new StringBuilder();
            foreach (var list in lists)
            {
                list.Write(sb);
            }

            writer.AppendLine(sb.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tmp = ChoiceFolder();
            if (tmp != "")
                textBox1.Text = tmp;
        }

        private string ChoiceFolder()
        {
            string path = "";
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    path = fbd.SelectedPath;
                }
            }

            return path;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tmp = ChoiceFolder();
            if (tmp != "")
                textBox2.Text = tmp;
        }
    }
}

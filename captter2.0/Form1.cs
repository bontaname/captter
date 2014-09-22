using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreTweet;
using System.Security.Cryptography;
using System.IO;

namespace captter_oxy
{
    public partial class Form1 : Form
    {
        public CoreTweet.OAuth.OAuthSession session;
        public CoreTweet.Tokens token;
        //鍵
        private const string CKEY = "belhomoa";
        //初期化ベクタ
        private const string CVEC = "12345678";
        public Form1()
        {
            InitializeComponent();

        }
        [System.Security.Permissions.SecurityPermission(
        System.Security.Permissions.SecurityAction.LinkDemand,
        Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton5.Checked)
            {
                key.Text = "oILPZ6JU6A7F8Mc9JE4YQxrJL";
                TDN.Text = "9LYL6ohQ31eCiILeCpzv9k2CLc0PP4d2Qq9ebUvHHmQeqs0W9e";
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                key.Text = "5nuIxcwPj1uIm26J85SfnMXVO";
                TDN.Text = "YvDjiDXH5yaoNmKndNIbppU1uqliofcQ7k7CfxiSiJFVlW8T5X";
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                key.Text = null;
                TDN.Text = null;
                key.Enabled = true;
                TDN.Enabled = true;

            }
            else
            { 
                key.Enabled = false;
                TDN.Enabled = false;            
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string CK = key.Text;
            string CS = TDN.Text;
            session = OAuth.Authorize(CK, CS);
            string url = session.AuthorizeUri.ToString();
            System.Diagnostics.Process.Start(url);
            textBox3.Enabled = true;
            button2.Enabled = true;
        }
        bool auth;
        private void button2_Click(object sender, EventArgs e)
        {
            auth = true;
            String code = textBox3.Text;
            token = session.GetTokens(code);
            Properties.Settings.Default.tokenValue = token.AccessToken;
            Properties.Settings.Default.tokenSecret = token.AccessTokenSecret;
            Properties.Settings.Default.CK = key.Text;
            Properties.Settings.Default.CS = TDN.Text;
            textBox3.Enabled = false;
            button2.Enabled = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton4.Checked)
            {
                groupBox4.Enabled = true;

            }
            else
            {
                groupBox4.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("フォルダーを選択してください", "ふぇぇ");
                return;
            }
            if(radioButton1.Checked)
            {
                Properties.Settings.Default.img = ".jpg";
            }
            else if(radioButton2.Checked)
            {
                Properties.Settings.Default.img = ".png";
            }
            else if(radioButton3.Checked)
            {
                Properties.Settings.Default.img = ".bmp";
            }
            else if(radioButton4.Checked)
            {
                string TNOK = textBox4.Text;
                Properties.Settings.Default.img = TNOK;
            }
            else
            {
                MessageBox.Show("UnknownError" + Environment.NewLine + "ErrorCode:001", "ふぇぇ");
            }
            if(auth==true)
            {
                Properties.Settings.Default.aniki = true;
                Properties.Settings.Default.Save();
                this.Close();
            }
            else
            {
                Properties.Settings.Default.Save();
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialogクラスのインスタンスを作成
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //上部に表示する説明テキストを指定する
            fbd.Description = "tvtestの画像がキャプチャされるフォルダを指定してください。";
            //ルートフォルダを指定する
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.SelectedPath = @"C:\";
            //ユーザーが新しいフォルダを作成できるようにする
            fbd.ShowNewFolderButton = true;
            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                //選択されたフォルダをtxetbox3に代入
                textBox1.Text = fbd.SelectedPath;
                Properties.Settings.Default.tvtestpass = fbd.SelectedPath;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                Properties.Settings.Default.yaju = true;
            }
            else
            {
                Properties.Settings.Default.yaju = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AboutBox1 fc2 = new AboutBox1();
            fc2.ShowDialog(this);
            fc2.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.tvtestpass;
            if(Properties.Settings.Default.img==".jpg")
            {
                radioButton1.Checked = true;
            }
            else if(Properties.Settings.Default.img==".png")
            {
                radioButton2.Checked = true;
            }
            else if(Properties.Settings.Default.img==".bmp")
            {
                radioButton3.Checked = true;
            }
            else if (Properties.Settings.Default.img == "")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton4.Checked = true;
                textBox4.Text = Properties.Settings.Default.img;
            }
            if(Properties.Settings.Default.yaju == true)
            {
                checkBox1.Checked = true;
            }
            else 
            {
                checkBox1.Checked = false;
            }
            if (Properties.Settings.Default.oxygen == true)
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                Properties.Settings.Default.oxygen = true;
            }
            else
            {
                Properties.Settings.Default.oxygen = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.aniki = true;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
             ///Point///
            if (Properties.Settings.Default.point != "")
            {
                string str = Properties.Settings.Default.point;
                byte[] srcByteArray;
                TripleDESCryptoServiceProvider tdes; // Triple DESサービスプロバイダ
                MemoryStream outStream = null;
                CryptoStream decStream = null;
                string dst = string.Empty;

                // Triple DESサービスプロバイダを作成
                tdes = new TripleDESCryptoServiceProvider();
                // キーと初期化ベクタを取得
                byte[] key = Encoding.Unicode.GetBytes(CKEY);
                byte[] IV = Encoding.Unicode.GetBytes(CVEC);
                // バイト配列を取得
                srcByteArray = Encoding.Unicode.GetBytes(str);
                // 出力用ストリーム/復号化ストリームを作成
                using (outStream = new MemoryStream())
                using (decStream = new CryptoStream(outStream, tdes.CreateDecryptor(key, IV), CryptoStreamMode.Write))
                {
                    // 復号化
                    decStream.Write(srcByteArray, 0, srcByteArray.Length);
                    decStream.Close();
                    // 復号化されたデータを文字列にする
                    decimal twpoint;
                    string point = Encoding.Unicode.GetString(outStream.ToArray());
                    twpoint = Convert.ToDecimal(point);
                    double x;
                    x = Math.Log(Convert.ToDouble(twpoint), Convert.ToDouble(3));
                    double y = Math.Floor(x);
                    if (y >= Convert.ToDouble(5))
                    {
                        checkBox1.Enabled = true;
                        checkBox2.Enabled = true;
                        checkBox3.Enabled = true;
                    }

                    else if (y >= Convert.ToDouble(3))
                    {
                        checkBox1.Enabled = true;
                        checkBox2.Enabled = true;
                        checkBox3.Text = "レベルが足りません(要レベル5)";

                    }
                    else if (y >= Convert.ToDouble(2))
                    {
                        checkBox1.Enabled = true;
                        checkBox2.Text = "レベルが足りません(要レベル3)";
                        checkBox3.Text = "レベルが足りません(要レベル5)";
                    }
                    else if (twpoint>=Convert.ToDecimal(8))
                    {
                        checkBox1.Checked = false;
                        checkBox2.Checked = false;
                        checkBox3.Checked = false;
                        checkBox1.Text = "レベルが足りません(要レベル2)";
                        checkBox2.Text = "レベルが足りません(要レベル3)";
                        checkBox3.Text = "レベルが足りません(要レベル5)";
                    }
                    else if (y == double.NegativeInfinity)
                    {
                        checkBox1.Checked = false;
                        checkBox2.Checked = false;
                        checkBox3.Checked = false;
                        checkBox1.Text = "レベルが足りません(要レベル2)";
                        checkBox2.Text = "レベルが足りません(要レベル3)";
                        checkBox3.Text = "レベルが足りません(要レベル5)";
                    }
                    else
                    {
                        checkBox1.Checked = false;
                        checkBox2.Checked = false;
                        checkBox3.Checked = false;
                        checkBox1.Text = "レベルが足りません(要レベル2)";
                        checkBox2.Text = "レベルが足りません(要レベル3)";
                        checkBox3.Text = "レベルが足りません(要レベル5)";
                    }

                }
            }
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                Properties.Settings.Default.kbtit = true;
            }
            else
            {
                Properties.Settings.Default.kbtit = false;
            }
        }
    }
}

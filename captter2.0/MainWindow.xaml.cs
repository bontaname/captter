using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using CoreTweet;
using System.IO;
using CoreTweet.Streaming;
using System.Runtime.InteropServices;
using System.Windows.Threading;
using System.Security.Cryptography;

namespace captter_oxy
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {

        public CoreTweet.OAuth.OAuthSession session;
        public CoreTweet.Tokens token;
        //鍵
        private const string CKEY = "belhomoa";
        //初期化ベクタ
        private const string CVEC = "12345678";
        /*
        public const string CK = Properties.Settings.Default.tokenValue;
        public const string CS = Properties.Settings.Default.tokenSecret;
         * */

        public MainWindow()
        {
            InitializeComponent();
            Properties.Settings.Default.Upgrade();
            DispatcherTimer testTimer;
            var desktop = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            var KBTIT = SystemInformation.WorkingArea.Height;
            this.Top = KBTIT - (this.Height);
            this.Left = desktop.Width - (this.Width);
            testTimer = new DispatcherTimer();
            testTimer.Interval = new TimeSpan(0,0,1);
            testTimer.Tick += new EventHandler(testTimer_Tick);
            testTimer.Start();
            if (Properties.Settings.Default.tokenValue == "")
            {
                Form1 f = new Form1();
                f.Show();
            }
            else
            {
                string CK = Properties.Settings.Default.CK;
                string CS = Properties.Settings.Default.CS;
                token = Tokens.Create(CK,
                    CS,
                    Properties.Settings.Default.tokenValue,
                    Properties.Settings.Default.tokenSecret);
                /*TL出そう措置たけどうまくいかぬ
                var stream = token.Streaming.StartStream(CoreTweet.Streaming.StreamingType.User,
                new StreamingParameters(replies => "all"));
                foreach(var message in stream)
                {
                    
                    if(message is StatusMessage)
                    {
                        var status = (message as StatusMessage).Status;
                        tl.Content = status.User.ScreenName + status.Text;
                    }

                }
                */
            }

        }
        decimal twpoint;
        [System.Security.Permissions.SecurityPermission(
        System.Security.Permissions.SecurityAction.LinkDemand,
        Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        string homo = "gay";
        decimal h;
        public void testTimer_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.point == "")
            {
                twpoint = Convert.ToDecimal(1);
            }
                if (twpoint != h)
                {


                    string str = Convert.ToString(twpoint);
                    byte[] srcByteArray;
                    TripleDESCryptoServiceProvider tdes; // Triple DESサービスプロバイダ
                    MemoryStream outStream = null;
                    CryptoStream encStream = null;
                    string dst = string.Empty;
                    tl.Content = "暗号化中...";
                    // Triple DESサービスプロバイダを作成
                    tdes = new TripleDESCryptoServiceProvider();
                    // キーと初期化ベクタを取得
                    byte[] key = Encoding.Unicode.GetBytes(CKEY);
                    byte[] IV = Encoding.Unicode.GetBytes(CVEC);
                    // バイト配列を取得
                    srcByteArray = Encoding.Unicode.GetBytes(str);
                    // 出力用ストリーム/暗号化ストリームを作成
                    using (outStream = new MemoryStream())
                    using (encStream = new CryptoStream(outStream, tdes.CreateEncryptor(key, IV), CryptoStreamMode.Write))
                    {
                        // 暗号化
                        encStream.Write(srcByteArray, 0, srcByteArray.Length);
                        encStream.Close();
                        // 暗号化されたデータを文字列にする
                        dst = Encoding.Unicode.GetString(outStream.ToArray());
                        string save = Encoding.Unicode.GetString(outStream.ToArray());
                        tl.Content = "保存中...";
                        Properties.Settings.Default.point = save;
                        Properties.Settings.Default.Save();
                    }
                }
                double x;
                x = Math.Log(Convert.ToDouble(twpoint), Convert.ToDouble(3));
                double y = Math.Floor(x);
                if (y >= Convert.ToDouble(3))
                {
                    yukarin.IsEnabled = true;
                    yukarin.Content = "OXYGEN";
                }
                else
                {
                    yukarin.IsChecked = false;
                    yukarin.IsEnabled = false;
                    yukarin.Content = "レベル不足";

                }
                int g = Convert.ToInt32(y) + 1;
                decimal pta = Convert.ToDecimal(Math.Floor(Math.Pow(g, 3)));
                //System.Windows.MessageBox.Show(Convert.ToString(pta));
                tl.Content = "LEVEL:" + Convert.ToString(y) + " " + Convert.ToString(twpoint) + "pt"/*+"次のレベルまで(バグあり)" + Convert.ToString(pta - Convert.ToDecimal(twpoint)) + "pt"*/;
                if (Properties.Settings.Default.aniki == true)
                {
                    Properties.Settings.Default.aniki = false;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();

                    System.Windows.Forms.Application.Restart();
                    Environment.Exit(0);
                }
                else if (Properties.Settings.Default.oxygen == true)
                {

                    string startFolder = Properties.Settings.Default.tvtestpass;
                    try
                    {
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);


                        IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.TopDirectoryOnly);
                        string ex = null;

                        ex = Properties.Settings.Default.img;

                        IEnumerable<System.IO.FileInfo> fileQuery =
                            from file in fileList
                            where file.Extension == ex
                            orderby file.Name
                            select file;

                        var newestFile =
                            (from file in fileQuery
                             orderby file.CreationTime
                             select new { file.FullName, file.CreationTime })
                            .Last();

                        string photo = newestFile.FullName; // ツイートする画像のパス
                        if (Properties.Settings.Default.imgpass == photo)
                        {
                            return;
                        }

                        else if (photo != homo)
                        {
                            string kbtit=null;
                            if(Properties.Settings.Default.kbtit==true)
                            { }
                            else { kbtit = Environment.NewLine + "#Captter http://captter.org"; }
                            token.Statuses.UpdateWithMedia(
                                status => tweet.Text + Environment.NewLine + has.Text + kbtit,
                                media => new FileInfo(photo));
                            if (Properties.Settings.Default.yaju == true)
                            {
                                // イメージブラシの作成
                                ImageBrush imageBrush = new ImageBrush();
                                imageBrush.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri(photo, UriKind.Relative));
                                // ブラシを背景に設定する
                                this.Background = imageBrush;

                            }
                            homo = photo;
                            Properties.Settings.Default.imgpass = photo;
                            tweet.Text = null;
                            twpoint += 5;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                h = twpoint;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        public void tweet_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                tl.Content = "終了処理中...";
                string str = Convert.ToString(twpoint);
                byte[] srcByteArray;
                TripleDESCryptoServiceProvider tdes; // Triple DESサービスプロバイダ
                MemoryStream outStream = null;
                CryptoStream encStream = null;
                string dst = string.Empty;
                tl.Content = "暗号化中...";
                // Triple DESサービスプロバイダを作成
                tdes = new TripleDESCryptoServiceProvider();
                // キーと初期化ベクタを取得
                byte[] key = Encoding.Unicode.GetBytes(CKEY);
                byte[] IV = Encoding.Unicode.GetBytes(CVEC);
                // バイト配列を取得
                srcByteArray = Encoding.Unicode.GetBytes(str);
                // 出力用ストリーム/暗号化ストリームを作成
                using (outStream = new MemoryStream())
                using (encStream = new CryptoStream(outStream, tdes.CreateEncryptor(key, IV), CryptoStreamMode.Write))
                {
                    // 暗号化
                    encStream.Write(srcByteArray, 0, srcByteArray.Length);
                    encStream.Close();
                    // 暗号化されたデータを文字列にする
                    dst = Encoding.Unicode.GetString(outStream.ToArray());
                    string save = Encoding.Unicode.GetString(outStream.ToArray());
                    tl.Content = "保存中...";
                    Properties.Settings.Default.point = save;
                    Properties.Settings.Default.Save();
                    Environment.Exit(0);
                }
            }
            try
            {
                if (e.Key == Key.RightCtrl)
                {
                    token.Statuses.Update(status => tweet.Text);
                    tweet.Text = null;
                    twpoint += 15;
                }
                else if (e.Key == Key.LeftCtrl)
                {
                POST:
                    string startFolder = Properties.Settings.Default.tvtestpass;
                    try
                    {
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);


                    IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.TopDirectoryOnly);
                    string ex =null;

                        ex = Properties.Settings.Default.img;

                    IEnumerable<System.IO.FileInfo> fileQuery =
                        from file in fileList
                        where file.Extension == ex
                        orderby file.Name
                        select file;

                        try
                        {
                            var newestFile =
                                (from file in fileQuery
                                 orderby file.CreationTime
                                 select new { file.FullName, file.CreationTime })
                                .Last();
                            try
                            {
                                string photo = newestFile.FullName; // ツイートする画像のパス
                                string kbtit = null;
                                if (Properties.Settings.Default.kbtit == true)
                                { }
                                else { kbtit = Environment.NewLine + "#Captter http://captter.org"; }

                                token.Statuses.UpdateWithMedia(
                                    status => tweet.Text + Environment.NewLine + has.Text + kbtit,
                                    media => new FileInfo(photo));
                                if (Properties.Settings.Default.yaju ==true)
                                {
                                    // イメージブラシの作成
                                    ImageBrush imageBrush = new ImageBrush();
                                    imageBrush.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri(photo, UriKind.Relative));
                                    // ブラシを背景に設定する
                                    this.Background = imageBrush;
                                    
                                }
                                tweet.Text = null;
                                twpoint += 25;
                            }
                            catch (IOException)
                            {
                                System.Windows.Forms.MessageBox.Show("エラーが発生しました。ファイルが使用されています。再試行しますか？", "ふぇぇ");

                            }
                        }
                        catch (System.ArgumentException)
                        {
                            System.Windows.MessageBox.Show("初期設定を済ませてください");

                        }

                 	}

                    catch(InvalidOperationException) {
						System.Windows.MessageBox.Show ("フォルダに画像がありません", "ふぇぇ");
					}

                }
            }
            catch (TwitterException)
            {
                System.Windows.MessageBox.Show("Twitter側からエラーを返されました", "ふぇぇ");
            }
            

        }

        private void set_Loaded(object sender, RoutedEventArgs e)
        {
            if(Properties.Settings.Default.point!="")
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
                    string point = Encoding.Unicode.GetString(outStream.ToArray());
                    twpoint = Convert.ToDecimal(point);
                    point += 10;
                }

            }
            if (Properties.Settings.Default.oxygen == true)
            {
                yukarin.IsChecked = true;
            }
            else
            {
                yukarin.IsChecked = false;                                                                                    
            }

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (yukarin.IsChecked == true)
            {
                Properties.Settings.Default.oxygen = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.oxygen = false;
                Properties.Settings.Default.Save();

            }
        }

    }
}

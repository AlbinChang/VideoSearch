using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MyWebBrowser;
using System.Threading;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

namespace 影视搜搜
{
    public delegate bool BackgroundThread();

    public partial class FrmMain : Form
    {

        public FrmMain()
        {
            //Reseting explorer worked. It looks like that the popup blocker in IE was disabled and that was causing the problem. I have experimented a bit and noticed that the web browser control will always reflect the behavior of IE pop up blocker regardless settings passed to it. Try to disable the popup blocker in IE and see if your code will still block it.
            SetBrowserFeatureControl();
            InitializeComponent();

            toolStripButtonPanSou.Margin = new Padding(1, 0, 0, 0);

            //注册webbrowser的statustextchanged事件
            pageWebBrowser.StatusTextChanged += delegate(object s, EventArgs e)
            {
                if (pageWebBrowser.StatusText == "Done" ||
                    String.IsNullOrWhiteSpace(pageWebBrowser.StatusText) ||
                    pageWebBrowser.StatusText == "完成")
                {
                    return;
                }
                else
                    toolStripStatusView.Text = pageWebBrowser.StatusText;
            };

            if (urlAddress == string.Empty)
            {
                // 指定一个主页
                urlAddress = "about:blank";
                pageWebBrowser.DocumentText = webhome;          
            }
            else
            {
                pageWebBrowser.Navigate(urlAddress, false);
            }
        }

        private void SetBrowserFeatureControlKey(string feature, string appName, uint value)
        {    

            using (var key = Registry.CurrentUser.CreateSubKey(
                String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
                RegistryKeyPermissionCheck.ReadWriteSubTree))
            {                
                key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
            }
        }

        private void DeleteBrowserFeatureControlKey(string feature, string appName, uint value)
        {
            try
            {
                //key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\" + feature);
            }
            catch (Exception)
            {
            }
            finally
            {
                Registry.CurrentUser.Close();
            }
        }

        /// <summary>
        /// 函数:通过注册表屏蔽广告网页的弹出
        /// </summary>
        private void SetBrowserFeatureControl()
        {
            // http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx

            // FeatureControl settings are per-process
            var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
            //MessageBox.Show(fileName);

            // make the control is not running inside Visual Studio Designer
            if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
                return;

            // TODO: FEATURE_BROWSER_MODE - what is it?
            SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, 11000); // Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode.
            SetBrowserFeatureControlKey("FEATURE_DISABLE_NAVIGATION_SOUNDS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_POPUPMANAGEMENT", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_INPUT_PROMPTS", fileName, 1);
        }

        /// <summary>
        /// 函数：删除注册表设置
        /// </summary>
        private void AntiSetBrowserFeatureControl()
        {
            // http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx

            // FeatureControl settings are per-process
            var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
            //MessageBox.Show(fileName);

            // make the control is not running inside Visual Studio Designer
            if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
                return;

            // 删除注册表项
            DeleteBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, 11000); // Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode.
            DeleteBrowserFeatureControlKey("FEATURE_DISABLE_NAVIGATION_SOUNDS", fileName, 0);
            DeleteBrowserFeatureControlKey("FEATURE_WEBOC_POPUPMANAGEMENT", fileName, 0);
            DeleteBrowserFeatureControlKey("FEATURE_BLOCK_INPUT_PROMPTS", fileName, 0);
        }

        private bool block()
        {
            try
            {
                block_baidu();
                BlockADs();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                //防止程序发生异常而崩溃
            }
            

            if (urlAddress.Contains("www.baidu.com"))
            {
                //如果在该网站没有检索到资源，则跳到下一个网站中去。
                HtmlElementCollection p_elements = pageWebBrowser.Document.GetElementsByTagName("p");
                if (p_elements.Count != 0)
                {
                    string temp_string = p_elements[0].InnerText;
                    if (temp_string != null)
                    {
                        if (temp_string.Contains("很抱歉"))
                        {
                            pageWebBrowser.Stop();
                            search_baidu();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 函数：删除百度的广告元素
        /// </summary>
        private void block_baidu()
        {

            if (urlAddress.Contains("www.baidu.com/s?wd") )
            {
                //根据ID删除百度页面上方的不必要的页面元素
                if (pageWebBrowser.Document.All["head"] != null)
                {
                    pageWebBrowser.Document.All["head"].OuterHtml = "";
                }
                if (pageWebBrowser.Document.All["s_tab"] != null)
                {
                    pageWebBrowser.Document.All["s_tab"].OuterHtml = "";
                }
                if (pageWebBrowser.Document.All["content_right"] != null)
                {
                    pageWebBrowser.Document.All["content_right"].OuterHtml = "";
                }
                if (pageWebBrowser.Document.All["page"] != null)
                {
                    pageWebBrowser.Document.All["page"].OuterHtml = "";
                }
                if (pageWebBrowser.Document.All["rs"] != null)
                {
                    pageWebBrowser.Document.All["rs"].OuterHtml = "";
                }
                if (pageWebBrowser.Document.All["foot"] != null)
                {
                    pageWebBrowser.Document.All["foot"].OuterHtml = "";
                }

                HtmlElementCollection divs = pageWebBrowser.Document.GetElementsByTagName("div");
                foreach (HtmlElement each in divs)
                {
                    try
                    {
                        if (each.OuterHtml.Contains("您的IE浏览器版本较低，即将停止更新维护，建议升级到更快、更安全的百度浏览器"))
                        {
                            each.OuterHtml = "";
                            continue;
                        }

                        if ( each.OuterHtml.Length>100 && each.OuterHtml.Substring(0, 100).Contains("head_nums_cont_outer OP_LOG"))
                        {
                            each.OuterHtml = "";
                            break;
                        }
                        
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }                    
                }
            }
        }

        #region webhome
        public static string webhome = @"<html>" +
                                     @"<head>" +
                                     @"<title>欢迎</title>" +
                                     @"<meta charset=utf-8>" +
                                     @"</head>" +
                                     @"<body>" +
                                     @"<div style=""text-align:center"">你好!" +
                                     @"<br>    欢迎你使用本免费软件，由于作者时间有限，因此对于软件中的bug，还请发送意见到邮箱" +
                                     @"<br>albinchang@foxmail.com" +
                                     @"<br>软件功能：" +
                                     @"<br>        该软件绑定了一些比较好的影视资源网站，你只需要在搜索框输入 影视名称 即可搜索到下载资源。<br><b><span style=""color:red"">同样的片名，每次点击都会有不同的搜素结果哦!</span></b>" +
                                     @"<br>        祝你使用搜片愉快！" +
                                     @"<br>        本软件的文本配置文件都在C:\Users\Public\YingShiSouSou文件夹下 " +
                                     @"<br>        配置文件的每一行代表一个历史记录或者网站，您可以用文本文件打开进行编辑" +
                                     @"<br>        但注意符合原文件的格式，如果发现配置错了，请直接删除文件就行" +
                                     //@"<br>        <b><span style=""color:red"">使用本软件之前，务必确保电脑上安装了.NET Framework 4.5以上版本</span></b>" +
                                     //@"<br>        <a href=""http://www.microsoft.com/zh-cn/download/details.aspx?id=30653"" style=""color:red "" ><b>微软官方下载链接</b> </a>" +
                                     //@"<br>        <b><span style=""color:red"">使用之前请务必关闭IE浏览器的“Internet选项”设置下的“Privacy(隐私)”选项卡下的“Pop-up Blocker”功能，否则会与本软件的广告屏蔽功能冲突，造成页面显示不正常</span><b>" +
                                     //@"<br>" +
                                     //@"<img border=""10"" src=""http://a1.qpic.cn/psb?/V11rmTSp2Z2iun/C2g5DQyZ.oMUdRe65GhWkQti9kZ*u70JCFt89TGHRzo!/b/dG8AAAAAAAAA&bo=agJVAmoCVQIDACU!&rf=viewer_4&t=5"" width=""50%"" title=""IE选项设置"">  " +
                                     @"<br>         下面是作者的qq群，扫一扫，可以和群主一起分享影视资源哦：" +
                                     @"<br>" +
                                     @"<img border=""0"" src=""http://a1.qpic.cn/psb?/V11rmTSp2Z2iun/UBFUoTVg2lAFyw1fXebzKPkl8rcMbDIaJMNpl8E2fFE!/b/dGMAAAAAAAAA&bo=HALkAhwC5AIBCS4!&rf=viewer_4"" width=""20%"" title=""分享是一种自由"">  " +
                                     @"</div>" +
                                     @"</body>" +
                                     @"</html>";
        #endregion

        List<string> address_for_forward = new List<string>();
        private void pageBack_Click(object sender, EventArgs e)
        {
            //this.pageWebBrowser.GoBack();
            if (urlAddress_history.Count >= 2)
            {
                if (urlAddress_history[urlAddress_history.Count - 2] == "about:blank")
                    pageWebBrowser.DocumentText = webhome;
                else
                    pageWebBrowser.Navigate(urlAddress_history[urlAddress_history.Count - 2]);
                address_for_forward.Add(urlAddress_history[urlAddress_history.Count - 1]);
                urlAddress_history.RemoveAt(urlAddress_history.Count - 1);
            }

        }

        private void pageForward_Click(object sender, EventArgs e)
        {
           
            if (address_for_forward.Count > 0)
            {
                if (address_for_forward[address_for_forward.Count - 1] == "about:blank")
                    pageWebBrowser.DocumentText = webhome;
                else
                    pageWebBrowser.Navigate(address_for_forward[address_for_forward.Count - 1]);
                urlAddress_history.Add(address_for_forward[address_for_forward.Count - 1]);
                address_for_forward.RemoveAt(address_for_forward.Count - 1);
            }
        }

        private void pageRefresh_Click(object sender, EventArgs e)
        {
            pageWebBrowser.Refresh();
        }

        private void pageHome_Click(object sender, EventArgs e)
        {
            pageWebBrowser.DocumentText = webhome;
        }

        List<string> sites =new List<string>
                         {
                             " site:xiamp4.com",
                             " site:ed2000.com",
                             " site:btshoufa.com" ,
                             " site:cn163.net",
                             " site:bttiantang.com",
                             " site:mp4ba.com",
                             " site:hd1080.cn",
                             " site:9ying.net",
                             " site:tutumv.com",
                             " site:2kandy.com",
                             " site:52laikan.com",
                             " site:hdbird.com",
                             " site:chinav.tv" ,
                             " site:720mp4.com",
                             " site:933bt.com",
                             " site:dy2018.com"
                         };      

        int indexOfSites = 0;
        string urlAddress = string.Empty;
        List<string> urlAddress_history = null;

        

        

        private void toolbtnbaiduSearch_Click(object sender, EventArgs e)
        {
            search_baidu();
        }

        /// <summary>
        /// 利用百度进行网站资源检索
        /// </summary>
        private void search_baidu()
        {
            string uri = "http://www.baidu.com/s?wd=" + System.Web.HttpUtility.UrlEncode(tooltbxKeyword.Text, encoding);
            uri += System.Web.HttpUtility.UrlEncode(sites[indexOfSites], encoding);

            uri = uri.Replace("+", "%20");
                        
            urlAddress = uri;
            toolStripStatusView.Text = "正在打开网页: " + urlAddress + "...";

            if (++indexOfSites >= sites.Count)
            {
                indexOfSites = 0;
                MessageBox.Show("提示：您已经对本软件收藏的网站全部检索了一遍！");
                return;
            }


            pageWebBrowser.Navigate(uri);

        }   

        int count_of_completed = 0;


        private void pageWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            count_of_completed++;                      

            //屏蔽无关内容
            block();           

            urlAddress = pageWebBrowser.Url.ToString();
            toolStripStatusView.Text = urlAddress + " 完毕" + "+" + count_of_completed;

            //进行判断，是否将该网址加入历史列表中去
            (new Thread(add_history)).Start();

            //记录搜索关键字
            if(!string.IsNullOrWhiteSpace(tooltbxKeyword.Text))
            {
                if (!historyCollection.Contains(tooltbxKeyword.Text))
                    historyCollection.Insert(0, tooltbxKeyword.Text);
                else
                {
                    historyCollection.Remove(tooltbxKeyword.Text);
                    historyCollection.Insert(0, tooltbxKeyword.Text);
                }               
            }
           
        }

        /// <summary>
        /// 进行判断，是否将该地址加入历史列表中去
        /// </summary>
        private void add_history()
        {
            if (urlAddress_history == null)
            {
                urlAddress_history = new List<string>();
                urlAddress_history.Add(urlAddress);
            }
            else
            {
                if (urlAddress != urlAddress_history[urlAddress_history.Count - 1] && !urlAddress.Contains("www.baidu.com/link?url="))
                {
                    if (address_for_forward.Count > 0)
                    {
                        if (urlAddress != address_for_forward[address_for_forward.Count - 1])
                            urlAddress_history.Add(urlAddress);
                    }
                    else
                        urlAddress_history.Add(urlAddress);
                }

            }
        }


        private void tooltbxKeyword_TextChanged(object sender, EventArgs e)
        {
            indexOfSites = 0;
        }

       

        private void pageWebBrowser_BeforeNavigate(object sender, WebBrowserExtendedNavigatingEventArgs e)
        {

            count_of_completed = 0;

            string temp = e.Url;
            foreach (string item in listOfBlackSites)
            {
                if (temp.Contains(item))
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
        

        private void pageWebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            
            urlAddress = e.Url.ToString();       

            this.Text = pageWebBrowser.Document.Title;

            toolStripStatusView.Text = "正在打开网页: " + urlAddress + "...";
        }

        
        private void BlockADs()
        {
            HtmlElementCollection divs =  pageWebBrowser.Document.GetElementsByTagName("div");
            foreach (HtmlElement each in divs)
            {
                if (each.Style != null && each.Style.Contains("POSITION") && each.Style.Contains("OVERFLOW") )
                    each.OuterHtml = "";                
            }
        }
              


        private void toolStripButtonPanSou_Click(object sender, EventArgs e)
        {
            string uri = "http://kaopu.so/pan/" + System.Web.HttpUtility.UrlEncode(tooltbxKeyword.Text, encoding);

            uri = uri.Replace("+", "%20");

            urlAddress = uri;
            toolStripStatusView.Text = "正在打开网页: " + urlAddress + "...";

            pageWebBrowser.Navigate(uri);
        }

        private void toolStripStatusView_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(toolStripStatusView.Text,"以下文本已经复制到剪贴板");
            Clipboard.SetText(toolStripStatusView.Text);
        }

        private void statusStrip1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(toolStripStatusView.Text, "以下文本已经复制到剪贴板");
            Clipboard.SetText(toolStripStatusView.Text);
        }

        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            pageWebBrowser.Print();
        }

        //存放配置文件的目录
        readonly string directory = @"C:\Users\Public\YingShiSouSou";

        readonly string historyPath = @"C:\Users\Public\YingShiSouSou\History.txt";//记录搜索关键词历史的文本文件        
        string[] history;//记录搜索关键词历史        
        AutoCompleteStringCollection historyCollection = new AutoCompleteStringCollection();

        readonly string blackSitesPath = @"C:\Users\Public\YingShiSouSou\BlackSites.txt";//记录黑名单网站
        string[] blackSites;//记录文本文件中的黑名单网站
        List<string> listOfBlackSites = new List<string>(); //记录所有黑名单网站

        readonly string videoSitesPath = @"C:\Users\Public\YingShiSouSou\VideoSites.txt";//记录影视网站
        string[] videoSites;                                                                                    //记录文本文件中的影视网站

        private void FrmMain_Load(object sender, EventArgs e)
        {
            #region 历史记录
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (!File.Exists(historyPath))
                File.CreateText(historyPath).Close();
            
            history = File.ReadAllLines(historyPath);

            this.tooltbxKeyword.AutoCompleteCustomSource = historyCollection;

            historyCollection.AddRange(history);
            #endregion

            #region 黑名单网站
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (!File.Exists(blackSitesPath))
                File.CreateText(blackSitesPath).Close();

            blackSites = File.ReadAllLines(blackSitesPath);

            listOfBlackSites.AddRange(blackSites);

            #endregion

            #region 影视网站
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (!File.Exists(videoSitesPath))
                File.CreateText(videoSitesPath).Close();

            videoSites = File.ReadAllLines(videoSitesPath);

            sites.AddRange(videoSites);

            #endregion

        }

        System.Text.Encoding encoding = System.Text.Encoding.UTF8;

        private void toolStripButtonSubSearch_Click(object sender, EventArgs e)
        {
            
            string uri = "http://www.zimuku.net/search?ad=1&q=" + System.Web.HttpUtility.UrlEncode(tooltbxKeyword.Text, encoding);

            uri = uri.Replace("+", "%20");

            urlAddress = uri;
            toolStripStatusView.Text = "正在打开网页: " + urlAddress + "...";

            pageWebBrowser.Navigate(uri);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (StreamWriter  txtWriter = new StreamWriter(historyPath))
            {
                int i = 0;
                foreach (string each in historyCollection)
                {
                    if(!string.IsNullOrWhiteSpace(each))
                         txtWriter.WriteLine(each);
                    if ( i++ == 100)
                        break;
                }
            }

            using (StreamWriter txtWriter = new StreamWriter(blackSitesPath))
            {
                //int i = 0;
                foreach (string each in listOfBlackSites)
                {
                    if (!string.IsNullOrWhiteSpace(each))
                        txtWriter.WriteLine(each);                    
                }
            }

            using (StreamWriter txtWriter = new StreamWriter(videoSitesPath))
            {
                for (int i = 16; i < sites.Count; i++)
                {
                    txtWriter.WriteLine(sites[i]);
                }
            }
            //AntiSetBrowserFeatureControl();
        }

        private void toolStripButtonCopyUrl_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(urlAddress);
            MessageBox.Show("已将\n" + urlAddress + "\n复制到剪贴板！");
        }

        private void BtnOpenWebPage_Click(object sender, EventArgs e)
        {
            pageWebBrowser.Navigate(this.tooltbxKeyword.Text);
        }

        private void pageWebBrowser_BeforeNewWindow(object sender, WebBrowserExtendedNavigatingEventArgs e)
        {
            e.Cancel = true;
            pageWebBrowser.Navigate(e.Url);
        }

        private void toolStripBtnBlackSite_Click(object sender, EventArgs e)
        {
            string temp = urlAddress;

            string[] parts = temp.Split('/');
            if (parts.Length < 3)
                return;
            temp = parts[2];

            if (MessageBox.Show("确定将该网站加入黑名单？\n" + temp , temp, MessageBoxButtons.OKCancel) == DialogResult.OK)
                if (!listOfBlackSites.Contains(temp))
                    listOfBlackSites.Add(temp);

        }

        private void toolStripBtnCollect_Click(object sender, EventArgs e)
        {
            string temp = urlAddress;

            string[] parts = temp.Split('/');
            if (parts.Length < 3)
                return;
            temp = parts[2];

            if (MessageBox.Show("确定收藏该网站?\n收藏后本软件将会该网站加入资源检索队列中，对该网站进行资源检索.\n" + temp, temp, MessageBoxButtons.OKCancel) == DialogResult.OK)
                if (!sites.Contains(temp))
                    sites.Add(" site:"+temp);

        }

        private void toolStripBtnCleanReg_Click(object sender, EventArgs e)
        {
            if( MessageBox.Show("除非你不再使用本软件，否则请不要清除注册表设置！\n确定清除注册表设置？","清除注册表设置",MessageBoxButtons.OKCancel) == DialogResult.OK)
                AntiSetBrowserFeatureControl();
        }
    }
}

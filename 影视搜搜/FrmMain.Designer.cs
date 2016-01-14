using MyWebBrowser;
using System;
namespace 影视搜搜
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ButtonPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStipHome = new System.Windows.Forms.ToolStripButton();
            this.tooltbxKeyword = new System.Windows.Forms.ToolStripTextBox();
            this.toolbtnbaiduSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPanSou = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSubSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopyUrl = new System.Windows.Forms.ToolStripButton();
            this.BtnOpenWebPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnBlackSite = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnCollect = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnCleanReg = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusView = new System.Windows.Forms.ToolStripStatusLabel();
            this.pageWebBrowser = new MyWebBrowser.ExtendedWebBrowser();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonPrint,
            this.toolStripBack,
            this.toolStripForward,
            this.toolStripRefresh,
            this.toolStipHome,
            this.tooltbxKeyword,
            this.toolbtnbaiduSearch,
            this.toolStripButtonPanSou,
            this.toolStripButtonSubSearch,
            this.toolStripButtonCopyUrl,
            this.BtnOpenWebPage,
            this.toolStripBtnBlackSite,
            this.toolStripBtnCollect,
            this.toolStripBtnCleanReg});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1262, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "后退";
            // 
            // ButtonPrint
            // 
            this.ButtonPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonPrint.Image = ((System.Drawing.Image)(resources.GetObject("ButtonPrint.Image")));
            this.ButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonPrint.Name = "ButtonPrint";
            this.ButtonPrint.Size = new System.Drawing.Size(24, 24);
            this.ButtonPrint.Text = "打印页面";
            this.ButtonPrint.Click += new System.EventHandler(this.ButtonPrint_Click);
            // 
            // toolStripBack
            // 
            this.toolStripBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBack.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBack.Image")));
            this.toolStripBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBack.Name = "toolStripBack";
            this.toolStripBack.Size = new System.Drawing.Size(24, 24);
            this.toolStripBack.Text = "后退";
            this.toolStripBack.Click += new System.EventHandler(this.pageBack_Click);
            // 
            // toolStripForward
            // 
            this.toolStripForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripForward.Image = ((System.Drawing.Image)(resources.GetObject("toolStripForward.Image")));
            this.toolStripForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripForward.Name = "toolStripForward";
            this.toolStripForward.Size = new System.Drawing.Size(24, 24);
            this.toolStripForward.Text = "前进";
            this.toolStripForward.Click += new System.EventHandler(this.pageForward_Click);
            // 
            // toolStripRefresh
            // 
            this.toolStripRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRefresh.Image")));
            this.toolStripRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRefresh.Name = "toolStripRefresh";
            this.toolStripRefresh.Size = new System.Drawing.Size(24, 24);
            this.toolStripRefresh.Text = "刷新";
            this.toolStripRefresh.Click += new System.EventHandler(this.pageRefresh_Click);
            // 
            // toolStipHome
            // 
            this.toolStipHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStipHome.Image = ((System.Drawing.Image)(resources.GetObject("toolStipHome.Image")));
            this.toolStipHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStipHome.Name = "toolStipHome";
            this.toolStipHome.Size = new System.Drawing.Size(24, 24);
            this.toolStipHome.Text = "主页";
            this.toolStipHome.Click += new System.EventHandler(this.pageHome_Click);
            // 
            // tooltbxKeyword
            // 
            this.tooltbxKeyword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tooltbxKeyword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tooltbxKeyword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tooltbxKeyword.Name = "tooltbxKeyword";
            this.tooltbxKeyword.Size = new System.Drawing.Size(500, 27);
            this.tooltbxKeyword.Text = "片名";
            this.tooltbxKeyword.TextChanged += new System.EventHandler(this.tooltbxKeyword_TextChanged);
            // 
            // toolbtnbaiduSearch
            // 
            this.toolbtnbaiduSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnbaiduSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnbaiduSearch.Image")));
            this.toolbtnbaiduSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnbaiduSearch.Name = "toolbtnbaiduSearch";
            this.toolbtnbaiduSearch.Size = new System.Drawing.Size(24, 24);
            this.toolbtnbaiduSearch.Text = "开始搜索";
            this.toolbtnbaiduSearch.Click += new System.EventHandler(this.toolbtnbaiduSearch_Click);
            // 
            // toolStripButtonPanSou
            // 
            this.toolStripButtonPanSou.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPanSou.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonPanSou.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPanSou.Image")));
            this.toolStripButtonPanSou.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPanSou.Name = "toolStripButtonPanSou";
            this.toolStripButtonPanSou.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonPanSou.Text = "盘搜";
            this.toolStripButtonPanSou.ToolTipText = "靠谱盘搜";
            this.toolStripButtonPanSou.Click += new System.EventHandler(this.toolStripButtonPanSou_Click);
            // 
            // toolStripButtonSubSearch
            // 
            this.toolStripButtonSubSearch.BackColor = System.Drawing.Color.PaleGreen;
            this.toolStripButtonSubSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSubSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSubSearch.Image")));
            this.toolStripButtonSubSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSubSearch.Name = "toolStripButtonSubSearch";
            this.toolStripButtonSubSearch.Size = new System.Drawing.Size(73, 24);
            this.toolStripButtonSubSearch.Text = "字幕搜索";
            this.toolStripButtonSubSearch.Click += new System.EventHandler(this.toolStripButtonSubSearch_Click);
            // 
            // toolStripButtonCopyUrl
            // 
            this.toolStripButtonCopyUrl.BackColor = System.Drawing.SystemColors.Highlight;
            this.toolStripButtonCopyUrl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonCopyUrl.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopyUrl.Image")));
            this.toolStripButtonCopyUrl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopyUrl.Name = "toolStripButtonCopyUrl";
            this.toolStripButtonCopyUrl.Size = new System.Drawing.Size(103, 24);
            this.toolStripButtonCopyUrl.Text = "复制本页网址";
            this.toolStripButtonCopyUrl.Click += new System.EventHandler(this.toolStripButtonCopyUrl_Click);
            // 
            // BtnOpenWebPage
            // 
            this.BtnOpenWebPage.BackColor = System.Drawing.Color.PaleGreen;
            this.BtnOpenWebPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnOpenWebPage.Image = ((System.Drawing.Image)(resources.GetObject("BtnOpenWebPage.Image")));
            this.BtnOpenWebPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOpenWebPage.Name = "BtnOpenWebPage";
            this.BtnOpenWebPage.Size = new System.Drawing.Size(73, 24);
            this.BtnOpenWebPage.Text = "打开网页";
            this.BtnOpenWebPage.Click += new System.EventHandler(this.BtnOpenWebPage_Click);
            // 
            // toolStripBtnBlackSite
            // 
            this.toolStripBtnBlackSite.BackColor = System.Drawing.SystemColors.Highlight;
            this.toolStripBtnBlackSite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnBlackSite.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnBlackSite.Image")));
            this.toolStripBtnBlackSite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnBlackSite.Name = "toolStripBtnBlackSite";
            this.toolStripBtnBlackSite.Size = new System.Drawing.Size(88, 24);
            this.toolStripBtnBlackSite.Text = "加入黑名单";
            this.toolStripBtnBlackSite.Click += new System.EventHandler(this.toolStripBtnBlackSite_Click);
            // 
            // toolStripBtnCollect
            // 
            this.toolStripBtnCollect.BackColor = System.Drawing.Color.PaleGreen;
            this.toolStripBtnCollect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnCollect.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnCollect.Image")));
            this.toolStripBtnCollect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnCollect.Name = "toolStripBtnCollect";
            this.toolStripBtnCollect.Size = new System.Drawing.Size(88, 24);
            this.toolStripBtnCollect.Text = "收藏该网站";
            this.toolStripBtnCollect.Click += new System.EventHandler(this.toolStripBtnCollect_Click);
            // 
            // toolStripBtnCleanReg
            // 
            this.toolStripBtnCleanReg.BackColor = System.Drawing.SystemColors.Highlight;
            this.toolStripBtnCleanReg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnCleanReg.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnCleanReg.Image")));
            this.toolStripBtnCleanReg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnCleanReg.Name = "toolStripBtnCleanReg";
            this.toolStripBtnCleanReg.Size = new System.Drawing.Size(88, 24);
            this.toolStripBtnCleanReg.Text = "清除注册表";
            this.toolStripBtnCleanReg.Click += new System.EventHandler(this.toolStripBtnCleanReg_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusView});
            this.statusStrip1.Location = new System.Drawing.Point(0, 698);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1262, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.DoubleClick += new System.EventHandler(this.statusStrip1_DoubleClick);
            // 
            // toolStripStatusView
            // 
            this.toolStripStatusView.Name = "toolStripStatusView";
            this.toolStripStatusView.Size = new System.Drawing.Size(54, 20);
            this.toolStripStatusView.Text = "状态栏";
            this.toolStripStatusView.DoubleClick += new System.EventHandler(this.toolStripStatusView_DoubleClick);
            // 
            // pageWebBrowser
            // 
            this.pageWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageWebBrowser.Location = new System.Drawing.Point(0, 27);
            this.pageWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.pageWebBrowser.Name = "pageWebBrowser";
            this.pageWebBrowser.ScriptErrorsSuppressed = true;
            this.pageWebBrowser.Size = new System.Drawing.Size(1262, 671);
            this.pageWebBrowser.TabIndex = 2;
            this.pageWebBrowser.BeforeNavigate += new System.EventHandler<MyWebBrowser.WebBrowserExtendedNavigatingEventArgs>(this.pageWebBrowser_BeforeNavigate);
            this.pageWebBrowser.BeforeNewWindow += new System.EventHandler<MyWebBrowser.WebBrowserExtendedNavigatingEventArgs>(this.pageWebBrowser_BeforeNewWindow);
            this.pageWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.pageWebBrowser_DocumentCompleted);
            this.pageWebBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.pageWebBrowser_Navigated);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 723);
            this.Controls.Add(this.pageWebBrowser);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "影视搜搜-qq群-分享是一种自由";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBack;
        private System.Windows.Forms.ToolStripButton toolStripForward;
        private System.Windows.Forms.ToolStripButton toolStripRefresh;
        private System.Windows.Forms.ToolStripButton toolStipHome;
        private System.Windows.Forms.ToolStripButton toolbtnbaiduSearch;
        private System.Windows.Forms.StatusStrip statusStrip1;
        //private System.Windows.Forms.WebBrowser pageWebBrowser;
        private MyWebBrowser.ExtendedWebBrowser pageWebBrowser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusView;
        private System.Windows.Forms.ToolStripButton toolStripButtonPanSou;
        private System.Windows.Forms.ToolStripButton ButtonPrint;
        private System.Windows.Forms.ToolStripButton toolStripButtonSubSearch;
        private System.Windows.Forms.ToolStripTextBox tooltbxKeyword;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopyUrl;
        private System.Windows.Forms.ToolStripButton BtnOpenWebPage;
        private System.Windows.Forms.ToolStripButton toolStripBtnBlackSite;
        private System.Windows.Forms.ToolStripButton toolStripBtnCollect;
        private System.Windows.Forms.ToolStripButton toolStripBtnCleanReg;
    }
}


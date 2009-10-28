﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DcamMouseGesture;
using MouseKeyboardLibrary;

namespace ImperionBrowser
{
    public partial class frmMain : Form
    {
        List<string> _AllreadySendedAttacks = new List<string>();
        MouseGesture _mg;
        MouseHook mouseHook = new MouseHook();

        public frmMain()
        {
            InitializeComponent();

            // Capture mouse the events
            mouseHook.MouseDown += new MouseEventHandler(mouseHook_MouseDown);
            mouseHook.Start();

            // b) Load a file with the commands and keys once in your application
            MouseGestureData.Instance.Commands.ReadFile(Environment.CurrentDirectory + @"\Data\MouseGestureCommands.xml" );

            // c) For each Form you want to use mouse gestures...
            _mg = new MouseGesture(this, null); 
            _mg.MouseGestureEntered += new MouseGestureEventHandler(OnMouseGestureEntered);
        }

        void mouseHook_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                pnlBrowserOverlay.Enabled = true;
        }

        private void OnMouseGestureEntered(object sender, MouseGestureEventArgs e)
        {
            if (e.Command == "Left")
                GetCurrentBrowser().GoBack();
            if (e.Command == "Right")
                GetCurrentBrowser().GoForward();

            pnlBrowserOverlay.Enabled = false;
        }

        #region browser events
        private void browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            toolBarProgress.Maximum = Convert.ToInt32(e.MaximumProgress);
            toolBarProgress.Value = Convert.ToInt32(e.CurrentProgress);
        }

        void newBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            edtAdress.Text = e.Url.ToString();
        }

        void newBrowser_DocumentTitleChanged(object sender, EventArgs e)
        {
            WebBrowser browser = (WebBrowser)sender;
            TabPage page = (TabPage)browser.Parent;
            if (page.Tag == null || page.Tag.ToString() != "1")
            {
                edtAdress.Text = GetCurrentBrowser().Url.ToString();
                page.Text = browser.DocumentTitle;
            }
        }

        #endregion

        #region generel interface
        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            AddNewBrowserTab(e);
        }

        /// <summary>
        /// Will add a new tab page to the main tab control with new browser element. The new browser Element
        /// will have the same url as the previous tab page browser element
        /// </summary>
        /// <param name="e">eventargs of tab selecting</param>
        private void AddNewBrowserTab(TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabNewPage)
            {
                InsertNewPage(e.TabPageIndex, ((WebBrowser)tabControl.TabPages[e.TabPageIndex - 1].Controls["browser"]).Url);
            }
            else
            {
                
            }
        }

        /// <summary>
        /// Load tab from string: tabtext;url for browser
        /// </summary>
        /// <param name="curLine">line</param>
        private void AddNewBrowserTab(string curLine)
        {
            char[] sep = { ';' };
            string[] elements = curLine.Split(sep);
            string TabText = elements[0];
            string TabUrl = elements[1];
            Uri uri = new Uri(TabUrl);

            TabPage page = InsertNewPage(tabControl.TabCount - 1, uri);
            page.Text = TabText;
            page.Tag = "1";

        }

        private TabPage InsertNewPage(int iIndex, Uri iBrowserUri)
        {
            WebBrowser newBrowser = CreateCommonWebBrowserElement();
            newBrowser.Navigate(iBrowserUri);

            TabPage page = new TabPage();
            page.Controls.Add(newBrowser);
            page.Text = "Imperion";

            tabControl.TabPages.Insert(iIndex, page);
            tabControl.SelectedTab = page;

            return page;
        }

        private WebBrowser CreateCommonWebBrowserElement()
        {
            WebBrowser newBrowser = new WebBrowser();
            newBrowser.Name = "browser";
            newBrowser.Dock = DockStyle.Fill;
            newBrowser.ProgressChanged += browser_ProgressChanged;
            newBrowser.Navigating += new WebBrowserNavigatingEventHandler(newBrowser_Navigating);
            newBrowser.DocumentTitleChanged += new EventHandler(newBrowser_DocumentTitleChanged);

            return newBrowser;
        }

        private void tabControl_MouseClick(object sender, MouseEventArgs e)
        {
            TabPage clickedPage = GetClickedPage(e);
            
            if (e.Button == MouseButtons.Right)
            {
                CloseTab(clickedPage);
            }
            if (e.Button == MouseButtons.Middle)
            {
                GetCurrentBrowser().GoBack();
            }
        }

        private void tabControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TabPage clieckedPage = GetClickedPage(e);
            RenameTab(clieckedPage);
        }

        /// <summary>
        /// Trys to find the clicked tab page by current mouse position
        /// </summary>
        /// <param name="e">Mouse Event</param>
        /// <returns></returns>
        private TabPage GetClickedPage(MouseEventArgs e)
        {
            for (int i = 0; i < tabControl.TabCount; i++)
            {
                // get their rectangle area and check if it contains the mouse cursor
                Rectangle r = tabControl.GetTabRect(i);
                if (r.Contains(e.Location))
                {
                    return tabControl.TabPages[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Shows a dialog to rename a tab
        /// </summary>
        /// <param name="tabPage">The tab you want to rename</param>
        private void RenameTab(TabPage tabPage)
        {
            if (tabPage == tabNewPage || tabPage == null)
                return;

            frmRenameTab frmRnmTab = new frmRenameTab();
            frmRnmTab.TabName = tabPage.Text;
            if (frmRnmTab.ShowDialog() == DialogResult.OK)
                tabPage.Text = frmRnmTab.TabName;
            
        }

        /// <summary>
        /// Close a Tab and remove all Controls
        /// </summary>
        /// <param name="tabPage">The Tab Page you want to close</param>
        private void CloseTab(TabPage tabPage)
        {
            if (tabPage == tabMain || tabPage == tabNewPage || tabPage == null)
                return;

            tabPage.Controls.Clear();
            tabControl.TabPages.Remove(tabPage);
        }

        /// <summary>
        /// Save all current opend register to a text file
        /// </summary>
        private void SaveOpendRegister()
        {
            string TabSaveFilePath = Application.StartupPath + "\\tabs.cfg";
            StringBuilder sb = new StringBuilder();
            foreach (TabPage tab in tabControl.TabPages)
            {
                if (tab == tabNewPage || tab == tabMain) // we dont need to save this tab
                    continue;

                sb.AppendLine(tab.Text + ";" + ((WebBrowser)tab.Controls["browser"]).Url.ToString()); 
            }

            using (StreamWriter sw = new StreamWriter(TabSaveFilePath,false))
            {
                sw.Write(sb.ToString());
                sw.Close();
            }
        }
        
        /// <summary>
        /// Load registers by stored text file
        /// </summary>
        private void LoadSavedRegister()
        {
            string TabSaveFilePath = Application.StartupPath + "\\tabs.cfg";

            if (!File.Exists(TabSaveFilePath))
                return;

            using (StreamReader sr = new StreamReader(TabSaveFilePath))
            {
                string curLine = String.Empty;
                while (!sr.EndOfStream)
                {
                    curLine = sr.ReadLine();
                    AddNewBrowserTab(curLine);
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadSavedRegister();
        }

        private void edtAdress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                GetCurrentBrowser().Navigate(edtAdress.Text);
            }
        }

        public WebBrowser GetCurrentBrowser()
        {
            return (WebBrowser)tabControl.SelectedTab.Controls["browser"];
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GetCurrentBrowser().GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            GetCurrentBrowser().GoForward();
        }

        #endregion

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            mouseHook.Stop();
            SaveOpendRegister();
        }

        #region parsing

        private void btnFindComets_Click(object sender, EventArgs e)
        {
            WebBrowser browser = GetCurrentBrowser();
            Tools.SaveCookies(browser, "cookies.txt");

            if (browser.ReadyState != WebBrowserReadyState.Complete)
            {
                MessageBox.Show("Das Universum ist noch nicht komplett geladen, bitte Vorgang später wiederholen", "Universum noch nicht bereit...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!browser.Url.ToString().Contains("map"))
            {
                DialogResult res = MessageBox.Show("Für diese Funktion muss zur Universumskarte navigiert werden. Navigation durchführen?", "Navigation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    browser.Navigate("http://u1.imperion.de/map/index");

                return;
            }

            ImperionParser parser = new ImperionParser(browser);
            parser.ShowRecyclerTargets(this);
        }

        #endregion

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguration frmConfig = new frmConfiguration();
            frmConfig.ShowDialog();
        }

        private void btnSMSAlert_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.gAccount == "" ||
                Properties.Settings.Default.gPwd == "" ||
                Properties.Settings.Default.gPostUrl == "")
            {
                MessageBox.Show("Bitte gehe erst in die Einstellungen und nehme die nötige Konfiguration vor", "Einstellungen nicht komplett", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (btnSMSAlert.Checked)
            {
                btnSMSAlert.ToolTipText = "Handybenarchichtigung jetzt ausschalten";
                _AllreadySendedAttacks.Clear();
                timerHandyAlert.Enabled = true;
            }
            else
            {
                btnSMSAlert.ToolTipText = "Handybenarchichtigung jetzt einschalten";
                timerHandyAlert.Enabled = false;
            }
        }

        private void timerHandyAlert_Tick(object sender, EventArgs e)
        {
            WebBrowser browser = GetCurrentBrowser();
            HtmlElement incomingAttackContent = browser.Document.GetElementById("incomingAttackContent");

            if (incomingAttackContent == null)
            {
                browser.Refresh();
                //there is no attack running
                return;
            }

            GoogleSms gSms = new GoogleSms(Properties.Settings.Default.gAccount, Properties.Settings.Default.gPwd);

            HtmlElementCollection links = incomingAttackContent.GetElementsByTagName("a");
            HtmlElementCollection spans;
            string text = "";

            for (int i = 0; i < links.Count; i++)
            {
                if (_AllreadySendedAttacks.Contains(links[i].Id))
                    continue;
                else
                    _AllreadySendedAttacks.Add(links[i].Id);
                
                spans = links[i].GetElementsByTagName("span");
                text = spans[0].InnerText + " in " + spans[1].InnerText;
                gSms.SendSms(Properties.Settings.Default.gPostUrl, text, "Imperion");
            }

        }

        private void pnlBrowserOverlay_MouseDown(object sender, MouseEventArgs e)
        {
            Text = "TEst";
        }

        private void pnlBrowserOverlay_MouseClick(object sender, MouseEventArgs e)
        {
            Text = "click";
        }

    }
}

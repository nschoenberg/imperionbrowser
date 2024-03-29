﻿namespace ImperionBrowser
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolBarProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolBarTop = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Zurück = new System.Windows.Forms.ToolStripButton();
            this.btnHistoryForward = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshBrowser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblAdress = new System.Windows.Forms.ToolStripLabel();
            this.edtAdress = new System.Windows.Forms.ToolStripTextBox();
            this.ContentContainer = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabNewPage = new System.Windows.Forms.TabPage();
            this.toolBarRight = new System.Windows.Forms.ToolStrip();
            this.btnFindComets = new System.Windows.Forms.ToolStripButton();
            this.btnRaidOverview = new System.Windows.Forms.ToolStripButton();
            this.btnGrowingStatistic = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSMSAlert = new System.Windows.Forms.ToolStripButton();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datenbankErzeugenPrüfenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerHandyAlert = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolBarTop.SuspendLayout();
            this.ContentContainer.Panel1.SuspendLayout();
            this.ContentContainer.Panel2.SuspendLayout();
            this.ContentContainer.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.toolBarRight.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarProgress,
            this.toolBarLabel,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 552);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(942, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolBarProgress
            // 
            this.toolBarProgress.Name = "toolBarProgress";
            this.toolBarProgress.Size = new System.Drawing.Size(300, 16);
            // 
            // toolBarLabel
            // 
            this.toolBarLabel.Name = "toolBarLabel";
            this.toolBarLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(625, 17);
            this.lblStatus.Spring = true;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolBarTop);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ContentContainer);
            this.splitContainer1.Size = new System.Drawing.Size(942, 528);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 4;
            // 
            // toolBarTop
            // 
            this.toolBarTop.CanOverflow = false;
            this.toolBarTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolBarTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.Zurück,
            this.btnHistoryForward,
            this.btnRefreshBrowser,
            this.toolStripSeparator3,
            this.lblAdress,
            this.edtAdress});
            this.toolBarTop.Location = new System.Drawing.Point(0, 0);
            this.toolBarTop.Name = "toolBarTop";
            this.toolBarTop.Size = new System.Drawing.Size(942, 25);
            this.toolBarTop.TabIndex = 0;
            this.toolBarTop.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Zurück
            // 
            this.Zurück.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Zurück.Image = ((System.Drawing.Image)(resources.GetObject("Zurück.Image")));
            this.Zurück.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Zurück.Name = "Zurück";
            this.Zurück.Size = new System.Drawing.Size(23, 22);
            this.Zurück.Text = "toolStripButton2";
            this.Zurück.ToolTipText = "Zurück";
            this.Zurück.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnHistoryForward
            // 
            this.btnHistoryForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHistoryForward.Image = ((System.Drawing.Image)(resources.GetObject("btnHistoryForward.Image")));
            this.btnHistoryForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHistoryForward.Name = "btnHistoryForward";
            this.btnHistoryForward.Size = new System.Drawing.Size(23, 22);
            this.btnHistoryForward.Text = "Vorwärts";
            this.btnHistoryForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnRefreshBrowser
            // 
            this.btnRefreshBrowser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshBrowser.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshBrowser.Image")));
            this.btnRefreshBrowser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshBrowser.Name = "btnRefreshBrowser";
            this.btnRefreshBrowser.Size = new System.Drawing.Size(23, 22);
            this.btnRefreshBrowser.Text = "Seite neu laden";
            this.btnRefreshBrowser.Click += new System.EventHandler(this.btnRefreshBrowser_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // lblAdress
            // 
            this.lblAdress.Name = "lblAdress";
            this.lblAdress.Size = new System.Drawing.Size(48, 22);
            this.lblAdress.Text = "Adresse";
            // 
            // edtAdress
            // 
            this.edtAdress.AutoSize = false;
            this.edtAdress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edtAdress.Name = "edtAdress";
            this.edtAdress.Size = new System.Drawing.Size(776, 23);
            this.edtAdress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtAdress_KeyUp);
            // 
            // ContentContainer
            // 
            this.ContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.ContentContainer.Location = new System.Drawing.Point(0, 0);
            this.ContentContainer.Name = "ContentContainer";
            // 
            // ContentContainer.Panel1
            // 
            this.ContentContainer.Panel1.Controls.Add(this.tabControl);
            // 
            // ContentContainer.Panel2
            // 
            this.ContentContainer.Panel2.Controls.Add(this.toolBarRight);
            this.ContentContainer.Size = new System.Drawing.Size(942, 499);
            this.ContentContainer.SplitterDistance = 913;
            this.ContentContainer.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabNewPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.HotTrack = true;
            this.tabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(913, 499);
            this.tabControl.TabIndex = 4;
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Selecting);
            this.tabControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseDoubleClick);
            this.tabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseClick);
            // 
            // tabMain
            // 
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(905, 473);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // tabNewPage
            // 
            this.tabNewPage.Location = new System.Drawing.Point(4, 22);
            this.tabNewPage.Name = "tabNewPage";
            this.tabNewPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabNewPage.Size = new System.Drawing.Size(905, 473);
            this.tabNewPage.TabIndex = 1;
            this.tabNewPage.UseVisualStyleBackColor = true;
            // 
            // toolBarRight
            // 
            this.toolBarRight.CanOverflow = false;
            this.toolBarRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolBarRight.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolBarRight.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolBarRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFindComets,
            this.btnRaidOverview,
            this.btnGrowingStatistic,
            this.toolStripSplitButton1,
            this.btnSMSAlert});
            this.toolBarRight.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolBarRight.Location = new System.Drawing.Point(0, 0);
            this.toolBarRight.Margin = new System.Windows.Forms.Padding(2);
            this.toolBarRight.MinimumSize = new System.Drawing.Size(32, 0);
            this.toolBarRight.Name = "toolBarRight";
            this.toolBarRight.Padding = new System.Windows.Forms.Padding(0, 20, 10, 0);
            this.toolBarRight.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolBarRight.Size = new System.Drawing.Size(32, 499);
            this.toolBarRight.TabIndex = 1;
            this.toolBarRight.TabStop = true;
            this.toolBarRight.Text = "toolStrip2";
            // 
            // btnFindComets
            // 
            this.btnFindComets.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFindComets.Image = ((System.Drawing.Image)(resources.GetObject("btnFindComets.Image")));
            this.btnFindComets.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFindComets.Margin = new System.Windows.Forms.Padding(0);
            this.btnFindComets.Name = "btnFindComets";
            this.btnFindComets.Padding = new System.Windows.Forms.Padding(2);
            this.btnFindComets.Size = new System.Drawing.Size(21, 24);
            this.btnFindComets.Text = "Kometen finden (strg+K)";
            this.btnFindComets.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnFindComets.Click += new System.EventHandler(this.btnFindComets_Click);
            // 
            // btnRaidOverview
            // 
            this.btnRaidOverview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRaidOverview.Image = ((System.Drawing.Image)(resources.GetObject("btnRaidOverview.Image")));
            this.btnRaidOverview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRaidOverview.Name = "btnRaidOverview";
            this.btnRaidOverview.Size = new System.Drawing.Size(21, 20);
            this.btnRaidOverview.ToolTipText = "Raid Übersicht (strg+R)";
            this.btnRaidOverview.Click += new System.EventHandler(this.btnFindEmptyNotRaidedPlanets_Click);
            // 
            // btnGrowingStatistic
            // 
            this.btnGrowingStatistic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGrowingStatistic.Image = ((System.Drawing.Image)(resources.GetObject("btnGrowingStatistic.Image")));
            this.btnGrowingStatistic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGrowingStatistic.Name = "btnGrowingStatistic";
            this.btnGrowingStatistic.Size = new System.Drawing.Size(21, 20);
            this.btnGrowingStatistic.ToolTipText = "Planeten wachstum (strg+W)";
            this.btnGrowingStatistic.Click += new System.EventHandler(this.btnGrowingStatistic_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(21, 6);
            // 
            // btnSMSAlert
            // 
            this.btnSMSAlert.CheckOnClick = true;
            this.btnSMSAlert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSMSAlert.Image = ((System.Drawing.Image)(resources.GetObject("btnSMSAlert.Image")));
            this.btnSMSAlert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSMSAlert.Name = "btnSMSAlert";
            this.btnSMSAlert.Size = new System.Drawing.Size(21, 20);
            this.btnSMSAlert.ToolTipText = "Handybenarchichtigung bei Angriff (strg+h)";
            this.btnSMSAlert.Click += new System.EventHandler(this.btnSMSAlert_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.extrasToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(942, 24);
            this.mainMenu.TabIndex = 5;
            this.mainMenu.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "&Datei";
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.beendenToolStripMenuItem.Text = "B&eenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // extrasToolStripMenuItem
            // 
            this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenToolStripMenuItem,
            this.datenbankErzeugenPrüfenToolStripMenuItem});
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            this.extrasToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.extrasToolStripMenuItem.Text = "E&xtras";
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.einstellungenToolStripMenuItem.Text = "&Einstellungen...";
            this.einstellungenToolStripMenuItem.Click += new System.EventHandler(this.einstellungenToolStripMenuItem_Click);
            // 
            // datenbankErzeugenPrüfenToolStripMenuItem
            // 
            this.datenbankErzeugenPrüfenToolStripMenuItem.Name = "datenbankErzeugenPrüfenToolStripMenuItem";
            this.datenbankErzeugenPrüfenToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.datenbankErzeugenPrüfenToolStripMenuItem.Text = "Datenbank erzeugen / prüfen";
            this.datenbankErzeugenPrüfenToolStripMenuItem.ToolTipText = "Die Datenbank wird auf vollständigkeit Überprüft und fehlende Tabellen erzeugt";
            this.datenbankErzeugenPrüfenToolStripMenuItem.Click += new System.EventHandler(this.datenbankErzeugenPruefenToolStripMenuItem_Click);
            // 
            // timerHandyAlert
            // 
            this.timerHandyAlert.Interval = 30000;
            this.timerHandyAlert.Tick += new System.EventHandler(this.timerHandyAlert_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 574);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "frmMain";
            this.Text = "Imperion Browser";
            this.TransparencyKey = System.Drawing.Color.Purple;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolBarTop.ResumeLayout(false);
            this.toolBarTop.PerformLayout();
            this.ContentContainer.Panel1.ResumeLayout(false);
            this.ContentContainer.Panel2.ResumeLayout(false);
            this.ContentContainer.Panel2.PerformLayout();
            this.ContentContainer.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.toolBarRight.ResumeLayout(false);
            this.toolBarRight.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolBarLabel;
        private System.Windows.Forms.ToolStripProgressBar toolBarProgress;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolBarTop;
        private System.Windows.Forms.SplitContainer ContentContainer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabNewPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton Zurück;
        private System.Windows.Forms.ToolStripButton btnHistoryForward;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lblAdress;
        private System.Windows.Forms.ToolStripTextBox edtAdress;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.Timer timerHandyAlert;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripButton btnRefreshBrowser;
        private System.Windows.Forms.ToolStripMenuItem datenbankErzeugenPrüfenToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolBarRight;
        private System.Windows.Forms.ToolStripButton btnFindComets;
        private System.Windows.Forms.ToolStripButton btnRaidOverview;
        private System.Windows.Forms.ToolStripButton btnGrowingStatistic;
        private System.Windows.Forms.ToolStripSeparator toolStripSplitButton1;
        private System.Windows.Forms.ToolStripButton btnSMSAlert;
    }
}


﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ImperionBrowser
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
            //Application.Run(new frmTest());
            //Application.Run(new frmPlanetGrowing(new GalaxyMap(),new frmMain()));
        }
    }
}
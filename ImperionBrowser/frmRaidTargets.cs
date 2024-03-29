﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImperionBrowser
{
    public partial class frmRaidTargets : Form
    {

        GalaxyMap _GalaxyMap;
        frmMain _ownerForm;

        public frmRaidTargets(GalaxyMap iGalaxyMap, frmMain iOwnerForm)
        {
            InitializeComponent();

            SetRace((RaceTypes)Properties.Settings.Default.Race);

            _GalaxyMap = iGalaxyMap;
            _ownerForm = iOwnerForm;
        }

        private void SetRace(RaceTypes iRace)
        {
            cmbxRace.SelectedIndex = (int)iRace;

            switch (iRace)
            {
                case RaceTypes.Terran:
                    pctrbxSprite.Load("Data/image/terranSprite.gif");
                    break;
                case RaceTypes.Titan:
                    pctrbxSprite.Load("Data/image/titanSprite.gif");
                    break;
                case RaceTypes.Xen:
                    pctrbxSprite.Load("Data/image/xenSprite.gif");
                    break;
            }
        }

        private void InitDataGrid()
        {
            dataGrid.SelectAll();
            dataGrid.ClearSelection();
            DataTable dataTable = new DataTable("GalaxyMap");
            dataTable.Columns.Add(Tools.CreateDataColumn(typeof(string), "Name", "Name", false, false, false));
            dataTable.Columns.Add(Tools.CreateDataColumn(typeof(Image), "Typ", "Typ", false, false, false));
            dataTable.Columns.Add(Tools.CreateDataColumn(typeof(string), "Flugzeit", "Flugzeit", false, false, false));
            dataTable.Columns.Add(Tools.CreateDataColumn(typeof(string), "LetzterAngriff", "LetzterAngriff", false, false, false));
            dataTable.Columns.Add(Tools.CreateDataColumn(typeof(object), "Object", "Object", false, false, false));

            progressBar.Value = 0;
            progressBar.Maximum = _GalaxyMap.Systems.Count;
            pnlProgress.Visible = true;

            for (int i = 0; i < _GalaxyMap.Systems.Count; i++)
            {
                for (int j = 0; j < _GalaxyMap.Systems[i].Planets.Count; j++)
                {
                    //skip planet if it is owned by someone
                    if (_GalaxyMap.Systems[i].Planets[j]._player_name != "")
                        continue;

                    //skip planet if it is a gas planet
                    if (_GalaxyMap.Systems[i].Planets[j].Type == PlanetType.Gas)
                        continue;

                    //skip planets if filter checkbox is unchecked
                    if (!isPlanetFilterActive(_GalaxyMap.Systems[i].Planets[j].Type))
                        continue;

                    DataRow row = dataTable.Rows.Add();
                    row["Name"] = _GalaxyMap.Systems[i].Planets[j]._planet_id;
                    row["Typ"] = Tools.GetImageOfPlanet(_GalaxyMap.Systems[i].Planets[j]);
                    row["Flugzeit"] = FlightTime.GetFlightTime(_ownerForm._CurSystemId, _GalaxyMap.Systems[i]._system_id, _GalaxyMap.Systems[i].Planets[j]._planet_id, (int)TerranSpaceShip.ssKleinerTransporter, typeof(Planet));
                    row["LetzterAngriff"] = _GalaxyMap.Systems[i].Planets[j].GetLatestReportTimeAsString("dd.MM.yyyy HH:mm");
                    row["Object"] = _GalaxyMap.Systems[i].Planets[j];
                }

                progressBar.Value = i;
                Application.DoEvents();
            }
            pnlProgress.Visible = false;

            DataView view = dataTable.DefaultView;
            view.Sort = "Flugzeit ASC, LetzterAngriff ASC";
            
            dataGrid.DataSource = view;
            dataGrid.Columns["Object"].Visible = false;
            dataGrid.Columns["Typ"].Width = 30;
            dataGrid.Columns["LetzterAngriff"].Width = 359;

        }

        private bool isPlanetFilterActive(PlanetType planetType)
        {
            bool result;

            switch (planetType)
            {
                case PlanetType.Desert:
                    result = chckbxDesertFilter.Checked;
                    break;
                case PlanetType.Earth:
                    result = chckbxEarthFilter.Checked;
                    break;
                case PlanetType.Ice:
                    result = chckbxIceFilter.Checked;
                    break;
                case PlanetType.Vulcan:
                    result = chckbxVulcanFilter.Checked;
                    break;
                case PlanetType.Water:
                    result = chckbxWaterFilter.Checked;
                    break;
                default:
                    result = false;
                    break;
            }

            return result;
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Row index -1 is the header column, dont do anything here
            if (e.RowIndex == -1) return;
            
            Planet planet = (Planet)dataGrid.Rows[e.RowIndex].Cells["Object"].Value;
            string url = String.Format("http://u1.imperion.de/fleetBase/mission/1/planetId/{0}/m/302", planet._planet_id);

            //Navigate the browser
            Tools.OpenFleetBaseOfPlanet(_ownerForm.GetCurrentBrowser(), planet);

            //Add document completed events to automatically add ships
            _ownerForm.GetCurrentBrowser().DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(frmRaidTargets_DocumentCompleted);
        }

        void frmRaidTargets_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser browser = (WebBrowser)sender;

            RaceTypes race = (RaceTypes)cmbxRace.SelectedIndex;

            int[] inputIds = Tools.GetInputIds(race);

            if (ship1.Value != 0)
                browser.Document.GetElementById("shipInput_" + inputIds[0].ToString()).SetAttribute("value", ship1.Value.ToString());

            if (ship2.Value != 0)
                browser.Document.GetElementById("shipInput_" + inputIds[1].ToString()).SetAttribute("value", ship2.Value.ToString());

            if (ship3.Value != 0)
                browser.Document.GetElementById("shipInput_" + inputIds[2].ToString()).SetAttribute("value", ship3.Value.ToString());

            if (ship4.Value != 0)
                browser.Document.GetElementById("shipInput_" + inputIds[3].ToString()).SetAttribute("value", ship4.Value.ToString());

            if (ship5.Value != 0)
                browser.Document.GetElementById("shipInput_" + inputIds[4].ToString()).SetAttribute("value", ship5.Value.ToString());

            if (ship6.Value != 0)
                browser.Document.GetElementById("shipInput_" + inputIds[5].ToString()).SetAttribute("value", ship6.Value.ToString());
            
            if (ship7.Value != 0)
                browser.Document.GetElementById("shipInput_" + inputIds[6].ToString()).SetAttribute("value", ship7.Value.ToString());

            if (ship8.Value != 0)
                browser.Document.GetElementById("shipInput_" + inputIds[7].ToString()).SetAttribute("value", ship8.Value.ToString());

            if (ship9.Value != 0)
                browser.Document.GetElementById("shipInput_" + inputIds[8].ToString()).SetAttribute("value", ship9.Value.ToString());

            if (ship10.Value != 0)
                browser.Document.GetElementById("shipInput_" + inputIds[9].ToString()).SetAttribute("value", ship10.Value.ToString());

            if (ship11.Value != 0)
                browser.Document.GetElementById("shipInput_" + inputIds[10].ToString()).SetAttribute("value", ship11.Value.ToString());

            if (ship12.Value != 0)
                browser.Document.GetElementById("shipInput_" + inputIds[11].ToString()).SetAttribute("value", ship12.Value.ToString());

            browser.DocumentCompleted -= frmRaidTargets_DocumentCompleted;
        }

        private void frmRecyclerTargets_Shown(object sender, EventArgs e)
        {
            InitDataGrid();
        }

        private void cmbxRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetRace((RaceTypes)cmbxRace.SelectedIndex);

            Properties.Settings.Default.Race = cmbxRace.SelectedIndex;
        }

        private void btnFilterNow_Click(object sender, EventArgs e)
        {
            InitDataGrid();
        }
    }
}

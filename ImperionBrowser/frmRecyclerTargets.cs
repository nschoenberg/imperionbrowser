﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImperionBrowser
{
    public partial class frmRecyclerTargets : Form
    {
        GalaxyMap _GalaxyMap;
        frmMain _ownerForm;

        public frmRecyclerTargets(GalaxyMap iGalaxyMap, frmMain iOwnerForm)
        {
            InitializeComponent();
            _GalaxyMap = iGalaxyMap;
            _ownerForm = iOwnerForm;
        }

        private void InitDataGrid()
        {
            DataTable dataTable = new DataTable("GalaxyMap");
            dataTable.Columns.Add(Tools.CreateDataColumn(typeof(string), "Name", "Name", false, false, false));
            dataTable.Columns.Add(Tools.CreateDataColumn(typeof(string), "Typ", "Typ", false, false, false));
            dataTable.Columns.Add(Tools.CreateDataColumn(typeof(string), "Flugzeit", "Flugzeit", false, false, false));
            dataTable.Columns.Add(Tools.CreateDataColumn(typeof(string), "Metall", "Metal", false, false, false));
            dataTable.Columns.Add(Tools.CreateDataColumn(typeof(string), "Kristall", "Kristall", false, false, false));
            dataTable.Columns.Add(Tools.CreateDataColumn(typeof(string), "Deuterium", "Deuterium", false, false, false));
            dataTable.Columns.Add(Tools.CreateDataColumn(typeof(object), "Object", "Object", false, false, false));

            progressBar.Value = 0;
            progressBar.Maximum = _GalaxyMap.Systems.Count;
            pnlProgress.Visible = true;

            for (int i = 0; i < _GalaxyMap.Systems.Count; i++)
            {
                for (int j = 0; j < _GalaxyMap.Systems[i].Comets.Count; j++)
                {
                    DataRow row = dataTable.Rows.Add();
                    row["Name"] = _GalaxyMap.Systems[i].Comets[j]._Name;
                    row["Typ"] = "Komet";
                    row["Flugzeit"] = FlightTime.GetFlightTime(_ownerForm._CurSystemId, _GalaxyMap.Systems[i]._system_id, _GalaxyMap.Systems[i].Comets[j]._Id, (int)TerranSpaceShip.ssRecycler, typeof(Comet));  //_GalaxyMap.GetFlightTime(_GalaxyMap.Systems[i].Comets[j]._Id, typeof(Comet), TerranSpaceShip.ssRecycler);
                    row["Metall"] = _GalaxyMap.Systems[i].Comets[j].Resources._metalFields;
                    row["Kristall"] = _GalaxyMap.Systems[i].Comets[j].Resources._crystalFields;
                    row["Deuterium"] = _GalaxyMap.Systems[i].Comets[j].Resources._deutriFields;
                    row["object"] = _GalaxyMap.Systems[i].Comets[j];
                }

                for (int j = 0; j < _GalaxyMap.Systems[i].Debris.Count; j++)
                {
                    DataRow row = dataTable.Rows.Add();
                    row["Name"] = "Trüfld. an " + _GalaxyMap.Systems[i].Debris[j]._planetId;
                    row["Typ"] = "Trümmerfeld";
                    row["Flugzeit"] = FlightTime.GetFlightTime(_ownerForm._CurSystemId, _GalaxyMap.Systems[i]._system_id, _GalaxyMap.Systems[i].Debris[j]._planetId, (int)TerranSpaceShip.ssRecycler, typeof(Debris));
                    row["Metall"] = _GalaxyMap.Systems[i].Debris[j].Resource._metalFields;
                    row["Kristall"] = _GalaxyMap.Systems[i].Debris[j].Resource._crystalFields;
                    row["Deuterium"] = _GalaxyMap.Systems[i].Debris[j].Resource._deutriFields;
                    row["object"] = _GalaxyMap.Systems[i].Debris[j];
                }

                for (int j = 0; j < _GalaxyMap.Systems[i].Asteroids.Count; j++)
                {
                    DataRow row = dataTable.Rows.Add();
                    row["Name"] = _GalaxyMap.Systems[i].Asteroids[j]._id;
                    row["Typ"] = "Asteroid";
                    row["Flugzeit"] = FlightTime.GetFlightTime(_ownerForm._CurSystemId, _GalaxyMap.Systems[i]._system_id, _GalaxyMap.Systems[i].Asteroids[j]._id, (int)TerranSpaceShip.ssRecycler, typeof(Asteroid));
                    row["Metall"] = _GalaxyMap.Systems[i].Asteroids[j].Resources._metalFields;
                    row["Kristall"] = _GalaxyMap.Systems[i].Asteroids[j].Resources._crystalFields;
                    row["Deuterium"] = _GalaxyMap.Systems[i].Asteroids[j].Resources._deutriFields;
                    row["object"] = _GalaxyMap.Systems[i].Asteroids[j];
                }

                progressBar.Value = i;
                Application.DoEvents();
            }
            pnlProgress.Visible = false;
            dataGrid.DataSource = dataTable;
            dataGrid.Columns["Object"].Visible = false;
            dataGrid.Sort(dataGrid.Columns[2], ListSortDirection.Ascending);
        }
        
        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Row index -1 is the header column, dont do anything here
            if (e.RowIndex == -1) return;

            Object target = dataGrid.Rows[e.RowIndex].Cells["object"].Value;

            Comet comet;
            Debris debris;
            string url = String.Empty;

            if (target.GetType() == typeof(Comet))
            {
                comet = (Comet)target;
                url = String.Format("http://u1.imperion.de/fleetBase/mission/1/planetId/c{0}/m/301", comet._Id);
            }
            else if (target.GetType() == typeof(Debris))
            {
                debris = (Debris)target;
                url = String.Format("http://u1.imperion.de/fleetBase/mission/1/planetId/d{0}/m/301", debris._planetId);
            }
            else if (target.GetType() == typeof(Asteroid))
            {
                debris = (Debris)target;
                url = String.Format("http://u1.imperion.de/fleetBase/mission/1/planetId/a{0}/m/301", debris._planetId);
            }

            _ownerForm.GetCurrentBrowser().Navigate(new Uri(url));
        }

        private void frmRecyclerTargets_Shown(object sender, EventArgs e)
        {
            InitDataGrid();
        }
        
    }
}

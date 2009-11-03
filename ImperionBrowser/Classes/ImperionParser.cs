﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Jayrock;
using System.IO;
using Jayrock.Json;

namespace ImperionBrowser
{
    class ImperionParser
    {
        private WebBrowser mBrowser;
        private int lengthOfSystem;

        public ImperionParser(WebBrowser iBrowser)
        {
            mBrowser = iBrowser;
        }
        
        public GalaxyMap TestMap()
        {
            StreamReader sr = new StreamReader("my_system.txt");
            StringBuilder sb = new StringBuilder(sr.ReadToEnd());

            GalaxyMap galaxyMap = json_parseMap(sb);


            int pcount = 0;
            int ccount = 0;
            int dcount = 0;
            int acount = 0;

            for (int i = 0; i < galaxyMap.Systems.Count; i++)
            {
                pcount += galaxyMap.Systems[i].Planets.Count;
                ccount += galaxyMap.Systems[i].Comets.Count;
                dcount += galaxyMap.Systems[i].Debris.Count;
                acount += galaxyMap.Systems[i].Asteroids.Count;
            }

            MessageBox.Show(String.Format("Es wurden {0} Systeme durchsucht: \r Es wurden {1} Planeten, {2} Kometen, {4} Asteroiden und {3} Trümmerfelder gefunden", galaxyMap.Systems.Count, pcount, ccount, dcount, acount));
            return galaxyMap;
        }

        private void json_AddDebrisToSystem(JsonTextReader jsonReader, GalaxySystem galaxySystem)
        {
            string text = jsonReader.Text;
            jsonReader.Read();
            Debris curDepris;
            
            while (jsonReader.Read() && jsonReader.TokenClass == JsonTokenClass.Member && jsonReader.Text.Length == lengthOfSystem + 2)
            {
                curDepris = new Debris();
                jsonReader.Read(); //Skip obj begin
                jsonReader.Read();
                curDepris._planetId = json_readMemberIntoString(jsonReader);
                curDepris.Resource._metalFields = json_readMemberIntoString(jsonReader);
                curDepris.Resource._crystalFields = json_readMemberIntoString(jsonReader);
                galaxySystem.Debris.Add(curDepris);
            }
        }

        private static void json_AddCometsToSystem(JsonTextReader jsonReader, GalaxySystem galaxySystem)
        {
            JsonTokenClass tc = jsonReader.TokenClass;
            Comet comet;

            //continue reader till array begins
            while (tc != JsonTokenClass.Array)
            {
                jsonReader.Read();
                tc = jsonReader.TokenClass;
            }

            while (tc != JsonTokenClass.EndArray)
            {

                try
                {
                    jsonReader.Read();
                    if (jsonReader.TokenClass != JsonTokenClass.Member)
                        jsonReader.Read();

                    comet = new Comet();
                    comet._Id = json_readMemberIntoString(jsonReader);
                    comet._styemId = galaxySystem._system_id;
                    comet.Resources._metalFields = json_readMemberIntoNumber(jsonReader).ToString();
                    comet.Resources._crystalFields = json_readMemberIntoNumber(jsonReader).ToString();
                    comet.Resources._deutriFields = json_readMemberIntoNumber(jsonReader).ToString();
                    
                    comet._Name = json_readMemberIntoString(jsonReader);
                    comet._highlight = json_readMemberIntoNumber(jsonReader) == 1;
                    galaxySystem.Comets.Add(comet);

                    jsonReader.Read();

                    tc = jsonReader.TokenClass;
                }
                catch
                {
                    MessageBox.Show("error:" + jsonReader.Text + " | line: " + jsonReader.LineNumber + " | pos: " + jsonReader.LinePosition);
                }
            }
            
        }

        private static Planet json_ParsePlanet(JsonTextReader jsonReader)
        {
            Planet curPlanet = new Planet();
            // read whole planet
            try
            {
                curPlanet._planet_id = json_readMemberIntoString(jsonReader);
                curPlanet._player_name = json_readMemberIntoString(jsonReader);
                curPlanet._alliance_name = json_readMemberIntoString(jsonReader);
                curPlanet._alliance_id = json_readMemberIntoString(jsonReader);
                curPlanet._user_id = json_readMemberIntoString(jsonReader);
                curPlanet._system_id = json_readMemberIntoString(jsonReader);
                curPlanet.SetPlanetType(json_readMemberIntoString(jsonReader));
                curPlanet._kind_id = json_readMemberIntoString(jsonReader);
                curPlanet._planet_name = json_readMemberIntoString(jsonReader);
                curPlanet._inhabitants = json_readMemberIntoString(jsonReader);
                curPlanet._alliance_status = json_readMemberIntoString(jsonReader);

                if (jsonReader.ReadMember() == "climate" && jsonReader.TokenClass != JsonTokenClass.Null)
                {
                    try
                    {
                        jsonReader.Read(); // skip object begin of climate object
                        curPlanet.Climate._solar = json_readMemberIntoNumber(jsonReader);
                        curPlanet.Climate._wind = json_readMemberIntoNumber(jsonReader);
                        curPlanet.Climate._water = json_readMemberIntoNumber(jsonReader);
                        curPlanet.Climate._thermal = json_readMemberIntoNumber(jsonReader);
                        jsonReader.Read(); //skip object end of cliamte object
                    }
                    catch
                    {
                        MessageBox.Show("error:" + jsonReader.Text + " | line: " + jsonReader.LineNumber + " | pos: " + jsonReader.LinePosition);
                    }
                }

                if (jsonReader.ReadMember() == "resources" && jsonReader.TokenClass != JsonTokenClass.Null)
                {
                    try
                    {
                        jsonReader.Read(); // skip object begin of resource object
                        curPlanet.Resources._metalFields = json_readMemberIntoString(jsonReader);
                        curPlanet.Resources._crystalFields = json_readMemberIntoString(jsonReader);
                        curPlanet.Resources._deutriFields = json_readMemberIntoString(jsonReader);
                        jsonReader.Read(); // skip object end of resource object
                    }
                    catch
                    {
                        MessageBox.Show("error:" + jsonReader.Text + " | line: " + jsonReader.LineNumber + " | pos: " + jsonReader.LinePosition);
                    }
                }

                if (jsonReader.ReadMember() == "reports")
                {
                    int depth = jsonReader.Depth;
                    Report report = null;
                    if (jsonReader.TokenClass != JsonTokenClass.Array)
                    {
                        while (jsonReader.TokenClass != JsonTokenClass.EndObject)
                        {
                            jsonReader.Read();
                            if (jsonReader.Text == "time")
                            {
                                report = new Report();
                                report._time = DateTime.Parse(json_readMemberIntoString(jsonReader));
                                report._planet_id_target = json_readMemberIntoString(jsonReader);
                                report._header_id = json_readMemberIntoString(jsonReader);
                                report._type = json_readMemberIntoString(jsonReader);
                                curPlanet.Reports.Add(report);
                                
                                jsonReader.Read(); //skip end object of report
                            }
                        }
                    } 
                }
            }
            catch
            {
                MessageBox.Show("error:" + jsonReader.Text + " | line: " + jsonReader.LineNumber + " | pos: " + jsonReader.LinePosition);
            }

            return curPlanet;

        }

        private static void json_ContinueToNextObject(JsonTextReader jsonReader)
        {
            int depth = jsonReader.Depth;
            string text;
            JsonTokenClass tc = jsonReader.TokenClass;
            while (tc != JsonTokenClass.EndObject && jsonReader.Depth != depth)
            {
                text = jsonReader.Text;
                jsonReader.Read();
                tc = jsonReader.TokenClass;
            }

            
        }

        private static string json_readMemberIntoString(JsonTextReader jsonReader)
        {
            jsonReader.ReadMember();
            if (jsonReader.TokenClass != JsonTokenClass.Null)
                return jsonReader.ReadString();
            else
                jsonReader.Read();

            return String.Empty;
        }

        private static int json_readMemberIntoNumber(JsonTextReader jsonReader)
        {
            try
            {
                jsonReader.ReadMember();
                if (jsonReader.TokenClass != JsonTokenClass.Null)
                    return jsonReader.ReadNumber().ToInt32();
                else
                    jsonReader.Read();
                
                return 0;
            }
            catch
            {
                jsonReader.Read();
                return 0;
            }
        }

        public void ShowRecyclerTargets(frmMain frmMain)
        {
            GalaxyMap galaxyMap = json_parseMap(json_getMapData());
            frmRecyclerTargets rt = new frmRecyclerTargets(galaxyMap, frmMain);
            rt.Show();
           
        }

        public void ShowRaidTargets(frmMain frmMain)
        {
            GalaxyMap galaxyMap = json_parseMap(json_getMapData());
            frmRaidTargets rt = new frmRaidTargets(galaxyMap, frmMain);
            rt.Show();
        }

        private StringBuilder json_getMapData()
        {
            string searchStr = "mapData = JSON.decode('";
            int posStart = mBrowser.DocumentText.LastIndexOf(searchStr) + searchStr.Length;
            int posEnd = mBrowser.DocumentText.IndexOf("');", posStart);

            StringBuilder jsonData = new StringBuilder(mBrowser.DocumentText.Substring(posStart, posEnd - posStart));

            return jsonData;
        }

        private GalaxyMap json_parseMap(StringBuilder jsonData)
        {
            JsonTextReader jsonReader = new JsonTextReader(new StringReader(jsonData.ToString()));
            GalaxyMap galaxyMap = new GalaxyMap();
            Planet curPlanet;
            int res; // temporary variable for integer testing
            string text; // temp text variable;
            lengthOfSystem = 0;
            while (jsonReader.Read())
            {
                text = jsonReader.Text;
                
                if (jsonReader.Depth == 1 && jsonReader.TokenClass == JsonTokenClass.Member && int.TryParse(text, out res)) //found new system, set length of system id
                {
                    lengthOfSystem = text.Length;
                }

                if (jsonReader.TokenClass == JsonTokenClass.Member && text.Length == lengthOfSystem && int.TryParse(text, out res)) //member is a new system
                {
                    galaxyMap.AddNewSystem(text);
                }

                if (text == "debris")
                {
                    json_AddDebrisToSystem(jsonReader, galaxyMap.Systems[galaxyMap.Systems.Count - 1]); //Add Debris to last found system
                }

                if (text == "comets")
                {
                    json_AddCometsToSystem(jsonReader, galaxyMap.Systems[galaxyMap.Systems.Count - 1]); //Add comets as Comet objects to the last found system
                }

                if (text == "asteroids")
                {
                    json_AddAsteroidsToSystem(jsonReader, galaxyMap.Systems[galaxyMap.Systems.Count - 1]); //Add Asteroids
                }

                if (text == "planet_id")
                {
                    curPlanet = json_ParsePlanet(jsonReader);
                    galaxyMap[curPlanet._system_id].Planets.Add(curPlanet);
                }

            }

            return galaxyMap;
        }

        private void json_AddAsteroidsToSystem(JsonTextReader jsonReader, GalaxySystem galaxySystem)
        {
            while (jsonReader.TokenClass != JsonTokenClass.EndArray)
            {
                jsonReader.Read();
                if (jsonReader.Text == "id")
                {
                    Asteroid asteroid = new Asteroid();
                    asteroid._id = json_readMemberIntoString(jsonReader);
                    asteroid._system_id = json_readMemberIntoString(jsonReader);
                    asteroid._user_id = json_readMemberIntoString(jsonReader);
                    asteroid._planet_id = json_readMemberIntoString(jsonReader);
                    asteroid._arrival = json_readMemberIntoString(jsonReader);
                    asteroid._disappearance = json_readMemberIntoString(jsonReader);
                    asteroid.Resources._metalFields = json_readMemberIntoNumber(jsonReader).ToString();
                    asteroid.Resources._crystalFields = json_readMemberIntoNumber(jsonReader).ToString();
                    asteroid.Resources._deutriFields = json_readMemberIntoNumber(jsonReader).ToString();

                    galaxySystem.Asteroids.Add(asteroid);
                }
            }
        }

        public static string json_extractFlightTime(string jsonData)
        {
            JsonTextReader jsonReader = new JsonTextReader(new StringReader(jsonData));

            while (jsonReader.Read())
            {
                if (jsonReader.Text == "duration")
                {
                    string text = json_readMemberIntoString(jsonReader);
                    return text;
                }
            }

            return "00:00:00";
        }

        public static string ParseFleetBaseAndGetResourceSum(HtmlDocument htmlDocument)
        {
            float sumMetal = 0;
            float sumCrystal = 0;
            float sumDeut = 0;
            
            HtmlElement divFleetBase = htmlDocument.GetElementById("fleetBase");
            HtmlElement divFleetSlots = divFleetBase.Children[0];

            HtmlElementCollection tableCells = divFleetBase.GetElementsByTagName("td");
            List<HtmlElement> ResourceTableCells = new List<HtmlElement>();

            if (tableCells.Count > 0)
            {
                foreach (HtmlElement cell in tableCells)
                {
                    if (cell.InnerText == "Rohstoffe")
                        ResourceTableCells.Add(cell.NextSibling);
                }
            }

            if (ResourceTableCells.Count > 0)
            {
                for (int i = 0; i < ResourceTableCells.Count; i++)
                {
                    sumMetal += float.Parse(ResourceTableCells[i].Children[0].GetElementsByTagName("li")[0].InnerText);
                    sumCrystal += float.Parse(ResourceTableCells[i].Children[0].GetElementsByTagName("li")[1].InnerText);
                    sumDeut += float.Parse(ResourceTableCells[i].Children[0].GetElementsByTagName("li")[2].InnerText);
                }
            }
            else
            {
                return "Es kommen momentan keine Resourcen zurück";
            }
            
            
            return String.Format("Es kommen insgesamt {0} Metall, {1} Kristall und {2} Deterium", sumMetal, sumCrystal, sumDeut);
        }

        public static string GetCurrentSystemId(HtmlDocument htmlDocument)
        {
            HtmlElement NavigationDiv = htmlDocument.GetElementById("navigation");
            string linkPlanet = NavigationDiv.Children[0].GetElementsByTagName("a")[0].GetAttribute("href");
            linkPlanet = linkPlanet.Replace("http://u1.imperion.de/planet/buildings/", "");

            //planet id is always systemid + number with leading zero. so if we cut the number, we have the system id :)
            return linkPlanet.Substring(0, linkPlanet.Length - 2); 
        }
    }
}
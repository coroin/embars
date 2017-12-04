//
// Copyright (C) 2011-2013, Coroin LLC <http://coroin.com>
//
// This file is part of EmBars.
//
// EmBars is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as
// published by the Free Software Foundation, either version 3 of
// the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// A copy of the GNU Lesser General Public License is included with
// this program.  See also <http://www.gnu.org/licenses/>.
//
using System;
using System.Drawing;
using System.Windows.Forms;
using NinjaTrader.Data;

namespace Coroin.EmBars
{
    partial class EmBars
    {
        /// fields
        static string configPath = NinjaTrader.Cbi.Core.UserDataDir + @"bin\Custom\";
        static NinjaTrader.Gui.Chart.ChartControl myChart = null;
        static Font tsbFont = new Font("Courier New", 9.00F);
        static string tsbName = "tsbEmBars";
        static string tsbText = "EmBars";
        static string tssName = "tssEmBars";
        int configBearContValue = 0, configBearInitValue = 0, configBullContValue = 0, configBullInitValue = 0;
        int configBearInitType = -1, configBullInitType = -1;
        int configBearRangeMax = 4, configBearRangeMin = 4, configBullRangeMax = 4, configBullRangeMin = 4;
        EmCloses configCloseOption = EmCloses.TickThru;
        bool configLoaded = false;
        EmOpens configOpenOption = EmOpens.TrueOpen;

        /// properties
        public EmCloses CloseOption { get { return configCloseOption; } }

        public string ConfigFile { get { return configFile; } }

        public string ConfigPath { get { return configPath; } }

        public EmOpens OpenOption { get { return configOpenOption; } }

        string configFile { get { return string.Format(@"EmBars-Config-{0}.xml", configId); } }

        int configId { get { return Period.Value; } }

        /// methods
        /// <summary>
        /// apply config from modal dialog
        /// </summary>
        void ApplyConfig(object sender, ResyncEventArgs e)
        {
            // ensure configId
            if (configId == e.ConfigId)
            {
                // update fields
                configBearContValue = e.BearContValue;
                configBearInitType = e.BearInitType;
                configBearInitValue = e.BearInitValue;
                configBearRangeMax = e.BearRangeMax;
                configBearRangeMin = e.BearRangeMin;
                configBullContValue = e.BullContValue;
                configBullInitType = e.BullInitType;
                configBullInitValue = e.BullInitValue;
                configBullRangeMax = e.BullRangeMax;
                configBullRangeMin = e.BullRangeMin;
                configCloseOption = e.CloseOption;
                configOpenOption = e.OpenOption;

                // reset calculations
                if (tickSize > 0)
                {
                    tickBearRangeMax = Math.Floor(10000000.0 * (double)e.BearRangeMax * tickSize) / 10000000.0;
                    tickBearRangeMin = Math.Floor(10000000.0 * (double)e.BearRangeMin * tickSize) / 10000000.0;
                    tickBullRangeMax = Math.Floor(10000000.0 * (double)e.BullRangeMax * tickSize) / 10000000.0;
                    tickBullRangeMin = Math.Floor(10000000.0 * (double)e.BullRangeMin * tickSize) / 10000000.0;
                }

                // set configLoaded
                configLoaded = true;
            }
            else
            { configLoaded = false; }
        }

        /// <summary>
        /// check for config loaded and load if needed
        /// </summary>
        void ConfigCheck()
        {
            if (configLoaded)
            { return; }

            ConfigLoad(ConfigPath, ConfigFile);
        }

        /// <summary>
        /// set fields to config from xml
        /// </summary>
        void ConfigLoad(string path, string file)
        {
            // load config from xml
            ConfigXml22 xml = new ConfigXml22(path, file);
            xml.Load();

            // set fields to xml values
            configBearContValue = xml.BearContValue;
            configBearInitType = xml.BearInitType;
            configBearInitValue = xml.BearInitValue;
            configBearRangeMax = xml.BearRangeMax;
            configBearRangeMin = xml.BearRangeMin;
            configBullContValue = xml.BullContValue;
            configBullInitType = xml.BullInitType;
            configBullInitValue = xml.BullInitValue;
            configBullRangeMax = xml.BullRangeMax;
            configBullRangeMin = xml.BullRangeMin;
            configCloseOption = (EmCloses)Enum.Parse(typeof(EmCloses), xml.CloseOption);
            configOpenOption = (EmOpens)Enum.Parse(typeof(EmOpens), xml.OpenOption);

            // calculate bear/bull min/max
            RangeInit();

            // update configLoaded
            configLoaded = true;
        }

        /// <summary>
        /// reset fields to default config
        /// </summary>
        void ConfigReset()
        {
            configBearContValue = configBullContValue = configBearInitValue = configBullInitValue = 0;
            configBearInitType = configBullInitType = 0;
            configBearRangeMax = configBearRangeMin = configBullRangeMax = configBullRangeMin = 4;
            configCloseOption = EmCloses.TickThru;
            configOpenOption = EmOpens.TrueOpen;
        }

        /// <summary>
        /// add chart control
        /// </summary>
        void ControlCheck(NinjaTrader.Gui.Chart.ChartControl chartControl)
        {
            // do not re-initialize
            if (myChart == chartControl)
            { return; }

            // NT toolstrip (do not try to rename tsrTool)
            ToolStrip ts = (ToolStrip)chartControl.Controls["tsrTool"];

            // tool strip separator
            if (!ts.Items.ContainsKey(tssName))
            {
                ToolStripSeparator tss = new ToolStripSeparator() { Name = tssName };
                ts.Items.Add(tss);
            }

            // tool strip button
            if (!ts.Items.ContainsKey(tsbName))
            {
                ToolStripButton tsb = new ToolStripButton(tsbText)
                {
                    Text = tsbText,
                    Name = tsbName,
                    Font = tsbFont,
                    Enabled = true,
                    ForeColor = Color.Black,
                };
                tsb.Click += ShowConfig;
                ts.Items.Add(tsb);
            }

            // set local variable
            myChart = chartControl;
        }

        /// <summary>
        /// show config modal dialog
        /// </summary>
        void ShowConfig(object sender, EventArgs e)
        {
            using (ConfigForm cf = new ConfigForm(configId))
            {
                cf.Resync += new ConfigForm.ResyncEventHandler(ApplyConfig);

                // open modal dialog
                if (cf.ShowDialog() == DialogResult.OK)
                { SendKeys.Send("(^+R)"); }
            }
        }
    }
}

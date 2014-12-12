//
// $Id$
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
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Coroin.EmBars
{
    /// <summary>
    /// EmBars Configuration Tool
    /// </summary>
    [Description("EmBars Configuration Tool")]
    public sealed partial class ConfigForm : Form
    {
        /// fields
        ConfigXml22 config;
        string configBase = @"# {0}";
        int configId = 1;
        string configPath = NinjaTrader.Cbi.Core.UserDataDir + @"bin\Custom\";
        bool statusMessageLink = false;

        /// <summary>
        /// default constructor
        /// </summary>
        public ConfigForm(int id)
        {
            // update fields
            configId = id;

            // create config object
            config = new ConfigXml22(configPath, configFile);

            // load components
            InitializeComponent();
            ComboBoxBind();

            // set modal name to version
            this.Text = BuildInfo.WindowTitle;
            this.helpBuild.Text = BuildInfo.Version;
            this.lblBuildMessage.Text = BuildInfo.Copyright;

            // reset form to config
            OnConfigReset();

            // set messages
            SetMessages();
        }

        /// nested types
        public delegate void ResyncEventHandler(object sender, ResyncEventArgs e);

        /// events
        public event ResyncEventHandler Resync;

        /// properties
        string configFile { get { return string.Format(@"EmBars-Config-{0}.xml", configId); } }

        /// methods

        /// <summary>
        /// click event handling method for apply button
        /// </summary>
        void btnApply_Click(object sender, EventArgs e)
        {
            // save current config
            OnConfigSave();

            // apply config to chart
            OnConfigApply();
        }

        /// <summary>
        /// click event handling method for cancel button
        /// </summary>
        void btnCancel_Click(object sender, EventArgs e)
        {
            OnConfigReset();
        }

        /// <summary>
        /// click event handling method for load button
        /// </summary>
        void btnOpen_Click(object sender, EventArgs e)
        {
            OnConfigLoad();
        }

        /// <summary>
        /// click event handling method for reset button
        /// </summary>
        void btnReset_Click(object sender, EventArgs e)
        {
            OnConfigReset();
        }

        /// <summary>
        /// click event handling method for save button
        /// </summary>
        void btnSave_Click(object sender, EventArgs e)
        {
            OnConfigSave();
        }

        /// <summary>
        /// click event handling method for save as button
        /// </summary>
        void btnSaveAs_Click(object sender, EventArgs e)
        {
            OnConfigSaveAs();
        }

        /// <summary>
        /// click event handling method for update message text
        /// </summary>
        void buildMessage_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://coroin.com/embars");
        }

        /// <summary>
        /// selected index changed handling method for close option
        /// </summary>
        void closeOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update config
            config.CloseOption = cboCloseOption.SelectedValue.ToString();

            // flag apply and save buttons
            OnApplySaveNeeded(true);
        }

        /// <summary>
        /// bind combo boxes to enums
        /// </summary>
        void ComboBoxBind()
        {
            cboCloseOption.DataSource = System.Enum.GetValues(typeof(EmCloses));
            cboOpenOption.DataSource = System.Enum.GetValues(typeof(EmOpens));
        }

        /// <summary>
        /// set config label
        /// </summary>
        void ConfigLabel()
        {
            lblConfig.Text = string.Format(configBase, configId);
        }

        /// <summary>
        /// set form values from xml
        /// </summary>
        void FormApplyXml(ConfigXml22 xml)
        {
            // flag isLoading
            isLoading = true;

            // set form values from config
            bearContValue.Value = (decimal)EmMath.RangeValidate(xml.BearContValue, 100, -100);
            bearInitValue.Value = (decimal)EmMath.RangeValidate(xml.BearInitValue, 100, -100);
            bearRangeMax.Value = Math.Max(1, (int)xml.BearRangeMax);
            bearRangeMin.Value = Math.Max(1, (int)xml.BearRangeMin);
            switch (xml.BearInitType)
            {
                case 1:

                    // range max
                    bearInitMax.Checked = true;
                    bearInitMin.Checked = bearInitPrev.Checked = false;
                    break;

                case -1:

                    // range min
                    bearInitMin.Checked = true;
                    bearInitMax.Checked = bearInitPrev.Checked = false;
                    break;

                case 0:
                default:

                    // prev range
                    bearInitPrev.Checked = true;
                    bearInitMin.Checked = bearInitMax.Checked = false;
                    break;
            }
            bullContValue.Value = (decimal)EmMath.RangeValidate(xml.BullContValue, 100, -100);
            bullInitValue.Value = (decimal)EmMath.RangeValidate(xml.BullInitValue, 100, -100);
            bullRangeMax.Value = Math.Max(1, (int)xml.BullRangeMax);
            bullRangeMin.Value = Math.Max(1, (int)xml.BullRangeMin);
            switch (xml.BullInitType)
            {
                case 1:

                    // range max
                    bullInitMax.Checked = true;
                    bullInitMin.Checked = bullInitPrev.Checked = false;
                    break;

                case -1:

                    // range min
                    bullInitMin.Checked = true;
                    bullInitMax.Checked = bullInitPrev.Checked = false;
                    break;

                case 0:
                default:

                    // prev range
                    bullInitPrev.Checked = true;
                    bullInitMin.Checked = bullInitMax.Checked = false;
                    break;
            }
            cboCloseOption.SelectedItem = (EmCloses)cboCloseOption.FindString(xml.CloseOption);
            cboOpenOption.SelectedItem = (EmOpens)cboOpenOption.FindString(xml.OpenOption);

            // reset isLoading
            isLoading = false;
        }

        /// <summary>
        /// update apply button
        /// </summary>
        void OnApplyNeeded(bool needed)
        {
            btnApply.ForeColor = (needed) ? Color.DarkRed : SystemColors.ControlText;
        }

        /// <summary>
        /// update apply and save buttons
        /// </summary>
        void OnApplySaveNeeded(bool needed)
        {
            OnApplyNeeded(needed);
            OnSaveNeeded(needed);
        }

        /// <summary>
        /// apply config to chart
        /// </summary>
        void OnConfigApply()
        {
            OnConfigResync();
        }

        /// <summary>
        /// loads config from file, apply to form, sync chart, reload chart
        /// </summary>
        void OnConfigLoad()
        {
            // update status message
            StatusMessage("Loading ...", Color.DarkRed);

            // set initial directory
            dialogOpen.InitialDirectory = configPath;

            // return if no file selected
            if (dialogOpen.ShowDialog() != DialogResult.OK)
            {
                // reset status message
                StatusMessageReady();

                // return
                return;
            }

            try
            {
                // get file from dialog
                string filename = dialogOpen.FileName;
                string path = Path.GetDirectoryName(filename) + @"\";
                string file = Path.GetFileName(filename);

                // get new xml object
                ConfigXml22 xml = new ConfigXml22(path, file);

                // load config from xml
                xml.Load();

                // set form values from xml
                FormApplyXml(xml);

                // update status message
                StatusMessage(string.Concat("Loaded ", file), Color.DarkRed);

                // flag apply button
                OnApplyNeeded(true);

                // flag save button
                OnSaveNeeded(true);
            }
            catch (Exception)
            {
                // error handling
                StatusMessage("Error! Please click [apply].", Color.DarkRed);
            }
        }

        /// <summary>
        /// reset form to config
        /// </summary>
        void OnConfigReset()
        {
            // load config from xml
            config.Load();

            // set form values from xml
            FormApplyXml(config);

            // flag apply button
            OnApplyNeeded(false);

            // flag save button
            OnSaveNeeded(false);
        }

        /// <summary>
        /// event raising method calls Resync delegate
        /// </summary>
        void OnConfigResync()
        {
            if (Resync != null)
            {
                Resync(this, new ResyncEventArgs(
                    configId,
                    (int)bearContValue.Value,
                    (bearInitMax.Checked ? 1 : bearInitMin.Checked ? -1 : 0),
                    (int)bearInitValue.Value,
                    (int)bearRangeMax.Value,
                    (int)bearRangeMin.Value,
                    (int)bullContValue.Value,
                    (bullInitMax.Checked ? 1 : bullInitMin.Checked ? -1 : 0),
                    (int)bullInitValue.Value,
                    (int)bullRangeMax.Value,
                    (int)bullRangeMin.Value,
                    (EmCloses)cboCloseOption.FindString(cboCloseOption.SelectedText),
                    (EmOpens)cboOpenOption.FindString(cboOpenOption.SelectedText))
                    );
            }
        }

        /// <summary>
        /// save form to config
        /// </summary>
        void OnConfigSave()
        {
            // set config values from form
            XmlApplyForm(ref config);

            // save config to config xml file
            XmlSave(ref config);
        }

        /// <summary>
        /// save config to xml in specified path/file
        /// </summary>
        void OnConfigSaveAs()
        {
            // update status message
            StatusMessage("Saving ...", Color.DarkRed);

            // return if user cancels
            if (ctlSaveFileDialog.ShowDialog() != DialogResult.OK)
            {
                // reset status message
                StatusMessageReady();

                // return
                return;
            }

            // ensure file specified
            if (ctlSaveFileDialog.FileName != string.Empty)
            {
                try
                {
                    // get file from dialog
                    string filename = ctlSaveFileDialog.FileName;
                    string file = Path.GetFileName(filename);
                    string path = Path.GetDirectoryName(filename) + @"\";

                    // get new xml object
                    ConfigXml22 xml = new ConfigXml22(path, file);

                    // set xml values from form
                    XmlApplyForm(ref xml);

                    // save config to specified xml file
                    XmlSave(ref xml);

                    // update status message
                    StatusMessage(string.Concat("Saved as ", file), Color.DarkGreen);
                }
                catch (Exception)
                {
                    // error handling
                    StatusMessage("Error! Please click [apply].", Color.DarkRed);
                }
            }
        }

        /// <summary>
        /// update save button
        /// </summary>
        void OnSaveNeeded(bool needed)
        {
            btnSave.ForeColor = (needed) ? Color.DarkRed : SystemColors.ControlText;
        }

        /// <summary>
        /// selected index changed handling method for open option
        /// </summary>
        void openOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update config
            config.OpenOption = cboOpenOption.SelectedValue.ToString();

            // flag apply and save buttons
            OnApplySaveNeeded(true);
        }

        /// <summary>
        /// set messages and labels
        /// </summary>
        void SetMessages()
        {
            // set status message
            StatusMessageReady();

            // set config label
            ConfigLabel();
        }

        /// <summary>
        /// update status message
        /// </summary>
        /// <param name="msg">message text</param>
        /// <param name="color">message color</param>
        void StatusMessage(string msg, Color color)
        {
            lblStatusMessage.Text = msg;
            lblStatusMessage.ForeColor = color;
        }

        /// <summary>
        /// update status message to ready and echo config file
        /// </summary>
        void StatusMessageReady()
        {
            StatusMessage(string.Concat("Using ", configFile), Color.DarkGreen);
        }

        /// <summary>
        /// set xml values from form
        /// </summary>
        void XmlApplyForm(ref ConfigXml22 xml)
        {
            // set xml values from form
            xml.BearContValue = (int)bearContValue.Value;
            xml.BearInitType = bearInitMax.Checked ? 1 : bearInitPrev.Checked ? 0 : -1;
            xml.BearInitValue = (int)bearInitValue.Value;
            xml.BearRangeMax = (int)bearRangeMax.Value;
            xml.BearRangeMin = (int)bearRangeMin.Value;
            xml.BullContValue = (int)bullContValue.Value;
            xml.BullInitType = bullInitMax.Checked ? 1 : bullInitPrev.Checked ? 0 : -1;
            xml.BullInitValue = (int)bullInitValue.Value;
            xml.BullRangeMax = (int)bullRangeMax.Value;
            xml.BullRangeMin = (int)bullRangeMin.Value;
            xml.CloseOption = cboCloseOption.SelectedItem.ToString();
            xml.OpenOption = cboOpenOption.SelectedItem.ToString();
        }

        /// <summary>
        /// save config to specified xml file
        /// </summary>
        void XmlSave(ref ConfigXml22 xml)
        {
            // do not fire while loading
            if (isLoading) { return; }

            // save xml
            xml.Save();

            // flag save button
            OnSaveNeeded(false);
        }
    }
}
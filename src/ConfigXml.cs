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
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Coroin.EmBars
{
    /// <summary>
    /// EmBars ConfigXml
    /// </summary>
    [Description("EmBars Config XML - v2.2")]
    [Serializable]
    public sealed class ConfigXml22
    {
        /// fields
        static string configNamespace = "http://schemas.coroin.com/embars2";
        static string configPrefix = "em2";
        static string configRoot = "EmBars";
        string configFile = @"EmBars-Config-1.xml";
        string configPath = NinjaTrader.Cbi.Core.UserDataDir + @"bin\Custom\";

        /// constructors
        /// <summary>
        /// default constructor using defaults for file and path
        /// </summary>
        public ConfigXml22()
            : this(null, null)
        {
        }

        /// <summary>
        /// instance constructor using specified file and default path
        /// </summary>
        public ConfigXml22(string file)
            : this(null, file)
        {
        }

        /// <summary>
        /// instance constructor using specified file and path
        /// </summary>
        public ConfigXml22(string path, string file)
        {
            if (path != null)
            { this.configPath = path; }

            if (file != null)
            { this.configFile = file; }
        }

        /// properties
        public int BearContValue { get; set; }

        public int BearInitType { get; set; }

        public int BearInitValue { get; set; }

        public int BearRangeMax { get; set; }

        public int BearRangeMin { get; set; }

        public int BullContValue { get; set; }

        public int BullInitType { get; set; }

        public int BullInitValue { get; set; }

        public int BullRangeMax { get; set; }

        public int BullRangeMin { get; set; }

        public string CloseOption { get; set; }

        public string OpenOption { get; set; }

        /// methods
        /// <summary>
        /// ensure config file exists and load xml
        /// </summary>
        public void Load()
        {
            // initialize or load file
            if (!Exists(configPath + configFile))
            { XmlReset(); }
            else
            { XmlLoad(); }
        }

        /// <summary>
        /// reset config to default
        /// </summary>
        public void Reset()
        { XmlReset(); }

        /// <summary>
        /// save config to xml
        /// </summary>
        public void Save()
        { XmlSave(); }

        /// <summary>
        /// ensure config file exists
        /// </summary>
        bool Exists(string path)
        {
            FileInfo fi = new FileInfo(path);
            bool exists = (fi.Exists) ? true : false;
            return exists;
        }

        /// <summary>
        /// get config from xml
        /// </summary>
        void XmlLoad()
        {
            // initialize objects
            XmlSerializer xs;
            FileStream fs = null;

            // load from file
            try
            {
                // set namespace
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(configPrefix, configNamespace);

                // set root attribute
                XmlRootAttribute ra = new XmlRootAttribute(configRoot);
                XmlAttributes xa = new XmlAttributes();
                xa.XmlRoot = ra;

                // add overrides
                XmlAttributeOverrides xo = new XmlAttributeOverrides();
                xo.Add(typeof(ConfigXml22), xa);

                // open serializer
                xs = new XmlSerializer(typeof(ConfigXml22), xo);

                // file info object
                FileInfo fi = new FileInfo(configPath + configFile);

                // if the config file exists, open it.
                if (fi.Exists)
                {
                    fs = fi.OpenRead();
                    ConfigXml22 xml = (ConfigXml22)xs.Deserialize(fs);

                    // update properties
                    BearContValue = xml.BearContValue;
                    BearInitType = xml.BearInitType;
                    BearInitValue = xml.BearInitValue;
                    BearRangeMax = xml.BearRangeMax;
                    BearRangeMin = xml.BearRangeMin;
                    BullContValue = xml.BullContValue;
                    BullInitType = xml.BullInitType;
                    BullInitValue = xml.BullInitValue;
                    BullRangeMax = xml.BullRangeMax;
                    BullRangeMin = xml.BullRangeMin;
                    CloseOption = xml.CloseOption;
                    OpenOption = xml.OpenOption;
                }
            }
            finally
            {
                // ensure object is released
                if (fs != null)
                { fs.Close(); }
            }
        }

        /// <summary>
        /// reset config to default
        /// </summary>
        void XmlReset()
        {
            // default values
            BearContValue = BullContValue = 0;
            BearInitType = BearInitValue = BullInitType = BullInitValue = 0;
            BearRangeMax = BearRangeMin = BullRangeMax = BullRangeMin = 4;
            CloseOption = EmCloses.TickThru.ToString();
            OpenOption = EmOpens.TrueOpen.ToString();

            // change for custom Init implementation
            XmlSave();
        }

        /// <summary>
        /// save config to xml
        /// </summary>
        void XmlSave()
        {
            // initialize objects
            StreamWriter sw = null;
            XmlSerializer xs;

            // write to file
            try
            {
                // set namespace
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(configPrefix, configNamespace);

                // set root attribute
                XmlRootAttribute ra = new XmlRootAttribute(configRoot);
                XmlAttributes xa = new XmlAttributes();
                xa.XmlRoot = ra;

                // add overrides
                XmlAttributeOverrides xo = new XmlAttributeOverrides();
                xo.Add(typeof(ConfigXml22), xa);

                // write to file
                xs = new XmlSerializer(typeof(ConfigXml22), xo);
                sw = new StreamWriter(configPath + configFile, false);
                xs.Serialize(sw, this, ns);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            {
                // ensure object is released
                if (sw != null)
                { sw.Close(); }
            }
        }
    }
}
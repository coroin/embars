//
// $Id$
// Copyright (C) 2008-2013, Coroin LLC <http://coroin.com>
//
using System;
using System.ComponentModel;

namespace Coroin.EmBars
{
    [Description("EmBars Config XML - v2.1")]
    [Serializable]
    public sealed class ConfigXml
    {
        #region Fields

        string configFile;
        string configPath;

        #endregion Fields

        #region Methods

        /// <summary>
        /// default constructor
        /// </summary>
        public ConfigXml()
        {
            configPath = NinjaTrader.Cbi.Core.UserDataDir + @"bin\Custom\";
            configFile = @"EmBars-Config-1.xml";
        }

        /// <summary>
        /// instance constructor
        /// </summary>
        /// <param name="path"></param>
        /// <param name="file"></param>
        public ConfigXml(string path, string file)
        {
            // set fields
            configPath = path;
            configFile = file;
        }

        #endregion Methods

        #region Properties

        public string CloseOption { get; set; }

        public string OpenOption { get; set; }

        public int RangeMax { get; set; }

        public int RangeMin { get; set; }

        public string RangeOption { get; set; }

        #endregion Properties
    }

    [Description("EmBars Config Xml - v2.0")]
    [Serializable]
    public sealed class EmBarsXML
    {
        #region Fields

        string configFile;
        string configPath;

        #endregion Fields

        #region Methods

        /// <summary>
        /// default constructor
        /// </summary>
        public EmBarsXML()
        {
            configPath = NinjaTrader.Cbi.Core.UserDataDir + @"bin\Custom\";
            configFile = @"EmBars-Config-1.xml";
        }

        /// <summary>
        /// instance constructor
        /// </summary>
        /// <param name="path"></param>
        /// <param name="file"></param>
        public EmBarsXML(string path, string file)
        {
            // set fields
            configPath = path;
            configFile = file;
        }

        #endregion Methods

        #region Properties

        public string CloseOption { get; set; }

        public string OpenOption { get; set; }

        public int RangeMax { get; set; }

        public int RangeMin { get; set; }

        #endregion Properties
    }
}
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

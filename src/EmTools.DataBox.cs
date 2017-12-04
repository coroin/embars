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
using System.Drawing;
using System.Xml.Serialization;
using NinjaTrader.Data;

namespace Coroin.EmBars
{
    partial class EmBarsTools
    {
        /// fields
        bool dataBox = true;
        Color dataBoxBackColor = Color.Transparent;
        Color dataBoxBorderColor = Color.SlateGray;
        Color dataBoxFontColor = Color.SlateGray;
        int dataBoxFontSize = 9;
        FontStyle dataBoxFontStyle = FontStyle.Regular;
        int dataBoxOpacity = 7;
        TextPosition dataBoxPosition = TextPosition.TopLeft;

        /// properties
        [Description("Enable or Disable data box which displays EmBars config settings on the chart. Note: DataBox only works on EmBars charts.")]
        [GridCategory("\t\tData Box")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("\tData Box")]
        public EmEnableDisable DataBox
        {
            get { return dataBox == true ? EmEnableDisable.Enable : EmEnableDisable.Disable; }
            set { dataBox = value == EmEnableDisable.Enable ? true : false; }
        }

        [XmlIgnore()]
        [Description("Select data box background color.")]
        [GridCategory("\t\tData Box")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Background Color")]
        public Color DataBoxBackColor
        {
            get { return dataBoxBackColor; }
            set { dataBoxBackColor = value; }
        }

        [Browsable(false)]
        public string DataBoxBackColor_Serialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(dataBoxBackColor); }
            set { dataBoxBackColor = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        [XmlIgnore()]
        [Description("Select data box outline color.")]
        [GridCategory("\t\tData Box")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Border Color")]
        public Color DataBoxBorderColor
        {
            get { return dataBoxBorderColor; }
            set { dataBoxBorderColor = value; }
        }

        [XmlIgnore()]
        [Description("Font Color is the color for the Data Box text.")]
        [GridCategory("\t\tData Box")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Font Color")]
        public Color DataBoxFontColor
        {
            get { return dataBoxFontColor; }
            set { dataBoxFontColor = value; }
        }

        [Browsable(false)]
        public string DataBoxFontColor_Serialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(dataBoxFontColor); }
            set { dataBoxFontColor = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        [Description("Font Size for the Data Box text is the point size ranging from 9 - 48.")]
        [GridCategory("\t\tData Box")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Font Size")]
        public int DataBoxFontSize
        {
            get { return dataBoxFontSize; }
            set { dataBoxFontSize = Math.Min(Math.Max(9, value), 48); }
        }

        [Description("Enter data box dataBoxOpacity. This value may be adjusted between one and ten.")]
        [GridCategory("\t\tData Box")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Opacity")]
        public int DataBoxOpacity
        {
            get { return dataBoxOpacity; }
            set { dataBoxOpacity = Math.Min(Math.Max(1, value), 10); }
        }

        [Browsable(false)]
        public string DataBoxOutlineColor_Serialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(dataBoxBorderColor); }
            set { dataBoxBorderColor = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        [Description("Select data box position on the screen.")]
        [GridCategory("\t\tData Box")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("\tPosition")]
        public TextPosition DataBoxPosition
        {
            get { return dataBoxPosition; }
            set { dataBoxPosition = value; }
        }

        [Description("Font Style for the Data Box text can be Regular, Bold, Italic, Underline, and Strikeout.")]
        [GridCategory("\t\tData Box")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Font Style")]
        public FontStyle DatBoxFontStyle
        {
            get { return dataBoxFontStyle; }
            set { dataBoxFontStyle = value; }
        }

        /// methods
        /// <summary>
        /// sets data-box values
        /// </summary>
        void DataBoxInit()
        {
            // only fire for EmBars
            dataBox = (Bars.BarsType.DisplayName.Contains("EmBars")) ? true : false;

            if (dataBox)
            {
                // local variables
                int configId = BarsPeriod.Value;
                string file = string.Format(@"EmBars-Config-{0}.xml", configId);
                string path = NinjaTrader.Cbi.Core.UserDataDir + @"bin\Custom\";
                Font font = new Font("Courier New", dataBoxFontSize, dataBoxFontStyle);

                // load config from xml
                ConfigXml22 xml = new ConfigXml22(path, file);
                xml.Load();

                // set fields to xml values
                int emBearContValue = xml.BearContValue;
                int emBearInitType = xml.BearInitType;
                int emBearInitValue = xml.BearInitValue;
                int emBearRangeMax = xml.BearRangeMax;
                int emBearRangeMin = xml.BearRangeMin;
                int emBullContValue = xml.BullContValue;
                int emBullInitType = xml.BullInitType;
                int emBullInitValue = xml.BullInitValue;
                int emBullRangeMax = xml.BullRangeMax;
                int emBullRangeMin = xml.BullRangeMin;
                string emCloseOption = xml.CloseOption;
                string emOpenOption = xml.OpenOption;

                // build rows
                string dbmMin = string.Format("Min     {0}{1} |  {2}{3}", emBullRangeMin, (emBullInitType == -1) ? "*" : " ", emBearRangeMin, (emBearInitType == -1) ? "*" : "");
                string dbmMax = string.Format("Max     {0}{1} |  {2}{3}", emBullRangeMax, (emBullInitType == 1) ? "*" : " ", emBearRangeMax, (emBearInitType == 1) ? "*" : "");
                string dbmInit = string.Format("Init   {0}{1}{2} | {3}{4}{5}", (emBullInitValue >= 0) ? " " : "", emBullInitValue, (emBullInitType == 0) ? "*" : " ", (emBearInitValue >= 0) ? " " : "", emBearInitValue, (emBearInitType == 0) ? "*" : "");
                string dbmCont = string.Format("Cont   {0}{1}  | {2}{3}", (emBullContValue >= 0) ? " " : "", emBullContValue, (emBearContValue >= 0) ? " " : "", emBearContValue);

                // build message box string
                dataBoxMsg = string.Format("EmBars {0}\r\nConfig  #{1}\r\n{2}\r\n{3}\r\n{4}\r\n{5}\r\nOpen    {6}\r\nClose   {7}", Bars.Instrument.FullName, configId.ToString(), dbmMin, dbmMax, dbmInit, dbmCont, emOpenOption, emCloseOption);

                // draw text-box
                DrawTextFixed("EmBarsDataBox", dataBoxMsg, dataBoxPosition, dataBoxFontColor, font, dataBoxBorderColor, dataBoxBackColor, dataBoxOpacity);

                // flag data-box loaded
                dataBoxLoaded = true;
            }
        }
    }
}

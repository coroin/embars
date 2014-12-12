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
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using Coroin.EmBars;
using NinjaTrader.Cbi;
using NinjaTrader.Data;
using NinjaTrader.Gui.Chart;

namespace NinjaTrader.Indicator
{
    /// <summary>
    /// EmSamples - custom indicator for EmBars with code samples for advanced developers.
    /// </summary>
    [Description("EmSamples - custom indicator for EmBars with code samples for advanced developers.")]
    public class EmSamples : Indicator
    {
        /// fields
        int barId;
        Color bearColor = Color.Crimson;
        Color bullColor = Color.SteelBlue;
        EmSamplesDisplayType displayType = EmSamplesDisplayType.Plots;
        bool invalid;
        int offset;
        IEmProps props = null;
        bool showDebug = false;

        /// methods
        protected override void Initialize()
        {
            Add(new Plot(bearColor, "Bear Close"));
            Add(new Plot(bullColor, "Bull Close"));
            ClearOutputWindow();
            Overlay = true;
            PriceTypeSupported = false;
            CalculateOnBarClose = false;
        }

        protected override void OnBarUpdate()
        {
            /// ensure bar has EmProps
            if (props is IEmProps)
            {
                /// only fire once per bar
                if (barId == CurrentBar)
                { return; }

                /// get EmProps for the specified bar, matching on OHLCVT
                EmProps barProps = props.GetEmProps(Open[0], High[0], Low[0], Close[0], (long)Volume[0], Time[0]) as EmProps;

                /// ensure EmProps exist for given bar (note: some historical data may not be available)
                if (barProps == null)
                { return; }

                /// add debug to output window
                if (showDebug)
                { Print(string.Format("Bar {0} => {1}", CurrentBar, barProps)); }

                /// update barId so this only fires once per bar
                barId = CurrentBar;

                /// assign local variables from current bar EmProps and offset
                double bear = Instrument.MasterInstrument.Round2TickSize(barProps.BearClose - TickSize * Offset);
                double bull = Instrument.MasterInstrument.Round2TickSize(barProps.BullClose + TickSize * Offset);

                /// draw objects based on DisplayType
                switch (DisplayType)
                {
                    case EmSamplesDisplayType.Lines:
                        {
                            DrawLine(CurrentBar + "_BearClose", true, 0, bear, -1, bear, bearColor, DashStyle.Dash, 2);
                            DrawLine(CurrentBar + "_BullClose", true, 0, bull, -1, bull, bullColor, DashStyle.Dash, 2);
                        }
                        break;


                    case EmSamplesDisplayType.Plots:
                    default:
                        {
                            BearClose.Set(bear);
                            BullClose.Set(bull);
                        }
                        break;
                }
            }
            else
            {
                /// generate log message one time
                if (!invalid)
                {
                    Log(String.Format("{0} does not implement interface IEmProps", Bars.BarsType.ToString()), LogLevel.Warning);
                    invalid = true;
                }
            }
        }

        protected override void OnStartUp()
        { props = Bars.BarsType as IEmProps; }

        public override string ToString()
        { return string.Format("EmSamples{0}", showDebug ? "(Debug)" : ""); }

        /// properties
        [Browsable(false)]
        [XmlIgnore()]
        public DataSeries BearClose
        { get { return Values[0]; } }

        [Browsable(false)]
        [XmlIgnore()]
        public DataSeries BullClose
        { get { return Values[1]; } }

        [Description("DisplayType (Lines or Plots)")]
        [GridCategory("Parameters")]
        public EmSamplesDisplayType DisplayType
        {
            get { return displayType; }
            set { displayType = value; }
        }

        [Description("Display Offset (in ticks)")]
        [GridCategory("Parameters")]
        public int Offset
        {
            get { return offset; }
            set { offset = Math.Max(0, value); }
        }

        [Description("Show Debug info in Output Window")]
        [GridCategory("Parameters")]
        public EmSamplesOnOff ShowDebug
        {
            get { return showDebug ? EmSamplesOnOff.On : EmSamplesOnOff.Off; }
            set { showDebug = value == EmSamplesOnOff.On ? true : false; }
        }
    }
}
public enum EmSamplesDisplayType { Lines, Plots }
public enum EmSamplesOnOff { On, Off, }

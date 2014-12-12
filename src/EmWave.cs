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
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Data;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Indicator;

namespace Coroin.EmBars
{
    /// <summary>
    /// EmWave - custom indicator for EmBars
    /// </summary>
    [Description("EmWave - custom indicator for EmBars")]
    public class EmWave : IndicatorBase
    {
        /// fields
        Color errorColor = Color.Transparent;
        bool invalid;
        IEmProps props = null;
        int smooth = 14;
        Color surgeColor = Color.LightSeaGreen;
        Color tideAvgColor = Color.MediumSeaGreen;
        Color tideColor = Color.DarkSeaGreen;

        [Browsable(false)]
        [XmlIgnore()]
        public DataSeries ErrorCount
        { get { return Values[3]; } }

        [Browsable(false)]
        [XmlIgnore()]
        public DataSeries ErrorVolume
        { get { return Values[4]; } }

        [Description("Number of bars for smoothing")]
        [Category("Parameters")]
        public int Smooth
        {
            get { return smooth; }
            set { smooth = Math.Max(1, value); }
        }

        [Browsable(false)]
        [XmlIgnore()]
        public DataSeries Surge
        { get { return Values[0]; } }

        [Browsable(false)]
        [XmlIgnore()]
        public DataSeries Tide
        { get { return Values[1]; } }

        [Browsable(false)]
        [XmlIgnore()]
        public DataSeries TideAvg
        { get { return Values[2]; } }

        /// <summary>
        /// This method is used to configure the indicator and is called once before any bar data is loaded.
        /// </summary>
        protected override void Initialize()
        {
            Add(new Plot(new Pen(surgeColor, 2), "Surge"));
            Add(new Plot(tideColor, "Tide"));
            Add(new Plot(tideAvgColor, "Tide Avg"));
            Add(new Plot(errorColor, "Error Count"));
            Add(new Plot(errorColor, "Error Volume"));
            Plots[0].Pen.DashStyle = DashStyle.Dash;
            Add(new Line(Color.DarkGray, 0, "Zero line"));
            CalculateOnBarClose = false;
            DisplayInDataBox = true;
            PlotsConfigurable = true;
        }

        /// <summary>
        /// Called on each bar update event (incoming tick)
        /// </summary>
        protected override void OnBarUpdate()
        {
            /// ensure bar has EmProps
            if (props is IEmProps)
            {
                /// get EmProps for the specified bar, matching on OHLCVT
                EmProps barProps = props.GetEmProps(Open[0], High[0], Low[0], Close[0], (long)Volume[0], Time[0]) as EmProps;

                /// ensure EmProps exist for given bar (note: some historical data may not be available)
                if (barProps == null)
                { return; }

                /// update plots
                Surge.Set(barProps.Surge);
                Tide.Set(barProps.Tide);
                ErrorCount.Set(barProps.ErrorCount);
                ErrorVolume.Set(barProps.ErrorVolume);

                /// update average
                TideAvg.Set(EmMath.EMA((double)barProps.Tide, CurrentBar, smooth, CurrentBar == 0 ? Tide[0] : TideAvg[1]));
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

        /// <summary>
        /// Set any variables or logic you wish to do only once at start of your indicator/strategy
        /// </summary>
        protected override void OnStartUp()
        { props = Bars.BarsType as IEmProps; }
    }
}
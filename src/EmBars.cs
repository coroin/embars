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
using NinjaTrader.Data;

namespace Coroin.EmBars
{
    [Description("EmBars is a uniquely customizable next-generation range bar with extensive user configuration options to specify bullish and bearish momentum using fixed or dynamic ranges (defined as open-close, not high-low as in traditional range bars) with different open/close candle options, trend initiation types, and continuation/initiation intervals. Get the latest version of EmBars online at <http://embars.com>. Copyright (C) 2011-2013 Coroin LLC <http://coroin.com>.")]
    public partial class EmBars : BarsType
    {
        /// fields
        static bool registered = Register(new EmBars());
        string displayName = "EmBars";

        /// methods
        /// <summary>
        /// built from period type
        /// </summary>
        public override PeriodType BuiltFrom
        { get { return PeriodType.Tick; } }

        /// <summary>
        /// default value
        /// </summary>
        public override int DefaultValue
        { get { return 1; } }

        /// <summary>
        /// display name used for chart display
        /// </summary>
        public override string DisplayName
        { get { return displayName; } }

        /// <summary>
        /// intraday data
        /// </summary>
        public override bool IsIntraday
        { get { return true; } }

        /// <summary>
        /// add new tick data to bars
        /// </summary>
        public override void Add(Bars bars, double open, double high, double low, double close, DateTime time, long volume, bool isRealtime)
        { OnTick(bars, open, high, low, close, time, volume, isRealtime); }

        /// <summary>
        /// apply default values to the base period type
        /// </summary>
        public override void ApplyDefaults(NinjaTrader.Gui.Chart.BarsData barsData)
        {
            // set default config
            barsData.Period.Value = 1;

            // ensure config loaded
            ConfigCheck();

            // days back default
            barsData.DaysBack = 10;
        }

        /// <summary>
        /// chart data box date
        /// </summary>
        public override string ChartDataBoxDate(DateTime time)
        { return time.ToString(NinjaTrader.Cbi.Globals.CurrentCulture.DateTimeFormat.ShortDatePattern); }

        /// <summary>
        /// chart label
        /// </summary>
        public override string ChartLabel(NinjaTrader.Gui.Chart.ChartControl chartControl, DateTime time)
        {
            ControlCheck(chartControl);
            return time.ToString(chartControl.LabelFormatTick, NinjaTrader.Cbi.Globals.CurrentCulture);
        }

        /// <summary>
        /// clone object
        /// </summary>
        public override object Clone()
        { return new EmBars(); }

        /// <summary>
        /// get initial look back days to load into chart
        /// </summary>
        public override int GetInitialLookBackDays(Period period, int barsBack)
        { return new EmBars().GetInitialLookBackDays(period, barsBack); }

        /// <summary>
        /// get percent complete
        /// </summary>
        public override double GetPercentComplete(Bars bars, DateTime now)
        { throw new ApplicationException("GetPercentComplete not supported in " + DisplayName); }

        /// <summary>
        /// property descriptor collection - add / remove additional properties
        /// </summary>
        public override PropertyDescriptorCollection GetProperties(PropertyDescriptor propertyDescriptor, Period period, Attribute[] attributes)
        {
            // local variables
            PropertyDescriptorCollection properties = base.GetProperties(propertyDescriptor, period, attributes);

            // remove properties not needed for this bar type
            properties.Remove(properties.Find("BasePeriodType", true));
            properties.Remove(properties.Find("PointAndFigurePriceType", true));
            properties.Remove(properties.Find("ReversalType", true));
            properties.Remove(properties.Find("BasePeriodValue", true));
            properties.Remove(properties.Find("Value2", true));

            // set display labels
            NinjaTrader.Gui.Design.DisplayNameAttribute.SetDisplayName(properties, "Value", "Config # (1=default)");

            // return collection
            return properties;
        }

        /// <summary>
        /// display friendly label
        /// </summary>
        public override string ToString(Period period)
        { return displayName; }
    }
}

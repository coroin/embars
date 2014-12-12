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
using System.ComponentModel;
using NinjaTrader.Indicator;

namespace Coroin.EmBars
{
    /// <summary>
    /// EmTools (candle colors, data box, range counter)
    /// </summary>
    [Description("EmBarsTools (candle colors, data box, range counter)")]
    public partial class EmBarsTools : IndicatorBase
    {
        /// fields
        bool dataBoxLoaded = false;
        string dataBoxMsg = string.Empty;

        /// methods
        public override string ToString()
        { return dataBoxLoaded ? string.Empty : "EmBarsTools"; }

        /// <summary>
        /// This method is used to configure the indicator and is called once before any bar data is loaded.
        /// </summary>
        protected override void Initialize()
        {
            Overlay = true;
            PriceTypeSupported = false;
            CalculateOnBarClose = false;
        }

        /// <summary>
        /// Called on each bar update event (incoming tick)
        /// </summary>
        protected override void OnBarUpdate()
        {
            if (candleColors)
            { CandleColorsApply(); }

            if (closePlots)
            { ClosePlotsApply(); }

            if (dataBox)
            { if (!dataBoxLoaded) { DataBoxInit(); } }

            if (rangeCounter)
            { RangeCounterApply(); }
        }

        /// <summary>
        /// Set any variables or logic you wish to do only once at start of your indicator/strategy
        /// </summary>
        protected override void OnStartUp()
        { props = Bars.BarsType as IEmProps; }
    }
}
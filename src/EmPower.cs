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
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using NinjaTrader.Data;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Indicator;

namespace Coroin.EmBars
{
    /// <summary>
    /// EmPower - custom indicator for EmBars represents the strength of the bulls vs. bears by assessing the ability of each to push price to an extreme level. Adapted from @BOP.cs, this indicator includes two smooth variables and custom plots and color shading.
    /// </summary>
    [Description("EmPower - custom indicator for EmBars represents the strength of the bulls vs. bears by assessing the ability of each to push price to an extreme level. Adapted from @BOP.cs, this indicator includes two smooth variables and custom plots and color shading.")]
    public class EmPower : IndicatorBase
    {
        /// fields
        Color bearColor = Color.Crimson;
        int bearOpacity = 3;
        Color bullColor = Color.SteelBlue;
        int bullOpacity = 3;
        DataSeries emBop;
        int smooth1 = 8;
        int smooth2 = 34;

        /// properties
        /// <summary>
        /// bear color for shading
        /// </summary>
        [XmlIgnore]
        [Description("Bear Color for shading")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Bear Color")]
        public Color BearColor
        {
            get { return bearColor; }
            set { bearColor = value; }
        }

        /// <summary>
        /// serializable bear color for shading
        /// </summary>
        [Browsable(false)]
        public string BearColorSerialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(bearColor); }
            set { bearColor = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        /// <summary>
        /// bear opacity
        /// </summary>
        [Description("Opacity for Bear Color shading")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Bear Opacity")]
        public int BearOpacity
        {
            get { return bearOpacity; }
            set { bearOpacity = (value < 1) ? 1 : (value > 10) ? 10 : value; }
        }

        /// <summary>
        /// bull color for shading
        /// </summary>
        [XmlIgnore]
        [Description("Bull Color for shading")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Bull Color")]
        public Color BullColor
        {
            get { return bullColor; }
            set { bullColor = value; }
        }

        /// <summary>
        /// serializable bull color for shading
        /// </summary>
        [Browsable(false)]
        public string BullColorSerialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(bullColor); }
            set { bullColor = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        /// <summary>
        /// bull opacity
        /// </summary>
        [Description("Opacity for Bull Color shading")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Bull Opacity")]
        public int BullOpacity
        {
            get { return bullOpacity; }
            set { bearOpacity = (value < 1) ? 1 : (value > 10) ? 10 : value; }
        }

        /// <summary>
        /// DataSeries for Bop1
        /// </summary>
        [Browsable(false)]
        [XmlIgnore()]
        public DataSeries EmBop1
        { get { return Values[0]; } }

        /// <summary>
        /// DataSeries for Bop2
        /// </summary>
        [Browsable(false)]
        [XmlIgnore()]
        public DataSeries EmBop2
        { get { return Values[1]; } }

        /// <summary>
        /// bars for smoothing Bop1
        /// </summary>
        [Description("Bars to use for SMA smoothing of EmBop1.")]
        [GridCategory("Parameters")]
        public int Smooth1
        {
            get { return smooth1; }
            set { smooth1 = Math.Max(1, value); SwapMinMax(); }
        }

        /// <summary>
        /// bars for smoothing Bop2
        /// </summary>
        [Description("Bars to use for SMA smoothing of EmBop2.")]
        [GridCategory("Parameters")]
        public int Smooth2
        {
            get { return smooth2; }
            set { smooth2 = Math.Max(1, value); SwapMinMax(); }
        }

        /// methods
        /// <summary>
        /// This method is used to configure the indicator and is called once before any bar data is loaded.
        /// </summary>
        protected override void Initialize()
        {
            Add(new Plot(new Pen(Color.Silver, 1), PlotStyle.Line, "EmBop1"));
            Add(new Plot(new Pen(Color.Silver, 1), PlotStyle.Line, "EmBop2"));
            Add(new Line(new Pen(System.Drawing.Color.DarkGray, 2), 0, "ZeroLine"));
            Lines[0].Pen.DashStyle = DashStyle.Dash;
            emBop = new DataSeries(this);
            Overlay = false;
            DrawOnPricePanel = false;
        }

        /// <summary>
        /// Called on each bar update event (incoming tick)
        /// </summary>
        protected override void OnBarUpdate()
        {
            if ((High[0] - Low[0]) == 0)
            { emBop.Set(0); }
            else
            { emBop.Set((Close[0] - Open[0]) / (High[0] - Low[0])); }

            EmBop1.Set(EmMath.SMA(ref emBop, CurrentBar, Smooth1, CurrentBar == 0 ? emBop[0] : EmBop1[1]));
            EmBop2.Set(EmMath.SMA(ref emBop, CurrentBar, Smooth2, CurrentBar == 0 ? emBop[0] : EmBop2[1]));

            if (EmBop1[0] > EmBop2[0])
            { DrawRegion("EmBoP_" + CurrentBar.ToString(), 1, 0, EmBop1, EmBop2, Color.Transparent, BullColor, BullOpacity); }
            else if (EmBop2[0] > EmBop1[0])
            { DrawRegion("EmBoP_" + CurrentBar.ToString(), 1, 0, EmBop2, EmBop1, Color.Transparent, BearColor, BearOpacity); }
        }

        /// <summary>
        /// Ensure smooth1 is less than smooth2
        /// </summary>
        void SwapMinMax()
        {
            if (smooth1 > smooth2)
            {
                int tmpSwap = smooth2;
                smooth2 = smooth1;
                smooth1 = tmpSwap;
            }
        }
    }
}

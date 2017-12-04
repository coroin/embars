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
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;
using NinjaTrader.Data;

namespace Coroin.EmBars
{
    partial class EmBarsTools
    {
        /// fields
        Color bearOutline = Color.Crimson;
        Color bearTrend = Color.LightCoral;
        Color bullOutline = Color.SteelBlue;
        Color bullTrend = Color.LightSteelBlue;
        bool candleColors = true;
        Color dojiColor = Color.Olive;
        Color zeroVolumeOutline = Color.DarkGray;
        Color zeroVolumeShading = Color.LightGray;

        /// properties
        /// <summary>
        /// bear candle outline color
        /// </summary>
        [XmlIgnore]
        [Description("Outline color for bear candles (close is below open)")]
        [GridCategory("\t\tCandle Colors")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Bear Outline")]
        public Color BearOutline
        {
            get { return bearOutline; }
            set { bearOutline = value; }
        }

        /// <summary>
        /// serializable bear candle outline color
        /// </summary>
        [Browsable(false)]
        public string BearOutlineSerialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(bearOutline); }
            set { bearOutline = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        /// <summary>
        /// bear trend candle color
        /// </summary>
        [XmlIgnore]
        [Description("Shading color for bear trend candles (no bull wick)")]
        [GridCategory("\t\tCandle Colors")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Bear Trend")]
        public Color BearTrend
        {
            get { return bearTrend; }
            set { bearTrend = value; }
        }

        /// <summary>
        /// serializable bear trend candle color
        /// </summary>
        [Browsable(false)]
        public string BearTrendSerialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(bearTrend); }
            set { bearTrend = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        /// <summary>
        /// bull candle outline color
        /// </summary>
        [XmlIgnore]
        [Description("Outline color for bull candles (close is above open)")]
        [GridCategory("\t\tCandle Colors")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Bull Outline")]
        public Color BullOutline
        {
            get { return bullOutline; }
            set { bullOutline = value; }
        }

        /// <summary>
        /// serializable bull candle outline color
        /// </summary>
        [Browsable(false)]
        public string BullOutlineSerialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(bullOutline); }
            set { bullOutline = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        /// <summary>
        /// bull trend candle color
        /// </summary>
        [XmlIgnore]
        [Description("Shading color for bull trend candles (no bear wick)")]
        [GridCategory("\t\tCandle Colors")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Bull Trend")]
        public Color BullTrend
        {
            get { return bullTrend; }
            set { bullTrend = value; }
        }

        /// <summary>
        /// serializable bull trend candle color
        /// </summary>
        [Browsable(false)]
        public string BullTrendSerialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(bullTrend); }
            set { bullTrend = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        [Description("Enable or Disable candle color options.")]
        [GridCategory("\t\tCandle Colors")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("\tCandle Colors")]
        public EmEnableDisable CandleColors
        {
            get { return candleColors == true ? EmEnableDisable.Enable : EmEnableDisable.Disable; }
            set { candleColors = value == EmEnableDisable.Enable ? true : false; }
        }

        /// <summary>
        /// doji candle color
        /// </summary>
        [XmlIgnore]
        [Description("Color for doji candles (close same as open)")]
        [GridCategory("\t\tCandle Colors")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Doji Color")]
        public Color DojiColor
        {
            get { return dojiColor; }
            set { dojiColor = value; }
        }

        /// <summary>
        /// serializable doji candle color
        /// </summary>
        [Browsable(false)]
        public string DojiColorSerialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(dojiColor); }
            set { dojiColor = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        /// <summary>
        /// zero-volume candle outline color
        /// </summary>
        [XmlIgnore]
        [Description("Outline color for zero-volume candles (eg. range bars)")]
        [GridCategory("\t\tCandle Colors")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Zero-Volume Outline")]
        public Color ZeroVolumeOutline
        {
            get { return zeroVolumeOutline; }
            set { zeroVolumeOutline = value; }
        }

        /// <summary>
        /// serializable zero-volume candle outline color
        /// </summary>
        [Browsable(false)]
        public string ZeroVolumeOutlineSerialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(zeroVolumeOutline); }
            set { zeroVolumeOutline = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        /// <summary>
        /// zero-volume candle shading color
        /// </summary>
        [XmlIgnore]
        [Description("Shading color for zero-volume candles (eg. range bars)")]
        [GridCategory("\t\tCandle Colors")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Zero-Volume Shading")]
        public Color ZeroVolumeShading
        {
            get { return zeroVolumeShading; }
            set { zeroVolumeShading = value; }
        }

        /// <summary>
        /// serializable doji candle color
        /// </summary>
        [Browsable(false)]
        public string ZeroVolumeShadingSerialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(zeroVolumeShading); }
            set { zeroVolumeShading = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        /// methods
        /// <summary>
        /// apply candle colors
        /// </summary>
        void CandleColorsApply()
        {
            // set bar color
            if (Volume[0] == 0)
            { BarColor = zeroVolumeShading; }
            else if (Close[0] == High[0] && Open[0] == Low[0])
            { BarColor = bullTrend; }
            else if (Close[0] == Low[0] && Open[0] == High[0])
            { BarColor = bearTrend; }
            else
            { BarColor = Color.Transparent; }

            // set candle outline
            if (Volume[0] == 0)
            { CandleOutlineColor = zeroVolumeOutline; }
            else if (Close[0] > Open[0])
            { CandleOutlineColor = bullOutline; }
            else if (Close[0] < Open[0])
            { CandleOutlineColor = bearOutline; }
            else
            { CandleOutlineColor = dojiColor; }
        }
    }
}

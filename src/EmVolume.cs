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
using NinjaTrader.Cbi;
using NinjaTrader.Data;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Indicator;

namespace Coroin.EmBars
{
    /// <summary>
    /// EmVolume - custom indicator for EmBars using EmProps data to represent the bull and bear volume and order pressure.
    /// </summary>
    [Description("EmVolume - custom indicator for EmBars using EmProps data to represent the bull and bear volume and order pressure.")]
    public class EmVolume : IndicatorBase
    {
        /// fields
        Color bearColor = Color.Crimson;
        int bearOpacity = 3;
        Color bullColor = Color.SteelBlue;
        int bullOpacity = 3;
        Color errorColor = Color.Transparent;
        int errorOpacity = 3;
        bool invalid;
        IEmProps props = null;

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
        /// serializable bear candle outline color
        /// </summary>
        [Browsable(false)]
        public string BearColorSerialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(bearColor); }
            set { bearColor = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        [Browsable(false)]
        [XmlIgnore()]
        public DataSeries BearCount
        { get { return Values[0]; } }

        [Description("Opacity for Bear Color shading")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Bear Opacity")]
        public int BearOpacity
        {
            get { return bearOpacity; }
            set { bearOpacity = (value < 1) ? 1 : (value > 10) ? 10 : value; }
        }

        [Browsable(false)]
        [XmlIgnore()]
        public DataSeries BearVolume
        { get { return Values[1]; } }

        /// <summary>
        /// bull color for shading
        /// </summary>
        [XmlIgnore]
        [Description("Shading color for bear trend candles (no bull wick)")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Bear Trend")]
        public Color BullColor
        {
            get { return bullColor; }
            set { bullColor = value; }
        }

        /// <summary>
        /// serializable bear trend candle color
        /// </summary>
        [Browsable(false)]
        public string BullColorSerialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(bullColor); }
            set { bullColor = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        [Browsable(false)]
        [XmlIgnore()]
        public DataSeries BullCount
        { get { return Values[2]; } }

        [Description("Opacity for Bull Color shading")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Bull Opacity")]
        public int BullOpacity
        {
            get { return bullOpacity; }
            set { bullOpacity = (value < 1) ? 1 : (value > 10) ? 10 : value; }
        }

        [Browsable(false)]
        [XmlIgnore()]
        public DataSeries BullVolume
        { get { return Values[3]; } }

        /// <summary>
        /// error color for shading
        /// </summary>
        [XmlIgnore]
        [Description("Error Color for shading")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Error Color")]
        public Color ErrorColor
        {
            get { return errorColor; }
            set { errorColor = value; }
        }

        /// <summary>
        /// serializable error candle outline color
        /// </summary>
        [Browsable(false)]
        public string ErrorColorSerialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(errorColor); }
            set { errorColor = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        [Browsable(false)]
        [XmlIgnore()]
        public DataSeries ErrorCount
        { get { return Values[4]; } }

        [Description("Opacity for Error Color shading")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Error Opacity")]
        public int ErrorOpacity
        {
            get { return errorOpacity; }
            set { errorOpacity = (value < 1) ? 1 : (value > 10) ? 10 : value; }
        }

        [Browsable(false)]
        [XmlIgnore()]
        public DataSeries ErrorVolume
        { get { return Values[5]; } }

        /// <summary>
        /// This method is used to configure the indicator and is called once before any bar data is loaded.
        /// </summary>
        protected override void Initialize()
        {
            Add(new Plot(new Pen(Color.Silver, 1), "Bear Count"));
            Add(new Plot(new Pen(Color.Silver, 1), "Bear Volume"));
            Add(new Plot(new Pen(Color.Silver, 1), "Bull Count"));
            Add(new Plot(new Pen(Color.Silver, 1), "Bull Volume"));
            Add(new Plot(new Pen(Color.Silver, 1), "Error Count"));
            Add(new Plot(new Pen(Color.Silver, 1), "Error Volume"));

            CalculateOnBarClose = false;
            DisplayInDataBox = true;
            DrawOnPricePanel = false;
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
                BearCount.Set(-barProps.BearCount);
                BearVolume.Set(-barProps.BearVolume);
                BullCount.Set(barProps.BullCount);
                BullVolume.Set(barProps.BullVolume);
                ErrorCount.Set(barProps.ErrorCount);
                ErrorVolume.Set(barProps.ErrorVolume);

                /// draw shading
                if (CurrentBar > 0)
                {
                    DrawRegion("EmVolume_Bull_" + CurrentBar.ToString(), 1, 0, BullVolume, BullCount, Color.Transparent, BullColor, BullOpacity);
                    DrawRegion("EmVolume_Bear_" + CurrentBar.ToString(), 1, 0, BearVolume, BearCount, Color.Transparent, BearColor, BearOpacity);
                    DrawRegion("EmVolume_Zero_" + CurrentBar.ToString(), 1, 0, BullCount, BearCount, Color.Transparent, ErrorColor, ErrorOpacity);
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

        /// <summary>
        /// Set any variables or logic you wish to do only once at start of your indicator/strategy
        /// </summary>
        protected override void OnStartUp()
        { props = Bars.BarsType as IEmProps; }
    }
}

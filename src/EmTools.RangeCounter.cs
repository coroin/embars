//
// $Id$
// Copyright (C) 2011-2013, Coroin LLC <http://coroin.com>
//
using System;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Data;

namespace Coroin.EmBars
{
    partial class EmBarsTools
    {
        /// fields
        EmRangeCalcs rangeCountCalc = EmRangeCalcs.OpenClose;
        bool rangeCounter = true;
        Color rangeCounterBear = Color.Crimson;
        Color rangeCounterBull = Color.SteelBlue;
        int rangeCountFontSize = 9;
        FontStyle rangeCountFontStyle = FontStyle.Regular;
        int rangeCountOffset = 1;
        EmRangeCountPositions rangeCountPosition = EmRangeCountPositions.EmBars;

        /// properties
        [Description("Calculation determins how the Range is calculated. Choices are OpenClose (default) and HighLow.")]
        [GridCategory("\t\tRange Counter")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Calculation")]
        public EmRangeCalcs RangeCountCalc
        {
            get { return rangeCountCalc; }
            set { rangeCountCalc = value; }
        }

        [Description("Enable or Disable Range Counter which prints the EmBars Range value associated with each candle on the chart.")]
        [GridCategory("\t\tRange Counter")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("\tRange Counter")]
        public EmEnableDisable RangeCounter
        {
            get { return rangeCounter == true ? EmEnableDisable.Enable : EmEnableDisable.Disable; }
            set { rangeCounter = value == EmEnableDisable.Enable ? true : false; }
        }

        [XmlIgnore]
        [Description("Range Counter Bear Color (close is below open)")]
        [GridCategory("\t\tRange Counter")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Bear Color")]
        public Color RangeCounterBear
        {
            get { return rangeCounterBear; }
            set { rangeCounterBear = value; }
        }

        [Browsable(false)]
        public string RangeCounterBearSerialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(rangeCounterBear); }
            set { rangeCounterBear = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        [XmlIgnore]
        [Description("Range Counter Bull Color (close is above open)")]
        [GridCategory("\t\tRange Counter")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Bull Color")]
        public Color RangeCounterBull
        {
            get { return rangeCounterBull; }
            set { rangeCounterBull = value; }
        }

        [Browsable(false)]
        public string RangeCounterBullSerialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(rangeCounterBull); }
            set { rangeCounterBull = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        [Description("Font Size for the Range Counter text is the point size ranging from 9 - 48.")]
        [GridCategory("\t\tRange Counter")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Font Size")]
        public int RangeCountFontSize
        {
            get { return rangeCountFontSize; }
            set { rangeCountFontSize = Math.Min(Math.Max(9, value), 48); }
        }

        [Description("Font Style for the Range Counter text can be Regular, Bold, Italic, Underline, and Strikeout.")]
        [GridCategory("\t\tRange Counter")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Font Style")]
        public FontStyle RangeCountFontStyle
        {
            get { return rangeCountFontStyle; }
            set { rangeCountFontStyle = value; }
        }

        [Description("Range Offset is the number of ticks above/below the high/low to print Range Counter.")]
        [GridCategory("\t\tRange Counter")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Offset")]
        public int RangeCountOffset
        {
            get { return rangeCountOffset; }
            set { rangeCountOffset = Math.Max(1, value); }
        }

        [Description("Range Position controls where the Range Counter is plotted. Choices are EmBars, Centered, Outside, Top, and Bottom. EmBars style plots Range Counter outside for trend candles and centered for candles with wicks. Outside plots bull closes above and bear closes below.")]
        [GridCategory("\t\tRange Counter")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Position")]
        public EmRangeCountPositions RangeCountPosition
        {
            get { return rangeCountPosition; }
            set { rangeCountPosition = value; }
        }

        /// methods
        /// <summary>
        /// sets range-count to print above the candle
        /// </summary>
        void RangeCountAbove(ref double offset, ref double y)
        {
            offset = rangeCountOffset * TickSize;
            y = High[0] + offset;
        }

        /// <summary>
        /// sets range-count to print below the candle
        /// </summary>
        void RangeCountBelow(ref double offset, ref double y)
        {
            offset = rangeCountOffset * TickSize;
            y = Low[0] - offset;
        }

        /// <summary>
        /// sets range-count to print on the center of the candle
        /// </summary>
        void RangeCountCenter(ref double offset, ref double y)
        {
            offset = Math.Abs(Close[0] - Open[0]) / 2;
            y = ((Close[0] > Open[0]) ? Open[0] + offset : Open[0] - offset);
        }

        /// <summary>
        /// re-draws center for previous candle
        /// </summary>
        void RangeCountCenterPrev(Font font)
        {
            if (!((Low[1] == Open[1] && High[1] == Close[1]) || (Low[1] == Close[1] && High[1] == Open[1])))
            {
                // local variables
                Color color = (Close[1] > Open[1] ? rangeCounterBull : rangeCounterBear);
                double offset = Math.Abs(Close[1] - Open[1]) / 2;
                string tag = "ebtRangeCounter_" + (CurrentBar - 1).ToString();
                double y = ((Close[1] > Open[1]) ? Open[1] + offset : Open[1] - offset);

                // calc range with user-specified formula
                double range = 1;
                switch (rangeCountCalc)
                {
                    case EmRangeCalcs.HighLow:
                        range = Math.Abs(High[1] - Low[1]);
                        break;

                    case EmRangeCalcs.OpenClose:
                    default:
                        range = Math.Abs(Close[1] - Open[1]);
                        break;
                }
                range = Instrument.MasterInstrument.Round2TickSize(range) / TickSize;

                // re-draw previous text
                DrawText(tag, false, range.ToString(), 1, y, 0, color, font, StringAlignment.Center, Color.Transparent, Color.Transparent, 0);
            }
        }

        /// <summary>
        /// apply range counter to chart
        /// </summary>
        void RangeCounterApply()
        {
            // local variables
            string tag = "ebtRangeCounter_" + CurrentBar.ToString();
            double range = 1;
            double offset = 1;
            double y = Close[0];
            Font font = new Font("Courier New", rangeCountFontSize, rangeCountFontStyle);
            Color color = (Close[0] > Open[0] ? rangeCounterBull : rangeCounterBear);

            // calc range with user-specified formula
            switch (rangeCountCalc)
            {
                case EmRangeCalcs.HighLow:
                    range = Math.Abs(High[0] - Low[0]);
                    break;

                case EmRangeCalcs.OpenClose:
                default:
                    range = Math.Abs(Close[0] - Open[0]);
                    break;
            }
            range = Instrument.MasterInstrument.Round2TickSize(range) / TickSize;

            // check for current bar forming
            if (Bars.Count == CurrentBar + 1)
            {
                RangeCountBelow(ref offset, ref y);

                // reset previous
                if (FirstTickOfBar && rangeCountPosition == EmRangeCountPositions.EmBars)
                { RangeCountCenterPrev(font); }
            }
            else
            {
                // apply range counter to user-specified position
                switch (rangeCountPosition)
                {
                    case EmRangeCountPositions.Above:
                        RangeCountAbove(ref offset, ref y);
                        break;

                    case EmRangeCountPositions.Below:
                        RangeCountBelow(ref offset, ref y);
                        break;

                    case EmRangeCountPositions.Centered:
                        RangeCountCenter(ref offset, ref y);
                        break;

                    case EmRangeCountPositions.Outside:
                        RangeCountOutside(ref offset, ref y);
                        break;

                    case EmRangeCountPositions.EmBars:
                    default:
                        if ((Low[0] == Open[0] && High[0] == Close[0]) || (Low[0] == Close[0] && High[0] == Open[0]))
                        { RangeCountOutside(ref offset, ref y); }
                        else
                        { RangeCountCenter(ref offset, ref y); }
                        break;
                }
            }

            // draw text on chart
            DrawText(tag, false, range.ToString(), 0, y, 0, color, font, StringAlignment.Center, Color.Transparent, Color.Transparent, 0);
        }

        /// <summary>
        /// sets range-count to print outside of candle (bull above high, bear below low)
        /// </summary>
        void RangeCountOutside(ref double offset, ref double y)
        {
            offset = rangeCountOffset * TickSize;
            y = ((Close[0] > Open[0]) ? High[0] + offset : Low[0] - offset);
        }
    }
}
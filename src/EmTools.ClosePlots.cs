//
// $Id$
// Copyright (C) 2011-2013, Coroin LLC <http://coroin.com>
//
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Data;

namespace Coroin.EmBars
{
    partial class EmBarsTools
    {
        /// fields
        int barId;
        Color bearColor = Color.Crimson;
        Color bullColor = Color.SteelBlue;
        bool closePlots = false;
        bool invalid;
        IEmProps props = null;
        bool showDebug = false;

        /// properties
        [XmlIgnore]
        [Description("Bear Close Plot Color")]
        [GridCategory("\t\tClose Plots")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Bear Color")]
        public Color BearColor
        {
            get { return bearColor; }
            set { bearColor = value; }
        }

        [Browsable(false)]
        public string BearColorSerialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(bearColor); }
            set { bearColor = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        [XmlIgnore]
        [Description("Bull Close Plot Color")]
        [GridCategory("\t\tClose Plots")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("Bull Color")]
        public Color BullColor
        {
            get { return bullColor; }
            set { bullColor = value; }
        }

        [Browsable(false)]
        public string BullColorSerialize
        {
            get { return NinjaTrader.Gui.Design.SerializableColor.ToString(bullColor); }
            set { bullColor = NinjaTrader.Gui.Design.SerializableColor.FromString(value); }
        }

        [Description("Enable or Disable Close Plots which are lines reflecting current bar BullClose / BearClose and previous bar failed close.")]
        [GridCategory("\t\tClose Plots")]
        [NinjaTrader.Gui.Design.DisplayNameAttribute("\tClose Plots")]
        public EmEnableDisable ClosePlots
        {
            get { return closePlots == true ? EmEnableDisable.Enable : EmEnableDisable.Disable; }
            set { closePlots = value == EmEnableDisable.Enable ? true : false; }
        }

        /// methods
        void ClosePlotsApply()
        {
            /// ensure bar has EmProps
            if (props is IEmProps)
            {
                /// only fire once per bar
                if (barId == CurrentBar)
                { return; }

                /// add close plots
                DrawPlots();

                /// remove successful close
                if (!Historical)
                { RemovePlots(); }
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

        void DrawPlots()
        {
            /// get EmProps for the specified bar, matching on OHLCVT
            EmProps barProps = props.GetEmProps(Open[0], High[0], Low[0], Close[0], (long)Volume[0], Time[0]) as EmProps;

            /// ensure EmProps exist for given bar (note: some historical data may not be available)
            if (barProps == null)
            { return; }

            /// update barId so this only fires once per bar
            barId = CurrentBar;

            /// local variables
            double bear = barProps.BearClose;
            double bull = barProps.BullClose;
            double close = barProps.Close;

            /// draw bear close
            if (close != bear)
            { DrawLine("ebtClosePlotsBear_" + CurrentBar, true, 0, bear, -1, bear, bearColor, DashStyle.Dash, 2); }

            /// draw bull close
            if (close != bull)
            { DrawLine("ebtClosePlotsBull_" + CurrentBar, true, 0, bull, -1, bull, bullColor, DashStyle.Dash, 2); }

            /// add debug to output window
            if (showDebug)
            { Print(string.Format("Bar {0} => {1}", CurrentBar, barProps)); }
        }

        void RemovePlots()
        {
            /// get EmProps for the previous bar
            EmProps barProps = props.GetEmProps(Open[1], High[1], Low[1], Close[1], (long)Volume[1], Time[1]) as EmProps;

            /// ensure EmProps exist for given bar (note: some historical data may not be available)
            if (barProps == null)
            { return; }

            /// remove successful bear line
            if (barProps.Close == barProps.BearClose)
            { RemoveDrawObject("ebtClosePlotsBear_" + (CurrentBar - 1).ToString()); }

            /// remove successful bull line
            if (barProps.Close == barProps.BullClose)
            { RemoveDrawObject("ebtClosePlotsBull_" + (CurrentBar - 1).ToString()); }
        }
    }
}
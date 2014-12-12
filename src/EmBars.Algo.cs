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
using NinjaTrader.Data;

namespace Coroin.EmBars
{
    partial class EmBars
    {
        /// fields
        double prevClose;
        int thisBias = 0;
        double thisCloseDown;
        double thisCloseUp;
        double thisOpen;
        double tickBearContValue;
        double tickBearInitValue;
        double tickBearRangeMax;
        double tickBearRangeMin;
        double tickBullContValue;
        double tickBullInitValue;
        double tickBullRangeMax;
        double tickBullRangeMin;
        double tickRange;
        double tickSize;

        /// methods
        /// <summary>
        /// add two doubles and return double rounded to ticksize
        /// </summary>
        /// <param name="bars">bars array</param>
        /// <param name="d1">first double input</param>
        /// <param name="d2">second double input</param>
        /// <returns>double that has been rounded to ticksize</returns>
        internal static double AddTwoDoubles(Bars bars, double d1, double d2)
        { return bars.Instrument.MasterInstrument.Round2TickSize((Math.Floor(10000000.0 * d1) + Math.Floor(10000000.0 * d2)) / 10000000.0); }

        /// <summary>
        /// set thisOpen, thisCloseUp, thisCloseDown
        /// </summary>
        /// <param name="bars">bars array</param>
        /// <param name="thisPrice">current value of thisClose</param>
        /// <param name="tickPrice">real price used for next open for gap bars</param>
        void AdjustOpenClose(Bars bars, double thisPrice, double tickPrice)
        {
            // local variables
            double tmpRange = 0;

            // update class fields
            thisOpen = (OpenOption == EmOpens.NoGap) ? thisPrice : tickPrice;

            if (thisBias == -1)
            {
                // counter-trend - use bull-init for thisCloseUp
                switch (configBullInitType)
                {
                    case 1:
                        tmpRange = tickBullRangeMax;
                        break;

                    case -1:
                        tmpRange = tickBullRangeMin;
                        break;

                    case 0:
                    default:
                        tmpRange = EmMath.RangeValidate(AddTwoDoubles(bars, tickRange, tickBullInitValue), tickBullRangeMax, tickBullRangeMin);
                        break;
                }
                thisCloseUp = AddTwoDoubles(bars, thisOpen, tmpRange);

                // with-trend - use bear-cont for thisCloseDown
                tickRange = EmMath.RangeValidate(AddTwoDoubles(bars, tickRange, tickBearContValue), tickBearRangeMax, tickBearRangeMin);
                thisCloseDown = AddTwoDoubles(bars, thisOpen, -tickRange);
            }
            else
            {
                // counter-trend - use bear-init for thisCloseUp
                switch (configBearInitType)
                {
                    case 1:
                        tmpRange = tickBearRangeMax;
                        break;

                    case -1:
                        tmpRange = tickBearRangeMin;
                        break;

                    case 0:
                    default:
                        tmpRange = EmMath.RangeValidate(AddTwoDoubles(bars, tickRange, tickBearInitValue), tickBearRangeMax, tickBearRangeMin);
                        break;
                }
                thisCloseDown = AddTwoDoubles(bars, thisOpen, -tmpRange);

                // with-trend - use bull-cont for thisCloseUp
                tickRange = EmMath.RangeValidate(AddTwoDoubles(bars, tickRange, tickBullContValue), tickBullRangeMax, tickBullRangeMin);
                thisCloseUp = AddTwoDoubles(bars, thisOpen, tickRange);
            }
        }

        /// <summary>
        /// Called on each incoming tick
        /// </summary>
        void OnTick(Bars bars, double open, double high, double low, double close, DateTime time, long volume, bool isRealtime)
        {
            // ensure xml config loaded
            ConfigCheck();

            // create initial bar on first tick and handle NT7 session-break issue (note: removing IsNewSession() creates invalid bars; remove if preferred)
            if ((bars.Count == 0) || bars.IsNewSession(time, isRealtime))
            {
                // set class fields
                tickSize = bars.Instrument.MasterInstrument.TickSize;

                // calculate bear/bull min/max
                RangeInit();

                // update class fields
                AdjustOpenClose(bars, close, close);
                prevClose = close;

                // add first bar
                AddBar(bars, thisOpen, thisOpen, thisOpen, thisOpen, time, volume, isRealtime);

                // add EmProps
                AddEmProps(thisOpen, volume, thisCloseDown, thisCloseUp, time);
            }

            // continue all subsequent ticks/bars
            else
            {
                // local variables
                Bar bar = (Bar)bars.Get(bars.Count - 1);
                int compareCloseUp = bars.Instrument.MasterInstrument.Compare(close, thisCloseUp);
                int compareCloseDown = bars.Instrument.MasterInstrument.Compare(close, thisCloseDown);

                // range exceeded; create new bar(s)
                if (((compareCloseUp > 0 || compareCloseDown < 0) && CloseOption == EmCloses.TickThru) || ((compareCloseUp >= 0 || compareCloseDown <= 0) && CloseOption == EmCloses.OnTouch))
                {
                    // local variables
                    bool newBar = true;
                    double thisClose = (compareCloseUp > 0) ? Math.Min(close, thisCloseUp) : (compareCloseDown < 0) ? Math.Max(close, thisCloseDown) : close;

                    // close current bar; volume included for on-touch only
                    // see this post for more info on volume calculation: http://www.ninjatrader.com/support/forum/showthread.php?p=302208#post302208
                    UpdateBar(bars, bar.Open, ((compareCloseUp > 0) ? thisClose : bar.High), ((compareCloseDown < 0) ? thisClose : bar.Low), thisClose, time, ((CloseOption == EmCloses.OnTouch) ? volume : 0), isRealtime);
                    barProps.Finalize(thisClose, prevClose, ((CloseOption == EmCloses.OnTouch) ? volume : 0), time, ((close > bar.Open) ? 1 : (close < bar.Open) ? -1 : 0));

                    // add next bar and loop phantom bars, if needed
                    do
                    {
                        // update class fields
                        thisBias = (close > bar.Open) ? 1 : (close < bar.Open) ? -1 : 0;
                        tickRange = EmMath.RangeValidate(Math.Abs(AddTwoDoubles(bars, bar.Open, -thisClose)), (thisBias == -1) ? tickBearRangeMax : tickBullRangeMax, (thisBias == -1) ? tickBearRangeMin : tickBullRangeMin);
                        AdjustOpenClose(bars, thisClose, close);
                        thisClose = (compareCloseUp > 0) ? Math.Min(close, thisCloseUp) : (compareCloseDown < 0) ? Math.Max(close, thisCloseDown) : close;

                        // add new bar; include volume once (except for on-touch), then create phantom bars
                        // see this post for more info on volume calculation: http://www.ninjatrader.com/support/forum/showthread.php?p=302208#post302208
                        AddBar(bars, thisOpen, ((compareCloseUp > 0) ? thisClose : thisOpen), ((compareCloseDown < 0) ? thisClose : thisOpen), thisClose, time, ((CloseOption == EmCloses.TickThru && newBar) ? volume : 0), isRealtime);

                        // add EmProps
                        AddEmProps(thisOpen, ((compareCloseUp > 0) ? thisClose : thisOpen), ((compareCloseDown < 0) ? thisClose : thisOpen), thisClose, ((CloseOption == EmCloses.TickThru && newBar) ? volume : 0), time, thisBias, thisCloseDown, thisCloseUp);

                        // update class fields
                        newBar = false;
                        compareCloseUp = bars.Instrument.MasterInstrument.Compare(close, thisCloseUp);
                        compareCloseDown = bars.Instrument.MasterInstrument.Compare(close, thisCloseDown);
                    }
                    while (((compareCloseUp > 0 || compareCloseDown < 0) && CloseOption == EmCloses.TickThru) || ((compareCloseUp >= 0 || compareCloseDown <= 0) && CloseOption == EmCloses.OnTouch));
                }

                // range not exceeded; continue current bar
                else
                {
                    // update current bar
                    UpdateBar(bars, bar.Open, ((close > bar.High) ? close : bar.High), ((close < bar.Low) ? close : bar.Low), close, time, volume, isRealtime);

                    // update EmProps
                    barProps.Update(close, prevClose, volume, time);
                }
            }

            // update prevClose and last price
            bars.LastPrice = prevClose = close;
        }

        /// <summary>
        /// calculate bear/bull min/max
        /// </summary>
        void RangeInit()
        {
            // calulate bear/bull min/max if tickSize is set
            if (tickSize > 0)
            {
                tickBearContValue = EmMath.MultiplyTwoDoubles((double)configBearContValue, tickSize);
                tickBearInitValue = EmMath.MultiplyTwoDoubles((double)configBearInitValue, tickSize);
                tickBearRangeMax = EmMath.MultiplyTwoDoubles((double)configBearRangeMax, tickSize);
                tickBearRangeMin = EmMath.MultiplyTwoDoubles((double)configBearRangeMin, tickSize);
                tickBullContValue = EmMath.MultiplyTwoDoubles((double)configBullContValue, tickSize);
                tickBullInitValue = EmMath.MultiplyTwoDoubles((double)configBullInitValue, tickSize);
                tickBullRangeMax = EmMath.MultiplyTwoDoubles((double)configBullRangeMax, tickSize);
                tickBullRangeMin = EmMath.MultiplyTwoDoubles((double)configBullRangeMin, tickSize);
            }

            // swap bear min/max if entered incorrectly
            if (tickBearRangeMin > tickBearRangeMax || tickBullRangeMin > tickBullRangeMax)
            {
                double tmpBear = tickBearRangeMax;
                tickBearRangeMax = tickBearRangeMin;
                tickBearRangeMin = tmpBear;
            }

            // swap bull min/max if entered incorrectly
            if (tickBullRangeMin > tickBullRangeMax)
            {
                double tmpBull = tickBullRangeMax;
                tickBullRangeMax = tickBullRangeMin;
                tickBullRangeMin = tmpBull;
            }
        }
    }
}
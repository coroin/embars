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

namespace Coroin.EmBars
{
    /// <summary>
    /// interface for EmProps - custom properties used by EmBars
    /// </summary>
    public interface IEmProps
    {
        /// <summary>
        /// get EmProps for given bar
        /// </summary>
        /// <param name="open">open</param>
        /// <param name="high">high</param>
        /// <param name="low">low</param>
        /// <param name="close">close</param>
        /// <param name="volume">volume</param>
        /// <param name="time">timestamp</param>
        /// <returns>object with EmProps for given bar</returns>
        EmProps GetEmProps(double open, double high, double low, double close, long volume, DateTime time);
    }

    /// <summary>
    /// custom properties used by EmBars
    /// </summary>
    public class EmProps
    {
        /// fields
        int barBias;
        double barClose;
        double barHigh;
        double barLow;
        double barOpen;
        DateTime barTime;
        long barVolume;
        double bearClose;
        long bearCount;
        long bearVolume;
        double bullClose;
        long bullCount;
        long bullVolume;
        int direction;
        long errorCount;
        long errorVolume;
        bool init;
        long surge;
        long tide;

        /// constructors
        public EmProps()
        {
        }

        public EmProps(double close, long volume, DateTime time, int bias, double bear, double bull)
            : this(close, close, close, close, volume, time, bias, bear, bull)
        {
        }

        public EmProps(double open, double high, double low, double close, long volume, DateTime time, int bias, double bear, double bull)
        {
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
            Timestamp = time;
            Bias = bias;
            BearClose = bear;
            BullClose = bull;
            init = true;
        }

        /// properties
        public double BearClose
        {
            get { return bearClose; }
            internal set { bearClose = (!init && value >= 0) ? value : bearClose; }
        }

        public long BearCount
        {
            get { return bearCount; }
            internal set { bearCount = (value > 0) ? value : bearCount; }
        }

        public long BearVolume
        {
            get { return bearVolume; }
            internal set { bearVolume = (value > 0) ? value : bearVolume; }
        }

        public int Bias
        {
            get { return barBias; }
            internal set { barBias = (value >= 1) ? 1 : (value <= -1) ? -1 : 0; }
        }

        public double BullClose
        {
            get { return bullClose; }
            internal set { bullClose = (!init && value >= 0) ? value : bullClose; }
        }

        public long BullCount
        {
            get { return bullCount; }
            internal set { bullCount = (value > 0) ? value : bullCount; }
        }

        public long BullVolume
        {
            get { return bullVolume; }
            internal set { bullVolume = (value > 0) ? value : bullVolume; }
        }

        public double Close
        {
            get { return barClose; }
            internal set { barClose = (value > 0) ? value : barClose; }
        }

        public long ErrorCount
        {
            get { return errorCount; }
            internal set { errorCount = (value > 0) ? value : errorCount; }
        }

        public long ErrorVolume
        {
            get { return errorVolume; }
            internal set { errorVolume = (value > 0) ? value : errorVolume; }
        }

        public double High
        {
            get { return barHigh; }
            internal set { barHigh = (value > 0) ? value : barHigh; }
        }

        public double Low
        {
            get { return barLow; }
            internal set { barLow = (value > 0) ? value : barLow; }
        }

        public double Open
        {
            get { return barOpen; }
            internal set { barOpen = (!init && value >= 0) ? value : barOpen; }
        }

        public long Surge
        {
            get { return surge; }
            internal set { surge = value; }
        }

        public long Tide
        {
            get { return tide; }
            internal set { tide = value; }
        }

        public DateTime Timestamp
        {
            get { return barTime; }
            internal set { barTime = value; }
        }

        public long Volume
        {
            get { return barVolume; }
            internal set { barVolume = (value > 0) ? value : barVolume; }
        }

        /// methods
        /// <summary>
        /// Finalize EmProps for current bar
        /// </summary>
        public void Finalize(double close, double last, long volume, DateTime time, int bias)
        {
            Bias = bias;
            Update(close, last, volume, time);
        }

        /// <summary>
        /// Return EmProps data as string
        /// </summary>
        public override string ToString()
        { return string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}", barOpen, barHigh, barLow, barClose, barVolume, barTime, bearClose, bullClose); }

        /// <summary>
        /// Update EmProps intra-bar
        /// </summary>
        public void Update(double close, double last, long volume, DateTime time)
        {
            // update hlcvt
            if (close > barHigh) High = close;
            if (close < barLow) Low = close;
            Close = close;
            Volume += volume;
            Timestamp = time;

            // bear
            if ((last > close) || (last == close && direction == -1))
            {
                BearCount++;
                BearVolume += volume;
                Tide -= volume;
                direction = -1;

                // downtick
                if (last > close)
                { Surge--; }
            }
            // bull
            else if ((last < close) || (last == close && direction == 1))
            {
                BullCount++;
                BullVolume += volume;
                Tide += volume;
                direction = 1;

                // uptick
                if (last < close)
                { Surge++; }
            }
            // exception
            else
            {
                /// this is a hack
                /// need to fix this so last is continuous and is not impacted by each successive bar
                direction = Bias;
                ErrorCount++;
                ErrorVolume += volume;
            }
        }
    }
}

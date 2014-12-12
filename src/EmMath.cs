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
    /// <summary>
    /// Math Functions used by EmBars
    /// </summary>
    internal static class EmMath
    {
        /// <summary>
        /// Exponential Moving Average
        /// </summary>
        internal static double EMA(double value, int bar, int period, double prev)
        { return (bar == 0) ? value : value * (2.0 / (1 + period)) + (1 - (2.0 / (1 + period))) * prev; }

        /// <summary>
        /// multiply two doubles
        /// </summary>
        internal static double MultiplyTwoDoubles(double d1, double d2)
        { return Math.Floor(10000000.0 * d1 * d2) / 10000000.0; }

        /// <summary>
        /// validate tick range between min and max
        /// </summary>
        internal static double RangeValidate(double range, double max, double min)
        { return Math.Min(Math.Max(range, min), max); }

        /// <summary>
        /// Simple Moving Average
        /// </summary>
        internal static double SMA(ref DataSeries ds, int bar, int period, double prev)
        {
            if (bar == 0)
            { return ds[0]; }
            else
            {
                double min = Math.Min(bar, period);
                double last = prev * min;

                if (bar >= period)
                { return (last + ds[0] - ds[period]) / min; }
                else
                { return (last + ds[0]) / (min + 1); }
            }
        }
    }
}
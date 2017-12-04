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
using System.Collections.Generic;
using NinjaTrader.Data;

namespace Coroin.EmBars
{
    partial class EmBars : IEmProps
    {
        /// fields
        EmProps barProps;
        List<EmProps> propList;

        /// constructors
        public EmBars()
            : base(PeriodType.Custom7)
        {
            barProps = null;
            propList = new List<EmProps>();
        }

        /// methods
        /// <summary>
        /// GetEmProps for bar (required by IEmProps)
        /// </summary>
        public EmProps GetEmProps(double open, double high, double low, double close, long volume, DateTime time)
        {
            return propList.Find(p =>
                    p.Open == open &&
                    p.High == high &&
                    p.Low == low &&
                    p.Close == close &&
                    p.Volume == volume &&
                    p.Timestamp.ToUniversalTime() == time.ToUniversalTime()
                );
        }

        /// <summary>
        /// Add EmProps for bar to List
        /// </summary>
        void AddEmProps(double open, double high, double low, double close, long volume, DateTime time, int bias, double bear, double bull)
        {
            barProps = new EmProps(open, high, low, close, volume, time, bias, bear, bull);
            propList.Add(barProps);
        }

        /// <summary>
        /// Add EmProps for initial/session bar to List
        /// </summary>
        void AddEmProps(double close, long volume, double bear, double bull, DateTime time)
        { AddEmProps(close, close, close, close, volume, time, 0, bear, bull); }
    }
}

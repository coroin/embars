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

namespace Coroin.EmBars
{
    /// <summary>
    /// EventArgs for Resync Event
    /// </summary>
    public sealed class ResyncEventArgs : EventArgs
    {
        /// fields
        int bearContValue;
        int bearInitType;
        int bearInitValue;
        int bearRangeMax;
        int bearRangeMin;
        int bullContValue;
        int bullInitType;
        int bullInitValue;
        int bullRangeMax;
        int bullRangeMin;
        EmCloses closeOption;
        int configId;
        EmOpens openOption;

        /// constructors
        public ResyncEventArgs(
            int id,
            int bearCV,
            int bearIT,
            int bearIV,
            int bearMax,
            int bearMin,
            int bullCV,
            int bullIT,
            int bullIV,
            int bullMax,
            int bullMin,
            EmCloses close,
            EmOpens open
            )
        {
            configId = id;
            bearContValue = bearCV;
            bearInitType = bearIT;
            bearInitValue = bearIV;
            bearRangeMax = bearMax;
            bearRangeMin = bearMin;
            bullContValue = bullCV;
            bullInitType = bullIT;
            bullInitValue = bullIV;
            bullRangeMax = bullMax;
            bullRangeMin = bullMin;
            closeOption = close;
            openOption = open;
        }

        /// properties
        public int BearContValue { get { return bearContValue; } }

        public int BearInitType { get { return bearInitType; } }

        public int BearInitValue { get { return bearInitValue; } }

        public int BearRangeMax { get { return bearRangeMax; } }

        public int BearRangeMin { get { return bearRangeMin; } }

        public int BullContValue { get { return bullContValue; } }

        public int BullInitType { get { return bullInitType; } }

        public int BullInitValue { get { return bullInitValue; } }

        public int BullRangeMax { get { return bullRangeMax; } }

        public int BullRangeMin { get { return bullRangeMin; } }

        public EmCloses CloseOption { get { return closeOption; } }

        public int ConfigId { get { return configId; } }

        public EmOpens OpenOption { get { return openOption; } }
    }
}
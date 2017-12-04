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
namespace Coroin.EmBars
{
    /// <summary>
    /// enumerator for closes
    /// </summary>
    public enum EmCloses
    {
        TickThru,
        OnTouch,
    }

    /// <summary>
    /// enumerator for Enable/Disable
    /// </summary>
    public enum EmEnableDisable
    {
        Enable,
        Disable,
    }

    /// <summary>
    /// enumerator for opens
    /// </summary>
    public enum EmOpens
    {
        TrueOpen,
        NoGap,
    }

    /// <summary>
    /// enumerator for calcs
    /// </summary>
    public enum EmRangeCalcs
    {
        OpenClose,
        HighLow,
    }

    /// <summary>
    /// enumerator for positions
    /// </summary>
    public enum EmRangeCountPositions
    {
        EmBars,
        Above,
        Below,
        Centered,
        Outside,
    }
}

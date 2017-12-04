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
    /// build info fields
    /// </summary>
    internal static class BuildInfo
    {
        /// for each release:
        /// - update Date
        /// - update Release
        /// - update Readme.txt

        /// fields
        internal const string Author = "Coroin LLC <http://coroin.com>";
        internal const string Copyright = "© 2011-2013 Coroin LLC";
        internal const string ProductName = "Coroin EmBars";
        internal const string Release = "2.4.0.1119";
        internal const string Title = "EmBars <http://embars.com>.";
        internal static DateTime Date = new DateTime(2013, 5, 8, 0, 2, 0, DateTimeKind.Utc);
        internal static string Version = string.Format("EmBars {0} [{1}]", Release, Date.ToShortDateString());
        internal static string WindowTitle = string.Format("{0} {1}", ProductName, Release);
    }
}

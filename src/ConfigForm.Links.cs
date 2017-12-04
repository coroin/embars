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
using System.Windows.Forms;

namespace Coroin.EmBars
{
    partial class ConfigForm
    {
        /// <summary>
        /// link click handling method for bull link contract
        /// </summary>
        void bearLinkContract_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { linkHandle(sender); }

        /// <summary>
        /// link click handling method for bear link expand
        /// </summary>
        void bearLinkExpand_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { linkHandle(sender); }

        /// <summary>
        /// link click handling method for bear link fixed
        /// </summary>
        void bearLinkFixed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { linkHandle(sender); }

        /// <summary>
        /// link click handling method for bull link contract
        /// </summary>
        void bullLinkContract_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { linkHandle(sender); }

        /// <summary>
        /// link click handling method for bull link expand
        /// </summary>
        void bullLinkExpand_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { linkHandle(sender); }

        /// <summary>
        /// link click handling method for bull link fixed
        /// </summary>
        void bullLinkFixed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { linkHandle(sender); }

        /// <summary>
        /// handle clicked links set tab to defaults
        /// </summary>
        void linkHandle(object sender)
        {
            // local variables
            string name = ((LinkLabel)sender).Name;

            // handle link by name
            switch (name)
            {
                case "bearLinkContract":
                    if (bearRangeMax.Value != 8) { bearRangeMax.Value = 8; }
                    if (bearRangeMin.Value != 5) { bearRangeMin.Value = 5; }
                    if (bearContValue.Value != -1) { bearContValue.Value = -1; }
                    if (!bearInitMax.Checked) { bearInitMax.Checked = true; }
                    break;

                case "bearLinkExpand":
                    if (bearRangeMax.Value != 7) { bearRangeMax.Value = 7; }
                    if (bearRangeMin.Value != 3) { bearRangeMin.Value = 3; }
                    if (bearContValue.Value != 1) { bearContValue.Value = 1; }
                    if (!bearInitMin.Checked) { bearInitMin.Checked = true; }
                    break;

                case "bearLinkFixed":
                    if (bearRangeMax.Value != 4) { bearRangeMax.Value = 4; }
                    if (bearRangeMin.Value != 4) { bearRangeMin.Value = 4; }
                    if (bearInitValue.Value != 0) { bearInitValue.Value = 0; }
                    if (bearContValue.Value != 0) { bearContValue.Value = 0; }
                    if (!bearInitPrev.Checked) { bearInitPrev.Checked = true; }
                    break;

                case "bullLinkContract":
                    if (bullRangeMax.Value != 8) { bullRangeMax.Value = 8; }
                    if (bullRangeMin.Value != 5) { bullRangeMin.Value = 5; }
                    if (bullContValue.Value != -1) { bullContValue.Value = -1; }
                    if (!bullInitMax.Checked) { bullInitMax.Checked = true; }
                    break;

                case "bullLinkExpand":
                    if (bullRangeMax.Value != 7) { bullRangeMax.Value = 7; }
                    if (bullRangeMin.Value != 3) { bullRangeMin.Value = 3; }
                    if (bullContValue.Value != 1) { bullContValue.Value = 1; }
                    if (!bullInitMin.Checked) { bullInitMin.Checked = true; }
                    break;

                case "bullLinkFixed":
                    if (bullRangeMax.Value != 4) { bullRangeMax.Value = 4; }
                    if (bullRangeMin.Value != 4) { bullRangeMin.Value = 4; }
                    if (bullInitValue.Value != 0) { bullInitValue.Value = 0; }
                    if (bullContValue.Value != 0) { bullContValue.Value = 0; }
                    if (!bullInitPrev.Checked) { bullInitPrev.Checked = true; }
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// click event handling method for contact link on help tab
        /// </summary>
        void linkHelpContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { System.Diagnostics.Process.Start("http://embars.com/contact"); }

        /// <summary>
        /// click event handling method for faq link on help tab
        /// </summary>
        void linkHelpFAQ_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { System.Diagnostics.Process.Start("http://embars.com/support"); }

        /// <summary>
        /// click event handling method for license (terms) link on help tab
        /// </summary>
        void linkHelpLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { System.Diagnostics.Process.Start("http://embars.com/faq#license"); }

        /// <summary>
        /// click event handling method for video link on help tab
        /// </summary>
        void linkHelpVideo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { System.Diagnostics.Process.Start("http://embars.com/video"); }
    }
}

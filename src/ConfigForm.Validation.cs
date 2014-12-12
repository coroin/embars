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
using System.Windows.Forms;

namespace Coroin.EmBars
{
    partial class ConfigForm
    {
        /// fields
        bool isDirty = false;
        bool isLoading = false;

        /// properties
        bool isStable { get { return !isLoading && !isDirty; } }

        /// methods
        /// <summary>
        /// value changed handling method for bear cont increment
        /// </summary>
        void bearContValue_ValueChanged(object sender, EventArgs e)
        {
            // validate change
            validateCont(sender);

            // update config
            config.BearContValue = (int)bearContValue.Value;

            // flag apply and save buttons
            OnApplySaveNeeded(true);
        }

        /// <summary>
        /// checkbox changed handling method for bull init range max
        /// </summary>
        void bearInitMax_CheckedChanged(object sender, EventArgs e)
        {
            // validate change
            validateInitType(sender);

            // update config
            config.BearInitType = 1;

            // flag apply and save buttons
            OnApplySaveNeeded(true);
        }

        /// <summary>
        /// checkbox changed handling method for bull init range min
        /// </summary>
        void bearInitMin_CheckedChanged(object sender, EventArgs e)
        {
            // validate change
            validateInitType(sender);

            // update config
            config.BearInitType = -1;

            // flag apply and save buttons
            OnApplySaveNeeded(true);
        }

        /// <summary>
        /// checkbox changed handling method for bull init previous
        /// </summary>
        void bearInitPrev_CheckedChanged(object sender, EventArgs e)
        {
            // validate change
            validateInitType(sender);

            // update config
            config.BearInitType = 0;

            // flag apply and save buttons
            OnApplySaveNeeded(true);
        }

        /// <summary>
        /// value changed handling method for bear init increment
        /// </summary>
        void bearInitValue_ValueChanged(object sender, EventArgs e)
        {
            // validate change
            validateInit(sender);

            // update config
            config.BearInitValue = (int)bearInitValue.Value;

            // flag apply and save buttons
            OnApplySaveNeeded(true);
        }

        /// <summary>
        /// value changed handling method for bear range max
        /// </summary>
        void bearRangeMax_ValueChanged(object sender, EventArgs e)
        {
            // validate change
            validateMinMax(sender);

            // update config
            config.BearRangeMax = (int)bearRangeMax.Value;

            // flag apply and save buttons
            OnApplySaveNeeded(true);
        }

        /// <summary>
        /// value changed handling method for bear range min
        /// </summary>
        void bearRangeMin_ValueChanged(object sender, EventArgs e)
        {
            // validate change
            validateMinMax(sender);

            // update config
            config.BearRangeMin = (int)bearRangeMin.Value;

            // flag apply and save buttons
            OnApplySaveNeeded(true);
        }

        /// <summary>
        /// value changed handling method for bull cont increment
        /// </summary>
        void bullContValue_ValueChanged(object sender, EventArgs e)
        {
            // validate change
            validateCont(sender);

            // update config
            config.BullContValue = (int)bullContValue.Value;

            // flag apply and save buttons
            OnApplySaveNeeded(true);
        }

        /// <summary>
        /// checkbox changed handling method for bull init range max
        /// </summary>
        void bullInitMax_CheckedChanged(object sender, EventArgs e)
        {
            // validate change
            validateInitType(sender);

            // update config
            config.BullInitType = 1;

            // flag apply and save buttons
            OnApplySaveNeeded(true);
        }

        /// <summary>
        /// checkbox changed handling method for bull init range min
        /// </summary>
        void bullInitMin_CheckedChanged(object sender, EventArgs e)
        {
            // validate change
            validateInitType(sender);

            // update config
            config.BullInitType = -1;

            // flag apply and save buttons
            OnApplySaveNeeded(true);
        }

        /// <summary>
        /// checkbox changed handling method for bull init previous
        /// </summary>
        void bullInitPrev_CheckedChanged(object sender, EventArgs e)
        {
            // validate change
            validateInitType(sender);

            // update config
            config.BullInitType = 0;

            // flag apply and save buttons
            OnApplySaveNeeded(true);
        }

        /// <summary>
        /// value changed handling method for bull init increment
        /// </summary>
        void bullInitValue_ValueChanged(object sender, EventArgs e)
        {
            // validate change
            validateInit(sender);

            // update config
            config.BullInitValue = (int)bullInitValue.Value;

            // flag apply and save buttons
            OnApplySaveNeeded(true);
        }

        /// <summary>
        /// value changed handling method for bull range max
        /// </summary>
        void bullRangeMax_ValueChanged(object sender, EventArgs e)
        {
            // validate change
            validateMinMax(sender);

            // update config
            config.BullRangeMax = (int)bullRangeMax.Value;

            // flag apply and save buttons
            OnApplySaveNeeded(true);
        }

        /// <summary>
        /// value changed handling method for bull range min
        /// </summary>
        void bullRangeMin_ValueChanged(object sender, EventArgs e)
        {
            // validate change
            validateMinMax(sender);

            // update config
            config.BullRangeMin = (int)bullRangeMin.Value;

            // flag apply and save buttons
            OnApplySaveNeeded(true);
        }

        /// <summary>
        /// validation rules when Cont value changes
        /// </summary>
        void validateCont(object sender)
        {
            // ensure ok to validate
            if (!isStable)
            { return; }

            // local variables
            decimal max = 0M, min = 0M;
            bool maxChecked = false, minChecked = false, prevChecked = false;
            string name = ((NumericUpDown)sender).Name;
            decimal prev = Decimal.Parse(((NumericUpDown)sender).Text);
            string tag = ((NumericUpDown)sender).Tag.ToString();
            decimal value = ((NumericUpDown)sender).Value;

            // set local variables
            switch (tag)
            {
                case "bear":
                    max = bearRangeMax.Value;
                    min = bearRangeMin.Value;
                    maxChecked = bearInitMax.Checked;
                    minChecked = bearInitMin.Checked;
                    prevChecked = bearInitPrev.Checked;
                    break;

                case "bull":
                    max = bullRangeMax.Value;
                    min = bullRangeMin.Value;
                    maxChecked = bullInitMax.Checked;
                    minChecked = bullInitMin.Checked;
                    prevChecked = bullInitPrev.Checked;
                    break;

                default:
                    break;
            }

            // ensure value <= max (***updates value***)
            if (Math.Abs(value) > max)
            {
                // flag isDirty
                isDirty = true;

                // update cont value
                value = (value < 0) ? max * -1M : max;
                ((NumericUpDown)sender).Value = value;
            }

            // ensure value not zero for dynamic (***updates value***)
            if (min < max && value == 0)
            {
                // flag isDirty
                isDirty = true;

                // update value
                value = (prev < 0) ? 1M : -1M;
                ((NumericUpDown)sender).Value = value;
            }

            // ensure dynamic range on increment/decrement from zero
            if (max == min && value != 0)
            {
                // flag isDirty
                isDirty = true;

                // increment max
                if (tag == "bear")
                {
                    bearRangeMax.Value = max + 1M;
                    config.BearRangeMax = (int)max + 1;
                }
                else if (tag == "bull")
                {
                    bullRangeMax.Value = max + 1M;
                    config.BullRangeMax = (int)max + 1;
                }
            }

            // ensure max not checked for expanding
            if (value > 0 && maxChecked)
            {
                // flag isDirty
                isDirty = true;

                // set min checked
                if (tag == "bear")
                {
                    bearInitMin.Checked = true;
                    config.BearInitType = -1;
                }
                else if (tag == "bull")
                {
                    bullInitMin.Checked = true;
                    config.BullInitType = -1;
                }
            }

            // ensure min not checked for contracting
            if (value < 0 && minChecked)
            {
                // flag isDirty
                isDirty = true;

                // set max checked
                if (tag == "bear")
                {
                    bearInitMax.Checked = true;
                    config.BearInitType = 1;
                }
                else if (tag == "bull")
                {
                    bullInitMax.Checked = true;
                    config.BullInitType = 1;
                }
            }

            // reset isDirty
            isDirty = false;
        }

        /// <summary>
        /// validation rules when Init value changes
        /// </summary>
        void validateInit(object sender)
        {
            // ensure ok to validate
            if (!isStable)
            { return; }

            // local variables
            decimal cont = 0M, max = 0M, min = 0M;
            bool prevChecked = false;
            decimal prev = Decimal.Parse(((NumericUpDown)sender).Text);
            string tag = ((NumericUpDown)sender).Tag.ToString();
            decimal value = ((NumericUpDown)sender).Value;

            // get max / prev
            switch (tag)
            {
                case "bear":
                    cont = bearContValue.Value;
                    max = bearRangeMax.Value;
                    min = bearRangeMin.Value;
                    prevChecked = bearInitPrev.Checked;
                    break;

                case "bull":
                    cont = bullContValue.Value;
                    max = bullRangeMax.Value;
                    min = bullRangeMin.Value;
                    prevChecked = bullInitPrev.Checked;
                    break;

                default:
                    break;
            }

            // ensure value <= max (***updates value***)
            if (Math.Abs(value) > max)
            {
                // flag isDirty
                isDirty = true;

                // update cont value
                value = (value < 0) ? max * -1M : max;
                ((NumericUpDown)sender).Value = value;
            }

            // ensure value not zero for dynamic (***updates value***)
            if (min < max && value == 0)
            {
                // flag isDirty
                isDirty = true;

                // update cont value
                value = (prev < 0) ? 1M : -1M;
                ((NumericUpDown)sender).Value = value;
            }

            // ensure dynamic range on increment/decrement from zero
            if (max == min && value != 0)
            {
                // flag isDirty
                isDirty = true;

                // increment max
                if (tag == "bear")
                {
                    bearRangeMax.Value = max + 1M;
                    config.BearRangeMax = (int)max + 1;

                    // update cont
                    if (cont == 0)
                    {
                        decimal newCont = Math.Min(Math.Max(value, -1M), 1M);
                        bearContValue.Value = newCont;
                        config.BearContValue = (int)newCont;
                    }
                }
                else if (tag == "bull")
                {
                    bullRangeMax.Value = max + 1M;
                    config.BullRangeMax = (int)max + 1;

                    // update cont
                    if (cont == 0)
                    {
                        decimal newCont = Math.Min(Math.Max(value, -1M), 1M);
                        bullContValue.Value = newCont;
                        config.BullContValue = (int)newCont;
                    }
                }
            }

            // ensure prev selected when value not zero
            if (value != 0 && !prevChecked)
            {
                // flag isDirty
                isDirty = true;

                // set prev checked
                if (tag == "bear")
                {
                    bearInitPrev.Checked = true;
                    config.BearInitType = 0;
                }
                else if (tag == "bull")
                {
                    bullInitPrev.Checked = true;
                    config.BullInitType = 0;
                }
            }

            // reset isDirty
            isDirty = false;
        }

        /// <summary>
        /// validation rules when InitType selection changes
        /// </summary>
        void validateInitType(object sender)
        {
            // ensure ok to validate
            if (!isStable)
            { return; }

            // local variables
            bool maxChecked = false, minChecked = false;
            string tag = ((RadioButton)sender).Tag.ToString();
            decimal init = 0M;

            // get maxChecked / prev
            switch (tag)
            {
                case "bear":
                    init = bearInitValue.Value;
                    maxChecked = bearInitMax.Checked;
                    minChecked = bearInitMin.Checked;
                    break;

                case "bull":
                    init = bullInitValue.Value;
                    maxChecked = bullInitMax.Checked;
                    minChecked = bullInitMin.Checked;
                    break;

                default:
                    break;
            }

            // ensure init is zero when min/max selected
            if ((minChecked || maxChecked) && init != 0)
            {
                // flag isDirty
                isDirty = true;

                // update init value
                if (tag == "bear")
                {
                    bearInitValue.Value = 0;
                    config.BearInitValue = 0;
                }
                else if (tag == "bull")
                {
                    bullInitValue.Value = 0;
                    config.BullInitValue = 0;
                }
            }

            // reset isDirty
            isDirty = false;
        }

        /// <summary>
        /// validation rules when Min/Max values changes
        /// </summary>
        void validateMinMax(object sender)
        {
            // ensure ok to validate
            if (!isStable)
            { return; }

            // local variables
            decimal cont = 0M, init = 0M, max = 0M, min = 0M;
            string name = ((NumericUpDown)sender).Name;
            decimal prev = Decimal.Parse(((NumericUpDown)sender).Text);
            string tag = ((NumericUpDown)sender).Tag.ToString();

            // get min / max / cont
            switch (tag)
            {
                case "bear":
                    cont = bearContValue.Value;
                    init = bearInitValue.Value;
                    max = bearRangeMax.Value;
                    min = bearRangeMin.Value;
                    break;

                case "bull":
                    cont = bullContValue.Value;
                    init = bullInitValue.Value;
                    max = bullRangeMax.Value;
                    min = bullRangeMin.Value;
                    break;

                default:
                    break;
            }

            // ensure min < max
            if (min > max)
            {
                // flag isDirty
                isDirty = true;

                // update min/max value
                switch (name)
                {
                    case "bearRangeMax":
                        bearRangeMin.Value = max;
                        config.BearRangeMin = (int)max;
                        break;

                    case "bearRangeMin":
                        bearRangeMax.Value = min;
                        config.BearRangeMax = (int)min;
                        break;

                    case "bullRangeMax":
                        bullRangeMin.Value = max;
                        config.BullRangeMin = (int)max;
                        break;

                    case "bullRangeMin":
                        bullRangeMax.Value = min;
                        config.BullRangeMax = (int)min;
                        break;

                    default:
                        break;
                }
            }

            // ensure fixed cont
            if (min == max && cont != 0)
            {
                // flag isDirty
                isDirty = true;

                // update cont value
                if (tag == "bear")
                {
                    bearContValue.Value = 0;
                    config.BearContValue = 0;
                }
                else if (tag == "bull")
                {
                    bullContValue.Value = 0;
                    config.BullContValue = 0;
                }
            }

            // ensure dynamic cont
            if (min < max && cont == 0)
            {
                // flag isDirty
                isDirty = true;

                // increment cont value
                if (tag == "bear")
                {
                    bearContValue.Value = 1;
                    config.BearContValue = 1;
                }
                else if (tag == "bull")
                {
                    bullContValue.Value = 1;
                    config.BullContValue = 1;
                }
            }

            // ensure cont value less than max
            if (max < Math.Abs(cont))
            {
                // flag isDirty
                isDirty = true;

                // local variables
                decimal newCont = (cont < 0) ? cont * -1M : cont;

                // update cont value
                if (tag == "bear")
                {
                    bearContValue.Value = newCont;
                    config.BearContValue = (int)newCont;
                }
                else if (tag == "bull")
                {
                    bullContValue.Value = newCont;
                    config.BullContValue = (int)newCont;
                }
            }

            // ensure init value less than max
            if (max < Math.Abs(init))
            {
                // flag isDirty
                isDirty = true;

                // local variables
                decimal newInit = (cont < 0) ? cont * -1M : cont;

                // update cont value
                if (tag == "bear")
                {
                    bearInitValue.Value = newInit;
                    config.BearInitValue = (int)newInit;
                }
                else if (tag == "bull")
                {
                    bullInitValue.Value = newInit;
                    config.BullInitValue = (int)newInit;
                }
            }

            // reset isDirty
            isDirty = false;
        }
    }
}
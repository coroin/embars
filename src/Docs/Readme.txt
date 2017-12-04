======================================================================
+ Release Notes - Coroin EmBars 2.x                                  +
======================================================================

INSTALLATION
1. Open NinjaTrader
2. Click File > Utilities > Import NinjaScript...
3. Browse to EmBars zip file location (eg. your desktop)
4. Select EmBars zip file
5. Click Open
6. Select OK to complete the import
   Note: It is recommended to restart NinjaTrader after install.

UPGRADING TO A NEW RELEASE
1. Follow the same instructions for INSTALLATION
2. You MUST restart NinjaTrader after importing.

USAGE - NEW CHART
1. Open NinjaTrader
2. Connect to your data provider (File > Connect > Your-Data-Provider)
3. File > New > Chart
4. Select an Instrument or enter one in the box
5. In the right-pane, under Period, change Type to EmBars
6. Set the config # (1 is the default)
7. Click OK

USAGE - EDIT SETTINGS
1. Open the EmBars Configuration Tool
2. Make note of the Config # (1 is the default)
   Note: DO NOT open more than one chart with the same config #
3. Change values (Open, Close, Min, Max)
4. Click [apply]

USAGE - SAVE SETTINGS
1. Open the EmBars Configuration Tool
2. Click [save as]
3. Browse to the folder where you wish to save
4. Select a file or type a name
5. Click Save
   Note: Changes are automatically saved to the EmBars Config file
         used by the chart. This feature is only for saving your
         favorite parameter sets to archive or share.

USAGE - OPEN SETTINGS
1. Open the EmBars Configuration Tool
2. Click [open]
3. Browse to the folder with the config file to load
4. Select the file
5. Click Open
6. Make changes, as needed
7. To apply the setitngs, click [apply]

USAGE - APPLY SETTINGS
1. Open the EmBars Configuration Tool
2. Click [apply]

UNINSTALLATION / REMOVAL
1. Open NinjaTrader
2. Click File > Utilities > Remove NinjaScript Assembly
3. Select Coroin.Embars
4. Click Remove
5. Click Yes to remove the assembly
6. Click Ok
   Note: It is recommended to restart NinjaTrader after uninstall.

MANUAL REMOVAL / TROUBLESHOOTING
Note: Please follow steps for UNINSTALLATION / REMOVAL before proceeding with the following!
0) ensure NinjaTrader is shut down
1) delete the following files, if they exist
    * NT7\bin\Custom\Coroin.EmBars.dll
    * NT7\bin\Custom\Indicator\EmSamples.cs
    * [optional] NT7\bin\Custom\EmBars-Config-#.xml (where # is the config Id)
2) open NinjaTrader (you may get errors)
3) click File | New | Workspace
4) close all other workspaces, leaving just the new blank one open
5) save the workspace with a name of your choosing, such as debug
6) click Tools | Edit | NinjaScript Indicator | <pick any custom indicator>
7) right-click in the whitespace and select References
    * if there is an entry for Coroin.EmBars.dll, click that row and press Delete
    * click OK
8) compile the indicator by pressing F5
    * if you get errors at this point, it's not related to EmBars;
    * fix that error(s) before proceeding with step 10
9) shut down NinjaTrader
10) follow INSTALLATION procedure above
11) restart NinjaTrader after installation
12) click File | New | Chart
13) select EmBars as the Bar Type
    * if you get errors at this point, please contact info@coroin.com
14) open your previous workspace
    * if you get errors at this point, please contact info@coroin.com
15) you can switch back and close the debug workspace so it won't open in the background
    if you made it this far with no errors, then it's time to celebrate :-)

======================================================================

KNOWN ISSUES / LIMITATIONS
- Do NOT open more than one chart with the same Config #. You may get
  unexpected results. Always use a separate Config # for each chart.
- There are no other known issues at this time.

LICENSE / TERMS AND CONDITIONS
Please review the License.txt file or visit http://embars.com/license

TECHNICAL SUPPORT
Please visit http://embars.com/contact to contact technical support.

======================================================================

RELEASE HISTORY
v2.4.0 r1119 @130508 0200Z
#139 EmBars 2.4 open-source
#141 update license to lgpl
#142 EmPower indicator
#143 EmVolume indicator

v2.3.0 r1076 @121218 0600Z
#13 new properties (BullClose, BearClose)
#95 EmSamples indicator (code samples for Advanced Developers)
#126 RangeCounter correct positioning after bar close
#133 add license grace period
#135 CLSCompliant assembly

v2.2.0 r1042 @121105 2200Z
#8 add help section to config tool
#54 calc formulas for RangeCounter
#84 round to ticksize
#90 enhance font styling for DataBox and RangeCounter
#91 set RangeCounter default to Enabled
#92 range config by trend and sentiment
#112 update DataBox display range trend and sentiment
#113 common config quick-links
#119 auto-disable DataBox for non-EmBars charts

v2.1.0 r981 @121004 0700Z
#11 add color parameters to RangeCounter
#12 use windows form for ConfigTool
#28 dynamic range type
#39 add position to RangeCounter
#65 add RangeOption to DataBox
#71 range type edit checks

v2.0.2 r959 @120927 1400Z
#3, #4, #5 added EmBarsTools indicator (colors, data box, range count)
#2 fixed dynamic range-max bug

v2.0.1 r945 @120922 0530Z
#1 renamed OpenOption.Actual to TrueOpen

v2.0.0 r939 @120921 2200Z
#6 public subscriber release

======================================================================
http://coroin.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSIsoft.AF.Time;
using System.Text.RegularExpressions;

namespace MATLABfromCSharp
{
    public partial class DataPreferences : Form
    {
        //Class Properties
        bool TimeStamps;
        int DataPref, DataPrefMultiple;
        MainForm main;
        string formatTimeStamp;

        //Constructor
        /// <summary>
        ///  Constructor of the Data Preferences Dialog.
        /// </summary>
        /// <param name="main"> The MainForm, needed to pass changes in the Preferences to the MainControl.</param>
        public DataPreferences(MainForm main)
        {
            this.main = main;
            InitializeComponent();
            TimeStamps = true;
            formatTimeStamp = "ts";
            DataPrefMultiple = 0;
            mTBIntervals.Text = ""+20;
            main.passDataPrefChanges(TimeStamps, getDataPref(), formatToString());
        }

        /// <summary>
        /// Gets the integer value for Attribute.GetValues;
        ///  0 (raw), negative (sampling), positive (profiled sampling)
        /// </summary>
        /// <returns> The integer value for Attribute.GetValues.</returns>
        public int getDataPref()
        {
            int.TryParse(mTBIntervals.Text, out DataPref);
            return DataPref*DataPrefMultiple;
        }
        /// <summary>
        ///  Setups the dialog, to select the correct radio button, based on the integer.
        /// </summary>
        /// <param name="intervals"> Number of samples or profiled samples wanted. Input into the textbox.</param>
        public void setDataPref(int intervals)
        {
            mTBIntervals.Text = "" + intervals;

            if (intervals > 0)
                reducedRadio.Select();
            else if (intervals < 0)
                IntervalRadio.Select();
            else
                rawRadio.Select();
        }

        /// <summary>
        /// Parses the string representation of the DataPreferences and setup Dialog.
        /// </summary>
        /// <remarks> if string contains "ts" then timestamp is used
        /// if string contains a number, then setups the raw/sample/profiled sample choice.</remarks>
        /// <param name="format"> String representation of the data preferences.</param>
        public void setupDataPreferences(string format)
        {
                TimeStamps = Regex.IsMatch(format,@"(ts)");
                checkTimestamps.Checked = TimeStamps;

                int i;
                format=Regex.Replace(format, @"[^\d-]","");
                int.TryParse(format, out i);
                setDataPref(i);

                main.passDataPrefChanges(TimeStamps, getDataPref(), formatToString());
        }
        
        /// <summary>
        /// Creates the String Representation of the Data Preferences
        /// </summary>
        /// <returns> String representation of the Data Preferences.</returns>
        public string formatToString()
        {
            return getDataPref() + formatTimeStamp;
        }

        // Form Actions
        /// <summary>
        /// Passes the Data Preferences before closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataPreferences_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.passDataPrefChanges(TimeStamps, getDataPref(), formatToString());
            this.Hide();
            e.Cancel = true;
        }

        //Component Actions
        private void okDataButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataRadio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            switch (rb.Text)
            {
                case "Sampling":
                    mTBIntervals.Enabled = true;
                    DataPrefMultiple = -1;
                    break;
                case "Profiled Sampling":
                    mTBIntervals.Enabled = true;
                    DataPrefMultiple = 1;
                    break;
                case "Raw Data":
                    mTBIntervals.Enabled = false;
                    DataPrefMultiple = 0;
                    break;
            }
        }
        private void checkTimestamps_CheckedChanged(object sender, EventArgs e)
        {
            TimeStamps = checkTimestamps.Checked;
            if (TimeStamps)
                formatTimeStamp = "ts";
            else
                formatTimeStamp = "";
        }

        
    }
}

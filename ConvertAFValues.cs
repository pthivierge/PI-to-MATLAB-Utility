
/*
Copyright 2016 OSIsoft, LLC.
Licensed under the Apache License, Version 2.0 (the License);
you may not use this file except in compliance with the License.
You may obtain a copy of the License at 

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing,
software distributed under the License is distributed on an AS IS BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and limitations under the License.

Please see the file named LICENSE.md.
*/


﻿using System;
using OSIsoft.AF.Asset;


namespace OSIsoft.AF.Asset
{
    public class ConvertAFValues
    {
    	public static void GetValuesArray(AFValues afvalues, out object[] values, out int baddata)
	    {
            int size = afvalues.Count;
            values = new object[size];
            baddata = 0;
            int i = 0;
            foreach (AFValues afval in afvalues)
            {
                values[i] = afval.Value;
                if(afval.Status != AFValueStatus.Good)
                    baddata = baddata + 1;
                i = i + 1;
            }
            return;
	    }

        public static void GetValuesArray(AFValues afvalues, out object[] values, out double[] timestamps, out int[] statuses, out int baddata)
        {
            int size = afvalues.Count;
            values = new object[size];
            timestamps = new double[size];
            statuses = new int[size];
            baddata = 0;
            int i = 0;
            foreach (AFValues afval in afvalues)
            {
                values[i] = afval.Value;
                timestamps[i] = ((DateTime)afval.Timestamp).ToOADate() + 693960;
                statuses[i] = (int)afval.Status;
                if (afval.Status != AFValueStatus.Good)
                    baddata = baddata + 1;
                i = i + 1;
            }
            return;
        }
    }
}


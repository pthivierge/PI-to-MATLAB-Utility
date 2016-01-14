using System;
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


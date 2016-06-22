
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATLABfromCSharp
{
    class MatlabWriter
    {

        System.IO.StreamWriter writer;
        string Filename;

        public MatlabWriter(string Filename)
        {
            this.Filename = Filename;
        }

        public void Save()
        {
            using(writer = new System.IO.StreamWriter(Filename))
            {
                WriteImports();
                WriteConnection("TYOUNG_APMATLAB", "EngleTest");
                WriteAttributeImport();
            }
        }

        // Writes all the necessary setup to use AFSDK
        public void WriteImports()
        {
            writer.Write(  " % Loaded and imported AFSDK \r\n"+
               " afsdk = NET.addAssembly('OSIsoft.AFSDK');\r\n" +
               " import OSIsoft.AF.*;\r\n" +
               " import OSIsoft.AF.Asset.*;\r\n" +
               " import OSIsoft.AF.Time.*;\r\n" +
               " import System.*;\r\n\r\n");

        }

        //COULD be multiple
        public void WriteConnection(string PISystem, string Database)
        {
            writer.Write(" % Connection to PISystems and Asset Framework\r\n\r\n" +
               " af_srvs = PISystems;\r\n" +
               " af_svr = af_srvs.Item('" + PISystem + "');\r\n" +
               " af_db = af_svr.Databases.Item('" + Database + "');\r\n\r\n");
        }

        public void WriteAttributeImport()
        {

        }

        public void getConstantAttribute()
        {

        }

        public void getPIPointAttribute()
        {

        }

    }
}

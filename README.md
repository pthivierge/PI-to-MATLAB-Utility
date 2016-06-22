# PI-to-MATLAB-Utility

The PI to Matlab utility is a small utility that automatically runs a MATLAB Instance and allows the user to inject PI System Data into this MatLab Instance, as variable(s). Currently it connects to the default AF Server and the first AF database.

This repository contains the source files to build this utility as well as the Windows Installer to install it on your computer.

##Getting Started
You must have the following installed to use the PI-to-MATLAB utility:
+ MATLAB (the version we tested are R20014b:8.4.0.150421 and 2016a:9.0.0.341360) 
+	PI AF Software Development Kit (PI AF SDK) <sup>1</sup>


For more detail, please also refer to the "Using PI-to-MATLAB Program" white paper, available at the root of this repository.

 
<sup>1</sup> PI AF SDK must be installed on the machine where the PI-to-MATLAB utility is used. The easiest way to obtain PI AF SDK is to download and install the PI Asset Framework Client. You may obtain the PI Asset Framework Client installation kit from our Tech Support webpage.   


##How to create the installation package
In visual studio, double click on the project properties. Then Select the Publish menu.  Click on Publish Now.
This will create a new click-once application called setup.exe under the Setup folder of the repository.

If you want to uninstall the application, use the add-remove program Windows feature.

##Contributing



##Licensing
Copyright 2016 OSIsoft, LLC.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
   
Please see the file named [LICENSE.md](LICENSE.md).

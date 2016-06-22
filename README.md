# PI-to-MATLAB-Utility

The PI to MATLAB utility is a small utility that was developed by an OSIsoft Academic Program intern, Marissa Engle. The utility automatically runs a MATLAB Instance and allows the user to inject PI System Data into this MatLab Instance, as variable(s). Currently it connects to the default AF Server and the first AF database.

This repository contains the source files to build this utility as well as the Windows Installer to install it on your computer.

**The content in this repository is explained in the [White Paper - Using the PI-to-MATLAB Utility][2] availabe on PI Square**. Make sure to have a look into it!

##Installation and Removal
Run setup.exe from the Setup folder.  You should then see an entry PI-to-MATLAB Utility in your start menu.

To uninstall, go to add or remove programs in windows, and uninstall PI-to-MATLAB Utility.


##Prerequisites

You must have the following applications installed before you can run or compile the PI-to-MATLAB utility:
+ MATLAB (the version we tested are R20014b:8.4.0.150421 and 2016a:9.0.0.341360) 
+ PI AF Software Development Kit (PI AF SDK) <sup>1</sup>

 
<sup>1</sup> PI AF SDK must be installed on the machine where the PI-to-MATLAB utility is used. The easiest way to obtain PI AF SDK is to download and install the **PI Asset Framework (PI AF) Client XXX Install Kit (with PSE and AF SDK)** . You may obtain the PI Asset Framework Client installation kit from our Tech Support website at https://techsupport.osisoft.com/Products/PI-Server/PI-AF/   


##How to create the installation package
In visual studio, double click on the project properties. Then Select the Publish menu.  Click on Publish Now.
This will create a new click-once application called setup.exe under the Setup folder of the repository.

If you want to uninstall the application, use the add-remove program Windows feature.

##Contributing

We do welcome everyone to share their contributions and be certain all contributions will be considered. Please make sure that you read our general [contribution guidelines][1] and agree with it; it also contains a lot if useful information. Please keep in mind that integrating your contribution may require some adjustments in your code, if this is the case this will be discussed in the Pull Request you open.

We suggest you start by opening an issue so a discussion can start before you start working on code.



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




[1]:https://github.com/osisoft/contributing
[2]:https://pisquare.osisoft.com/docs/DOC-2292
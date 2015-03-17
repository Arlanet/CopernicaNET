#Arlanet CopernicaNET

##Overview
The Arlanet CopernicaNET library allows you to communicate with Copernica using their own REST API.

##Note
The library is not feature complete and without a doubt has room for improvement. 

For example: 

- It does not support receiving information from Copernica, only sending. 
- Current workings force you to have an ID-field in your Copernica-tables.

And probably a lot more. It serves its purpose to us as a company at the moment, but as said, it can certainly be improved. Hence we open-source it

##Usage
To be able to use the library or its samples you need to specify an access token that can be obtained from your Copernica account. After you add an application from the dashboard Copernica provides the access token. The token can be set in the Web.config/App.config file located in the sample and test projects.

##Documentation
Please resort to the Wiki for more information.

##Projects
The solution contains the following projects.

###Arlanet.CopernicaNET
The main library project.

###Arlanet.CopernicaNET.Sample
An ASP.net sample how to use the library.

###Arlanet.CopernicaNET.Tests
Unit testing project used to test the library functionality.

##License
We've chosen for a LGPL v3.0 license to make sure any changes made to the library find its way back to the community. Other than that, there are no restrictions.

Just to make clear what LGPL means:
- It can be used in any project you desire, including commercial ones.
- You do not have to open-source your projects, just the source of the library in case you make modifications to it.
- It's not allowed to relicense the library to anything but LGPL v3, even derivative ones, without our permission.

These are just some main concerns most people will have with open-source licenses. Be sure to read the rest of the LGPL v3 license here: https://www.gnu.org/licenses/lgpl.html

If you feel the LGPL v3 license is too restrictive, need more information or you would like to negotiate a different license, don't hesistate to contact us through github@arlanet.com.
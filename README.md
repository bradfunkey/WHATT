# WHATT
This project is hosted at http://whatechtest-bj.azurewebsites.net/

I wanted to create something which is essentially production ready and able to be extended to include more features.
The different logic has been abstracted into seperate projects to provide an architecture good to grow.
Ninject is used for the IoC Container (forgive me if I write IoT anywhere, I do lots of IoT hobby stuff too and I interchange them without realising)
Knockout is used for the client side display, maybe overkill but it's designed to scale.

How it works:
The data is loaded from the .csv files
It is then processed via the RiskManagement class where Risk Codes are added to each record based on the business rules.
The risk codes can be used to modify the UI any way our stakeholders like via knockout. I've left if plain for now.
Two Dictionaries are returned along with the processed records, these give us;
1) average bets per punter 
2) and a list of risky punters who are winning over 60% the cheeky buggers.
These two lists are also displayed in the UI

The project does not include the following:
1) Security - out of scope
2) Super Sexy UI - I could easily write some knockout effects after discussing how the stakeholders would like it displayed
3) any testing, I want to add some when I have a chance Friday.

Why are there DTO's in there?
The original plan I wanted to showcase was to allow for the files to be uploaded and persited to a db - a real world type approach. 
I later culled this approach due to time constraints and really being out of scope, but it does show how I handle mappings between repo/dto's and a client application's view models.
This project could easily be modified to read the data from a database instead of the files.

TODO: Write some tests! Well, at least I consider a testable architecture... that might have to do it as I have spent the allocated time on it already..





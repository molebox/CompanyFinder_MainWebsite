# Competence Matching

A website that enables a user to select from a list of competences and search for a company that matches the criteria. The main industry focus is currently IT.

#### Built with:
* .NET Core 2.1
* Entity Framework Core 2.1
* Material Design Bootstrap

#### Setup:
Go into the appsettings.json file and set the UrlSettings ApiBaseUrl to point towards the api address with the correct port number. You can also change the user login details here.

Once logged in you will be able to choose which industry you would like to start entering information into the databse for. At the present time only the IT sector is available

#### How it works:
* Once admin has set up the required data in the database the user simply has to login from the homepage using the credentials given in the appsettings.json file. They are then presented with a search filter which holds all the skills, details and focuses. The user can choose to select as many or as few skills or details as they like but they must select a focus for the search to happen.

* As soon as at least one focus is selected the live search will begin. The user can then select or de-select as many checkboxes as they like and the page will update live with the search results. The results are listed in descending order with the top result being the best match. Once finished logout.




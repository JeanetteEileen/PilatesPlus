# PilatesPlus   
 >Get rid of note cards or excel spreadsheets.  Put your client information in one spot!  
## Table of Contents
* [General information](#general-info)
* [User Story](#user-story)
* [Technologies Employed](#technologies-used)
* [Installation and Setup](Installation-amdnd-setup)
* [Instructions](#instructions)
* [Resources](#resources)
* [Cloning the site](#cloning-the-site)
## General Information  
Pilates Plus is an ASP.NET MVC application that allows an individual Pilates Studio owner to Keep track of the clients that frequent the studio. The structure
of the application is an n-tier structured MVC utilizing the Data, Models, Services and WebMVC.  
## User Story  
This project was inspired by the small studio where I study Pilates.  The owner kept hand written notes on what was done in the class and what to do in the future. Notebooks or note cards can be lost but information stored in a database can be kept safe easier.  As a result, this application was designed to allow the owner to keep track of the clients, the sessions or classes they took and which equipment was utilized during the class. PilatesPlus allows the the owner to keep track of the client information in one spot!   
## Technolgies Employed  
 * Visual Studio Community 2019
   * Web API.NET Frammework
   * Individual Authentication
   * Identity Framework
   * User Authorization
   * Entity Framework
   * Web MVC 5
  * Database Mapping using Code-First Approach
  * CSharp - Utilized for Logic 
  * Bootstrap
  * HTML
  * CSS
  * JQUERY
  * LINQ
  * RAZOR
  * Git  
 ## Installation and Setup  
 #### Requirements: Web browser, PilatesPlus.Azurewebsites.net  
 ![PilatesPlus login page](https://user-images.githubusercontent.com/73566009/117301389-9b38c780-ae48-11eb-8d4e-0b6f1172c52a.png)


## Instructions  
After the website has been pulled up, create a user login to begin.  Before any sessions or equipment can be added, the user needs to establish a list of clients.
1. Click on the Clients button to start entering client information such as first name, last name, email address, Is client active, and phone number.
2. After the information has been entered click on the create button.  If everything is correct and entered you will be returned to the list of clients and given a message telling you the client has been added to the database.  In the unlikely event the information is not entered correctly you will be prompted to enter the correct information.
3. The next step after creating a client is to create a session when the client comes in for a class.  This can be done prior to the class or after the class. The user can click on the CreateSession option or go back to the main menu and Select the Session button.
4. The Create Client Session page you need to start with the dropdown list of Clients to pick the client whose session you which to add.  The Session comments are for what ever the user wants to note about the session. There is an option for noting whether the session is a shared with another client as a duet.  The session date is also added as well as the day of the week drop down.  When all the information has been entered use the create button to add the session.
5. There are many pieces of equipment that can be utilized in a traditional pilates session.  As a result you will want to track which equipment was used by the client in the session.  You can either access this from the home page and click on the equipment button or choose the option to create an equipment from the session index.
6. Choose the equipment that is to be created from the drop down list.  There can only be one list of equipment for each session.  So when you enter the equipment be sure you are adding only one equipment for a session.
7. The information for the client, session, and equipment can all be edited or viewed individually.  
8. The ability to delete information is available in the equipment and session areas.  Should you want to delete the information, you must first delete the equipment before trying to delete the session since the equipment can not exist without a session to go with it.  
## Resources
 * Eleven Fifty Academy 
 * LinkedIn Learning
   * Git Essential Training: The Basics
   * Boostrap 4 Essential Training
   * Building Web APIs with ASP.NET Web API 2.2
 * [How to Write Beautiful and Meaninful README.md](https://blog.bitsrc.io/how-to-write-beautiful-and-meaningful-readme-md-for-your-next-project-897045e3f991)
 * [GitHub Markdown Syntax Cheat Sheet](https://guides.github.com/pdfs/markdown-cheatsheet-online.pdf)
 * [Golden Rules of Documentation](https://docs.google.com/document/d/1RCrukQdGxV4wBL1um4K1U_V8q-0e67OkYoNEZMBp1Mo/edit)
 * [Stack Overflow](https://stackoverflow.com/questions/879852/display-a-view-from-another-controller-in-asp-net-mvc)
 * [Stack Overflow on email validation](https://stackoverflow.com/questions/16712043/email-address-validation-using-asp-net-mvc-data-type-attributes)
 * [twilio blog on validating phone numbers](https://www.twilio.com/blog/validating-phone-numbers-effectively-with-c-and-the-net-frameworks)
 * [Stackoverflow for sorting IEnumerable string](https://stackoverflow.com/questions/3630687/how-to-sort-an-ienumerablestring)
 * [Microsft Build Relationship, navigation properties and foreign keys](https://docs.microsoft.com/en-us/ef/ef6/fundamentals/relationships)
 * [TutorialTeacher for Views](https://www.tutorialsteacher.com/mvc/tempdata-in-asp.net-mvc)
 * [TutorialTeach for DropdownListFor](https://www.tutorialsteacher.com/mvc/htmlhelper-dropdownlist-dropdownlistfor) 
 * [Trello](https://trello.com)
 * [dbdiagram](https://dbdiagram.io)
 * [W3Schools for HTML, CSS, Bootstrap](https://www.w3schools.com)
 ##Cloning the Site  
 1. 
   
  

  

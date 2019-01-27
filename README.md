# Paylocity Coding Challenge (VueJS)

[![](https://img.shields.io/website-up-down-green-red/https/gaurav-shah-paylocity-coding-challenge-vue.azurewebsites.net.svg?label=Demo%20Website)](https://gaurav-shah-paylocity-coding-challenge-vue.azurewebsites.net)

## Problem Statement
After I completed and submitted my original [Paylocity Coding Challenge](https://github.com/shah-gaurav/paylocity-coding-challenge), the feedback I recieved during the interview was that because this was a Full Stack Developer position, I should have written some Javascript code in my web application. 

## Solution
So I modified the original solution to create a Web API using ASP.NET core and use it in a front end VueJS application. 

### Implementation
#### Technologies Used

 - Visual Studio 2017 Community Edition
 - .NET Standard 2.0
 - .NET Core 2.2
 - ASP.NET Core 2.2
 - VueJS 2.5



#### Project Organization
##### Backend
- **Paylocity.CodingChallenge.Entities** (*.NET Standard 2.0*) - Contains the shared entities and their definitions.
- **Paylocity.CodingChallenge.Business** (*.NET Standard 2.0*) - Contains the business logic for calculating the benefits deduction. 
- **Paylocity.CodingChallenge.Api** (*.NET Core 2.2*) - Contains the web api implementation of the benefits calculator. This project uses ASP.NET Core 2.2.
##### Frontend
- **paylocity-codingchallenge-web** (*VueJS 2.5*) - Contains the code for the VueJS SPA application.


#### Notable Implementation/Design Decisions
To ensure that the SPA can talk to the backend Web API, I have enabled CORS in the ASP.NET Core application and purposefully made this implementation insecure and wide open. In a production application proper CORS along with JWT authentication should be used to secure the Web API.

### Testing
All testing has been removed from this solution.

### Deployment

#### Demo Website
The results are deployed to two separate web apps:

##### Frontend
[https://gaurav-shah-paylocity-coding-challenge-vue.azurewebsites.net](https://gaurav-shah-paylocity-coding-challenge-vue.azurewebsites.net)

##### Backend
[https://gaurav-shah-paylocity-coding-challenge-api.azurewebsites.net](https://gaurav-shah-paylocity-coding-challenge-api.azurewebsites.net)

This demo website is running on [Azure Web Apps](https://azure.microsoft.com/en-us/services/app-service/web/) platform  on Windows.


> Written by [Gaurav Shah](http://www.linkedin.com/in/gaurav-shah-boise).
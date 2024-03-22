# NetCoreReact
REST API for Portfolio Hierarchy Submission REST API<br>
with .Net 8, Clean Architecture, DDD, CQRS + MediatR pattern implementing. <br>
<p>&nbsp;</p>

# Built With
<ul>
<li>Microsoft Visual Studio 2022 & VS Code</li>
<li>ASP.NET Core Web Application Project - The project that includes WEB API. References ASP.NET 8.0.0. </li>
<li>Entity Framework Core</li>
<li>MySQL</li>
<li>Postman</li>
<li>Docker</li>
</ul>

# To Run
docker compose up<br><br>
Then create a user with permission and role:<br><br>
{<br>
    "Id": "bae93bf5-9e3c-47b3-aace-3034653b6bb2",<br>
    "FirstName": "esra",<br>
    "LastName": "sertsu",<br>
    "Email": "esra@gmail.com",<br>
    "Permissions": [<br>
        "create:hierarcy",<br>
        "get:hierarcy"<br>
    ],<br>
    "Roles": [<br>
        "Admin"<br>
    ]<br>
}<br><br>
Then submit a hierarcy json<br> : {<br>
"Equity": "Alex",<br>
"Bonds": "Jordan",<br>
"Alex": "Morgan",<br>
"Morgan": "Casey"<br>
}<br>
<br><br>
# Screen Shots

Docker Container<br><br>

<img width="1080" alt="Screenshot 2024-03-22 at 3 08 56 pm" src="https://github.com/esrasertsu/NetCoreReact/assets/9791024/e7bb57d3-4ce3-423a-9efc-13537cc78ab8">

Auth Implementation with User Roles and Permissions<br><br>

<img width="1080" alt="Screenshot 2024-03-22 at 3 08 46 pm" src="https://github.com/esrasertsu/NetCoreReact/assets/9791024/2dbd3b6d-5e96-4929-8b87-83b7d9150c77">

Authenticated Api for submit portfolios<br><br>
<img width="1080" alt="Screenshot 2024-03-22 at 3 08 30 pm" src="https://github.com/esrasertsu/NetCoreReact/assets/9791024/66ad9d39-2241-40de-8fa5-244204edf805">

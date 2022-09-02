# Table of contents
- [Auth](#auth)
    - [Register](#register)
        - [Register Request](#register-request)
        - [Register Response](#register-response)
    - [Login](#login)
        - [Login Request](#login-request)
        - [Login Response](#login-response)


## Auth

### Register
#### Register Request
 ```js
POST https://localhost:7129/api/Authentication/Register 
Content-Type: application/json

{
"firstname":"Surendra",
"lastname":"Singh",
"email": "SurendraSingh599@gmail.com",
"Password":"ABC@12xyz"
}

 ```
### Register
#### Register  Response
 ```json 
{
  "firstname":"Surendra",
  "lastname":"Singh",
  "email": "SurendraSingh599@gmail.com",
  "Password":"ABC@12xyz"
}
 ```
### Login
#### Login Request
 ```js
POST https://localhost:7129/api/Authentication/Login 
Content-Type: application/json

{

  "email": "SurendraSingh599@gmail.com",
  "Password":"ABC@12xyz"
}

 ```
### Login
#### Login Response
 ```json 
{
  "firstname":"Surendra",
  "lastname":"Singh",
  "email": "SurendraSingh599@gmail.com",
  "Password":"ABC@12xyz"
}
 ```
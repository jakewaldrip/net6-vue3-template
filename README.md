#README 

## Setup User Secrets in .NET Core
Either use command line, or right click the backend project and click "Manage User Secrets"

Fill in these values in the secrets, they will replace the corresponding named values in the appsettings.json

{
  "AppSettings": {
    "JwtSecret": "JWT Secret, recommend 32 bit random string"
  },
  "MailSettings": {
    "Password": "Password to your Mail Account"
  }
}

## Start App
Click start in visual studio

From command line, // TODO
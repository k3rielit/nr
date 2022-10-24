# NightRiderz API reversing
The goal is to provide documentation and a C# wrapper for the API.
## Auth: Basic
Send a request with this body to `https://api.nightriderz.world/gateway.php?contentType=application/json`:
```json
{
    "serviceName": "session",
    "methodName": "login",
    "parameters": [
        "email",
        "password",
        ""
    ]
}
```
The response contains two items if the credentials were correct (200), otherwise 401 Unauthorized:
  - `easharpptr_u` the auth token
  - `easharpptr_p` the main persona id
```json
{
    "easharpptr_u": "long.token.string",
    "easharpptr_p": "123456"
}
```
With these credentials included in the header, you can do a `{"serviceName": "session","methodName": "GetUserInfo"}` POST request to get other persona IDs.
Most of the methods require this header.

## C# Wrapper
To use the library, create a reference for it in the project, then it's accessible through the `LibNR` namespace.

Errors are handled, while returning objects with their default values (usually 0, false, empty string, empty list, 0001.01.01., etc). During the json parsing, properties with null values are skipped and the default values are being kept.

Data queries has the same structure as the original API. There are seperate classes for each services' methods. For example to login, or get user data, use the Session class:
```cs
using LibNR;

var token = await Session.Login("email","password");
var userInfo = await Session.GetUserInfo(token);
```

*Methods requiring auth instead of `(SessionLogin token)`, also accept `(int PersonaId, string Token)` parameters, to avoid making unnecessary objects when querying for alt personas for example.*

The NightRiderz project included in the solution contains more examples.
## TODO
- Create all the models for JSON serialization/deserialization
- Create an abstraction on top of the original data structures
- Improve exception handling, or make it optional
- config.json
- Livemap
- Check for duplicate properties
- Document methods
- Make a helper class to automate queries and IO
- Abstract request bodies into easy to create objects
- Maybe add a `bool WasSuccessfulQuery` property to every model

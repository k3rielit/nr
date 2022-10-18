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
To use the library, create a reference for it in the project.

Now it's accessible through the `LibNR` namespace. Currently only the raw data structures are being implemented under the `LibNR.RawClasses` namespace. Errors are handled and suppressed, while returning objects with their default values (usually empty strings/lists).

Right now, the queries has the same structure as the original API. There are seperate classes for each services' methods. For example to login, or get user data, use the Session class:
```cs
using LibNR;
using LibNR.RawClasses;

rSessionLogin token = await Session.Login("email","password");
rSessionUserInfo userInfo = await Session.GetUserInfo(token);
```

## TODO
- Create all the models for JSON serialization/deserialization
- Create an abstraction on top of the original data structures
- Improve exception handling, or make it optional
- Config.json
- Livemap

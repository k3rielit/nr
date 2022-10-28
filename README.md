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
The response contains two items if the credentials were correct (**200 OK**), otherwise nothing (**401 Unauthorized**):
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

The NightRiderz project included in the solution contains more examples.

### Queries

Data queries has the same structure as the original API. There are seperate classes for each services' methods. For example to login, or get user data, use the Session class:
```cs
using LibNR;

var token = await Session.Login("email","password");
var userInfo = await Session.GetUserInfo(token);
```

*Methods requiring auth instead of `(SessionLogin token)`, also accept `(int PersonaId, string Token)` parameters, to avoid making unnecessary objects when querying for alt personas for example.*

### Custom Queries

Custom queries are possible, with the `Utils.NrGet<T>()` and `Utils.NrSet<T>()` methods by providing a type, an `HttpMethod`, `RequestBody`/`PRequestBody`, and optionally auth:
```cs
var token = await Utils.NrGet<SessionLogin>(
    HttpMethod.Post,
    new PRequestBody {
        Service = "session",
        Method = "login",
        Params = { "email", "password", "" }
    }
) ?? new();
var activity = await Utils.NrGet<List<PlayerActivity>>(
    HttpMethod.Post,
    new PRequestBody {
        Service = "players",
        Method = "GetActivity",
        Params = { token.PersonaId }
    },
    token.PersonaId,
    token.Token
) ?? new();
```
*The `?? new()` is there to ensure it's not null, to provide a default value. The difference between `RequestBody` and `PRequestBody` is the Params extra property.*
## Todo
- Create all the models for JSON serialization/deserialization
- Improve exception handling, or make it optional to rethrow
- config.json
- Livemap
- Check for duplicate properties
- Document methods
- Make a helper class to automate queries and IO
- Maybe add a base class to all models with a `WasSuccessfulQuery` property, and `ToJson()` method
- Collect all the hashes
- Simplify PlayerActivity class
- Maybe an "X Y ago" DateTimeOffset parser
- Implement `Utils.NrSet(...)` method
- Changing name
- NuGet package (when it's done)
- Add async user activity observer, firing Events (event finish, challenge done, updated profile, etc)

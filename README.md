# NightRiderz API reversing
The goal is to provide documentation and a C# wrapper for the API.
## Auth: Basic
- Send a request with this request body:
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
- The response contains two items:
    - `easharpptr_u` the auth token
    - `easharpptr_p` the last persona id
```json
{
    "easharpptr_u": "long.token.string",
    "easharpptr_p": "123456"
}
```
- With these credentials, you can do a `{"serviceName": "session","methodName": "GetUserInfo"}` POST request to get other persona IDs.
- Include these in the header for future requests on protected methods.
## C# Wrapper
To use the library, create a reference for it in a project.

Now it's accessible through the `LibNR` namespace. The data models are inside the `LibNR.Data` namespace.

For now, every model has it's own `Create(...)` method, which interacts with the API, and returns an object with the same type. If the request fails, the object will keep its default property values.

Some properties might have a NULL value.

## TODO
- Move HTTP requests to a single standalone function
- Create all the models for JSON serialization/deserialization
- Config.json
- Livemap

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
    - `easharpptr_p` the user id
```json
{
    "easharpptr_u": "long.token.string",
    "easharpptr_p": "123456"
}
```
- Include these in the header for future requests on protected methods.
## TODO
- Create all the models for JSON serialization/deserialization
- Config.json
- Livemap

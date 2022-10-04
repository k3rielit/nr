# NightRiderz API reversing
## Auth: Basic
- Send a request with this request body:
```json
{
    "serviceName": "session",
    "methodName": "login",
    
}
```
- The response contains two items:
    - easharpptr_u: the auth token
    - easharpptr_p: the user id
- Include these in the header for future requests on protected methods.

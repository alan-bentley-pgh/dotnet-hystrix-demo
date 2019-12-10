# Hystrix Circuit Breaker Demo
Demo application to show Hystrix Circuit Breaker implementation.

## API Endpoint Call
```
GET http://localhost:5000/api/v1/Values/{name}
```

## Controlling Circuit Breaker
Under `HystrixCommands/MyCircuitBreakerCommand.cs`, comment line 21 (Exception throw) to close the circuit.  Or uncomment to open the circuit:

### Circuit closed:
```dotnet
protected override async Task<string> RunAsync()
        {
            //throw new Exception("testing RunFallbackAsync()");
            return await Task.FromResult("Hello " + _name);
        }
```

### Circuit opened:
```dotnet
protected override async Task<string> RunAsync()
        {
            throw new Exception("testing RunFallbackAsync()");
            return await Task.FromResult("Hello " + _name);
        }
```


## Ex Request:
```
GET http://localhost:5000/api/v1/Values/John
```

## Ex Response (circuit closed):
```
[
  "Hello John"
]
```

## Ex Response (circuit opened):
```
[
  "Hello John via fallback"
]
```
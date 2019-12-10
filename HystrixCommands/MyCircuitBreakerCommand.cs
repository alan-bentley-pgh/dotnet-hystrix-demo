using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Steeltoe.CircuitBreaker.Hystrix;
namespace CircuitBreakerDemo
{
    public interface IMyCircuitBreakerCommand
    {
        Task<string> GetMessage(string name);
    }
    public class MyCircuitBreakerCommand : HystrixCommand<string>, IMyCircuitBreakerCommand
    {
        private string _name;
        public MyCircuitBreakerCommand(): base(HystrixCommandGroupKeyDefault.AsKey("MyCircuitBreakerGroup"))
        {
            IsFallbackUserDefined = true;
        }
        protected override async Task<string> RunAsync()
        {
            throw new Exception("testing RunFallbackAsync()");
            return await Task.FromResult("Hello " + _name);
        }
        protected override async Task<string> RunFallbackAsync()
        {
            return await Task.FromResult("Hello " + _name + " via fallback");
        }

        public Task<string> GetMessage(String name)
        {
            _name = name;
            return this.ExecuteAsync();
        }
    }
}

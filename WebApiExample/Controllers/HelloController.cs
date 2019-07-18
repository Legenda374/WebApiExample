using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;
using WebApiExample.Dependencies;
using WebApiExample.Dependencies.Interface;

namespace WebApiExample.Controllers
{
    public class HelloController : ApiController
    {
        IGreeter _Greeter;
        public HelloController([Dependency("HelloGreeter")] IGreeter greeter)
        {
            _Greeter = greeter;
        }
        public string Get()
        {
            return _Greeter.SayHello();
        }
    }
}

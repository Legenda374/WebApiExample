using WebApiExample.Dependencies.Interface;

namespace WebApiExample.Dependencies
{
    public class Greeter : IGreeter
    {
        string _GreeteText;
        public Greeter(string greeteText)
        {
            _GreeteText = greeteText;
        }

        public string SayHello()
        {
            return _GreeteText;
        }
    }
}
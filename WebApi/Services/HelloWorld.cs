namespace WebApi.Services
{
    public class HelloWorldService : InterfaceHelloWorldService
    {
        public string GetHelloWorld()
        {
            return "Hola mundo";
        }
    }

    public interface InterfaceHelloWorldService
    {
        public string GetHelloWorld();
    }
}

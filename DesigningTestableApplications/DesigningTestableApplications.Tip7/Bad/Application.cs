namespace TestOrientedDevelopment.Tip7.Bad
{
    public class Application
    {
        public string Method()
        {
            return ThirdPartyLibrary.ThirdPartyLibrary.DoWork("Tip", 7);
        }
    }
}

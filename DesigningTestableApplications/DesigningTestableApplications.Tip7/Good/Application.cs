using TestOrientedDevelopment.Tip7.Good.Wrapper;

namespace TestOrientedDevelopment.Tip7.Good
{
    public class Application
    {
        public readonly IWrapper thirdPartyLibraryWrapper;

        public Application(IWrapper thirdPartyLibraryWrapper)
        {
            this.thirdPartyLibraryWrapper = thirdPartyLibraryWrapper;
        }

        public string Method()
        {
            return this.thirdPartyLibraryWrapper.DoWork("Tip", 7);
        }
    }
}

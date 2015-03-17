namespace DesigningTestableApplications.Tip7.Good.Wrapper
{
    public class Wrapper : IWrapper
    {
        public string DoWork(string param1, int param2)
        {
            return ThirdPartyLibrary.ThirdPartyLibrary.DoWork(param1, param2);
        }
    }
}

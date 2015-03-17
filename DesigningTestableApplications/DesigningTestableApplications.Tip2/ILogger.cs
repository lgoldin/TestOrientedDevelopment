using System;

namespace TestOrientedDevelopment.Tip2
{
    public interface ILogger
    {
        void LogMessage(string message);

        string[] GetLast10Messages();
    }
}

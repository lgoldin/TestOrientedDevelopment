using System;

namespace TestOrientedDevelopment.Tip1.Good
{
    public interface ILogger
    {
        void LogMessage(string message);

        string[] GetLast10Messages();
    }
}

using System.Collections.Generic;

namespace BankSolution
{
    public interface IAuditLogger
    {
        void AddMessage(string message);
        List<string> GetLog();
    }
}
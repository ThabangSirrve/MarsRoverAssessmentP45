using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverAssessment
{
    public interface IValidator
    {
        void InvalidInput(string input);
        void InvalidCommandLength(string input);
        void OutputError(string message);
    }
}

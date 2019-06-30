using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverAssessment
{
    public class PlateauValidation : IValidator
    {
        public void InvalidCommandLength(string input)
        {
            if (input.Split(' ').Length != 2)
                OutputError("Plateau only accepts 2 numeric numbers");
        }

        public void InvalidInput(string input)
        {
            string []coordinates = input.Split(' ');

            if (Convert.ToInt32(coordinates[0]) < 0 || Convert.ToInt32(coordinates[1]) < 0)
            {
                OutputError($"Cannot Initialize a Plateau with negative values : {input}");
            }
        }

        public void OutputError(string message)
        {
            throw new Exception(message);
        }
    }
}

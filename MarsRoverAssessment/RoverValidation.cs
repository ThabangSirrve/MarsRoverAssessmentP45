using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverAssessment
{
    public class RoverValidation : IValidator
    {
        public void InvalidCommandLength (string command)
        {
            //Check that there's only one instruction
            if(command.Split(' ').Length > 1)
            {
                OutputError($"Invalid Rover Command {command}");
            }
        }

        public void InvalidInput(string input)
        {
            OutputError($"Invalid Rover input {input}");
        }

        public bool IsValidPlaceMent(Plateau plateau, Point roverPosition)
        {
            if (plateau.EndPosition.X < roverPosition.X || plateau.EndPosition.Y < roverPosition.Y)
                OutputError($"Rover placed outside Plateau");

            return true;
        }
        public bool IsValidMove(Plateau plateau, Point roverPosition)
        {
            if (plateau.EndPosition.X < roverPosition.X || plateau.EndPosition.Y < roverPosition.Y)
                OutputError($"Rover is trying to move outside the Plateau");

            return true;
        }

        public void OutputError(string message)
        {
            throw new Exception(message);
        }
    }
}

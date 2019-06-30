using System;
using System.Collections.Generic;

namespace MarsRoverAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfRovers = 0;
            List<Rover> rovers = new List<Rover>();

            //Read upper-right coordinates of the plateau
            string plateauCoordinates = ProcessPlateauInfo();
            
            //Initialize Plateau
            Plateau plateau = new Plateau(plateauCoordinates);

           //Process number of Rovers
            numOfRovers = ProcessNoOfRoversInput();

            //Process info for each rover 
            for (int i = 0; i < numOfRovers; i++)
            {
                string position = "", instructions = "";

                ProcessRoverInformation(ref instructions,ref position,i);

                Rover rover = new Rover(position,plateau);
                rover.Explore(instructions);

                //Add Rover 
                rovers.Add(rover);
            }

            //Output 
            foreach (var rover in rovers)
            {
                Print(rover.RoverDestination());
            }

            Print("Enter any key to exit...");
            Console.ReadKey();
        }

        private static void ProcessRoverInformation(ref string instructions, ref string position, int i)
        {
            //Input 1 : Process Position of the rover 
            Print(string.Format("Enter start position for rover {0}", i + 1));
            position = Caputure();

            //Input 2 : Process instructions
            Print(string.Format("Enter instructions for Rover {0} ", i + 1));
            instructions = Caputure();

            new RoverValidation().InvalidCommandLength(instructions);
        }

        private static string ProcessPlateauInfo()
        {
            //Input Grid information
            Print("Enter upper-right coordinates of the plateau");
            string coordinates = Caputure();

            return coordinates;
        }

        private static int ProcessNoOfRoversInput()
        {
            Print("How many Rovers would you like to navigate the Plateau");
            int numOfRovers = Convert.ToInt32(Caputure());

            return numOfRovers;
        }

        private static void Print(string message)
        {
            Console.WriteLine(message);
        }

        private static string Caputure()
        {
            return Console.ReadLine();
        }
    }
}

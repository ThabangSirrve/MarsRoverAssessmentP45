using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverAssessment
{
    public class Rover
    {
        private const char LEFT = 'L';
        private const char RIGHT = 'R';

        public Point Position { get; set; }
        public char Direction { get; set; }

        public Rover(string position)
        {
            InitializeRover(position);
        }

        private void InitializeRover(string position)
        {
            string[] values = position.Split(' ');

            if(values.Length != 3)
            {
                Console.WriteLine("Invalid Input");
                Console.ReadKey();
                return;
            }

            int x = Convert.ToInt32(values[0]);
            int y = Convert.ToInt32(values[1]);
            char d = Convert.ToChar(values[2].ToUpper());
            
            Position = new Point(x, y);
            Direction = d;
        }

        public string RoverDestination()
        {
            return (Position.X + " " + Position.Y + " " + Direction);
        }

        public void Explore(string instructions)
        {
            //Command the rover 
            char[] Commands = (instructions.ToUpper()).ToCharArray();

            foreach(var command in Commands)
            {
                if(command.Equals('M'))
                    MoveRover();
                else
                    Direction = ChangeDirection(command);
            }
        }

        private char ChangeDirection(char letter)
        {
            //Initialize with default direction
            char updatedDirection = Direction;

            if(letter.Equals(LEFT))
            {
                switch (Direction)
                {
                    case 'N':
                        updatedDirection = 'W';
                        break;
                    case 'W':
                        updatedDirection = 'S';
                        break;
                    case 'S':
                        updatedDirection = 'E';
                        break;
                    case 'E':
                        updatedDirection = 'N';
                        break;
                }
            }
            else if(letter.Equals(RIGHT))
            {
                switch (Direction)
                {
                    case 'N':
                        updatedDirection = 'E';
                        break;
                    case 'E':
                        updatedDirection = 'S';
                        break;
                    case 'S':
                        updatedDirection = 'W';
                        break;
                    case 'W':
                        updatedDirection = 'N';
                        break;
                }
            }

            return updatedDirection;
        }

        private void MoveRover()
        {
            //Move Rover
            switch(Direction)
            {
                case 'E':
                    Position.X += 1;
                    break;
                case 'N':
                    Position.Y += 1;
                    break;
                case 'S':
                    Position.Y -= 1;
                    break;
                case 'W':
                    Position.X -= 1;
                    break;
            }
        }
    }
}
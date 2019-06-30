using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverAssessment
{
    public class Rover
    {
        public Point Position { get; set; }
        public char Direction { get; set; }
        private RoverValidation validator;
        private Plateau Plateau;

        public Rover(string position, Plateau plateau)
        {
            Plateau = plateau;
            validator = new RoverValidation();
            InitializeRover(position);
        }

        private void InitializeRover(string position)
        {
            string[] values = position.Split(' ');

            try
            {
                int x = Convert.ToInt32(values[0]);
                int y = Convert.ToInt32(values[1]);
                char d = Convert.ToChar(values[2].ToUpper());

                if (validator.IsValidPlaceMent(Plateau, new Point(x, y)))
                {
                    Position = new Point(x, y);
                    Direction = d;
                }
            }
            catch(Exception)
            {
                validator.OutputError("Invalid Commands");
            }
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
                if(command.Equals(Campass.MOVE))
                    MoveRover();
                else
                    Direction = ChangeDirection(command);
            }
        }

        private char ChangeDirection(char letter)
        {
            //Initialize with default direction
            char updatedDirection = Direction;

            if(letter.Equals(Campass.LEFT))
            {
                switch (Direction)
                {
                    case Campass.NORTH:
                        updatedDirection = Campass.WEST;
                        break;
                    case Campass.WEST:
                        updatedDirection = Campass.SOUTH;
                        break;
                    case Campass.SOUTH:
                        updatedDirection = Campass.EAST;
                        break;
                    case Campass.EAST:
                        updatedDirection = Campass.NORTH;
                        break;
                }
            }
            else if(letter.Equals(Campass.RIGHT))
            {
                switch (Direction)
                {
                    case Campass.NORTH:
                        updatedDirection = Campass.EAST;
                        break;
                    case Campass.EAST:
                        updatedDirection = Campass.SOUTH;
                        break;
                    case Campass.SOUTH:
                        updatedDirection = Campass.WEST;
                        break;
                    case Campass.WEST:
                        updatedDirection = Campass.NORTH;
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
                case Campass.EAST:
                    if(validator.IsValidMove(Plateau,new Point(Position.X + 1,Position.Y)))
                        Position.X += 1;
                    break;
                case Campass.NORTH:
                    if (validator.IsValidMove(Plateau, new Point(Position.X, Position.Y + 1)))
                        Position.Y += 1;
                    break;
                case Campass.SOUTH:
                    if (validator.IsValidMove(Plateau, new Point(Position.X, Position.Y -1)))
                        Position.Y -= 1;
                    break;
                case Campass.WEST:
                    if (validator.IsValidMove(Plateau, new Point(Position.X-1, Position.Y)))
                        Position.X -= 1;
                    break;
            }
        }
    }
}
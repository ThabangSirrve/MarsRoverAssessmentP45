using System;
using System .Collections.Generic;
using System.Text;

namespace MarsRoverAssessment
{
    public class Plateau
    {
        public readonly Point StartPosition;

        public readonly Point EndPosition;

        public Plateau(string plateauCoordinates)
        {
            //Validation
            string[] coordinates = plateauCoordinates.Split(' ');
            int x = Convert.ToInt32(coordinates[0]);
            int y = Convert.ToInt32(coordinates[1]);

            StartPosition = new Point(0, 0);
            EndPosition = new Point(x,y);
        }
    }
}

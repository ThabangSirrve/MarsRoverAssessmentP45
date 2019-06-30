using System;

namespace MarsRoverAssessment
{
    public class Plateau
    {
        public readonly Point StartPosition;
        public readonly Point EndPosition;
        private readonly PlateauValidation PlateauValidation;

        public Plateau(string plateauCoordinates)
        {
            //Validation
            PlateauValidation = new PlateauValidation();

            try
            {
                PlateauValidation.InvalidCommandLength(plateauCoordinates);

                string[] coordinates = plateauCoordinates.Split(' ');
                int x = Convert.ToInt32(coordinates[0]);
                int y = Convert.ToInt32(coordinates[1]);

                PlateauValidation.InvalidInput(plateauCoordinates);

                StartPosition = new Point(0, 0);
                EndPosition = new Point(x,y);
            }
            catch(Exception)
            {
                PlateauValidation.OutputError("Invalid Data format");
            }
        }
    }
}

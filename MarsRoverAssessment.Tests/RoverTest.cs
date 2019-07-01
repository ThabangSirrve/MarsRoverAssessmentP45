using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRoverAssessment.Tests
{
    public class RoverTest
    {
        [Fact]
        public void PlaceRover()
        {
            // Arrange
            Plateau plateau = new Plateau("5 5");
            Rover rover = new Rover("1 2 N", plateau);

            // Act
            rover.Explore("LMLMLMLMM");

            // Assert
            Assert.NotNull(rover);
            Assert.True((rover.Position.X < plateau.EndPosition.X && rover.Position.Y < plateau.EndPosition.Y));
            Assert.Equal("1 3 N", rover.RoverDestination());
        }
    }
}
using System;
using Xunit;

namespace MarsRoverAssessment.Tests
{
    public class PlateauTest
    {
        [Fact]
        public void CreatePlateau()
        {
            // Arrange
            Plateau plateau = new Plateau("5 5");

            // Act
            var startPosition = plateau.StartPosition;
            var endPosition = plateau.EndPosition;
           
            // Assert
            Assert.NotNull(startPosition);
            Assert.NotNull(endPosition);
            Assert.Equal("5",plateau.EndPosition.Y.ToString());
            Assert.Equal("5",plateau.EndPosition.X.ToString());
            Assert.True((endPosition.X > 0 && endPosition.Y > 0));
        }
    }
}

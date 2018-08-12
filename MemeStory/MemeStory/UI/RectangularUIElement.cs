using Microsoft.Xna.Framework;

namespace MemeStory.UI
{
    public abstract class RectangularUIElement
    {
        Vector2 TopLeftCoordinates;
        Vector2 Dimensions;

        public bool ContainsCoords(Vector2 coords)
        {
            return (
                coords.X >= TopLeftCoordinates.X &&
                coords.X < TopLeftCoordinates.X + Dimensions.X &&
                coords.Y >= TopLeftCoordinates.Y &&
                coords.Y < TopLeftCoordinates.Y + Dimensions.Y
            );
        }
    }
}

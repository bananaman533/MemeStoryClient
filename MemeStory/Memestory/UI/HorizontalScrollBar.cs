using System;
using Microsoft.Xna.Framework;

namespace MemeStory.UI
{
    public class HorizontalScrollBar : RectangularUIElement
    {
        bool isScrolling;

        public HorizontalScrollBar(Vector2 topLeftCoords, Vector2 dimensions) {
            TopLeftCoordinates = topLeftCoords;
            Dimensions = dimensions;
        }
        
    }
}

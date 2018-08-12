using Microsoft.Xna.Framework;

namespace MemeStory.UI
{
    // Parent class for absolute positioned UI elements, eg menus, scrollbars, etc.
    public abstract class UIElement
    {
        public int ZIndex // higher ZIndex is shown in front
        { get; set; }

        public abstract void Update();

        public abstract void Draw();

        public abstract bool ContainsCoords(Vector2 coords);

        public abstract void Hover(Vector2 mousePos);

        public abstract void LeftClick(Vector2 mousePos);
    }
}

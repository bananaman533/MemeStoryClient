using Microsoft.Xna.Framework;

namespace MemeStory.UI
{
    // Parent class for absolute positioned UI elements, eg menus, scrollbars, etc.
    public abstract class UIElement
    {
        public int ZIndex // higher ZIndex is shown in front
        { get; set; }

        public virtual void Update() {}

        public abstract void Draw();

        public abstract bool ContainsCoords(Vector2 coords);

        public virtual void Hover(Vector2 mousePos) {}

        public virtual void LeftClick(Vector2 mousePos) {}
    }
}

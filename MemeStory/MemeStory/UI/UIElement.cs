using System;

namespace MemeStory.UI
{
    public abstract class UIElement
    {
        public int ZIndex // higher ZIndex is shown in front
        { get; set; }

        public abstract void Update();

        public abstract void Draw();
    }
}

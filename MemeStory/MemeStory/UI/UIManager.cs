using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MemeStory.UI
{
    class UIManager
    {
        private List<UIElement> elements = new List<UIElement>();
        private ZIndexComparer zIndexComparer = new ZIndexComparer();

        public void AddElement(UIElement element)
        {
            int index = elements.BinarySearch(element, zIndexComparer);
            if (index < 0)
            {
                index = ~index;
            }
            elements.Insert(index, element);
        }

        public void Update()
        {
            MouseState state = Mouse.GetState();
        }

        public void Draw()
        {
            foreach (UIElement element in elements) {
                element.Draw();
            }
        }

        class ZIndexComparer : IComparer<UIElement>
        {
            public int Compare(UIElement e1, UIElement e2)
            {
                return e1.ZIndex.CompareTo(e2.ZIndex);
            }
        }
    }
}

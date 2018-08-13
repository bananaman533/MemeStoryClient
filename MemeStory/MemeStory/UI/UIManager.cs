using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MemeStory.UI
{
    class UIManager
    {
        public static UIManager Instance { get; set; }
        
        List<UIElement> elements = new List<UIElement>();
        ZIndexComparer zIndexComparer = new ZIndexComparer();

        public UIManager() {
            if (Instance != null) {
                throw (new System.Exception("UIManager was instantiated twice!"));
            }
            Instance = this;
        }

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

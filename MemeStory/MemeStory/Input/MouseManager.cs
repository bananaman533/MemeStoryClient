using Microsoft.Xna.Framework.Input;
using System;

namespace MemeStory.Input
{
    public sealed class MouseManager
    {
        public static MouseManager Instance { get; set; } = null;

        public event EventHandler<LeftPressEventArgs> OnLeftPress;
        public event EventHandler<LeftReleaseEventArgs> OnLeftRelease;
        public event EventHandler<MoveEventArgs> OnMove;
        private MouseState oldState;

        public MouseManager()
        {
            if (Instance != null)
            {
                throw (new System.Exception("MouseManager was instantiated twice!"));
            }
            Instance = this;
        }

        public void Update()
        {
            MouseState newState = Mouse.GetState();
            if (oldState == null)
            {
                oldState = newState;
                return;
            }
            if (newState.X != oldState.X || newState.Y != oldState.Y)
            {
                OnMove(this, new MoveEventArgs());
            }
            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                OnLeftPress(this, new LeftPressEventArgs());
            }
            if (newState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
            {
                OnLeftRelease(this, new LeftReleaseEventArgs());
            }
        }

        public Action SubscribeLeftPress(Func<object, LeftPressEventArgs> handler)
        {
            OnLeftPress += handler;
            return () => { OnLeftPress -= handler; };
        }

        public Action SubscribeLeftRelease(EventHandler<LeftReleaseEventArgs> handler)
        {
            OnLeftRelease += handler;
            return () => { OnLeftRelease -= handler; };
        }

        public Action SubscribeMove(EventHandler<MoveEventArgs> handler)
        {
            OnMove += handler;
            return () => { OnMove -= handler; };
        }
    }

    public class LeftPressEventArgs : EventArgs {}
    public class LeftReleaseEventArgs : EventArgs {}
    public class MoveEventArgs : EventArgs {}
}

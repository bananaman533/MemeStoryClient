using Microsoft.Xna.Framework.Input;
using System;

namespace MemeStory.Input
{
    public sealed class MouseManager
    {
        public static MouseManager Instance { get; set; } = null;

        public event EventHandler<MouseLeftPressEventArgs> OnLeftPress;
        public event EventHandler<MouseLeftReleaseEventArgs> OnLeftRelease;
        public event EventHandler<MouseMoveEventArgs> OnMove;
        public MouseState State;

        MouseState oldState;

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
            State = Mouse.GetState();
            if (oldState == null)
            {
                oldState = State;
                return;
            }
            if (OnMove != null && 
                (State.X != oldState.X || State.Y != oldState.Y)
            ) {
                OnMove(this, new MouseMoveEventArgs());
            }
            if (OnLeftPress != null && 
                (State.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            ) {
                OnLeftPress(this, new MouseLeftPressEventArgs());
            }
            if (OnLeftRelease != null && 
                (State.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
            ) {
                OnLeftRelease(this, new MouseLeftReleaseEventArgs());
            }
            oldState = State;
        }

        public Action SubscribeMouseLeftPress(EventHandler<MouseLeftPressEventArgs> handler)
        {
            OnLeftPress += handler;
            return () => { OnLeftPress -= handler; };
        }

        public Action SubscribeMouseLeftRelease(EventHandler<MouseLeftReleaseEventArgs> handler)
        {
            OnLeftRelease += handler;
            return () => { OnLeftRelease -= handler; };
        }

        public Action SubscribeMouseMove(EventHandler<MouseMoveEventArgs> handler)
        {
            OnMove += handler;
            return () => { OnMove -= handler; };
        }
    }

    public class MouseLeftPressEventArgs : EventArgs {}
    public class MouseLeftReleaseEventArgs : EventArgs {}
    public class MouseMoveEventArgs : EventArgs {}
}

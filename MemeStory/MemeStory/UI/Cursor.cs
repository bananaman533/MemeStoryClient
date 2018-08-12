using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MemeStory.UI
{
    public class Cursor
    {
        SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 position;

        public Cursor(SpriteBatch spriteBatch, Texture2D texture)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;
        }

        public void Update()
        {
            MouseState state = Mouse.GetState();
            position.X = state.X;
            position.Y = state.Y;
        }

        public void Draw() {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}

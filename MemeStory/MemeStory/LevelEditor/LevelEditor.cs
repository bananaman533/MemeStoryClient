using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MemeStory.UI;

namespace MemeStory.LevelEditor
{
    public class LevelEditor : Game
    {
        public const int LevelViewWidth = 800;
        public const int LevelViewHeight = 800;
        public const int MenuWidth = 300;
        public const int ScrollBarWidth = 20;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Cursor cursor;

        public LevelEditor()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = LevelViewWidth + MenuWidth + ScrollBarWidth * 2;
            graphics.PreferredBackBufferHeight = LevelViewHeight + ScrollBarWidth;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            cursor = new Cursor(spriteBatch, Content.Load<Texture2D>("cursor"));
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            cursor.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            cursor.Draw();
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

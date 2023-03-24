using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Multirinth
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D character;
        private Texture2D background;
        private Rectangle bgPos;
        private Rectangle cPos;
        private KeyboardState oldKB;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            cPos = new Rectangle(315, 300, 100, 150);
            bgPos = new Rectangle(0, 0, 800, 500);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            character = Content.Load<Texture2D>("character");
            background = Content.Load<Texture2D>("cave");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState kb = Keyboard.GetState();
            if (kb.IsKeyDown(Keys.Left) && !kb.IsKeyDown(Keys.Up) && !kb.IsKeyDown(Keys.Down) && cPos.X > -40)
            {
               
                cPos.X -= 5;
            }
            if (kb.IsKeyDown(Keys.Right) && !kb.IsKeyDown(Keys.Up) && !kb.IsKeyDown(Keys.Down) && cPos.X < 760)
            {
                cPos.X += 5;
                
            }
            oldKB = kb;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            System.Diagnostics.Debug.WriteLine(cPos);
            _spriteBatch.Draw(background, bgPos, Color.White);
            _spriteBatch.Draw(character, cPos, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
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
        private Texture2D characterRight;
        private Texture2D characterLeft;
        private Texture2D background;
        private Rectangle bgPos;
        private Rectangle cPos;
        private Texture2D fireball;
        private Rectangle fPos;
        private int velocity;
        private KeyboardState oldKB;
        SpriteFont font;
        Vector2 textPos;
        string label;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.PreferredBackBufferWidth = 1400;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.ApplyChanges();
            this.Window.AllowUserResizing = true;       
            IsMouseVisible = true;
            
            cPos = new Rectangle(700, 550, 200, 250);
            bgPos = new Rectangle(0, 0, 1400, 800);
            fPos = new Rectangle(9000, 9000, 50, 50);

            textPos = new Vector2(200, 100);
            label = "Score: ";


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
            characterRight = Content.Load<Texture2D>("character");
            characterLeft = Content.Load<Texture2D>("characterL");
            background = Content.Load<Texture2D>("cave");
            fireball = Content.Load<Texture2D>("energyball");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState kb = Keyboard.GetState();

            
            if (kb.IsKeyDown(Keys.Left) && !kb.IsKeyDown(Keys.Up) && !kb.IsKeyDown(Keys.Down))
            {
                character = characterLeft;
                cPos.X -= 5;
                velocity = -5;
            }
            if (kb.IsKeyDown(Keys.Right) && !kb.IsKeyDown(Keys.Up) && !kb.IsKeyDown(Keys.Down))
            {
                character = characterRight;
                cPos.X += 5;
                velocity = 5;

            }

            if (kb.IsKeyDown(Keys.Space) && fPos.X > 1400)
            {
                fPos.X = cPos.X + 90;
                fPos.Y = cPos.Y + 110;

            }

            else if ((kb.IsKeyDown(Keys.Space) && fPos.X < 0)) 
            {
                fPos.X = cPos.X + 90;
                fPos.Y = cPos.Y + 110;
            }



            fPos.X += velocity;
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
            _spriteBatch.Draw(fireball, fPos, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
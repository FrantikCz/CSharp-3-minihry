using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D squareTexture;
        private Vector2 squarePosition;
        private float squareSpeed = 200f;

        private int windowWidth;
        private int windowHeight;

        private const int squareSize = 20;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 400;
            _graphics.ApplyChanges();

            windowWidth = _graphics.PreferredBackBufferWidth;
            windowHeight = _graphics.PreferredBackBufferHeight;

            squarePosition = new Vector2(100, windowHeight / 2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            squareTexture = new Texture2D(GraphicsDevice, 1, 1);
            squareTexture.SetData(new[] { Color.White });

        }

        protected override void Update(GameTime gameTime)
        {
            

            var k = Keyboard.GetState();
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //pohyb čtverce
            if (k.IsKeyDown(Keys.W)) squarePosition.Y -= squareSpeed * dt;
            if (k.IsKeyDown(Keys.S)) squarePosition.Y += squareSpeed * dt;
            if (k.IsKeyDown(Keys.A)) squarePosition.X -= squareSpeed * dt;
            if (k.IsKeyDown(Keys.D)) squarePosition.X += squareSpeed * dt;

            squarePosition.X = MathHelper.Clamp(squarePosition.X, 0, windowWidth - 20);
            squarePosition.Y = MathHelper.Clamp(squarePosition.Y, 0, windowHeight - 20);

            // kolize se zrcadlem
            float mirrorX = windowWidth / 2f;
            if (squarePosition.X + squareSize > mirrorX)
            {
                // pokud hráč narazí na zrcadlo, zastaví se
                squarePosition.X = mirrorX - squareSize;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(squareTexture, new Rectangle((int)squarePosition.X, (int)squarePosition.Y, 20, 20), Color.Blue);

            //zrcadlový čtverec

            float mirrorX = windowWidth - (squarePosition.X + 20);
            _spriteBatch.Draw(squareTexture, new Rectangle((int)mirrorX, (int)squarePosition.Y, 20, 20), Color.Gray);

            _spriteBatch.Draw(squareTexture, new Rectangle(windowWidth / 2, 0, 2, windowHeight), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

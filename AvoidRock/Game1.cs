using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AvoidRock
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public StartScene startScene;
        public PlayScene playGame;
        public GameOverScene gameOverScene;
        public HighScoreScene highScoreScene;

        private double timer = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth,
            graphics.PreferredBackBufferHeight);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            startScene = new StartScene(this);
            this.Components.Add(startScene);
            startScene.show();

            playGame = new PlayScene(this);
            this.Components.Add(playGame);

            gameOverScene = new GameOverScene(this);
            this.Components.Add(gameOverScene);

            highScoreScene = new HighScoreScene(this);
            this.Components.Add(highScoreScene);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            int selectedIndex = 0;

            KeyboardState ks = Keyboard.GetState();
            if (startScene.Enabled)
            {
                timer += (double)gameTime.ElapsedGameTime.TotalSeconds;
                selectedIndex = startScene.Menu.SelectedIndex;

                if (timer > 0.3)
                {
                    if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                    {
                        playGame.show();
                        startScene.hide();
                        timer = 0;
                    }


                    else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                    {
                        highScoreScene.show();
                        startScene.hide();
                        timer = 0;
                    }

                    else if (selectedIndex == 4 && ks.IsKeyDown(Keys.Enter))
                    {
                        Exit();
                    }
                }
            }

            else if (playGame.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    playGame.hide();
                    startScene.show();
                }
            }

            else if (highScoreScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    highScoreScene.hide();
                    startScene.show();
                }
            }

            else if (gameOverScene.Enabled)
            {
                this.Components.Remove(playGame);
                playGame = new PlayScene(this);
                this.Components.Add(playGame);

                this.Components.Remove(startScene);
                startScene = new StartScene(this);
                this.Components.Add(startScene);

                int gameOverSelectedIndex = 0;

                gameOverSelectedIndex = gameOverScene.Menu.SelectedIndex;
                if (gameOverSelectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    Shared.alive = true;
                    Shared.level = 1;

                    gameOverScene.hide();
                    playGame.show();
                }

                else if (gameOverSelectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    Shared.alive = true;
                    Shared.level = 1;

                    gameOverScene.hide();
                    startScene.show();
                }

                else if (gameOverSelectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }

            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

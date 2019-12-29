using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidRock
{
public class GameOverScene : Scenes
    {
        private SpriteBatch spriteBatch;
        private Game1 g;
        private SpriteFont font;
        private Vector2 position = new Vector2(Shared.stage.X/2, Shared.stage.Y/2);
        private Vector2 gameOverPosition = new Vector2(Shared.stage.X/2 - 45, Shared.stage.Y / 4);
        private Vector2 fontSize;
        private Vector2 levelFontSize;
        private Vector2 OverFontSize;
        private string message;
        private string levelMessage;
        private GameOverSceneMenu gameOverSceneMenu;

        private string[] menuItems =
        { "Play Again",
            "Go back to Menu",
                "Quit"
         };

        public GameOverScene(Game game) : base(game)
        {
            g = (Game1)game;

            this.spriteBatch = g.spriteBatch;
            this.font = g.Content.Load<SpriteFont>("font/MyFont");
            this.message = "Your Score is " + Shared.gameScore.ToString() + "!";
            this.levelMessage = "Level: " + Shared.level.ToString();
            fontSize = font.MeasureString(message);
            levelFontSize = font.MeasureString(levelMessage);
            OverFontSize = font.MeasureString("Game Over!");

            SpriteFont regularFont = g.Content.Load<SpriteFont>("font/RegularFont");
            SpriteFont hilightFont = g.Content.Load<SpriteFont>("font/HilightFont");
            gameOverSceneMenu = new GameOverSceneMenu(game, spriteBatch, regularFont, hilightFont, menuItems);
            this.Components.Add(gameOverSceneMenu);
        }

        public GameOverSceneMenu Menu { get => gameOverSceneMenu; set => gameOverSceneMenu = value; }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(g.Content.Load<SpriteFont>("font/gameOverFont"),
                "Game Over!", new Vector2 (gameOverPosition.X - OverFontSize.X/2,
                gameOverPosition.Y), Color.Red);
            spriteBatch.DrawString(font, message, new Vector2(position.X - fontSize.X/2 , position.Y - fontSize.Y/2), Color.Black);
            spriteBatch.DrawString(font, levelMessage, new Vector2(position.X - levelFontSize.X /2, position.Y - levelFontSize.Y / 2 + 30), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            this.message = "Your Score is " + Shared.gameScore.ToString() + "!";

            this.levelMessage = "Level: " + Shared.level.ToString();
            fontSize = font.MeasureString(message);
            base.Update(gameTime);
        }
    }
}

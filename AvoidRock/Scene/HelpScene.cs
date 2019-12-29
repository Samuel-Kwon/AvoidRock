using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidRock
{
    public class HelpScene : Scenes
    {
        private SpriteBatch spriteBatch;
        private Game1 g;
        private SpriteFont font;
        private Vector2 position = new Vector2(Shared.stage.X / 2, Shared.stage.Y / 2);
        private string message;
        private Vector2 fontSize;

        public HelpScene(Game game) : base(game)
        {
            g = (Game1)game;

            this.spriteBatch = g.spriteBatch;
            this.font = g.Content.Load<SpriteFont>("font/MyFont");
            this.message = "The purpose of this game is very simple. Survive Longer!" + "\r\n" +
                "You can move your Hero with arrow key pad, try not to get hit by the rock!" + "\r\n" +
                "If you survived more than 20 secs, you will be entered to level 2 where rocks shoots more frequntly." + "\r\n" +
                "Your survived time is your score, and it will be displayed on the top left corner while you playing.";
            fontSize = font.MeasureString(message);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, message, new Vector2(position.X - fontSize.X / 2, position.Y - fontSize.Y / 2), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}

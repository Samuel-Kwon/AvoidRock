using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidRock
{
    public class Level : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private Vector2 position;
        private string message = "Level: " + Shared.level.ToString();
        private Color color;

        public Level(Game game, SpriteBatch spriteBatch, SpriteFont font,
            Color color) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.position = new Vector2(Shared.stage.X - 100, 0); ;
            this.color = color;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, message, position, color);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            message = "Level: " + Shared.level.ToString();

            base.Update(gameTime);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidRock
{
    public class Score : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private Vector2 position;
        private double score;
        private Color color;

        public Score(Game game, SpriteBatch spriteBatch, SpriteFont font,
            Vector2 position, double score, Color color) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.position = position;
            this.score = score;
            this.color = color;
        }

        public double GameScore { get => score; set => score = value; }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, score.ToString("0.00"), position, color);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (Shared.alive)
            {
                score += (double)gameTime.ElapsedGameTime.TotalSeconds;
            }

            else
            {
                Shared.gameScore = score;
            }

            base.Update(gameTime);
        }
    }
}

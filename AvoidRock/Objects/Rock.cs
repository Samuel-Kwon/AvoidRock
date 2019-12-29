using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidRock
{
    class Rock : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 initialPosition;
        private Vector2 position;
        private Vector2 heroPosition;
        private Vector2 towardHero;
        private Game1 g;

        private Vector2 stage;
        private Hero hero;

        public Rock(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Vector2 heroPosition,
            Vector2 towardHero,
            Vector2 stage,
            Hero hero) : base(game)
        {
            g = (Game1)game;

            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.initialPosition = position;
            this.heroPosition = heroPosition;
            this.towardHero = towardHero;
            this.stage = stage;
            this.hero = hero;
        }

        public Vector2 HeroPosition { get => heroPosition; set => heroPosition = value; }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            position += towardHero / 100;

            Rectangle heroRect = hero.getBound();
            Rectangle rockRect = getBound();

            if (heroRect.Intersects(rockRect))
            {
                Shared.alive = false;
            }

            base.Update(gameTime);
        }

        public Rectangle getBound()
        {
            return new Rectangle((int)position.X, (int)position.Y,
                tex.Width, tex.Height);
        }
    }
}

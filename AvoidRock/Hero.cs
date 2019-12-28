using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidRock
{
    public class Hero : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;

        private Vector2 stage;

        public Vector2 Position { get => position; set => position = value; }

        public Hero(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Vector2 stage) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.stage = stage;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Right))
            {
                position.X += 5;
            }

            if (ks.IsKeyDown(Keys.Left))
            {
                position.X -= 5;
            }

            if (ks.IsKeyDown(Keys.Up))
            {
                position.Y -= 5;
            }

            if (ks.IsKeyDown(Keys.Down))
            {
                position.Y += 5;
            }

            if (position.X < 0)
            {
                position.X = 0;
            }

            if (position.X + tex.Width > stage.X)
            {
                position.X = stage.X - tex.Width;
            }

            if (position.Y < 0)
            {
                position.Y = 0;
            }

            if (position.Y + tex.Height > stage.Y)
            {
                position.Y = stage.Y - tex.Height;
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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidRock
{
    public class PlayScene : Scenes
    {
        private SpriteBatch spriteBatch;
        SpriteFont font;

        public bool alive = true;

        Game1 g;

        public double rockShootingSec = 2;
        public double rockLevelOneSpeed = 1.5;
        public double rockLevelTwoSpeed = 1;
        double timer = 0;

        private Hero hero;
        private Rock rock;
        private Score score;
        private Level level;

        public PlayScene(Game game) : base(game)
        {
            g = (Game1)game;

            this.spriteBatch = g.spriteBatch;

            Texture2D heroTex = g.Content.Load<Texture2D>("image/hero");
            Vector2 stage = new Vector2(Shared.stage.X,
                Shared.stage.Y);
            Vector2 heroInitPos = new Vector2(stage.X / 2 - heroTex.Width / 2,
                    stage.Y / 2 - heroTex.Height / 2);

            hero = new Hero(g, spriteBatch, heroTex, heroInitPos, stage);
            this.Components.Add(hero);

            //Score
            font = g.Content.Load<SpriteFont>("font/MyFont");
            Vector2 scorePosition = new Vector2(0, 0);
            score = new Score(g, spriteBatch, font, scorePosition, timer, Color.White);
            this.Components.Add(score);

            //Level
            font = g.Content.Load<SpriteFont>("font/MyFont");
            level = new Level(g, spriteBatch, font, Color.White);
            this.Components.Add(level);

            //Rock
            Texture2D rockTex = g.Content.Load<Texture2D>("image/rock");
            Vector2 RockStage = new Vector2(Shared.stage.X,
                Shared.stage.Y);
            Vector2 rockInitPos = new Vector2(0 - rockTex.Width, 0 - rockTex.Height);
            Vector2 heroPosition = hero.Position;
            Vector2 towardHero = new Vector2(hero.Position.X - rockInitPos.X, hero.Position.Y - rockInitPos.Y);

            rock = new Rock(g, spriteBatch, rockTex, rockInitPos, heroPosition, towardHero, RockStage, hero);
            this.Components.Add(rock);

            rockInitPos = new Vector2(Shared.stage.X / 2, 0 - rockTex.Height);
            towardHero = new Vector2(hero.Position.X - rockInitPos.X, hero.Position.Y - rockInitPos.Y);

            rock = new Rock(g, spriteBatch, rockTex, rockInitPos, heroPosition, towardHero, RockStage, hero);
            this.Components.Add(rock);

            rockInitPos = new Vector2(Shared.stage.X, 0 - rockTex.Height);
            towardHero = new Vector2(hero.Position.X - rockInitPos.X, hero.Position.Y - rockInitPos.Y);

            rock = new Rock(g, spriteBatch, rockTex, rockInitPos, heroPosition, towardHero, RockStage, hero);
            this.Components.Add(rock);

            rockInitPos = new Vector2(0, Shared.stage.Y / 2 - rockTex.Height);
            towardHero = new Vector2(hero.Position.X - rockInitPos.X, hero.Position.Y - rockInitPos.Y);

            rock = new Rock(g, spriteBatch, rockTex, rockInitPos, heroPosition, towardHero, RockStage, hero);
            this.Components.Add(rock);

            rockInitPos = new Vector2(Shared.stage.X, Shared.stage.Y / 2 - rockTex.Height);
            towardHero = new Vector2(hero.Position.X - rockInitPos.X, hero.Position.Y - rockInitPos.Y);

            rock = new Rock(g, spriteBatch, rockTex, rockInitPos, heroPosition, towardHero, RockStage, hero);
            this.Components.Add(rock);

            rockInitPos = new Vector2(0, Shared.stage.Y - rockTex.Height);
            towardHero = new Vector2(hero.Position.X - rockInitPos.X, hero.Position.Y - rockInitPos.Y);

            rock = new Rock(g, spriteBatch, rockTex, rockInitPos, heroPosition, towardHero, RockStage, hero);
            this.Components.Add(rock);

            rockInitPos = new Vector2(Shared.stage.X / 2, Shared.stage.Y - rockTex.Height);
            towardHero = new Vector2(hero.Position.X - rockInitPos.X, hero.Position.Y - rockInitPos.Y);

            rock = new Rock(g, spriteBatch, rockTex, rockInitPos, heroPosition, towardHero, RockStage, hero);
            this.Components.Add(rock);

            rockInitPos = new Vector2(Shared.stage.X, Shared.stage.Y - rockTex.Height);
            towardHero = new Vector2(hero.Position.X - rockInitPos.X, hero.Position.Y - rockInitPos.Y);

            rock = new Rock(g, spriteBatch, rockTex, rockInitPos, heroPosition, towardHero, RockStage, hero);
            this.Components.Add(rock);
        }

        public override void Update(GameTime gameTime)
        {
            rock.HeroPosition = hero.Position;

            if (Shared.alive == true)
            {
                if (score.GameScore > 20)
                {
                    Shared.level = 2;
                }

                if (score.GameScore > rockShootingSec && score.GameScore < rockShootingSec + 0.1)
                {
                    Texture2D rockTex = g.Content.Load<Texture2D>("image/rock");
                    Vector2 RockStage = new Vector2(Shared.stage.X,
                        Shared.stage.Y);
                    Vector2 rockInitPos = new Vector2(0 - rockTex.Width, 0 - rockTex.Height);
                    Vector2 heroPosition = hero.Position;
                    Vector2 towardHero = new Vector2(hero.Position.X - rockInitPos.X, hero.Position.Y - rockInitPos.Y);
                    Vector2 rockSpeed = new Vector2(4, 0);

                    rock = new Rock(g, spriteBatch, rockTex, rockInitPos, heroPosition, towardHero, RockStage, hero);
                    this.Components.Add(rock);

                    rockInitPos = new Vector2(Shared.stage.X / 2, 0 - rockTex.Height);
                    towardHero = new Vector2(hero.Position.X - rockInitPos.X, hero.Position.Y - rockInitPos.Y);

                    rock = new Rock(g, spriteBatch, rockTex, rockInitPos, heroPosition, towardHero, RockStage, hero);
                    this.Components.Add(rock);

                    rockInitPos = new Vector2(Shared.stage.X, 0 - rockTex.Height);
                    towardHero = new Vector2(hero.Position.X - rockInitPos.X, hero.Position.Y - rockInitPos.Y);

                    rock = new Rock(g, spriteBatch, rockTex, rockInitPos, heroPosition, towardHero, RockStage, hero);
                    this.Components.Add(rock);

                    rockInitPos = new Vector2(0, Shared.stage.Y / 2 - rockTex.Height);
                    towardHero = new Vector2(hero.Position.X - rockInitPos.X, hero.Position.Y - rockInitPos.Y);

                    rock = new Rock(g, spriteBatch, rockTex, rockInitPos, heroPosition, towardHero, RockStage, hero);
                    this.Components.Add(rock);

                    rockInitPos = new Vector2(Shared.stage.X, Shared.stage.Y / 2 - rockTex.Height);
                    towardHero = new Vector2(hero.Position.X - rockInitPos.X, hero.Position.Y - rockInitPos.Y);

                    rock = new Rock(g, spriteBatch, rockTex, rockInitPos, heroPosition, towardHero, RockStage, hero);
                    this.Components.Add(rock);

                    rockInitPos = new Vector2(0, Shared.stage.Y - rockTex.Height);
                    towardHero = new Vector2(hero.Position.X - rockInitPos.X, hero.Position.Y - rockInitPos.Y);

                    rock = new Rock(g, spriteBatch, rockTex, rockInitPos, heroPosition, towardHero, RockStage, hero);
                    this.Components.Add(rock);

                    rockInitPos = new Vector2(Shared.stage.X / 2, Shared.stage.Y - rockTex.Height);
                    towardHero = new Vector2(hero.Position.X - rockInitPos.X, hero.Position.Y - rockInitPos.Y);

                    rock = new Rock(g, spriteBatch, rockTex, rockInitPos, heroPosition, towardHero, RockStage, hero);
                    this.Components.Add(rock);

                    rockInitPos = new Vector2(Shared.stage.X, Shared.stage.Y - rockTex.Height);
                    towardHero = new Vector2(hero.Position.X - rockInitPos.X, hero.Position.Y - rockInitPos.Y);

                    rock = new Rock(g, spriteBatch, rockTex, rockInitPos, heroPosition, towardHero, RockStage, hero);
                    this.Components.Add(rock);

                    if (Shared.level == 1)
                    {
                        rockShootingSec += rockLevelOneSpeed;
                    }

                    else
                    {
                        rockShootingSec += rockLevelTwoSpeed;
                    }
                }
            }

            else
            {
                g.gameOverScene.show();
                this.hide();
            }


            base.Update(gameTime);
        }
    }
}


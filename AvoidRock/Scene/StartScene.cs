using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidRock
{
    public class StartScene : Scenes
    {
        private StartSceneMenu menu;
        private SpriteBatch spriteBatch;
        private string[] menuItems =
            { "Play",
            "High Score",
            "Help",
            "About",
                "Quit"
        };

        public StartScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            SpriteFont regularFont = g.Content.Load<SpriteFont>("font/RegularFont");
            SpriteFont hilightFont = g.Content.Load<SpriteFont>("font/HilightFont");
            menu = new StartSceneMenu(game, spriteBatch, regularFont, hilightFont, menuItems);
            this.Components.Add(menu);
        }

        public StartSceneMenu Menu { get => menu; set => menu = value; }
    }
}

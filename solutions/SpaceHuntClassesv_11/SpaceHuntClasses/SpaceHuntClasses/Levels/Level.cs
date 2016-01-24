using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceHuntClasses.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Levels
{
    public class Level
    {
        public GameMode gameMode;
        private List<GameData> gameDatas;
        public Texture2D menuTexture;
        public Texture2D gameTexture;
        public int index { get; private set; }
        public string Story { get; private set; }
        public bool IsLocked { get; private set; }       
        public string Name { get; private set; }

        
        public Level(string story, int index, string name, bool isLocked)
        {
            this.Story = story;
            this.index = index;
            this.Name = name;
            this.IsLocked = isLocked;
        }

        public void LoadMenuTexture(ContentManager cm)
        {
            menuTexture = cm.Load<Texture2D>("textures/buttons/" + Name + "Button");
        }

        public void LoadGameTexture(ContentManager cm)
        {
            gameTexture = cm.Load<Texture2D>("textures/backgrounds/lvlBackgrounds/" + Name + "Background");
        }

        public void UnLock()
        {
            IsLocked = false;
        }

        public void AddGameData(GameData gameData)
        {
            gameDatas.Add(gameData);

            gameMode = Utility.GetHighestGameMode(gameMode, gameData.gameMode);
        }

        //public string GetHighestGameModeName()
        //{
        //    if()
        //}
        
    }
}

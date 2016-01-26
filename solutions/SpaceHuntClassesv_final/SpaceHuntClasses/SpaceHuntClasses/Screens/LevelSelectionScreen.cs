using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceHuntClasses.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceHuntClasses.Shapes.Buttons;
using SpaceHuntClasses.Buttons;
using SpaceHuntClasses.Levels;

namespace SpaceHuntClasses.Shapes
{
    public enum GameMode {Easy, Medium, Hard}

    class LevelSelectionScreen : IScreen
    {
        private Main main;
        private GameMode gameMode;

        private List<ButtonLevel> unlockedLevels;
        private List<LockedLevelShape> lockedLevels;

        private Shape tvShape;
        private Shape backgroundShape;

        private ButtonCheckBox easyButton;
        private ButtonCheckBox mediumButton;
        private ButtonCheckBox hardButton;
        
        private Texture2D easyButtonTexture;
        private Texture2D mediumButtonTexture;
        private Texture2D hardButtonTexture;
        private Texture2D startTexture;
        private Texture2D lockedTexture;

        private Texture2D earthTexture;
        private Texture2D marsTexture;
        private Texture2D venusTexture;
        private Texture2D neptuneTexture;
        private Texture2D mercuryTexture;
        private Texture2D erisTexture;

        private Texture2D backgroundTexture;
        private Texture2D tvTexture;


        public LevelSelectionScreen(Main main, GraphicsInfos graphics)
        {
            this.main = main;
            LoadContent();
            Initialize(graphics);
        }

        public void Initialize(GraphicsInfos graphics)
        {
            LoadContent();

            
            easyButton = new ButtonCheckBox(graphics, easyButtonTexture, new Rectangle(0, 0, 0, 0), false);
            easyButton.rectangle = new Rectangle(1500, 100, 300, 200);
            easyButton.Release += EasyButtonOnRelease;

            mediumButton = new ButtonCheckBox(graphics, mediumButtonTexture, new Rectangle(0, 0, 0, 0), false);
            mediumButton.rectangle = new Rectangle(1500, 400, 300, 200);
            mediumButton.Release += MediumButtonOnRelease;

            hardButton = new ButtonCheckBox(graphics, hardButtonTexture, new Rectangle(0, 0, 0, 0), false);
            hardButton.rectangle = new Rectangle(1500, 700, 300, 200);
            hardButton.Release += HardButtonOnRelease;

            backgroundShape = new Shape(graphics, backgroundTexture, new Rectangle(0, 0, 100, 100));
            tvShape = new Shape(graphics, tvTexture,new Rectangle(0, 0, 100, 100));

            //LEVELS BUTTON
            lockedLevels = new List<LockedLevelShape>();
            unlockedLevels = new List<ButtonLevel>();

            var levels = main.levels.GetArray();

            for(int i = 0; i < levels.Count();i++)
            {
                int x = 1;
                int y = 1;

                if (i + 1 > 3)
                    y = 2;

                x = (i + 1) / y;

                var r = new Rectangle((x - 1)* 25 + 5, (y - 1) * 37 + 5, 20, 30);
                var r2 = new Rectangle((x  - 1)* 25 + 5, (y - 1) * 37 + 5, 20, 30);

                if(!levels[i].IsLocked) //if level is not lock
                {
                    unlockedLevels.Add(new ButtonLevel(graphics, r, levels[i], startTexture, main.fontSize14, main.fontSize10, GetLevelsTexture()[i]));
                    unlockedLevels.Last<ButtonLevel>().StartGame += StartGame;
                    unlockedLevels.Last<ButtonLevel>().Release += LevelButtonOnRelease;
                }
                else
                {
                    lockedLevels.Add(new LockedLevelShape(graphics, r, lockedTexture));
                }
            }

        }

        public void LoadContent()
        {
            easyButtonTexture = main.Content.Load<Texture2D>("textures/buttons/easyButton");
            mediumButtonTexture = main.Content.Load<Texture2D>("textures/buttons/mediumButton");
            hardButtonTexture = main.Content.Load<Texture2D>("textures/buttons/hardButton");

            startTexture = main.Content.Load<Texture2D>("textures/buttons/startButton");
            lockedTexture = main.Content.Load<Texture2D>("textures/backgrounds/background_items/lockedLevel");

            earthTexture = main.Content.Load<Texture2D>("textures/buttons/earthButton");
            marsTexture = main.Content.Load<Texture2D>("textures/buttons/marsbutton");
            venusTexture = main.Content.Load<Texture2D>("textures/buttons/venusButton");
            neptuneTexture = main.Content.Load<Texture2D>("textures/buttons/neptuneButton");
            mercuryTexture = main.Content.Load<Texture2D>("textures/buttons/mercuryButton");
            erisTexture = main.Content.Load<Texture2D>("textures/buttons/erisButton");

            backgroundTexture = main.Content.Load<Texture2D>("textures/backgrounds/backgroundLoadScreen");
            tvTexture = main.Content.Load<Texture2D>("textures/backgrounds/background_items/tvLevelScreen");
        }

        public void Update(InputState input, GameTime gameTime)
        {
            easyButton.Update(input, gameTime);
            mediumButton.Update(input, gameTime);
            hardButton.Update(input, gameTime);

            for (int i = 0; i < unlockedLevels.Count(); i++)
                unlockedLevels[i].Update(input, gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            //backgroundShape.Draw(batch);
            //tvShape.Draw(batch);

            easyButton.Draw(batch);
            mediumButton.Draw(batch);
            hardButton.Draw(batch);

            for (int i = 0; i < unlockedLevels.Count(); i++)
                unlockedLevels[i].Draw(batch);

            for (int i = 0; i < lockedLevels.Count(); i++)
                lockedLevels[i].Draw(batch);
        }

        public void StartGame(object sender, Level level)
        {
            main.StartGame(level);
        }

        public void EasyButtonOnRelease(object sender, InteractionEventArgs e)
        {
            gameMode = GameMode.Easy;
            SelectButtonMode();
        }

        public void MediumButtonOnRelease(object sender, InteractionEventArgs e)
        {
            gameMode = GameMode.Medium;
            SelectButtonMode();
        }

        public void HardButtonOnRelease(object sender, InteractionEventArgs e)
        {
            gameMode = GameMode.Hard;
            SelectButtonMode();
        }

        public void SelectButtonMode()
        {
            if(gameMode == GameMode.Easy)
            {
                easyButton.Selected = true;
                mediumButton.Selected = false;
                hardButton.Selected = false;
            }
            else if(gameMode == GameMode.Medium)
            {
                easyButton.Selected = false;
                mediumButton.Selected = true;
                hardButton.Selected = false;
            }
            else //if (gameMode == GameMode.Hard
            {
                easyButton.Selected = false;
                mediumButton.Selected = false;
                hardButton.Selected = true;
            }
        }

        private Texture2D[] GetLevelsTexture()
        {
            return new Texture2D[] { earthTexture, marsTexture, venusTexture, neptuneTexture, mercuryTexture, erisTexture };
        }


        public void LevelButtonOnRelease(object sender, InteractionEventArgs e)
        {
            var o = (ButtonLevel)sender;

            foreach(var b in unlockedLevels)
            {
                if (b.level.index != o.level.index)
                    b.Deselect();
            }
        }

    }
}

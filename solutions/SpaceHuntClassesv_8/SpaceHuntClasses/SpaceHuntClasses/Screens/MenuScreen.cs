using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceHuntClasses.Shapes;
using SpaceHuntClasses.Buttons;
using SpaceHuntClasses.Shapes.Labels;
using SpaceHuntClasses.Screens;
using SpaceHuntClasses.MessageBoxs;
using SpaceHuntClasses.Shapes.Buttons;

namespace SpaceHuntClasses
{
    enum MenuState {Main, LevelSelection, Leaderboard, Option, Credit}

    class MenuScreen : IScreen
    {
        private Main main;
        private OptionScreen optionScreen;
        private LevelSelectionScreen levelScreen;
        private MenuState menuState;
        private MenuState newMenuState;
        private List<Button> menuButtons;
        private DarkBackgroundAnimation backgroundAnimation;

        private ButtonMenu startButton;
        private ButtonMenu leaderboardButton;
        private ButtonMenu optionButton;

        private Shape backgroundShape;

        private Texture2D backgroundTexture;


        public MenuScreen(Main main, GraphicsInfos graphics)
        {
            this.main = main;
            optionScreen = new OptionScreen(main, graphics);
            levelScreen = new LevelSelectionScreen(main, graphics);
            menuState = MenuState.Main;
            backgroundAnimation = new DarkBackgroundAnimation(graphics, 0.1f);
            Initialize(graphics);
        }

        public void Initialize(GraphicsInfos graphics)
        {
            LoadContent();

            optionScreen.Initialize(graphics);

            backgroundShape = new Shape(graphics, backgroundTexture, new Rectangle(0, 0, 100, 100));

            var tc = new Color(65, 103, 136, 200); // text color
            var bc = new Color(0, 244, 200, 180); // background color
            Texture2D bt = Utility.GetBlackTexture(); // background texture
            bt.SetData<Color>(new Color[] { bc });

            startButton = new ButtonMenu(graphics, new Rectangle(40, 30, 0, 0), main.fontSize14, "Start Game", tc, bt);
            leaderboardButton = new ButtonMenu(graphics, new Rectangle(40, 40, 0, 0), main.fontSize14, "Leaderboard", tc, bt);
            optionButton = new ButtonMenu(graphics, new Rectangle(40, 50, 0, 0), main.fontSize14, "Option", tc, bt);
            startButton.Release += StartButtonOnRelease;
            leaderboardButton.Release += LeaderboardButtonOnRelease;
            optionButton.Release += OptionButtonOnRelease;
        }


        public void LoadContent()
        {
            backgroundTexture = main.Content.Load<Texture2D>("textures/backgrounds/backgroundMenuScreen");
        }

        public void MainButtonOnRelease(object sender, InteractionEventArgs e)
        {
            StartBackgroundAnimation();
            //menuState = MenuState.Option;
            newMenuState = MenuState.Option;
        }
        
        private void StartBackgroundAnimation()
        {
            backgroundAnimation.Start();
        }

        public void Update(InputState input, GameTime gameTime)
        {
            if(input.backControl == ControlState.Pressed && menuState != MenuState.Main && !backgroundAnimation.active)
            {
                newMenuState = MenuState.Main;
                StartBackgroundAnimation();
            }

            if(menuState == MenuState.Main)
            {
                startButton.Update(input, gameTime);
                leaderboardButton.Update(input, gameTime);
                optionButton.Update(input, gameTime);
            }           
            else if(menuState == MenuState.LevelSelection)
            {
                levelScreen.Update(input, gameTime);
            }
            else if(menuState == MenuState.Leaderboard)
            {

            }
            else if(menuState == MenuState.Option)
            {
                optionScreen.Update(input, gameTime);
            }
            else
            {

            }

            if(backgroundAnimation.active)
            {
                backgroundAnimation.Update();
                if(backgroundAnimation.paused)
                {
                    backgroundAnimation.ReverseVelocity();
                    backgroundAnimation.Resume();
                    menuState = newMenuState;
                }
            }

        }

        public void Draw(SpriteBatch batch) 
        {
            if (menuState == MenuState.Main)
            {
                backgroundShape.Draw(batch);
                startButton.Draw(batch);
                leaderboardButton.Draw(batch);
                optionButton.Draw(batch);
            }
            else if (menuState == MenuState.LevelSelection)
            {
                levelScreen.Draw(batch);
            }
            else if(menuState == MenuState.Leaderboard)
            {

            }
            else if (menuState == MenuState.Option)
            {
                optionScreen.Draw(batch);
            }
            else
            {

            }

            if (backgroundAnimation.active)
            {
                backgroundAnimation.Draw(batch);
            }

        }

        public void StartButtonOnRelease(object sender, InteractionEventArgs e)
        {
            newMenuState = MenuState.LevelSelection;
            StartBackgroundAnimation();
        }

        public void LeaderboardButtonOnRelease(object sender, InteractionEventArgs e)
        {
            newMenuState = MenuState.Leaderboard;
            StartBackgroundAnimation();
        }

        public void OptionButtonOnRelease(object sender, InteractionEventArgs e)
        {
            newMenuState = MenuState.Option;
            StartBackgroundAnimation();
        }
    }
}

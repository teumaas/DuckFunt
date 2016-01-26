﻿using Microsoft.Xna.Framework;
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

namespace SpaceHuntClasses
{
    enum MenuState {Main, LevelSelection, Option, Credit}

    class MenuScreen : IScreen
    {
        private Main main;
        private OptionScreen optionScreen;
        private MenuState menuState;
        private MenuState newMenuState;
        private List<Button> menuButtons;
        private DarkBackgroundAnimation backgroundAnimation;


        public MenuScreen(Main main, GraphicsInfos graphics)
        {
            this.main = main;
            optionScreen = new OptionScreen(main, graphics);
            menuState = MenuState.Option;
            backgroundAnimation = new DarkBackgroundAnimation(graphics);
            Initialize(graphics);
        }

        public void Initialize(GraphicsInfos graphics)
        {
            LoadContent();
            InitButtons(graphics);

            optionScreen.Initialize(graphics);
        }

        private void InitButtons(GraphicsInfos graphics)
        {
            menuButtons = new List<Button>();
            //TODO : add buttons here
        }

        public void LoadContent()
        {
            //TODO : add textures here
        }

        public void MainButtonOnRelease(object sender, InteractionEventArgs e)
        {
            StartBackgroundAnimation();//TODO : use the darkbackgroundAnimation class
            //menuState = MenuState.Option;
            newMenuState = MenuState.Option;
        }
        
        private void StartBackgroundAnimation()
        {
            backgroundAnimation.Start();
        }

        public void Update(InputState input, GameTime gameTime)
        {
            if(input.backControl == ControlState.Pressed && menuState != MenuState.Main)
            {
                newMenuState = MenuState.Main;
                StartBackgroundAnimation();
            }

            if(menuState == MenuState.Main)
            {
                foreach(var button in menuButtons)
                {
                    button.Update(input, gameTime);
                }
            }
            else if(menuState == MenuState.LevelSelection)
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
                if(backgroundAnimation.Update())// if the animation is finish
                {
                    if (backgroundAnimation.velocity < 0)
                        backgroundAnimation.Stop();
                    else
                        backgroundAnimation.ReverseVelocity();
                }
            }

        }

        public void Draw(SpriteBatch batch) 
        {
            if (menuState == MenuState.Main)
            {
                foreach(var button in menuButtons)
                {
                    button.Draw(batch);
                }
            }
            else if (menuState == MenuState.LevelSelection)
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
    }
}
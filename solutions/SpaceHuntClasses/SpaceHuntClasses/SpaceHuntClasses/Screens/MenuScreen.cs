using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceHuntClasses.Classes;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceHuntClasses.Shapes;
using SpaceHuntClasses.Buttons;

namespace SpaceHuntClasses
{
    enum MenuState {Main, LevelSelection, Option, Credit}

    class MenuScreen : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Main main;
        private OptionScreen optionScreen;
        private MenuState menuState;
        private MenuState newMenuState;
        private KeyboardState keyboardState;
        private List<Button> menuButtons;
        private Timer backgroundAnimation;
        private float backgroundTranVelocity;
        private float backgroundTransparency;

        private Texture2D testTexture1;
        private Texture2D testTexture2;
        private Texture2D testTexture3;
        private Texture2D testTexture4;

        public MenuScreen(Main main) : base(main)
        {
            this.main = main;
            optionScreen = new OptionScreen(main);
            backgroundAnimation = new Timer(OnAnimationBackground, 10);
            backgroundTransparency = 0.0f;
            backgroundTranVelocity = 0.01f;
            Initialize();
        }

        public override void Initialize()
        {
            LoadContent();
            InitButtons();

            base.Initialize();
        }

        private void InitButtons()
        {
            menuButtons = new List<Button>();
            var button1 = new Button(testTexture1, new Rectangle(200, 200, 300, 218));
            menuButtons.Add(button1);
            button1.Release += MainButtonOnRelease;


            //menuButtons.Add(new Button(c))
        }

        protected override void LoadContent()
        {
            testTexture1 = main.Content.Load<Texture2D>("menuButtonNormal");
            testTexture2 = main.Content.Load<Texture2D>("menuButtonHover");
            testTexture3 = main.Content.Load<Texture2D>("ufo");
            testTexture4 = main.Content.Load<Texture2D>("buttonAnimationTexture");

            base.LoadContent();
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

        public void OnAnimationBackground()
        {
            if(backgroundTransparency >= 1)
            {
                backgroundTranVelocity *= -1;
                menuState = newMenuState;
            }
            else if(backgroundTranVelocity == 0)
            {
                backgroundAnimation.Stop();
                backgroundTranVelocity = 0.01f;
            }
            else
            {
                backgroundTranVelocity += 0.01f;
            }

            backgroundTransparency += backgroundTranVelocity;
        }

        public void Update(GameTime gameTime,KeyboardState keyboardState, MouseState mouseState)
        {
            if(keyboardState.IsKeyDown(Keys.Escape) && menuState != MenuState.Main)
            {
                newMenuState = MenuState.Main;
                StartBackgroundAnimation();
            }

            if(menuState == MenuState.Main)
            {
                foreach(var button in menuButtons)
                {
                    button.Update(gameTime, mouseState);
                }
            }
            else if(menuState == MenuState.LevelSelection)
            {

            }
            else if(menuState == MenuState.Option)
            {
                optionScreen.Update(gameTime, mouseState);
            }
            else
            {

            }

            backgroundAnimation.Update(gameTime);

            base.Update(gameTime);
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
                var t = new Texture2D(main.GraphicsDevice, 1, 1);

                t.SetData<Color>(new Color[] {Color.Black * backgroundTransparency});
                batch.Draw(t, new Rectangle(0, 0, main.Window.ClientBounds.Width, main.Window.ClientBounds.Height), Color.Black);
            }
 
        }

    }
}

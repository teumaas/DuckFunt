using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SpaceHuntClasses.Classes;
using SpaceHuntClasses.Screens;
using SpaceHuntClasses.Shapes.Buttons;
using SpaceHuntClasses.Shapes;


namespace SpaceHuntClasses
{

    enum OptionScreenState {None, Audio, Video, Control}

    public class OptionScreen : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Main main;     
        private Rectangle bound;
        private OptionScreenState optionScreenState;
        private Timer animation;
        private List<ButtonOption> mainButtons;
        private List<ButtonCheckBox> soundButtons;
        private List<ButtonCheckBox> resolutionButtons;
        private List<ButtonTrackBar> sensibilityButtons;
        private ButtonCheckBox fullScreenButton;
        private Shape windowShape;
        private Shape boardShape;
        private ShapeSource blindShape;
        private Shape projectorShape;
        private Resolution currentResolution;
        private float backgroundTransparency;

        private Texture2D darkBackgroundTexture;
        private Texture2D lightTexture;
        private Texture2D backgroundTexture;
        private Texture2D windowTexture;
        private Texture2D boardTexture;
        private Texture2D audioButtonTexture;
        private Texture2D videoButtonTexture;
        private Texture2D controlsButtonTexture;
        private Texture2D blindTexture;
        private Texture2D projectorTexture;
        private Texture2D musicButtonTexture;
        private Texture2D specialEffectsButtonTexture;
        private Texture2D soundButtonTexture;
        private Texture2D fullscreenTexture;
        private Texture2D resolutionTexture_1920_1080;
        private Texture2D resolutionTexture_800_600;
        private Texture2D mouseTrackBarTexture;


        public OptionScreen(Main main) : base(main)
        {
            this.main = main;
            optionScreenState = OptionScreenState.None;

            currentResolution = new Resolution(main.graphics.PreferredBackBufferWidth, main.graphics.PreferredBackBufferHeight);
            Initialize(currentResolution);
            backgroundTransparency = 0.0f;
        }

        public void Initialize(Resolution resolution)
        {
            LoadContent();

            bound = new Rectangle(0, 0, resolution.width, resolution.height); //TODO : make variables
            animation = new Timer(OnBlindAnimation, 10);   //10ms         
            
            double pDX = (double)1920 / resolution.width;
            double pDY = (double)1080 / resolution.height;
            double sD = (double)1080 / resolution.height;

            mainButtons = new List<ButtonOption>();
            soundButtons = new List<ButtonCheckBox>();
            resolutionButtons = new List<ButtonCheckBox>();
            sensibilityButtons = new List<ButtonTrackBar>();


            var button1 = new ButtonOption(audioButtonTexture, new Rectangle((int)(40/pDX), (int)(220/pDY), (int)(146/sD), (int)(228/sD)));
            var button2 = new ButtonOption(videoButtonTexture, new Rectangle((int)(200/pDX), (int)(400/pDY), (int)(146/sD), (int)(228/sD)));
            var button9 = new ButtonOption(controlsButtonTexture, new Rectangle((int)(60/pDX), (int)(600/pDY), (int)(146/sD), (int)(228/sD)));
            button1.Release += AudioButtonOnRelease;
            button2.Release += VideoButtonOnRelease;
            button9.Release += ControlsButtonRelease;
            mainButtons.Add(button1);
            mainButtons.Add(button2);
            mainButtons.Add(button9);

            var button3 = new ButtonCheckBox(musicButtonTexture, new Rectangle((int)(890/pDX), (int)(300/pDY), (int)(209/sD), (int)(31/sD)), true);
            var button4 = new ButtonCheckBox(specialEffectsButtonTexture, new Rectangle((int)(890/pDX), (int)(400/pDY), (int)(600/sD), (int)(31/sD)), true);
            var button5 = new ButtonCheckBox(soundButtonTexture, new Rectangle((int)(890/pDX), (int)(700/pDY), (int)(288/sD), (int)(78/sD)), true);
            button3.Release += MusicButtonOnRelease;
            button4.Release += SpecialEffectButtonOnRelease;
            button5.Release += GeneralSoundButtonOnRelease;
            soundButtons.Add(button3);
            soundButtons.Add(button4);
            soundButtons.Add(button5);

            //var button6 = new ButtonCheckBox(fullscreenTexture, new Rectangle((int)(890/pDX), (int)(300/pDY), (int)(450/sD), (int)(45/sD)), main.graphics.IsFullScreen);
            var button7 = new ButtonCheckBoxResolution(resolutionTexture_1920_1080, new Rectangle((int)(890/pDX), (int)(348/pDY), (int)(321/sD), (int)(45/sD)), currentResolution.width == 1920, new Resolution(1920, 1080));
            var button8 = new ButtonCheckBoxResolution(resolutionTexture_800_600, new Rectangle((int)(890/pDX), (int)(396/pDY), (int)(255/sD), (int)(45/sD)), currentResolution.width == 800, new Resolution(800, 600));
            //button6.Release += FullScreenButtonOnRelease;
            button7.Release += ResolutionButtonOnClick;
            button8.Release += ResolutionButtonOnClick;
            //resolutionButtons.Add(button6);
            resolutionButtons.Add(button7);
            resolutionButtons.Add(button8);

            var button10 = new ButtonTrackBar(main.trackBarTexture, new Rectangle(950, 350, 300, 45), main.scrollTrackBarTexture, 50);
            button10.Release += MouseTrackBarOnRelease;
            sensibilityButtons.Add(button10);

            windowShape = new Shape(windowTexture, new Rectangle((int)(850/pDX), (int)(180/pDY), (int)(735/sD), (int)(656/sD)));
            boardShape = new Shape(boardTexture, new Rectangle((int)(0/pDX), (int)(180/pDY), (int)(597/sD), (int)(678/sD)));
            blindShape = new ShapeSource(blindTexture, new Rectangle((int)(850/pDX), (int)(180/pDY), (int)(735/sD), (int)(13/sD)), new Rectangle(0, 0, (int)(735/sD), (int)(13/sD)));
            projectorShape = new Shape(projectorTexture, new Rectangle((int)(850/pDX), (int)(180/pDY), (int)(735/sD), (int)(656/sD)));

            fullScreenButton = new ButtonCheckBox(fullscreenTexture, new Rectangle((int)(890 / pDX), (int)(300 / pDY), (int)(450 / sD), (int)(45 / sD)), main.graphics.IsFullScreen);
            fullScreenButton.Release += FullScreenButtonOnRelease;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            backgroundTexture = main.Content.Load<Texture2D>("backgroundOptionScreen");
            windowTexture = main.Content.Load<Texture2D>("windowBackground");
            boardTexture = main.Content.Load<Texture2D>("boardBackground");
            audioButtonTexture = main.Content.Load<Texture2D>("optionAudioButton");
            blindTexture = main.Content.Load<Texture2D>("blindOption");
            projectorTexture = main.Content.Load<Texture2D>("projectorOption");
            musicButtonTexture = main.Content.Load<Texture2D>("musicOptionButton");
            specialEffectsButtonTexture = main.Content.Load<Texture2D>("specialEffectsOptionButton");
            soundButtonTexture = main.Content.Load<Texture2D>("generalSoundOptionButton2");
            videoButtonTexture = main.Content.Load<Texture2D>("optionVideoButton");
            resolutionTexture_1920_1080 = main.Content.Load<Texture2D>("resolutionOptionButton_1920_1080");
            resolutionTexture_800_600 = main.Content.Load<Texture2D>("resolutionOptionButton_800_600");
            fullscreenTexture = main.Content.Load<Texture2D>("fullscreenOptionButton");
            controlsButtonTexture = main.Content.Load<Texture2D>("optionControlsButton");
            mouseTrackBarTexture = main.Content.Load<Texture2D>("mouseTrackBar");

            darkBackgroundTexture = new Texture2D(main.GraphicsDevice, 1, 1);
            lightTexture = new Texture2D(main.GraphicsDevice, 1, 1);

            lightTexture.SetData<Color>(new Color[] { Color.Yellow * 0.3f });

            base.LoadContent();
        }

        public void Update(GameTime gameTime, MouseState mouseState)
        {
            foreach(var b in mainButtons)
            {
                b.Update(gameTime, mouseState);
            }
            
            if(animation.active)
            {
                animation.Update(gameTime);
            }
            else if(optionScreenState != OptionScreenState.None)
            {
                if(optionScreenState == OptionScreenState.Audio)
                {
                    foreach(var b in soundButtons)
                    {
                        b.Update(gameTime, mouseState);
                    }
                }
                else if(optionScreenState == OptionScreenState.Video)
                {
                    fullScreenButton.Update(gameTime, mouseState);
                    foreach(var b in resolutionButtons)
                    {
                        b.Update(gameTime, mouseState);
                    }
                }
                else
                {
                    foreach(var b in sensibilityButtons)
                    {
                        b.Update(gameTime, mouseState);
                    }
                }
            }

            base.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(backgroundTexture, bound, Color.White);
            windowShape.Draw(batch);
            boardShape.Draw(batch);
            blindShape.Draw(batch);

            if(optionScreenState != OptionScreenState.None && !animation.active)
            {
                projectorShape.Draw(batch);
                                
                if(optionScreenState == OptionScreenState.Audio)
                {
                    foreach(var b in soundButtons)
                    {
                        b.Draw(batch);
                    }
                }
                else if(optionScreenState == OptionScreenState.Video)
                {
                    fullScreenButton.Draw(batch);
                    foreach(var b in resolutionButtons)
                    {
                        b.Draw(batch);
                    }
                }
                else
                {
                    foreach(var b in sensibilityButtons)
                    {
                        b.Draw(batch);
                    }
                }                
            }

            foreach(var b in mainButtons)
            {
                b.Draw(batch);
            }

            darkBackgroundTexture.SetData<Color>(new Color[] { Color.Black * backgroundTransparency });
            batch.Draw(darkBackgroundTexture, bound, Color.White);
            //batch.Draw(lightTexture, new Rectangle(0, 180, 400, 550), Color.White);         
        }

        public void AudioButtonOnRelease(object sender, InteractionEventArgs e)
        {
            CloseBlind();
            optionScreenState = OptionScreenState.Audio;
        }
        public void VideoButtonOnRelease(object sender, InteractionEventArgs e)
        {
            CloseBlind();
            optionScreenState = OptionScreenState.Video;
        }

        public void ControlsButtonRelease(object sender, InteractionEventArgs e)
        {
            CloseBlind();
            optionScreenState = OptionScreenState.Control;
        }

        private void OpenBlind()
        {
            animation.Start();
            optionScreenState = OptionScreenState.None;
        }

        private void CloseBlind()
        {
            if(optionScreenState == OptionScreenState.None)
            {
                animation.Start();
            }
        }

        public void OnBlindAnimation()
        {
            if(optionScreenState == OptionScreenState.None)
            {
                if (blindShape.sourceRectangle.Height > 20)
                {
                    blindShape.sourceRectangle.Height -= 20;
                    blindShape.rectangle.Height -= 20;
                    backgroundTransparency -= 0.0144f;
                    darkBackgroundTexture.SetData<Color>(new Color[] { Color.Black * backgroundTransparency });
                }
                else
                {
                    animation.Stop();
                }
            }
            else
            {
                if (blindShape.sourceRectangle.Height <=  windowShape.rectangle.Height - 20)
                {
                    blindShape.sourceRectangle.Height += 20;
                    blindShape.rectangle.Height += 20;
                    backgroundTransparency += 0.0144f;
                    darkBackgroundTexture.SetData<Color>(new Color[] { Color.Black * backgroundTransparency });
                }
                else
                {
                    animation.Stop();
                }
            }
        }

        public void ChangeResolution()
        {

        }

        public void MusicButtonOnRelease(object sender, InteractionEventArgs e)
        {

        }
        public void SpecialEffectButtonOnRelease(object sender, InteractionEventArgs e)
        {

        }
        public void GeneralSoundButtonOnRelease(object sender, InteractionEventArgs e)
        {

        }
        public void FullScreenButtonOnRelease(object sender, InteractionEventArgs e)
        {
            main.ChangeFullScreenMode();
        }
        public void ResolutionButtonOnClick(object sender, InteractionEventArgs e)
        {
            var o = (ButtonCheckBoxResolution)sender;

            if(!o.resolution.Equals(currentResolution))
            {
                ChangeResolution(o.resolution);

                foreach(ButtonCheckBoxResolution b in resolutionButtons)
                {
                    if (!o.resolution.Equals(b.resolution))
                    {
                        b.Selected = false;
                    }
                    else
                        b.Selected = true;
                }                
                currentResolution = o.resolution;
            }
        }
        
        private void ChangeResolution(Resolution resolution)
        {
            main.ChangeResolution(resolution);
            Initialize(resolution);
        }

        public void MouseTrackBarOnRelease(object sender, InteractionEventArgs e)
        {
            //TODO : get the value and send it to the mouse class or something like dat
        }

    }
}

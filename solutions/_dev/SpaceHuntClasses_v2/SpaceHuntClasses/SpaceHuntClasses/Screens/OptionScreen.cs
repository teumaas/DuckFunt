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
using SpaceHuntClasses.Screens;
using SpaceHuntClasses.Shapes.Buttons;
using SpaceHuntClasses.Shapes;
using SpaceHuntClasses.MessageBoxs;


namespace SpaceHuntClasses.Screens
{

    enum OptionScreenState {None, Audio, Video, Control}

    public class OptionScreen : Microsoft.Xna.Framework.DrawableGameComponent
    {

        #region Fields
        private Main main;     
        private Rectangle bound;
        private OptionScreenState optionScreenState;
        private Timer animation;
        private ButtonCheckBox fullScreenButton;
        private Shape windowShape;
        private Shape boardShape;
        private ShapeSource blindShape;
        private Shape projectorShape;
        private Resolution currentResolution;
        private float backgroundTransparency;
        private MessageBox messageBox;
        private List<ButtonCheckBoxResolution> resolutionButtons;


        private ButtonOption buttonOptionAudio;
        private ButtonOption buttonOptionVideo;
        private ButtonOption buttonOptionControl;

        private ButtonCheckBox musicButton;
        private ButtonCheckBox specialeffectButton;
        private ButtonCheckBox soundButton;

        private ButtonCheckBoxResolution resolutionButton1;
        private ButtonCheckBoxResolution resolutionButton2;

        private ButtonTrackBar wiimoteTrackBar;
        private ButtonTrackBar mouseTrackBar;

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
        private Texture2D mouseLabelTexture;
        private Texture2D wiimoteLabelTexture;
        private Texture2D actionLabelTexture;
        private Texture2D mouseAndKeyboardLabelTexture;
        #endregion

        #region Constructor

        public OptionScreen(Main main, GraphicsInfos graphics) : base(main)
        {
            this.main = main;
            optionScreenState = OptionScreenState.None;

            currentResolution = new Resolution(main.graphics.PreferredBackBufferWidth, main.graphics.PreferredBackBufferHeight);
            Initialize(graphics);
            backgroundTransparency = 0.0f;
            messageBox = new MessageBoxResolution(graphics);
        }

        #endregion

        #region Initialize
        public void Initialize(GraphicsInfos graphics)
        {
            LoadContent();

            bound = new Rectangle(0, 0, graphics.resolution.width, graphics.resolution.height); //TODO : make variables
            animation = new Timer(10);   //10ms         
            animation.Tick += animation_Tick;
            
            double pDX = (double)1920 / graphics.resolution.width;
            double pDY = (double)1080 / graphics.resolution.height;
            double sD = (double)1080 / graphics.resolution.height;


            buttonOptionAudio = new ButtonOption(graphics, audioButtonTexture, new Rectangle(50, 50, 50, 50));
            buttonOptionVideo = new ButtonOption(graphics, videoButtonTexture, new Rectangle(10, 10, 10, 10));
            buttonOptionControl = new ButtonOption(graphics, controlsButtonTexture, new Rectangle(20, 20, 10, 10));

            buttonOptionAudio.Release += MusicButtonOnRelease;
            buttonOptionVideo.Release += SpecialEffectButtonOnRelease;
            buttonOptionControl.Release += GeneralSoundButtonOnRelease;


            resolutionButtons = new List<ButtonCheckBoxResolution>();
            var b1 = new ButtonCheckBoxResolution(graphics, resolutionTexture_1920_1080, new Rectangle(15, 15, 15, 15), currentResolution.width == 1920, new Resolution(1920, 1080));
            var b2 = new ButtonCheckBoxResolution(graphics, resolutionTexture_800_600, new Rectangle(10, 30, 45, 25), currentResolution.width == 800, new Resolution(800, 600));
            b1.Release += ResolutionButtonOnRelease;
            b2.Release += ResolutionButtonOnRelease;
            resolutionButtons.Add(b1);
            resolutionButtons.Add(b2);

            musicButton = new ButtonCheckBox(graphics, musicButtonTexture, new Rectangle(0, 0, 0, 0), true);
            specialeffectButton = new ButtonCheckBox(graphics, specialEffectsButtonTexture, new Rectangle(0, 0, 0, 0), true);
            soundButton = new ButtonCheckBox(graphics, soundButtonTexture, new Rectangle(0, 0, 0, 0), true);
            musicButton.Release += MusicButtonOnRelease;
            specialeffectButton.Release += SpecialEffectButtonOnRelease;
            soundButton.Release += GeneralSoundButtonOnRelease;

            //var button10 = new ButtonTrackBar(main.trackBarTexture, new Rectangle((int)(1100/pDX), (int)(350/pDY), (int)(480/sD), 45), main.scrollTrackBarTexture, mouseLabelTexture, 5);
            //var button11 = new ButtonTrackBar(main.trackBarTexture, new Rectangle((int)(1100/pDX), (int)(395/pDY), (int)(480/sD), 45), main.scrollTrackBarTexture, wiimoteLabelTexture, 5);
            //button10.Release += MouseTrackBarOnRelease;
            //button11.Release += WiimoteTrackBarOnRelease;

            //wiimoteTrackBar = new ButtonTrackBar(graphics)

            windowShape = new Shape(graphics, windowTexture, new Rectangle(20, 20, 35, 35));
            boardShape = new Shape(graphics, boardTexture, new Rectangle((int)(0/pDX), (int)(180/pDY), (int)(597/sD), (int)(678/sD)));
            blindShape = new ShapeSource(graphics, blindTexture, new Rectangle((int)(850 / pDX), (int)(180 / pDY), (int)(735 / sD), (int)(13 / sD)), new Rectangle(0, 0, (int)(735 / sD), (int)(13 / sD)));
            projectorShape = new Shape(graphics, projectorTexture, new Rectangle((int)(850 / pDX), (int)(180 / pDY), (int)(735 / sD), (int)(656 / sD)));

            fullScreenButton = new ButtonCheckBox(graphics, fullscreenTexture, new Rectangle((int)(890 / pDX), (int)(300 / pDY), (int)(450 / sD), (int)(45 / sD)), main.graphics.IsFullScreen);
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
            mouseLabelTexture = main.Content.Load<Texture2D>("mouseLabel");
            wiimoteLabelTexture = main.Content.Load<Texture2D>("wiimoteLabel");

            darkBackgroundTexture = new Texture2D(main.GraphicsDevice, 1, 1);
            lightTexture = new Texture2D(main.GraphicsDevice, 1, 1);

            lightTexture.SetData<Color>(new Color[] { Color.Yellow * 0.3f });

            base.LoadContent();
        }
        #endregion

        #region Update & Draw
        public void Update(GameTime gameTime, MouseState mouseState)
        {
            buttonOptionAudio.Update(gameTime, mouseState);
            buttonOptionControl.Update(gameTime, mouseState);
            buttonOptionVideo.Update(gameTime, mouseState);

            if (animation.active)
            {
                animation.Update(gameTime);
            }
            else if (optionScreenState != OptionScreenState.None)
            {
                if (optionScreenState == OptionScreenState.Audio)
                {
                    musicButton.Update(gameTime, mouseState);
                    specialeffectButton.Update(gameTime, mouseState);
                    soundButton.Update(gameTime, mouseState);

                }
                else if (optionScreenState == OptionScreenState.Video)
                {
                    fullScreenButton.Update(gameTime, mouseState);
                    resolutionButton1.Update(gameTime, mouseState);
                    resolutionButton2.Update(gameTime, mouseState);
                }
                else
                {
                    wiimoteTrackBar.Update(gameTime, mouseState);
                    mouseTrackBar.Update(gameTime, mouseState);
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

            if (optionScreenState != OptionScreenState.None && !animation.active)
            {
                projectorShape.Draw(batch);

                if (optionScreenState == OptionScreenState.Audio)
                {
                    musicButton.Draw(batch);
                    specialeffectButton.Draw(batch);
                    soundButton.Draw(batch);
                }
                else if (optionScreenState == OptionScreenState.Video)
                {
                    fullScreenButton.Draw(batch);
                    resolutionButton1.Draw(batch);
                    resolutionButton2.Draw(batch);
                }
                else
                {
                    wiimoteTrackBar.Draw(batch);
                    mouseTrackBar.Draw(batch);
                }
            }

            buttonOptionAudio.Draw(batch);
            buttonOptionVideo.Draw(batch);
            buttonOptionControl.Draw(batch);

            darkBackgroundTexture.SetData<Color>(new Color[] { Color.Black * backgroundTransparency });
            batch.Draw(darkBackgroundTexture, bound, Color.White);
            //batch.Draw(lightTexture, new Rectangle(0, 180, 400, 550), Color.White);         
        }
        #endregion

        #region Methods
        private void animation_Tick(object sender, EventArgs e)
        {
            if (optionScreenState == OptionScreenState.None)
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
                if (blindShape.sourceRectangle.Height <= windowShape.rectangle.Height - 20)
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

        private void ChangeResolution(Resolution nResolution) //new resolution
        {
            main.ChangeResolution(nResolution);
            //Initialize(resolution);
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

        public void ResolutionButtonOnRelease(object sender, InteractionEventArgs e)
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

        public void MouseTrackBarOnRelease(object sender, InteractionEventArgs e)
        {
            //TODO : get the value and send it to the mouse class or something like dat
        }
        public void WiimoteTrackBarOnRelease(object sender, InteractionEventArgs e)
        {
            //TODO : get the value and send it to the wii-mote class or something like dat
        }

        #endregion
    }
}

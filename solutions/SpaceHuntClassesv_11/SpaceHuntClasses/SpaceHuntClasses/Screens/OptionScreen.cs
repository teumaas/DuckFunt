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
using SpaceHuntClasses.Shapes;
using SpaceHuntClasses.Shapes.Buttons;
using SpaceHuntClasses.Shapes;
using SpaceHuntClasses.MessageBoxs;


namespace SpaceHuntClasses.Shapes
{

    enum OptionScreenState {None, Audio, Video, Control}

    public class OptionScreen : IScreen
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
        //private MessageBoxYesNo messageBox;
        private List<ButtonCheckBoxResolution> resolutionButtons;
        //private DarkBackgroundAnimation backgroundAnimation; TODO : look if i need it


        private ButtonOption buttonOptionAudio;
        private ButtonOption buttonOptionVideo;
        private ButtonOption buttonOptionControl;

        private ButtonCheckBox musicButton;
        private ButtonCheckBox specialeffectButton;
        private ButtonCheckBox soundButton;

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

        #endregion

        #region Constructor

        public OptionScreen(Main main, GraphicsInfos graphics)
        {
            this.main = main;
            optionScreenState = OptionScreenState.None;

            currentResolution = new Resolution(main.graphics.PreferredBackBufferWidth, main.graphics.PreferredBackBufferHeight);
            Initialize(graphics);
            backgroundTransparency = 0.0f;
            //messageBox = new MessageBoxYesNo(graphics, main.fontSize14)
        }

        #endregion

        #region Initialize
        public void Initialize(GraphicsInfos graphics)
        {
            LoadContent();

            bound = new Rectangle(0, 0, graphics.resolution.width, graphics.resolution.height);
            animation = new Timer(10);   //10ms         
            animation.Tick += animation_Tick;

            //AUDIO VIDEO & CONTROL MENU BUTTONS
            buttonOptionAudio = new ButtonOption(graphics, audioButtonTexture, new Rectangle(3, 4 + 17, 0, 0));
            buttonOptionVideo = new ButtonOption(graphics, videoButtonTexture, new Rectangle(21, 22 + 17, 0, 0));
            buttonOptionControl = new ButtonOption(graphics, controlsButtonTexture, new Rectangle(4, 35 + 17, 0, 0));
            buttonOptionAudio.Release += AudioButtonOnRelease;
            buttonOptionVideo.Release += VideoButtonOnRelease;
            buttonOptionControl.Release += ControlsButtonRelease;

            //VIDEO OPTION
            fullScreenButton = new ButtonCheckBox(graphics, fullscreenTexture, new Rectangle(40 + 5, 17 + 8, 0, 0), main.graphics.IsFullScreen);
            fullScreenButton.Release += FullScreenButtonOnRelease;
            resolutionButtons = new List<ButtonCheckBoxResolution>();
            var b1 = new ButtonCheckBoxResolution(graphics, resolutionTexture_1920_1080, new Rectangle(40 + 5, 17 + 24, 15, 15), currentResolution.width == 1920, new Resolution(1920, 1080));
            var b2 = new ButtonCheckBoxResolution(graphics, resolutionTexture_800_600, new Rectangle(40 + 5, 17 + 40, 45, 25), currentResolution.width == 800, new Resolution(800, 600));
            b1.Release += ResolutionButtonOnRelease;
            b2.Release += ResolutionButtonOnRelease;
            resolutionButtons.Add(b1);
            resolutionButtons.Add(b2);
            

            //AUDIO OPTION
            musicButton = new ButtonCheckBox(graphics, musicButtonTexture, new Rectangle(40 + 5, 17 + 8, 0, 0), true);
            specialeffectButton = new ButtonCheckBox(graphics, specialEffectsButtonTexture, new Rectangle(40 + 5, 17 + 24, 0, 0), true);
            soundButton = new ButtonCheckBox(graphics, soundButtonTexture, new Rectangle(40 + 5, 17 + 40, 0, 0), true);
            musicButton.Release += MusicButtonOnRelease;
            specialeffectButton.Release += SpecialEffectButtonOnRelease;
            soundButton.Release += GeneralSoundButtonOnRelease;

            //CONTROL OPTION
            wiimoteTrackBar = new ButtonTrackBar(graphics, main.trackBarTexture, new Rectangle(40 + 5, 17 + 8, 0, 0), main.fontSize10, main.scrollTrackBarTexture, "wiimote", 5);
            mouseTrackBar = new ButtonTrackBar(graphics, main.trackBarTexture, new Rectangle(40 + 5, 17 + 24, 0, 0), main.fontSize10, main.scrollTrackBarTexture, "mouse", 5);
            wiimoteTrackBar.Release += WiimoteTrackBarOnRelease;
            mouseTrackBar.Release += MouseTrackBarOnRelease;

            //BACKGROUND SHAPES
            windowShape = new Shape(graphics, windowTexture, new Rectangle(40, 17, 0, 0));
            boardShape = new Shape(graphics, boardTexture, new Rectangle(0, 17, 0, 0));
            blindShape = new ShapeSource(graphics, blindTexture, new Rectangle(40, 17, blindTexture.Width, blindTexture.Height));
            projectorShape = new Shape(graphics, projectorTexture, new Rectangle(40, 17, 0, 0));

            windowShape.ApplyPositionPercentage(graphics.resolution);
            boardShape.ApplyPositionPercentage(graphics.resolution);
            blindShape.ApplyPositionPercentage(graphics.resolution);
            projectorShape.ApplyPositionPercentage(graphics.resolution);

            windowShape.ResizeWithTexture(graphics.resolution);
            boardShape.ResizeWithTexture(graphics.resolution);
            projectorShape.ResizeWithTexture(graphics.resolution);
        }

        public void LoadContent()
        {
            backgroundTexture = main.Content.Load<Texture2D>("textures/backgrounds/backgroundOptionScreen");
            windowTexture = main.Content.Load<Texture2D>("textures/backgrounds/background_items/windowBackground");
            boardTexture = main.Content.Load<Texture2D>("textures/backgrounds/background_items/boardBackground");
            audioButtonTexture = main.Content.Load<Texture2D>("textures/buttons/optionAudioButton");
            blindTexture = main.Content.Load<Texture2D>("blindOption");
            projectorTexture = main.Content.Load<Texture2D>("projectorOption");
            musicButtonTexture = main.Content.Load<Texture2D>("textures/buttons/musicOptionButton");
            specialEffectsButtonTexture = main.Content.Load<Texture2D>("textures/buttons/specialEffectsOptionButton");
            soundButtonTexture = main.Content.Load<Texture2D>("textures/buttons/generalSoundOptionButton2");
            videoButtonTexture = main.Content.Load<Texture2D>("textures/buttons/optionVideoButton");
            resolutionTexture_1920_1080 = main.Content.Load<Texture2D>("textures/buttons/resolutionOptionButton_1920_1080");
            resolutionTexture_800_600 = main.Content.Load<Texture2D>("textures/buttons/resolutionOptionButton_800_600");
            fullscreenTexture = main.Content.Load<Texture2D>("textures/buttons/fullscreenOptionButton");
            controlsButtonTexture = main.Content.Load<Texture2D>("textures/buttons/optionControlsButton");

            darkBackgroundTexture = new Texture2D(main.GraphicsDevice, 1, 1);
            lightTexture = new Texture2D(main.GraphicsDevice, 1, 1);

            lightTexture.SetData<Color>(new Color[] { Color.Yellow * 0.3f });
        }
        #endregion

        #region Update & Draw
        public void Update(InputState input, GameTime gameTime)
        {
            buttonOptionAudio.Update(input, gameTime);
            buttonOptionControl.Update(input, gameTime);
            buttonOptionVideo.Update(input, gameTime);

            if (animation.active)
            {
                animation.Update(gameTime);
            }
            else if (optionScreenState != OptionScreenState.None)
            {
                if (optionScreenState == OptionScreenState.Audio)
                {
                    musicButton.Update(input, gameTime);
                    specialeffectButton.Update(input, gameTime);
                    soundButton.Update(input, gameTime);

                }
                else if (optionScreenState == OptionScreenState.Video)
                {
                    fullScreenButton.Update(input, gameTime);
                    foreach (var b in resolutionButtons)
                        b.Update(input, gameTime);
                }
                else
                {
                    wiimoteTrackBar.Update(input, gameTime);
                    mouseTrackBar.Update(input, gameTime);
                }
            }
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
                    foreach (var b in resolutionButtons)
                        b.Draw(batch);
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
            batch.Draw(darkBackgroundTexture, new Rectangle(0, 0, 1920, 1080), Color.White);
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
                    //blindShape.rectangle.Height -= 20;
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
                if (blindShape.sourceRectangle.Height <= blindShape.rectangle.Height)
                {
                    blindShape.sourceRectangle.Height += 20;
                    //blindShape.rectangle.Height += 20;
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

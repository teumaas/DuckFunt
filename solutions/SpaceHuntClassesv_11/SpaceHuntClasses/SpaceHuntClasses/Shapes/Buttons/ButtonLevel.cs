using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceHuntClasses.Buttons;
using SpaceHuntClasses.Levels;
using SpaceHuntClasses.Shapes.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes.Buttons
{
    public delegate void StartButtonEventHandler(object sender, Level level);

    class ButtonLevel : Button
    {
        private Button startButton;
        private Texture2D backgroundTexture;
        private Label modeLabel;
        private Label storyLabel;
        private Label titleLabel;
        public event StartButtonEventHandler StartGame;
        private bool selected;
        private DarkBackgroundAnimation fadeAnimation;
        private Shape planetShape;

        public Level level { get; private set; }
       

        public ButtonLevel(GraphicsInfos graphics, Rectangle rectangle, Level level, Texture2D startTexture, SpriteFont titleFont, SpriteFont font, Texture2D planetTexture) : base(graphics, rectangle)
        {
            ApplyPercentage(graphics.resolution);

            this.level = level;
            selected = false;

            startButton = new Button(graphics, startTexture, new Rectangle(0, 0, 0, 0));
            startButton.ResizeWithTexture(graphics.resolution);
            startButton.rectangle.X = this.rectangle.X + this.rectangle.Width - startButton.rectangle.Width - 10;
            startButton.rectangle.Y = this.rectangle.Y + this.rectangle.Height - startButton.rectangle.Height - 10;
            startButton.Release += StartButtonOnRelease;

            modeLabel = new Label(graphics, font, Vector2.Zero, level.gameMode.ToString());
            storyLabel = new Label(graphics, font, new Vector2(this.rectangle.X, this.rectangle.Y + (this.rectangle.Height / 4)), Utility.GetStringBordersFormat(font, level.Story, this.rectangle.Width));
            titleLabel = new Label(graphics, titleFont, new Vector2(this.rectangle.X + (this.rectangle.Width / 2) - (titleFont.MeasureString(level.Name).X / 2), this.rectangle.Y + (titleFont.MeasureString(level.Name).Y / 2)), level.Name);

            backgroundTexture = Utility.GetTexture(Color.Gray);
            fadeAnimation = new DarkBackgroundAnimation(graphics, 0.02f, this.rectangle, 0.7f);

            planetShape = new Shape(graphics, planetTexture, new Rectangle(this.rectangle.X + (this.rectangle.Width / 2), this.rectangle.Y + (this.rectangle.Height / 2), this.rectangle.Height / 2, this.rectangle.Height / 2));
            planetShape.rectangle = new Rectangle(this.rectangle.X + (this.rectangle.Width / 2) - (planetShape.rectangle.Width / 2), this.rectangle.Y + (this.rectangle.Height / 2) - (planetShape.rectangle.Height / 2), planetShape.rectangle.Width, planetShape.rectangle.Width);

            Release += OnRelease;
        }

        public override void Update(InputState input, GameTime gameTime)
        {
            if(selected && fadeAnimation.paused)
            {
                startButton.Update(input, gameTime);
            }

            base.Update(input, gameTime);

            if (fadeAnimation.active)
                fadeAnimation.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(backgroundTexture, rectangle, Color.White);
            planetShape.Draw(batch);

            fadeAnimation.Draw(batch);

            if (selected)
            {
                titleLabel.Draw(batch);
                storyLabel.Draw(batch);
                modeLabel.Draw(batch);

                if (fadeAnimation.paused)
                    startButton.Draw(batch);
            }
        }

        public void StartButtonOnRelease(object sender, InteractionEventArgs e)
        {
            StartGame(this, level);
        }

        public void OnRelease(object sender, InteractionEventArgs e)
        {
            if (selected)
                HideInfos();
            else
                ShowInfos();
        }

        public void ShowInfos()
        {
            selected = true;
            fadeAnimation.Start();
        }

        public void HideInfos()
        {
            selected = false;
            fadeAnimation.ReverseVelocity();
            fadeAnimation.Resume();
        }

        public void Deselect()//obsolete
        {
            selected = false;
            HideInfos();
        }

        public void Select()
        {
            selected = true;
        }
    }
}

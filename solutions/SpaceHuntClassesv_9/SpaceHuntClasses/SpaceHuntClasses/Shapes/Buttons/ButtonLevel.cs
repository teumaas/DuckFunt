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

        public Level level { get; private set; }
       

        public ButtonLevel(GraphicsInfos graphics, Texture2D texture, Rectangle rectangle, Level level, Button startButton, SpriteFont titleFont, SpriteFont font) : base(graphics, texture, rectangle)
        {
            this.startButton = startButton;
            selected = true;

            modeLabel = new Label(graphics, font, Vector2.Zero, level.gameMode.ToString());
            storyLabel = new Label(graphics, font, new Vector2(0, 0), level.Story);
            titleLabel = new Label(graphics, font, new Vector2(0, 0), level.Name);

            backgroundTexture = Utility.GetTexture(Color.Gray);

            startButton.rectangle.X = this.rectangle.X + this.rectangle.Width - startButton.rectangle.Width;
            startButton.rectangle.Y = this.rectangle.Y + this.rectangle.Height - startButton.rectangle.Height;

            Release += OnRelease;
        }

        public override void Update(InputState input, GameTime gameTime)
        {
            base.Update(input, gameTime);

            if(selected)
            {
                startButton.Update(input, gameTime);
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(backgroundTexture, rectangle, Color.White);
            base.Draw(batch);

            if(selected)
            {
                titleLabel.Draw(batch);
                storyLabel.Draw(batch);
                modeLabel.Draw(batch);
                startButton.Draw(batch);
            }
            else
            {
                //draw the fade shape
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
        }

        public void HideInfos()
        {
            selected = false;
        }
    }
}

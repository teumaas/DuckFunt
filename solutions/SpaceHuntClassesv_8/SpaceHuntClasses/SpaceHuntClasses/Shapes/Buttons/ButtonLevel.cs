using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceHuntClasses.Buttons;
using SpaceHuntClasses.Shapes.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes.Buttons
{
    public delegate void StartButtonEventHandler(Level level);
    public enum ButtonLevelState { }

    class ButtonLevel : Button
    {
        private Button startButton;
        private Texture2D backgroundTexture;
        private Label modeLabel;
        private Label storyLabel;
        private event StartButtonEventHandler StartGame;
        private ButtonLevelState state;
        private bool selected;

        public Level level { get; private set; }
       

        public ButtonLevel(GraphicsInfos graphics, Texture2D texture, Rectangle rectangle, Level level, Button startButton, SpriteFont titleFont, SpriteFont font) : base(graphics, texture, rectangle)
        {
            this.startButton = startButton;
            selected = false;

            modeLabel = new Label(graphics, font, Vector2.Zero, level.gameMode.ToString());
            storyLabel = new Label(graphics, font, new Vector2(0, 0), level.Story);
        }

        public override void Update(InputState input, GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch batch)
        {
            
        }



        public void StartButtonOnRelease(object sender, InteractionEventArgs e)
        {
            StartGame(level);
        }

        public void ShowInfos()
        {

        }

        public void HideInfos()
        {

        }
    }
}

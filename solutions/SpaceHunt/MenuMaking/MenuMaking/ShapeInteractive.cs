using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes
{
    public delegate void InteractionEventHandler(object sender, InteractionEventArgs e);
    public enum InteractionState { None, Hover, Down, Release };

    public class ShapeInteractive : Shape
    {
        public InteractionState state { get; set; }

        public event InteractionEventHandler Click;
        public event InteractionEventHandler Hover;
        public event InteractionEventHandler Release;

        public ShapeInteractive(Rectangle rectangle) : base(rectangle)
        {
            this.rectangle = rectangle;
            state = InteractionState.None;
        }

        public ShapeInteractive(Texture2D texture, Rectangle rectangle)
            : base(texture, rectangle)
        {
            state = InteractionState.None;
        }


        public virtual void Update(GameTime gameTime, MouseState mouseState)
        {
            //if(Utility.CheckBorders(rectangle, mouseState.X, mouseState.Y))

            if ((mouseState.X >= rectangle.X && mouseState.X <= rectangle.X + rectangle.Width) && (mouseState.Y >= rectangle.Y && mouseState.Y <= rectangle.Y + rectangle.Height))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (state == InteractionState.Hover)
                    {
                        state = InteractionState.Down;
                        if (Click != null)
                        {
                            Click(this, new InteractionEventArgs(state));
                        }
                    }
                }
                else //ButtonState.Release
                {
                    if (state == InteractionState.Down)
                    {
                        state = InteractionState.Release;
                        if (Release != null)
                        {
                            Release(this, new InteractionEventArgs(state));
                        }
                    }
                    else
                    {
                        state = InteractionState.Hover;
                        if (Hover != null)
                        {
                            Hover(this, new InteractionEventArgs(state));
                        }
                    }
                }
            }
            else if (state != InteractionState.Down && mouseState.LeftButton != ButtonState.Pressed)
            {
                state = InteractionState.None;
            }
        }
    }
}

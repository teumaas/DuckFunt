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

        public ShapeInteractive(GraphicsInfos graphics, Rectangle percentage) : base(graphics, percentage)
        {
            this.rectangle = rectangle;
            state = InteractionState.None;
        }

        public ShapeInteractive(GraphicsInfos graphics, Texture2D texture, Rectangle percentage)
            : base(graphics, texture, percentage)
        {
            state = InteractionState.None;
        }


        public virtual void Update(InputState input, GameTime gameTime)
        {
            //if(Utility.CheckBorders(rectangle, mouseState.X, mouseState.Y))

            if ((input.X >= rectangle.X && input.X <= rectangle.X + rectangle.Width) && (input.Y >= rectangle.Y && input.Y <= rectangle.Y + rectangle.Height))
            {
                if (input.shootControl == ControlState.Pressed)
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
            else if (input.shootControl != ControlState.Release || state == InteractionState.Hover)
            {
                state = InteractionState.None;
            }
            
        }
    }
}

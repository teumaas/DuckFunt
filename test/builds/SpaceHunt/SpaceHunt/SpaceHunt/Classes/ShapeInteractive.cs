using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHunt.Classes
{
    public delegate void InteractionEventHandler(object sender, InteractionEventArgs e);
    public enum InteractionState { None, Hover, Down, Release };
    public class ShapeInteractive : Shape
    {
        public InteractionState state { get; set; }

        public event InteractionEventHandler Click;
        public event InteractionEventHandler Hover;
        public event InteractionEventHandler Release;

        public ShapeInteractive(Texture2D texture, Rectangle rectangle)
            : base(texture, rectangle)
        {
            state = InteractionState.None;
        }

        public virtual void Update(GameTime gameTime, MouseState mouseState)
        {
            if ((mouseState.X >= rectangle.X && mouseState.X <= rectangle.X + rectangle.Width) && (mouseState.Y >= rectangle.Y && mouseState.Y <= rectangle.Y + rectangle.Height))
            {
                if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                {
                    state = InteractionState.Down;
                    if (Click != null)
                        Click(this, new InteractionEventArgs(state));
                }
                else
                {
                    if (state == InteractionState.Down)
                    {
                        state = InteractionState.Release;
                        if (Release != null)
                            Release(this, new InteractionEventArgs(state));
                    }
                    else
                    {
                        state = InteractionState.Hover;
                        if (Hover != null)
                            Hover(this, new InteractionEventArgs(state));
                    }
                }
            }
            else
                state = InteractionState.None;
        }
    }
}

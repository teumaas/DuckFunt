using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes.Labels
{
    

    //class LabelInteractive : Label
    //{
    //    public Rectangle rectangle;
    //    public InteractionState state;
    //    public event InteractionEventHandler Click;

    //    public LabelInteractive(GraphicsInfos graphics, SpriteFont font, Vector2 position, string text)
    //        : base(graphics, font, location, text)
    //    {
    //        state = InteractionState.None;
    //    }

    //    public void Update(MouseState mouseState)
    //    {
    //        rectangle = new Rectangle((int)position.X, (int)position.Y, (int)font.MeasureString(text).X, (int)font.MeasureString(text).Y);

    //        if (mouseState.X > rectangle.X && mouseState.X < rectangle.X + rectangle.Width && mouseState.Y > rectangle.Y && mouseState.Y < rectangle.Y + rectangle.Width)
    //        {
    //            if (mouseState.LeftButton == ButtonState.Pressed && state == InteractionState.None)
    //            {
    //                Click(this, new InteractionEventArgs(state));
    //                state = InteractionState.Down;
    //            }
    //        }
    //        else
    //            state = InteractionState.None;
    //    }
    //}
}

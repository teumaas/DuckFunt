using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceHuntClasses.Classes;
using SpaceHuntClasses.Shapes;

namespace SpaceHuntClasses
{




    public class Shape
    {
        protected Texture2D texture;
        public Rectangle rectangle;


        public Shape(Texture2D texture, Rectangle rectangle)
        {
            this.texture = texture;
            this.rectangle = rectangle;
        }


        public virtual void Draw(SpriteBatch batch)
        {
             batch.Draw(texture, rectangle, Color.White);
        }
    }


    



    








    
}

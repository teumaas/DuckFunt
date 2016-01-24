using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes
{
    class LockedLevelShape : Shape
    {
        private Texture2D backgroundTexture;
        private Shape planetShape;

        public LockedLevelShape(GraphicsInfos graphics, Rectangle rectangle, Texture2D planetTexture) : base(graphics, rectangle)
        {
            ApplyPercentage(graphics.resolution);

            backgroundTexture = Utility.GetTexture(new Color(31, 31, 31));

            planetShape = new Shape(graphics, planetTexture, new Rectangle(this.rectangle.X + (this.rectangle.Width / 2), this.rectangle.Y + (this.rectangle.Height / 2), this.rectangle.Height / 2, this.rectangle.Height / 2));
            //planetShape.rectangle.X -= planetShape.rectangle.Width / 2;
            //planetShape.rectangle.Y -= planetShape.rectangle.Height / 2;
            planetShape.rectangle = new Rectangle(this.rectangle.X + (this.rectangle.Width / 2) - (planetShape.rectangle.Width / 2), this.rectangle.Y + (this.rectangle.Height / 2) - (planetShape.rectangle.Height / 2), planetShape.rectangle.Width, planetShape.rectangle.Width);
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(backgroundTexture, rectangle, Color.White);
            planetShape.Draw(batch);
        }
    }
}

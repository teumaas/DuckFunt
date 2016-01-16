using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceHuntClasses.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Screens
{
    interface IScreen
    {
        void Initialize(GraphicsInfos graphics);
        void LoadContent();
        void Update(InputState input, GameTime gameTime);
        void Draw(SpriteBatch batch);
    }
}

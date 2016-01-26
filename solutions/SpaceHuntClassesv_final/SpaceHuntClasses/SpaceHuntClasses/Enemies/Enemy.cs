using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceHuntClasses.Enemies;
using SpaceHuntClasses.Enemies.Movements;
using SpaceHuntClasses.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Enemys
{
    public delegate void EnemyEventHandler(object sender, EventArgs e);

    class Enemy
    {
        private Rectangle rectangle;
        private Texture2D ufoTexture;
        private Texture2D alienTexture;
        private Texture2D alienDeadTexture;
        private int health;
        private ControlState oldControlState;
        private InteractionState interactionState;
        private UfoMovement ufoMovement;
        private Shape ufoShape;
        private Shape alienShape;
        private int count;

        public event EnemyEventHandler Shot;
        public event EnemyEventHandler Dead;

        public Enemy(GraphicsInfos graphics, Rectangle field, Vector2 position, Texture2D ufoTexture, Texture2D alienTexture, Texture2D alienDeadTexture)
        {
            ufoShape = new Shape(graphics, ufoTexture, new Rectangle((int)position.X, (int)position.Y, 0, 0));
            ufoShape.ResizeWithTexture(graphics.resolution);

            alienShape = new Shape(graphics, alienTexture, new Rectangle((int)position.X, (int)position.Y, 0, 0));
            alienShape.ResizeWithTexture(graphics.resolution);

            this.rectangle = ufoShape.rectangle;

            this.ufoTexture= ufoTexture;
            this.alienTexture= alienTexture;
            this.alienDeadTexture = alienDeadTexture;
            health = 2;
            oldControlState = ControlState.Release;
            interactionState = InteractionState.None;
            ufoMovement = new UfoMovement(field, new Vector2(rectangle.X, rectangle.Y));

            count = 0;
            
        }

        public void Update(InputState input, GameTime gameTime)
        {
            if (Utility.CheckBorders(rectangle, input.X, input.Y))
            {
                if (input.shootControl == ControlState.Pressed)//&& oldControlState != ControlState.Pressed
                {
                    if (interactionState == InteractionState.Hover)
                    {
                        if (health == 2)
                            Explode();
                        else if(health == 1)
                            Kill();
                        oldControlState = ControlState.Pressed;
                    }
                    else
                        oldControlState = ControlState.Release;
                }
                else if(interactionState != InteractionState.Down)
                {
                    oldControlState = ControlState.Release;
                    interactionState = InteractionState.Hover;
                }
            }
            else
            {
                oldControlState = ControlState.Release;
                interactionState = InteractionState.None;
            }



            if(health == 2)
            {
                ufoMovement.Move();
                rectangle.X = (int)ufoMovement.GetPosition().X;
                rectangle.Y = (int)ufoMovement.GetPosition().Y;
                ufoShape.rectangle = rectangle;
            }
            else
            {
                rectangle.Y += 2;
                alienShape.rectangle = rectangle;
            }

            
        }

        public void Draw(SpriteBatch batch)
        {
            ufoShape.Draw(batch);

            if(health == 2)
            {
                //batch.Draw(ufoTexture, rectangle, Color.White);
            }
            else
            {
                alienShape.Draw(batch);
            }


        }

        public void Explode()
        {
            Shot(this, new EventArgs());
            health--;
            rectangle.Y += rectangle.Height;
            rectangle = new Rectangle(rectangle.X, rectangle.Y, alienShape.rectangle.Width, alienShape.rectangle.Height);
        }

        public void Kill()
        {
            Dead(this, new EventArgs());
            alienShape.SetTexture(alienDeadTexture);
        }

        public bool IsDead()
        {
            return health < 1;
        }

        public bool IsFlying()
        {
            return health > 1;
        }
    }
}

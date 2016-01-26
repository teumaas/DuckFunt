using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SpaceHuntClasses.Shapes;
using SpaceHuntClasses.Shapes;
using SpaceHuntClasses.Levels;
using System.Threading;
using SpaceHuntClasses.Shapes.Labels;
using SpaceHuntClasses.Enemys;
using SpaceHuntClasses.Screens;


namespace SpaceHuntClasses
{
    public enum GameScreenState { Loading, Game}

    public class GameScreen : IScreen
    {
        private Main main;
        private Level level;
        private LoadScreen loadScreen;
        private GameScreenState gameScreenState;
        private Random random;
        private Shape backgroundShape;
        private GraphicsInfos graphics;
        private Rectangle enemyField;
        private WaveBar waveBar;

        private Timer enemyTimer;
        //private GameData gameData;

        private Player player;

        private List<Enemy> enemies;

        private int wave;

        private Shape scoreHUD;
        private Shape healthHUD;
        private Shape ammoHUD;

        private Label scoreLabel;
        private Label healtLabel;
        private Label ammoLabel;

        private Texture2D scoreTexture;
        private Texture2D healthTexture;
        private Texture2D ammoTexture;

        private Texture2D ufoTexture;
        private Texture2D alienTexture;
        private Texture2D alienDeadTexture;

        private Texture2D wavebarFrameTexture;
        private Texture2D wavebarValueTexture;


        public GameScreen(Main main, GraphicsInfos graphics)
        {
            this.main = main;
            LoadContent();
            Initialize(graphics);        
        }


        public void Initialize(GraphicsInfos graphics)
        {
            wave = 1;
            enemies = new List<Enemy>();
            random = new Random();
            this.graphics = graphics;
            enemyTimer = new Timer(3000);
            enemyTimer.Tick += OnTickEnemySpawn;
            player = new Player();
            waveBar = new WaveBar(new Vector2(0, 0), wavebarFrameTexture, wavebarValueTexture);

            enemyField = new Rectangle(0, 0, graphics.resolution.width, graphics.resolution.height / 2);

            loadScreen = new LoadScreen(main, graphics);
            loadScreen.Finish += LoadScreenOnFinish;
            backgroundShape = new Shape(graphics, new Rectangle(0, 0, 100, 100));
            backgroundShape.rectangle = new Rectangle(0, 0, graphics.resolution.width, graphics.resolution.height);

            scoreHUD = new Shape(graphics, scoreTexture, new Rectangle(5, 95, 0, 0));
            ammoHUD = new Shape(graphics, ammoTexture, new Rectangle(95, 95, 0, 0));
            healthHUD = new Shape(graphics, healthTexture, new Rectangle(50, 95, 0, 0));

            scoreHUD.ApplyPositionPercentage(graphics.resolution);
            scoreHUD.ResizeWithTexture(graphics.resolution);

            ammoHUD.ApplyPositionPercentage(graphics.resolution);
            ammoHUD.ResizeWithTexture(graphics.resolution);

            healthHUD.ApplyPositionPercentage(graphics.resolution);
            healthHUD.ResizeWithTexture(graphics.resolution);

            scoreHUD.rectangle.Y -= scoreHUD.rectangle.Height;
            healthHUD.rectangle.X -= healthHUD.rectangle.Width / 2;
            healthHUD.rectangle.Y -= healthHUD.rectangle.Height;
            ammoHUD.rectangle.X -= ammoHUD.rectangle.Width;
            ammoHUD.rectangle.Y -= ammoHUD.rectangle.Height;

            scoreLabel = new Label(graphics, main.fontSize14, new Vector2(scoreHUD.rectangle.X, scoreHUD.rectangle.Y), player.score + "");
            healtLabel = new Label(graphics, main.fontSize14, new Vector2(healthHUD.rectangle.X, healthHUD.rectangle.Y), player.health + "/10");
            ammoLabel = new Label(graphics, main.fontSize14, new Vector2(ammoHUD.rectangle.X, ammoHUD.rectangle.Y), "30/30");

        }

        public void LoadContent()
        {
            scoreTexture = main.Content.Load<Texture2D>("textures/scoreHUD");
            healthTexture = main.Content.Load<Texture2D>("textures/healthHUD");
            ammoTexture = main.Content.Load<Texture2D>("textures/ammoHUD");

            ufoTexture = main.Content.Load<Texture2D>("textures/enemies/ufo");
            alienTexture = main.Content.Load<Texture2D>("textures/enemies/alienParachute");
            alienDeadTexture = main.Content.Load<Texture2D>("textures/enemies/alienDead");

            wavebarFrameTexture = main.Content.Load<Texture2D>("textures/waveBarFrame");
            wavebarValueTexture = main.Content.Load<Texture2D>("textures/waveBarValue");
        }

        public void Update(InputState input, GameTime gameTime)
        {
            if(gameScreenState == GameScreenState.Game)
            {
                foreach(var e in enemies)
                {
                    e.Update(input, gameTime);
                }
            }
            else
            {
                loadScreen.Update(input, gameTime);
            }

            enemyTimer.Update(gameTime);

            //LABELS
            scoreLabel.text = player.score + "";
            healtLabel.text = player.health + "/10";
            ammoLabel.text = "30/30";
        }

        public void Draw(SpriteBatch batch)      
        {
            if(gameScreenState == GameScreenState.Game)
            {
                backgroundShape.Draw(batch);

                //HUD
                scoreHUD.Draw(batch);
                healthHUD.Draw(batch);
                ammoHUD.Draw(batch);
                scoreLabel.Draw(batch);
                healtLabel.Draw(batch);
                ammoLabel.Draw(batch);


                //ENEMY
                foreach(var e in enemies)
                {
                    e.Draw(batch);
                }

                waveBar.Draw(batch);
            }
            else
            {
                loadScreen.Draw(batch);
            }
        }
        
        public void Start(Level level)
        {
            this.level = level;
            level.LoadGameTexture(main.Content);
            backgroundShape.SetTexture(level.gameTexture);


            loadScreen.Start(level.index);
            gameScreenState = GameScreenState.Loading;

            enemyTimer.Start();
        }

        public void LoadScreenOnFinish(object sender, EventArgs e)
        {
            gameScreenState = GameScreenState.Game;
        }

        public void EnemyShot(object sender, EventArgs e)
        {
            player.AddPoint(10);
        }

        public void EnemyDead(object sender, EventArgs e)
        {
            player.AddPoint(15);
        }

        public void PlayerShot()
        {

        }

        public void OnTickEnemySpawn(object sender, EventArgs e)
        {
            if (enemies.Count < 10)
            {
                var enemy = new Enemy(graphics, enemyField, new Vector2(random.Next(0, enemyField.Width), random.Next(0, enemyField.Height)), ufoTexture, alienTexture, alienDeadTexture);
                enemy.Shot += EnemyShot;
                enemy.Dead += EnemyDead;

                enemies.Add(enemy);
            }
            else if(AllEnemiesDead())
            {
                NextWave();
            }
            
        }

        public void NextWave()
        {
            wave++;
            waveBar.NewWave();
            enemies = new List<Enemy>();
        }

        private bool AllEnemiesDead()
        {
            foreach(var e in enemies)
            {
                if (e.IsFlying())
                    return false;
            }
            return true;
        }
    }
}

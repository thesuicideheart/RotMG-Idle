using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

using MonoGame.Extended;
using System.Collections.Generic;
using MysteryBox.Core;

namespace MysteryBox
{

    public static class Option
    {
        public const int Width = 800;
        public const int Height = 600;
        public const int FPS = 60;
    }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        LootBoxAnimationHandler LootBoxAnimationHandler;

        public SpriteFont font, TimerFont;

        public InputManager input;

        public static Game1 Instance;

        public State CurrentState;

        public Dictionary<string, State> states = new Dictionary<string, State>();

        LootBox box;

        public Player player;

        public InventoryState InventoryState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Instance = this;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.xd 
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Sprites.Load(Content);
            graphics.PreferredBackBufferWidth = Option.Width;
            graphics.PreferredBackBufferHeight = Option.Height;
            graphics.ApplyChanges();
            this.IsMouseVisible = true;
            this.IsFixedTimeStep = true;
            this.MaxElapsedTime = TimeSpan.FromSeconds(1f / Option.FPS);
            input = new InputManager(this);
            this.Components.Add(input);
            base.Initialize();
            GameData.Init();

            player = new Player();

            List<LootboxItem> items = new List<LootboxItem> {
                new LootboxItem("t0_katana",0,25000),
                new LootboxItem("t1_katana",25000,50000),
                new LootboxItem("t2_katana",50000,55000),
                new LootboxItem("t3_katana",55000,60000),
                new LootboxItem("t4_katana",60000,65000),
                new LootboxItem("t5_katana",65000,70000),
                new LootboxItem("t6_katana",70000,75000),
                new LootboxItem("t7_katana",75000,80000),
                new LootboxItem("t8_katana",80000,85000),
                new LootboxItem("t9_katana",85000,90000),
                new LootboxItem("t10_katana",90000,95000),
                new LootboxItem("t11_katana",95000,97000),
                new LootboxItem("t12_katana",97000,99000),
                new LootboxItem("t13_katana",99000,100000)
            };

            box = new LootBox("Test crate", items);

            LootBoxAnimationHandler = new LootBoxAnimationHandler();

            InventoryState = new InventoryState();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("font");
            TimerFont = Content.Load<SpriteFont>("TimerFont");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }



        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            CurrentState.Update();
            LootBoxAnimationHandler.Update();

            if (input.JustPressed(Keys.E))
            {
                SwitchState(GameData.InvState);
            }

            if (input.JustPressed(Keys.F))
            {
                if (CurrentState.ID != GameData.InvState)
                    LootBoxAnimationHandler.OpenBox(box, player.Inventory);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            LootBoxAnimationHandler.Draw(spriteBatch);

            CurrentState.Draw(spriteBatch);

            drawString($"Mouse pos: {input.GetMousePosition().ToString()}", 0, 0);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void SwitchState(string id)
        {
            if (states.ContainsKey(id))
            {
                CurrentState = states[id];
            }
        }

        public void draw(Texture2D texture, Rectangle rect)
        {
            spriteBatch.Draw(texture, rect, Color.White);
        }

        public void drawString(string text, int x, int y)
        {
            spriteBatch.DrawString(font, text, new Vector2(x, y), Color.White);
        }
    }
}

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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public List<LootboxItem> Items = new List<LootboxItem>();

        SpriteFont font;

        InputManager input;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        LootBox box;

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
            GameData.Init();
            graphics.PreferredBackBufferWidth = Option.Width;
            graphics.PreferredBackBufferHeight = Option.Height;
            graphics.ApplyChanges();
            this.IsMouseVisible = true;
            this.IsFixedTimeStep = true;
            this.MaxElapsedTime = TimeSpan.FromSeconds(1f / Option.FPS);
            input = new InputManager(this);
            this.Components.Add(input);
            base.Initialize();


            List<LootboxItem> items = new List<LootboxItem> {
                new LootboxItem("Ya yeet!",0,1000),
                new LootboxItem("Oh boie!",1000,20000),
                new LootboxItem("Yeah man!",20000,35000),
                new LootboxItem("For fuck sake",35000,65000),
                new LootboxItem("God dammit",65000,85000),
                new LootboxItem("Holy lord please fuck me",85000,90000),
                new LootboxItem("Unholy satan. Yikes",90000, 95000),
                new LootboxItem("Boi.",95000, 100000)
            };

            box = new LootBox(items);
            
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (input.JustPressed(Keys.F))
            {
                var item = box.GetItem();
                Items.Add(item);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            for(int i = 0; i < Items.Count; i++)
            {
                drawString(Items[i].ItemId, 0, 30 * i);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void drawString(string text, int x, int y)
        {
            spriteBatch.DrawString(font, text, new Vector2(x, y), Color.White);
        }
    }
}

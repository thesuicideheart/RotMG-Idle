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

        public List<InventoryItem> Items = new List<InventoryItem>();

        LootBoxAnimationHandler LootBoxAnimationHandler;

        public SpriteFont font,TimerFont;

        public InputManager input;

        public static Game1 Instance;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Instance = this;
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


            List<LootboxItem> items = new List<LootboxItem> {
                new LootboxItem("verts_item",0,40000),
                new LootboxItem("mindless_item",40000,80000),
                new LootboxItem("test_item",80000,100000)
            };



            box = new LootBox(items);

            LootBoxAnimationHandler = new LootBoxAnimationHandler();
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            LootBoxAnimationHandler.Update();

            if (input.JustPressed(Keys.F))
            {
                LootBoxAnimationHandler.OpenBox(box, Items);
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

            for (int i = 0; i < Items.Count; i++)
            {
                //Todo: Debug this
                var item = GameData.GetItemFromId(Items[i].ItemID);
                Vector2 position = new Vector2();
                position.X = 0;
                position.Y = 40 * i;

                drawString(item.Name, (int)position.X + 40, (int)position.Y + 10);
                draw(item.GetTexture(), new Rectangle((int)position.X, (int)position.Y, 40, 40));
                spriteBatch.DrawRectangle(new RectangleF(position.X, position.Y, Option.Width, 40), Color.Black, 3);

            }

            spriteBatch.End();

            base.Draw(gameTime);
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

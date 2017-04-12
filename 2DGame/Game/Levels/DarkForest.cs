using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2DGame
{

    class DarkForest : Level
    {
        /// <summary>
        /// The level complete
        /// </summary>
        public bool levelComplete;

        /// <summary>
        /// The end post
        /// </summary>
        Platform endPost;

        /// <summary>
        /// The check point
        /// </summary>
        Vector2 checkPoint;

        /// <summary>
        /// The particles
        /// </summary>
        List<Texture> particles;

        /// <summary>
        /// The crystals
        /// </summary>
        List<Crystal> crystals;

        /// <summary>
        /// The spikes
        /// </summary>
        List<Spikes> spikes;

        /// <summary>
        /// The player
        /// </summary>
        public Player player;

        /// <summary>
        /// The camera
        /// </summary>
        public Camera camera;

        /// <summary>
        /// The crystals collected
        /// </summary>
        public int crystalsCollected;

        /// <summary>
        /// The total crystals in the level
        /// </summary>
        public int totalCrystals;

        /// <summary>
        /// The background
        /// </summary>
        List<BackgroundImage> background;

        /// <summary>
        /// The middleground
        /// </summary>
        List<BackgroundImage> middleground;

        /// <summary>
        /// The foreground
        /// </summary>
        List<BackgroundImage> foreground;

        /// <summary>
        /// The trees
        /// </summary>
        List<Texture> trees;

        /// <summary>
        /// The surface particle engine
        /// </summary>
        SurfaceParticleEngine sp;

        /// <summary>
        /// Initializes a new instance of the <see cref="DarkForest"/> class.
        /// </summary>
        /// <param name="cam">The camera.</param>
        public DarkForest(Camera cam)
        {
            camera = cam;
            Initialise();          
        }

        /// <summary>
        /// Initialises this instance.
        /// </summary>
        public override void Initialise()
        {
            levelComplete = false;
            crystalsCollected = 0;

            Random r = new Random();

            background = new List<BackgroundImage>();
            middleground = new List<BackgroundImage>();
            foreground = new List<BackgroundImage>();
            trees = new List<Texture>();
            particles = new List<Texture>();
            crystals = new List<Crystal>();
            spikes = new List<Spikes>();

            Texture ledge = Texture.Create("DarkForest/Platforms/tbg_3");
            Texture forestBackground = Texture.Create("DarkForest/Background/tbg_1");
            Texture flowerHangMiddle = Texture.Create("DarkForest/Background/tbg_2");
            Texture bigGnarlyTree = Texture.Create("DarkForest/Trees/s_2");
            Texture littleGrarlyTree = Texture.Create("DarkForest/Trees/s_6");
            Texture glowFlower = Texture.Create("DarkForest/Trees/s_1");
            Texture longPlatform = Texture.Create("DarkForest/Platforms/s_12");
            Texture treeBlock = Texture.Create("DarkForest/Trees/s_5");
            Texture rightRamp = Texture.Create("DarkForest/Platforms/s_13");
            Texture rampFlowerOverHang = Texture.Create("DarkForest/Background/s_16");
            Texture twistedTree = Texture.Create("DarkForest/Trees/s_3");
            Texture branchedTree = Texture.Create("DarkForest/Trees/s_4");
            Texture littlePlatform = Texture.Create("DarkForest/Platforms/s_11");
            Texture sideSpikes = Texture.Create("DarkForest/Crystals/s_21");
            Texture endFlowerOverHang = Texture.Create("DarkForest/Background/tbg_2_end");
            Texture endLedge = Texture.Create("DarkForest/Platforms/tbg_3_end");
            Texture bigSpikes = Texture.Create("DarkForest/Crystals/s_7");
            Texture spikeMound = Texture.Create("DarkForest/Crystals/spikeMound");
            Texture spikeRun = Texture.Create("DarkForest/Crystals/spikeRun");
            Texture middlePlatform = Texture.Create("DarkForest/Platforms/s_10");
            Texture spikeLedge = Texture.Create("DarkForest/Platforms/tbg_4");
            Texture middleHangFlowerFlip = Texture.Create("DarkForest/Background/tbg_2_flip");

            Texture rockBlock = Texture.Create("MagicForest/rockBlock");
            Texture middleRock = Texture.Create("MagicForest/tbg_10");
            Texture rockBlockRight = Texture.Create("MagicForest/rockBlockRight");
            Texture magicPlatform = Texture.Create("MagicForest/s_1_noS");
            Texture leftWisp = Texture.Create("MagicForest/s_9");
            Texture rightWisp = Texture.Create("MagicForest/s_7");
            Texture middleLedge = Texture.Create("MagicForest/tbg_4 - Copy");
            Texture crystalHang = Texture.Create("MagicForest/tbg_1");
            Texture magicForest = Texture.Create("MagicForest/tbg_2");
            Texture rockwall = Texture.Create("MagicForest/tbg_9");
            Texture greenHangMiddle = Texture.Create("MagicForest/tbg_13");

            Texture glowingFlower = Texture.Create("MagicForest/s_2");
            Texture glowingFlowerRight = Texture.Create("MagicForest/s_2_left");
            Texture levelEnd = Texture.Create("Voodoo/s_4");
            Texture goldPlatform = Texture.Create("Voodoo/s_24");


            trees.Add(littleGrarlyTree);
            trees.Add(bigGnarlyTree);
            trees.Add(treeBlock);
            trees.Add(twistedTree);
            trees.Add(branchedTree);

            particles.Add(Texture.Create("Particles/white"));

            particles.Add(Texture.Create("Particles/yellow"));

            //Tiled images in background
            Platform ledgeTile;

            //Tile images in foreground
            BackgroundImage overhangFlowers;
            BackgroundImage rampFlower;
            

            int length = 20;

            player = new Player(new Vector2(100, 0));
            checkPoint = new Vector2(100, 0);

            //Add all the background images
            for (int k= 0; k < length; k++)
            {                                                          
                background.Add(new BackgroundImage(forestBackground, new Vector2(k * forestBackground.Width, -512)));                             
            }

            //Add all the middleground images
            //Add ledges and trees
            for (int k = 0; k < length; k++)
            {
                ledgeTile = new Platform(ledge, new Vector2(k * ledge.Width, 0));
                if (k == length - 6)
                {
                    ledgeTile = new Platform(spikeLedge, new Vector2(k * ledge.Width, 0));
                }
                if (k == length - 4)
                {
                    ledgeTile = new Platform(spikeLedge, new Vector2(k * ledge.Width, 0));
                }

                if (k == length-1)
                {
                    ledgeTile = new Platform(endLedge, new Vector2(k * ledge.Width, 0));
                }
                m_platforms.Add(ledgeTile);               
            }

            for(int k=0; k < length; k++)
            {
                if(k < length-1)
                {
                    //Generate trees for the middle ground
                    middleground.Add(new BackgroundImage(trees[r.Next(0, trees.Count)], new Vector2(k * 512 + 512, -512)));                
                }             
            }

            //Add all the foreground images
            for (int j = 0; j < length; j++)
            {
                overhangFlowers = new BackgroundImage(flowerHangMiddle, new Vector2(j * flowerHangMiddle.Width, -512 - 180));
                if(j == length -1)
                {
                    overhangFlowers = new BackgroundImage(endFlowerOverHang, new Vector2(j * flowerHangMiddle.Width, -512 - 180));
                }
                foreground.Add(overhangFlowers);
            }
            for(int j=0; j < length; j++)
            {
                rampFlower = new BackgroundImage(rampFlowerOverHang, new Vector2( (512 * length) + (2 * 512 * j), -512 -180));
            }

            crystals.Add(new Crystal(new Vector2(865, -405), new Vector2(865, -395), 2));
            m_platforms.Add(new Platform(treeBlock, new Vector2(0, -512)));
            m_platforms.Add(new MovingPlatform(longPlatform, new Vector2(512, -256), new Vector2(1024, -256), 5));
            camera.SetPosition(new Vector2(-50, -600));

            spikes.Add(new Spikes(spikeMound, new Vector2(4224, -245)));
            spikes.Add(new Spikes(spikeRun, new Vector2(6000, -120)));

            m_platforms.Add(new MovingPlatform(littlePlatform, new Vector2(5517, -90), new Vector2(5532, -320), 3));
            m_platforms.Add(new Platform(littlePlatform, new Vector2(5866, -320)));
            
            crystals.Add(new Crystal(new Vector2(6198, -425), new Vector2(6198, -455),2));
            m_platforms.Add(new Platform(littlePlatform, new Vector2(6180, -271)));
            m_platforms.Add(new Platform(middlePlatform, new Vector2(4243, -236)));
            m_platforms.Add(new Platform(longPlatform, new Vector2(6496, -271)));

            crystals.Add(new Crystal(new Vector2(6622, -425), new Vector2(6622, -455), 2));
            crystals.Add(new Crystal(new Vector2(6863, -425), new Vector2(6863, -455), 2));
            spikes.Add(new Spikes(bigSpikes, new Vector2(7359, 52)));
            spikes.Add(new Spikes(bigSpikes, new Vector2(8382, 52)));


            for (int i = 0; i < length; i++)
            {
                foreground.Add(new BackgroundImage(middleHangFlowerFlip, new Vector2(512 * i + 200, -803)));
            }
            for (int i = 0; i < length; i++)
            {
                foreground.Add(new BackgroundImage(middleHangFlowerFlip, new Vector2(512 * i, -803)));
            }
            for (int i = 0; i < length; i++)
            {
                foreground.Add(new BackgroundImage(middleHangFlowerFlip, new Vector2(512 * i + 200, -900)));
            }
            for (int i = 0; i < length; i++)
            {
                foreground.Add(new BackgroundImage(flowerHangMiddle, new Vector2(512 * i, -950)));
            }
            for (int i = 0; i < length; i++)
            {
                foreground.Add(new BackgroundImage(middleHangFlowerFlip, new Vector2(512 * i, -1000)));
            }

            foreground.Add(new BackgroundImage(rockBlock, new Vector2(9900,-512-180)));
            foreground.Add(new BackgroundImage(middleRock, new Vector2(10749,-512-180)));
            foreground.Add(new BackgroundImage(middleRock, new Vector2(11261, -512 - 180)));
            background.Add(new BackgroundImage(rockBlockRight, new Vector2(11773,-512-180)));

            m_platforms.Add(new MovingPlatform(magicPlatform, new Vector2(10488, 205), new Vector2(10714, 205), 5));
            m_platforms.Add(new Platform(magicPlatform, new Vector2(10405, -122)));

            crystals.Add(new Crystal(new Vector2(10496, 65)));
            crystals.Add(new Crystal(new Vector2(10657, 65)));

            m_platforms.Add(new MovingPlatform(magicPlatform, new Vector2(11240, 116), new Vector2(10999, 116), 4));

            crystals.Add(new Crystal(new Vector2(11166, 22)));
            crystals.Add(new Crystal(new Vector2(11311, 22)));
       

            for (int i = 0; i < length+3; i++)
            {
                background.Add(new BackgroundImage(rockwall, new Vector2(9900 + 512 * i, -512 - 180 - 512)));
                foreground.Add(new BackgroundImage(crystalHang, new Vector2(9900 + 512 * i, -710)));
            }

            for (int i = 0; i < length+3; i++)
            {
                background.Add(new BackgroundImage(rockwall, new Vector2(9900 + 512 * i, -512 - 180 - 512 - 512)));                
            }

            for (int i = 0; i < length+3; i++)
            {
                background.Add(new BackgroundImage(rockwall, new Vector2(9900 + 512 * i, -512 - 180 - 512 - 512 -512)));
            }
           

            m_platforms.Add(new Platform(magicPlatform, new Vector2(10829,-79)));
            m_platforms.Add(new MovingPlatform(magicPlatform, new Vector2(11580, -6), new Vector2(11756, -147), 4));
            m_platforms.Add(new Platform(magicPlatform, new Vector2(12056,-186)));
            m_platforms.Add(new Platform(magicPlatform, new Vector2(12496, -290)));

            crystals.Add(new Crystal(new Vector2(12146, -276)));
            crystals.Add(new Crystal(new Vector2(12565, -371)));

            m_platforms.Add(new Platform(magicPlatform,new Vector2(12920, -400)));

            crystals.Add(new Crystal(new Vector2(12290,-525)));
            m_platforms.Add(new Platform(magicPlatform, new Vector2(13319, -522)));

            crystals.Add(new Crystal(new Vector2(13009, -485)));
            crystals.Add(new Crystal(new Vector2(13401, -599)));
            m_platforms.Add(new Platform(magicPlatform, new Vector2(13758, -599)));


            m_platforms.Add(new Platform(leftWisp, new Vector2(15020-512, -180)));
            
            for (int i = 10; i < length; i++)
            {              
                m_platforms.Add(new Platform(middleLedge, new Vector2(9900 + 512 * i, -180)));
            }

            m_platforms.Add(new Platform(magicPlatform, new Vector2(14153, -840)));
            crystals.Add(new Crystal(new Vector2(14248, -935)));

            for(int i = 0; i < length*3; i++)
            {
                int choice = r.Next(-1, 2);
                if(choice == 1)
                {
                    foreground.Add(new BackgroundImage(glowingFlower, new Vector2(15000 + r.Next(0, 100) * i, -180 - 170)));
                }
                if(choice == 0)
                {
                    foreground.Add(new BackgroundImage(glowingFlowerRight, new Vector2(15000 + r.Next(0, 4500) + r.Next(0,200), -180 - 170)));
                }
                
            }

            m_platforms.Add(new Platform(rightWisp, new Vector2(20140, -180)));
            endPost = new Platform(levelEnd, new Vector2(20132,-292));
            sp = new SurfaceParticleEngine(particles, new Vector2(15000,-166), 5000, 1, 0.1f, 15);
            sp.SetEnabled(true);

            m_platforms.Add(new Platform(magicPlatform, new Vector2(14742, -599)));
            m_platforms.Add(new MovingPlatform(magicPlatform, new Vector2(14188, -519),new Vector2(14577,-346),4));
            m_platforms.Add(endPost);

            totalCrystals = crystals.Count;
        }

        /// <summary>
        /// Converts an image position to world space.
        /// </summary>
        /// <param name="imagePosition">The image position.</param>
        /// <param name="worldPosition">The world position.</param>
        /// <returns></returns>
        public Vector2 ImageToWorldSpace(Vector2 imagePosition, Vector2 worldPosition)
        {
            return (imagePosition + worldPosition) + new Vector2(0.5f,0.5f);
        }

        /// <summary>
        /// Converts a world position to a world position of a second image.
        /// </summary>
        /// <param name="worldPosition">The world position.</param>
        /// <param name="worldPosition2">The world position2.</param>
        /// <returns></returns>
        public Vector2 WorldToImageSpace(Vector2 worldPosition, Vector2 worldPosition2)
        {
            return worldPosition - worldPosition2;
        }

        /// <summary>
        /// Checks if a pixel collision has occurred.
        /// </summary>
        /// <param name="t1">The texture of object1..</param>
        /// <param name="object1Position">The object1 position.</param>
        /// <param name="t2">The texture of object2.</param>
        /// <param name="object2Position">The object2 position.</param>
        /// <returns></returns>
        public bool PixelCollision(Texture t1, Vector2 object1Position, Texture t2, Vector2 object2Position)
        {
            BoundingBox a = new BoundingBox(t1, object1Position);
            BoundingBox b = new BoundingBox(t2, object2Position);
            BoundingBox intersection = BoundingBox.Intersection(a, b);

            int xMin = (int)(intersection.GetPosition().X - object1Position.X);
            int yMin = (int)(intersection.GetPosition().Y - object1Position.Y);
            int xMax = (int)(intersection.GetPosition().X + intersection.GetSize().X - object1Position.X);
            int yMax = (int)(intersection.GetPosition().Y + intersection.GetSize().Y - object1Position.Y);

            for (int y = yMin; y < yMax; y++)
            {
                for (int x = xMin; x < xMax; x++)
                {
                    //Pixel in image space
                    Color pixelColor1 = t1.GetPixel(x, y);

                    //Only check for collision if the pixel has an alpha value over 0
                    //Otherwise pixel is transparent and we can't collide with it anyway
                    if(pixelColor1.A > 0)
                    {
                        //Pixel in world space from first image
                        Vector2 worldSpacePixel = ImageToWorldSpace(new Vector2(x, y), object1Position);
                        
                        //Where the pixel is in the second image
                        Vector2 image2SpacePixel = WorldToImageSpace(worldSpacePixel, object2Position);

                        //Check if the pixel is in the second image bounds
                        if (image2SpacePixel.X >= 0 && image2SpacePixel.X < t2.Width)
                        {
                            if (image2SpacePixel.Y >= 0 && image2SpacePixel.Y < t2.Height)
                            {
                                //Get the color of the pixel
                                Color pixelColor2 = t2.GetPixel(image2SpacePixel);
                                //If the alpha is greater than 0
                                if(pixelColor2.A > 0)
                                {
                                    //We must be colliding
                                    return true;
                                }
                            }
                        }
                    }
                                     
                }
            }
            return false;
        }


        /// <summary>
        /// Checks if the player is colliding.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <returns></returns>
        public bool PlayerCollision(GameTime gameTime)
        {
            BoundingBox temp;
            BoundingBox pb = player.GetBoundingBox(gameTime);

            for(int i =0; i < m_platforms.Count; i++)
            {
                temp = new BoundingBox(m_platforms[i].GetTexture(), m_platforms[i].GetPosition());

                if (BoundingBox.Intersects(pb, temp))
                {
                    if (PixelCollision(player.GetCurrentTexture(gameTime), player.GetPosition(), m_platforms[i].GetTexture(), m_platforms[i].GetPosition()))
                    {
                        if (m_platforms[i].IsMoving())
                        {
                            player.AddToPosition(m_platforms[i].GetChangeInPosition());
                        }

                        return true;
                    }                   
                }
            }

            for (int i = 0; i < spikes.Count; i++)
            {
                temp = new BoundingBox(spikes[i].GetTexture(), spikes[i].GetPosition());

                if (PixelCollision(player.GetCurrentTexture(gameTime), player.GetPosition(), spikes[i].GetTexture(), spikes[i].GetPosition()))
                {
                    player.IsDead(true);                                 
                }
            }

            for (int i = 0; i < crystals.Count; i++)
            {
                temp = new BoundingBox(crystals[i].GetTexture(), crystals[i].GetPosition());

                if (PixelCollision(player.GetCurrentTexture(gameTime), player.GetPosition(), crystals[i].GetTexture(), crystals[i].GetPosition()))
                {
                    crystals.Remove(crystals[i]);
                    crystalsCollected++;
                }
            }


            if (player.GetPosition().X > endPost.GetPosition().X)
            {
                if(crystals.Count == 0)
                {
                    levelComplete = true;
                }
            }

            return false;
        }

        /// <summary>
        /// Updates the level.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public override void Update(GameTime gameTime)
        {
            sp.Update((float)gameTime.TotalGameTime.TotalSeconds);

            if(player.GetPosition().Y > 10200)
            {
                player.IsDead(true);
            }
              
            for (int j = 0; j < m_platforms.Count; j++)
            {
                m_platforms[j].Update(gameTime);
            }
            for(int j=0; j < crystals.Count; j++)
            {
                crystals[j].Update(gameTime);
            }

            player.Update(gameTime);
            player.AddToPosition(player.GetVelocity());

            if(PlayerCollision(gameTime))
            {
                player.SetVelocityY(0);
                player.SetPosition(IslandSearch(gameTime));
            }
            player.SetVelocityY(player.GetVelocity().Y + 2f);
            //player.m_velocity.Y += 2f;
            player.SetVelocityX(player.GetVelocity().X * 0.5f);
            //player.m_velocity.X *= 0.5f;            
        }

        /// <summary>
        /// Performs an star shaped island search and returns a new position for the player.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <returns></returns>
        public Vector2 IslandSearch(GameTime gameTime)
        {
            //Diamond search

            ////return player.m_position;
            //Vector2 pos = player.m_position;

            //if (!CheckPlayerCollisionPos(pos + new Vector2(0, 0), gameTime))
            //    return pos + new Vector2(0, 0);

            //if (!CheckPlayerCollisionPos(pos + new Vector2(0, 1), gameTime))
            //    return pos + new Vector2(0, 1);

            //if (!CheckPlayerCollisionPos(pos + new Vector2(1, 0), gameTime))
            //    return pos + new Vector2(1, 0);

            //if (!CheckPlayerCollisionPos(pos + new Vector2(-1, 0), gameTime))
            //    return pos + new Vector2(-1, 0);

            //if (!CheckPlayerCollisionPos(pos + new Vector2(0, -1), gameTime))
            //    return pos + new Vector2(0, -1);

            //int steps = 2;
            //while (true)
            //{
            //    for (int a = steps - steps / 2; a <= steps; a++)
            //    {
            //        int b = steps - a;

            //        if (!CheckPlayerCollisionPos(pos + new Vector2(b, a), gameTime))
            //            return pos + new Vector2(b, a);

            //        if (!CheckPlayerCollisionPos(pos + new Vector2(-b, a), gameTime))
            //            return pos + new Vector2(-b, a);

            //        if (!CheckPlayerCollisionPos(pos + new Vector2(a, b), gameTime))
            //            return pos + new Vector2(a, b);

            //        if (!CheckPlayerCollisionPos(pos + new Vector2(-a, b), gameTime))
            //            return pos + new Vector2(-a, b);

            //        if (!CheckPlayerCollisionPos(pos + new Vector2(a, -b), gameTime))
            //            return pos + new Vector2(a, -b);

            //        if (!CheckPlayerCollisionPos(pos + new Vector2(-a, -b), gameTime))
            //            return pos + new Vector2(-a, -b);

            //        if (!CheckPlayerCollisionPos(pos + new Vector2(b, -a), gameTime))
            //            return pos + new Vector2(b, -a);

            //        if (!CheckPlayerCollisionPos(pos + new Vector2(-b, -a), gameTime))
            //            return pos + new Vector2(-b, -a);
            //    }
            //    ++steps;
            //}


            //Star search
            Vector2 tryNewPos;
            Vector2 result = new Vector2(0, 0);
            //Let everything happen then fix the the position so we aren't colliding with anything anymore
            int moveLayer = 1;
            //While there is a collision move up, down, left and right until no collision

            Vector2 oldPos = player.GetPosition();

            while (true)
            {
                //Move up
                tryNewPos = new Vector2(oldPos.X, oldPos.Y - moveLayer);
                player.SetPosition(tryNewPos);
                if (PlayerCollision(gameTime))
                {
                    //Didn't work
                    player.SetPosition(oldPos);
                }
                else
                {
                    result = tryNewPos;
                    break;
                }

                //Move down
                tryNewPos = new Vector2(oldPos.X, oldPos.Y + moveLayer);
                player.SetPosition(tryNewPos);
                if (PlayerCollision(gameTime))
                {
                    //Didn't work
                    player.SetPosition(oldPos);
                }
                else
                {
                    result = tryNewPos;
                    break;
                }

                //Move left
                tryNewPos = new Vector2(oldPos.X - moveLayer, oldPos.Y);
                player.SetPosition(tryNewPos);
                if (PlayerCollision(gameTime))
                {
                    //Didn't work
                    player.SetPosition(oldPos);
                }
                else
                {
                    result = tryNewPos;
                    break;
                }

                //Move right
                tryNewPos = new Vector2(oldPos.X + moveLayer, oldPos.Y);
                player.SetPosition(tryNewPos);
                if (PlayerCollision(gameTime))
                {
                    //Didn't work
                    player.SetPosition(oldPos);
                }
                else
                {
                    result = tryNewPos;
                    break;
                }

                //Move up and left           
                tryNewPos = new Vector2(oldPos.X - moveLayer, oldPos.Y - moveLayer);
                player.SetPosition(tryNewPos);
                if (PlayerCollision(gameTime))
                {
                    //Didn't work
                    player.SetPosition(oldPos);
                }
                else
                {
                    result = tryNewPos;
                    break;
                }

                //Move up and right         
                tryNewPos = new Vector2(oldPos.X + moveLayer, oldPos.Y - moveLayer);
                player.SetPosition(tryNewPos);
                if (PlayerCollision(gameTime))
                {
                    //Didn't work
                    player.SetPosition(oldPos);
                }
                else
                {
                    result = tryNewPos;
                    break;
                }

                //Move down and left
                tryNewPos = new Vector2(oldPos.X - moveLayer, oldPos.Y + moveLayer);
                player.SetPosition(tryNewPos);
                if (PlayerCollision(gameTime))
                {
                    //Didn't work
                    player.SetPosition(oldPos);
                }
                else
                {
                    result = tryNewPos;
                    break;
                }

                //Move down and right
                tryNewPos = new Vector2(oldPos.X - moveLayer, oldPos.Y + moveLayer);
                player.SetPosition(tryNewPos);
                if (PlayerCollision(gameTime))
                {
                    //Didn't work
                    player.SetPosition(oldPos);
                }
                else
                {
                    result = tryNewPos;
                    break;
                }

                moveLayer++;
            }

            return result;
        }

        /// <summary>
        /// Draws the level.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <param name="spriteBatch">The sprite batch.</param>
        /// <param name="spriteEffects">The sprite effects.</param>
        /// <param name="camera">The camera.</param>
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, SpriteEffects spriteEffects, Camera camera)
        {          
            for(int i =0; i < background.Count; i++)
            {
                background[i].Draw(spriteBatch, camera);
            }

            for (int i = 0; i < middleground.Count; i++)
            {
                middleground[i].Draw(spriteBatch, camera);
            }
           

            for (int j = 0; j < m_platforms.Count; j++)
            {
                m_platforms[j].Draw(spriteBatch, camera);
            }
            for(int i=0; i< spikes.Count; i++)
            {
                spikes[i].Draw(spriteBatch, camera);
            }

            for (int i = 0; i < crystals.Count; i++)
            {
                crystals[i].Draw(spriteBatch, camera);
            }

            for (int i= 0; i < foreground.Count; i++)
            {
                foreground[i].Draw(spriteBatch, camera);
            }

            sp.Draw(spriteBatch, camera);        
            player.Draw(gameTime, spriteBatch, spriteEffects, camera);          
        }

    }
}

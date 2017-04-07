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
        List<Texture> particles = new List<Texture>();
      
        public Player player;
        public Camera camera;

        public DarkForest(Camera cam)
        {
            camera = cam;
            Initialise();
            
        }

        public override void Initialise()
        {
            player = new Player(new Vector2(100, 0));                     
                     
            Platform tile;
            MovingPlatform plat1;
            BackgroundImage bg;
            BackgroundImage flowers;
            BackgroundImage tree1;
            BackgroundImage tree2;
            BackgroundImage glowflow1;

            Texture ledge = Texture.Create("DarkForest/Platforms/tbg_3");
            Texture forestbg = Texture.Create("DarkForest/Background/tbg_1");
            Texture flowerhang = Texture.Create("DarkForest/Background/tbg_2");
            Texture gnarlytree = Texture.Create("DarkForest/Trees/s_2");
            Texture lilgnarlytree = Texture.Create("DarkForest/Trees/s_6");
            Texture glowflower = Texture.Create("DarkForest/Trees/s_1");
            Texture longPlat = Texture.Create("DarkForest/Platforms/s_12");

            for (int k=0; k < 10; k++)
            {
                bg = new BackgroundImage(forestbg, new Vector2(k * forestbg.Width, -512)); 
                tile = new Platform(ledge, new Vector2(k*ledge.Width, 0));               
                m_platforms.Add(tile);
                m_images.Add(bg);                             
            }
            tree1 = new BackgroundImage(gnarlytree, new Vector2(0, -512));
            tree2 = new BackgroundImage(lilgnarlytree, new Vector2(1024, -512));
            glowflow1 = new BackgroundImage(glowflower, new Vector2(0, 0 - 190));
            m_images.Add(tree1);
            m_images.Add(tree2);
            m_images.Add(glowflow1);

            for (int j =0; j < 10; j++)
            {
                flowers = new BackgroundImage(flowerhang, new Vector2(j * flowerhang.Width, -512 - 180));                        
                m_images.Add(flowers);
            }

            plat1 = new MovingPlatform(longPlat, new Vector2(512, -256), new Vector2(1024, -256), 5);
            m_platforms.Add(plat1);
            camera.SetPosition(new Vector2(-50, -800));      
        }

        public Vector2 ImageToWorldSpace(Vector2 imagePosition, Vector2 worldPosition)
        {
            return (imagePosition + worldPosition) + new Vector2(0.5f,0.5f);
        }

        public Vector2 WorldToImageSpace(Vector2 worldPosition, Vector2 worldPosition2)
        {
            return worldPosition - worldPosition2;
        }

        public bool PixelCollision(Texture t1, Vector2 object1Position, Texture t2, Vector2 object2Position)
        {
            BoundingBox a = new BoundingBox(t1, object1Position);
            BoundingBox b = new BoundingBox(t2, object2Position);
            BoundingBox intersection = BoundingBox.Intersection(a, b);

            int xMin = (int)(intersection.m_position.X - object1Position.X);
            int yMin = (int)(intersection.m_position.Y - object1Position.Y);
            int xMax = (int)(intersection.m_position.X + intersection.m_size.X - object1Position.X);
            int yMax = (int)(intersection.m_position.Y + intersection.m_size.Y - object1Position.Y);

            //for(int y=0; y < t1.Height; y++)
            //{
            //    for(int x=0; x < t1.Width; x++)
            //    {
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

        public bool CheckPlayerCollisionPos(Vector2 newPos, GameTime gameTime)
        {
            Vector2 oldPos = player.m_position;
            player.m_position = newPos;
            bool result = PlayerCollision(gameTime);
            player.m_position = oldPos;
            return result;
        }

        public bool PlayerCollision(GameTime gameTime)
        {
            BoundingBox temp;
            BoundingBox pb = player.GetBoundingBox(gameTime);

            for(int i =0; i < m_platforms.Count; i++)
            {
                temp = new BoundingBox(m_platforms[i].m_texture, m_platforms[i].m_position);

                if (BoundingBox.Intersects(pb, temp))
                {
                    if (PixelCollision(player.GetCurrentTexture(gameTime), player.m_position, m_platforms[i].GetTexture(), m_platforms[i].m_position))
                        return true;
                }
            }

            return false;
        }

        public override void Update(GameTime gameTime)
        {                      
            for (int j = 0; j < m_platforms.Count; j++)
            {
                m_platforms[j].Update(gameTime);
            }

            player.Update(gameTime);          

            player.m_position += player.m_velocity;

            if(PlayerCollision(gameTime))
            {
                player.m_velocity.Y = 0;
                player.m_position = IslandSearch(gameTime);
            }

            player.m_velocity.Y += 2f;
            player.m_velocity.X *= 0.5f;            
        }

        public Vector2 IslandSearch(GameTime gameTime)
        {

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


            Vector2 tryNewPos;
            Vector2 result = new Vector2(0, 0);
            //Let everything happen then fix the the position so we aren't colliding with anything anymore
            int moveLayer = 1;
            //While there is a collision move up, down, left and right until no collision

            Vector2 oldPos = player.m_position;

            while (true)
            {
                //Move up
                tryNewPos = new Vector2(oldPos.X, oldPos.Y - moveLayer);
                player.m_position = tryNewPos;
                if (PlayerCollision(gameTime))
                {
                    //Didn't work
                    player.m_position = oldPos;
                }
                else
                {
                    result = tryNewPos;
                    break;
                }

                //Move down
                tryNewPos = new Vector2(oldPos.X, oldPos.Y + moveLayer);
                player.m_position = tryNewPos;
                if (PlayerCollision(gameTime))
                {
                    //Didn't work
                    player.m_position = oldPos;
                }
                else
                {
                    result = tryNewPos;
                    break;
                }

                //Move left
                tryNewPos = new Vector2(oldPos.X - moveLayer, oldPos.Y);
                player.m_position = tryNewPos;
                if (PlayerCollision(gameTime))
                {
                    //Didn't work
                    player.m_position = oldPos;
                }
                else
                {
                    result = tryNewPos;
                    break;
                }

                //Move right
                tryNewPos = new Vector2(oldPos.X + moveLayer, oldPos.Y);
                player.m_position = tryNewPos;
                if (PlayerCollision(gameTime))
                {
                    //Didn't work
                    player.m_position = oldPos;
                }
                else
                {
                    result = tryNewPos;
                    break;
                }

                //Move up and left           
                tryNewPos = new Vector2(oldPos.X - moveLayer, oldPos.Y - moveLayer);
                player.m_position = tryNewPos;
                if (PlayerCollision(gameTime))
                {
                    //Didn't work
                    player.m_position = oldPos;
                }
                else
                {
                    result = tryNewPos;
                    break;
                }

                //Move up and right         
                tryNewPos = new Vector2(oldPos.X + moveLayer, oldPos.Y - moveLayer);
                player.m_position = tryNewPos;
                if (PlayerCollision(gameTime))
                {
                    //Didn't work
                    player.m_position = oldPos;
                }
                else
                {
                    result = tryNewPos;
                    break;
                }

                //Move down and left
                tryNewPos = new Vector2(oldPos.X - moveLayer, oldPos.Y + moveLayer);
                player.m_position = tryNewPos;
                if (PlayerCollision(gameTime))
                {
                    //Didn't work
                    player.m_position = oldPos;
                }
                else
                {
                    result = tryNewPos;
                    break;
                }

                //Move down and right
                tryNewPos = new Vector2(oldPos.X - moveLayer, oldPos.Y + moveLayer);
                player.m_position = tryNewPos;
                if (PlayerCollision(gameTime))
                {
                    //Didn't work
                    player.m_position = oldPos;
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

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, SpriteEffects spriteEffects, Camera camera)
        {          
            for(int i =0; i < m_images.Count; i++)
            {
                m_images[i].Draw(spriteBatch, camera);
            }
            for(int j =0; j < m_platforms.Count; j++)
            {
                m_platforms[j].Draw(spriteBatch, camera);
            }
            player.Draw(gameTime, spriteBatch, spriteEffects, camera);          
        }

    }
}

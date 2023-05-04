using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EnemyMovement
{
    internal class EnemyMove
    {
        private Texture2D enemy;

        Rectangle pos;
        Boolean dir;
        Boolean once;
        public EnemyMove(Rectangle pos, Texture2D enemy)
        {
            this.pos = pos;
            dir = false;
            once = true;
            this.enemy = enemy;
        }

        public void Update(GameTime gametime)
        {
            
            if (once)
            {
                pos.X += 3;
                once = false;
            }
            if (gametime.ElapsedGameTime.TotalMilliseconds % 500 == 0 && dir)
            {
                pos.X += 6;
            }
            else if(gametime.ElapsedGameTime.TotalMilliseconds % 500 != 0 && !dir)
            {
                pos.X -= 6;
            }
            
        }

        public void Draw(SpriteBatch _spritebatch, GameTime gametime)
        { 
            _spritebatch.Begin();
            _spritebatch.Draw(enemy, pos, Color.White);
            _spritebatch.End();
        }


    }
}

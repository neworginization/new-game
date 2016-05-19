using joj_game.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace joj_game
{
  class doggo : Entity
  {
    new float X = 100;
    new float Y = 100;
    public void update()
    {

      if (KeyboardUtil.KeyPressed(Keys.W))
        X++;

    }

    public override void Draw(SpriteBatch spriteBatch)
    {
      spriteBatch.Draw(ContentLibrarby.Sprites["woman"], new Vector2(X, Y), new Rectangle(0, 0, 16, 16), Color.White);
      base.Draw(spriteBatch);
    }
  }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace joj_game
{
  class Entity
  {
    public float X;
    public float Y;
    public int ID = -1;
    public Vector2 XandY
    {
      get { return new Vector2(this.X, this.Y); }
      set
      {
        this.X = value.X;
        this.Y = value.Y;
      }
    }
    public Entity() { }

    public virtual void Update(GameTime gameTime) { }
    public virtual void UpdateEvenWhenPaused(GameTime gameTime) { }
    public virtual void Draw(SpriteBatch spriteBatch) { }
  }
}

using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace joj_game
{
  public static class ContentLibrarby
  {
    public static Dictionary<string, Texture2D> Sprites = new Dictionary<string, Texture2D>();
    public static Dictionary<string, SpriteFont> Fonts = new Dictionary<string, SpriteFont>();
    public static Dictionary<string, SoundEffect> Sounds = new Dictionary<string, SoundEffect>();

    public static void Init()
    {
      Sprites = Game1.GameContent.LoadListContent<Texture2D>("sprites");
      //Fonts = Game1.GameContent.LoadListContent<SpriteFont>("fonts");
      //Sounds = Game1.GameContent.LoadListContent<SoundEffect>("sounds");

      string pathBase = Game1.GameContent.RootDirectory + Path.DirectorySeparatorChar;
      
    }
    public static Dictionary<string, T> LoadListContent<T>(this ContentManager contentManager, string contentFolder)
    {
      DirectoryInfo dir = new DirectoryInfo(contentManager.RootDirectory + "/" + contentFolder);
      if (!dir.Exists)
        throw new DirectoryNotFoundException();
      Dictionary<String, T> result = new Dictionary<String, T>();

      FileInfo[] files = dir.GetFiles("*.*");
      foreach (FileInfo file in files)
      {
        string key = Path.GetFileNameWithoutExtension(file.Name);


        result[key] = contentManager.Load<T>(contentFolder + "/" + key);
      }
      DirectoryInfo[] directories = dir.GetDirectories();
      foreach (DirectoryInfo directory in directories)
      {
        Dictionary<string, T> nextDict = contentManager.LoadListContent<T>(contentFolder + Path.DirectorySeparatorChar + directory.Name);
        foreach (var i in nextDict)
        {
          result[directory.Name + ":" + i.Key] = i.Value;
        }
      }
      return result;
    }
  }
}

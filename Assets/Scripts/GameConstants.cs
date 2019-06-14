using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using System.IO;


public static class GameConstants {
    public enum Phase {Start, Reinforcement, Combat, Relocate, None};

    public static Color ConvertColor (float r, float g, float b, float a) {
        return new Color(r/255.0f, g/255.0f, b/255.0f, a/255.0f);
    }

    public static void ClearConsole()
    {
        var logEntries = System.Type.GetType("UnityEditor.LogEntries, UnityEditor.dll");
     
        var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
     
        clearMethod.Invoke(null, null);
    }

        public static class IMG2Sprite
    {
     
        //Static class instead of _instance
        // Usage from any other script:
        // MySprite = IMG2Sprite.LoadNewSprite(FilePath, [PixelsPerUnit (optional)], [spriteType(optional)])
     
        public static Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f, SpriteMeshType spriteType = SpriteMeshType.Tight)
        {
     
            // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference
     
            Sprite NewSprite;
            Texture2D SpriteTexture = LoadTexture(FilePath);
            NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit, 0 , spriteType);
     
            return NewSprite;
        }
     
        public static Sprite ConvertTextureToSprite(Texture2D texture, float PixelsPerUnit = 100.0f, SpriteMeshType spriteType = SpriteMeshType.Tight)
        {
            // Converts a Texture2D to a sprite, assign this texture to a new sprite and return its reference
     
            Sprite NewSprite;
            NewSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), PixelsPerUnit, 0, spriteType);
     
            return NewSprite;
        }
     
        public static Texture2D LoadTexture(string FilePath)
        {
     
            // Load a PNG or JPG file from disk to a Texture2D
            // Returns null if load fails
     
            Texture2D Tex2D;
            byte[] FileData;
     
            if (File.Exists(FilePath))
            {
                FileData = File.ReadAllBytes(FilePath);
                Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
                if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                    return Tex2D;                 // If data = readable -> return texture
            }
            return null;                     // Return null if load failed
        }
    }



}

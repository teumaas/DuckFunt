using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SpaceHunt
{
    class IntroScreen
    {
        Rectangle spriteBatch;
        SpriteBatch heroBatch;
        Rectangle textbox;
        Rectangle back;
        Rectangle destRec;
        Rectangle heroRec;
        Texture2D pic;
        Texture2D heroSheet;
        SpriteFont font;

        string text;
        string parsedText;
        string typedText;
        SoundEffect snd;
        Vector2 pos;
        SoundEffectInstance soundEffectIntance;
        double typedTextLength;
        int delayInMilliseconds;
        bool isDoneDrawing;
        float elapsed;
        float delay;
        int frames;
        int oneFrame;
        int recWidth;
        int recHeight;
        int frameHeight;
        int i;

        byte r;
        byte g;
        byte b;
        //Color color;

        private void IntroScreen()
        {
        }

        private void Drawback()
        {
        
        }
        private string ParseText(string text)
        {
            return text;
        }
        private double Delay(double milliseconds)
        {
            return milliseconds;
        }
        public void Run()
        { 
            
        }
    }
}

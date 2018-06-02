using System;
using System.Collections.Generic;
using ShTK.Content;
using ShTK.Divisions;
using ShTK.Graphics;
using ShTK.Input;

namespace ShTK.Screens
{
    public class Screen : Division
    {
        public string Name;

        protected ScreenOverhead Overhead => ScreenOverhead.GetInstance();

        public Screen()
        {
            Anchor = Anchor.TopLeft;
            Origin = Anchor.TopLeft;
        }
        
        public override void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    public class ScreenOverhead
    {
        private Stack<Screen> ScreenStack = new Stack<Screen>();

        private static ScreenOverhead instance = new ScreenOverhead();

        public App app;

        public static ScreenOverhead GetInstance()
        {
            return instance;
        }

        public Screen Peek()
        {
            if (ScreenStack.Count == 0)
            {
                return null;
            }
            else
            {
                return ScreenStack.Peek();
            }
        }

        public void Push (Screen s)
        {
            bool firstScreen = ScreenStack.Count == 0;
            ScreenStack.Push(s);
            if (!firstScreen)
                app.LoadAllContent();
        }

        ScreenOverhead()
        {

        }
    }
}
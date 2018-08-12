using System;

namespace MemeStory.Desktop
{
    public static class Program
    {
        const bool RunEditor = true;

        [STAThread]
        static void Main()
        {
            if (RunEditor)
            {
                using (var game = new LevelEditor.LevelEditor())
                    game.Run();
            }
            else
            {
                using (var game = new Game1())
                    game.Run();
            }            
        }
    }
}

using System;

namespace GameBrowser
{
    public class Program
    {
        [STAThread]
        static void Main()
        {
            using (GameBrowser.System.GameBrowser gameBrowser = new GameBrowser.System.GameBrowser())
            {
                gameBrowser.Run(30.0);
            }
        }
    }
    
}
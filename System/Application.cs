using System;

namespace GameBrowser.System
{
    public class Application
    {
        [STAThread]
        static void Main()
        {
            using (GameBrowser gameBrowser = new GameBrowser())
            {
                gameBrowser.Run(30.0);
            }
        }
    }
}
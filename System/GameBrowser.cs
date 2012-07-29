﻿using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using GameBrowser.DOM;
using GameBrowser.Style;
using GameBrowser.Render;

namespace GameBrowser.System
{
    class GameBrowser : GameWindow
    {
        private string m_sourcePath;

        private DOMTree m_domTree;
        private StyleRules m_styleRules;
        private RenderTree m_renderTree;

        private DOMTreeBuilder m_domTreeBuilder;
        private StyleRulesBuilder m_styleRulesBuilder;
        private RenderTreeBuilder m_renderTreeBuilder;


        public GameBrowser()
            : base(800, 600, GraphicsMode.Default, "Game Browser")
        {
            VSync = VSyncMode.On;
            m_domTreeBuilder = new DOMTreeBuilder();
            m_styleRulesBuilder = new StyleRulesBuilder();
            m_renderTreeBuilder = new RenderTreeBuilder();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadGame("../../game.xml");
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            m_renderTree.Resize(Width, Height); 
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (Keyboard[Key.Escape])
            {
                Exit();
            }
            if (Keyboard[Key.F5])
            {
                ReloadGame();
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);            
            m_renderTree.Render(e);
            SwapBuffers();
        }

        private void LoadGame(string sourcePath)
        {
            m_sourcePath = sourcePath;
            m_domTree = m_domTreeBuilder.Build(m_sourcePath);
            m_styleRules = m_styleRulesBuilder.Build(m_domTree);
            m_renderTree = m_renderTreeBuilder.Build(m_domTree, m_styleRules);
        }

        private void ReloadGame()
        {
            LoadGame(m_sourcePath);
        }
    }
}

using GameBrowser.Render.Element;

namespace GameBrowser.Render
{
    public class RenderTreeBuilder
    {
        public RenderTree Build() {
            var renderTree = new RenderTree();
            var box = new BoxElement(renderTree);
            var camera = new CameraElement(renderTree);
            var viewport = new ViewportElement(renderTree);

            camera.Children.Add(box);
            viewport.Children.Add(camera);
            renderTree.RootElement = viewport;

            return renderTree;
        }
    }
}

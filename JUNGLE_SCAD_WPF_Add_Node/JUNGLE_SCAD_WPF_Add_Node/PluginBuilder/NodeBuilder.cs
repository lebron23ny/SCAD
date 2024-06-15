using EditorClasses;
using EditorClasses.Object;
using EngineClasses;
using JUNGLE_SCAD_WPF_UI_Add_Node.Model;
using PUI = JUNGLE_SCAD_WPF_UI_Add_Node;

namespace JUNGLE_SCAD_WPF_Add_Node.PluginBuilder
{
    internal class NodeBuilder
    {
        private readonly EditorModelInfo _setting;
        private readonly Engine _engine;
        private readonly Editor _editor;

        public NodeBuilder(PUI.Model.EditorModelInfo modelInfo, Engine engine) 
        {
            _setting = modelInfo;
            _engine = engine;
            _editor = engine.GetEditor();
        }

        public void Build()
        {
            uint nodeNum = _editor.NodeAdd(1);

            string nameNode = _setting.Name;
            double coord_x = _setting.X;
            double coord_y = _setting.Y;
            double coord_z = _setting.Z;

            NodeEditor node_1 = new NodeEditor()
            {
                Text = nameNode,
                x = coord_x,
                y = coord_y,
                z = coord_z,
            };
            _editor.NodeUpdate(nodeNum, node_1);
        }
    }
}

using JUNGLE_SCAD_WPF_UI_Add_Node.Model;
using System;
using System.Runtime.InteropServices;
using PUI =JUNGLE_SCAD_WPF_UI_Add_Node;
using Newtonsoft.Json;

using Helpers;
using EngineClasses;
using JUNGLE_SCAD_WPF_Add_Node.PluginBuilder;

namespace JUNGLE_SCAD_WPF_Add_Node
{

    [ProgId("JUNGLE_SCAD_WPF_ADD_NODE")]
    //Create a new GUID
    [Guid("11C46954-50A2-4BBB-A4A2-79DEC0F0E6AB")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class ScadPluginClass : IScadPlugin
    {
        public void RunPlugin(dynamic engine, string jsonStr)
        {
            try
            {

                PUI.Model.EditorModelInfo modelInfo = 
                    JsonConvert.DeserializeObject<EditorModelInfo>(jsonStr);
                Engine engineSCAD = new Engine(engine);

                NodeBuilder editorCreator = new NodeBuilder(modelInfo, engineSCAD);
                editorCreator.Build();
            }
            catch(Exception ex)
            {
                ScadDebug.MessageShow(ex.Message);
            }
            finally
            {
                Marshal.ReleaseComObject((object)engine);
            }
        }

        public string Run_UI_Plugin(dynamic engine)
        {
            string str = string.Empty;
            try
            {
                PUI.MainWindow mainWindow = new PUI.MainWindow();
                mainWindow.ShowDialog();
                str = mainWindow.GetModelInfo();
            }
            finally
            {
                Marshal.ReleaseComObject((object)engine);
            }
            return str;
        }
    }



    //Create a new GUID
    [Guid("05997A22-3D57-4AF7-98BF-4B315458A62B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [ComVisible(true)]
    public interface IScadPlugin
    {
        [DispId(1)]
        void RunPlugin(dynamic engine, string jsonStr);
        [DispId(2)]
        string Run_UI_Plugin(dynamic engine);
    }

}

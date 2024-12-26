using EditorClasses;
using EditorClasses.Object;
using EngineClasses;
using Helpers;
using ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SCAD_CreateFrame
{

    [ProgId("ScadCreateFrame.Lib")]
    [Guid("708025B4-7DA4-4793-99F5-E760169A0F82")] //Сгенерировать свой
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class Class1 : IScad
    {
        public void Run(dynamic engine)
        {
            try
            {
                //#region Пример 1 вывод сообщения
                //ScadDebug.MessageShow("Hello SCAD");
                //#endregion

                #region Пример 2 Создание рамы
                Engine engineSCAD = new Engine(engine);
                Editor editor = engineSCAD.GetEditor();

                uint baseNodeNum1;
                uint baseNodeNum2;
                uint baseNodeNum3;
                uint baseNodeNum4;
                #region Создание узлов
                #region Первый узел
                baseNodeNum1 = editor.NodeAdd(1);

                NodeEditor node_1 = new NodeEditor()
                {
                    Text = "Узел 1",
                    x = 0,
                    y = 0,
                    z = 0,
                };
                editor.NodeUpdate(baseNodeNum1, node_1);
                
                #endregion
                #region Второй узел
                baseNodeNum2 = editor.NodeAdd(1);
                NodeEditor node_2 = new NodeEditor()
                {
                    Text = "Узел 2",
                    x = 0,
                    y = 0,
                    z = 6,
                };
                editor.NodeUpdate(baseNodeNum2, node_2);
                #endregion
                #endregion

                #region Третий узел
                baseNodeNum3 = editor.NodeAdd(1);
                NodeEditor node_3 = new NodeEditor()
                {
                    Text = "Узел 2",
                    x = 6,
                    y = 0,
                    z = 6,
                };
                editor.NodeUpdate(baseNodeNum3, node_3);
                #endregion

                #region Четвертый узел
                baseNodeNum4 = editor.NodeAdd(1);
                NodeEditor node_4 = new NodeEditor()
                {
                    Text = "Узел 4",
                    x = 6,
                    y = 0,
                    z = 0,
                };
                editor.NodeUpdate(baseNodeNum4, node_4);
                #endregion

                #region Создание стержней

                #region Левая колонна
                uint baseElemNum1 = editor.ElemAdd(1);
                ElemEditor elem1 = new ElemEditor()
                {
                    Text = "Стержень",
                    TypeElem = 10,
                    ListNode = new object[] { baseNodeNum1, baseNodeNum2 }
                };
                editor.ElemUpdate(baseElemNum1, elem1);
                #endregion

                #region Ригель
                uint baseElemNum2 = editor.ElemAdd(1);
                ElemEditor elem2 = new ElemEditor()
                {
                    Text = "Стержень",
                    TypeElem = 10,
                    ListNode = new object[] { baseNodeNum2, baseNodeNum3 }
                };
                editor.ElemUpdate(baseElemNum2, elem2);
                #endregion

                #region Правая колонна

                uint baseElemNum3 = editor.ElemAdd(1);
                ElemEditor elem3 = new ElemEditor()
                {
                    Text = "Стержень",
                    TypeElem = 10,
                    ListNode = new object[] { baseNodeNum4, baseNodeNum3 }
                };
                editor.ElemUpdate(baseElemNum3, elem3);

                #endregion

                #endregion

                #region Добавление жесткости
                RigidEditor rigid1 = new RigidEditor
                {
                    Text = "Колонна",
                    ListElem = new object[] { baseElemNum1, baseElemNum3 },
                    Description = "STZ RUSSIAN G57837_K 6"
                };

                RigidEditor rigid2 = new RigidEditor
                {
                    Text = "Ригель",
                    ListElem = new object[] { baseElemNum2 },
                    Description = "STZ RUSSIAN G57837Sh 16"
                };
                editor.RigidAdd(rigid1);
                editor.RigidAdd(rigid2);
                #endregion


                #region Создание закреплений
                BoundEditor bound = new BoundEditor
                {
                    Mask = 63,
                    ListNode = new object[] { baseNodeNum1}
                };
                editor.SetBound(bound, true);

                BoundEditor bound1 = new BoundEditor
                {
                    Mask = 56,
                    ListNode = new object[] { baseNodeNum4 }
                };
                editor.SetBound(bound1, true);

                #endregion


                #region Создание шарниров
                JointEditor joint = new JointEditor
                {
                    Place = 1,
                    Mask = 24
                };
                editor.JointSet(baseElemNum2, 1, joint);
                editor.JointSet(baseElemNum2, 2, joint);

                #endregion

                #endregion



            }
            finally
            {
                Marshal.ReleaseComObject(engine);
            }
        }
    }


    [Guid("94CA0A2B-248E-4A30-8767-2CDB94F18F56")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [ComVisible(true)]
    public interface IScad
    {
        [DispId(1)]
        void Run(dynamic engine);
    }
}

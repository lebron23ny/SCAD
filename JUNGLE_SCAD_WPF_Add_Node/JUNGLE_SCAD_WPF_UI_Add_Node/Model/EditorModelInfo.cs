using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JUNGLE_SCAD_WPF_UI_Add_Node.Model
{
    public class EditorModelInfo
    {
        /// <summary>
        /// Имя узла
        /// </summary>
        public string Name { get; set; } = "Узел # ";


        /// <summary>
        /// Координата X узла
        /// </summary>
        public double X { get; set; } = 0;

        /// <summary>
        /// Координат Y узла
        /// </summary>
        public double Y { get; set; } = 0;


        /// <summary>
        /// Координата Z узла
        /// </summary>
        public double Z { get; set; } = 0;
    }
}

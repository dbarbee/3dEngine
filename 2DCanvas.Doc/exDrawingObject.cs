using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas.Data;

namespace dbarbee.GraphicsEngine._2DCanvas.Doc
{
    public static class exDrawingObject
    {
        public delegate void DrawObjectDelegate(IDrawingObject obj, Canvas c);
        private static Dictionary<string, DrawObjectDelegate> methodMap;

        public static void RegisterDrawMethod(string className, DrawObjectDelegate d)
        {
            if(!methodMap.ContainsKey(className))
            {
                methodMap.Add(className, d);
            }
        }
        public static void Draw(this IDrawingObject obj, Canvas c)
        {
            string className = obj.GetType().ToString();
            if (methodMap.ContainsKey(className))
            {
                methodMap[className](obj, c);
            }
        }
    }
}

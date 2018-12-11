using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._3DEngine
{
    public class Solid : I3DObject
    {
protected Solid() { }
        public Solid (Surface[] surfaces)
        {
            Surfaces = surfaces;
        }

        private Surface[] _surfaces;

        public Surface[] Surfaces {
            get { return _surfaces; }
            protected set {
                _surfaces = value;

                Max = new Point(double.MinValue, double.MinValue, double.MinValue);
                Min = new Point(double.MaxValue, double.MaxValue, double.MaxValue);
                for (int idx = 0; idx < Surfaces.Length; idx++)
                {
                    if (_surfaces[idx].Max.x > Max.x) Max.x = _surfaces[idx].Max.x;
                    if (_surfaces[idx].Max.y > Max.y) Max.y = _surfaces[idx].Max.y;
                    if (_surfaces[idx].Max.z > Max.z) Max.z = _surfaces[idx].Max.z;

                    if (_surfaces[idx].Min.x < Min.x) Min.x = _surfaces[idx].Min.x;
                    if (_surfaces[idx].Min.y < Min.y) Min.y = _surfaces[idx].Min.y;
                    if (_surfaces[idx].Min.z < Min.z) Min.z = _surfaces[idx].Min.z;
                }
                Center = new Point((Max.x - Min.x) / 2, (Max.y - Min.y) / 2, (Max.z - Min.z) / 2);
           }
        }

        public Point Max { get; private set; }

        public Point Min { get; private set; }

        public Point Center { get; private set; }

        public void Render(I3DCamera c)
        {
            for (int idx=0;idx<Surfaces.Length;idx++)
            {
                Surfaces[idx].Render(c);
            }
        }

        public I3DObject RotateXY(double degrees)
        {
            Surface[] surfaces = new Surface[Surfaces.Length];
            for (int idx = 0; idx < Surfaces.Length; idx++)
            {
                surfaces[idx] = (Surface)  Surfaces[idx].RotateXY(degrees);
            }
            return new Solid(surfaces);
        }

        public I3DObject RotateXZ(double degrees)
        {
            Surface[] surfaces = new Surface[Surfaces.Length];
            for (int idx = 0; idx < Surfaces.Length; idx++)
            {
                surfaces[idx] = (Surface)Surfaces[idx].RotateXZ(degrees);
            }
            return new Solid(surfaces);
        }

        public I3DObject RotateYZ(double degrees)
        {
            Surface[] surfaces = new Surface[Surfaces.Length];
            for (int idx = 0; idx < Surfaces.Length; idx++)
            {
                surfaces[idx] = (Surface)Surfaces[idx].RotateYZ(degrees);
            }
            return new Solid(surfaces);
        }

        public I3DObject Scale(Vector scale)
        {
            Surface[] surfaces = new Surface[Surfaces.Length];
            for (int idx = 0; idx < Surfaces.Length; idx++)
            {
                surfaces[idx] = (Surface)Surfaces[idx].Scale(scale);
            }
            return new Solid(surfaces);
        }

        public I3DObject Scale(double scale)
        {
            Surface[] surfaces = new Surface[Surfaces.Length];
            for (int idx = 0; idx < Surfaces.Length; idx++)
            {
                surfaces[idx] = (Surface)Surfaces[idx].Scale(scale);
            }
            return new Solid(surfaces);
        }

        public I3DObject Translate(Vector delta)
        {
            Surface[] surfaces = new Surface[Surfaces.Length];
            for (int idx = 0; idx < Surfaces.Length; idx++)
            {
                surfaces[idx] = (Surface)Surfaces[idx].Translate(delta);
            }
            return new Solid(surfaces);
        }
    }
}

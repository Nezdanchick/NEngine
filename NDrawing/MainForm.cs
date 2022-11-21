using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NRender;

namespace NDrawing
{
    public partial class MainForm : Form
    {

        private static List<Vector3D> _vectors = new List<Vector3D>()
            {
                new Vector3D(-1, 1, 1),//           #           #
                new Vector3D(1, 1, 1),//        #           #

                new Vector3D(-1, -1, 1),
                new Vector3D(1, -1, 1),

                new Vector3D(-1, 1, -1),
                new Vector3D(1, 1, -1),

                new Vector3D(-1, -1, -1),//         #           #
                new Vector3D(1, -1, -1),//      #           #
            };
        private static Camera _camera = new Camera
        {
            Width = 50,
            Height = 30,
            FOV = 120,
            FocalLength = 15
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var brush = new SolidBrush(Color.Red);
            var pen = new Pen(brush);

            for (int i = 0; i < _vectors.Count; i++)
            {
                _vectors[i].Projection2D(_camera);
                _vectors[i].Rotate(1, Vector3D.Direction.X);
                _vectors[i].Rotate(2, Vector3D.Direction.Y);
                _vectors[i].Rotate(1, Vector3D.Direction.Z);
            }

            g.Clear(Color.Black);
            g.DrawLine(pen, _vectors[0].ProjectedPoint, _vectors[1].ProjectedPoint);
            g.DrawLine(pen, _vectors[2].ProjectedPoint, _vectors[3].ProjectedPoint);
            g.DrawLine(pen, _vectors[4].ProjectedPoint, _vectors[5].ProjectedPoint);
            g.DrawLine(pen, _vectors[6].ProjectedPoint, _vectors[7].ProjectedPoint);
            
            g.DrawLine(pen, _vectors[0].ProjectedPoint, _vectors[2].ProjectedPoint);
            g.DrawLine(pen, _vectors[1].ProjectedPoint, _vectors[3].ProjectedPoint);
            
            g.DrawLine(pen, _vectors[4].ProjectedPoint, _vectors[6].ProjectedPoint);
            g.DrawLine(pen, _vectors[5].ProjectedPoint, _vectors[7].ProjectedPoint);
            
            g.DrawLine(pen, _vectors[0].ProjectedPoint, _vectors[4].ProjectedPoint);
            g.DrawLine(pen, _vectors[1].ProjectedPoint, _vectors[5].ProjectedPoint);
            g.DrawLine(pen, _vectors[2].ProjectedPoint, _vectors[6].ProjectedPoint);
            g.DrawLine(pen, _vectors[3].ProjectedPoint, _vectors[7].ProjectedPoint);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox.Refresh();
        }
    }
}

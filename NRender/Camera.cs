namespace NRender
{
    public class Camera
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double FOV { get; set; }
        public double FocalLength { get; set; }

        public Camera() { }
        public Camera (double width, double height, double fov, double focalLength)
        {
            Width = width;
            Height = height;
            FOV = fov;
            FocalLength = focalLength;
        }
    }
}

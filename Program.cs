using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using static motion_tracker.ColorTracking;

namespace motion_tracker
{
    internal class Program
    {
        private const int camIndex = 0;
        static void Main(string[] args)
        {
            CvInvoke.NamedWindow("cam");
            using (Mat frame = new Mat())
            using (VideoCapture capture = new VideoCapture(camIndex))
                while(CvInvoke.WaitKey(1) == -1)
                {
                    capture.Read(frame);
                    Image<Bgr, Byte> img = frame.ToImage<Bgr, Byte>();

                   DrawSquareFromCenter(ref img, 300, 300, 30, 255, 255, 0);

                    CvInvoke.Imshow("cam", img);
                    img.Dispose();
                }
        }

        struct TrackingBox
        {
            public int x;
            public int y;
            public int width;
            public Bgr color;

            public TrackingBox(int x, int y, int width, Bgr color)
            {
                this.x = x;
                this.y = y;
                this.width = width;
                this.color = color;
            }
        }
    }
}
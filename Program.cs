using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

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

                    CvInvoke.Imshow("cam", frame);
                    img.Dispose();
                }
        }
    }
}
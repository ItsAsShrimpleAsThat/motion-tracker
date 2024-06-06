using Emgu.CV;
using Emgu.CV.Structure;

namespace motion_tracker
{
    internal static class ColorTracking
    {
        //Calculate the distance between two colors using weights for the r, g, and b values of the color
        //R, g, and b contribute different amounts to how humans percieve colors (for example, blue contributes
        //a lot less than red) so here I multiply the channels by different amounts to get a relatively accurate measure
        //of how different colors are
        public static double ColorDistance(Bgr color1, Bgr color2)
        {
            double rdist = color1.Red - color2.Red;
            double gdist = color1.Green - color2.Green;
            double bdist = color1.Blue - color2.Blue;
            return (rdist * rdist) * 0.3 + (gdist * gdist) * 0.59 + (bdist * bdist) * 0.11;
        }

        public static void DrawSquareFromCenter(ref Image<Bgr, Byte> canvas, int centerX, int centerY, int radius, byte r, byte g, byte b)
        {
            for(int x = centerX - radius; x < centerX + radius; x++)
            {
                canvas.Data[x, centerY + radius, 0] = b;
                canvas.Data[x, centerY - radius, 0] = b;
                canvas.Data[x, centerY + radius, 1] = g;
                canvas.Data[x, centerY - radius, 1] = g;
                canvas.Data[x, centerY + radius, 2] = r;
                canvas.Data[x, centerY - radius, 2] = r;
            }
            for (int y = centerY - radius + 1; y < centerY + radius; y++)
            {
                canvas.Data[centerX + radius, y, 0] = b;
                canvas.Data[centerX - radius, y, 0] = b;
                canvas.Data[centerX + radius, y, 1] = g;
                canvas.Data[centerX - radius, y, 1] = g;
                canvas.Data[centerX + radius, y, 2] = r;
                canvas.Data[centerX - radius, y, 2] = r;
            }
        }
    }
}

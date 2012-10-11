using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;

namespace Pathfinder_Prototype_1
{
    class HazardModel
    {
          private float sectorSize = 1f;

        private float[,] hazardModel;
        private float[,] slopeModel;

        private Bitmap hazardBitmap;


        public HazardModel(float[,] slope , float chunkSize , float hazardSize)
        {
            slopeModel = slope;

        }




        public ImageSource getHazardModelImage()
        {
            MemoryStream ms = new MemoryStream();
            hazardBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms.Position = 0;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();

            ImageSource img = bi;

            return img;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.IO;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace Pathfinder_Prototype_1
{
    class Pathfinder
    {
        private int width;
        private int height;


        private Bitmap pathBitmap;
        private float[,] hazardModel;


        private List<Point> pathNodes;

        public Pathfinder(float[,] hazardModelT)
        {
            hazardModel = hazardModelT;

            width = hazardModel.GetLength(0);
            height = hazardModel.GetLength(1);

            findPath();
            generatePathImage();
        }

 public List<Point> getPath()
{
return pathNodes;
}



        private void findPath()
        {


        }







        private void generatePathImage()
        {
            Bitmap bitmap = new Bitmap(width, height);

            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    System.Drawing.Color tempColor = getPathColorValue(hazardModel[x, y]);

                    bitmap.SetPixel(x, y, tempColor);
                 
                }
            
            }

            pathBitmap = bitmap;
        }


        private System.Drawing.Color getPathColorValue(float gradient)
        {
            System.Drawing.Color color = System.Drawing.Color.White;

            gradient = Math.Abs(gradient);

            float green = 255;
            float red = 255;
            float blue = 0;


            if (gradient <= 1f)
            {

                red = (1f - gradient) * 255;

            }
            else if (gradient <= 3f)
            {
                float percent = (gradient) / (3f);

                green = (1f - percent) * 255;
            }
            else
            {
                green = 0;
            }


            color = System.Drawing.Color.FromArgb(255, (int)red, (int)green, (int)blue);

            return color;
        }




        public ImageSource getPathImage()
        {
            MemoryStream ms = new MemoryStream();
            pathBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
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

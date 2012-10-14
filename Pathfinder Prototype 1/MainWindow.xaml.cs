using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pathfinder_Prototype_1
{
    public partial class MainWindow : Window
    {
        PathfinderController pathfinder;

        public MainWindow()
        {
            InitializeComponent();
            cmb_slopeType.SelectedIndex = 2;
            pathfinder = new PathfinderController();


           String path = "Models//model1_w512_h0.1_v0.01.ppm";
        //     String path = "Models//model2_w1024_h0.1_v0.01.ppm";

            pathfinder.loadElevationModel(path);
            img_height.Source = pathfinder.getElevationModelImage();

            string slopeType = "";

            System.Windows.Controls.ComboBoxItem curItem = ((System.Windows.Controls.ComboBoxItem)cmb_slopeType.SelectedItem);

            if (curItem != null)
            {
                slopeType = curItem.Content.ToString();
            }

            pathfinder.loadSlopeModel(slopeType);
            img_slope.Source = pathfinder.getSlopeModelImage();

            pathfinder.loadHazardModel(10);
            img_hazard.Source = pathfinder.getHazardModelImage();

           
            populateTextDataBox(pathfinder.getElevationModel() , txt_height);
            populateTextDataBox(pathfinder.getSlopeModel(), txt_slope);
            populateTextDataBox(pathfinder.getHazardModel(), txt_hazard);

        }


        private void populateTextDataBox(float[,] dataArray , TextBox textBox)
        {

            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < dataArray.GetLength(1); y++)
            {
                for (int x = 0; x < dataArray.GetLength(0); x++)
                {
                    sb.Append(dataArray[x, y] + ",");
                }
                sb.Append("\r\n");
            }
            textBox.Text = sb.ToString();
        }



        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            String path = "Models//model1_w512_h0.1_v0.01.ppm";

            if (cmb_mapType.SelectedIndex == 0)
            {
                path = "Models//model1_w512_h0.1_v0.01.ppm";
            }
            else if (cmb_mapType.SelectedIndex ==1)
            {
                path = "Models//model2_w1024_h0.1_v0.01.ppm";
            }

            pathfinder.loadElevationModel(path);
            img_height.Source = pathfinder.getElevationModelImage();

            populateTextDataBox(pathfinder.getElevationModel(), txt_height);
        }



        private void btn_slope_Click(object sender, RoutedEventArgs e)
        {
            string slopeType = "";

            System.Windows.Controls.ComboBoxItem curItem = ((System.Windows.Controls.ComboBoxItem)cmb_slopeType.SelectedItem);

            if (curItem != null)
            {
                slopeType = curItem.Content.ToString();
            }

            pathfinder.loadSlopeModel(slopeType);
            img_slope.Source = pathfinder.getSlopeModelImage();

            populateTextDataBox(pathfinder.getSlopeModel(), txt_slope);
        }


        private void btn_hazard_Click(object sender, RoutedEventArgs e)
        {
            int size = 10;
            try
            {
                size = int.Parse(txt_sectorSize.Text);
            }
            catch (Exception ex)
            {

            }
            pathfinder.loadHazardModel(size);
            img_hazard.Source = pathfinder.getHazardModelImage();


            populateTextDataBox(pathfinder.getHazardModel(), txt_hazard);
        }

        private void btn_path_Click(object sender, RoutedEventArgs e)
        {
            int startX = 0;
            int startY = 0;
            int targetX = 22;
            int targetY = 30;

            try
            {
                startX = int.Parse(txt_startX.Text);
                startY = int.Parse(txt_startY.Text);
                targetX = int.Parse(txt_endX.Text);
                targetY = int.Parse(txt_endY.Text);
            }
            catch (Exception ex)
            {

            }



            pathfinder.generatePath(startX , startY , targetX , targetY);
            img_path.Source = pathfinder.getPathImage();

            List<PathNode> pathNodes = pathfinder.getPathModel();

            StringBuilder sb = new StringBuilder();

            foreach (PathNode p in pathNodes)
            {
                sb.AppendLine("(" + p.x + "," + p.y + ")");
            }
            txt_pathModel.Text = sb.ToString();
        }


       

    }
}

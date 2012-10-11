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
        }


     

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            String path = "Models//model1_w512_h0.1_v0.01.ppm";
           // String path = "Models//model2_w1024_h0.1_v0.01.ppm";

            pathfinder.loadElevationModel(path);
            img_height.Source = pathfinder.getElevationModelImage();
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
        }


        private void btn_hazard_Click(object sender, RoutedEventArgs e)
        {
            pathfinder.loadHazardModel(10);
            img_hazard.Source = pathfinder.getHazardModelImage();
        }


       

    }
}

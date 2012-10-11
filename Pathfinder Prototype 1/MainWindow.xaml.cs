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

        private ElevationLoader elevationLoader;
        private SlopeModel slopeModel;
        private HazardModel hazardModel;


        public MainWindow()
        {
            InitializeComponent();
        }


     

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            loadModel();
        }

        private void loadModel()
        {
            //  elevationLoader = new ElevationLoader("Models//test.ppm");
            elevationLoader = new ElevationLoader("Models//model1_w512_h0.1_v0.01.ppm");
          //  elevationLoader = new ElevationLoader("Models//model2_w1024_h0.1_v0.01.ppm");

            img_height.Source = elevationLoader.getImageSource();
            //.Source = loader.getImageSource();


          //  elevationModel = new ElevationModel(loader.getBitmap());
        }

        private void btn_slope_Click(object sender, RoutedEventArgs e)
        {
            loadSlopeModel();
        }


        private void btn_hazard_Click(object sender, RoutedEventArgs e)
        {
            loadHazardModel();
        }


        private void loadSlopeModel()
        {
            string cmbvalue = "";

            System.Windows.Controls.ComboBoxItem curItem = ((System.Windows.Controls.ComboBoxItem)cmb_slopeType.SelectedItem);

            if (curItem != null)
            {
                cmbvalue = curItem.Content.ToString();
            }



            slopeModel = new SlopeModel(elevationLoader.getHeightMap(), cmbvalue);

            img_slope.Source = slopeModel.getSlopeModelImage();
        }



        private void loadHazardModel()
        {
            hazardModel = new HazardModel(slopeModel.getSlopeModel(), 0.1f, 1.0f);

            img_hazard.Source = hazardModel.getHazardModelImage();
        }

    }
}

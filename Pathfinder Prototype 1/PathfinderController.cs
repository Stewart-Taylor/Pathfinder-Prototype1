using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Pathfinder_Prototype_1
{
    class PathfinderController
    {
        private ElevationLoader elevationLoader;
        private SlopeModel slopeModel;
        private HazardModel hazardModel;
        private Pathfinder pathfinder;


        public PathfinderController()
        {


        }


        public void loadElevationModel(String path)
        {
            elevationLoader = new ElevationLoader(path);
        }


        public void loadSlopeModel(String slopeType)
        {
            slopeModel = new SlopeModel(elevationLoader.getHeightMap(), slopeType);
        }

        public void loadHazardModel(int chunkSize)
        {
            hazardModel = new HazardModel(slopeModel.getSlopeModel(), chunkSize);
        }

        public void generatePath()
        {
            pathfinder = new Pathfinder(hazardModel.getHazardModel());
        }

        public ImageSource getElevationModelImage()
        {
            return elevationLoader.getImageSource();
        }

        public ImageSource getSlopeModelImage()
        {
            return slopeModel.getSlopeModelImage();
        }

        public ImageSource getHazardModelImage()
        {
            return hazardModel.getHazardModelImage();
        }

        public ImageSource getPathImage()
        {
            return pathfinder.getPathImage();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecto.Services
{
    public class Point
    {
        public static List<Models.PointViewModel> setPoint()
        {
            List<Models.PointViewModel> lisPointViewModels = new List<Models.PointViewModel>();

            lisPointViewModels.Add(new Models.PointViewModel(0, 0));
            lisPointViewModels.Add(new Models.PointViewModel(1, 15));
            lisPointViewModels.Add(new Models.PointViewModel(2, 30));
            lisPointViewModels.Add(new Models.PointViewModel(3, 40));
            lisPointViewModels.Add(new Models.PointViewModel(4, 4));

            return lisPointViewModels;
        }

        public static Models.PointViewModel getPointPlayer(int point)
        {
            List<Models.PointViewModel> lisPointViewModels = setPoint();

            Models.PointViewModel pointViewMod = null;

            foreach (Models.PointViewModel pointViewModel in lisPointViewModels)
            {
                if (pointViewModel.poinWin == point)
                {
                    pointViewMod = pointViewModel;
                }
            }

            return pointViewMod;
        }

        public static Models.PointViewModel getPointWin(int point)
        {
            List<Models.PointViewModel> lisPointViewModels = setPoint();

            Models.PointViewModel pointViewMod = null;

            foreach (Models.PointViewModel pointViewModel in lisPointViewModels)
            {
                if (pointViewModel.poinPlay == point)
                {
                    pointViewMod = pointViewModel;
                }
            }

            return pointViewMod;
        }
    }
}
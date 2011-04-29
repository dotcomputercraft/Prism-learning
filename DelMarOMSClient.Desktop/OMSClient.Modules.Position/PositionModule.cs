using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

using DelMarOMSClient.Infrastructure;

namespace OMSClient.Modules.Position
{
    public class PositionModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public void Initialize()
        {
           //_regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(Views.PositionView));
           Views.PositionView posView = new Views.PositionView();
           _regionManager.Regions[RegionNames.MainRegion].Add(posView);

        }

        public PositionModule(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
        }
    }
}

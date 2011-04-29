using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

using DelMarOMSClient.Infrastructure;
using Microsoft.Practices.ServiceLocation;
using OMSClient.Modules.Position.Views;

namespace OMSClient.Modules.Position
{
    public class PositionModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public void Initialize()
        {
           //_regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(Views.PositionView));
            Views.MyDataGridView myView = new Views.MyDataGridView();
            myView.ViewModel = ServiceLocator.Current.GetInstance<MyDataGridViewModel>();            
            _regionManager.Regions[RegionNames.MainRegion].Add(myView, "MyView");

            Views.AnotherView other = new Views.AnotherView();            
            other.ViewModel = ServiceLocator.Current.GetInstance<AnotherViewModel>();
            _regionManager.Regions[RegionNames.MainRegion].Add(other, "OtherView");
        }

        public PositionModule(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
        }
    }
}

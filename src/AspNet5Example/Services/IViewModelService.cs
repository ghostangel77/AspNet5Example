using AspNet5Example.ViewModels;

namespace AspNet5Example.Services
{
    public interface IViewModelService
    {
        DashboardViewModel GetDashboardViewModel();
    }
}
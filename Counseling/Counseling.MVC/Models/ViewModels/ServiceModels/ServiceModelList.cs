using Counseling.Entity.Entity;

namespace Counseling.MVC.Models.ViewModels.ServiceModels
{
    public class ServiceModelList
    {
        public List<ServiceModel> ServiceModels { get; set; }
        public List<Category> Categories{ get; set; }
    }
}

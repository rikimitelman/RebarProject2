
using ReabrProject.RebarProject.Repositories.Interfaces;

namespace ReabrProject.RebarProject.Repositories.Entities
{
    public class RebarStoreDatabaseSettings : IRebarStoreDatabaseSettings
    {
        public string PaymentCollectionName { get; set; }   =String.Empty;        
        public string MenuCollectioName { get; set; } =String.Empty;
        public string CustomerOrderCollectionName { get; set; } =String.Empty;
        public string ConnectionString { get; set; }  =String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}

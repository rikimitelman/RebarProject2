namespace ReabrProject.RebarProject.Repositories.Interfaces
{
    public interface IRebarStoreDatabaseSettings
    {
        string PaymentCollectionName { get; set; }
        string MenuCollectioName { get; set; }
        string CustomerOrderCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

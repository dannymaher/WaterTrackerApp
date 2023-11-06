namespace WaterTrackerAPI.Repositories.IRepositories
{
    // An interface which declares the methods and fields for the unit of work class and allows for dependency injection
    public interface IUnitOfWork
    {
        IWaterIntakeRepository WaterIntake {  get; } 
        IUserRepository User { get; }
        Task Save();
    }
}

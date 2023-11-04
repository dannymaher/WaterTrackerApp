namespace WaterTrackerAPI.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IWaterIntakeRepository WaterIntake {  get; }
        IUserRepository User { get; }
        void Save();
    }
}

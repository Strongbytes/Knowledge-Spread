namespace LearningSystem.Module.Common.Infrastructure
{
    public interface IDataSeedService
    {
        /// <summary>
        /// This method will be used inside a synchronous context, therefore we are required to conceal any asynchronous operations inside the implementation
        /// </summary>
        void EnsureDataIsSeed();
    }
}

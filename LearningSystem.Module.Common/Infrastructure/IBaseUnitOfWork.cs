using System;
using System.Threading.Tasks;

namespace LearningSystem.Module.Common.Infrastructure
{
    public interface IBaseUnitOfWork : IDisposable
    {
        Task<int> Complete();
    }
}

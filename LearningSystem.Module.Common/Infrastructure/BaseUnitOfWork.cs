using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace LearningSystem.Module.Common.Infrastructure
{
    public class BaseUnitOfWork : IBaseUnitOfWork
    {
        private readonly DbContext _context;

        public BaseUnitOfWork(DbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            SetRepositoriesFromServiceDependencies(serviceProvider);
        }

        private void SetRepositoriesFromServiceDependencies(IServiceProvider serviceProvider)
        {
            foreach (PropertyInfo property in GetType().GetProperties())
            {
                property.SetValue(this, serviceProvider.GetRequiredService(property.PropertyType));
            }
        }

        public virtual Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}

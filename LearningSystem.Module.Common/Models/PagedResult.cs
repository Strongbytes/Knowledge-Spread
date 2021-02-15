using System.Collections.Generic;

namespace LearningSystem.Module.Common.Models
{
    public class PagedResult<T>
    {
        public int Count { get; set; }

        public IList<T> Data { get; set; }
    }
}

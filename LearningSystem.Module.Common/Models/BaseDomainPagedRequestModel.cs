namespace LearningSystem.Module.Common.Models
{
    public abstract class BaseDomainPagedRequestModel
    {
        public int Page { get; set; } = int.MinValue;

        public int PageSize { get; set; } = int.MinValue;
    }
}

namespace LearningSystem.Module.Common.Infrastructure
{
    public enum QueryTracking
    {
        /// <summary>
        /// By default, queries that return entity types are tracking. 
        /// <br/>Which means you can make changes to those entity instances and have those changes persisted by SaveChanges().
        /// </summary>
        AsTracking = 1,

        /// <summary>
        /// No tracking queries are useful when the results are used in a read-only scenario.
        /// <br/>They're quicker to execute because there's no need to set up the change tracking information.
        /// <br/>If you don't need to update the entities retrieved from the database, then a no-tracking query should be used.
        /// </summary>
        AsNoTracking = 0
    }
}

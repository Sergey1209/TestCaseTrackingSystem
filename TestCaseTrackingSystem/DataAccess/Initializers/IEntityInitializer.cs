namespace DataAccess.Initializers
{
    internal interface IEntityInitializer
    {
        void InitializeData(TestCaseDataContext dbContext);
    }
}

namespace Function.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private FunctionContext dbContext;

        public UnitOfWork(FunctionContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}

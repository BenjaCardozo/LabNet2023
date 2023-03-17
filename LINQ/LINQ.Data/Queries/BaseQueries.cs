namespace LINQ.Data.Queries
{
    public abstract class BaseQueries
    {
        protected NorthwindContext _context;
        public BaseQueries(NorthwindContext context)
        {
            _context = context;
        }
        public BaseQueries() { }
    }
}

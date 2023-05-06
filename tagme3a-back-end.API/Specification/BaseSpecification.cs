using System.Linq.Expressions;

namespace tagme3a_back_end.API.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(Expression<Func<T,bool>> criteria) 
        {
            Criteria = criteria;    
        }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPaginationEnabled { get; private set; }
        protected void ApplyPagination(int take, int skip)
        {
            Skip = skip;
            Take = take;

            IsPaginationEnabled = true;

        }

        public Expression<Func<T, object>> OrderByAscending
        {
            get; private set;
        }

        public Expression<Func<T, object>> OrderByDescending
        {
            get; private set;

        }

        public Expression<Func<T, bool>> Criteria { get; }


        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddOrderByAscending(Expression<Func<T,object>> orderByExpression) 
        {
            OrderByAscending = orderByExpression;
        }
        protected void AddOrderByDescendingg(Expression<Func<T, object>> orderByExpression) 
        {
            OrderByDescending = orderByExpression;
        }
        protected void AddInclude(Expression<Func<T,object>> IncludesExpression)
        {
            Includes.Add(IncludesExpression);
        }

    }
}

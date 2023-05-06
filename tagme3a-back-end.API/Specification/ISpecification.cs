using System.Linq.Expressions;

namespace tagme3a_back_end.API.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T,object>>> Includes { get;}

        //sorting
        Expression <Func<T, Object>> OrderByAscending { get; }
        Expression<Func<T, Object>> OrderByDescending { get; }

        //PAGINATION
        int Take { get; }
        int Skip { get; }
        bool IsPaginationEnabled { get; }

    }
}

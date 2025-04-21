using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace domain.contracts
{
    public abstract class specification<T> where T : class
    {

        public specification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        protected specification()
        {
        }

        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }           

    }
}

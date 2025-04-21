using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.contracts;
using Microsoft.EntityFrameworkCore;

namespace presistance
{
    public class specificationevaluator
    {
        public static IQueryable<T> GetQuery<T>(IQueryable<T> inputQuery, specification<T> specification) where T : class
        {
            var query = inputQuery;
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);//x => x.Id == 1&& x.Name == "ahmed"
            }
            query=specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            //foreach (var item in specification.Includes)
            //{
            //    query = query.Include(item);
            //}
            return query;
        }
    }
}
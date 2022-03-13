using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _0_Framework.Domain
{
    public interface IRepository<TKey,T> where T : class
    {
        List<T> Get();
        T GetBy(TKey id);
        bool Exists(Expression<Func<T, bool>> expression);
        void SaveChanges();
        void Create(T entity);
    }
}

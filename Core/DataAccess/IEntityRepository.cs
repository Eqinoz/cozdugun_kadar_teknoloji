using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    /*where koşulu generic yapıyı filtreler yani, T, class ve IEntity ve onu implement eden farklı bir şey olamaz
     new() parametresi ile sadece new'lenebilir classları kabul eder.
     */
    {
        /*
         * expression methodu Manager kısmında getall methoduna Linq komutu ile filtreleme özelliği sunuyor
         * get'de filtre olma zorunluluğu ise daha detaylı bir filtrelemeye yarıyor.
         */
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter); 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

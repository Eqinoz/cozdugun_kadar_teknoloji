using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public interface IAuth:IEntity
    {
        int Id { get; }
        string Email { get; }
        string FirstName { get; }
        string LastName { get; }

    }
}

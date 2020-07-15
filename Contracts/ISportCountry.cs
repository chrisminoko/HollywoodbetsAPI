using SportAPISever.Model;
using SportAPISever.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Contracts
{
    public interface ISportCountry: IRepositoryBase<SportCountry>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportsVerification.Web.Utills.Interfaces
{
    public interface IMapper<in TSource, in TDestination>
    {
        void Map(TSource source, TDestination destination);
    }
}
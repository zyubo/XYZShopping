using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace XYZShopping.Models.Data
{
    public interface IDataAccess
    {
        object GetScalar(string sql);
        DataTable GetDataTable(string sql);
        int InsOrUpdOrDel(string sql);
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace Accounting.DAO
{
    class Database:DataContext
    {
        public Database():base(ConfigurationManager.ConnectionStrings["AccountConnectionString"].ToString())
        {

        }
    }
}
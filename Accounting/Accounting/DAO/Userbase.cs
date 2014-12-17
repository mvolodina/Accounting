using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace Accounting.DAO
{
    class Userbase:DataContext
    {
        public Userbase():base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString())
        {

        }
    }
}
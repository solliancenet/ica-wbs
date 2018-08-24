using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using NorthwindMVC.Data;
using NorthwindMVC.Models;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace NorthwindMVC.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Index()
        {
            // Oracle
            var salesByYear = this.db.Database.SqlQuery<SALESBYYEAR>(
                "BEGIN NW.SALESBYYEAR(:P_BEGIN_DATE, :P_END_DATE, :CUR_OUT); END;",
                new OracleParameter("P_BEGIN_DATE", OracleDbType.TimeStamp, new OracleTimeStamp(1996, 1, 1), ParameterDirection.Input),
                new OracleParameter("P_END_DATE", OracleDbType.TimeStamp, new OracleTimeStamp(1999, 12, 31), ParameterDirection.Input),
                new OracleParameter("CUR_OUT", OracleDbType.RefCursor, ParameterDirection.Output)).ToList();

            // SQL Server
            ////var salesByYear = this.db.Database.SqlQuery<SALESBYYEAR>(
            ////    "exec [NW].[SALESBYYEAR] @p_begin_date, @p_end_date ",
            ////    new SqlParameter("p_begin_date", "1996-1-1"),
            ////    new SqlParameter("p_end_date", "1999-1-1")).ToList();

            var model = from r in salesByYear
                        orderby r.YEAR
                        group r by r.YEAR into grp
                        select new SalesByYearViewModel { Year = grp.Key, Count = grp.Count() };

            return this.View(model);
        }
    }
}
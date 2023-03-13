using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Filtros_y_Seguridad
{
    public class VariablesEntorno
    {
        public static string ConnectionString
        {
            get
            {
                var database = Environment.GetEnvironmentVariable("initial_catalog", EnvironmentVariableTarget.Machine);
                var user = Environment.GetEnvironmentVariable("user_id", EnvironmentVariableTarget.Machine);
                var password = Environment.GetEnvironmentVariable("password", EnvironmentVariableTarget.Machine);

                var connectionString = $"data source=RENARDROGUE;initial catalog={database};persist security info=True;user id={user};password={password};MultipleActiveResultSets=True;App=EntityFramework";

                return connectionString;
            }
        }

    }
}
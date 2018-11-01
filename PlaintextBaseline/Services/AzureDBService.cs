using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace PlaintextBaseline.Services
{
    public class AzureDBService
    {
        public static AzureDBService Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private static Lazy<AzureDBService> _instance = new Lazy<AzureDBService>(() =>
        {
            return new AzureDBService();
        });

        private AzureDBService()
        {
            ConnectionString = ConfigurationManager.AppSettings["AzureDBConnectionString"];
        }

        private string ConnectionString = null;
        public T GetAsync<T>(string id)
        {
            return default(T);
        }
    }
}
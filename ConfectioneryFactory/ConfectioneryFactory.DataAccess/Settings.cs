using System;

namespace ConfectioneryFactory.DataAccess
{
    public class Settings
    {
        private string databaseServerName;

        private string databaseName;

        public void AddDatabaseServer(string serverName)
        {
            this.databaseServerName = serverName;
        }

        public string GetDatabaseServer()
        {
            return this.databaseServerName;
        }

        public void AddDatabaseName(string databaseName)
        {
            this.databaseName = databaseName;
        }

        public string GetDatabaseName()
        {
            return this.databaseName;
        }
    }
}

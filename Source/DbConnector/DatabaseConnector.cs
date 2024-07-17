namespace DbConnector
{
    public class DatabaseConnector
    {
        private static DatabaseConfiguration m_dbConnector = null;

        public static DatabaseConfiguration DbConnectorInstance
        {
            get
            {
                if (m_dbConnector == null)
                {
                    m_dbConnector = new DatabaseConfiguration();
                }

                return m_dbConnector;
            }
        }
    }
}
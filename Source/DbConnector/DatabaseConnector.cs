﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

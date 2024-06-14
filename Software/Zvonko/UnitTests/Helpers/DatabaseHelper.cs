using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.Helpers {
    public static class DatabaseHelper {
        private static ZvonkoModel9 _dbContext;

        public static void ResetDatabase() {
            Connect();
            ResetTables();
            Disconnect();
        }

        private static void Connect() {
            _dbContext = new ZvonkoModel9();
        }

        private static void Disconnect() {
            if (_dbContext != null) {
                _dbContext.Dispose();
                _dbContext = null;
            }
        }

        private static void ResetTables() {
        }
    }
}

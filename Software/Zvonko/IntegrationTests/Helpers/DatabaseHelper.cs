using System;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using DatabaseLayer;

namespace IntegrationTests.Helpers {
    public static class DatabaseHelper {
        private static SqlConnection _connection;

        public static void ResetDatabase() {
            Connect();
            ResetTables();
            Disconnect();
        }

        private static void Disconnect() {
            if (_connection != null && _connection.State != System.Data.ConnectionState.Closed) {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }

        private static void Connect() {
            string connectionString = ConfigurationManager.ConnectionStrings["ZvonkoTest"].ConnectionString;
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }


        private static void ResetTables() {
            ClearTables();
            InsertDefaultData();
        }

        private static void ClearTables() {
            string sqlScript = @"
            DELETE FROM [dbo].[Events];
            DELETE FROM [dbo].[Recordings];
            DELETE FROM [dbo].[Accounts];
            DELETE FROM [dbo].[TypeOfEvent];";
            ExecuteSqlCommand(sqlScript);
        }

        private static void InsertDefaultData() {
            string sqlScript = @"
            INSERT INTO [dbo].[Accounts] (username, password, schoolName, macAddress) VALUES
            ('TestUser1', 'password1', 'TestSchool1', '00:00:00:00:00:01'),
            ('TestUser2', 'password2', 'TestSchool2', '00:00:00:00:00:02');

            INSERT INTO [dbo].[TypeOfEvent] (typeName, isRecurring) VALUES
            ('EventType1', 1),
            ('EventType2', 0);

            INSERT INTO [dbo].[Recordings] (name, duration, description, storedFile, AccountId, timeCreated) VALUES
            ('Test Recording 1', '00:05:00', 'Test Description 1', 'test_file1.mp3', 1, GETDATE()),
            ('Test Recording 2', '00:10:00', 'Test Description 2', 'test_file2.mp3', 2, GETDATE());

            INSERT INTO [dbo].[Events] (name, description, starting_time, accountId, recordingId, typeOfEventId, date, monday, tuesday, wednesday, thursday, friday, saturday, sunday) VALUES
            ('Test Event 1', 'Description 1', '08:00:00', 1, 1, 1, '2023-06-14', 1, 0, 0, 0, 0, 0, 0),
            ('Test Event 2', 'Description 2', '09:00:00', 2, 2, 2, '2023-06-15', 0, 1, 0, 0, 0, 0, 0);";
            ExecuteSqlCommand(sqlScript);
        }

        private static void ExecuteSqlCommand(string sqlCommand) {
            using (SqlCommand command = new SqlCommand(sqlCommand, _connection)) {
                command.ExecuteNonQuery();
            }
        }
    }
}

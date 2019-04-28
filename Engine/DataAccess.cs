using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FastDataAccess.Engine
{
    public class DataAccess
    {
        public List<string> list;

        public DataAccess()
        {
            list = new List<string>();
        }
        
        public void IndexingAllFiles(object directoryPathObj)
        {
            var directoryPath = directoryPathObj.ToString();
            if (Directory.Exists(directoryPath))
            {
                try
                {
                    foreach (var file in Directory.GetFiles(directoryPath))
                    {
                        list.Add($"{file}");
                    }

                    foreach (var directory in Directory.EnumerateDirectories(directoryPath))
                    {
                        list.Add($"{directory}");
                        IndexingAllFiles(directory);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void TraverseTree(string root)
        {
            Stack<string> dirs = new Stack<string>(20);

            if (!Directory.Exists(root))
            {
                throw new ArgumentException();
            }

            dirs.Push(root);
            IsExits(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs;
                try
                {
                    subDirs = Directory.GetDirectories(currentDir);
                }
                catch (UnauthorizedAccessException e)
                {
                    continue;
                }
                catch (DirectoryNotFoundException e)
                {
                    continue;
                }

                Task.Run(() => GetFiles(currentDir));
                
                foreach (string str in subDirs)
                {
                    dirs.Push(str);
                    IsExits(str);
                }
            }
        }

        private void GetFiles(string dir)
        {
            string[] files = null;
            try
            {
                files = Directory.GetFiles(dir);
            }
            catch (UnauthorizedAccessException e)
            {
            }

            foreach (string file in files)
            {
                try
                {
                    IsExits(file);
                }
                catch (FileNotFoundException e)
                {
                }
            }
        }

        public void Save(string path)
        {
            string connectionString = @"Data Source=.;Initial Catalog=Index;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                var sqlQuery = @"INSERT INTO [dbo].[Index] ([Path]) VALUES (@Path)";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlParameter pathParam = new SqlParameter("@Path", path);
                command.Parameters.Add(pathParam);

                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteAll()
        {
            string connectionString = @"Data Source=.;Initial Catalog=Index;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                var sqlQuery = @"Delete from [dbo].[Index]";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        
        public void IsExits(string path)
        {
            string connectionString = @"Data Source=.;Initial Catalog=Index;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string sqlQuery =
                    "SELECT Count(Path) FROM [Index].[dbo].[Index] Where Path = @Path";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlParameter pathParam = new SqlParameter("@Path", path.ToLowerInvariant());
                command.Parameters.Add(pathParam);

                if ((int) command.ExecuteScalar() != 1)
                {
                    list.Add(path);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}


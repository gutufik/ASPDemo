using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ASPDemo.Core
{
    public static class DBConnect
    {
        public static List<Project> GetProjects()
        {
            string connStr = "server=192.168.1.44;user=name;database=test;port=3306;password=password";
            //string connStr = "server=10.0.4.135;user=a;database=test;port=3306;password=a";
            MySqlConnection conn = new MySqlConnection(connStr);
            List<Project> projects = new List<Project>();

            try
            {
                conn.Open();

                string sql = "SELECT * FROM Site.Project";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    projects.Add(new Project { ID = Convert.ToInt32(res[0]), Name = res[1].ToString(), Description = res[2].ToString(), Link = res[3].ToString() });
                    //Console.WriteLine($"<p><input type=checkbox name=\"{res[1]}\"> {res[1]}</p>");
                    //Console.WriteLine($"<option value=\"{res[1]}\">{res[1]}</option>");
                }
                res.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
            return projects;
        }
        public static void RemoveProject(int id)
        {
            try
            {
                string connStr = "server=192.168.1.44;user=name;database=test;port=3306;password=password";
                MySqlConnection conn = new MySqlConnection(connStr);
                MySqlCommand cmd = new MySqlCommand($"DELETE from Site.Project where idProject = {id}", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                //Response.Redirect("done.aspx");
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void AddProject(Project project)
        {
            try
            {
                string connStr = "server=192.168.1.44;user=name;database=test;port=3306;password=password";
                MySqlConnection conn = new MySqlConnection(connStr);
                MySqlCommand cmd = new MySqlCommand($"insert into Site.Project(Name, Description, Link) values('{project.Name}', '{project.Description}', '{project.Link}')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                //Response.Redirect("done.aspx");
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

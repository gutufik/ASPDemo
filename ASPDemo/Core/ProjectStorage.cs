using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDemo.Core
{
    public static class ProjectStorage
    {
        public static List<Project> Projects { get; private set; } = DBConnect.GetProjects();
        public static void Add(Project project)
        {
            DBConnect.AddProject(project);
            Projects = DBConnect.GetProjects();
            //Projects.Add(project);
        }
        public static void RemoveByName(int id)
        {
            DBConnect.RemoveProject(id);
            Projects = DBConnect.GetProjects();
            //Projects.RemoveAll(p => p.Name == name);
        }
    }
}

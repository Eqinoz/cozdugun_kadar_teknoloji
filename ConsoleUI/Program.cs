using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SchoolManager schoolManager = new SchoolManager(new EfSchoolDal());

            foreach (var school in schoolManager.GetAll())
            {
                Console.WriteLine(school.SchoolName);
            }
        }
    }
}

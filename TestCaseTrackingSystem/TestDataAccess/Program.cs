using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Entities;

namespace TestDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TestCaseDataContext())
            {
                var types = context.BacklogItemTypes.ToList();

                types.ForEach(t => Console.WriteLine(t.Type));
            }

            Console.ReadKey();
        }
    }
}

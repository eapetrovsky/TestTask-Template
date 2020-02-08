using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startDate = new DateTime(2017, 4, 21);
            int dayCount = 7;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25)),
                new WeekEnd(new DateTime(2017, 4, 29), new DateTime(2017, 4, 29))
            };
             
            WorkDayCalculator wdk = new WorkDayCalculator();
            wdk.Calculate(startDate, dayCount, weekends);

            Console.ReadKey();

        }
    }
}

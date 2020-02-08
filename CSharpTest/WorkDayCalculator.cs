using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        { 
            if (weekEnds == null)
            {
                return startDate.AddDays(-1);
            } 

            int day = 1;

            int totalDaysQty;
            
            if (weekEnds.GetLength(0) > 1)
            {
                totalDaysQty = (int)(weekEnds[1].EndDate.ToOADate() - weekEnds[1].StartDate.ToOADate() + 1 +
                    weekEnds[1].EndDate.ToOADate() - weekEnds[1].StartDate.ToOADate() + dayCount + 2);
            }
            else
            {
                totalDaysQty = (int)(weekEnds[0].EndDate.ToOADate() - weekEnds[0].StartDate.ToOADate() + dayCount + 1);
            }
             
            DateTime[] newDT = new DateTime[totalDaysQty];
            DateTime variableDay = newDT[0] = startDate;
            variableDay = variableDay.AddDays(1); 

            int firstWeekendLength = (int)(weekEnds[0].EndDate.ToOADate() - weekEnds[0].StartDate.ToOADate() + 1);
                        
            int secondtWeekendLength = 0;
                          
            if (weekEnds.GetLength(0) > 1)
            { 
                secondtWeekendLength = (int)(weekEnds[1].EndDate.ToOADate() - weekEnds[1].StartDate.ToOADate() + 1);           
            }       

            Console.WriteLine("Start date:" + newDT[0].ToString());
            Console.WriteLine("Duration: {0} days", dayCount);
            Console.WriteLine("Day  " + day.ToString() + ":\t" + newDT[0].ToString("dd.MM.yyyy"));

            for (int i = 0; i < totalDaysQty; i++)
            {
                if (variableDay != weekEnds[0].StartDate)
                {
                    newDT[i] = variableDay;
                    variableDay = variableDay.AddDays(1);
                    day++;
                    Console.WriteLine("Day  " + day.ToString() + ":\t" + newDT[i].ToString("dd.MM.yyyy"));                    
                }
                else if (weekEnds[0].StartDate.CompareTo(variableDay) == 0)
                {
                    for (int j = 0; j < firstWeekendLength; j++)
                    {                        
                        newDT[i] = variableDay;
                        Console.WriteLine(newDT[i].ToString("dd.MM.yyyy") + "   excluded as weekend ");
                        i++;
                        variableDay = variableDay.AddDays(1);                        
                    }                     
                }
                else if (secondtWeekendLength > 0 && weekEnds[1].StartDate.CompareTo(variableDay) == 0)
                {
                    for (int j = 0; j < secondtWeekendLength; j++)
                    {
                        variableDay = variableDay.AddDays(1);
                        newDT[i] = weekEnds[1].StartDate;
                        i++;
                        day++;
                        Console.WriteLine(newDT[i].ToString("dd.MM.yyyy") + "   excluded as weekend ");
                    }  
                }                
            }
             
            return newDT[newDT.Length - 1];
        }
    }
}

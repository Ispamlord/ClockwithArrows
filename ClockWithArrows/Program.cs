using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockWithArrows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите время цифровых часов");
            string timer = Console.ReadLine();
            string[] time = timer.Split(':') ;
            int hour = int.Parse(time[0]);
            if (hour > 23 || hour<0)
                throw new AccessViolationException("час не может быть отрицательным или больше 23");
            int min = int.Parse(time[1]);
            if(min>59 || min<0)
                throw new AccessViolationException("Минута не может быть отрицательным или больше 59");
            DateTime dt = DateTime.Now;

            Console.WriteLine("Время на часах: "+dt.Hour+":"+dt.Minute);
            //IDigital ae = new digital_clock();
            //ae.gettime(hour, min);
            IDigital digital = new Adapter(new CLockWithArrow());
            digital.gettime(hour,min) ;
        }
    }
}

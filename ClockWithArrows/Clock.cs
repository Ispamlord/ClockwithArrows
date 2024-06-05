using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockWithArrows
{
    public class digital_clock : IDigital
    {
        public void gettime(decimal Hour, decimal min)
        {
            DateTime date = DateTime.Now;
            string result = "";
            Hour -= date.Hour;
            min -= date.Minute;
            
            if (min < 0)
            {
                Hour -= 1;
                min += 60;
            }
            if (Hour < 9)
            {
                result += "0" + Hour;
            }
            else
            {
                result += Hour;
            }
            result += ":";
            if (min < 9)
            {
                result += "0" + min;
            }
            else
            {
                result += min;
            }
           Console.WriteLine("расхождение во времени"+result);
        }
    }
    public interface IDigital {
        void gettime(decimal Hour, decimal min);
    }

    
    public class Adapter : IDigital
    {
        private IAnalog analog;
        public Adapter(IAnalog analog)
        {
            this.analog = analog;
        }
        public void gettime(decimal Hour, decimal min)
        {
            analog.getangle(Hour, min);
        }
    }
    public interface IAnalog {
        void getangle(decimal Hour, decimal min);
    }
    public class CLockWithArrow : IAnalog 
    {
        public void getangle(decimal Hour, decimal min)
        {
            string result = "";
            DateTime date = DateTime.Now;
            Hour -= date.Hour;
            min -= date.Minute;
            min *= 6;
            min += Hour*360;            
            result += min;

            Console.WriteLine("Поверните стрелку на " + result + " градусов");
        }
    }
}
//if (Hour < 0)
//{
//    Hour
//    Hour = -Hour * 30 + (-min / 60 * 30) + 360;
//}
//else
//{
//    Hour = -Hour * 30 + (-min / 60 * 30);
//}
//min = -min * 360 / 60;
//if (min < 0)
//{
//    min += 360;
//}
//if (Hour < 0)
//{
//    Hour += 360;
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4._2
{
    class Clock
    {
        int hour;
        int minute;
        int second;
        int hour_a;
        int minute_a;
        int second_a;
        public Clock(int h, int m, int s)
        {
            hour = h;
            minute = m;
            second = s;
        }
        public void SetAlarm(int h_a,int m_a,int s_a)
        {
            hour_a = h_a;
            minute_a = m_a;
            second_a = s_a;
        }
        DateTime clocktime = new DateTime();
        public delegate void ClockTick(object sender, DateTime args);
        public delegate void ClockAlarm(object sender, DateTime args);

        public event ClockTick OnTick;
        public event ClockAlarm OnAlarm;
        public void Tick()
        {
            Console.WriteLine("Time:" + hour + ":" +minute+":"+second);
        }
        public void Alarm()
        {
            if (hour_a == hour && minute_a == minute && second_a == second)
            {
                Console.WriteLine("Time out");
            }
            else
            {
                Console.WriteLine("It's not time");
            }
        }
    }

        class Program
    {
        static void Main(string[] args)
        {
            int h0 = 23;
            int m0 = 14;
            int s0 = 56;
            string s = "";
            s = Console.ReadLine();
            int ha = int.Parse(s);
            s = Console.ReadLine();
            int ma = int.Parse(s);
            s = Console.ReadLine();
            int sa = int.Parse(s);
            Clock clock = new Clock(h0,m0,s0);
            clock.SetAlarm(ha,ma,sa);
            clock.Tick();
            clock.Alarm();
            Console.ReadKey();
        }
    }
}

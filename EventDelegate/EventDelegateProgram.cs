using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate
{
   class EventDelegateProgram
    {
        static void Main(string[] args)
        {
            Even even = new Even();
            EventDelegateProgram eventDelegateProgram = new EventDelegateProgram();

            even.State += new EventDelegateEventHandler(eventDelegateProgram.EvenCatch);
            even.State += new EventDelegateEventHandler(eventDelegateProgram.EvenCatch2);
            even.Trigger();
            Console.ReadLine();
        }

        public void EvenCatch(String s)
        {
            Console.WriteLine(s);
        }

        public void EvenCatch2(String s)
        {
            Console.WriteLine(s);
        }
    }
}

public delegate void EventDelegateEventHandler(string s);
class Even
{
    public event EventDelegateEventHandler State;
    public void Trigger()
    {
        if (State != null)
            State("Even got triggered");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegatExample
{
    class Program
    {
        #region 
        public static void Main()
        {
            ProcessBusinessLogic bl = new ProcessBusinessLogic();
            bl.ProcessCompleted += bl_ProcessCompleted; // register with an event
            bl.StartProcess();

            // Ctrl + K + C , K + U
            //NormalDelegateEvent.ProcessBusinessLogic bl = new NormalDelegateEvent.ProcessBusinessLogic();
            //bl.ProcessCompleted += bl_ProcessCompleted; // register with an event
            //bl.StartProcess();

            //NormalDelegateEvent.ProcessBusinessLogic bl = new NormalDelegateEvent.ProcessBusinessLogic();
            //NormalDelegateEvent.Notify notify = new NormalDelegateEvent.Notify(bl.StartProcess);
            //notify += bl_ProcessCompleted;
            //notify();


        }

        // event handler
        public static void bl_ProcessCompleted(object sender, ProcessEventArgs e)  // Subscriber (Receiving notification)
        {
            Console.WriteLine("Process " + (e.IsSuccessful ? "Completed Successfully" : "failed"));
            Console.WriteLine("Completion Time: " + e.CompletionTime.ToLongDateString());
        }

        
        // event handler
        public static void bl_ProcessCompleted()
        {
            Console.WriteLine("Process Completed!");
        }
        #endregion
    }

    #region EventHandler
    public class ProcessBusinessLogic       // Publisher (Event raiser)
    {
        // declaring an event using built-in EventHandler
        public event EventHandler<ProcessEventArgs> ProcessCompleted;

        public void StartProcess()
        {
            var data = new ProcessEventArgs();

            try
            {
                Console.WriteLine("Process Started!");

                // some code here..

                data.IsSuccessful = true;
                data.CompletionTime = DateTime.Now;
                OnProcessCompleted(data);
            }
            catch (Exception ex)
            {
                data.IsSuccessful = false;
                data.CompletionTime = DateTime.Now;
                OnProcessCompleted(data);
            }
        }

        protected virtual void OnProcessCompleted(ProcessEventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }
    }
    public class ProcessEventArgs : EventArgs
    {
        public bool IsSuccessful { get; set; }
        public DateTime CompletionTime { get; set; }
    }

    #endregion


}


#region DelegateEvent


namespace NormalDelegateEvent
{

    public delegate void Notify();  // delegate

    public class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted; // event

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            // some code here..
            OnProcessCompleted();
        }

        protected virtual void OnProcessCompleted() //protected virtual method
        {
            //if ProcessCompleted is not null then call delegate
            ProcessCompleted?.Invoke();
        }
    }
}

#endregion
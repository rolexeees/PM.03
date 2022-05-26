using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleconNevaCommunication
{
    public delegate void TimerCreationEventHandler();
    internal class ShutdownTimer
    {
        int _runningTime = 10;

        public event TimerCreationEventHandler TimerCreationEvent;
        System.Windows.Threading.DispatcherTimer _timer;
        public ShutdownTimer(int runningTime)
        {
            _runningTime = runningTime;

            _timer = new System.Windows.Threading.DispatcherTimer();

            _timer.Tick += new EventHandler(timerTick);
            _timer.Interval = new TimeSpan(0, 0, _runningTime);
        }

        public void Run()
        {
            TimerCreationEvent?.Invoke();
            _timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            Manager.CodVhoda++;
            _timer.Stop();
        }
    }
}

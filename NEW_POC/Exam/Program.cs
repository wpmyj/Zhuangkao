using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Signal;
using Signal.MotorSignal;
using Exam.State.MotorState;
using Exam.SignalTranslator;

namespace Exam
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            MotorSignalSettings settings = (MotorSignalSettings)Util.ModuleConfig.GetSettings(new MotorSignalSettings().GetType(), "MotorSignal.config");

            IMonitor monitor = new MotorMonitor(settings);
            ITranslater translator = new MotorSignalTranslator(monitor);
            StateManager sm = new MotorStateManager(translator, settings);

            SimForm simForm = new SimForm();
            monitor.HotKeyHandle = simForm.Handle;
            monitor.RegMonitor(simForm);
            monitor.Start();
            Application.Run(simForm);
            //Use StateManager to set the entry state temporarily in dev
            sm.CurrentState = sm.EntryState;
        }

    }
}
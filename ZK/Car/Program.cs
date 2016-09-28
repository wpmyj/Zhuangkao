using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Core.Util;
using Cn.Youdundianzi.Share;
using Cn.Youdundianzi.Share.Util;


namespace Cn.Youdundianzi.Car
{
    class Program : IMonObserver 
    {
        static private SignLength signLen;
        [STAThread]
        static void Main()
        {
            Type t = Type.GetType("Cn.Youdundianzi.Share.Util.Car.CarSignalSettings");

            CSettings settings = (CSettings)ModuleConfig.GetSettings(t, "CarSignal.config");
            signLen = new SignLength();
            signLen.GAN_LENGTH = settings.SignConfig.GanLength;
            signLen.XIAN_LENGTH = settings.SignConfig.XianLength;
            signLen.CHE_LENGTH = settings.SignConfig.CheLength;

            Cn.Youdundianzi.Share.Util.Sim6G8X4C.SimForm simForm = new Cn.Youdundianzi.Share.Util.Sim6G8X4C.SimForm();

            ISignalMonitor monitor = SignalMonitorFactory.CreateSignalMonitor("Car.exe", "Cn.Youdundianzi.Share.Signal.Car.CarMonitor", settings);
            oldData = monitor.CreateMonDate(signLen);
            monitor.HotKeyHandle = simForm.Handle;
            monitor.RegMonitor(simForm);
            Program p = new Program();
            monitor.RegMonitor(p);

            ITranslator translator = TranslatorFactory.CreateTranslater("Car.exe", "Cn.Youdundianzi.Exam.CarSignalTranslator", monitor);
            //IStateManager sm = StateManagerFactory.CreateStateManager("Motor.exe", "Cn.Youdundianzi.Exam.State.MotorState.MotorStateManager", translator, settings);
            //IStateManager sm = StateManagerFactory.CreateStateManager("Motor.exe", "Cn.Youdundianzi.Exam.State.XA2WMotorState.MotorStateManager", translator, settings);
            IStateManager sm = StateManagerFactory.CreateStateManager("Car.exe", "Cn.Youdundianzi.Exam.State.CarState.CarStateManager", translator, settings);
            
            sm.CurrentState = sm.EntryState;

            monitor.Start();
            Application.Run(simForm);
        }

        #region IMonObserver Members

        static private IMonData oldData;
        public void Notify(IMonData data)
        {
            if (!oldData.Equals(data))
            {
                Console.Write(Environment.NewLine);
                Console.Write("Che:\t");
                for (int i = 0; i < signLen.CHE_LENGTH; i++)
                    Console.Write("{0}\t", data.GetSignal(SignalType.CHE, i));
                Console.Write(Environment.NewLine);
                Console.Write("Xian:\t");
                for (int i = 0; i < signLen.XIAN_LENGTH; i++)
                    Console.Write("{0}\t", data.GetSignal(SignalType.XIAN, i));
                Console.Write(Environment.NewLine);
                Console.Write("Gan:\t");
                for (int i = 0; i < signLen.GAN_LENGTH; i++)
                    Console.Write("{0}\t", data.GetSignal(SignalType.GAN, i));
                Console.Write(Environment.NewLine);
            }
            oldData.Copy(data);
        }

        #endregion
    }
}

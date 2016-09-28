using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Signal.MotorSignal;
using Shared;

namespace Signal
{
    class Program : IMonObserver 
    {
        static private SignLength signLen;
        [STAThread]
        static void Main()
        {
            MotorSignalSettings settings = (MotorSignalSettings)Util.ModuleConfig.GetSettings(new MotorSignalSettings().GetType(), "MotorSignal.config");
            signLen = new SignLength();
            signLen.GAN_LENGTH = settings.SignConfig.GanLength;
            signLen.XIAN_LENGTH = settings.SignConfig.XianLength;
            signLen.CHE_LENGTH = settings.SignConfig.CheLength;
            oldData = new CMonData(signLen);
            //SimForm simForm = new SimForm();
            IMonitor monitor = new MotorMonitor(settings);
            //monitor.HotKeyHandle = simForm.Handle;
            //monitor.RegMonitor(simForm);
            Program p = new Program();
            monitor.RegMonitor(p);
            monitor.Start();
            //Application.Run(simForm);
        }

        #region IMonObserver Members

        static private CMonData oldData;
        public void Notify(CMonData data)
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

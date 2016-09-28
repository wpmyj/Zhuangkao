using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace zhuangkao
{
    public class StateManager
    {
        public static CState CurrState;
        public CState0 State0;
        public CState1 State1;
        public CState2 State2;
        public CState3 State3;
        public CState4 State4;
        public CState4_che State4_che;
        public CState4i State4i;
        public CState5 State5;
        public CState6 State6;
        public CState7 State7;
        public CState8 State8;
        public CState8_che State8_che;
        public CState9 State9;
        public CState10 State10;
        public CState11 State11;
        public CState11i State11i;
        public CState12 State12;
        public CState13 State13;
        public CState14 State14;
        public CState14_che State14_che;
        public CState14i State14i;
        public CState14i_Che State14i_che;
        public CState15 State15;
        public CState16 State16;
        public CState17 State17;
        public CStateEnd StateEnd;
        private static Hashtable StateList;

        public StateManager(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec,ExamForm eform)
        {
            StateList = new Hashtable();
            State0 = new CState0(ganc, xianc, chec, eform);
            StateList.Add("State0", State0);
            State1 = new CState1(ganc, xianc, chec,eform);
            StateList.Add("State1", State1);
            State2 = new CState2(ganc, xianc, chec,eform);
            StateList.Add("State2", State2);
            State3 = new CState3(ganc, xianc, chec,eform);
            StateList.Add("State3", State3);
            if (eform.settings.HasCheSignal)
            {
                State4_che = new CState4_che(ganc, xianc, chec, eform);
                StateList.Add("State4", State4_che);
                State8_che = new CState8_che(ganc, xianc, chec, eform);
                StateList.Add("State8", State8_che);
                State14_che = new CState14_che(ganc, xianc, chec, eform);
                StateList.Add("State14", State14_che);
                State14i_che = new CState14i_Che(ganc, xianc, chec, eform);
                StateList.Add("State14i", State14i_che);
            }
            else
            {
                State4 = new CState4(ganc, xianc, chec, eform);
                StateList.Add("State4", State4);
                State8 = new CState8(ganc, xianc, chec, eform);
                StateList.Add("State8", State8);
                State14 = new CState14(ganc, xianc, chec, eform);
                StateList.Add("State14", State14);
                State14i = new CState14i(ganc, xianc, chec, eform);
                StateList.Add("State14i", State14i);
            }
            State4i = new CState4i(ganc, xianc, chec, eform);
            StateList.Add("State4i", State4i);
            State5 = new CState5(ganc, xianc, chec, eform);
            StateList.Add("State5", State5);
            State6 = new CState6(ganc, xianc, chec, eform);
            StateList.Add("State6", State6);
            State7 = new CState7(ganc, xianc, chec, eform);
            StateList.Add("State7", State7);
            
            State9 = new CState9(ganc, xianc, chec, eform);
            StateList.Add("State9", State9);
            State10 = new CState10(ganc, xianc, chec, eform);
            StateList.Add("State10", State10);
            State11 = new CState11(ganc, xianc, chec, eform);
            StateList.Add("State11", State11);
            State11i = new CState11i(ganc, xianc, chec, eform);
            StateList.Add("State11i", State11i);
            State12 = new CState12(ganc, xianc, chec, eform);
            StateList.Add("State12", State12);
            State13 = new CState13(ganc, xianc, chec, eform);
            StateList.Add("State13", State13);
            
            State15 = new CState15(ganc, xianc, chec, eform);
            StateList.Add("State15", State15);
            State16 = new CState16(ganc, xianc, chec, eform);
            StateList.Add("State16", State16);
            State17 = new CState17(ganc, xianc, chec, eform);
            StateList.Add("State17", State17);
            StateEnd = new CStateEnd(ganc, xianc, chec, eform);
            StateList.Add("StateEnd", StateEnd);
            CurrState = State1;
        }
        
        public static void SwitchState(string StateName)
        {
//#if DEBUG
            System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\log.log", true);
            if (StateName.Equals("State0"))
                sw.WriteLine("=======================================================================");
            sw.WriteLine("=====" + StateName + "=====");
            DateTime tmptime = DateTime.Now;
            sw.WriteLine(tmptime.Hour.ToString() + ":" + tmptime.Minute + ":" + tmptime.Second);
            sw.Close();
//#endif
            CurrState = (CState)StateList[StateName];
            CurrState.StateSwitchMesg();
        }

        public static void Close()
        {
            CurrState.Close(); 
        }

    }
}

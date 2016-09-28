using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Exam.SignalTranslator;
using Util;
using Signal.MotorSignal;

namespace Exam.State.XA2WMotorState
{
    public class MotorStateManager : StateManager, IMotorStateManager
    {
        private MotorBaseState _idleState;
        private MotorBaseState _ksState;
        private MotorBaseState _jsState;
        private MotorBaseState _y1State;
        private MotorBaseState _z1State;
        private MotorBaseState _yState;
        private MotorBaseState _zState;
        private MotorBaseState _c5State;
        private MotorBaseState _y2State;
        private MotorBaseState _z2State;
        private MotorBaseState _zwksState;
        private MotorBaseState _zwjsState;
        private MotorBaseState _sampleState;

        private uint _c5Time = 0;
        public uint C5Time
        {
            get { return _c5Time; }
        }
        public void Pass5()
        {
            _c5Time++;
        }
        public void ResetC5Time()
        {
            _c5Time = 0;
        }

        public MotorBaseState IDLE
        {
            get { return _idleState; }
        }

        public MotorBaseState KS
        {
            get { return _ksState; }
        }

        public MotorBaseState JS
        {
            get { return _jsState; }
        }

        public MotorBaseState Y1
        {
            get { return _y1State; }
        }

        public MotorBaseState Z1
        {
            get { return _z1State; }
        }

        public MotorBaseState Y
        {
            get { return _yState; }
        }

        public MotorBaseState Z
        {
            get { return _zState; }
        }

        public MotorBaseState C5
        {
            get { return _c5State; }
        }

        public MotorBaseState Y2
        {
            get { return _y2State; }
        }
        
        public MotorBaseState Z2
        {
            get { return _z2State; }
        }

        public MotorBaseState ZWKS
        {
            get { return _zwksState; }
        }

        public MotorBaseState ZWJS
        {
            get { return _zwjsState; }
        }

        public MotorBaseState SAMPLE
        {
            get { return _sampleState; }
        }

        public MotorStateManager(ITranslater ist, MotorSignalSettings settings)
        {
            _name = "MOTOR_2";
            _description = "Á½ÂÖÄ¦ÍÐ³µÈÆ×®×´Ì¬";

            Settings = settings;

            regobj = new ArrayList();

            MotorSignalTranslator st = (MotorSignalTranslator)ist;
            _idleState = new IdleState(st, this);
            _ksState = new KSState(st, this);
            _jsState = new JSState(st, this);
            _y1State = new Y1State(st, this);
            _z1State = new Z1State(st, this);
            _yState = new YState(st, this);
            _zState = new ZState(st, this);
            _c5State = new C5State(st, this);
            _y2State = new Y2State(st, this);
            _z2State = new Z2State(st, this);
            _zwksState = new ZWKSState(st, this);
            _zwjsState = new ZWJSState(st, this);
            _sampleState = new SampleState(st, this);
    
            ResetState();
        }

        public override void ResetState()
        {
            EntryState = _ksState;
            if (CurrentState == null)
                CurrentState = IDLE;
            else
                CurrentState.ChangeState(IDLE);
            ResetC5Time();
        }
    }
}

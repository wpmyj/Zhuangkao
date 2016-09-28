using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Core.Util;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Exam;
using Cn.Youdundianzi.Share.Util;
using Cn.Youdundianzi.Share.Util.Motor;

namespace Cn.Youdundianzi.Exam.State.MotorState
{
    public class MotorStateManager : StateManager, IMotorStateManager
    {
        private BaseState _idleState;
        private BaseState _ksState;
        private BaseState _jsState;
        private BaseState _y1State;
        private BaseState _z1State;
        private BaseState _yState;
        private BaseState _zState;
        private BaseState _c5State;
        private BaseState _sampleState;

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

        public BaseState IDLE
        {
            get { return _idleState; }
        }

        public BaseState KS
        {
            get { return _ksState; }
        }

        public BaseState JS
        {
            get { return _jsState; }
        }

        public BaseState Y1
        {
            get { return _y1State; }
        }

        public BaseState Z1
        {
            get { return _z1State; }
        }

        public BaseState Y
        {
            get { return _yState; }
        }

        public BaseState Z
        {
            get { return _zState; }
        }

        public BaseState C5
        {
            get { return _c5State; }
        }

        public BaseState SAMPLE
        {
            get { return _sampleState; }
        }

        public MotorStateManager(ITranslator ist, MotorSignalSettings settings)
            : base(ist, settings)
        {
            _name = "MOTOR_2";
            _description = "Á½ÂÖÄ¦ÍÐ³µÈÆ×®ÀíÏë×´Ì¬";

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

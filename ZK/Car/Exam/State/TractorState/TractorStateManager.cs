using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Core.Util;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Exam;
using Cn.Youdundianzi.Share.Util;
using Cn.Youdundianzi.Share.Util.Tractor;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class TractorStateManager : StateManager, ITractorStateManager
    {

        private BaseState _sampleState;
        private BaseState _idleState;
        //开始状态
        private BaseState _ksState;
        //结束状态
        private BaseState _jsState;
        //前进状态
        private BaseState _f1State;
        private BaseState _f2State;
        private BaseState _f3State;
        private BaseState _f4State;
        private BaseState _f5State;
        private BaseState _f6State;
        private BaseState _f7State;
        private BaseState _f7_2State;
        private BaseState _f8State;
        //移库成功状态
        private BaseState _fbState;
        //后退状态
        private BaseState _b1State;
        private BaseState _b2State;
        private BaseState _b3State;
        private BaseState _b4State;
        private BaseState _b5State;
        private BaseState _b6State;
        private BaseState _b7State;
        private BaseState _b7_2State;
        private BaseState _b8State;

        public BaseState KS
        {
            get { return _ksState; }
        }
        public BaseState JS
        {
            get { return _jsState; }
        }
        public BaseState SAMPLE
        {
            get { return _sampleState; }
        }
        public BaseState IDLE
        {
            get { return _idleState; }
        }
        public BaseState F1
        {
            get { return _f1State; }
        }
        public BaseState B1
        {
            get { return _b1State; }
        }
        public BaseState F2
        {
            get { return _f2State; }
        }
        public BaseState B2
        {
            get { return _b2State; }
        }
        public BaseState F3
        {
            get { return _f3State; }
        }
        public BaseState B3
        {
            get { return _b3State; }
        }
        public BaseState F4
        {
            get { return _f4State; }
        }
        public BaseState B4
        {
            get { return _b4State; }
        }
        public BaseState F5
        {
            get { return _f5State; }
        }
        public BaseState B5
        {
            get { return _b5State; }
        }
        public BaseState F6
        {
            get { return _f6State; }
        }
        public BaseState B6
        {
            get { return _b6State; }
        }
        public BaseState F7
        {
            get { return _f7State; }
        }
        public BaseState B7
        {
            get { return _b7State; }
        }
        public BaseState F7_2
        {
            get { return _f7_2State; }
        }
        public BaseState B7_2
        {
            get { return _b7_2State; }
        }
        public BaseState F8
        {
            get { return _f8State; }
        }
        public BaseState B8
        {
            get { return _b8State; }
        }
        public BaseState FB
        {
            get { return _fbState; }
        }


        public TractorStateManager(ITranslator ist, TractorSignalSettings settings)
            : base(ist, settings)
        {
            _name = "TRACTOR";
            _description = "牵引车状态管理器";

            Settings = settings;

            regobj = new ArrayList();

            CarSignalTranslator st = (CarSignalTranslator)ist;
            _idleState = new IdleState(st, this);
            _sampleState = new SampleState(st, this);

            _ksState = new KSState(st, this);
            _jsState = new JSState(st, this);

            _f1State = new F1State(st, this);
            _f2State = new F2State(st, this);
            _f3State = new F3State(st, this);
            _f4State = new F4State(st, this);
            _f5State = new F5State(st, this);
            _f6State = new F6State(st, this);
            _f7State = new F7State(st, this);
            _f7_2State = new F7_2State(st, this);
            _f8State = new F8State(st, this);

            _fbState = new FBState(st, this);

            _b1State = new B1State(st, this);
            _b2State = new B2State(st, this);
            _b3State = new B3State(st, this);
            _b4State = new B4State(st, this);
            _b5State = new B5State(st, this);
            _b6State = new B6State(st, this);
            _b7State = new B7State(st, this);
            _b7_2State = new B7_2State(st, this);
            _b8State = new B8State(st, this);
            
            ResetState();
        }
        
        #region ITractorStateManager Members

        #endregion

        public override void ResetState()
        {
            EntryState = _ksState;
            if (CurrentState == null)
                CurrentState = IDLE;
            else
                CurrentState.ChangeState(IDLE);
        }
    }
}

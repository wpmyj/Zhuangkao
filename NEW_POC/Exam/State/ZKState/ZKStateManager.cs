using System;
using System.Collections.Generic;
using System.Text;
using Exam;
using Exam.State;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class ZKStateManager : StateManager
    {
        private ZKBaseCState _sampleState;
        private ZKBaseCState _idleState;
        //¿ªÊ¼×´Ì¬
        private ZKBaseCState _ksState;
        //½ø¿â×´Ì¬
        private ZKBaseCState _jk32State;
        private ZKBaseCState _jk24State;
        private ZKBaseCState _jk474State;
        private ZKBaseCState _jk48State;
        private ZKBaseCState _jk8toState;
        //ÒÆ¿â×´Ì¬
        //Ð±³ö¿â×´Ì¬
        //µ¹¿â×´Ì¬
        //³ö¿â×´Ì¬

        public ZKBaseCState SAMPLE
        {
            get { return _sampleState; }
        }

        public ZKBaseCState IDLE
        {
            get { return _idleState; }
        }

        public ZKBaseCState KS
        {
            get { return _ksState; }
        }

        public ZKBaseCState JK32
        {
            get { return _jk32State; }
        }

        public ZKBaseCState JK24
        {
            get { return _jk24State; }
        }

        public ZKBaseCState JK474
        {
            get { return _jk474State; }
        }

        public ZKBaseCState JK48
        {
            get { return _jk48State; }
        }

        public ZKBaseCState JK8TO
        {
            get { return _jk8toState; }
        }

        public ZKStateManager(ZKSignalTranslator st)
        {
            _idleState = new IdleState(st, this);
            //_sampleState = new SampleState(st, this);
            _ksState = new KSState(st, this);
            _jk32State = new JK32State(st, this);
            _jk24State = new JK24State(st, this);
            _jk474State = new JK474State(st, this);
            _jk48State = new JK48State(st, this);
            _jk8toState = new JK8TOState(st, this);

            _name = "ZK_NO_CS";
            _description = "ÎÞ³µÐÅºÅ×®¿¼×´Ì¬";

            ResetState();
        }

        public override void ResetState()
        {
            EntryState = _ksState;
            //CurrentState = IDLE;
            CurrentState = KS;
        }
    }
}

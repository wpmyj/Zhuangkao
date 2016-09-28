using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Core.Util;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Exam;
using Cn.Youdundianzi.Share.Util;
using Cn.Youdundianzi.Share.Util.Car;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class CarStateManager : StateManager, ICarStateManager
    {

        private BaseState _sampleState;
        private BaseState _idleState;
        //¿ªÊ¼×´Ì¬
        private BaseState _ksState;
        //½áÊø×´Ì¬
        private BaseState _jsState;
        //½ø¿â×´Ì¬
        private BaseState _jk32State;
        private BaseState _jk24State;
        private BaseState _jk4State;
        private BaseState _jkl4State;
        private BaseState _jk4sState;
        private BaseState _jktoState;
        //ÒÆ¿â×´Ì¬
        private BaseState _yk1fState;
        private BaseState _yk1sState;
        private BaseState _yk1bState;
        private BaseState _yk2sState;
        private BaseState _yk2fState;
        private BaseState _yk3sState;
        private BaseState _yk2bState;
        private BaseState _yk4sState;
        //Ð±³ö¿â×´Ì¬
        private BaseState _xck24State;
        private BaseState _xck4State;
        private BaseState _xck14State;
        private BaseState _xckl4State;
        private BaseState _xck4sState;
        private BaseState _xckeState;
        //µ¹¿â×´Ì¬
        private BaseState _dk12State;
        private BaseState _dk24State;
        private BaseState _dk4State;
        private BaseState _dkl4State;
        private BaseState _dk4sState;
        private BaseState _dktoState;
        //³ö¿â×´Ì¬
        private BaseState _ckf4State;
        private BaseState _ck4State;
        private BaseState _ck34State;
        private BaseState _ckl4State;
        private BaseState _ck4sState;

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
        public BaseState JK32
        {
            get { return _jk32State; }
        }
        public BaseState JK24
        {
            get { return _jk24State; }
        }
        public BaseState JK4
        {
            get { return _jk4State; }
        }
        public BaseState JKL4
        {
            get { return _jkl4State; }
        }
        public BaseState JK4S
        {
            get { return _jk4sState; }
        }
        public BaseState JKTO
        {
            get { return _jktoState; }
        }
        public BaseState YK1F
        {
            get { return _yk1fState; }
        }
        public BaseState YK1S
        {
            get { return _yk1sState; }
        }
        public BaseState YK1B
        {
            get { return _yk1bState; }
        }
        public BaseState YK2S
        {
            get { return _yk2sState; }
        }
        public BaseState YK2F
        {
            get { return _yk2fState; }
        }
        public BaseState YK3S
        {
            get { return _yk3sState; }
        }
        public BaseState YK2B
        {
            get { return _yk2bState; }
        }
        public BaseState YK4S
        {
            get { return _yk4sState; }
        }
        public BaseState XCK24
        {
            get { return _xck24State; }
        }
        public BaseState XCK4
        {
            get { return _xck4State; }
        }
        public BaseState XCK14
        {
            get { return _xck14State; }
        }
        public BaseState XCKL4
        {
            get { return _xckl4State; }
        }
        public BaseState XCK4S
        {
            get { return _xck4sState; }
        }
        public BaseState XCKE
        {
            get { return _xckeState; }
        }
        public BaseState DK12
        {
            get { return _dk12State; }
        }
        public BaseState DK24
        {
            get { return _dk24State; }
        }
        public BaseState DK4
        {
            get { return _dk4State; }
        }
        public BaseState DKL4
        {
            get { return _dkl4State; }
        }
        public BaseState DK4S
        {
            get { return _dk4sState; }
        }
        public BaseState DKTO
        {
            get { return _dktoState; }
        }
        public BaseState CKF4
        {
            get { return _ckf4State; }
        }
        public BaseState CK4
        {
            get { return _ck4State; }
        }
        public BaseState CK34
        {
            get { return _ck34State; }
        }
        public BaseState CKL4
        {
            get { return _ckl4State; }
        }
        public BaseState CK4S
        {
            get { return _ck4sState; }
        }

        public CarStateManager(ITranslator ist, CarSignalSettings settings)
            : base(ist, settings)
        {
            _name = "CAR_PURE_RADIO";
            _description = "Æû³µÈÆ×®×´Ì¬¹ÜÀíÆ÷£¨·Ö»ú£©";

            Settings = settings;

            regobj = new ArrayList();

            CarSignalTranslator st = (CarSignalTranslator)ist;
            _idleState = new IdleState(st, this);
            _sampleState = new SampleState(st, this);

            _ksState = new KSState(st, this);
            _jsState = new JSState(st, this);

            _jk32State = new JK32State(st, this);
            _jk24State = new JK24State(st, this);
            _jk4State = new JK4State(st, this);
            _jkl4State = new JKL4State(st, this);
            _jk4sState = new JK4SState(st, this);
            _jktoState = new JKTOState(st, this);
            
            _yk1fState = new YK1FState(st, this);
            _yk1sState = new YK1SState(st, this);
            _yk1bState = new YK1BState(st, this);
            _yk2sState = new YK2SState(st, this);
            _yk2fState = new YK2FState(st, this);
            _yk3sState = new YK3SState(st, this);
            _yk2bState = new YK2BState(st, this);
            _yk4sState = new YK4SState(st, this);
            
            _xck24State = new XCK24State(st, this);
            _xck4State = new XCK4State(st, this);
            _xck14State = new XCK14State(st, this);
            _xckl4State = new XCKL4State(st, this);
            _xck4sState = new XCK4SState(st, this);
            _xckeState = new XCKEState(st, this);
            
            _dk12State = new DK12State(st, this);
            _dk24State = new DK24State(st, this);
            _dk4State = new DK4State(st, this);
            _dkl4State = new DKL4State(st, this);
            _dk4sState = new DK4SState(st, this);
            _dktoState = new DKTOState(st, this);
            
            _ckf4State = new CKF4State(st, this);
            _ck4State = new CK4State(st, this);
            _ck34State = new CK34State(st, this);
            _ckl4State = new CKL4State(st, this);
            _ck4sState = new CK4SState(st, this);

            ResetState();
        }

        public override void ResetState()
        {
            EntryState = _ksState;
            if (CurrentState == null)
                CurrentState = IDLE;
            else
                CurrentState.ChangeState(IDLE);
            _hasLeaveLine2 = false;
            _jklinenum = 2;
            _dklinenum = 2;
            _jkl1time = new DateTime(DateTime.MinValue.Ticks);
            _jkl2time = new DateTime(DateTime.MinValue.Ticks);
            _dkl3time = new DateTime(DateTime.MinValue.Ticks);
            _dkl2time = new DateTime(DateTime.MinValue.Ticks);
            _yknotified = false;
            _xcknotified = false;
            _dknotified = false;
            _cknotified = false;
            _ykh2startTime = DateTime.MinValue;
            _ykhl2Dur = new TimeSpan(0);
        }

        #region ICarStateManager Members

        private bool _hasLeaveLine2 = false;
        public bool HasLeaveLine2
        {
            get
            {
                return _hasLeaveLine2;
            }
            set
            {
                _hasLeaveLine2 = value;
            }
        }

        private int _jklinenum = 2;
        public int JKLineNum
        {
            get
            {
                return _jklinenum;
            }
            set
            {
                _jklinenum = value;
            }
        }

        private int _dklinenum = 2;
        public int DKLineNum
        {
            get
            {
                return _dklinenum;
            }
            set
            {
                _dklinenum = value;
            }
        }

        private DateTime _jkl1time = new DateTime(DateTime.MinValue.Ticks);
        public DateTime JKL1Time
        {
            get
            {
                return _jkl1time;
            }
            set
            {
                _jkl1time = value;
            }
        }

        private DateTime _jkl2time = new DateTime(DateTime.MinValue.Ticks);
        public DateTime JKL2Time
        {
            get
            {
                return _jkl2time;
            }
            set
            {
                _jkl2time = value;
            }
        }

        private DateTime _dkl3time = new DateTime(DateTime.MinValue.Ticks);
        public DateTime DKL3Time
        {
            get
            {
                return _dkl3time;
            }
            set
            {
                _dkl3time = value;
            }
        }

        private DateTime _dkl2time = new DateTime(DateTime.MinValue.Ticks);
        public DateTime DKL2Time
        {
            get
            {
                return _dkl2time;
            }
            set
            {
                _dkl2time = value;
            }
        }

        #endregion

        #region ICarStateManager Members

        private bool _yknotified = false;
        public bool YKNotified
        {
            get
            {
                return _yknotified;
            }
            set
            {
                _yknotified = value;
            }
        }

        private bool _xcknotified = false;
        public bool XCKNotified
        {
            get
            {
                return _xcknotified;
            }
            set
            {
                _xcknotified = value;
            }
        }

        private bool _dknotified = false;
        public bool DKNotified
        {
            get
            {
                return _dknotified;
            }
            set
            {
                _dknotified = value;
            }
        }

        private bool _cknotified = false;
        public bool CKNotified
        {
            get
            {
                return _cknotified;
            }
            set
            {
                _cknotified = value;
            }
        }

        #endregion

        #region ICarStateManager ³ÉÔ±


        private DateTime _ykh2startTime = DateTime.MinValue;
        public DateTime YKH2StartTime
        {
            get
            {
                return _ykh2startTime;
            }
            set
            {
                _ykh2startTime = value;
            }
        }

        private TimeSpan _ykhl2Dur = new TimeSpan(0);
        public TimeSpan YKHideLine2Duration
        {
            get
            {
                return _ykhl2Dur;
            }
            set
            {
                _ykhl2Dur = value;
            }
        }

        #endregion
    }
}

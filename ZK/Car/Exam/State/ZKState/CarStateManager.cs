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

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
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
        private BaseState _jk47State;
        private BaseState _jk74State;
        private BaseState _jk77State;
        private BaseState _jkl4State;
        private BaseState _jk48State;
        private BaseState _jk8TOState;
        private BaseState _jkTOState;
        //ÒÆ¿â×´Ì¬
        private BaseState _yk27State;
        private BaseState _yk771State;
        private BaseState _yk781State;
        private BaseState _yk88State;
        private BaseState _yk87State;
        private BaseState _yk772State;
        private BaseState _yk782State;
        private BaseState _ykl2State;
        private BaseState _ykh2State;
        private BaseState _ykl28State;
        private BaseState _ykh28State;
        //Ð±³ö¿â×´Ì¬
        private BaseState _xckl2State;
        private BaseState _xckh2State;
        private BaseState _xck74State;
        private BaseState _xck41State;
        private BaseState _xck14State;
        private BaseState _xck4EState;
        private BaseState _xckEState;
        //µ¹¿â×´Ì¬
        private BaseState _dk11State;
        private BaseState _dk12State;
        private BaseState _dk24State;
        private BaseState _dk47State;
        private BaseState _dk74State;
        private BaseState _dk77State;
        private BaseState _dkl4State;
        private BaseState _dk48State;
        //³ö¿â×´Ì¬
        private BaseState _ck84State;
        private BaseState _ck44State;
        private BaseState _ck34State;
        private BaseState _ck43State;
        private BaseState _ckeState;

        public BaseState SAMPLE
        {
            get { return _sampleState; }
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

        public BaseState JK32
        {
            get { return _jk32State; }
        }

        public BaseState JK24
        {
            get { return _jk24State; }
        }

        public BaseState JK47
        {
            get { return _jk47State; }
        }

        public BaseState JK74
        {
            get { return _jk74State; }
        }

        public BaseState JK77
        {
            get { return _jk77State; }
        }

        public BaseState JKL4
        {
            get { return _jkl4State; }
        }

        public BaseState JK48
        {
            get { return _jk48State; }
        }

        public BaseState JK8TO
        {
            get { return _jk8TOState; }
        }

        public BaseState JKTO
        {
            get { return _jkTOState; }
        }

        public BaseState YK27
        {
            get { return _yk27State; }
        }

        public BaseState YK771
        {
            get { return _yk771State; }
        }

        public BaseState YK781
        {
            get { return _yk781State; }
        }

        public BaseState YK88
        {
            get { return _yk88State; }
        }

        public BaseState YK87
        {
            get { return _yk87State; }
        }

        public BaseState YK772
        {
            get { return _yk772State; }
        }

        public BaseState YK782
        {
            get { return _yk782State; }
        }

        public BaseState YKL2
        {
            get { return _ykl2State; }
        }

        public BaseState YKH2
        {
            get { return _ykh2State; }
        }

        public BaseState YKL28
        {
            get { return _ykl28State; }
        }

        public BaseState YKH28
        {
            get { return _ykh28State; }
        }

        public BaseState XCKL2
        {
            get { return _xckl2State; }
        }

        public BaseState XCKH2
        {
            get { return _xckh2State; }
        }

        public BaseState XCK74
        {
            get { return _xck74State; }
        }

        public BaseState XCK41
        {
            get { return _xck41State; }
        }

        public BaseState XCK14
        {
            get { return _xck14State; }
        }

        public BaseState XCK4E
        {
            get { return _xck4EState; }
        }

        public BaseState XCKE
        {
            get { return _xckEState; }
        }

        public BaseState DK11
        {
            get { return _dk11State; }
        }

        public BaseState DK12
        {
            get { return _dk12State; }
        }

        public BaseState DK24
        {
            get { return _dk24State; }
        }

        public BaseState DK47
        {
            get { return _dk47State; }
        }

        public BaseState DK74
        {
            get { return _dk74State; }
        }

        public BaseState DK77
        {
            get { return _dk77State; }
        }

        public BaseState DKL4
        {
            get { return _dkl4State; }
        }

        public BaseState DK48
        {
            get { return _dk48State; }
        }

        public BaseState CK84
        {
            get { return _ck84State; }
        }

        public BaseState CK44
        {
            get { return _ck44State; }
        }

        public BaseState CK34
        {
            get { return _ck34State; }
        }

        public BaseState CK43
        {
            get { return _ck43State; }
        }

        public BaseState CKE
        {
            get { return _ckeState; }
        }



        public CarStateManager(ITranslator ist, CarSignalSettings settings)
            : base(ist, settings)
        {
            _name = "CAR_PURE_LINE";
            _description = "Æû³µÈÆ×®×´Ì¬¹ÜÀíÆ÷£¨7¡¢8Ïß£©";

            Settings = settings;

            regobj = new ArrayList();

            CarSignalTranslator st = (CarSignalTranslator)ist;
            _idleState = new IdleState(st, this);
            _ksState = new KSState(st, this);
            _jsState = new JSState(st, this);
            _sampleState = new SampleState(st, this);

            _jk32State = new JK32State(st, this);
            _jk24State = new JK24State(st, this);
            _jk47State = new JK47State(st, this);
            _jk74State = new JK74State(st, this);
            _jk77State = new JK77State(st, this);
            _jkl4State = new JKL4State(st, this);
            _jk48State = new JK48State(st, this);
            _jk8TOState = new JK8TOState(st, this);
            _jkTOState = new JKTOState(st, this);

            _yk27State = new YK27State(st, this);
            _yk771State = new YK771State(st, this);
            _yk781State = new YK781State(st, this);
            _yk88State = new YK88State(st, this);
            _yk87State = new YK87State(st, this);
            _yk772State = new YK772State(st, this);
            _yk782State = new YK782State(st, this);
            _ykl2State = new YKL2State(st, this);
            _ykh2State = new YKH2State(st, this);
            _ykl28State = new YKL28State(st, this);
            _ykh28State = new YKH28State(st, this);

            _xckl2State = new XCKL2State(st, this);
            _xckh2State = new XCKH2State(st, this);
            _xck74State = new XCK74State(st, this);
            _xck41State = new XCK41State(st, this);
            _xck14State = new XCK14State(st, this);
            _xck4EState = new XCK4EState(st, this);
            _xckEState = new XCKEState(st, this);

            _dk11State = new DK11State(st, this);
            _dk12State = new DK12State(st, this);
            _dk24State = new DK24State(st, this);
            _dk47State = new DK47State(st, this);
            _dk74State = new DK74State(st, this);
            _dk77State = new DK77State(st, this);
            _dkl4State = new DKL4State(st, this);
            _dk48State = new DK48State(st, this);

            _ck84State = new CK84State(st, this);
            _ck44State = new CK44State(st, this);
            _ck34State = new CK34State(st, this);
            _ck43State = new CK43State(st, this);
            _ckeState = new CKEState(st, this);

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

        #endregion

        #region ICarStateManager Members

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


        public bool YKNotified
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool XCKNotified
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool DKNotified
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool CKNotified
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
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

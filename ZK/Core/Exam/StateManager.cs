using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Util;

namespace Cn.Youdundianzi.Core.Exam
{
    public abstract class StateManager : IStateManager
    {
        protected string _name;
        protected string _description;
        private IState _curState;
        private ISettings _settings;

        public StateManager(ITranslator ist, ISettings settings)
        {
        }
        
        protected ArrayList regobj;
        public ArrayList ExamObservers
        {
            get { return regobj; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }

        public IState CurrentState
        {
            get { return _curState; }
            set
            {
                if (_curState != null)
                {
                    if (_curState != value)
                    {
                        _curState.UnRegEventHandle();
                        _curState = value;
                        _curState.RegEventHandle();
                        _curState.EntryTime = DateTime.Now;
                    }
                }
                else
                {
                    if (value != null)
                    {
                        _curState = value;
                        _curState.RegEventHandle();
                        _curState.EntryTime = DateTime.Now;
                    }
                }
            }
        }

        private IState _entryState;
        public IState EntryState
        {
            get { return _entryState; }
            set { _entryState = value; }
        }

        abstract public void ResetState();


        #region IStateManager Members


        public void RegExamObserver(IExamObserver obj)
        {
            regobj.Add(obj);
        }

        public void UnRegExamObserver(IExamObserver obj)
        {
            regobj.Remove(obj);
        }

        #endregion

        #region IStateManager Members


        virtual public ISettings Settings
        {
            get { return _settings; }
            set { _settings = value; }
        }

        #endregion
    }
}

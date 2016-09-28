using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.State.ZKState
{
    public class ZKFailureMsg : IFailureMessage
    {
        #region IFailureMessage Members

        public FailureType TypeOfFailure
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string Message
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}

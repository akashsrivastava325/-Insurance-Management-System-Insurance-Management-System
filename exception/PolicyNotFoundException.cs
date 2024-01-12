﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAssignment.MyExceptions
{
    [Serializable]
    public class PolicyNotFoundException : Exception
    {
        public PolicyNotFoundException() { }
        public PolicyNotFoundException(string message) : base(message) { }
        public PolicyNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected PolicyNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
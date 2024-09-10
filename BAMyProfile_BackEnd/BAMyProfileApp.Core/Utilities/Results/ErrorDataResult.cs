﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult() : base(default, false) { }
        public ErrorDataResult(string message) : base(default, false, message) { }

        public ErrorDataResult(T data, string message) : base(data, false, message) { }
    }
}

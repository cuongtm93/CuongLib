﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Others
{
    interface IFunction
    {
        dynamic Execute(params dynamic[] args);
    }

    interface IVoid
    {
        void Execute();
    }
}

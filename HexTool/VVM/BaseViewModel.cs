﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HexTool.VVM
{
    public abstract class BaseViewModel : DependencyObject
    {
        public Window Window {get; protected set;}
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal interface ITaskFactory
    {
        ATask CreateTask(String task_type, String task_details);
    }
}

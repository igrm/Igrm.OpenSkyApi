﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igrm.OpenSkyApi.Interfaces
{
    public interface ICommand
    {
        Task ExecuteAsync();
    }
}

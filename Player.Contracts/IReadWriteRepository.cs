﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Contracts
{
   public interface IReadWriteRepository<T>: IReadOnlyRepository<T>,IWriteRepository<T>
    {      
    }
}

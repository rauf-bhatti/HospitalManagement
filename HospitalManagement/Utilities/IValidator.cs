﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Utilities
{
    interface IValidator
    {
        public bool ValidateDataLength(string dataString, int length);
        public bool ValidateData(string dataString);
    }
}
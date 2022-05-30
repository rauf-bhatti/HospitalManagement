﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Utilities
{
    class LoginValidator : IValidator
    {
        public bool ValidateData(string dataString)
        {
            //Custom Implementation
            return dataString.Any(char.IsDigit); //Check if atleast one character contains a number
        }

        public bool ValidateDataLength(string dataString, int lowerBound, int upperBound)
        {
            if (dataString.Length <= 0 || dataString.Length < lowerBound) //Empty check is common to all login data that needs to be validated.
                return false;

            if (dataString.Length >= upperBound)
                return false;

            return true;
        }
    }
}

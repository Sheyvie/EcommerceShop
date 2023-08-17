﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Helpers
{
    public class Validation
    {

        public static bool Validate(List <string> inputs)
        {
            var valid = false;
            foreach (var input in inputs)
            {
                if (string.IsNullOrWhiteSpace(input)) {
                    valid = false;
                    break;
                }
                valid = true;
            }
            return valid;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.EmailSenderHelper
{
    public interface IEmailSenderHelper
    {
        Task SendRegistrationSuccessfulInfo(string emailAddress);

    }
}

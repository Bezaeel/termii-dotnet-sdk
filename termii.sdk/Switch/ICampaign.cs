﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace termii.sdk.Switch.Campaign;

public interface IPhoneBook
{
    Task<PhoneBookResponse> GetPhoneBooks();
}
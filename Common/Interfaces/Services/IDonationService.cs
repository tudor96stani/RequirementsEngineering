﻿using System;
using Common.DTO;

namespace Common.Interfaces.Services
{
    public interface IDonationService
    {
         void Add(string userId, string offerId, double amount);
    }
}
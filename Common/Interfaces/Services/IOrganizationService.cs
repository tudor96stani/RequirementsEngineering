﻿using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.Services
{
    public interface IOrganizationService
    {
        OrganizationDTO GetOrganizationProfileDetails(Guid id);
        List<EventDTO> GetAllEventsForOrganization(Guid id);

        List<EventQuickInfoDTO> GetAllEventsForOrganizationOrderedByDate(Guid id);
        List<UserDTO> GetTopVolunteers();

        List<EventQuickInfoDTO> GetAllEvents();
        
    }
}
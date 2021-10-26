﻿using System.Collections.Generic;
using System.Linq;
using Core.Domain;

namespace Core.DomainServices
{
    public interface ITherapistRepository
    {
        List<Therapist> GetAll();

        public Therapist FindByName(string name);
        public Therapist FindByEmail(string email);
    }
}
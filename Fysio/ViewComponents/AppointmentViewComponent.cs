using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DomainServices;
using Fysio.Models;
using Fysio.Models.Extensions;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Fysio.ViewComponents
{
    public class AppointmentViewComponent : ViewComponent
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ITherapistRepository _therapistRepository;

        public AppointmentViewComponent(IPatientRepository patientRepository, ITherapistRepository therapistRepository)
        {
            _patientRepository = patientRepository;
            _therapistRepository = therapistRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.IsInRole("Patient"))
            {
                var patient = _patientRepository.FindByName(User.Identity?.Name);
                return await Task.Run(() => View(patient.Appointments));
            }
            
            var therapist = _therapistRepository.FindByName(User.Identity?.Name);
            return await Task.Run(() => View(therapist.Appointments));
        }
    }
}
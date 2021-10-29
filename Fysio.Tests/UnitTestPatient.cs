using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;
using Core.DomainServices;
using Fysio.Controllers;
using Fysio.Models;
using Fysio.Models.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Appointment = Core.Domain.Appointment;
using Patient = Core.Domain.Patient;
using PatientFile = Core.Domain.PatientFile;
using Therapist = Core.Domain.Therapist;
using Treatment = Core.Domain.Treatment;
using TreatmentPlan = Core.Domain.TreatmentPlan;

namespace Fysio.Tests
{
    public class UnitTestPatient
    {
        [Fact(DisplayName = "BR_5")]
        public void PatientIsNotOlderThan16()
        {
            Patient patient = new Patient
            {
                Id = 1,
                PatientNumber = Guid.NewGuid().ToString(),
                StaffNumber = "11111111111",
                BigNumber = "11111111111",
                Name = "Pascal Stoop",
                Email = "p.stoop@test.com",
                Gender = "Male",
                Birthdate = DateTime.Now,
                PhoneNumber = "0612823332",
                PatientFile = new PatientFile(),
            };


            var therapist = new Therapist
            {
                Id = 1,
                Name = "Jantje therapist",
                Email = "test@test.com",
                PhoneNumber = "062872132131",
                AvailableDate = DateTime.Now.ToShortTimeString(),
                StudentNumber = "2168734",
                BigNumber = "1231313131",
            };

            var patient2 = new Patient
            {
                Id = 2,
                PatientNumber = Guid.NewGuid().ToString(),
                StaffNumber = "12321321321",
                BigNumber = "1232131313",
                Name = "Pascal Stoop",
                Email = "test2@test.com",
                Gender = "Male",
                Birthdate = DateTime.Today,
                PhoneNumber = "0612823332",
            };


            var therapistRepo = new Mock<ITherapistRepository>();
            var patientRepo = new Mock<IPatientRepository>();
            
            var service = new Mock<IServiceProvider>();
            therapistRepo.Setup(x => x.FindByEmail(therapist.Email)).Returns(therapist);
            patientRepo.Setup(x => x.FindByEmail(patient2.Email)).Returns(patient2);
            service.Setup(x => x.GetService(typeof(ITherapistRepository))).Returns(therapistRepo.Object);
            service.Setup(x => x.GetService(typeof(IPatientRepository))).Returns(patientRepo.Object);
            
            
            var isGood = validateModelState(patient.ConvertToModel(), service.Object);
            Assert.False(isGood);
        }
        

        public bool validateModelState(object model, IServiceProvider service)
        {
            var context = new ValidationContext(model, service, null);
            var results = new List<ValidationResult>();
            return Validator.TryValidateObject(model, context, results, true);
        }
    }
    
    
    
}

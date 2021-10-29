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
    public class UnitTestAppointment
    {
        [Fact(DisplayName = "BR_1")]
        public void CantBookMoreThanMax()
        {
            
            var PatientIdentity = new ClaimsIdentity("ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType); ;
            PatientIdentity.AddClaim(new Claim(ClaimTypes.Name, "Pascal.Stoop"));
            PatientIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "Pascal.Stoop"));
            PatientIdentity.AddClaim(new Claim(ClaimTypes.Role, "Patient"));

            var context = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(PatientIdentity)
                }
            };

            // SETUP
            Appointment appointment = new Appointment
            {
                Id = 1,
                PatientId = 1,
                TherapistId = 1,
                TreatmentId = 1,
                AddedDate = default,
                Date = DateTime.Now.AddYears(1)
            };
            
            Patient patient = new Patient
            {
                Id = 1,
                PatientNumber = Guid.NewGuid().ToString(),
                StaffNumber = "12321321321",
                BigNumber = "1232131313",
                Name = "Pascal Stoop",
                Email = "test@test.com",
                Gender = "Male",
                Appointments = new List<Appointment>
                {
                    new Appointment()
                    {
                        Id = 1,
                        PatientId = 1,
                        TherapistId = 1,
                        TreatmentId = 1,
                        AddedDate = default,
                        Date = DateTime.Now
                    },
                    new Appointment()
                    {
                        Id = 2,
                        PatientId = 1,
                        TherapistId = 1,
                        TreatmentId = 1,
                        AddedDate = default,
                        Date = DateTime.Now
                    }
                },
                Birthdate = DateTime.Today,
                PhoneNumber = "0612823332",
                PatientFile = new PatientFile(),
            };

            Therapist therapist = new Therapist
            {
                Id = 1,
                Name = "Jantje therapist",
                Email = "test@test.com",
                PhoneNumber = "062872132131",
                AvailableDate = DateTime.Now.ToShortTimeString(),
                StudentNumber = "2168734",
                BigNumber = "1231313131",
            };

            List<Therapist> therapists = new List<Therapist>()
            {
                new Therapist
                {
                    Id = 1,
                    Name = "Jantje therapist",
                    Email = "test@test.com",
                    PhoneNumber = "062872132131",
                    AvailableDate = DateTime.Now.ToShortTimeString(),
                    StudentNumber = "2168734",
                    BigNumber = "1231313131",
                },
                new Therapist
                {
                    Id = 2,
                    Name = "Jantje therapist",
                    Email = "test@test.com",
                    PhoneNumber = "062872132131",
                    AvailableDate = DateTime.Now.ToShortTimeString(),
                    StudentNumber = "2168734",
                    BigNumber = "1231313131",
                }
            };

            Treatment treatment = new Treatment
            {
                Id = 1,
                TreatmentPlanId = 1,
                Type = "1000",
                Description = "description",
                TherapistId = 1,
                TreatmentPlan = new TreatmentPlan
                {
                    Id = 1,
                    PatientFileId = 1,
                    MaxTreatments = 0,
                    StartTime = DateTime.Now,
                    EndTime = default
                },
                AddedDate = DateTime.Now,
                FinishDate = null
            };

            var appointmentRepo = new Mock<IAppointmentRepository>();
            var patientRepo = new Mock<IPatientRepository>();
            var therapistRepo = new Mock<ITherapistRepository>();
            var treatmentRepo = new Mock<ITreatmentRepository>();
            appointmentRepo.Setup(x => x.Find(appointment.Id)).Returns(appointment);
            patientRepo.Setup(x => x.FindByName(PatientIdentity.Name)).Returns(patient);
            therapistRepo.Setup(x => x.Find(therapist.Id)).Returns(therapist);
            therapistRepo.Setup(x => x.GetAll()).Returns(therapists);
            treatmentRepo.Setup(x => x.Find(treatment.Id)).Returns(treatment);
            
            var controller = new AppointmentController(appointmentRepo.Object, patientRepo.Object, therapistRepo.Object, treatmentRepo.Object);
            controller.ControllerContext = context;
            var appointmentViewModel = new AppointmentViewModel();
            appointment.TreatmentId = treatment.Id;
            appointment.TherapistId = therapist.Id;
            appointment.Date = DateTime.Now.AddYears(1);
            appointmentViewModel.Appointment = appointment.ConvertToModel();
            controller.Create(appointmentViewModel);
            
            Assert.False(controller.ModelState.IsValid);
        }
        
        [Fact(DisplayName = "BR_2")]
        public void IsNotAvailableInSchedule()
        {

            var plannedDate = DateTime.Now.AddYears(1);

                // SETUP
            Appointment appointment = new Appointment
            {
                Id = 1,
                PatientId = 1,
                TherapistId = 1,
                TreatmentId = 1,
                AddedDate = default,
                Date = plannedDate
            };
            
            Therapist therapist = new Therapist
            {
                Id = 1,
                Name = "Jantje therapist",
                Email = "test@test.com",
                PhoneNumber = "062872132131",
                AvailableDate = DateTime.Now.ToShortTimeString(),
                StudentNumber = "2168734",
                Appointments = new List<Appointment>
                {
                    new Appointment
                    {
                        Id = 1,
                        PatientId = 1,
                        TherapistId = 1,
                        TreatmentId = 1,
                        AddedDate = default,
                        Date = plannedDate
                    }
                },
                BigNumber = "1231313131",
            };

            var therapistRepo = new Mock<ITherapistRepository>();
            
            var service = new Mock<IServiceProvider>();
            therapistRepo.Setup(x => x.Find(therapist.Id)).Returns(therapist);
            service.Setup(x => x.GetService(typeof(ITherapistRepository))).Returns(therapistRepo.Object);

            var isGood = validateModelState(appointment.ConvertToModel(), service.Object);

            Assert.False(isGood);
        }

        [Fact(DisplayName = "BR_6")]
        public void CantCancel24Hour()
        {
            Appointment appointment = new Appointment
            {
                Id = 1,
                PatientId = 1,
                TherapistId = 1,
                TreatmentId = 1,
                AddedDate = default,
                Date = DateTime.Now.AddHours(4)
            };
            
            var appointmentRepo = new Mock<IAppointmentRepository>();
            var patientRepo = new Mock<IPatientRepository>();
            var therapistRepo = new Mock<ITherapistRepository>();
            var treatmentRepo = new Mock<ITreatmentRepository>();
            appointmentRepo.Setup(x => x.Find(appointment.Id)).Returns(appointment);
            var controller = new AppointmentController(appointmentRepo.Object, patientRepo.Object, therapistRepo.Object, treatmentRepo.Object);
            var result = controller.DeleteConfirmed(appointment.Id) as RedirectToActionResult;
            Assert.True(result == null);

        }
        
        
        public bool validateModelState(object model, IServiceProvider service)
        {
            var context = new ValidationContext(model, service, null);
            var results = new List<ValidationResult>();
            return Validator.TryValidateObject(model, context, results, true);
        }
    }
    
    
    
}

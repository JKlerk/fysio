using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Core.Domain;
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
    public class UnitTestTreatment
    {
        [Fact(DisplayName = "BR_3")]
        public void CantAddTreatmentAfterExpired()
        {
            var treatmentPlan = new TreatmentPlan
            {
                Id = 1,
                PatientFileId = 1,
                MaxTreatments = 10,
                StartTime = default,
                EndTime = DateTime.Now
            };
            
            var treatment = new Treatment
            {
                TreatmentPlanId = 1,
                Type = "1",
                Description = null,
                TherapistId = 1,
                AddedDate = DateTime.Now.AddDays(1),
                FinishDate = null
            };
            
            var treatmentType = new TreatmentType
            {
                Id = 1,
                TreatmentCode = "1000",
                Description = "Descrpition",
                ExplanationRequired = "Ja"
            };

            var treatmentRepo = new Mock<ITreatmentRepository>();
            var treatmentPlanRepo = new Mock<ITreatmentPlanRepository>();
            
            var service = new Mock<IServiceProvider>();
            treatmentRepo.Setup(x => x.GetTreatmentType(treatmentType.Id)).ReturnsAsync(treatmentType);
            treatmentPlanRepo.Setup(x => x.Find(treatment.TreatmentPlanId)).Returns(treatmentPlan);
            service.Setup(x => x.GetService(typeof(ITreatmentRepository))).Returns(treatmentRepo.Object);
            service.Setup(x => x.GetService(typeof(ITreatmentPlanRepository))).Returns(treatmentPlanRepo.Object);
            
            
            var isGood = validateModelState(treatment.ConvertToModel(), service.Object);
            
            
            Assert.False(isGood);

        }

        [Fact(DisplayName = "BR_4")]
        public void TreatmentRequiresNote()
        {
            var treatmentPlan = new TreatmentPlan
            {
                Id = 1,
                PatientFileId = 1,
                MaxTreatments = 10,
                StartTime = default,
                EndTime = DateTime.Now.AddDays(4)
            };
            
            var treatment = new Treatment
            {
                TreatmentPlanId = 1,
                Type = "1",
                Description = null,
                TherapistId = 1,
                AddedDate = DateTime.Now,
                FinishDate = null
            };
            
            var treatmentType = new TreatmentType
            {
                Id = 1,
                TreatmentCode = "1000",
                Description = "Descrpition",
                ExplanationRequired = "Ja"
            };

            var treatmentRepo = new Mock<ITreatmentRepository>();
            var treatmentPlanRepo = new Mock<ITreatmentPlanRepository>();
            
            var service = new Mock<IServiceProvider>();
            treatmentRepo.Setup(x => x.GetTreatmentType(treatmentType.Id)).ReturnsAsync(treatmentType);
            treatmentPlanRepo.Setup(x => x.Find(treatment.TreatmentPlanId)).Returns(treatmentPlan);
            service.Setup(x => x.GetService(typeof(ITreatmentRepository))).Returns(treatmentRepo.Object);
            service.Setup(x => x.GetService(typeof(ITreatmentPlanRepository))).Returns(treatmentPlanRepo.Object);
            
            
            var isGood = validateModelState(treatment.ConvertToModel(), service.Object);
            
            
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

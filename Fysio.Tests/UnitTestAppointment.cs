using System;
using Core.DomainServices;
using Fysio.Controllers;
using Fysio.Models;
using Fysio.Models.Extensions;
using Infrastructure;
using Moq;
using Xunit;
using Patient = Core.Domain.Patient;
using Treatment = Core.Domain.Treatment;
using TreatmentPlan = Core.Domain.TreatmentPlan;

namespace Fysio.Tests
{
    public class UnitTestAppointment
    {
        private readonly Mock<ITreatmentPlanRepository> _treatmentPlan;
        private readonly Mock<ITreatmentRepository> _treatment;
        private readonly Mock<ITherapistRepository> _therapist;

        [Fact]
        public async void CantBookMoreThanMax()
        {
            // SETUP
            var tpId = 1;
            TreatmentPlan treatmentPlan = new TreatmentPlan
            {
                Id = tpId,
                PatientFileId = 1,
                MaxTreatments = 1,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddYears(1)
            };

            Treatment treatment = new Treatment
            {
                TreatmentPlanId = tpId,
                Type = "1001",
                Description = "Notes",
                TherapistId = 1,
                AddedDate = default,
                FinishDate = DateTime.Now.AddYears(1)
            };
            _treatmentPlan.Setup(x => x.Find(tpId)).Returns(treatmentPlan);

            TreatmentViewModel treatmentViewModel = new TreatmentViewModel
            {
                TreatmentPlan = treatmentPlan.ConvertToModel(),
                Treatment = treatment.ConvertToModel(),
            };

            var controller = new TreatmentController(_treatment.Object, _therapist.Object, _treatmentPlan.Object);

            controller.CreatePost(treatmentViewModel);
            
            

        }
    }
}

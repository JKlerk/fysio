using System;
using Core.DomainServices;
using Fysio.Controllers;
using Fysio.Models;
using Fysio.Models.Extensions;
using Infrastructure;
using Moq;
using Xunit;
using Patient = Core.Domain.Patient;

namespace Fysio.Tests
{
    public class UnitTestPatient
    {
        
        private readonly Mock<IPatientRepository> _patientRepository = new Mock<IPatientRepository>();
        private readonly Mock<ITherapistRepository> _therapistRepository;
        private readonly Mock<IPatientFileRepository> _patientFileRepository;
        private readonly Mock<ITreatmentPlanRepository> _treatmentPlanRepository;
        private readonly Mock<ITreatmentRepository> _treatmentRepository;
        
        
        
        [Fact]
        public async void IsOldEnough()
        {
            
            PatientsController _patientController = new PatientsController(_patientRepository.Object, _therapistRepository.Object, _patientFileRepository.Object, _treatmentPlanRepository.Object, _treatmentRepository.Object);
            PatientViewModel patientViewModel = new PatientViewModel();
            
            var patient = new Patient
            {
                Id = 0,
                PatientNumber = "2168734",
                StaffNumber = "11111111111",
                BigNumber = "11111111111",
                Name = "John doe",
                Email = "test@test.com",
                Gender = "Male",
                Birthdate = DateTime.Now,
                PhoneNumber = "0628726470",
            };
            
            patientViewModel.Patient = patient.ConvertToModel();
            // var data =await _patientController.CreatePost(patientViewModel);
            
            // _patientController.SetFakeAuthenticatedControllerContext(controller);



            // mock.Setup(p => p.Find(1));
            // string result = await emp.GetEmployeeById(1);  
            // Assert.Equal("JK", data.ToString());  
        }
    }
}

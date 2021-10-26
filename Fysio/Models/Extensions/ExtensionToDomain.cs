using System.Collections.Generic;

namespace Fysio.Models.Extensions
{
    public static class ExtensionToDomain
    {
        public static Core.Domain.Patient ConvertToDomain(this Patient p)
        {
            return new Core.Domain.Patient
            {
                PatientNumber = p.PatientNumber,
                StaffNumber = p.StaffNumber,
                Name = p.Name,
                Email = p.Email,
                Gender = p.Gender,
                Birthdate = p.Birthdate,
                PhoneNumber = p.PhoneNumber,
            };
        }
        
        public static Core.Domain.PatientFile ConvertToDomain(this PatientFile pf)
        {
            return new Core.Domain.PatientFile
            {
                Age = pf.Age,
                Description = pf.Description,
                DiagnoseCode = pf.DiagnoseCode,
                InterviewerId = pf.InterviewerId,
                SupervisorId = pf.SupervisorId,
                PractitionerId = pf.PractitionerId,
                RegisterDate = pf.RegisterDate,
                DischargeDate = pf.DischargeDate,
                Notes = pf.Notes,
                TherapistType = pf.TherapistType,
                PatientId = pf.PatientId,
            };
        }
        
        public static Core.Domain.TreatmentPlan ConvertToDomain(this TreatmentPlan tp)
        {
            return new Core.Domain.TreatmentPlan
            {
                PatientFileId = tp.PatientFileId,
                MaxTreatments = tp.MaxTreatments,
                StartTime = tp.StartTime,
                EndTime = tp.EndTime
            };
        }
        
        public static Core.Domain.Treatment ConvertToDomain(this Treatment t)
        {
            return new Core.Domain.Treatment
            {
                TreatmentPlanId = t.TreatmentPlanId,
                Type = t.Type,
                Description = t.Description,
                TherapistId = t.TherapistId,
                AddedDate = t.AddedDate,
                FinishDate = t.FinishDate
            };
        }
    
        public static void AddTherapists(this IViewModel vm, List<Core.Domain.Therapist> therapists)
        {
            var data = new List<Therapist>();
            foreach (var t in therapists)
            {
                data.Add(t.ConvertToModel());
            }
            vm.SetTherapist(data);
        }
    }
}
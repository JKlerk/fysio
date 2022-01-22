using System.Collections.Generic;
using System.Linq;

namespace Fysio.Models.Extensions
{
    public static class ExtensionToDomain
    {
        public static Core.Domain.Patient ConvertToDomain(this Patient p)
        {
            return new Core.Domain.Patient
            {
                PatientNumber = p.PatientNumber,
                BigNumber = p.BigNumber,
                StaffNumber = p.StaffNumber,
                Name = p.Name,
                Email = p.Email,
                Gender = p.Gender,
                Birthdate = p.Birthdate,
                PhoneNumber = p.PhoneNumber,
            };
        }

        public static Core.Domain.Note ConvertToDomain(this Note n)
        {
            return new Core.Domain.Note
            {
                PatientFileId = n.PatientFileId,
                Text = n.Text,
                CreatedOn = n.CreatedOn,
                Placer = n.Placer,
                VisibleForPatient = n.VisibleForPatient
            };
        }
        
        
        public static Core.Domain.PatientFile ConvertToDomain(this PatientFile pf)
        {
            var notes = new List<Core.Domain.Note>();
            if (pf.Notes != null)
            {
                notes = pf.Notes.Select(n => n.ConvertToDomain()).ToList();
            }

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
                Notes = notes,
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
                Id = t.Id,
                TreatmentPlanId = t.TreatmentPlanId,
                Type = t.Type,
                Description = t.Description,
                TherapistId = t.TherapistId,
                AddedDate = t.AddedDate,
                FinishDate = t.FinishDate
            };
        }
        
        public static Core.Domain.Appointment ConvertToDomain(this Appointment a)
        {
            return new Core.Domain.Appointment
            {
                Id = a.Id,
                PatientId = a.PatientId,
                TherapistId = a.TherapistId,
                TreatmentId = a.TreatmentId,
                AddedDate = a.AddedDate,
                Date = a.Date
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
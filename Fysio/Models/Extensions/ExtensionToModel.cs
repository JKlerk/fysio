namespace Fysio.Models.Extensions
{
    public static class ExtensionToModel
    {
        public static Therapist ConvertToModel(this Core.Domain.Therapist t)
        {
            return new Therapist
            {
                Id = t.Id,
                Name = t.Name,
                Email = t.Email,
                PhoneNumber = t.PhoneNumber,
                ScheduleStart = t.ScheduleStart,
                ScheduleEnd = t.ScheduleEnd,
                StudentNumber = t.StudentNumber,
                BigNumber = t.BigNumber,
            };
        }
        
        public static Patient ConvertToModel(this Core.Domain.Patient p)
        {
            if (p.PatientFile != null)
            {
                return new Patient
                {
                    Id = p.Id,
                    BigNumber = p.BigNumber,
                    PatientNumber = p.PatientNumber,
                    StaffNumber = p.StaffNumber,
                    Name = p.Name,
                    Email = p.Email,
                    Gender = p.Gender,
                    PatientFile = p.PatientFile.ConvertToModel(),
                    Birthdate = p.Birthdate,
                    PhoneNumber = p.PhoneNumber,
                };
            }
            else
            {
                return new Patient
                {
                    Id = p.Id,
                    BigNumber = p.BigNumber,
                    PatientNumber = p.PatientNumber,
                    StaffNumber = p.StaffNumber,
                    Name = p.Name,
                    Email = p.Email,
                    Gender = p.Gender,
                    PatientFile = new PatientFile(),
                    Birthdate = p.Birthdate,
                    PhoneNumber = p.PhoneNumber,
                };
            }
            
        }
        
        public static PatientFile ConvertToModel(this Core.Domain.PatientFile pf)
        {
            return new PatientFile
            {
                Id = pf.Id,
                Age = pf.Age,
                Description = pf.Description,
                DiagnoseCode = pf.DiagnoseCode,
                InterviewerId = pf.InterviewerId,
                SupervisorId = pf.SupervisorId,
                PractitionerId = pf.PractitionerId,
                RegisterDate = pf.RegisterDate,
                DischargeDate = pf.DischargeDate,
                Notes = pf.Notes,
                PrivateNotes = pf.PrivateNotes,
                TherapistType = pf.TherapistType,
                PatientId = pf.PatientId,
            };
        }
        
        public static TreatmentPlan ConvertToModel(this Core.Domain.TreatmentPlan tp)
        {
            return new TreatmentPlan
            {
                PatientFileId = tp.PatientFileId,
                MaxTreatments = tp.MaxTreatments,
                StartTime = tp.StartTime,
                EndTime = tp.EndTime
            };
        }
        
        public static Treatment ConvertToModel(this Core.Domain.Treatment t)
        {
            return new Treatment
            {
                Id = t.Id,
                TreatmentPlanId = t.TreatmentPlanId,
                Type = t.Type,
                Description = t.Description,
                TherapistId = t.TherapistId,
                FinishDate = t.FinishDate
            };
        }
        
        public static Appointment ConvertToModel(this Core.Domain.Appointment a)
        {
            return new Appointment
            {
                Id = a.Id,
                PatientId = a.PatientId,
                TherapistId = a.TherapistId,
                TreatmentId = a.TreatmentId,
                AddedDate = a.AddedDate,
                Date = a.Date
            };
        }
    }
}
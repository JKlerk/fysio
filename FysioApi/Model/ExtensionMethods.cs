namespace FysioAPI
{
    public static class ExtensionMethods
    {
        public static Core.Domain.Diagnose ConvertToDomain(this Diagnose d)
        {
            return new Core.Domain.Diagnose
            {
                Id = d.Id,
                DiagnoseCode = d.DiagnoseCode,
                BodyLocation = d.BodyLocation,
                Pathology = d.Pathology
            };
        }
        
        public static Core.Domain.TreatmentType ConvertToDomain(this TreatmentType t)
        {
            return new Core.Domain.TreatmentType
            {
                Id = t.Id,
                TreatmentCode = t.TreatmentCode,
                Description = t.Description,
                ExplanationRequired = t.ExplanationRequired
            };
        }
    }
}
using System;
using System.Collections.Generic;
using Core.Domain;

namespace Infrastructure.Seeders
{
    public class NoteSeeder
    {
        public List<Note> notes { get; }

        public NoteSeeder(List<PatientFile> patientFiles)
        {
            List<Note> data = new List<Note>();

            data.Add(
                new Note
                {
                    Id = 1,
                    PatientFileId = patientFiles[0].Id,
                    Text = "Public Note 1",
                    CreatedOn = DateTime.Now,
                    Placer = "Pascal stoop",
                    VisibleForPatient = true
                }
            );
            
            data.Add(
                new Note
                {
                    Id = 2,
                    Text = "Public Note 1",
                    PatientFileId = patientFiles[0].Id,
                    CreatedOn = DateTime.Now,
                    Placer = "Pascal stoop",
                    VisibleForPatient = true
                }
            );

            notes = data;
        }
    }
}
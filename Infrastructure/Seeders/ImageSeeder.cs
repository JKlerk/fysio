using System.Collections.Generic;
using Core.Domain;

namespace Infrastructure.Seeders
{
    public class ImageSeeder
    {
        public List<Image> Images { get; }

        public ImageSeeder(List<Patient> patients)
        {
            List<Image> data = new List<Image>();
            data.Add(
                new Image {
                    Src = "https://source.unsplash.com/500x750/?person",
                    PatientId = patients[0].Id
                }
            );
            
            data.Add(
                new Image {
                    Src = "https://source.unsplash.com/500x750/?person",
                    PatientId = patients[1].Id
                }
            );

            Images = data;
        }
    }
}
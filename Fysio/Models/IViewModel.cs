using System.Collections.Generic;

namespace Fysio.Models
{
    public interface IViewModel
    {
        public void SetTherapist(List<Therapist> therapists);
    }
}
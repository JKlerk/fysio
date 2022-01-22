using System.Collections.Generic;
using Core.Domain;

namespace Core.DomainServices
{
    public interface INoteRepository
    {
        List<Note> GetAll();
        
        public void Add(Note note);

        void SaveChanges();
    }
}
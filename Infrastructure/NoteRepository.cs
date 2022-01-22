using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure
{
    public class NoteRepository : INoteRepository
    {
        private readonly FysioContext _context;

        public NoteRepository(FysioContext context)
        {
            _context = context;
        }

        public List<Note> GetAll()
        {
            return _context.Notes.ToList();
        }

        public void Add(Note note)
        {
            _context.Notes.Add(note);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
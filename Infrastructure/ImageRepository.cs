using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ImageRepository : IImageRepository
    {
        private readonly FysioContext _context;

        public ImageRepository(FysioContext context)
        {
            _context = context;
        }

        public List<Image> GetAll()
        {
            return _context.Images.ToList();
        }

        public void Add(Image image)
        {
            _context.Images.Add(image);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        
        
    }
}
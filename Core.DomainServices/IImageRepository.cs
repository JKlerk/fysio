using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices
{
    public interface IImageRepository
    {
        List<Image> GetAll();
        
        public void Add(Image image);

        void SaveChanges();
    }
}
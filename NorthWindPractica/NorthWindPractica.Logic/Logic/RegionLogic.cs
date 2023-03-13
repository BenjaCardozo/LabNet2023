using NorthWindPractica.Data;
using NorthWindPractica.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindPractica.Logic.Logic
{
    public class RegionLogic : BaseLogic, IABMLogic<Region, int>
    {
        public void Add(Region newRegion)
        {
            _context.Region.Add(newRegion);
            _context.SaveChanges();
        }
        public void Delete(Region deleteRegion)
        {
            _context.Region.Remove(deleteRegion);
            _context.SaveChanges(); 
        }
        public bool ExistID(int id) => _context.Region.Any(r => r.RegionID == id);

        public IEnumerable<Region> Find(string find) => _context.Region
            .Where(r => r.RegionDescription.ToLower().Contains(find));

        public IEnumerable<Region> GetAll() => _context.Region.ToList();

        public Region GetById(int id) => _context.Region.First(r=> r.RegionID == id);
        
        public void Update(Region updateRegion)
        {
            var regionToUpdate = _context.Region.Find(updateRegion.RegionID);

            regionToUpdate.RegionDescription = updateRegion.RegionDescription;

            _context.SaveChanges();
        }
    }
}

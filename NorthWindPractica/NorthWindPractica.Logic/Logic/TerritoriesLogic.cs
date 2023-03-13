using NorthWindPractica.Data;
using NorthWindPractica.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindPractica.Logic.Logic
{
    public class TerritoriesLogic : BaseLogic, IABMLogic<Territories, string>
    {
        public IEnumerable<Territories> GetAll() => _context.Territories.ToList();

        public Territories GetById(string id)=> _context.Territories.First(t=> t.TerritoryID ==id);

        public void Add(Territories newTerritory)
        {
            _context.Territories.Add(newTerritory);
            _context.SaveChanges();
        }

        public void Delete(Territories deleteTerritory)
        {
            _context.Territories.Remove(deleteTerritory);
            _context.SaveChanges();
        }
        

        public string IdGenerator()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 99999);
            string randomString = randomNumber.ToString("D5");
            return randomString;
        }

        public void Update(Territories updateTerritory)
        {
            Territories territoryToUpdate = _context.Territories.Find(updateTerritory.TerritoryID);

            territoryToUpdate.TerritoryDescription = updateTerritory.TerritoryDescription;
            territoryToUpdate.RegionID = updateTerritory.RegionID;

            _context.SaveChanges();
        }
        public bool ExistID(string id) => _context.Territories.Any(r=> r.TerritoryID == id);

        public IEnumerable<Territories> Find(string find) => _context.Territories
            .Where(t => t.TerritoryDescription.ToLower().Contains(find))
            .ToList();
    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Practice.Data;
using Practice.Models;

namespace Practice
{
    public class ProvinceService : IProvinceService
    {
        private readonly ApplicationDbContext _context;
        public ProvinceService( ApplicationDbContext context)
        {
            _context = context;
        }

        public int Create(ProvinceModel model)
        {

            // some logic here

            // condition

            // check unique province name 
            int count = 0;

            //foreach (var x in _context.ProvinceModel)
            //{
            //    if (x.Name == model.Name && x.CountryId == model.CountryId)
            //    {
            //        count++;
            //    }
            //}


            ////OR


            count = _context.ProvinceModel.Where(x => x.Name == model.Name && x.CountryId == model.CountryId).Count();

            

            if (count > 0)
            {
                //Duplicate name found, Name already exist 
                return 0;
            }
            else
            {
                _context.ProvinceModel.Add(model);
                int id = _context.SaveChanges();
                return id;
            }           
        }

        public int Update(ProvinceModel model)
        {

            ProvinceModel existingmodel = _context.ProvinceModel.Find(model.Id);
            if (existingmodel.Name == model.Name)
            {
                _context.ProvinceModel.Update(model);
                int id =  _context.SaveChanges();
                return id;
            }

            else
            {
                int count = 0;
                count = _context.ProvinceModel.Where(x=>x.Name == model.Name && x.CountryId == model.CountryId).Count();
                if (count == 0)
                {
                    _context.ProvinceModel.Update(model);
                    int effectedrecords = _context.SaveChanges();
                    return effectedrecords;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Delete(int id)
        {
            var data  = _context.ProvinceModel.Find(id);
            _context.ProvinceModel.Remove(data);
            int effectedrecords = _context.SaveChanges();
            return  effectedrecords;
        }

        public List<ProvinceModel> GetProvinces()
        {
            return _context.ProvinceModel.Include(x=>x.Country).ToList();
        }

        public ProvinceModel GetProvinces(int id)
        {
            return _context.ProvinceModel
                .Include(x => x.Country)
                .FirstOrDefault(x=>x.Id==id);
        }

        public List<CountryModel> GetCountries()
        {
            return _context.CountryModel.ToList();
        }
    }
}

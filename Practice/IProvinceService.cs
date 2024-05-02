using Practice.Models;

namespace Practice
{
    public interface IProvinceService
    {
        public int Create(ProvinceModel model);

        public int Update(ProvinceModel model);

        public int Delete(int id);

        public List<ProvinceModel> GetProvinces();

        public ProvinceModel GetProvinces(int id);
    }
}

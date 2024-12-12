using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories;
using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA24_PRN221_3W_G3_KoiCareSystemAtHome.Services
{
    public class PondService
    {
        private PondRepository _repository;
        public PondService()
        {
            _repository = new PondRepository();
        }

        public async Task<List<Pond>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<int> Create(Pond pond)
        {
            return await _repository.CreateAsync(pond);
        }

        public async Task<Pond> GetById(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Pond> GetByIdLong(long id)
        {
            return await _repository.GetByIdLongAsync(id);
        }

        public async Task<int> Update(Pond pond)
        {
            return await _repository.UpdateAsync(pond);
        }

        public async Task<bool> Delete(Pond pond)
        {
            return await _repository.RemoveAsync(pond);
        }

        //public List<pond> Search(string bankNo, string holderName, string holderTaxCode)
        //{
        //    return _repository.Search(bankNo, holderName, holderTaxCode);
        //}
    }
}

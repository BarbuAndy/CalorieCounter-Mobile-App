using CC.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Repository
{
    public interface IBaseRepository<T,R>
    {
        public void Add(T e);
        public void Delete(T e);
        public void Update(T e);
        public IEnumerable<T> Get(R req);

    }
}

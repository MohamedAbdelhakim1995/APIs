using System.Collections.Generic;

namespace EcommerceApis.Interfaces
{
    public interface IRepository <T >
    {
        List<T> GetAll();

        T GetById(int id);

       int Insert(T obj);

        int Update(int id, T obj);

        int Delete(int id);


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TiendaContext context;

        private PaisRepository _paises;

        public IPaisInterface Paises => new PaisRepository(context);

        /* IPaisInterface IUnitOfWork.Paises { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
 */
        public UnitOfWork(TiendaContext _context)
        {
            context = _context;
        }
        public IPaisInterface Paise
        {
            get{
                if(_paises ==null){
                    _paises = new PaisRepository(context);
                }
                return _paises;
            }
        }
        public int Save()
        {
            throw new NotImplementedException();
        }
        
    }
}
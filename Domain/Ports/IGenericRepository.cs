using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove.Domain.Ports;
public interface IGenericRepository<T>
{
    List<T> Obtener();
    void Crear(T entity);
    void Actualizar(T entity);
    void Eliminar(int var);
}

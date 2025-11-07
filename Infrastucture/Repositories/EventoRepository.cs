using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class EventoRepository : GenericRepository<Evento>, IEventoRepository//herencia 
    {
        public EventoRepository(VirticketDbContext context) : base(context)//el :base es el constructor del padre(del generico)
        { }
        
    }
}
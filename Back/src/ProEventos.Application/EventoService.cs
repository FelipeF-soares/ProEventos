using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist geralPersist;
        private readonly IEventoPersist eventoPersist;

        public EventoService(IGeralPersist geralPersist,IEventoPersist eventoPersist)
        {
            this.geralPersist = geralPersist;
            this.eventoPersist = eventoPersist;
        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                geralPersist.Add<Evento>(model);
                if(await geralPersist.SaveChangesAsync())
                {
                    return await eventoPersist.GetAllEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        
        public async Task<Evento> UpDate(int eventoId, Evento model)
        {
            try
            {
               var evento = await eventoPersist.GetAllEventoByIdAsync(eventoId,false);
               if(evento == null) return null;

               model.Id = evento.Id;

                geralPersist.UpDate<Evento>(model);
                if(await geralPersist.SaveChangesAsync())
                {
                    return await eventoPersist.GetAllEventoByIdAsync(model.Id, false);
                }
                return null;

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
               var evento = await eventoPersist.GetAllEventoByIdAsync(eventoId,false);
               if(evento == null) throw new Exception("Evento para delete não encontrado.");

                geralPersist.Delete<Evento>(evento);
                return await geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            try
            {
                var eventos = await eventoPersist.GetAllEventosAsync(includePalestrante);
                if(eventos == null) return null;
                return eventos;
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetAllEventoByIdAsync(int eventoId, bool includePalestrante = false)
        {
           try
            {
                var evento = await eventoPersist.GetAllEventoByIdAsync( eventoId ,includePalestrante);
                if(evento == null) return null;
                return evento;
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
              try
            {
                var evento = await eventoPersist.GetAllEventosByTemaAsync( tema, includePalestrante);
                if(evento == null) return null;
                return evento;
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
        }
    }
}

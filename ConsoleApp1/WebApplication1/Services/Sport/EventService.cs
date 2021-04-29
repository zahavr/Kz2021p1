using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model;
using WebApplication1.EfStuff.Repositoryies;

namespace WebApplication1.Services.Sport
{
    public class EventService
    {
        private SportEventRepository _sportEventRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public EventService(SportEventRepository sportEventRepository, IHttpContextAccessor httpContextAccessor)
        {
            _sportEventRepository = sportEventRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public SportEvent GetEvent()
        {

            var idStr = _httpContextAccessor
                .HttpContext.User.Claims.SingleOrDefault(x => x.Type == "Id")?.Value;
            if (string.IsNullOrEmpty(idStr))
            {
                return null;
            }
            
            var id = int.Parse(idStr);
            return _sportEventRepository.Get(id);
        }
    }
}

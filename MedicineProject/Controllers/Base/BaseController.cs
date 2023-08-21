using AutoMapper;
using MedicineProject.Context;
using MedicineProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MedicineProject.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly WebMobileContext context;
        protected readonly IMapper mapper;
        protected readonly IMemoryCache cache;
        protected readonly MobileAndWebRepository mobileAndWebRepository;

        public BaseController(WebMobileContext context, IMapper mapper, IMemoryCache memoryCache)
        {
            this.context = context;
            this.mapper = mapper;
            cache = memoryCache;
            this.mobileAndWebRepository = new MobileAndWebRepository(context); 
        }

        /// <summary>
        /// Этот метод использует AutoMapper, перед его использованием, 
        /// убедитесь, что у вас настроен маппинг между этими типами
        /// </summary>
        /// <typeparam name="ORIGINAL_TYPE"></typeparam>
        /// <typeparam name="TARGET_TYPE"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        protected List<TARGET_TYPE> MapObjects<ORIGINAL_TYPE, TARGET_TYPE>(List<ORIGINAL_TYPE> items)
        {
            List<TARGET_TYPE> DTOs = new List<TARGET_TYPE>();
            items.ForEach(item => DTOs.Add(mapper.Map<TARGET_TYPE>(item)));
            return DTOs;
        }
    }
}

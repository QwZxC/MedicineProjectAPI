﻿using AutoMapper;
using MedicineProject.Domain.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MedicineProject.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly WebMobileContext context;
        protected readonly IMapper mapper;
        protected readonly IMemoryCache cache;

        public BaseController(WebMobileContext context, IMapper mapper, IMemoryCache memoryCache)
        {
            this.context = context;
            this.mapper = mapper;
            cache = memoryCache; 
        }

        /// <summary>
        /// Этот метод использует AutoMapper, перед его использованием
        /// убедитесь, что у вас настроен маппинг между этими типами.
        /// Принимает список объектов, которые вы хотите преобразовать в другой тип.
        /// Возвращает список преобразованных объектов.
        /// Первый джейнерик - тип из которого будет происходить преобразование.
        /// Второй джейнерик - тип в который будет происходить преоброзование.
        /// </summary>
        /// <typeparam name="TOriginal"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="objects"></param>
        /// <returns></returns>
        protected List<TTarget> MapObjects<TOriginal, TTarget>(List<TOriginal> objects)
        {
            List<TTarget> DTOs = new List<TTarget>();
            objects.ForEach(item => DTOs.Add(mapper.Map<TTarget>(item)));
            return DTOs;
        }
    }
}

﻿using Meetins.Models.Events.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meetins.Abstractions.Repositories
{
    /// <summary>
    /// Абстракция к репозиторию событий.
    /// </summary>
    public interface IEventRepository
    {
        /// <summary>
        /// Метод вернёт список категорий событий.
        /// </summary>
        /// <returns>Список категорий событий.</returns>
        Task<IEnumerable<EventsCategoryOutput>> GetEventsCategotiesListAsync();

        /// <summary>
        /// Метод вернёт список всех событий.
        /// </summary>
        /// <returns>Список всех событий.</returns>
        Task<IEnumerable<EventOutput>> GetEventsListAsync();

        /// <summary>
        /// Метод вернёт событие по Id.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="eventId">Идентификатор события.</param>
        /// <returns>Модель события.</returns>
        Task<EventOutput> GetEventByIdAsync(Guid userId, Guid eventId);

        /// <summary>
        /// Метод подпишет пользователя на событие.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="eventId">Идентификатор события.</param>
        /// <returns>Модель события.</returns>
        Task<EventOutput> SubscribeToEventAsync(Guid userId, Guid eventId);

        /// <summary>
        /// Метод отменит подписку пользователя на событие.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="eventId">Идентификатор события.</param>
        /// <returns>Модель события.</returns>
        Task<EventOutput> UnSubscribeToEventAsync(Guid userId, Guid eventId);
    }
}

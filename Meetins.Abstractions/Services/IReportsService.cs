﻿using Meetins.Models.Entities;
using Meetins.Models.Reports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Meetins.Abstractions.Services
{
    /// <summary>
    /// Абстракция сервиса всех обращений.
    /// </summary>
    public interface IReportsService
    {
        /// <summary>
        /// Получение списка всех обращений.
        /// </summary>
        /// <returns> Список всех обращений. </returns>
        Task<IEnumerable<ReportOutput>> GetAllReportsAsync();

        /// <summary>
        /// Получение обращения по Id.
        /// </summary>
        /// <param name="reportId"> Идентификатор обращения. </param>
        /// <returns> Обращение. </returns>
        Task<ReportOutput> GetReportByReportIdAsync(Guid reportId);

        /// <summary>
        /// Получение всех обращений от пользователя.
        /// </summary>
        /// <param name="userId"> Идентификатор пользователя. </param>
        /// <returns> Список обращений. </returns>
        Task<IEnumerable<ReportOutput>> GetReportsByUserIdAsync(Guid userId);

        /// <summary>
        /// Получение открытых обращений.
        /// </summary>
        /// <returns> Список обращений. </returns>
        Task<IEnumerable<ReportOutput>> GetOpenReportsAsync();

        /// <summary>
        /// Получение закрытых обращений.
        /// </summary>
        /// <returns> Список обращений. </returns>
        Task<IEnumerable<ReportOutput>> GetClosedReportsAsync();

        /// <summary>
        /// Получение списка обращений за период времени.
        /// </summary>
        /// <param name="startOfPeriod"> Начало периода. </param>
        /// <param name="endOfPeriod"> Конец периода.</param>
        /// <returns> Список обращений. </returns>
        Task<IEnumerable<ReportOutput>> GetReportsForPeriodAsync(DateTime startOfPeriod, DateTime endOfPeriod);

        Task<bool> CreateReportAsync(Guid userId, string topic, string text);

        Task<bool> CloseReportAsync(Guid reportId);

        Task<bool> OpenReportAsync(Guid reportId);
    }
}

using Meetins.Abstractions.Repositories;
using Meetins.Abstractions.Services;
using Meetins.Models.Reports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meetins.Services.Reports
{
    /// <summary>
    /// В сервисе содержится функционал для обращений.
    /// </summary>
    public class ReportsService : IReportsService
    {
        private IReportsRepository _reportRepository;

        public ReportsService(IReportsRepository reportsRepository)
        {
            _reportRepository = reportsRepository;
        }

        /// <summary>
        /// Получение списка всех обращений.
        /// </summary>
        /// <returns> Список всех обращений. </returns>
        public async Task<IEnumerable<ReportOutput>> GetAllReportsAsync()
        {
            try
            {
                var result = await _reportRepository.GetAllReportsAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            } 
        }

        /// <summary>
        /// Получение обращения по Id.
        /// </summary>
        /// <param name="reportId"> Идентификатор обращения. </param>
        /// <returns> Обращение. </returns>
        public async Task<ReportOutput> GetReportByReportIdAsync(Guid reportId)
        {
            try
            {
                var result = await _reportRepository.GetReportByReportIdAsync(reportId);

                return result;
            }
            catch(Exception)
            {
                throw;
            } 
        }

        /// <summary>
        /// Получение всех обращений от пользователя.
        /// </summary>
        /// <param name="userId"> Идентификатор пользователя. </param>
        /// <returns> Список обращений. </returns>
        public async Task<IEnumerable<ReportOutput>> GetReportsByUserIdAsync(Guid userId)
        {
            try
            {
                var result = await _reportRepository.GetReportsByUserIdAsync(userId);

                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Получение открытых обращений.
        /// </summary>
        /// <returns> Список обращений. </returns>
        public async Task<IEnumerable<ReportOutput>> GetOpenReportsAsync()
        {
            try
            {
                var result = await _reportRepository.GetOpenReportsAsync();

                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Получение закрытых обращений.
        /// </summary>
        /// <returns> Список обращений. </returns>
        public async Task<IEnumerable<ReportOutput>> GetClosedReportsAsync()
        {
            try
            {
                var result = await _reportRepository.GetClosedReportsAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Получение списка обращений за период времени.
        /// </summary>
        /// <param name="startOfPeriod"> Начало периода. </param>
        /// <param name="endOfPeriod"> Конец периода.</param>
        /// <returns> Список обращений. </returns>
        public async Task<IEnumerable<ReportOutput>> GetReportsForPeriodAsync(DateTime startOfPeriod, DateTime endOfPeriod)
        {
            try
            {
                var result = await _reportRepository.GetReportsForPeriodAsync(startOfPeriod, endOfPeriod);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Создание обращения от пользователя.
        /// </summary>
        /// <param name="userId"> Идентификатор пользователя. </param>
        /// <param name="topic"> Тема обращения. </param>
        /// <param name="text">  Текст обращения. </param>
        /// <returns> True, если обращение отправлено. </returns>
        public async Task<bool> CreateReportAsync(Guid userId, string topic, string text)
        {
            try
            {
                var result = await _reportRepository.CreateReportAsync(userId, topic, text);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Закрыть обращение.
        /// </summary>
        /// <param name="reportId"> Идентификатор обращения. </param>
        /// <returns> True, если обращение закрыто. </returns>
        public async Task<bool> CloseReportAsync(Guid reportId)
        {
            try
            {
                var result = await _reportRepository.CloseReportAsync(reportId);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Открыть обращение.
        /// </summary>
        /// <param name="reportId"> Идентификатор обращения. </param>
        /// <returns> True, если обращение открыто. </returns>
        public async Task<bool> OpenReportAsync(Guid reportId)
        {
            try
            {
                var result = await _reportRepository.OpenReportAsync(reportId);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

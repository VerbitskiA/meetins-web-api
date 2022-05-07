using Meetins.Abstractions.Repositories;
using Meetins.Core.Data;
using Meetins.Core.Logger;
using Meetins.Models.Entities;
using Meetins.Models.Reports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetins.Services.Reports
{
    /// <summary>
    /// В репозитории содержится функционал для обращений.
    /// </summary>
    public class ReportsRepository : IReportsRepository
    {
        private IDataContext _dataContext;

        public ReportsRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Получение списка всех обращений.
        /// </summary>
        /// <returns> Список всех обращений. </returns>
        public async Task<IEnumerable<ReportOutput>> GetAllReportsAsync()
        {
            try
            {
                var result = await _dataContext.Reports.Include(d => d.User)
                .Select(report => new ReportOutput
                {
                    ReportId = report.ReportId,
                    UserId = report.UserId,
                    UserName = report.User.Name,
                    IsOpened = report.IsOpened,
                    Topic = report.Topic,
                    Text = report.Text,
                    Date = report.Date
                })
                .ToListAsync();

                return result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                var logger = new Logger(_dataContext, e.GetType().FullName, e.Message, e.StackTrace);
                await logger.LogError();
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
                var report = await GetReportById(reportId);               
                
                var result = new ReportOutput()
                {
                    ReportId = report.ReportId,
                    UserId = report.UserId,
                    UserName = report.User.Name,
                    IsOpened = report.IsOpened,
                    Topic = report.Topic,
                    Text = report.Text,
                    Date = report.Date
                };

                return result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                var logger = new Logger(_dataContext, e.GetType().FullName, e.Message, e.StackTrace);
                await logger.LogError();
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
                var result = await _dataContext.Reports.Where(report => report.UserId.Equals(userId))
                    .Include(d => d.User)
                    .Select(report => new ReportOutput
                    {
                        ReportId = report.ReportId,
                        UserId = report.UserId,
                        UserName = report.User.Name,
                        IsOpened = report.IsOpened,
                        Topic = report.Topic,
                        Text = report.Text,
                        Date = report.Date
                    })
                    .ToListAsync();

                return result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                var logger = new Logger(_dataContext, e.GetType().FullName, e.Message, e.StackTrace);
                await logger.LogError();
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
                var result = await _dataContext.Reports.Where(report => report.IsOpened == true)
                    .Include(d => d.User)
                    .Select(report => new ReportOutput
                    {
                        ReportId = report.ReportId,
                        UserId = report.UserId,
                        UserName = report.User.Name,
                        IsOpened = report.IsOpened,
                        Topic = report.Topic,
                        Text = report.Text,
                        Date = report.Date
                    })
                    .ToListAsync();

                return result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                var logger = new Logger(_dataContext, e.GetType().FullName, e.Message, e.StackTrace);
                await logger.LogError();
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
                var result = await _dataContext.Reports.Where(report => report.IsOpened == false)
                    .Include(d => d.User)
                    .Select(report => new ReportOutput
                    {
                        ReportId = report.ReportId,
                        UserId = report.UserId,
                        UserName = report.User.Name,
                        IsOpened = report.IsOpened,
                        Topic = report.Topic,
                        Text = report.Text,
                        Date = report.Date
                    })
                    .ToListAsync();

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                var logger = new Logger(_dataContext, e.GetType().FullName, e.Message, e.StackTrace);
                await logger.LogError();
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
                var result = await _dataContext.Reports.Where(report => report.Date >= startOfPeriod && report.Date <= endOfPeriod)
                .Include(d => d.User)
                .Select(report => new ReportOutput
                {
                    ReportId = report.ReportId,
                    UserId = report.UserId,
                    UserName = report.User.Name,
                    IsOpened = report.IsOpened,
                    Topic = report.Topic,
                    Text = report.Text,
                    Date = report.Date
                })
                .ToListAsync();

                return result;
            } 
            catch(Exception e)
            {
                Console.WriteLine(e);
                var logger = new Logger(_dataContext, e.GetType().FullName, e.Message, e.StackTrace);
                await logger.LogError();
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
                Guid guid = Guid.NewGuid();

                ReportEntity report = new()
                {
                    ReportId = guid,
                    UserId = userId,
                    IsOpened = true,
                    Topic = topic,
                    Text = text,
                    Date = DateTime.Now
                };

                await _dataContext.Reports.AddAsync(report);
                await _dataContext.SaveAllChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                var logger = new Logger(_dataContext, e.GetType().FullName, e.Message, e.StackTrace);
                await logger.LogError();
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
                var report = await GetReportById(reportId);

                if (report.IsOpened == false)
                {
                    throw new ArgumentException("Your report is already closed");
                }

                report.IsOpened = false;

                await _dataContext.SaveAllChangesAsync();

                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                var logger = new Logger(_dataContext, e.GetType().FullName, e.Message, e.StackTrace);
                await logger.LogError();
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
                var report = await GetReportById(reportId);

                if (report.IsOpened == true)
                {
                    throw new ArgumentException("Your report is already open");
                }

                report.IsOpened = true;

                await _dataContext.SaveAllChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                var logger = new Logger(_dataContext, e.GetType().FullName, e.Message, e.StackTrace);
                await logger.LogError();
                throw;
            }
        }
        
        /// <summary>
        /// Получение обращения по идентификатору обращения.
        /// </summary>
        /// <param name="reportId"> Идентификатор обращения. </param>
        /// <returns> Обращение. </returns>
        private async Task<ReportEntity> GetReportById(Guid reportId)
        {
            var report = await _dataContext.Reports.Include(d => d.User).FirstOrDefaultAsync(report => report.ReportId.Equals(reportId));

            if (report is null)
            {
                throw new ArgumentNullException("Report with such Id is not found");
            }

            return report;
        }
    }
}
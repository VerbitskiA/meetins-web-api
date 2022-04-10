using Meetins.Abstractions.Repositories;
using Meetins.Core.Data;
using Meetins.Core.Logger;
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
        private PostgreDbContext _postgreDbContext;

        public ReportsRepository(PostgreDbContext postgreDbContext)
        {
            _postgreDbContext = postgreDbContext;
        }

        /// <summary>
        /// Получение списка всех обращений.
        /// </summary>
        /// <returns> Список всех обращений. </returns>
        public async Task<IEnumerable<ReportOutput>> GetAllReportsAsync()
        {
            try
            {
                var result = await _postgreDbContext.Reports.Include(d => d.User)
                .Select(report => new ReportOutput
                {
                    ReportId = report.ReportId,
                    UserId = report.UserId,
                    UserName = report.User.Name,
                    Status = report.Status,
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
                var logger = new Logger(_postgreDbContext, e.GetType().FullName, e.Message, e.StackTrace);
                await logger.LogError();
                throw;
            }
            
        }

        /// <summary>
        /// Получение обращения по Id.
        /// </summary>
        /// <param name="reportId"> Идентификатор обращения. </param>
        /// <returns> Обращение. </returns>
        public async Task<IEnumerable<ReportOutput>> GetReportByReportId(Guid reportId)
        {
            try
            {
                var result = await _postgreDbContext.Reports.Where(report => report.ReportId.Equals(reportId))
                    .Include(d => d.User)
                    .Select(report => new ReportOutput
                    {
                        ReportId = report.ReportId,
                        UserId = report.UserId,
                        UserName = report.User.Name,
                        Status = report.Status,
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
                var logger = new Logger(_postgreDbContext, e.GetType().FullName, e.Message, e.StackTrace);
                await logger.LogError();
                throw;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetins.Abstractions.Services;
using Meetins.Models.Reports;
using Microsoft.AspNetCore.Mvc;

namespace Meetins.Contollers
{
    /// <summary>
    /// В контроллере содержится функционал для обращений.
    /// </summary>
    [Route("reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private IReportsService _reportsService;

        public ReportsController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        /// <summary>
        /// Получение списка всех обращений.
        /// </summary>
        /// <returns> Список всех обращений. </returns>
        [HttpGet]
        [Route("get-reports")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReportOutput>))]
        public async Task<ActionResult<IEnumerable<ReportOutput>>> GetAllReportsAsync()
        {
            var result = await _reportsService.GetAllReportsAsync();

            return Ok(result);
        }

        /// <summary>
        /// Получение обращения по Id.
        /// </summary>
        /// <param name="reportId"> Идентификатор обращения. </param>
        /// <returns> Обращение. </returns>
        [HttpPost]
        [Route("by-id")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReportOutput>))]
        public async Task<ActionResult<IEnumerable<ReportOutput>>> GetReportByReportId([FromBody] ReportInput reportId)
        {
            if (reportId.ReportId.Equals(Guid.Empty))
            {
                return BadRequest(new { errorText = "Incorrect request body." });
            }

            try
            {
                var result = await _reportsService.GetReportByReportId(reportId.ReportId);

                if (result.Count() == 0) 
                {
                    return BadRequest(new { errorText = "Report with this Id does not exist." });
                }

                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}

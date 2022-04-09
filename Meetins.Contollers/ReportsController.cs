using System.Collections.Generic;
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
    }
}

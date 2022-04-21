using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetins.Abstractions.Services;
using Meetins.Models.Reports;
using Microsoft.AspNetCore.Authorization;
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
            try
            {
                var result = await _reportsService.GetAllReportsAsync();

                if (result.Count() == 0)
                {
                    return NoContent();
                }

                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
            
        }

        /// <summary>
        /// Получение обращения по Id.
        /// </summary>
        /// <param name="report"> Идентификатор обращения. </param>
        /// <returns> Обращение. </returns>
        [HttpPost]
        [Route("by-id")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReportOutput>))]
        public async Task<ActionResult<ReportOutput>> GetReportByReportIdAsync([FromBody] ReportByIdInput report)
        {
            if (report.ReportId.Equals(Guid.Empty))
            {
                return BadRequest(new { errorText = "Incorrect request body." });
            }

            try
            {
                var result = await _reportsService.GetReportByReportIdAsync(report.ReportId);

                if (result is null)
                {
                    return NoContent();
                }

                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        /// <summary>
        /// Получение всех обращений от пользователя.
        /// </summary>
        /// <param name="userId"> Идентификатор пользователя. </param>
        /// <returns> Список обращений. </returns>
        [HttpPost]
        [Route("from-user")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReportOutput>))]
        public async Task<ActionResult<IEnumerable<ReportOutput>>> GetReportsByUserIdAsync([FromBody] GetReportsByUserIdInput user)
        {
            if (user.UserId.Equals(Guid.Empty))
            {
                return BadRequest(new { errorText = "Incorrect request body." });
            }
            
            try
            {
                var result = await _reportsService.GetReportsByUserIdAsync(user.UserId);

                if (result.Count() == 0)
                {
                    return NoContent();
                }

                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        /// <summary>
        /// Получение открытых обращений.
        /// </summary>
        /// <returns> Список обращений. </returns>
        [HttpGet]
        [Route("get-opened")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReportOutput>))]
        public async Task<ActionResult<IEnumerable<ReportOutput>>> GetOpenReportsAsync()
        {
            try
            {
                var result = await _reportsService.GetOpenReportsAsync();

                if (result.Count() == 0)
                {
                    return NoContent();
                }

                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        /// <summary>
        /// Получение закрытых обращений.
        /// </summary>
        /// <returns> Список обращений. </returns>
        [HttpGet]
        [Route("get-closed")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReportOutput>))]
        public async Task<ActionResult<IEnumerable<ReportOutput>>> GetClosedReportsAsync()
        {
            try
            {
                var result = await _reportsService.GetClosedReportsAsync();

                if (result.Count() == 0)
                {
                    return NoContent();
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        /// <summary>
        /// Получение списка обращений за период времени.
        /// </summary>
        /// <param name="period"> Период времени. </param>
        /// <returns> Список обращений. </returns>
        [HttpPost]
        [Route("period")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReportOutput>))]
        public async Task<ActionResult<IEnumerable<ReportOutput>>> GetReportsForPeriodAsync([FromBody] GetReportsForPeriodInput period)
        {
            if (period.Equals(Guid.Empty))
            {
                return BadRequest(new { errorText = "Incorrect request body." });
            }

            try
            {
                var result = await _reportsService.GetReportsForPeriodAsync(period.StartOfPeriod, period.EndOfPeriod);

                if (result.Count() == 0)
                {
                    return NoContent();
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        /// <summary>
        /// Создание обращения от пользователя.
        /// </summary>
        /// <param name="report"> Обращение. </param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("create-report")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReportOutput>))]
        public async Task<ActionResult<bool>> CreateReportAsync([FromBody] CreateReportInput report)
        {
            string rawUserId = HttpContext.User.FindFirst("userId").Value;

            if (!Guid.TryParse(rawUserId, out Guid userId))
            {
                return Unauthorized();
            }

            if (report.Equals(Guid.Empty))
            {
                return NoContent();
            }

            try
            {
                var result = await _reportsService.CreateReportAsync(userId, report.Topic, report.Text);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        /// <summary>
        /// Закрыть обращение.
        /// </summary>
        /// <param name="report"> Идентификатор обращения. </param>
        /// <returns> True, если обращение закрыто. </returns>
        [HttpPost]
        [Route("close")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReportOutput>))]
        public async Task<ActionResult<bool>> CloseReportAsync([FromBody] ReportByIdInput report)
        {
            if (report.ReportId.Equals(Guid.Empty))
            {
                return BadRequest(new { errorText = "Incorrect request body." });
            }

            try
            {
                var result = await _reportsService.CloseReportAsync(report.ReportId);

                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        /// <summary>
        /// Открыть обращение.
        /// </summary>
        /// <param name="report"> Идентификатор обращения. </param>
        /// <returns> True, если обращение открыто. </returns>
        [HttpPost]
        [Route("open")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReportOutput>))]
        public async Task<ActionResult<bool>> OpenReportAsync([FromBody] ReportByIdInput report)
        {
            if (report.ReportId.Equals(Guid.Empty))
            {
                return BadRequest(new { errorText = "Incorrect request body." });
            }

            try
            {
                var result = await _reportsService.OpenReportAsync(report.ReportId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}

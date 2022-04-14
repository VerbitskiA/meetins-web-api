using Meetins.Abstractions.Services;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace Meetins.Bot
{
    public class StartController : BotController
    {
        readonly ILogger<StartController> _logger;
        private ICommonService _commonService;
        private IConfiguration _configuration;

        public StartController(ILogger<StartController> logger, ICommonService commonService, IConfiguration configuration)
        {
            _logger = logger;
            _commonService = commonService;
            _configuration = configuration;
        }

        [Action("Start")]
        [Action("/start", "start the bot")]
        public async Task Start()
        {
            KButton("Зарегистрированные пользователи за последние сутки");
            PushL("Приветствующее сообщение");
        }

        [Action("Зарегистрированные пользователи за последние сутки")]
        public async Task Stat()
        {
            await Client.SendTextMessageAsync(
                chatId: _configuration.GetValue<string>("groupId"),
                text: $"Число зарегистрированных пользователей за последние сутки: {await _commonService.GetRegistrationsForLast24HoursAsync()}");

            PushL("Данные отправлены в канал");
        }










        #region Errors

        [On(Handle.Unknown)]
        public async Task Unknown()
        {
            PushL("unknown");
            await Send();
        }

        [On(Handle.Exception)]
        public async Task Ex(Exception e)
        {
            _logger.LogCritical(e, e.Message);

            if (Context.Update.Type == UpdateType.CallbackQuery)
            {
                await AnswerCallback("Error");
            }
            else if (Context.Update.Type == UpdateType.Message)
            {
                Push("Error");
            }
        }

        [On(Handle.ChainTimeout)]
        public async Task ChainTimeout()
        {
            PushL("timeout");
        }

        #endregion
    }

}


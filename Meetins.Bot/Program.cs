global using Deployf.Botf;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Meetins.Abstractions.Services;
using Meetins.Abstractions.Repositories;
using Meetins.Services.Common;
using Meetins.Core.Data;
using Microsoft.EntityFrameworkCore;

class Program : BotfProgram
{
    readonly ILogger<Program> _logger;
    private ICommonService _commonService;
    private IConfiguration _configuration;

    public static void Main(string[] args) => StartBot(args, onConfigure: (svc, cfg) =>
    {
        svc.AddTransient<ICommonService, CommonService>();

        svc.AddTransient<ICommonRepository, CommonRepository>();

        svc.AddDbContext<PostgreDbContext>(options =>
            options.UseNpgsql(cfg.GetConnectionString("NpgTestSqlConnection")));

        svc.AddLogging();
    });

    public Program(ILogger<Program> logger, ICommonService commonService, IConfiguration configuration)
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

    /*
     * await Send($"Hi! What is your name?");

        var name = await AwaitText(() => Send("Use /start to try again"));
        await Send($"Hi, {name}! Where are you from?");

        var place = await AwaitText();

        Button("Like");
        Button("Don't like");
        await Send($"Hi {name} from {place}! Nice to meet you!\nDo you like this place?");

        var likeStatus = await AwaitQuery();
        if (likeStatus == "Like")
        {
            await Send("I'm glad to heat it!\nSend /start to try it again.");
        }
        else
        {
            await Send("It's bad(\nSend /start to try it again.");
        }

        Start(); // вызовет метод Start
     */



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

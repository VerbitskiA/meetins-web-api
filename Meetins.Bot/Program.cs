global using Deployf.Botf;
using Telegram.Bot.Types.Enums;
using Meetins.Abstractions.Services;
using Meetins.Abstractions.Repositories;
using Meetins.Services.Common;
using Meetins.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Meetins.Bot;

class Program : BotfProgram
{
    public static void Main(string[] args) => StartBot(args, onConfigure: (svc, cfg) =>
    {
        svc.AddTransient<ICommonService, CommonService>();

        svc.AddTransient<ICommonRepository, CommonRepository>();

        svc.AddDbContext<PostgreDbContext>(options =>
            options.UseNpgsql(cfg.GetConnectionString("NpgTestSqlConnection")));

        svc.AddLogging();
    });

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

        Start(); // גûחמגוע לועמה Start
     */
}



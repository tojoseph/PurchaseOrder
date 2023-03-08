using Serilog.Core;
using Serilog.Events;

namespace PurchaseOrder.API
{
    //this is the custome sink created here for serlog to have log info in color code on a console.
    public class CustomSink : ILogEventSink
    {
        public void Emit(LogEvent logEvent)
        {
            var result = logEvent.RenderMessage();

            Console.ForegroundColor = logEvent.Level switch
            {
                LogEventLevel.Debug => ConsoleColor.Green,
                LogEventLevel.Information => ConsoleColor.Blue,
                LogEventLevel.Error => ConsoleColor.Red,
                LogEventLevel.Warning => ConsoleColor.Yellow,
                _=> ConsoleColor.White,
            };
            Console.WriteLine($"{logEvent.Timestamp} - {logEvent.Level}: {result}");
        }
    }
   
}

using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace AnalysisServer.Formatters;

public class TextPlainInputFormatter : TextInputFormatter
{
    private readonly string _separator;

    public TextPlainInputFormatter(string separator = "\n")
    {
        _separator = separator;
        SupportedMediaTypes.Add("text/plain");
        SupportedEncodings.Add(Encoding.UTF8);
    }

    protected override bool CanReadType(Type type)
    {
        return type == typeof(string)
               || typeof(IEnumerable<string>).IsAssignableFrom(type);
    }

    public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
    {
        using var reader = context.ReaderFactory(context.HttpContext.Request.Body, encoding);

        if (context.ModelType == typeof(string))
        {
            return await InputFormatterResult.SuccessAsync(reader.ReadToEndAsync());
        }
        else if (context.ModelType.IsAssignableTo(typeof(IEnumerable<string>)))
        {
            if (_separator == "\n")
            {
                var model = new List<string>();
                while (true)
                {
                    var line = await reader.ReadLineAsync();
                    if (line == null) break;
                    model.Add(line.Trim());
                }

                return await InputFormatterResult.SuccessAsync(
                    context.ModelType.IsArray ? model.ToArray() : model);
            }
            else
            {
                var model = (await reader.ReadToEndAsync()).Split(_separator);
                return await InputFormatterResult.SuccessAsync(
                    context.ModelType == typeof(List<string>) ? model.ToList() : model);
            }
        }

        return await InputFormatterResult.FailureAsync();
    }
}
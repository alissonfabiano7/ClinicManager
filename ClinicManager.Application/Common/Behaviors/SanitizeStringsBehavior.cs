using MediatR;
using System.Globalization;
using System.Reflection;
using System.Text;

public class SanitizeStringsBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        SanitizeStringProperties(request);
        return await next();
    }

    private void SanitizeStringProperties(object obj)
    {
        if (obj == null) return;

        var props = obj.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

        foreach (var prop in props)
        {
            var original = prop.GetValue(obj) as string;
            if (!string.IsNullOrWhiteSpace(original))
            {
                var sanitized = original
                    .Normalize(NormalizationForm.FormD)
                    .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    .Aggregate("", (s, c) => s + c)
                    .ToUpperInvariant();

                prop.SetValue(obj, sanitized);
            }
        }
    }
}

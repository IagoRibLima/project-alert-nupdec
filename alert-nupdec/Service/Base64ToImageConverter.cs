using System.Globalization;

namespace alert_nupdec.Service;

public class Base64ToImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string base64String && !string.IsNullOrWhiteSpace(base64String))
        {
            // 1. Converte a string Base64 de volta para bytes
            byte[] imageBytes = System.Convert.FromBase64String(base64String);

            // 2. Cria um Stream de memória
            return ImageSource.FromStream(() => new MemoryStream(imageBytes));
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Não é necessário converter de volta para este cenário
        throw new NotImplementedException();
    }    
}
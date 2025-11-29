namespace alert_nupdec.Service
{
    internal class ImageService
    {
        public async Task<string?> SelecionarFotoAsync()
        {
            try
            {
                FileResult photo = await MediaPicker.PickPhotoAsync();

                if (photo == null)
                    return null;

                using Stream stream = await photo.OpenReadAsync();
                using MemoryStream memoryStream = new();
                await stream.CopyToAsync(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();

                // Aqui usamos System.Convert explicitamente para garantir
                return System.Convert.ToBase64String(imageBytes);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

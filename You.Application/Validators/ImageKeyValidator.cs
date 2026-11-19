namespace You.Application.Validators;
    
public static class ImageKeyValidator
{
    public static void Validate(string? imageKey)
    {
        if (string.IsNullOrWhiteSpace(imageKey))
        {
            return;
        }

        if (imageKey.Length > 255)
        {
            throw new ArgumentException("Image key cannot exceed 255 characters.", nameof(imageKey));
        }

        if (imageKey.Contains(".."))
        {
            throw new ArgumentException("Image key contains an invalid path.", nameof(imageKey));
        }
    }
}
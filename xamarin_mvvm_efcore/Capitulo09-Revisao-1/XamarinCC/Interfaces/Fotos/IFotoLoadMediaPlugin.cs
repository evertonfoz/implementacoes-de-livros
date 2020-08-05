namespace Interfaces.Fotos
{
    public interface IFotoLoadMediaPlugin
    {
        string SetPathToPhoto(string caminhoCompleto);
        string GetDevicePathToPhoto();
        string GetPathToPhoto(string caminhoArmazenado);
    }
}

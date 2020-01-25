namespace Interfaces.Fotos
{
    public interface IFotoLoadMediaPlugin
    {
        string GetPathToPhoto(string caminhoArmazenado);
        string SetPathToPhoto(string caminhoCompleto);
        string GetDevicePathToPhoto();
    }
}

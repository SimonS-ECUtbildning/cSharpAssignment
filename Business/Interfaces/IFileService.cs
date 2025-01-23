namespace Business.Interfaces;

public interface IFileService
{
    public bool SaveContentToFile(string content);
    public string GetContentFromFile();
}
namespace MySharedLib.Interfaces
{
    public interface IFileService
    {
        bool Save<T>(int? id, T data);
        bool Delete<T>(int? id, T data);
        T? Find<T>(int? id, T data);
        int GetNextId<T>(T data);
    }
}

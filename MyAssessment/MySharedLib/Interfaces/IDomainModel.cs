namespace MySharedLib.Interfaces
{
    public interface IDomainModel
    {
        int? Id { get; }
        void Save();
        void Delete();

        T? Find<T>(int? id, T data);
    }
}

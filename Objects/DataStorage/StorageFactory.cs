using Interfaces.DataStorage;

namespace Objects.DataStorage
{
    public enum StorageType
    {
        Database,
        File
    }
    public static class StorageFactory
    {
        public static IStorage GetStorage(StorageType storageType)
        {
            switch (storageType) 
            {
                case StorageType.Database:
                    return new DatabaseStorage();
                case StorageType.File:
                    return new FileStorage();
                default:
                    throw new ArgumentException("Invalid storage type");
            }
        }
    }
}

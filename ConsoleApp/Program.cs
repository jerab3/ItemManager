using Autofac;
using Newtonsoft.Json.Linq;
using Interfaces.DataStorage;
using Domains.Locations;
using Interfaces.Location;
using System.Security.Cryptography.X509Certificates;
using Domains.Accessories;
using System.Runtime.CompilerServices;

namespace ConsoleApp
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            SetupContainer();

            using (var scope = Container.BeginLifetimeScope())
            {
                var dataStorage = scope.Resolve<IDataStorage>();


                dataStorage.LoadData();

                var newStorage = new StorageLocation("Box");
                dataStorage.AddData(newStorage);

                foreach (StorageLocation storage in dataStorage.StorageLocations)
                {
                    Console.WriteLine(storage.Name);
                }

                Console.ReadLine();
            }
        }
        private static void SetupContainer()
        {
            var builder = new ContainerBuilder();

            var config = JObject.Parse(File.ReadAllText("config.json"));
            string dataStorageTypeName = config["DataStorageType"].ToString();
            Type dataStorageType = Type.GetType(dataStorageTypeName);
            
            if (dataStorageType == null)
            {
                throw new InvalidOperationException($"Type {dataStorageTypeName} was not found.");
            }

            builder.RegisterType(dataStorageType).As<IDataStorage>();

            Container = builder.Build();

            
        }
    }
}

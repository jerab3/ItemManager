using Autofac;
using Newtonsoft.Json.Linq;
using Interfaces.DataStorage;

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

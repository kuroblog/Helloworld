
namespace K.MEF.Basic
{
    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Registration;

    class Program
    {
        static void Main(string[] args)
        {
            FluentExportInterfaceDemo();
        }

        private static void FluentExportInterfaceDemo()
        {
            Program program = new Program();
            var picker = new RegistrationBuilder();
            picker.ForTypesMatching(pl => pl.Name.EndsWith("Plugin"))
               .ExportInterfaces();

            var catalog = new AssemblyCatalog(typeof(Program).Assembly, picker);

            var container = new CompositionContainer(catalog);
            container.ComposeParts(program);

            var log = container.GetExportedValue<ILogPlugin>();
            var save = container.GetExportedValue<ISavePlugin>();

            save.Save("test");
            log.Write("test");
        }
    }

    public class GreatEditor
    {
        public ILogPlugin Logger { get; set; }
        public ISavePlugin Saver { get; set; }
    }


    public interface ILogPlugin
    {
        void Write(string message);
    }

    public class LoggerPlugin : ILogPlugin
    {
        public void Write(string message)
        {
            Console.WriteLine("Logger {0}", message);
        }
    }

    public interface ISavePlugin
    {
        void Save(string message);
    }

    public class FilePlugin : ISavePlugin
    {
        public void Save(string message)
        {
            Console.WriteLine("FilePlugin {0}", message);

        }
    }
}

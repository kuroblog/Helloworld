
namespace K.MEF.Basic
{
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;

    class Program
    {
        static void Main(string[] args)
        {
            var app = new ApplicationRoot();
            app.Run();
        }
    }

    class ApplicationRoot
    {
        private void Compose()
        {
            var compositionContainer = new CompositionContainer();
            compositionContainer.ComposeParts(this);
        }

        public void Run()
        {
            Compose();
        }
    }
}

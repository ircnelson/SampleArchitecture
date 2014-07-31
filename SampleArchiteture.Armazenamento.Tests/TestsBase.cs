using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleArchiteture.Armazenamento.Tests
{
    public abstract class TestsBase
    {
        protected IContainer Container;

        public TestsBase()
        {
            Init();
        }

        private void Init()
        {
            Container = SetupTest.Container;

            OnInit();
        }

        protected abstract void OnInit();
    }
}
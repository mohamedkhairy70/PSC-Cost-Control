using NUnit.Framework;
using PSC_Cost_Control.Services.ProjectCodesServices;
using PSC_Cost_Control.Services.UnifiedCodesServices;
using PSC_Cost_Control.Services.ServicesBuilders;
using PSC_Cost_Control.Services.ProjectCodeItemRegisterationServices;

namespace UnitTestProject1.Services.ServicesBuilder
{
    [TestFixture]
    public class ServiceBuilderUnitTestings
    {
        [Test]
        public void Build_TIsIprojectCodeService_ReturnsProjecCodeServicObject()
        {
            var o = ServiceBuilder.Build<IProjectCodeService>();
            Assert.That(o, Is.InstanceOf<IProjectCodeService>());
        }
        [Test]
        public void Build_TIsIprojectCodeCategoryService_ReturnsProjecCodeCategoryServicObject()
        {
            var o = ServiceBuilder.Build<IProjectCodeCategoryService>();
            Assert.That(o, Is.InstanceOf<IProjectCodeCategoryService>());
        }
        [Test]
        public void Build_TIsIUnifiedCodeService_ReturnsIUnifiedCodeServiceObject()
        {
            var o = ServiceBuilder.Build<IUnifiedCodeService>();
            Assert.That(o, Is.InstanceOf<IUnifiedCodeService>());
        }
        [Test]
        public void Build_TIsIUnifiedCodeCategoryService_ReturnsIUnifiedCodeCategoryServiceObject()
        {
            var o = ServiceBuilder.Build<IUnifiedCodeCategoryService>();
            Assert.That(o, Is.InstanceOf<IUnifiedCodeCategoryService>());
        }
        [Test]
        public void Build_TIsIRegisterationService_ReturnsIRegisterationService()
        {
            var o = ServiceBuilder.Build<IRegisterationService>();
            Assert.That(o, Is.InstanceOf<IRegisterationService>());
        }
    }
}

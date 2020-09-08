using Flunt.Notifications;
using NUnit.Framework;
using Valhalla.Modules.Domain.ValueObjects;

namespace Valhalla.Tests.UnitTesting.ValueObjectsTests
{
    public class NameVoTests : Notifiable
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NameVoTests_State_IsValid()
        {
            var name = new NameVo("RAY", "CARNEIRO");

            name.Validate();

            Assert.AreEqual(true, name.Valid);
        }

        [Test]
        public void NameVoTests_State_IsInvalid()
        {
            var name = new NameVo("R", "CARNEIRO");

            name.Validate();

            Assert.AreEqual(true, name.Invalid);
        }
    }
}

using NUnit.Framework;
using PSC_Cost_Control.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1.HelpersUnitTestings
{
    [TestFixture]
    public class GuidIntGenratorUnitTestings
    {
        [Test]
        public void Guid_NoBlockedAdderAndThisFistCallingInObject_Return1()
        {
            var generator = new GuidIntGenerator();
            var guid = generator.Guid();
            Assert.That(guid, Is.EqualTo(1));
        }

        [Test]
        public void Guid_AddingBlockFor1_TheNewGuidIsNot1()
        {
            var generator = new GuidIntGenerator();
            generator.Block(1);
            var guid = generator.Guid();
            Assert.That(guid, Is.EqualTo(2));
        }

        [Test]
        public void Guid_AddingBlockFor1AndTwo_TheNewGuidMustNotEquals1nor2()
        {
            var generator = new GuidIntGenerator();
            generator.Block(1);
            generator.Block(2);
            var guid = generator.Guid();
            Assert.That(guid, Is.EqualTo(3));
        }

        [Test]
        public void Guid_GenratingTwoGuids_TheTwoGnratedGuidsIsNotEualTogethers()
        {
            var generator = new GuidIntGenerator();
            var guid1 = generator.Guid();
            var guid2 = generator.Guid();

            Assert.That(guid1, Is.Not.EqualTo(guid2));
        }

    }
}

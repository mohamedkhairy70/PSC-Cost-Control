using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Helper.FakeIDsGenerator;

namespace UnitTestProject1.HelpersUnitTestings
{
    [TestFixture]
    public class FakeIdsGeneratorUnitTestings
    {
        [Test]
        public void GenerateIDs_whenCalled_InjuctIdsToAllElemnts()
        {
            var list = new List<C_Cost_Project_Codes> { 
                new C_Cost_Project_Codes
                {
                    Description="desc1"
                },
                new C_Cost_Project_Codes
                {
                    Description="desc2"
                },
            };
            list.InjectFakeIds();

            Assert.That(list[0].Id, Is.Not.Null.Or.Zero);
            Assert.That(list[1].Id, Is.Not.Null.Or.Zero);

        }

        [Test]
        public void GenerateIDs_whenCalledWithExistingId_InjuctNewIdsToAllElemnts()
        {
            var list = new List<C_Cost_Project_Codes> {
                new C_Cost_Project_Codes
                {
                    Id=3,
                    Description="desc1"
                },
            
            };
            list.InjectFakeIds();

            Assert.That(list[0].Id, Is.Not.Null.Or.Zero.Or.EqualTo(3));

        }
    }
}

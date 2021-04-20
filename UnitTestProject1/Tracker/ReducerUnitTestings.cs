using NUnit.Framework;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Trackers.Reducers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Tracker
{
    [TestFixture]
    public class ReducerUnitTestings
    {
        [Test]
        public void Reduce_InvokeWithListOfChildWithHisParent_ReturnIenumerableOfParentOnly()
        {
            var o = new Reducer<C_Cost_Project_Codes>();

            var list = new List<C_Cost_Project_Codes>
            {
                new C_Cost_Project_Codes{Code="/22/5/"},      //child
                new C_Cost_Project_Codes{Code="/22/"}         //parent
            };
            var actual = o.Reduce(list);

            Assert.That(actual.Count(), Is.EqualTo(1));

            Assert.That(actual.FirstOrDefault().Code, Is.EqualTo("/22/"));
        }

        [Test]
        public void Reduce_InvokeWithListOfOnElement_ReturnIenumerableOfTheElementOnly()
        {
            var o = new Reducer<C_Cost_Project_Codes>();

            var list = new List<C_Cost_Project_Codes>
            {
                new C_Cost_Project_Codes{Code="/22/5555/5511/"},
            };
            var actual = o.Reduce(list);

            Assert.That(actual.Count(), Is.EqualTo(1));

            Assert.That(actual.FirstOrDefault().Code, Is.EqualTo("/22/5555/5511/"));
        }

        [Test]
        public void Reduce_InvokeWithEmptyList_ReturnEmptyIEnumerable()
        {
            var o = new Reducer<C_Cost_Project_Codes>();

            var list = new List<C_Cost_Project_Codes>
            {
                //empty
            };
            var actual = o.Reduce(list);

            Assert.That(actual.Count(), Is.EqualTo(0));
        }


    }
}

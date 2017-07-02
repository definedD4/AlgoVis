using System;
using AlgoVis.AlgorithmConstruction;
using AlgoVis.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoVis.Tests.AlgorithmConstruction
{
    [TestClass]
    public class MethodActionTest
    {
        class TestAlgorithmBase : AlgorithmBase
        {
            public bool Executed { get; private set; } = false;
            public int Param { get; private set; }

            public void Execute(int x)
            {
                Executed = true;
                Param = x;
            }

            public override object Display => null;
        }

        [TestMethod]
        public void ExecutesGivenMethodWithParam()
        {
            var algoBase = new TestAlgorithmBase();
            var action = new MethodAction("TestAction", "TestActionDescription", new []
            {
                new ActionParameter("TestParam", typeof(int))
            }, algoBase,
            algoBase.GetType().GetMethod("Execute"));

            action.Execute(new[] {(object) 42});

            Assert.IsTrue(algoBase.Executed);
            Assert.AreEqual(42, algoBase.Param);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AlgoVis.AlgorithmConstruction;
using AlgoVis.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoVis.Tests.AlgorithmConstruction
{
    [TestClass]
    public class AlgoritmBuilderTest
    {
        [Algorithm("TestAlgorithm", Description = "TestAlgorithmDescription")]
        public class TestAlgorithm : AlgorithmBase
        {
            public bool NoParamsActionExecuted { get; private set; } = false;
            public bool IntActionExecuted { get; private set; } = false;
            public int IntActionParam { get; private set; }

            [Action("TestNoParamsAction", "TestNoParamsActionDescription")]
            public IEnumerable<IActionStatement> NoParamsAction()
            {
                NoParamsActionExecuted = true;
                yield return null;
            }

            [Action("TestIntAction", "TestIntActionDescription")]
            [Param("TestIntActionParam", typeof(int))]
            public IEnumerable<IActionStatement> IntAction(int x)
            {
                IntActionExecuted = true;
                IntActionParam = x;
                yield return null;
            }

            public override object Display => null;
        }

        [TestMethod]
        public void NameAndDescriptionSet()
        {
            var testAlgo = new TestAlgorithm().Build();

            Assert.AreEqual("TestAlgorithm", testAlgo.Name);
            Assert.AreEqual("TestAlgorithmDescription", testAlgo.Description);
        }

        [TestMethod]
        public void NoParamsActionNameDescriptionAndParametersSet()
        {
            var testAlgo = new TestAlgorithm().Build();

            var noParamsAction = testAlgo.Actions.FirstOrDefault(act => act.Name == "TestNoParamsAction");

            Assert.IsNotNull(noParamsAction);
            Assert.AreEqual("TestNoParamsAction", noParamsAction.Name);
            Assert.AreEqual("TestNoParamsActionDescription", noParamsAction.Description);
            Assert.IsTrue(!noParamsAction.Parameters.Any());
        }

        [TestMethod]
        public void IntActionNameDescriptionAndParametersSet()
        {
            var testAlgo = new TestAlgorithm().Build();

            var intAction = testAlgo.Actions.FirstOrDefault(act => act.Name == "TestIntAction");

            Assert.IsNotNull(intAction);
            Assert.AreEqual("TestIntAction", intAction.Name);
            Assert.AreEqual("TestIntActionDescription", intAction.Description);
            Assert.IsTrue(intAction.Parameters.Count() == 1);

            var param = intAction.Parameters.FirstOrDefault();

            Assert.IsNotNull(param);
            Assert.AreEqual("TestIntActionParam", param.Name);
            Assert.AreEqual(typeof(int), param.Type);
        }

        [TestMethod]
        public void ExecuteNoParamsAction()
        {
            var algo = new TestAlgorithm();
            var testAlgo = algo.Build();

            Assert.IsFalse(algo.NoParamsActionExecuted);

            var statements = testAlgo.Actions.FirstOrDefault(act => act.Name == "TestNoParamsAction")
                .Execute(new object[] { }).ToArray();

            Assert.IsTrue(algo.NoParamsActionExecuted);
        }

        [TestMethod]
        public void ExecuteIntAction()
        {
            var algo = new TestAlgorithm();
            var testAlgo = algo.Build();

            Assert.IsFalse(algo.IntActionExecuted);

            var statements = testAlgo.Actions.FirstOrDefault(act => act.Name == "TestIntAction")
                .Execute(new object[] { (object)42 }).ToArray();

            Assert.IsTrue(algo.IntActionExecuted);
            Assert.AreEqual(42, algo.IntActionParam);
        }
    }
}

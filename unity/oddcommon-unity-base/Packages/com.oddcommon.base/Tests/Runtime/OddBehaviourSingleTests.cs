using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace OddCommon.Tests
{
    public class OddBehaviourSingleTests
    {
        [UnityTest]
        public IEnumerator RuntimeExistenceTest()
        {
            GameObject testGameObjectOne =
                new GameObject
                (
                    "Test GameObject with OddBehaviourSingleTest",
                    typeof(OddBehaviourSingleTest)
                );
            yield return null;
            GameObject testGameObjectTwo =
                new GameObject
                (
                    "Test GameObject without OddBehaviourSingleTest",
                    typeof(OddBehaviourSingleTest)
                );
            yield return null;
            OddBehaviourSingleTest testOddBehaviourSingleOne =
                testGameObjectOne.GetComponent<OddBehaviourSingleTest>();
            OddBehaviourSingleTest testOddBehaviourSingleTwo =
                testGameObjectTwo.GetComponent<OddBehaviourSingleTest>();
            Assert.IsTrue((testOddBehaviourSingleOne != null) && (testOddBehaviourSingleTwo == null));
        }

        private class OddBehaviourSingleTest : OddBehaviourSingle<OddBehaviourSingleTest>, IMonoBehaviourTest
        {
            public bool IsTestFinished => true;
        }
    }
}

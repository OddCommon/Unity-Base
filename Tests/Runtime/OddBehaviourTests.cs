using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;


namespace OddCommon.Tests
{
    public class OddBehaviourTests
    {
        /*
         * Currently OddBehaviour has no fields or methods,
         * so there is nothing to test hence EmptyTest.
         */
        [UnityTest]
        public IEnumerator EmptyTest()
        {
            yield return null;
            Assert.Pass();
        }
    }
}

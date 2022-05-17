using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;


namespace OddCommon.Tests
{
    public class OddScriptableObjectTests
    {
        /*
         * Currently OddScriptableObject has no fields or methods,
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

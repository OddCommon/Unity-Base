using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace OddCommon.Tests
{
    public class OddScriptableObjectSingleTests
    {
        [UnityTest]
        public IEnumerator RuntimeExistenceTest()
        {
            OddScriptableObjectSingleTest testScriptableObjectOne =
                ScriptableObject.CreateInstance<OddScriptableObjectSingleTest>();
            yield return null;
            OddScriptableObjectSingleTest testScriptableObjectTwo =
                ScriptableObject.CreateInstance<OddScriptableObjectSingleTest>();
            yield return null;
            Assert.IsTrue((testScriptableObjectOne != null) && (testScriptableObjectTwo == null));
        }

        private class OddScriptableObjectSingleTest : OddScriptableObjectSingle<OddScriptableObjectSingleTest>
        {
            
        }
    }
}

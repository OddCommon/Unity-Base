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
            Assert.IsTrue(!testScriptableObjectOne.isBeingDestroyed && (testScriptableObjectTwo == null || testScriptableObjectTwo.isBeingDestroyed));
        }

        private class OddScriptableObjectSingleTest : OddScriptableObject<OddScriptableObjectSingleTest>
        {
            #region Methods
            #region Unity Messages
            protected override void Awake()
            {
                this.onlyAllowSingleRuntimeInstance = true;
                base.Awake();
            }
            #endregion //Unity Messages
            #endregion //Methods
        }
    }
}

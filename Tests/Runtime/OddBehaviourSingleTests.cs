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

        private class OddBehaviourSingleTest : OddBehaviour<OddBehaviourSingleTest>, IMonoBehaviourTest
        {
            #region Fields
            #region Public
            public bool IsTestFinished => true;
            #endregion //Public
            #endregion //Fields

            #region Methods
            #region Unity Messages
            protected override void Awake()
            {
                this.onlyAllowSingleInstance = true;
                base.Awake();
            }
            #endregion //Unity Messages
            #endregion //Methods
        }
    }
}

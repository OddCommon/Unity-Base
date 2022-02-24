using System.Collections;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace OddCommon.Editor.Tests
{
    public class ScriptOrderPreprocessorTests
    {
        [UnityTest]
        public IEnumerator RuntimeMonoScriptOrderTest()
        {
            GameObject testGameObject = 
                new GameObject("TestGameObject", typeof(ScriptOrderPreprocessorTestBehaviour));
            yield return null;
            ScriptOrderPreprocessorTestBehaviour testBehaviour = 
                testGameObject.GetComponent<ScriptOrderPreprocessorTestBehaviour>();
            if (testBehaviour != null)
            {
                ScriptOrderAttribute scriptOrderAttribute = 
                    testBehaviour.GetType().GetCustomAttribute<ScriptOrderAttribute>();
                if (scriptOrderAttribute != null)
                {
                    int scriptOrder = testBehaviour.GetType().GetCustomAttribute<ScriptOrderAttribute>().Order;
                    if (scriptOrder == 20170912)
                    {
                        Assert.Pass();
                    }
                    else
                    {
                        Assert.Fail();
                    }     
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                Assert.Fail();
            }
        }

        [ScriptOrder(20170912)]
        private class ScriptOrderPreprocessorTestBehaviour : MonoBehaviour, IMonoBehaviourTest
        {
            public bool IsTestFinished => true;
        }
    }
}

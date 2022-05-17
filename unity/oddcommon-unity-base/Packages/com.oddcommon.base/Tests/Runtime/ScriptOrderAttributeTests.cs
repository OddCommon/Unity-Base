using System;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using Assembly = System.Reflection.Assembly;
using Type = System.Type;


namespace OddCommon.Tests
{
    public class ScriptOrderAttributeTests
    {
        [Test]
        public void EditorOrderInAssemblyTest()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                if (this.GetType().Assembly.Equals(assembly))
                {
                    Type[] assemblyTypes = assembly.GetTypes();
                    foreach (Type type in assemblyTypes)
                    {
                        if (typeof(ScriptOrderAttributeTestBehaviour) == type)
                        {
                            ScriptOrderAttribute scriptOrderAttribute = type.GetCustomAttribute<ScriptOrderAttribute>();
                            if (scriptOrderAttribute != null)
                            {
                                int scriptOrder = scriptOrderAttribute.Order;
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
                    }
                    Assert.Fail();
                }
            }
            Assert.Fail();
        }
        
        [ScriptOrder(20170912)]
        private class ScriptOrderAttributeTestBehaviour : MonoBehaviour, IMonoBehaviourTest
        {
            public bool IsTestFinished => true;
        }
    }
}

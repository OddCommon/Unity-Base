using System;
using UnityEditor;
using UnityEditor.Callbacks;
using OddCommon.Debug;


namespace OddCommon.Editor
{
    public class ScriptOrderPreprocessor
    {
        #region Class
        #region Methods
        [DidReloadScripts]
        public static void PreprocessScriptOrder()
        {
            foreach (MonoScript monoScript in MonoImporter.GetAllRuntimeMonoScripts())
            {
                if (monoScript.GetClass() != null)
                {
                    Attribute[] classAttributes =
                        Attribute.GetCustomAttributes(monoScript.GetClass(), typeof(ScriptOrderAttribute));
                    foreach (Attribute attribute in classAttributes)
                    {
                        int customScriptOrder = ((ScriptOrderAttribute)attribute).Order;
                        int currentScriptOrder = MonoImporter.GetExecutionOrder(monoScript);
                        if (currentScriptOrder != customScriptOrder)
                        {
                            Logging.Log
                            (
                                "[{0}] Changing script order of {1} from {2} to {3}",
                                typeof(ScriptOrderPreprocessor).FullName,
                                monoScript.name,
                                currentScriptOrder.ToString(),
                                customScriptOrder.ToString()
                            );
                            MonoImporter.SetExecutionOrder(monoScript, customScriptOrder);
                        }
                    }
                }
            }
        }
        #endregion //Methods
        #endregion //Class
    }
}
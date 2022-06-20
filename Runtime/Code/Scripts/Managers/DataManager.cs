using System;
using OddCommon;
using OddCommon.Debug;
using UnityEngine;


[DefaultExecutionOrder(Int32.MinValue)]
public class DataManager<T1> : OddBehaviour<DataManager<T1>>, IRuntimeDataInjector where T1 : OddScriptableObject<T1>
{
    #region Fields
    #region Inspector
    [SerializeField] private OddScriptableObject<T1> runtimeData;
    #endregion //Inspector
    #endregion //Fields
    
    #region Methods
    #region IRuntimeDataInjector
    public T2 GetData<T2>() where T2 : OddScriptableObject<T2>
    {
        if (typeof(T2) == typeof(T1))
        {
            bool findRuntimeData = this.runtimeData == null || this.runtimeData.isBeingDestroyed;
            if (findRuntimeData)
            {
                T2[] runtimeDataCandidates = Resources.FindObjectsOfTypeAll<T2>();
                foreach (T2 potentialRuntimeData in runtimeDataCandidates)
                {
                    if (!potentialRuntimeData.isBeingDestroyed)
                    {
                        this.runtimeData = potentialRuntimeData as OddScriptableObject<T1>;
                        break;
                    }
                }
            }
            return this.runtimeData as T2;   
        }
        else
        {
            Logging.Warn("[{0}] Type of GetData<T> does not match underlying typf of DataManager<T>.runtimeData.", this.name);
            return null;
        }
    }
    #endregion //IRuntimeDataInjector
    #endregion //Methods
}

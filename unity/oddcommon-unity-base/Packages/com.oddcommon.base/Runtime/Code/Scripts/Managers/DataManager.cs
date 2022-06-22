using System;
using OddCommon;
using OddCommon.Debug;
using UnityEngine;
using UnityEngine.Assertions;


[DefaultExecutionOrder(Int32.MinValue)]
public class DataManager : OddBehaviour<DataManager>
{
    #region Fields
    #region Inspector
    [SerializeField] private OddScriptableObject runtimeData;
    #endregion //Inspector
    #endregion //Fields
    
    #region Methods
    #region Public
    public T GetData<T>() where T : OddScriptableObject<T>
    {
        T castRuntimeData = null;
        if (this.runtimeData != null)
        {
            castRuntimeData = this.runtimeData as T;
        }
        if (castRuntimeData == null || castRuntimeData.isBeingDestroyed)
        {
            T[] runtimeDataCandidates = Resources.FindObjectsOfTypeAll<T>();
            foreach (T potentialRuntimeData in runtimeDataCandidates)
            {
                if (!potentialRuntimeData.isBeingDestroyed)
                {
                    this.runtimeData = potentialRuntimeData;
                    castRuntimeData = potentialRuntimeData;
                    break;
                }
            }
        }
        return castRuntimeData;
    }
    #endregion //Public
    #endregion //Methods
}

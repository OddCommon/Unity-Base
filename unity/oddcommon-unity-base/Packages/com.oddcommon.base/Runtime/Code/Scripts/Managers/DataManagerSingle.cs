using System;
using OddCommon;
using UnityEngine;


[DefaultExecutionOrder(Int32.MinValue)]
public class DataManagerSingle : OddBehaviourSingle<DataManagerSingle>
{
    #region Fields
    #region Inspector
    [SerializeField] private OddScriptableObject runtimeData;
    #endregion //Inspector
    #endregion //Fields
    
    #region Methods
    #region Public
    public T GetData<T>() where T : OddScriptableObjectSingle<T>
    {
        bool findRuntimeData = this.runtimeData == null || ((T)this.runtimeData).isBeingDestroyed;
        if (findRuntimeData)
        {
            T[] runtimeDataCandidates = Resources.FindObjectsOfTypeAll<T>();
            foreach (T potentialRuntimeData in runtimeDataCandidates)
            {
                if (!potentialRuntimeData.isBeingDestroyed)
                {
                    this.runtimeData = potentialRuntimeData;
                    break;
                }
            }
        }
        return this.runtimeData as T;
    }
    #endregion //Public
    #endregion //Methods
}

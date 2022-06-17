using System;
using OddCommon;
using UnityEngine;


[ScriptOrder(Int32.MinValue)]
public class DataManager : OddBehaviourSingle<DataManager>
{
    #region Fields
    #region Inspector
    [SerializeField] private OddScriptableObject runtimeData;
    #endregion //Inspector
    #endregion //Fields
    
    #region Methods
    #region Public
    public T GetData<T>() where T : OddScriptableObject
    {
        if (this.runtimeData == null)
        {
            OddScriptableObjectSingle<T>[] runtimeDataCandidates = GameObject.FindObjectsOfType<OddScriptableObjectSingle<T>>();
            foreach (OddScriptableObjectSingle<T> potentialRuntimeData in runtimeDataCandidates)
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

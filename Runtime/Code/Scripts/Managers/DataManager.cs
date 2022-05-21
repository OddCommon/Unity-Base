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
        return this.runtimeData as T;
    }
    #endregion //Public
    #endregion //Methods
}

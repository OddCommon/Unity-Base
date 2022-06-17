using System;
using OddCommon;
using UnityEngine;


[ScriptOrder(Int32.MinValue)]
public class DataManager<T> : OddBehaviourSingle<DataManager<T>> where T : OddScriptableObjectSingle<T>
{
    #region Fields
    #region Inspector
    [SerializeField] private T runtimeData;
    #endregion //Inspector
    #endregion //Fields
    
    #region Methods
    #region Unity Messages
    protected override void Awake()
    {
        base.Awake();
        if (this.runtimeData == null)
        {
            T runtimeDataCandidate = GameObject.FindObjectOfType<T>();
            this.runtimeData =
                    runtimeDataCandidate != null && !runtimeDataCandidate.isBeingDestroyed ? 
                    runtimeDataCandidate :
                    null;
        }
    }
    #endregion //Unity Messages
    
    #region Public
    public T GetData()
    {
        return this.runtimeData;
    }
    #endregion //Public
    #endregion //Methods
}

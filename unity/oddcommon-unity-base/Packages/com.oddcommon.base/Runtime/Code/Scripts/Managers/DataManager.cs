using OddCommon;
using UnityEngine;

public class DataManager : OddBehaviourSingle<DataManager>
{
    #region Fields
    #region Inspector
    [SerializeField] private ScriptableObject runtimeData;
    #endregion //Inspector
    #endregion //Fields
    
    #region Methods
    #region Public
    public T GetData<T>() where T : ScriptableObject
    {
        return this.runtimeData as T;
    }
    #endregion //Public
    #endregion //Methods
}

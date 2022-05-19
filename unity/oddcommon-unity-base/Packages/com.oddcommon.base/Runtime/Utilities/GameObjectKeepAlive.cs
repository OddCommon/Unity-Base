using System.Collections.Generic;
using OddCommon.Debug;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;


namespace OddCommon
{
    public class GameObjectKeepAlive : OddBehaviour
    {
        #region Instance
        #region Methods
        #region Unity Messages
        protected virtual void Awake()
        {
            Object.DontDestroyOnLoad(this.gameObject);
            Logging.Log
            (
                "[{0}] Setting as persistent through scene loads/unloads.",
                typeof(GameObjectKeepAlive).FullName
            );
        }
        #endregion //Unity Messages
        #endregion //Methods
        #endregion //Instance
    }   
}
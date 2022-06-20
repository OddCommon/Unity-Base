using OddCommon.Debug;

using Object = UnityEngine.Object;


namespace OddCommon
{
    public class GameObjectKeepAlive : OddBehaviour<GameObjectKeepAlive>
    {
        #region Instance
        #region Methods
        #region Unity Messages
        protected override void Awake()
        {
            base.Awake();
            this.onlyAllowSingleInstance = false;
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
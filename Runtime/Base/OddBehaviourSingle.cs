using UnityEngine;
using OddCommon.Debug;


namespace OddCommon
{
    /*  
        This single class only insures that there is one object of this component/type
        during runtime. It creates an instance if none exists. Note that this is NOT
        a singleton, as there is no getInstance style getter, and because it is generic,
        inheritance is not a problem.
    */
    public class OddBehaviourSingle<T> : OddBehaviour where T : OddBehaviour
    {
        #region Class
        #region Fields
        #region Private
        protected static T instance;
        #endregion //Private
        #endregion //Fields
        #endregion //Class

        #region Instance
        #region Fields
        [Header("OddBehaviourSingle")] 
        [SerializeField] private bool destroyGameObject = false;
        #endregion //Fields
        
        #region Methods
        #region Unity Messages
        protected virtual void Awake()
        {
            string fullName = typeof(T).FullName;
            if (OddBehaviourSingle<T>.instance == null)
            {
                // First instance of this OddBehaviourSingle, so we set ourselves as the protected instance
                OddBehaviourSingle<T>.instance = this as T;
                Logging.Log("[{0}] Setting first instance as single instance.", fullName);
            }
            else
            {
                // Instance already exists, destroy self
                #if UNITY_EDITOR
                if (Application.isEditor && !Application.isPlaying)
                {
                    GameObject.DestroyImmediate(this.destroyGameObject ? this.gameObject as Object : this as Object);
                }
                else
                {
                    GameObject.Destroy(this.destroyGameObject ? this.gameObject as Object : this as Object);
                }
                #else
                GameObject.Destroy(this.destroyGameObject ? this.gameObject as Object : this as Object);
                #endif
                Logging.Warn("[{0}] Instance already exists; destroying self.", fullName);
            }
        }

        protected virtual void OnDestroy()
        {
            if (OddBehaviourSingle<T>.instance == this as T)
            {
                OddBehaviourSingle<T>.instance = null;
                string fullName = typeof(T).FullName;
                Logging.Log("[{0}] Singleton instance is being destroyed.", fullName);
            }
        }
        #endregion //Unity Messages
        #endregion //Methods
        #endregion //Instance
    }
}

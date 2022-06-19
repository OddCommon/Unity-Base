using UnityEngine;
using OddCommon.Debug;


namespace OddCommon
{
    public class OddScriptableObjectSingle<T> : OddScriptableObject where T : OddScriptableObject
    {
        #region Class
        #region Fields
        #region Private
        private static T instance;
        #endregion //Private
        #endregion //Fields
        #endregion //Class

        #region Instance
        #region Fields
        #region Public
        public bool isBeingDestroyed;
        #endregion //Public
        #endregion //Fields
        
        #region Methods
        #region Unity Messages
        protected void Awake()
        {
            string fullName = typeof(T).FullName;
            if (OddScriptableObjectSingle<T>.instance == null)
            {
                this.isBeingDestroyed = false;
                OddScriptableObjectSingle<T>.instance = this as T;
                Logging.Log("[{0}] Setting first instance as single instance.", fullName);
            }
            else
            {
                this.isBeingDestroyed = true;
                #if UNITY_EDITOR
                if (Application.isEditor && !Application.isPlaying)
                {
                    GameObject.DestroyImmediate(this);
                }
                else
                {
                    GameObject.Destroy(this);
                }
                #else
                GameObject.Destroy(this);
                #endif
                Logging.Warn("[{0}] Instance already exists; destroying self.", fullName);
            }
        }

        protected void OnDestroy()
        {
            if (OddScriptableObjectSingle<T>.instance == this as T)
            {
                OddScriptableObjectSingle<T>.instance = null;
                string fullName = typeof(T).FullName;
                Logging.Log("[{0}] Single instance being destroyed.", fullName);
            }
        }
        #endregion //Unity Messages
        #endregion //Methods
        #endregion //Instance
    }
}
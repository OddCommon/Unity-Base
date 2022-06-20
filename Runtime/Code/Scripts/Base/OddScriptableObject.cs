using System;
using OddCommon.Debug;
using UnityEngine;


namespace OddCommon
{
    [Serializable]
    public class OddScriptableObject<T> : ScriptableObject where T : OddScriptableObject<T>
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
        #region Inspector
        [Header("OddScriptableObject<TypeData")]
        [SerializeField] protected bool onlyAllowSingleRuntimeInstance = false;
        #endregion //Inspector
        
        #region Public
        [HideInInspector] public bool isBeingDestroyed;
        #endregion //Public
        #endregion //Fields
        
        #region Methods
        #region Unity Messages
        protected virtual void Awake()
        {
            if (this.onlyAllowSingleRuntimeInstance)
            {
                string className = typeof(T).FullName;
                if (OddScriptableObject<T>.instance == null)
                {
                    // First instance of this OddScriptableObject, so we set ourselves as the protected instance
                    this.isBeingDestroyed = false;
                    OddScriptableObject<T>.instance = this as T;
                    Logging.Log("[{0}] Setting first instance as single instance.", className);
                }
                else
                {
                    // Instance already exists, destroy self
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
                    Logging.Warn("[{0}] Instance already exists; destroying self.", className);
                }   
            }
        }

        protected virtual void OnDestroy()
        {
            this.isBeingDestroyed = true; //When objects are destroyed by the engine and not us
            if (this.onlyAllowSingleRuntimeInstance && OddScriptableObject<T>.instance == this as T)
            {
                OddScriptableObject<T>.instance = null;
                Logging.Log("[{0}] Single instance being destroyed.", typeof(T).FullName);
            }
        }
        #endregion //Unity Messages
        #endregion //Methods
        #endregion //Instance
    }   
}

using OddCommon.Debug;
using UnityEngine;
using UnityEngine.Assertions;


namespace OddCommon
{
    public class OddBehaviour<T> : MonoBehaviour where T : OddBehaviour<T>
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
        #region Inspector
        [Header("OddBehaviour<TypeComponent>")] 
        [SerializeField] protected bool onlyAllowSingleInstance = false;
        #endregion //Inspector
        
        #region Public
        [HideInInspector] public bool isBeingDestroyed = false;
        #endregion //Public
        #endregion //Fields
        
        #region Methods
        #region Unity Messages
        protected virtual void Awake()
        {
            if (this.onlyAllowSingleInstance)
            {
                string className = typeof(T).FullName;
                if (OddBehaviour<T>.instance == null)
                {
                    // First instance of this OddBehaviour, so we set ourselves as the protected instance
                    OddBehaviour<T>.instance = this as T;
                    Logging.Log("[{0}] Setting first instance as single instance.", className);
                }
                else
                {
                    // Instance already exists, destroy self
                    this.isBeingDestroyed = true;
                    if (Application.isEditor && !Application.isPlaying)
                    {
                        GameObject.DestroyImmediate(this as Object);
                    }
                    else
                    {
                        GameObject.Destroy(this as Object);
                    }
                    Logging.Warn("[{0}] Instance already exists; destroying self.", className);
                }
            }
        }

        protected virtual void OnDestroy()
        {
            this.isBeingDestroyed = true; //When objects are destroyed by the engine and not us
            if (this.onlyAllowSingleInstance && OddBehaviour<T>.instance == this as T)
            {
                OddBehaviour<T>.instance = null;
                Logging.Log("[{0}] Singleton instance is being destroyed.", typeof(T).FullName);
            }
        }
        #endregion //Unity Messages
        #endregion //Methods
        #endregion //Instance
    }
    
    public class OddBehaviour<T1, T2> : OddBehaviour<T1> 
        where T1 : OddBehaviour<T1>
        where T2 : OddScriptableObject<T2>
    {
        #region Instance
        #region Fields
        #region Inspector
        [Header("OddBehaviour<TypeComponent,TypeData")]
        [SerializeField] private IRuntimeDataInjector runtimeDataInjector;
        #endregion //Inspector
    
        #region Protected
        protected T2 runtimeData;
        #endregion //Protected
        #endregion //Fields
    
        #region Methods
        #region Unity Messages
        protected override void Awake()
        {
            Assert.IsNotNull( this.runtimeDataInjector );
            
            base.Awake();
            this.runtimeData = this.runtimeDataInjector.GetData<T2>();
        }
    
        protected override void OnDestroy()
        {
            this.runtimeData = null;
            base.OnDestroy();
        }
        #endregion //Unity Messages
        #endregion //Methods
        #endregion //Instance
    }
}

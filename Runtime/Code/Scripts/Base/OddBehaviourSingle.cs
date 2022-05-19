using UnityEngine;
using OddCommon.Debug;

/*  
        These single classes only insures that there is one object of this component/type
        during runtime. It creates an instance if none exists. Note that this is NOT
        a singleton, as there is no getInstance style getter, and because it is generic,
        inheritance is not a problem.
*/
namespace OddCommon
{
    public class OddBehaviourSingle<TypeComponent> : OddBehaviour where TypeComponent : OddBehaviour
    {
        #region Class
        #region Fields
        #region Private
        protected static TypeComponent instance;
        #endregion //Private
        #endregion //Fields
        #endregion //Class

        #region Instance
        #region Fields
        [Header("OddBehaviourSingle")] 
        [SerializeField] private bool destroyDuplicateGameObjects = false;
        #endregion //Fields
        
        #region Methods
        #region Unity Messages
        protected virtual void Awake()
        {
            string fullName = typeof(TypeComponent).FullName;
            if (OddBehaviourSingle<TypeComponent>.instance == null)
            {
                // First instance of this OddBehaviourSingle, so we set ourselves as the protected instance
                OddBehaviourSingle<TypeComponent>.instance = this as TypeComponent;
                Logging.Log("[{0}] Setting first instance as single instance.", fullName);
            }
            else
            {
                // Instance already exists, destroy self if desired
                if (Application.isEditor && !Application.isPlaying)
                {
                    GameObject.DestroyImmediate(this.destroyDuplicateGameObjects ? this.gameObject as Object : this as Object);
                }
                else
                {
                    GameObject.Destroy(this.destroyDuplicateGameObjects ? this.gameObject as Object : this as Object);
                }
                Logging.Warn("[{0}] Instance already exists; destroying self.", fullName);
            }
        }

        protected virtual void OnDestroy()
        {
            if (OddBehaviourSingle<TypeComponent>.instance == this as TypeComponent)
            {
                OddBehaviourSingle<TypeComponent>.instance = null;
                string fullName = typeof(TypeComponent).FullName;
                Logging.Log("[{0}] Singleton instance is being destroyed.", fullName);
            }
        }
        #endregion //Unity Messages
        #endregion //Methods
        #endregion //Instance
    }
    
    public class OddBehaviourSingle<TypeRuntimeData, TypeComponent> : OddBehaviour<TypeRuntimeData>
        where TypeRuntimeData : OddScriptableObjectSingle<TypeRuntimeData>
        where TypeComponent : OddBehaviour<TypeRuntimeData>
    {
        #region Class
        #region Fields
        #region Private
        protected static TypeComponent instance;
        #endregion //Private
        #endregion //Fields
        #endregion //Class

        #region Instance
        #region Fields
        [Header("OddBehaviourSingle")] 
        [SerializeField] private bool destroyDuplicateGameObjects = false;
        #endregion //Fields
        
        #region Methods
        #region Unity Messages
        protected override void Awake()
        {
            base.Awake();
            string fullName = typeof(TypeComponent).FullName;
            if (OddBehaviourSingle<TypeRuntimeData, TypeComponent>.instance == null)
            {
                // First instance of this OddBehaviourSingle, so we set ourselves as the protected instance
                OddBehaviourSingle<TypeRuntimeData, TypeComponent>.instance = this as TypeComponent;
                Logging.Log("[{0}] Setting first instance as single instance.", fullName);
            }
            else
            {
                // Instance already exists, destroy self if desired
                if (Application.isEditor && !Application.isPlaying)
                {
                    GameObject.DestroyImmediate(this.destroyDuplicateGameObjects ? this.gameObject as Object : this as Object);
                }
                else
                {
                    GameObject.Destroy(this.destroyDuplicateGameObjects ? this.gameObject as Object : this as Object);
                }
                Logging.Warn("[{0}] Instance already exists; destroying self.", fullName);
            }
        }

        protected virtual void OnDestroy()
        {
            if (OddBehaviourSingle<TypeRuntimeData, TypeComponent>.instance == this as TypeComponent)
            {
                OddBehaviourSingle<TypeRuntimeData, TypeComponent>.instance = null;
                string fullName = typeof(TypeComponent).FullName;
                Logging.Log("[{0}] Singleton instance is being destroyed.", fullName);
            }
        }
        #endregion //Unity Messages
        #endregion //Methods
        #endregion //Instance
    }
}

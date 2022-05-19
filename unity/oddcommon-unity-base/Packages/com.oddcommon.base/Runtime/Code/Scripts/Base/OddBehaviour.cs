﻿using System;
using UnityEngine;
using UnityEngine.Assertions;


namespace OddCommon
{
    public class OddBehaviour : MonoBehaviour
    {
        /*
         * Non-runtimedata holding OddBehaviour, for backwards compatibility.
         */
    }
    
    public class OddBehaviour<T> : MonoBehaviour where T : OddScriptableObjectSingle<T>
    {
        #region Instance
        #region Fields
        #region Inspector
        [SerializeField] private DataManager dataManager;
        #endregion //Inspector

        #region Protected
        protected T runtimeData;
        #endregion //Protected
        #endregion //Fields

        #region Methods
        #region Unity Messages
        protected virtual void Awake()
        {
            Assert.IsNotNull( this.dataManager );
            this.runtimeData = this.dataManager.GetData<T>();
        }
        #endregion //Unity Messages
        #endregion //Methods
        #endregion //Instance
    }
}
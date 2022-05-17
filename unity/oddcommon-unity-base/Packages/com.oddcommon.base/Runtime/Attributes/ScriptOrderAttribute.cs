using System;


namespace OddCommon
{ 
    public class ScriptOrderAttribute : Attribute
    {
        #region Fields
        #region Public
        public int Order
        {
            get => this.order;
        }
        #endregion //Public

        #region Private
        private readonly int order;
        #endregion //Private
        #endregion //Fields

        #region Constructors
        public ScriptOrderAttribute(int customOrder) : base()
        {
            this.order = customOrder;
        }
        #endregion //Constructors
    }
}
using OddCommon;


namespace OddCommon
{
    public interface IRuntimeDataInjector
    {
        public T GetData<T>() where T : OddScriptableObject<T>;
    }
}
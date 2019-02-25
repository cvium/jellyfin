namespace MediaBrowser.Model.Services
{
    public interface IReturn : ServiceStack.IReturn { }
    public interface IReturn<T> : IReturn { }
    public interface IReturnVoid : IReturn { }
}

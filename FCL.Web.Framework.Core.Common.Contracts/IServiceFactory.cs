namespace FCL.Web.Framework.Core.Common.Contracts
{
    public interface IServiceFactory
    {
        T CreateClient<T>() where T : IServiceContract;
    }
}
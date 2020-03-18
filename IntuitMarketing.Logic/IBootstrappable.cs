using Autofac;

namespace IntuitMarketing.Base
{
    public interface IBootstrappable
    {
        ContainerBuilder Bootstrap();
    }
}

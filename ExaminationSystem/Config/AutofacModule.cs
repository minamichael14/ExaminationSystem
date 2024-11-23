using Autofac;
using Autofac.Core;
using ExaminationSystem.Data.Repository;
using ExaminationSystem.Data;
using ExaminationSystem.Services.Questions;

namespace ExaminationSystem.Config
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                            .Where(c => c.Name.EndsWith("Service"))
                            .AsImplementedInterfaces()
                            .InstancePerLifetimeScope();

        }
    }
}

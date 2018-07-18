using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Data;
using GeaWebMVC.Business;
using GeaWebMVC.Business.RepositoryInterfaces;
using Repository.Repository;
using Repository.RepositoryInterfaces;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace ContainerIoc
{
    public class RgisterContainerIoc
    {
        public static void Register()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:

            //Register Repository
            container.Register<IRepositoryCarro, RepositoryCarro >(Lifestyle.Transient);
            container.Register<IRepositoryOperador, RepositoryOperador>(Lifestyle.Transient);
            container.Register<IRepositoryEmpresa, RepositoryEmpresa>(Lifestyle.Transient);
            container.Register<IRepositoryRegistroDeFluxo, RepositoryRegistroDeFluxo>(Lifestyle.Transient);
            container.Register<IRepositoryPerfil, RepositoryPerfil>(Lifestyle.Transient);
            container.Register<IRepositoryFaturamento, RepositoryFaturamento>(Lifestyle.Transient);

            //Register Business
            container.Register<IBusinessCarro, BusinessCarro>(Lifestyle.Transient);
            container.Register<IBusinessOperador, BusinessOperador>(Lifestyle.Transient);
            container.Register<IBusinessEmpresa, BusinessEmpresa>(Lifestyle.Transient);
            container.Register<IBusinessRegistroDeFluxo, BusinessRegistroDeFluxo>(Lifestyle.Transient);
            container.Register<IBusinessPerfil, BusinessPerfil>(Lifestyle.Transient);
            container.Register<IBusinessFaturamento, BusinessFaturamento>(Lifestyle.Transient);


           // container.Register<DbContext>(() => new GeaContext("Name=GeaContext"), Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}

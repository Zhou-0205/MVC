﻿using Autofac;
using Autofac.Integration.Mvc;
using ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //1. 获得一个ContainerBuilder（容器建造器）对象 
            ContainerBuilder builder = new ContainerBuilder();

            //2. 注册Controller和FilterProvider
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterFilterProvider();

            //2.1 可以一个类一个类的注册
            //builder.RegisterType<UserService>().As<UserService>();

            //2.2 也可以整个程序集的注册  
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly).AsImplementedInterfaces();

            //3. 通过ContainerBuilder得到一个IContainer容器对象，
            IContainer container = builder.Build();

            //4. 并为MVC自动设定解析（resolve：获取“接口对象”）
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

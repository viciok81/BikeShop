﻿using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Domain.Abstract;
using Domain.Concrete;
using Ninject;
using WebUI.Infrastructure.Abstarct;
using WebUI.Infrastructure.Concrete;

namespace WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public  NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController) ninjectKernel.Get(controllerType);
        }
        
        private void AddBindings()
        {
            ninjectKernel.Bind<IProductionRepository>().To<EfProductionRepository>();
            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
            ninjectKernel.Bind<RoleProvider>().To<FormsRoleProvider>();
            
        }
    }
}
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<RoleManager>().As<IRoleService>().SingleInstance();

            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();

            builder.RegisterType<EfBasketDal>().As<IBasketDal>().SingleInstance();
            builder.RegisterType<BasketManager>().As<IBasketService>().SingleInstance();

            builder.RegisterType<EfBasketItemDal>().As<IBasketItemDal>().SingleInstance();
            builder.RegisterType<BasketItemManager>().As<IBasketItemService>().SingleInstance();

            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();

            builder.RegisterType<EfCategoryProductDal>().As<ICategoryProductDal>().SingleInstance();
            builder.RegisterType<CategoryProductManager>().As<ICategoryProductService>().SingleInstance();

            builder.RegisterType<EfDiscountDal>().As<IDiscountDal>().SingleInstance();
            builder.RegisterType<DiscountManager>().As<IDiscountService>().SingleInstance();

            builder.RegisterType<EfWalletDal>().As<IWalletDal>().SingleInstance();
            builder.RegisterType<WalletManager>().As<IWalletService>().SingleInstance();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}

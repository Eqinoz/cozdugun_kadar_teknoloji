using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SchoolManager>().As<ISchoolService>();
            builder.RegisterType<EfSchoolDal>().As<ISchoolDal>();

            builder.RegisterType<EfSchoolLessonDal>().As<ISchoolLessonDal>();
            builder.RegisterType<SchoolLessonManager>().As<ISchoolLessonService>();

            builder.RegisterType<MissionTypeManager>().As<IMissionTypeService>();
            builder.RegisterType<EfMissionTypeDal>().As<IMissionTypeDal>();

            builder.RegisterType<PhotoMissionManager>().As<IPhotoMissionService>();
            builder.RegisterType<EfPhotoMissionDal>().As<IPhotoMissionDal>();

            builder.RegisterType<QuestionMissionManager>().As<IQuestionMissonService>();
            builder.RegisterType<EfQuestionMission>().As<IQuestionMissionDal>();

            builder.RegisterType<ParentManager>().As<IParentService>();
            builder.RegisterType<EfParentDal>().As<IParentDal>();

            builder.RegisterType<ChildManager>().As<IChildService>();
            builder.RegisterType<EfChildDal>().As<IChildDal>();

            builder.RegisterType<AdminManager>().As<IManagerService>();
            builder.RegisterType<EfManagerDal>().As<IManagerDal>();

            builder.RegisterType<TitleManager>().As<ITitleService>();
            builder.RegisterType<EfTitleDal>().As<ITitleDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<QuestionGenerateManager>().As<IQuestionGenerateService>();
            builder.RegisterType<EfQuestionGenerateDal>().As<IQuestionGenerateDal>();

            
            

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}

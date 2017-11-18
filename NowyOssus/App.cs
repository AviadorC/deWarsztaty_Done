using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Plugins.Messenger;

namespace NowyOssus
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            //CreatableTypes()
                //.EndingWith("Service")
                //.AsInterfaces()
                //.RegisterAsLazySingleton();

            RegisterNavigationServiceAppStart<ViewModels.MainViewModel>();
            Mvx.LazyConstructAndRegisterSingleton<IMvxMessenger, MvxMessengerHub>();
        }
    }
}

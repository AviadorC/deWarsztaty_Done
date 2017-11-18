using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Support;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Plugins.Messenger;
using NowyOssus.Messages;
using NowyOssus.Service;

namespace NowyOssus.Droid.Services
{
    public class DialogService : IDialogService
    {
        private readonly IMvxMessenger _messenger;

        public DialogService(IMvxMessenger messenger)
        {
            _messenger = messenger;
        }

        public void ShowAcceptanceDialog() 
        {
            var activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
            var dialog = new AlertDialog
                .Builder(activity)
                .SetMessage("Do you accept it?")
                .SetPositiveButton("OK", (sender, e) =>
                {
                    _messenger.Publish(new DecisionMessage(this, true));
                })
                .SetNegativeButton("CANCEL", (sender, e) =>
                {
                    _messenger.Publish(new DecisionMessage(this, false));
                }).Create();

            dialog.Show();
        }
    }
}

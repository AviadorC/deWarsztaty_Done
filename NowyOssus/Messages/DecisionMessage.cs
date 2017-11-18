using System;
using MvvmCross.Plugins.Messenger;

namespace NowyOssus.Messages
{
    public class DecisionMessage : MvxMessage
    {
        public DecisionMessage(object sender, bool decision) : base(sender)
        {
            Decision = decision;
        }

        public bool Decision { get; private set; }
    }
}

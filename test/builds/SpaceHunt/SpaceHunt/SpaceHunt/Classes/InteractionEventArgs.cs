using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHunt.Classes
{
    public class InteractionEventArgs
    {
        public readonly InteractionState interactionState;

        public InteractionEventArgs(InteractionState interactionState)
        {
            this.interactionState = interactionState;
        }
    }
}

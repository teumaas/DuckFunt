using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes
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

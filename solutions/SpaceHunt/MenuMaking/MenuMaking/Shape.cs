using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHunt
{
    enum InteractionState
    {
        shapesource,
        shapeInteractive,
        shapeAnimated,
    }
    class Shape
    {
        ShapeSource shapeSource;//ShapeSource
        ShapeInteractive shapeInteractive;//ShapeInteractive
        ShapeAnimated shapeAnimated;//ShapeAnimated
        InteractionState interactionState;//InteractionState
    }
}

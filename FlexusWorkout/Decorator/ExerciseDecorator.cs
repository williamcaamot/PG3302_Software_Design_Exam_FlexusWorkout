using FlexusWorkout.Models.Base;

namespace FlexusWorkout.MODIFINGGGGG.modifierAndDecorators;

public abstract class ExerciseDecorator : Exercise
{
    protected Exercise _component;

    public ExerciseDecorator(Exercise component) : base()
    {
        _component = component;
    }
}
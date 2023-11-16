using FlexusWorkout.Models.Base;

namespace FlexusWorkout.MODIFINGGGGG.modifierAndDecorators;

public class SetDecreaseDecorator : ExerciseDecorator
{
    public SetDecreaseDecorator(Exercise component) : base(component) { }

    public void DecreaseSets()
    {
        if (_component.Sets.HasValue && _component.Sets > 1)
        {
            _component.Sets--;
        }
    }
}
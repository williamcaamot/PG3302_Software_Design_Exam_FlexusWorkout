using FlexusWorkout.Models.Base;

namespace FlexusWorkout.MODIFINGGGGG.modifierAndDecorators;

public class SetIncreaseDecorator : ExerciseDecorator
{
    public SetIncreaseDecorator(Exercise component) : base(component) { }

    public void IncreaseSets()
    {
        if (_component.Sets.HasValue)
        {
            _component.Sets++;
        }
    }
    
}
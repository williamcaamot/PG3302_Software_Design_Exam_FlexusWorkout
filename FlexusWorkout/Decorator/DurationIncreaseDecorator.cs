using FlexusWorkout.Models.Base;

namespace FlexusWorkout.MODIFINGGGGG.modifierAndDecorators;

public class DurationIncreaseDecorator : ExerciseDecorator
{
    public DurationIncreaseDecorator(Exercise component) : base(component) { }

    public void IncreaseDuration()
    {
        if (_component.DurationInMinutes.HasValue)
        {
            _component.DurationInMinutes++;
        }
    }
}
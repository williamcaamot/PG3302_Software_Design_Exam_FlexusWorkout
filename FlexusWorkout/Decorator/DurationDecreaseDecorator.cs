using FlexusWorkout.Models.Base;

namespace FlexusWorkout.MODIFINGGGGG.modifierAndDecorators;

public class DurationDecreaseDecorator : ExerciseDecorator
{
    public DurationDecreaseDecorator(Exercise component) : base(component) { }
    
    public void DecreaseDuration()
    {
        if (_component.DurationInMinutes.HasValue && _component.DurationInMinutes > 1)
        {
            _component.DurationInMinutes--;
        }
    }
}
using FlexusWorkout.Models.Base;

namespace FlexusWorkout.MODIFINGGGGG.modifierAndDecorators;

public class IntensityIncreaseDecorator : ExerciseDecorator
{
    public IntensityIncreaseDecorator(Exercise component) : base(component) { }

    public void IncreaseIntensity()
    {
        if (_component.IntensityLevel.HasValue)
        {
            _component.IntensityLevel++;
        }
    }
}
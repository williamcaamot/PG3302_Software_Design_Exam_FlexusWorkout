using FlexusWorkout.Models.Base;

namespace FlexusWorkout.MODIFINGGGGG.modifierAndDecorators;

public class IntensityDecreaseDecorator : ExerciseDecorator
{
    public IntensityDecreaseDecorator(Exercise component) : base(component) { }

    public void DecreaseIntensity()
    {
        if (_component.IntensityLevel.HasValue && _component.IntensityLevel > 1)
        {
            _component.IntensityLevel--;
        }
    }
}
using FlexusWorkout.Models.Base;

namespace FlexusWorkout.MODIFINGGGGG.modifierAndDecorators;

public class RepetitionDecreaseDecorator : ExerciseDecorator
{
    public RepetitionDecreaseDecorator(Exercise component) : base(component) { }
    

    public void DecreaseReps()
    {
        if (_component.Repetitions.HasValue && _component.Repetitions > 1)
        {
            _component.Repetitions--;
        }
    }
}
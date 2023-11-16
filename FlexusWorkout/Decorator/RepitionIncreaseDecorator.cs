using FlexusWorkout.Models.Base;

namespace FlexusWorkout.MODIFINGGGGG.modifierAndDecorators;

public class RepetitionIncreaseDecorator : ExerciseDecorator
{
    public RepetitionIncreaseDecorator(Exercise component) : base(component) { }

    public void IncreaseReps()
    {
        if (_component.Repetitions.HasValue)
        {
            _component.Repetitions++;
        }
    }
    
}
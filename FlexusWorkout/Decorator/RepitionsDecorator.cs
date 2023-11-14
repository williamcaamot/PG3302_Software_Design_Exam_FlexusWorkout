using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Decorator
{
    public class RepitionsDecorator : ExerciseDecorator
    {
        public RepitionsDecorator(Exercise component) : base(component) { }

        public void IncreaseRepetitions()
        {
            if (_component.Repetitions.HasValue)
            {
                _component.Repetitions++;
            }
        }

        public void DecreaseRepetitions()
        {
            if (_component.Repetitions.HasValue && _component.Repetitions > 1)
            {
                _component.Repetitions--;
            }
        }
    }
}
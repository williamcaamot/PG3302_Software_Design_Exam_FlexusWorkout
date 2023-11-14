using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Decorator
{
    public class DurationInMinutesDecorator : ExerciseDecorator
    {
        public DurationInMinutesDecorator(Exercise component) : base(component) { }

        public void IncreaseDuration()
        {
            if (_component.DurationInMinutes.HasValue)
            {
                _component.DurationInMinutes++;
            }
        }

        public void DecreaseDuration()
        {
            if (_component.DurationInMinutes.HasValue && _component.DurationInMinutes > 1)
            {
                _component.DurationInMinutes--;
            }
        }
    }
}

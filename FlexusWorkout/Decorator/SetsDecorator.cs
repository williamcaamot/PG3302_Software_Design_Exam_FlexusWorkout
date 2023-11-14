using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Decorator
{
    public class SetsDecorator : ExerciseDecorator
    {
        public SetsDecorator(Exercise component) : base(component) { }

        public void IncreaseSets()
        {
            if (_component.Sets.HasValue)
            {
                _component.Sets++;
            }
        }

        public void DecreaseSets()
        {
            if (_component.Sets.HasValue && _component.Sets > 1)
            {
                _component.Sets--;
            }
        }
    }
}
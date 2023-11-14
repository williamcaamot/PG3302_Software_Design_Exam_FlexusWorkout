using FlexusWorkout.Decorator;
using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Decorators
{
//Decorator for adding intensity level to an exercise
    public class IntensityLevelDecorator : ExerciseDecorator
    {
        //Constructor that sets the wrapped component
        public IntensityLevelDecorator(Exercise component) : base(component)
        {
        }

        public void IncreaseIntensity()
        {
            if (_component.IntensityLevel.HasValue)
            {
                _component.IntensityLevel++;
            }
        }

        public void DecreaseIntensity()
        {
            if (_component.IntensityLevel.HasValue && _component.IntensityLevel > 1)
            {
                _component.IntensityLevel--;
            }
        }
    }
}


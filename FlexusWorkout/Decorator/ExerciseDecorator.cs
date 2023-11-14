using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Decorator
{
    //base class for all decorators
    public abstract class ExerciseDecorator : Exercise
    {
        //component can be accessed by derived classes
        protected Exercise _component;

        //Constructor that takes in wrapped component as parameter
        public ExerciseDecorator(Exercise component) : base()
        {
            _component = component;
        }
        
    }
}
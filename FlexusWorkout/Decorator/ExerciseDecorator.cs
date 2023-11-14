using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Decorator
{

    public abstract class ExerciseDecorator : Exercise
    {
        //Component field = refers to the component being decorated. 
        //component can be accessed by derived classes
        protected Exercise _component;

        //Constructor that takes in wrapped component as parameter
        public ExerciseDecorator(Exercise component) : base()
        {
            _component = component;
        }
        //Overriding the DisplayExercise method to delegate to the wrapped component 
        /*public override void DisplayExercise()
        {
            _component.DisplayExercise();
        }*/
    }
}
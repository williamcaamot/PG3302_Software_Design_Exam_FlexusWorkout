using FlexusWorkout.Decorator;
using FlexusWorkout.Model.Base;

namespace FlexusWorkout.Decorators; 
//Decorator for adding intensity level to an exercise
public class IntensityLevelDecorator : ExerciseDecorator{
    //Constructor that sets the wrapped component
    public IntensityLevelDecorator(Exercise component) : base(component) {
    }
    //Override method to add specific outcome, in this case for intensity level
    /*public override void DisplayExercise() {
        Console.WriteLine("Exercise with enhanced intensity level");
        _component.DisplayExercise();
        
    }*/
}
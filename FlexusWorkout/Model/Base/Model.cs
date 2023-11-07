namespace FlexusWorkout.Model.Base;

public abstract class Model
{
    // abstract method to update/modify data
    public abstract void UpdateData(object data);
    
    // abstract class for retrieving model data
    public abstract object GetData();
}
// See https://aka.ms/new-console-template for more information

using System;
using FlexusWorkout.View_model.WorkoutPlanner;
using FlexusWorkout.View.Menu;
using Microsoft.VisualBasic;

namespace FlexusWorkout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InitialMenu initialMenu = new();
            
            var test = new WorkoutPlanner();
            
            test.addSession(new WorkoutSession("Chest", "flys, benchpress, dumbell press", DateTime.Today ));
            test.DisplayWorkout();
        }
    }
}
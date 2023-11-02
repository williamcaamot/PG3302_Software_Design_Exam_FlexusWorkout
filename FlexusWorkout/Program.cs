// See https://aka.ms/new-console-template for more information

using System;
using FlexusWorkout.Model;
using FlexusWorkout.View_model.User;
using FlexusWorkout.View_model.WorkoutPlanner;
using FlexusWorkout.View.Menu;
using Microsoft.VisualBasic;

namespace FlexusWorkout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new("Test", "User", "bor@gmail.com", "Lol");
            UserService userService = new();
            userService.Add(user);
            
            
            InitialMenu initialMenu = new();
            
            //var test = new WorkoutPlanner();
            
            //test.addSession(new WorkoutSession("Chest", "flys, benchpress, dumbell press", DateAndTime.Today ));


            

        }
    }
}
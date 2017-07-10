using System;

using TechTalk.SpecFlow;

namespace Xamarin.UITest.SpecFlow
{
    [Binding]
    public class GeneralSteps
    {
        [Given(@"I enter a new task named ""(.*)""")]
        public void GivenIEnterANewTaskNamed(string name)
        {
            new TaskListPage()
                .GoToAddTask();

            new TaskDetailsPage()
                .EnterTask(name)
                .Save();

            new TaskListPage()
                .VerifyTaskExists(name);
        }
    }
}

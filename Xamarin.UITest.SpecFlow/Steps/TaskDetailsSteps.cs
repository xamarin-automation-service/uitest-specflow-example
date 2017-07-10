using System;

using TechTalk.SpecFlow;

namespace Xamarin.UITest.SpecFlow
{
    [Binding]
    public class TaskDetailsSteps
    {
        TaskDetailsPage taskDetailsPage = new TaskDetailsPage();

        [Given(@"I am on the task details page")]
        public void GivenIAmOnTheTaskDetailsPage()
        {
            taskDetailsPage
                .AssertOnPage();
        }

        [When(@"I delete the task")]
        public void WhenIDeleteTheTask()
        {
            taskDetailsPage
                .Delete();
        }

        [When(@"I complete the task")]
        public void WhenICompleteTheTask()
        {
            taskDetailsPage
                .TapDone();
        }

        [When(@"I verify the task is done")]
        public void WhenIVerifyTheTaskIsDone()
        {
            taskDetailsPage
                .VerifyDone();
        }

        [When(@"I save the task")]
        public void WhenISaveTheTask()
        {
            taskDetailsPage
                .Save();
        }
    }
}

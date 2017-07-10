using System;

using TechTalk.SpecFlow;

namespace Xamarin.UITest.SpecFlow
{
    [Binding]
    public class TaskListSteps
    {
        TaskListPage taskListPage = new TaskListPage();

        [Given(@"I am on the task list page")]
        [When(@"I am on the task list page")]
        public void GivenIAmOnTheTaskListPage()
        {
            taskListPage
                .AssertOnPage();
        }

        [Given(@"I select the first task")]
        public void GivenISelectTheFirstTask()
        {
            taskListPage
                .SelectTask();
        }

        [When(@"I swipe and delete the task named ""(.*)""")]
        public void WhenISwipeAndDeleteTheTask(string taskName)
        {
            taskListPage
                .DeleteTask(taskName);
        }

        [Then(@"the task named ""(.*)"" should not exist")]
        public void ThenTheTaskNamedShouldNotExist(string taskName)
        {
            taskListPage
                .VerifyTaskDoesNotExist(taskName);
        }

        [Then(@"the task named ""(.*)"" should be complete")]
        public void ThenTheTaskNamedShouldBeComplete(string taskName)
        {
            taskListPage
                .VerifyTaskDone(taskName, true);
        }
    }
}

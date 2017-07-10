using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Xamarin.UITest.SpecFlow
{
    public class TaskListPage : BasePage
    {
        readonly Query addTaskButton;
        readonly Query firstTask;
        readonly Query deleteButton;
        readonly Func<string, Query> checkMarkForTask;
        readonly Func<string, Query> taskListItem;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("menu_add_task"),
            iOS = x => x.Marked("Tasky")
        };

        public TaskListPage()
        {
            if (OnAndroid)
            {
                addTaskButton = x => x.Marked("menu_add_task");
                firstTask = x => x.Id("lstTasks").Child(0);
                checkMarkForTask = taskName => x => x.Marked(taskName).Parent().Sibling().Id("checkMark");
            }

            if (OniOS)
            {
                addTaskButton = x => x.Marked("Add");
                firstTask = x => x.Class("UITableViewWrapperView").Child(0);
                taskListItem = name => x => x.Class("UITableViewCell").Text(name);
                deleteButton = x => x.Marked("Delete");
            }
        }

        public void GoToAddTask()
        {
            app.WaitForElement(addTaskButton);
            app.Tap(addTaskButton);
        }

        public void SelectTask(string name = null)
        {
            app.WaitForElement(firstTask);

            if (name == null)
            {
                app.Tap(firstTask);
            }
            else
            {
                app.Tap(name);
            }
        }

        public TaskListPage VerifyTaskExists(string name)
        {
            app.WaitForElement(name);

            return this;
        }

        public TaskListPage VerifyTaskDoesNotExist(string name)
        {
            app.WaitForNoElement(name);

            return this;
        }

        public TaskListPage VerifyTaskDone(string name, bool done = true)
        {
            // Method not applicable to iOS
            if (OnAndroid)
            {
                if (done)
                {
                    app.WaitForElement(checkMarkForTask(name));
                }
                else
                {
                    app.WaitForNoElement(checkMarkForTask(name));
                }
            }

            return this;
        }

        public TaskListPage DeleteTask(string name)
        {
            // Method not applicable to Android
            if (OniOS)
            {
                app.SwipeRightToLeft(taskListItem(name));
                app.Tap(deleteButton);
            }

            return this;
        }
    }
}

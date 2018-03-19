using ACTestProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ACTestProject.Steps
{
    
    [Scope(Feature = "CreateTask", Tag = "createTask")]
    [Scope(Feature = "CreateSubTask", Tag = "createSubTask")]
    [Binding]
    class ToDoListSteps
    {      
        ToDoListPage page = new ToDoListPage();

        //[BeforeTestRun]
        //public void Initialize()
        //{
        //    Browser.Initialize();
        //}

        //[AfterTestRun]
        //public void TearDown()
        //{
        //    Browser.TearDown();
        //}

        #region Background methods
        [Given(@"I have logged in the website")]
        public void GivenIHaveLoggedInTheWebsite()
        {
            //Browser.Initialize();
            PropertiesCollection.currentPage = new LoginPage();
            ((LoginPage)PropertiesCollection.currentPage).Login("felipegluz@hotmail.com", "abc123456");
            ((LoginPage)PropertiesCollection.currentPage).ClickSignInButton();
        }

        [When(@"I click My Tasks")]
        public void WhenIClickMyTasks()
        {
            PropertiesCollection.currentPage = new HomePage();
            ((HomePage)PropertiesCollection.currentPage).ClickOnMyTasksButton();
        }

        [Then(@"I should see the ToDoList page")]
        public void ThenIShouldSeeTheToDoListPage()
        {
            PropertiesCollection.currentPage = new ToDoListPage();
            ((ToDoListPage)PropertiesCollection.currentPage).IsLoggedIn();
        }
        #endregion
        
        [Given(@"I typed a new task")]
        public void GivenITypedANewTask()
        {
            page.CreateTask();
        }

        [When(@"I click on Add icon")]
        public void WhenIClickOnAddIcon()
        {
            page.AddNewTask();
        }

        [Then(@"the new task should be in the To be Done list")]
        public void ThenTheNewTaskShouldBeInTheToBeDoneList()
        {
            page.TaskCreatedInTheList();
        }

        [When(@"I clicked the link My Tasks on the NavBar")]
        public void WhenIClickedTheLinkMyTasksOnTheNavBar()
        {
            PropertiesCollection.currentPage = new HomePage();            
            ((HomePage)PropertiesCollection.currentPage).ClickOnMyTasksNavBar();
        }

        [When(@"I see the message on the top")]
        public void WhenISeeTheMessageOnTheTop()
        {
            page.CheckTitleOfTheList();
        }

        [Then(@"The message on the top should be correct")]
        public void ThenTheMessageOnTheTopShouldBeCorrect()
        {
            page.VerifyIfTitleIsCorrect();
        }

        [When(@"I press Enter")]
        public void WhenIPressEnter()
        {
            page.PressEnter();
        }

        [When(@"I type a task named (.*)")]
        public void WhenITypeATaskNamed(string name)
        {
            page.CreateTaskWithName(name);
        }

        [Then(@"The task should not be added")]
        public void ThenTheTaskShouldNotBeAdded()
        {
            Assert.IsFalse(page.TaskCreatedInTheList());
        }

        [When(@"I see the (.*) of the task field")]
        public void WhenISeeTheOfTheTaskField(string attribute)
        {
            page.GetAttributeOfTheTaskField(attribute);
        }                        

        [Then(@"The value of the task field should be correct")]
        public void ThenTheValueOfTheTaskFieldShouldBeCorrect()
        {
            page.CheckTaskMaxlenghtOfTask();
        }
        
        [Then(@"I click on the Manage Subtasks button")]
        public void ThenIClickOnTheManageSubtasksButton()
        {
            page.ClickOnTheManageSubTasks();
        }

        [Then(@"I create a task")]
        public void ThenICreateATask()
        {
            page.CreateTask();
            page.AddNewTask();
        }

        [When(@"I close the modal")]
        public void WhenICloseTheModal()
        {
            page.CloseModal();
        }

        [Then(@"I should see a button labeled Manage Subtasks")]
        public void ThenIShouldSeeAButtonLabeledManageSubtasks()
        {
            Assert.IsTrue(page.ButtonManageSubtasaksIsVisible());
        }

        [Given(@"I created two subtasks")]
        public void GivenICreatedTwoSubtasks()
        {
            page.CreateSubTask();
            page.ClickAddSubTask();

            page.CreateSubTask();
            page.ClickAddSubTask();
        }

        [Then(@"I should see the number of two subtasks created for that task")]
        public void ThenIShouldSeeTheNumberOfTwoSubtasksCreatedForThatTask()
        {
            page.CheckNumberOfSubTasks();
        }

        [Given(@"The modal dialog is open")]
        public void GivenTheModalDialogIsOpen()
        {
            Assert.IsTrue(page.ModalIsOpened());
        }

        [Then(@"I should check if the modal has task ID and task description")]
        public void ThenIShouldCheckIfTheModalHasTaskIDAndTaskDescription()
        {
            Assert.IsTrue(page.CheckTaskIdAndTaskDescription());
        }

        [Then(@"the subTask description and dueDate should have the correct values")]
        public void ThenTheSubTaskDescriptionAndDueDateShouldHaveTheCorrectValues()
        {            
            page.CheckSubTaskDescriptionAndDueDate();            
        }

        [Given(@"I created a subtask")]
        public void GivenICreatedASubtask()
        {
            page.CreateSubTask();            
        }

        [When(@"I click the Add button to add a subTask")]
        public void WhenIClickTheAddButtonToAddASubTask()
        {
            page.ClickAddSubTask();
        }

        [Then(@"I should see if the task description and dueDate are required fields")]
        public void ThenIShouldSeeIfTheTaskDescriptionAndDueDateAreRequiredFields()
        {
            page.CheckRequiredFields();
        }

        [Then(@"The subtask should be on the bottom part of the modal dialog")]
        public void ThenTheSubtasShouldBeOnTheBottomPartOfTheModalDialog()
        {
            page.CheckSubTaskOnTheBottom();
        }





    }
}

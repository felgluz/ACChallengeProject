using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace ACTestProject.Pages
{
    class ToDoListPage : BasePage
    {
        public string nameTask = "taskName";

        public IWebElement newTaskField => Browser.Driver.FindElement(By.Id("new_task"));
        public IWebElement btnAddTask => Browser.Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[2]/span"));
        public IList<IWebElement> task => Browser.Driver.FindElements(By.XPath($"//*[contains(text(),'{nameTask}')]"));       
        public IWebElement titleOfTheList => Browser.Driver.FindElement(By.XPath("//h1[contains(text(),'ToDo List')]"));
        public IList<IWebElement> btnRemovetask => Browser.Driver.FindElements(By.CssSelector(".btn-danger"));

        public IWebElement btnCloseModal => Browser.Driver.FindElement(By.CssSelector(".btn-primary[ng-click='close()']"));
        public IList<IWebElement> btnManageSubtasks => Browser.Driver.FindElements(By.CssSelector(".btn-primary"));        
        public IWebElement newSubTask => Browser.Driver.FindElement(By.Id("new_sub_task"));
        public IWebElement newSubTaskAdd => Browser.Driver.FindElement(By.Id("add-subtask"));
        public IWebElement dueDate => Browser.Driver.FindElement(By.Id("dueDate"));    
        
        public void IsLoggedIn()
        {
            Assert.IsTrue(Browser.ElementIsPresent(By.Id("new_task"), PropertiesCollection.timeoutInSeconds));
        }

        public void CreateTask()
        {
            newTaskField.SendKeys(nameTask);
        }

        public void CreateTaskWithName(string name)
        {
            newTaskField.SendKeys(name);
        }

        public void AddNewTask()
        {
            btnAddTask.Click();
        }

        public bool TaskCreatedInTheList()
        {
            if (task[0].Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CheckTitleOfTheList()
        {
            Assert.IsTrue(Browser.ElementIsPresent(By.XPath("//h1[contains(text(),'ToDo List')]"), PropertiesCollection.timeoutInSeconds));
        }

        public bool VerifyIfTitleIsCorrect()
        {
            string excepectedMessage = "this is your todo list for today:";
            try
            {
                Assert.AreEqual(excepectedMessage, titleOfTheList.Text);
                return true;
            }
            catch
            {
                return false;
                //throw new System.SystemException("Message is different from expected", e);                
            }
        }

        public void PressEnter()
        {
            Browser.UseEnterKey();
        }

        public void GetAttributeOfTheTaskField(string attribute)
        {
            newTaskField.GetAttribute(attribute);
        }

        public void CheckTaskMaxlenghtOfTask()
        {
            Assert.AreEqual("250", newTaskField.GetAttribute("maxlength"));
        }

        public void ClickOnTheManageSubTasks()
        {
            btnManageSubtasks[0].Click();
        }

        public void CloseModal()
        {
            btnCloseModal.Click();
        }

        public bool ButtonManageSubtasaksIsVisible()
        {
            if (btnManageSubtasks[0].Displayed == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreateSubTask()
        {
            newSubTask.SendKeys("newSubTask");
        }

        public void ClickAddSubTask()
        {
            newSubTaskAdd.Click();
        }
        
        public void CheckNumberOfSubTasks()
        {
            Assert.AreEqual("(2) Manage Subtasks", btnManageSubtasks[0].Text);
            btnRemovetask[0].Click();
        }

        public bool ModalIsOpened()
        {
            if (btnCloseModal.Displayed == true)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        public bool CheckTaskIdAndTaskDescription()
        {
            var taskID = Browser.Driver.FindElement(By.CssSelector(".modal-title"));

            if(taskID.Text != null && newSubTask.Text != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CheckSubTaskDescriptionAndDueDate()
        {            
            Assert.AreEqual("MM/dd/yyyy", dueDate.GetAttribute("placeholder"));
            Assert.AreEqual("250", newSubTask.GetAttribute("maxlength"));
        }

        public bool CheckRequiredFields()
        {
            var editTask = Browser.Driver.FindElement(By.Id("edit_task"));
            try
            {
                Assert.AreEqual("required", editTask.GetAttribute("required"));
                Assert.AreEqual("required", dueDate.GetAttribute("required"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void CheckSubTaskOnTheBottom()
        {
            var subtaskOnTheBottom = Browser.Driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[2]/div[2]/table/tbody/tr/td[2]/a"));
            Assert.IsTrue(subtaskOnTheBottom.Displayed);
        }
    }
}


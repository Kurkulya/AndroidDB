using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Tests.UI_Control;

namespace Tests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;
        IPageObject db;

        public Tests(Platform platform)
        {
            this.platform = platform;
            if (platform == Platform.Android)
                db = new AndroidDataBase();
            else
                db = new IOSDataBase();
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [TestCase("5","Bobik","Arno","23")]
        public void TestCreatePerson(string id, string fn, string ln, string age)
        {
            StartCreateScreen();
            FullCreateScreen(id, fn, ln, age);
            app.Tap(db.ICreateBtn);

            Assert.AreEqual(id, GetText(db.OId));
            Assert.AreEqual(fn, GetText(db.OFirstName));
            Assert.AreEqual(ln, GetText(db.OLastName));
            Assert.AreEqual(age, GetText(db.OAge));
        }

        [TestCase("K", "K", "3")]
        public void TestUpdatePerson(string fn, string ln, string age)
        {
            TestCreatePerson("5", "Bobik", "Arno", "1");
            StartUpdateScreen();
            FullUpdateScreen(fn, ln, age);
            app.Tap(db.UUpdateBtn);

            Assert.AreEqual("BobikK", GetText(db.OFirstName));
            Assert.AreEqual("ArnoK", GetText(db.OLastName));
            Assert.AreEqual("13", GetText(db.OAge));
        }

        [Test]
        public void TestDelete()
        {
            TestCreatePerson("5", "NeBobik", "NeArno", "100");
            app.Tap(db.DeleteBtn);
        }

        [Test]
        public void TesеSwipe()
        {
            app.SwipeRight();
            app.SwipeLeft();
        }


        private string GetText(Func<AppQuery, AppQuery> field)
        {
            app.Tap(field);
            AppResult[] results = app.Query(field);
            return results[0].Text;
        }
        private void EnterField(Func<AppQuery,AppQuery> field, string text)
        {
            app.Tap(field);
            app.EnterText(text);
        }

        private void StartCreateScreen()
        {
            app.Tap(db.CreateBtn);
            app.WaitForElement(db.ICreateBtn);
        }
        private void StartUpdateScreen()
        {
            app.Tap(db.UpdateBtn);
            app.WaitForElement(db.UUpdateBtn);
        }

        private void FullCreateScreen(string id, string fn, string ln, string age)
        {
            EnterField(db.IId, id);
            EnterField(db.IFirstName, fn);
            EnterField(db.ILastName, ln);
            EnterField(db.IAge, age);
        }
        private void FullUpdateScreen(string fn, string ln, string age)
        {
            EnterField(db.UFirstName, fn);
            EnterField(db.ULastName, ln);
            EnterField(db.UAge, age);
        }
    }
}


using Model.GigFacade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model;
using System.Collections.Generic;
using Util.Exceptions;
using Microsoft.Practices.Unity;
using System.Transactions;
namespace Test
{
    [TestClass()]
    public class IGigServiceTest
    {
        // Variables used in several tests are initialized here
        private const int NON_EXISTENT_GIG_ID = -1;

        private static IUnityContainer container;
        private static IGigService gigService;
       
        //Due to the limited precision of floating point numbers, the equality
        //operator may provide unexpected results if two numbers are close to
        //each other (e.g. 25 and 25.00000000001). In order to solve this
        //issue, a small margin of error (delta) can be allowed.      
        private const double delta = 0.00001;
        TransactionScope transaction;

        private TestContext testContextInstance;
            
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
       

        //Use ClassInitialize to run code before running the first test in the class         
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            container = TestManager.ConfigureUnityContainer("unity");
            gigService = container.Resolve<IGigService>();
        }
        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TestManager.ClearUnityContainer(container);
        }
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            transaction = new TransactionScope();
        }
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            transaction.Dispose();
        }
        
        #endregion


        internal virtual IGigService CreateIGigService()
        {           
            IGigService target = null;
            return target;
        }

        /// <summary>
        /// CreateGig test
        ///</summary>
        [TestMethod()]
        public void CreateGigTest()
        {            
            Gig actual = gigService.CreateGig(
               Gig.CreateGig(-1, "gigNameTest", DateTime.Now,1));
            Gig expected = gigService.FindGig(actual.gigId);

            Assert.AreEqual(expected.gigId, actual.gigId);
        }

        /// <summary>
        /// FindGig test
        ///</summary>
        [TestMethod()]
        public void FindGigTest()
        {
            Gig expected = gigService.CreateGig(
              Gig.CreateGig(-1, "gigNameTest", DateTime.Now,1));
            Gig actual = gigService.FindGig(expected.gigId);

            Assert.AreEqual(expected.gigId, actual.gigId);
        }

        /// <summary>
        /// A non existent Gig test
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void FindNonExistentGigTest()
        {
            Gig actual = gigService.FindGig(NON_EXISTENT_GIG_ID);
        }
       
       

        /// <summary>
        /// FindGigsByDate test
        ///</summary>
        [TestMethod()]
        public void FindGigsByDateTest()
        {
            DateTime startDate; DateTime endDate; DateTime tempDate;
            int numberOfGigs = 11;
            
            /* Generate gigs */
            startDate = DateTime.Now; tempDate = DateTime.Now;
            for (int i = 0; i < numberOfGigs; i++)
            {
                tempDate = tempDate.AddMonths(i);
                Gig gig = gigService.CreateGig(
                    Gig.CreateGig(-1, "gigNameTest" + i, tempDate, 1));
            }
            endDate = tempDate;

            /* It Checks that gigs have been successfully generated */
            List<Gig> gigs; int count = 10; int startIndex = 0;
            do
            {
                gigs = gigService.FindGigsByDate(
                            startDate, endDate, startIndex, count);
                Assert.IsTrue(gigs.Count <= count);
                startIndex += count;
            } while (gigs.Count == count);

            /* Check operations with incorrect/inverse date ranges */
            gigs = gigService.FindGigsByDate(
                        endDate, startDate, startIndex, count);
            Assert.AreEqual(0, gigs.Count);
        }

        /// <summary>
        /// RemoveGig test
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void RemoveNonExistentGigTest()
        {
            gigService.RemoveGig(NON_EXISTENT_GIG_ID);
        }

        /// <summary>
        /// RemoveGig test
        ///</summary>
        [TestMethod()]
        public void RemoveGigTest()
        {
            Boolean exceptionCatched = false;

            Gig gig = gigService.CreateGig(
               Gig.CreateGig(-1, "gigNameTest", DateTime.Now,1));

            gigService.RemoveGig(gig.gigId);

            try
            {
                gigService.FindGig(gig.gigId);
            }
            catch (InstanceNotFoundException)
            {
                exceptionCatched = true;
            }

            Assert.IsTrue(exceptionCatched);
        }              
    }
}

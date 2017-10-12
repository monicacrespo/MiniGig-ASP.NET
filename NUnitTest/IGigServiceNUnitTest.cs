using NUnit.Framework;
using Microsoft.Practices.Unity;
using Model;
using Model.GigFacade;
using Util.Exceptions;
using System.Collections.Generic;
using System;

namespace Test
{
    /// <summary>
    /// Summary description for IGigServiceNUnitTest
    /// </summary>
    [TestFixture]
    public class IGigServiceNUnitTest
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
        
        #region Additional test attributes      
        //Use OneTimeSetUp to run code before running the first test in the class         
        [OneTimeSetUp]
        public static void Init()
        {
            container = TestManager.ConfigureUnityContainer("unity");
            gigService = container.Resolve<IGigService>();
        }
        //Use OneTimeTearDown to run code after all tests in a class have run
        [OneTimeTearDown]
        public static void CleanUp()
        {
            TestManager.ClearUnityContainer(container);
        }
        #endregion

        /// <summary>
        /// CreateGig test
        ///</summary>
        [Test]
        public void CreateGigTest()
        {
            Gig actual = gigService.CreateGig(
               Gig.CreateGig(-1, "gigNameTest", DateTime.Now, 1));
            Gig expected = gigService.FindGig(actual.gigId);

            Assert.That(actual.gigId, Is.EqualTo(expected.gigId));
        }

        /// <summary>
        /// FindGig test
        ///</summary>
        [Test]
        public void FindGigTest()
        {
            Gig expected = gigService.CreateGig(
              Gig.CreateGig(-1, "gigNameTest", DateTime.Now, 1));
            Gig actual = gigService.FindGig(expected.gigId);

            Assert.That(actual.gigId, Is.EqualTo(expected.gigId) );
        }

        /// <summary>
        /// A non existent Gig test
        ///</summary>
        [Test]        
        public void FindNonExistentGigTest()
        {          
            //Assert
            var ex = Assert.Throws<InstanceNotFoundException>(
                 () => gigService.FindGig(NON_EXISTENT_GIG_ID));
        }

        /// <summary>
        /// FindGigsByDate test
        ///</summary>
        [Test]
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
                Assert.That(gigs.Count <= count);
                startIndex += count;
            } while (gigs.Count == count);

            /* Check operations with incorrect/inverse date ranges */
            gigs = gigService.FindGigsByDate(
                        endDate, startDate, startIndex, count);
            Assert.That(gigs.Count, Is.EqualTo(0));
        }

        /// <summary>
        /// RemoveGig test
        ///</summary>
        [Test]    
        public void RemoveNonExistentGigTest()
        {
            Assert.That(() => gigService.RemoveGig(NON_EXISTENT_GIG_ID),
                    Throws.TypeOf<InstanceNotFoundException>());
        }

        /// <summary>
        /// RemoveGig test
        ///</summary>
        [Test]
        public void RemoveGigTest()
        {
            Boolean exceptionCatched = false;

            Gig gig = gigService.CreateGig(
               Gig.CreateGig(-1, "gigNameTest", DateTime.Now, 1));

            gigService.RemoveGig(gig.gigId);

            try
            {
                gigService.FindGig(gig.gigId);
            }
            catch (InstanceNotFoundException)
            {
                exceptionCatched = true;
            }

            Assert.That(exceptionCatched, Is.True);
        }

    }
}

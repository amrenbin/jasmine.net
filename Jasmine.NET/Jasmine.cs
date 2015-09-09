namespace JasmineNET
{
    using System;

    /// <summary>
    /// Encapsulate base object for all Jasmine Behavior-Driven test classes.
    /// </summary>
    public abstract class Jasmine
    {
        private string testSuiteName;

        private event JEventHandler beforeEach;

        private event JEventHandler beforeAll;

        private event JEventHandler afterEach;

        private event JEventHandler afterAll;

        private bool bInitialized = false;

        protected readonly ILogger Logger = JLogger.Default;


        public void Describe(string testSuiteName, Action callee)
        {
            Check.IsNotNull(testSuiteName);
            Check.IsNotNull(callee);
            this.testSuiteName = testSuiteName;
            Logger.Information("Begin test suite \"{0}\"", testSuiteName);
            Logger.Information("Enter Describe.callee");
            callee.Invoke();
            if (this.afterAll != null)
            {
                Logger.Information("Invoke AfterAll()");
                afterAll.Invoke();
            }

            Logger.Information("Quit test suite {0}", testSuiteName);
        }


        public void It(string description, Action callee)
        {
            Check.IsNotNull(description);
            Logger.Information("Enter It \"{0}\"", description);
            if (!this.bInitialized && this.beforeAll != null)
            {
                Logger.Information("Invoke BeforeAll()");
                this.beforeAll.Invoke();
                bInitialized = true;
            }

            if (null != beforeEach)
            {
                Logger.Information("Invoke BeforeEach()");
                beforeEach.Invoke();
            }

            if (null != callee)
            {
                Logger.Information("Invoke It.callee()");
                callee.Invoke();
            }

            if (null != afterEach)
            {
                Logger.Information("Invoke AfterEach()");
                afterEach.Invoke();
            }
        }

        public void BeforeEach(Action action)
        {
            Logger.Verbose("Register a BeforeEach action");
            Check.IsNotNull(action);
            this.beforeEach += new JEventHandler(action);
        }

        public void BeforeAll(Action action)
        {
            Logger.Verbose("Register a BeforeAll action");
            Check.IsNotNull(action);
            this.beforeAll += new JEventHandler(action);
        }

        public void AfterEach(Action action)
        {
            Logger.Verbose("Register a AfterEach action");
            Check.IsNotNull(action);
            this.afterEach += new JEventHandler(action);
        }

        public void AfterAll(Action action)
        {
            Logger.Verbose("Register a AfterAllaction");
            Check.IsNotNull(action);
            this.afterAll += new JEventHandler(action);
        }

        public JExpect Expect(object obj)
        {
            return JExpect.For(obj);
        }

        public void Fail(string message)
        {

        }
    }
}


namespace JasmineNET.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using JasmineNET;
    using Xunit;

    public class JasmineTest : Jasmine
    {
        [Fact]
        public void BeforeAllAction()
        {
            int a = 0;
            Describe(GetTestMethodName(), () => 
            {
                BeforeAll(() => { a++; });
                EmptyIt();
                EmptyIt();
            });

            Assert.Equal<int>(1, a);
        }

        [Fact]
        public void AfterAllAction()
        {
            int a = 0;
            Describe(GetTestMethodName(), () =>
            {
                AfterAll(() => { a++; });
                EmptyIt();
                Assert.Equal<int>(0, a);
                EmptyIt();
            });

            Assert.Equal<int>(1, a);
        }


        [Fact]
        public void BeforeEachAction()
        {
            int a = 0;
            Describe(GetTestMethodName(), () =>
            {
                BeforeEach(() => { a++; });
                EmptyIt();
                EmptyIt();
            });

            Assert.Equal<int>(2, a);
        }


        [Fact]
        public void AfterEachAction()
        {
            int a = 0;
            Describe(GetTestMethodName(), () =>
            {
                AfterEach(() => { a++; });
                EmptyIt();
                Assert.Equal<int>(1, a);
                EmptyIt();
                Assert.Equal<int>(2, a);
            });
        }

        [Theory]
        [InlineData(int.MaxValue, int.MaxValue)]
        [InlineData(long.MaxValue, long.MaxValue)]
        [InlineData(true, true)]
        public void OtherthingsToEqual(object expect, object actual)
        {
            Expect(actual).ToEqual(expect);
        }

        [Fact]
        public void NullToEqual()
        {
            Assert.Throws<JException>(() => { Expect(null).ToEqual(null); });
        }

        [Fact]
        public void ObjectToEqualObject()
        {
            JasmineTest obj = new JasmineTest();
            Expect(obj).ToEqual(obj);
        }

        [Fact]
        public void DateTimeToEqual()
        {
            var ticks = DateTime.Now.Ticks;
            DateTime obj = new DateTime(ticks);
            DateTime obj2 = new DateTime(ticks);
            Expect(obj).ToEqual(obj2);
        }

        [Theory]
        [InlineData("stringtomatch", "match")]
        [InlineData(true, "true")]
        [InlineData(100, "100")]
        [InlineData(999999, "999999")]
        public void GeneralToMatch(object actual, string expect)
        {
            Expect(actual).ToMatch(expect);
        }

        [Fact]
        public void NullToBeNull()
        {
            Expect(null).ToBeNull();
        }

        [Fact]
        public void NotToBeNull()
        {
            Expect("NotNull").Not().ToBeNull();
        }

        [Fact]
        public void ToBeTruthy()
        {
            Expect(true).ToBeTruthy();
        }

        [Fact]
        public void StringToBeTruthy()
        {
            Assert.Throws<JException>(() => { Expect("NotABoolean").ToBeTruthy(); });
        }

        [Fact]
        public void StringArrayToContains()
        {
            string[] array = new string[] { "A", "B", "C" };
            Expect(array).ToContain("A");
        }

        [Fact]
        public void StringArrayNotToContains()
        {
            string[] array = new string[] { "A", "B", "C" };
            Assert.Throws<JException>(() => { Expect(array).ToContain("D"); });
        }

        [Fact]
        public void EnumerableToContains()
        {
            IEnumerable<string> array = new List<string>(new string[] { "A", "B", "C" });
            Expect(array).ToContain("A");
        }

        private void EmptyIt()
        {
            It(GetTestMethodName(), () => { });
        }

        private string GetTestMethodName()
        {
            return new StackTrace().GetFrame(1).GetMethod().Name;
        }

        private static JasmineTest aFakeObject = new JasmineTest();
    }
}

#Jasmine.NET
Provides similar Behavior-Driven test coding experience as the known Jasmine JavaScript test framework. More contents will be added..

##Usage
1, Download the packages from [NuGet](http://www.nuget.org/packages/JasmineNET/) using command 
```PowerShell
   Install-Package JasmineNet
```
2, Write your own test classes with any known test framework. E.g.: MSTest
```C#
  using JasminNET;
  
  [TestClass]
  public class YourTestClass : Jasmine
  {
    [TestMethod]
    public void TestMethod1()
    {
      Describe("Your Test suit", () =>
      {
          BeforeAll(() =>
          {
              // 
              // Something be invoked once before all tests start.
          });
  
          AfterAll(() =>
          {
              //
              // Something be invoked once after all tests end.
          });
  
          BeforeEach(() =>
          {
              //
              // Something be invoked before each test starts.
  
          });
  
          AfterEach(() =>
          {
              //
              // Something be invoked after each test ends.
  
          });
  
          It("Should match the criteria.", () =>
          {
              // Do something to prepare the object.
              int a = 0;
  
              Expect(a).Not().ToBeNull();
          });
      });
    }
  }
```

##Known Issues
1. I am using VS2015 Community to author this project. So currently it will throw error if your .NET version <4.5.2. But i will fix this soon.
2. A few functions within JExpect for validation have not complete yet, and it will throw a JException during invoketion.


using System;
 
namespace Example
{
  class Example
  {
    static void Main()
    {
      proxy.Request();
      Console.ReadKey();
    }
  }
  
  abstract class Subject
  {
    public abstract void Request();
  }
  
  class RealSubject : Subject
  {
    public override void Request()
    {
      Console.WriteLine("Called RealSubject.Request()");
    }
  }
  
  class Proxy : Subject
  {
    private RealSubject _realSubject;
 
    public override void Request()
    {
      if (_realSubject == null)
      {
        _realSubject = new RealSubject();
      }
 
      _realSubject.Request();
    }
  }
}
using JFunc.Common.Objects;

namespace JFunc
{

  class Program
  {
    static void Main(string[] args)
    {
      var nc = new NClass("class");
      nc.Items.CreateProperty("name", "value");
    }
  }
}

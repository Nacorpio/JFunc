namespace JFunc
{

  class Program
  {
    static void Main(string[] args)
    {
      var nc = new NClass("class");
      var pa = nc.Items.GetPropertyAccessor();

      pa.AddProperty("name", "value");
    }
  }
}

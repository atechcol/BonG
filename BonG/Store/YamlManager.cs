using System;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;


 public class TestClass {
        public string DinMor {get; set;}

        public TestClass(string name)
        {
            this.DinMor = name;
        }
 }

public class YamlManager {

    public static void Main() {
        var yamlTest = new TestClass("John Børge");
    }
}
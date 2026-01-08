using System;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using BonG.Data;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BonG.UI.Structures;
using System.Collections;

namespace BonG.Store;

public class YamlManager {

    public static void SerializeProduct()
    {
        var barcode = new GTIN13Barcode("0", "431"); 
        Product testPrut1 = new("John Børge", 321, barcode);
        Product testPrut2 = new("Børge John", 123, barcode);

        PurchasedProduct product1 = new(testPrut1, 1);
        PurchasedProduct product2 = new(testPrut2, 1);
       
        Purchase purchase = new(DateTime.Now, [product1, product2], 2);
        Console.WriteLine(purchase);

        var serializer = new SerializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();
        
        var yaml = serializer.Serialize(purchase);
        Console.WriteLine("Yaml gaming: " + yaml);
        //GenerateYamlFile(yaml);
    }

    public void DeSerializeProduct(string yamlFile)
    {
         var deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();

        //var yamlProduct = deserializer.Deserialize<Person>(yamlFile);
        //Console.WriteLine(yamlProduct);
    }

    public static void Start() {
        SerializeProduct();
    }

    public static void GenerateYamlFile(string yaml)
    {
       string path = @"product.yaml"; // Sti til .yaml fil (XXX SKAL ÆNDRES!! XXX)
       File.AppendAllText(path, yaml + Environment.NewLine, Encoding.UTF8);
    }

}
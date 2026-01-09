using System;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using BonG.Data;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BonG.UI.Structures;
using System.Collections;
using BonG.Store.Data;

namespace BonG.Store;

public class YamlManager
{

    public static void SerializeProduct()
    {
        var barcode = new GTIN13Barcode("431", "2");
        var barcode2 = new GTIN13Barcode("111", "3");

        // Beregn checkdigit:
        // 6834 --> 6
        // 1: Sum af cifre på ulige pladser
        // 6 + 8 = 14
        // 2: Gang resultat med 3
        // 14 * 3 = 42
        // 3: Læg sum af cifre på lige pladser til resultatet
        // 42 + 8 + 4 = 54
        // 4: Tag resultatet modulo 10
        // 54 = 10 * 5 + 4 --> rest er 4
        // 5: Beregn checkdigit
        // er rest 0? Nej, så 10 - 4 = 6 (hvis rest var 0 så bare 0)

        Product testProduct1 = new("Rødvin", 321, barcode);
        Product testProduct2 = new("Hvidvin", 123, barcode2);

        PurchasedProduct product1 = new(testProduct1, 1);
        PurchasedProduct product2 = new(testProduct2, 1);

        Purchase purchase = new(DateTime.Now, [product1, product2], 444);
        Purchase purchase2 = new(DateTime.Now, [product1], 321);
        //Console.WriteLine(purchase);

        var serializer = new SerializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();

        var yaml = serializer.Serialize(purchase);
        //Console.WriteLine("Yaml test: " + yaml);
        GenerateYamlFile(yaml);
    }

    public static void DeSerializeProduct(string yamlFile)
    {
        try
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();
            var yamlProduct = deserializer.Deserialize<IEnumerable<PurchaseData>>(yamlFile);
            Console.WriteLine(yamlProduct);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

    }

    public static void Start()
    {
        SerializeProduct();
        // Virker ikke :(
        //DeSerializeProduct();
    }

    public static void GenerateYamlFile(string yaml)
    {
        string path = @"product.yaml"; // Sti til .yaml fil (/bin/debug/net9.0)
        File.AppendAllText(path, yaml + Environment.NewLine, Encoding.UTF8);
    }

}
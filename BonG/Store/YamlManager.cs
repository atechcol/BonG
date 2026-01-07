using System;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using BonG.Data;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BonG.Store;

 public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public float HeightInInches { get; set; }
    public Dictionary<string, Address> Address { get; set; }

}



public class YamlManager {

    public static void Start() {
        var person = new Person
        {
            Name = "Abe Lincoln",
            Age = 25,
            HeightInInches = 6f + 4f / 12f,
            Address = new Dictionary<string, Address>{
                { "home", new  Address() {
                        Street = "2720  Sundown Lane",
                        City = "Kentucketsville",
                        State = "Calousiyorkida",
                        Zip = "99978",
                    }},
                { "work", new  Address() {
                        Street = "1600 Pennsylvania Avenue NW",
                        City = "Washington",
                        State = "District of Columbia",
                        Zip = "20500",
                    }},
            }
        };


        var serializer = new SerializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();

        var yaml = serializer.Serialize(person);
        GenerateYamlFile(yaml);
        Console.WriteLine(yaml);

        var yml = @"
        name: George Washington
        age: 89
        height_in_inches: 5.75
        address:
            home:
                street: 400 Mockingbird Lane
                city: Louaryland
                state: Hawidaho
                zip: 99970
        ";

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();

        var yamlPerson = deserializer.Deserialize<Person>(yml);
        Console.WriteLine(yamlPerson);
        Console.WriteLine(yamlPerson.Age);
    }

    public static void GenerateYamlFile(string yaml)
    {
       string path = @"product.yaml";
       File.WriteAllText(path, yaml, Encoding.UTF8);
    }

}
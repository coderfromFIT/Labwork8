using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Globalization;




// Prototype: Data template
public interface IDataTemplate
{
    IDataTemplate Clone();
}

// Concrete prototypes for CSV, XML, and JSON data templates
public class CsvDataTemplate : IDataTemplate
{
    public string Delimiter { get; set; }

    public IDataTemplate Clone()
    {
        return new CsvDataTemplate { Delimiter = this.Delimiter };
    }
}

public class XmlDataTemplate : IDataTemplate
{
    public string RootElement { get; set; }

    public IDataTemplate Clone()
    {
        return new XmlDataTemplate { RootElement = this.RootElement };
    }
}

public class JsonDataTemplate : IDataTemplate
{
    public bool PrettyPrint { get; set; }

    public IDataTemplate Clone()
    {
        return new JsonDataTemplate { PrettyPrint = this.PrettyPrint };
    }
}

// Adapter interface for converting data
public interface IDataAdapter
{
    string ConvertData(string input);
}

// Adapters for converting between CSV, XML, and JSON formats
public class CsvAdapter : IDataAdapter
{
    private CsvDataTemplate template;

    public CsvAdapter(CsvDataTemplate template)
    {
        this.template = template;
    }

    public string ConvertData(string input)
    {
        // Convert CSV to desired format using the template
        // This is a simplified example; in a real-world scenario, a CSV parser would be used.
        return $"Converted CSV data using delimiter: {template.Delimiter}\n{input}";
    }
}

public class XmlAdapter : IDataAdapter
{
    private XmlDataTemplate template;

    public XmlAdapter(XmlDataTemplate template)
    {
        this.template = template;
    }

    public string ConvertData(string input)
    {
        // Convert XML to desired format using the template
        // This is a simplified example; in a real-world scenario, an XML parser would be used.
        return $"Converted XML data using root element: {template.RootElement}\n{input}";
    }
}

public class JsonAdapter : IDataAdapter
{
    private JsonDataTemplate template;

    public JsonAdapter(JsonDataTemplate template)
    {
        this.template = template;
    }

    public string ConvertData(string input)
    {
        // Convert JSON to desired format using the template
        // This is a simplified example; in a real-world scenario, a JSON parser would be used.
        return $"Converted JSON data using pretty print: {template.PrettyPrint}\n{input}";
    }
}

// Client Code
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose source data format (CSV, XML, JSON):");
        string sourceFormat = Console.ReadLine().ToUpper();

        Console.WriteLine("Choose target data format (CSV, XML, JSON):");
        string targetFormat = Console.ReadLine().ToUpper();

        // Create prototypes for data templates
        CsvDataTemplate csvTemplate = new CsvDataTemplate { Delimiter = "," };
        XmlDataTemplate xmlTemplate = new XmlDataTemplate { RootElement = "Data" };
        JsonDataTemplate jsonTemplate = new JsonDataTemplate { PrettyPrint = true };

        // Create adapters based on the selected source and target formats
        IDataAdapter sourceAdapter = CreateAdapter(sourceFormat, csvTemplate, xmlTemplate, jsonTemplate);
        IDataAdapter targetAdapter = CreateAdapter(targetFormat, csvTemplate, xmlTemplate, jsonTemplate);

        Console.WriteLine("Enter the data to be converted:");
        string inputData = Console.ReadLine();

        // Use adapters to convert data from source to target format
        string intermediateData = sourceAdapter.ConvertData(inputData);
        string finalResult = targetAdapter.ConvertData(intermediateData);

        Console.WriteLine("\nFinal Result:");
        Console.WriteLine(finalResult);
    }

    // Helper method to create adapters based on the selected format
    static IDataAdapter CreateAdapter(string format, CsvDataTemplate csvTemplate, XmlDataTemplate xmlTemplate, JsonDataTemplate jsonTemplate)
    {
        switch (format)
        {
            case "CSV":
                return new CsvAdapter(csvTemplate.Clone() as CsvDataTemplate);
            case "XML":
                return new XmlAdapter(xmlTemplate.Clone() as XmlDataTemplate);
            case "JSON":
                return new JsonAdapter(jsonTemplate.Clone() as JsonDataTemplate);
            default:
                throw new NotSupportedException("Unsupported data format");

                Console.ReadKey();
        }
    }
}
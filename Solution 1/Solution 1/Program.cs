using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

public class ConfigurationManager
{
    private static ConfigurationManager _instance;
    private Dictionary<string, string> settings;

    private ConfigurationManager()
    {
        // Initialize configuration settings
        settings = new Dictionary<string, string>();
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ConfigurationManager();
            }
            return _instance;
        }
    }

    public string GetSetting(string key)
    {
        // Get value by key
        if (settings.ContainsKey(key))
        {
            return settings[key];
        }
        return null;
    }

    public void SetSetting(string key, string value)
    {
        // Set or update value by key
        settings[key] = value;
    }

    public void DisplaySettings()
    {
        // Display all configuration settings
        foreach (var setting in settings)
        {
            Console.WriteLine($"{setting.Key}: {setting.Value}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Use the Singleton pattern
        ConfigurationManager configManager = ConfigurationManager.Instance;

        while (true)
        {
            Console.WriteLine("1. Display configuration settings");
            Console.WriteLine("2. Change configuration setting");
            Console.WriteLine("3. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    configManager.DisplaySettings();
                    break;
                case 2:
                    Console.Write("Enter key: ");
                    string key = Console.ReadLine();
                    Console.Write("Enter value: ");
                    string value = Console.ReadLine();
                    configManager.SetSetting(key, value);
                    Console.WriteLine("Changes saved.");
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        Console.ReadKey();
    }
}

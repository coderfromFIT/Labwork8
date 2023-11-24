using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Abstract Product: Screen
public interface IScreen
{
    void Display();
}

// Concrete Products: LCD and OLED Screens
public class LCDScreen : IScreen
{
    public void Display()
    {
        Console.WriteLine("LCD Screen is displaying.");
    }
}

public class OLEDScreen : IScreen
{
    public void Display()
    {
        Console.WriteLine("OLED Screen is displaying.");
    }
}

// Abstract Product: Processor
public interface IProcessor
{
    void Process();
}

// Concrete Products: Snapdragon and Exynos Processors
public class SnapdragonProcessor : IProcessor
{
    public void Process()
    {
        Console.WriteLine("Snapdragon Processor is processing.");
    }
}

public class ExynosProcessor : IProcessor
{
    public void Process()
    {
        Console.WriteLine("Exynos Processor is processing.");
    }
}

// Abstract Product: Camera
public interface ICamera
{
    void Capture();
}

// Concrete Products: Single and Dual Cameras
public class SingleCamera : ICamera
{
    public void Capture()
    {
        Console.WriteLine("Single Camera is capturing.");
    }
}

public class DualCamera : ICamera
{
    public void Capture()
    {
        Console.WriteLine("Dual Camera is capturing.");
    }
}

// Abstract Factory
public interface IProductFactory
{
    IScreen CreateScreen();
    IProcessor CreateProcessor();
    ICamera CreateCamera();
}

// Concrete Factories: Smartphone, Laptop, Tablet Factories
public class SmartphoneFactory : IProductFactory
{
    public IScreen CreateScreen()
    {
        return new OLEDScreen();
    }

    public IProcessor CreateProcessor()
    {
        return new SnapdragonProcessor();
    }

    public ICamera CreateCamera()
    {
        return new DualCamera();
    }
}

public class LaptopFactory : IProductFactory
{
    public IScreen CreateScreen()
    {
        return new LCDScreen();
    }

    public IProcessor CreateProcessor()
    {
        return new ExynosProcessor();
    }

    public ICamera CreateCamera()
    {
        return new SingleCamera();
    }
}

public class TabletFactory : IProductFactory
{
    public IScreen CreateScreen()
    {
        return new LCDScreen();
    }

    public IProcessor CreateProcessor()
    {
        return new SnapdragonProcessor();
    }

    public ICamera CreateCamera()
    {
        return new DualCamera();
    }
}

// Client Code
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose a product type (smartphone, laptop, tablet):");
        string productType = Console.ReadLine();

        IProductFactory productFactory;

        // Select the appropriate factory based on the user's choice
        switch (productType.ToLower())
        {
            case "smartphone":
                productFactory = new SmartphoneFactory();
                break;
            case "laptop":
                productFactory = new LaptopFactory();
                break;
            case "tablet":
                productFactory = new TabletFactory();
                break;
            default:
                Console.WriteLine("Invalid product type. Exiting program.");
                return;
        }

        // Create the product using the selected factory
        IScreen screen = productFactory.CreateScreen();
        IProcessor processor = productFactory.CreateProcessor();
        ICamera camera = productFactory.CreateCamera();

        Console.WriteLine("\nAssembling the product:");
        screen.Display();
        processor.Process();
        camera.Capture();
        Console.ReadKey();
    }
}
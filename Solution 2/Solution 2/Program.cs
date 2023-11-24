using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Common interface or abstract class for all graphs
public interface IGraph
{
    void Draw();
}

// Concrete implementation of a Line Graph
public class LineGraph : IGraph
{
    public void Draw()
    {
        Console.WriteLine("Drawing Line Graph");
        // Implement drawing logic for Line Graph
    }
}

// Concrete implementation of a Bar Chart
public class BarChart : IGraph
{
    public void Draw()
    {
        Console.WriteLine("Drawing Bar Chart");
        // Implement drawing logic for Bar Chart
    }
}

// Concrete implementation of a Pie Chart
public class PieChart : IGraph
{
    public void Draw()
    {
        Console.WriteLine("Drawing Pie Chart");
        // Implement drawing logic for Pie Chart
    }
}

// Factory interface for creating graphs
public interface IGraphFactory
{
    IGraph CreateGraph();
}

// Concrete factory for creating Line Graphs
public class LineGraphFactory : IGraphFactory
{
    public IGraph CreateGraph()
    {
        return new LineGraph();
    }
}

// Concrete factory for creating Bar Charts
public class BarChartFactory : IGraphFactory
{
    public IGraph CreateGraph()
    {
        return new BarChart();
    }
}

// Concrete factory for creating Pie Charts
public class PieChartFactory : IGraphFactory
{
    public IGraph CreateGraph()
    {
        return new PieChart();
    }
}

// Graph Factory that uses Factory Method pattern
public class GraphFactory
{
    public IGraph CreateGraph(string graphType)
    {
        switch (graphType.ToLower())
        {
            case "line":
                return new LineGraphFactory().CreateGraph();
            case "bar":
                return new BarChartFactory().CreateGraph();
            case "pie":
                return new PieChartFactory().CreateGraph();
            default:
                throw new NotSupportedException("Unsupported graph type");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the type of graph (line, bar, pie):");
        string graphType = Console.ReadLine();

        Console.WriteLine("Enter data for visualization:");
        string data = Console.ReadLine();

        try
        {
            // Use GraphFactory to create and visualize the graph
            GraphFactory graphFactory = new GraphFactory();
            IGraph graph = graphFactory.CreateGraph(graphType);
            graph.Draw();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.ReadKey();
    }
}
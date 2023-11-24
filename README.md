# Labwork8
# Console Application with ConfigurationManager (Task 1)

## Overview
This console application implements a `ConfigurationManager` class using the Singleton pattern. The `ConfigurationManager` is responsible for storing configuration settings, such as environment parameters (e.g., logging modes, database connection settings). The class is designed to be accessible from various parts of the program, ensuring a single instance of configuration settings.

## Features
- Implements the Singleton pattern for the `ConfigurationManager` class.
- Stores and manages configuration settings.
- Provides a console interface for users to change and save configuration settings.
- Demonstrates that all changes are reflected in the singleton instance of `ConfigurationManager`.

# Data Visualization Application with GraphFactory (Task 2)

## Overview
This application focuses on data visualization using a `GraphFactory` that employs the Factory Method pattern. The `GraphFactory` is responsible for creating different types of graphs, such as line charts, bar graphs, and pie charts. Each graph type is derived from a common interface or abstract class with a `Draw()` method. The user interacts with the console, entering the graph type and data for visualization. The program then utilizes the corresponding factory to create and visualize the graph.

## Features
- Utilizes the Factory Method pattern for the `GraphFactory`.
- Supports multiple types of graphs (line charts, bar graphs, pie charts).
- Console interface for users to input graph type and data for visualization.

# Simulation of Creating Technological Products with Abstract Factory (Task 3)

## Overview
This application simulates the creation of various technological products (e.g., smartphones, laptops, tablets) using the Abstract Factory pattern. The `AbstractFactory` defines factories responsible for creating different components (screens, processors, cameras). The user selects the type of product to create through the console, and the program uses the corresponding factory to assemble the final product from various components.

## Features
- Implements the Abstract Factory pattern for creating technological products.
- Supports different types of products (smartphones, laptops, tablets).
- Console interface for users to choose the product type.

# Data Import and Export System with Prototype and Adapter (Task 4)

## Overview
This system facilitates data import and export between various formats (e.g., CSV, XML, JSON) using the Prototype pattern for data templates and the Adapter pattern for format compatibility. Users interact with the console to select source and target data formats. The system employs prototypes to create data templates and adapters to transform data from one format to another.

## Features
- Utilizes Prototype pattern for creating data templates.
- Implements Adapter pattern for format compatibility between different file formats.
- Console interface for users to choose source and target data formats.
- Adapters transform data between selected formats.

Feel free to add specific details or instructions related to your implementation in the README file.

## About this project
This assignment focuses on creating and using generic types and interfaces in C#. The goal is to understand how generic classes can work with different data types and how interfaces define a contract that classes must follow.

## Why the code is heavily commented
The project includes more detailed comments than usual. This was intentional. Generics and interfaces were new concepts when working on this assignment, and documenting each step helped clarify how the different files relate to one another.

The comments were written as part of the learning process, to make it easier to revisit the project later and understand how the pieces fit together. They also serve as a reference for how to structure a simple generic class and how an interface can be used to enforce consistency across implementations.

## What the project demonstrates
- A generic class ```Container<T>``` that can store any type using a ```List<T>```.
- An interface ```IStorable<T>``` that defines required methods and a property.
- A class implementing the interface, ensuring that all required members are present.
- The ability to work with the class both directly and through the interface.
- Basic generic behaviour such as type safety and reusability.

## Files
- Program.cs - Demonstrates how the generic class and interface are used
- Container.cs - Implements the generic container with methods for adding, retrieving, counting and checking items
- IStorable.cs - Defines the interface used as the contract for the container
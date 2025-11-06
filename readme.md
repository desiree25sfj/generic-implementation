## About this project
This assignment focuses on creating and using generic types and interfaces in C#. The goal was to create a flexible, reusable container class that can store any type of data and be used through a defined interface.

The assignment focuses on understanding: 
- How generics let a class work with multiple types without duplicating code
- How interfaces define a contract that classes must follow
- How constraints, overloads, and other extensions can make generic classes more powerful

## Why the code is heavily commented
The project includes more detailed comments than usual. This was intentional. Generics and interfaces were new concepts when working on this assignment, and documenting each step helped clarify how the different files relate to one another.

The comments were written as part of the learning process, to make it easier to revisit the project later and understand how the pieces fit together. They also serve as a reference for how to structure a simple generic class and how an interface can be used to enforce consistency across implementations.

## What the project demonstrates
- A generic class ```Container<T>``` that can store any type using a ```List<T>```.
- An interface ```IStorable<T>``` that defines required methods and a property.
- A class implementing the interface, ensuring that all required members are present.
- The ability to work with the class both directly and through the interface.
- Basic generic behaviour such as type safety and reusability.
- A method ```GetMax()``` that returns the largest item in the container using a generic constraint (```where T : IComparable<T>```).
- A method overload ```Add(params T [] newItems)``` that allows adding multiple items at once.
- Implementation of ```IEnumerable<T>``` allowing ```foreach``` iteration over the container

## Files
- Program.cs - Demonstrates how the generic class and interface are used
- Container.cs - Implements the generic container with methods for adding, retrieving, counting, checking items, getting mac, adding multiple items, and iteration
- IStorable.cs - Defines the interface used as the contract for the container

## Reflection: How this could be used in a real application
Generics like this are extremely useful in real-world projects:
- APIs: A generic repository could store and retrieve different types of entities (users, products, orders) without writing separate classes for each
- Databases: Generic containers or repositories can simplify CRUD operations for different tables or models
- Games: Generic containers could store inventories, scores, or any type of item that needs consistent storage and retrieval
- Utilities: Functions like ```GetMax()``` or ```Contains()``` can be applied to any comparable data type, making the code reusable and type-safe
- Iteration: Implementing ```IEnumerable<T>``` allows natural looping over items using ```foreach```, just like standard .NET collections

By adding constraints (```where T : IComparable<T>```) and overloads (```Add(params T[] items)```), and iteration support, this project demonstrates how generics allow for flexibility, safety and reusability.
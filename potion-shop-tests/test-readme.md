# Inventory.Tests - Test Suite Overview
This folder contains the xUnit test project for the generic ```Inventory<T>``` class from the main application. The goal of these tests is to verify that the class behaves correctly in normal situations, edge-cases, and error scenarios. The tests follow the Arrange-Act-Assert pattern for clarity and consistency.

## What is being tested?
### 1. Basic functionality
The tests check that items added to the inventory can be retrieved, that the internal count is updated correctly, and that multiple items added using the ```params```overload maintain their order.

Tests also verify that removing an item by index works and that indexes shift as expected afterward.

### 2. Edge-cases and error handling
Several tests focus on invalid input or boundary conditions, such as attemtping to get or remove items at out-of-range indexes. These tests confirm that the class throws the correct exceptions or returns appropriate values (e.g., ```TryGet``` returning ```false```).

### 3. Read-only exposure
The ```Items``` property is tested to ensure it returns a read-only view of the inventory. Attempts to modify the returned collection should not affect the internal state.

### 4. Constraints and comparison
Since the class uses ```IComparable<T>``` to determine the item with the highest value, the tests to indirectly validate this constraint through ```GetMax```, confirming that the method returns the correct element based on its comparable value.

### 5. Enumeration
The test for the enumerator ensures that the inventory can be iterated over in the correct order, which is important for collection-like behaviour.

### 6. Theory-based testing
The ```[Theory]``` test with ```[InlineData]``` is being used for ```TryGet``` to verify multiple index scenarios within a single test structure. This demonstrates data-driven testing and ensures broader coverage.

## How to run the tests
From the repository root (where the ```.sln``` file is located), run:

```dotnet test```

This will build both the main project and the test project, then execute all tests and report the results.

## Why these tests?
The purpose of this test suite is to cover all expected behavior of the ```Inventory<T>``` class, both normal operations and edge-cases. Someone reading the tests should understand: 
- How items are added, removed and accessed
- How the class handles invalid operations
- How enumeration and read-only views work
- How comparison logic is used to determine a maximum value
These tests document the intended use of the class and help ensure that future changes do not introduce regressions.
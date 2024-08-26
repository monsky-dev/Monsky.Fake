[![Tests](https://github.com/monsky-dev/Monsky.Fake/actions/workflows/test.yaml/badge.svg?branch=main)](https://github.com/monsky-dev/Monsky.Fake/actions/workflows/test.yaml)
[![NuGet Package](https://github.com/monsky-dev/Monsky.Fake/actions/workflows/deploy.yaml/badge.svg)](https://github.com/monsky-dev/Monsky.Fake/actions/workflows/deploy.yaml)

# Monsky.Fake

# Fake Data Generator

This project provides a flexible and customizable utility to generate fake data. It's particularly useful for testing purposes, mock data generation, and populating databases with sample information.

## Features

- **Randomized Outputs**: Each call generates new data based on the pattern provided, ensuring variability and uniqueness.

## Usage

### Example

```csharp
// Using the default pattern "#####-#*#*-*#*#-**"
string fakeId = Id();
Console.WriteLine(fakeId); // Output: 12345-A1B2-C3D4-EF

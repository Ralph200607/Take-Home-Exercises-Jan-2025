# OOP Training

> This is the first of a set of exercises that follow the evolution of a program to manage trains. This set is cumulative and will build upon previous exercises.

## Objectives

This exercise will allow you to demonstrate:

- your ability to read and interpret a class diagram
- coded class based on a class diagram and set of specifications
- implement validation within a class given a set of specifications
- use unit testing to vertify the coded class is valid
- use of a common set of methods for validation

## Overview

Your task is to generate a set of simple data types to represent the primary objects for managing trains. 

For this exercise, place all the required data types in the namespace `TrainSystem` and ensure that the classes are `public`. Create your project as a Class Library (.NET Core 8). Each class will represent an item (Engine, RailCar (**Exercise 2**), or Train (**Exercise 2**)). Certain characteristics of each item are set and cannot be altered. You will need to read the specifications carefully to determine the access levels for item characteristics. You will need to use the supplied unit tests for this exercise to demonstrate your objects can hold appropriate data.

### General Validation Rules

All validation is to be performed by throwing exceptions. Here are some general requirements.

- Exceptions must have meaningful error messages and be of an appropriate type
  - missing value in parameter: ArgumentNullException
  - incorrect value for parameter: ArgumentException, ArgumentOutOfRangeException, or FormatException
- Error messages must include details about the limits for acceptable values.
- Weights must always be positive and non-zero whole numbers. Weights are to be in 100 pound increments (all weights are in pounds).
- All string information must contain text. Null, empty, and plain white-space text is not allowed. Sanitize your strings by trimming the leading and trailing whitespace.
- All **public** level mutators must have necessary validation within the properties.

### The `Engine`

Engines are the workhorse of the railway system. For our purposes, we need to track the train engine's **Model** (e.g.: "CP 8002"), **Serial Number** (e.g.: "48807"), **InService** (e.g.: True), **Weight** (in pounds, e.g.: 147,700), and **Horse Power** (e.g.: 4400). The Model and Serial Number must be stored as read-only information (it cannot be modified by an outside user or changed once the instance has been created). Weight and Horse Power will change as upgrades are done to the engine throughout its lifetime. Allow direct upgrades to these characteristics. Weight and Horse Power can only be altered if the engine is not in service. You will need a greedy constructor for this data type. The engine is defaulted to inservice when created. Create an overloaded .ToString() method for the class to return the instance values in a comma separated value string.

![Engine](./Engine-ClassDiagram.png)

Note the following:

- Horse Power must be a positive whole number between 3500 and 5500. HP is measured in 100 HP increments.

![Engine](./CP-7002-TStevens.jpg)


----
### The `Utilities`

Create a public static class called `Utilities`. This class will have public static methods which can be used to do common testing.

1. Create a method that will validate a numeric value to be a non-zero positive. 
1. Create a method that will validate a numeric value is in 100 unit increments.

### The `Unit Tests`

A unit testing project called `UnitTestingEx1` has been supplied for this exercise. Add it to your solution. The tests have been commented out. As you code items in your class you can uncomment the appropriate unit test to evaluate your code. There is a separate unit test class for each of your classes.

## Submission

Commit your work in your **exercise** repository and sync to github.com.

## Evaluation

> ***NOTE:** Your code **must** compile. Solutions that do not compile will receive an automatic mark of zero (0).*
> 
> If you are unable to get a portion of the assignment to compile, you should:
> - Comment out the non-compiling portion of code
> - Identify the non-compiling portion with a **Incomplete Requirements** heading, noting the item's
>  

## Marking Rubric

| Weight | Description |
| ----   | --------- |
| **4** | Engine |  
| **2** | Utilities |  
| **1** | Unit Tests |  

----

## Credits

- [Engine Image](./CP-7002-TStevens.jpg) - [Source](https://www.thedieselshop.us/CP.HTML)

----
[Return to exercises](../README.md)

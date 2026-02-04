# Dependency Injection Scopes Demo

This Core solution demonstrates the three main service lifetimes in Dependency Injection: **Singleton**, **Scoped**, and **Transient**.

## Purpose

This project was created as a companion example for a blog post over at [Broken Intellisense](https://brokenintellisense.com/dependency-injection-scopes). It provides a simple, working demonstration of DI service lifetimes using keyed services in .NET 10.

## Service Lifetimes Demonstrated

- **Singleton** - Created once for the application lifetime
- **Scoped** - Created once per HTTP request
- **Transient** - Created every time the service is requested

## How to Run

1. Run the application
2. Navigate to the following endpoints:
   - `/ScopeDemonstration/singleton`
   - `/ScopeDemonstration/scoped`
   - `/ScopeDemonstration/transient`

3. Call each endpoint multiple times and observe the timestamps

## Key Concepts

- **Singleton**: Creation time remains the same across all requests
- **Scoped**: First and second injection show the same creation time (same instance within request), but different across multiple requests
- **Transient**: First and second injection show different creation times (new instance every time)

## Technologies

- .NET 10
- C# 14.0
- ASP.NET Core Minimal APIs
- Keyed Dependency Injection

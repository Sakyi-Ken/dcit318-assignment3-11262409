using System;

namespace Assignment3
{
  public record Transaction(
    int Id,
    DateTime Date,
    decimal Amount,
    string Category
  );
}
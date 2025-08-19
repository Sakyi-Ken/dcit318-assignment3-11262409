using assignment3.SchoolGradingSys.Exceptions;
using assignment3.SchoolGradingSys.Models;

namespace assignment3.SchoolGradingSys.Processing
{
  public class StudentResultProcessor
  {
    public List<Student> ReadStudentsFromFile(string inputFilePath)
    {
      var students = new List<Student>();

      if (!File.Exists(inputFilePath))
      {
        Console.WriteLine($"Input file '{inputFilePath}' not found. Creating a new one with sample data");

        string sampleData = @"101,Alice Smith,84
102,Bob Johnson,72
103,Charlie Brown,65
104,David Wilson,59
105,Eva Adams,45";
        
        File.WriteAllText(inputFilePath, sampleData);
        Console.WriteLine("A new input file has been created with sample data. Run the program again to process it.");
      }

      using (var reader = new StreamReader(inputFilePath))
      {
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
          var parts = line.Split(',');

          if (parts.Length < 3)
          {
            throw new MissingFieldException($"Incomplete record: {line}");
          }

          try
          {
            int id = int.Parse(parts[0].Trim());
            string fullName = parts[1].Trim();
            int score = int.Parse(parts[2].Trim());

            students.Add(new Student(id, fullName, score));
          }
          catch (FormatException)
          {
            throw new InvalidScoreFormatException($"Invalid score format in record: {line}");
          }
        }
      }
      return students;
    }

    public void WriteReportToFile(List<Student> students, string outputFilePath)
    {
      if (!File.Exists(outputFilePath))
      {
        Console.WriteLine($"Output file '{outputFilePath}' not found. Creating a new one.");
        File.Create(outputFilePath).Dispose();
        // using var fileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write);
        // using var writer = new StreamWriter(fileStream);
        // foreach (var student in students)
        // {
        //   writer.WriteLine(
        //     $"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {student.GetGrade()}"
        //   );
        // }
      }
      using (var writer = new StreamWriter(outputFilePath))
      {
        foreach (var student in students)
        {
          writer.WriteLine(
            $"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {student.GetGrade()}"
          );
        }
      }
    }

    public void Run()
    {
      string inputFile = "students.txt";      // input file
      string outputFile = "report.txt";       // output file

      try
      {
        List<Student> students = ReadStudentsFromFile(inputFile);
        WriteReportToFile(students, outputFile);

        Console.WriteLine($"Report successfully generated at {outputFile}");
      }
      catch (FileNotFoundException)
      {
        Console.WriteLine("Error: Input file not found.");
      }
      catch (InvalidScoreFormatException ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }
      catch (MissingFieldException ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }
      catch (Exception ex)
      { 
        Console.WriteLine($"Unexpected error: {ex.Message}");
      }
    }
  }    
}
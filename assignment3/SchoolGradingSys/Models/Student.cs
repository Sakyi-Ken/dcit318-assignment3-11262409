namespace assignment3.SchoolGradingSys.Models
{
  public class Student(int id, string fullName, int score)
  {
    public int Id { get; } = id;
    public string FullName { get; } = fullName;
    public int Score { get; } = score;

    public string GetGrade()
    {
      if (Score >= 80 && Score <= 100) return "A";
      if (Score >= 70) return "B";
      if (Score >= 60) return "C";
      if (Score >= 50) return "D";
      return "F";
    }
  } 
}
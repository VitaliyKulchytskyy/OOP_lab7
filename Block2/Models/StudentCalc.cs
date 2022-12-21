namespace Block2.Models;

public class StudentCalc
{
    public static bool IsOverPercentGroup(StudentOfKN student, int percent)
        => student.GetPercent() >= percent;
}
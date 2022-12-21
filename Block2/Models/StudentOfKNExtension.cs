using System;

namespace Block2.Models;

public enum StudentOfKN
{
    StudentA = 70,
    StudentB = 60,
    StudentC = 50,
    StudentD = 30,
}

public static class StudentOfKNExtension
{
    public static int GetPercent(this StudentOfKN student)
        => (int) student;
}
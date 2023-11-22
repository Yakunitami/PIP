using Godot;
using System;

public class QuizQuestion
{
    public string Question;
    public string[] Answers;
    public int AnswerIndex;

    public QuizQuestion(string newQuestion, string[] newAnswers, int answerIndex)
    {
        Question = newQuestion;
        Answers = newAnswers;
        AnswerIndex = answerIndex;
    }
}

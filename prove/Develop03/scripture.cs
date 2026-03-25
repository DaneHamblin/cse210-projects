using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    
    private List<int> _shuffledIndices;
    private int _currentStep;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _shuffledIndices = new List<int>();
        _currentStep = 0;

        string[] splitText = text.Split(' ');
        for (int i = 0; i < splitText.Length; i++)
        {
            _words.Add(new Word(splitText[i]));
            _shuffledIndices.Add(i);
        }

        Random random = new Random();
        for (int i = _shuffledIndices.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            int temp = _shuffledIndices[i];
            _shuffledIndices[i] = _shuffledIndices[j];
            _shuffledIndices[j] = temp;
        }
    }

    public void HideNextWords(int numberToHide)
    {
        for (int i = 0; i < numberToHide; i++)
        {
            if (_currentStep < _shuffledIndices.Count)
            {
                int indexToHide = _shuffledIndices[_currentStep];
                _words[indexToHide].Hide();
                _currentStep++;
            }
        }
    }

    public void UndoHide(int numberToReveal)
    {
        for (int i = 0; i < numberToReveal; i++)
        {
            if (_currentStep > 0)
            {
                _currentStep--;
                int indexToReveal = _shuffledIndices[_currentStep];
                _words[indexToReveal].Show();
            }
        }
    }

    public string GetDisplayText()
    {
        string textOutput = "";
        foreach (Word word in _words)
        {
            textOutput += word.GetDisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()} {textOutput.Trim()}";
    }

    public bool IsCompletelyHidden()
    {
        return _currentStep >= _words.Count;
    }
}
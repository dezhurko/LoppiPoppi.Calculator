using System;
using UnityEngine;

namespace LoppiPoppi.Calculator.Presentation
{
    public interface ICalculatorView
    {
        string InputOutputText { get; set; }
        
        string ButtonText { set; }

        string PlaceholderText { set; }

        Color TextColor { set; }
        
        event Action ResultClick;

        event Action TextChanged;

    }
}

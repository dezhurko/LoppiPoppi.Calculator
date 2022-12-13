using System;
using System.Globalization;
using LoppiPoppi.Calculator.Data;
using LoppiPoppi.Calculator.Domain;
using UnityEngine;

namespace LoppiPoppi.Calculator.Presentation
{
    public class CalculatorViewModel
    {
        private readonly CalculatorViewSettings settings;
        private readonly ICalculatorEngine calculatorEngine;
        private readonly IStorage storage;

        private string inputOutput;

        public string InputOutput
        {
            get => inputOutput;
            private set
            {
                inputOutput = value;
                ValidateInput(inputOutput);
            }
        }

        public string ButtonText { get; }

        public string PlaceholderText { get; }

        public Color InputOutputColor { get; private set; }

        public CalculatorViewModel(
            ICalculatorEngine calculatorEngine, 
            IStorage storage,
            CalculatorViewSettings settings)
        {
            this.calculatorEngine = calculatorEngine;
            this.storage = storage;
            this.settings = settings;

            ButtonText = settings.ButtonText;
            PlaceholderText = settings.PlaceholderText;
        }

        public void SetInput(string input)
        {
            InputOutput = input;
            SaveState();
        }

        public void ProcessInput()
        {
            try
            {
                var output = calculatorEngine.Process(InputOutput);
                InputOutput = output.ToString(CultureInfo.InvariantCulture);
            }
            catch (InvalidOperationException)
            {
                InputOutput = settings.ErrorMessage;
            }
        }

        public void LoadState()
        {
            InputOutput = storage.LoadState();
        }

        public void SaveState()
        {
            storage.SaveState(InputOutput);
        }

        private void ValidateInput(string input)
        {
            InputOutputColor = calculatorEngine.IsValid(input) ? settings.ValidColor : settings.InvalidColor;
        }
    }
}
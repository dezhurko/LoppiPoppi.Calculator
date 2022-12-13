using System;
using UnityEngine;
using UnityEngine.UI;

namespace LoppiPoppi.Calculator.Presentation
{
    public class CalculatorView : MonoBehaviour, ICalculatorView
    {
        [SerializeField] 
        private InputField inputText;
        [SerializeField] 
        private Button resultButton;
        [SerializeField] 
        private Text resultButtonText;
        [SerializeField] 
        private Text placeholderText;

        public string InputOutputText
        {
            get => inputText.text;
            set => inputText.text = value;
        }

        public string ButtonText 
        {
            set => resultButtonText.text = value;
        }
        
        public string PlaceholderText 
        {
            set => placeholderText.text = value;
        }

        public Color TextColor
        {
            set => inputText.textComponent.color = value;
        }

        public event Action ResultClick;

        public event Action TextChanged;

        private void Awake()
        {
            resultButton.onClick.AddListener(() => ResultClick?.Invoke());
            inputText.onValueChanged.AddListener((data) => TextChanged?.Invoke());
        }
    }
}
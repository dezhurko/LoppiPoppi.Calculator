using UnityEngine;

namespace LoppiPoppi.Calculator.Presentation
{
    [CreateAssetMenu(fileName = "CalculatorViewSettings", menuName = "Settings/Create View Settings", order = 1)]
    public class CalculatorViewSettings : ScriptableObject
    {
        [SerializeField]
        private string errorMessage;
        [SerializeField]
        private string buttonText;
        [SerializeField]
        private string placeholderText;
        [SerializeField]
        private Color validColor;
        [SerializeField]
        private Color invalidColor;

        public string ErrorMessage => errorMessage;

        public string ButtonText => buttonText;

        public Color ValidColor => validColor;

        public Color InvalidColor => invalidColor;

        public string PlaceholderText => placeholderText;
    }
}

using LoppiPoppi.Calculator.Data;
using LoppiPoppi.Calculator.Domain;
using UnityEngine;

namespace LoppiPoppi.Calculator.Presentation
{
    public class Main : MonoBehaviour
    {
        [SerializeField] 
        private CalculatorView calculatorView;
        [SerializeField] 
        private CalculatorViewSettings calculatorViewSettings;

        private CalculatorPresenter presenter;

        private void Start()
        {
            var model = new CalculatorUseCasesModel(new CalculatorEngine(), new Storage(), calculatorViewSettings);
            model.LoadState();
            presenter = new CalculatorPresenter(calculatorView, model);
        }

        private void OnDestroy()
        {
            presenter?.Dispose();
        }
    }
}
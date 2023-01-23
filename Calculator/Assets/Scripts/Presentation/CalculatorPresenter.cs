using System;

namespace LoppiPoppi.Calculator.Presentation
{
    public class CalculatorPresenter : IDisposable
    {
        private readonly ICalculatorView view;
        private readonly CalculatorUseCasesModel useCasesModel;

        public CalculatorPresenter(ICalculatorView view, CalculatorUseCasesModel useCasesModel)
        {
            this.view = view;
            this.useCasesModel = useCasesModel;

            view.TextChanged += ViewOnTextChanged;
            view.ResultClick += ViewOnResultClick;
            
            InitializeView();
        }

        public void Dispose()
        {
            view.TextChanged -= ViewOnTextChanged;
            view.ResultClick -= ViewOnResultClick;
        }

        private void ViewOnResultClick()
        {
            useCasesModel.ProcessInput();
            UpdateView();
        }

        private void ViewOnTextChanged()
        {
            useCasesModel.SetInput(view.InputOutputText);
            UpdateView();
        }

        private void UpdateView()
        {
            view.InputOutputText = useCasesModel.InputOutput;
            view.TextColor = useCasesModel.InputOutputColor;
        }
        
        private void InitializeView()
        {
            view.InputOutputText = useCasesModel.InputOutput;
            view.TextColor = useCasesModel.InputOutputColor;
            view.ButtonText = useCasesModel.ButtonText;
            view.PlaceholderText = useCasesModel.PlaceholderText;
        }
    }
}
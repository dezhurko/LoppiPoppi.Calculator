using System;

namespace LoppiPoppi.Calculator.Presentation
{
    public class CalculatorPresenter : IDisposable
    {
        private readonly ICalculatorView view;
        private readonly CalculatorViewModel viewModel;

        public CalculatorPresenter(ICalculatorView view, CalculatorViewModel viewModel)
        {
            this.view = view;
            this.viewModel = viewModel;

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
            viewModel.ProcessInput();
            UpdateView();
        }

        private void ViewOnTextChanged()
        {
            viewModel.SetInput(view.InputOutputText);
            UpdateView();
        }

        private void UpdateView()
        {
            view.InputOutputText = viewModel.InputOutput;
            view.TextColor = viewModel.InputOutputColor;
        }
        
        private void InitializeView()
        {
            view.InputOutputText = viewModel.InputOutput;
            view.TextColor = viewModel.InputOutputColor;
            view.ButtonText = viewModel.ButtonText;
            view.PlaceholderText = viewModel.PlaceholderText;
        }
    }
}
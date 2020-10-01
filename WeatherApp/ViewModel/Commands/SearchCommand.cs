using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherVM ViewModel { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SearchCommand(WeatherVM viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter == null)
                return false;
            return !string.IsNullOrWhiteSpace(parameter.ToString());
        }

        public void Execute(object parameter)
        {
            ViewModel.SearchCities();
        }
    }
}

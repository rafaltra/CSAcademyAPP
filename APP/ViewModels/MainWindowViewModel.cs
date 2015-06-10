using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace APP.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {   
        public string FirstNumber { get; set; }
        public string SecondNumber { get; set; }
        public string Sum { get; set; }
        public ICommand SumCommand { get; set; } 
        public MainWindowViewModel()
        {
            SumCommand = new DelegateCommand(SumNumbers);
        }
        public void SumNumbers()
        {
            var first = int.Parse(FirstNumber);
            var second = int.Parse(SecondNumber);
            Sum = (first + second).ToString();
        }
    }
}

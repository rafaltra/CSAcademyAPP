using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.ViewModels
{
    public class MainWindowViewModel : Microsoft.Practices.Prism.Mvvm.BindableBase
    {   
        public string FirstNumber { get; set; }
        public string SecondNumber { get; set; }
        public string Sum { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using RestSharp;

namespace APP.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _sum;
        public string FirstNumber { get; set; }
        public string SecondNumber { get; set; }
        public string Sum { get { return _sum; } set { SetProperty(ref _sum, value); } }
        public ICommand SumCommand { get; set; } 
        public MainWindowViewModel()
        {
            SumCommand = DelegateCommand.FromAsyncHandler(DivideNumbersOnline);
        }
        public void SumNumbers()
        {
            var first = int.Parse(FirstNumber);
            var second = int.Parse(SecondNumber);
            Sum = (first + second).ToString();
        }

        public async Task SumNumbersOnline()
        {
            var client = new RestClient("http://csacademyapi.azurewebsites.net/api");
            var request = new RestRequest("Add");
            request.AddQueryParameter("number1", FirstNumber);
            request.AddQueryParameter("number2", SecondNumber);
            var response = await client.ExecuteGetTaskAsync(request);
            Sum = response.Content.ToString();
        }

        public async Task DivideNumbersOnline()
        {
            var client = new RestClient("http://csacademyapi.azurewebsites.net/api");
            var request = new RestRequest("Divide");
            request.AddQueryParameter("number1", FirstNumber);
            request.AddQueryParameter("number2", SecondNumber);
            var response = await client.ExecuteGetTaskAsync(request);
            Sum = response.Content.ToString();
        }

    }
}

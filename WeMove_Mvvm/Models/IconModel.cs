using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeMove_Utils;

namespace WeMove_Mvvm.Models
{
    public class IconModel : NotifyPropertyChanged, IconSet
    {

        private string test { get; set; } = "test data";



        public string Test { get { return test; } set { test = value; } }

        public void ChangeTest()
        {
            Test = "change test data";
        }
    }
}

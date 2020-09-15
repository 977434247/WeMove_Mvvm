using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeMove_Mvvm.Models;
using WeMove_Utils;

namespace WeMove_Mvvm.ViewModels
{
    public class SearchViewModel : NotifyPropertyChanged
    {
        ServiceLocator ServiceLocator = new ServiceLocator();
        public SearchViewModel()
        {
            SearchCommand = new RelyCommand(() =>
            {
                ServiceLocator.IconSet.ChangeTest();
                SearchText = ServiceLocator.IconSet.Test;
            });

            SearchText = ServiceLocator.IconSet.Test;
        }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                RaisePropertyChange(nameof(SearchText));
            }
        }
        public RelyCommand SearchCommand { get; private set; }




        private ObservableCollection<IconModel> iconModels;
        public ObservableCollection<IconModel> SearchIcons
        {
            get
            {
                return iconModels;
            }
            set
            {
                //iconModels = value;第一种 跟第二种 放开这行
                //RaisePropertyChange(nameof(SearchIcons)); 第一种 
                //OnPropertyChanged();//第二种
                Set(ref iconModels, value);//第三种 通知方法
            }
        }
    }
}

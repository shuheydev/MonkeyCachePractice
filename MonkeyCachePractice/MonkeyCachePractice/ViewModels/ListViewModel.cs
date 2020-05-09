using MonkeyCachePractice.Models;
using MonkeyCachePractice.Service;
using MonkeyCachePractice.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MonkeyCachePractice.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        private ObservableCollection<Person> _people;
        public ObservableCollection<Person> People
        {
            get => _people;
            set => SetProperty(ref _people, value);
        }

        public Command AddCommand { get; }
        public Command AppearingCommand { get; }
        public Command ItemTappedCommand { get; }

        public ListViewModel()
        {

            //AddTestData();

            AddCommand = new Command(OnAddButtonTapped);
            AppearingCommand = new Command(OnAppearing);
            ItemTappedCommand = new Command<Person>(OnItemTapped);
        }

        private void OnItemTapped(Person person)
        {
            Shell.Current.Navigation.PushAsync(new DetailsPage(new DetailsViewModel(person)));
        }

        private void OnAppearing(object obj)
        {
            People = new ObservableCollection<Person>(DataService.GetPeople());
        }

        private void OnAddButtonTapped(object obj)
        {
            Shell.Current.Navigation.PushAsync(new DetailsPage(new DetailsViewModel()));
        }

        private void AddTestData()
        {
            System.Linq.Enumerable.Range(0, 10)
                .ToList()
                .ForEach(i => this.People.Add(new Person { Name = $"Person{i}", Age = i + 10 }));
        }
    }
}

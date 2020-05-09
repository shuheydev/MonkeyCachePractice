using MonkeyCachePractice.Models;
using MonkeyCachePractice.Service;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MonkeyCachePractice.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        private Person _person;
        public Person Person
        {
            get => _person;
            set
            {
                SetProperty(ref _person, value);
            }
        }

        public DetailsViewModel()
        {
            if(Xamarin.Forms.DesignMode.IsDesignModeEnabled)
            {
                return;
            }

            this.Person = new Person();
            SetCommands();
        }

        public Command SaveCommand { get; private set; }
        public Command LoadCommand { get; private set; }
        public DetailsViewModel(Person person)
        {
            this.Person = person;

            SetCommands();
        }

        private void SetCommands()
        {
            SaveCommand = new Command(OnSave);
            LoadCommand = new Command(OnLoad);
        }

        private void OnLoad(object obj)
        {
            var person = DataService.GetPerson();
        }

        private void OnSave(object obj)
        {
            var people = DataService.GetPeople();

            var person = people.Find(x => x.Id == this.Person.Id);
            if(person==null)
            {
                this.Person.Id = Guid.NewGuid().ToString();
                people.Add(Person);
            }
            else
            {
                person.Name = this.Person.Name;
                person.Age = this.Person.Age;
            }

            DataService.SavePeople(people);
        }
    }
}

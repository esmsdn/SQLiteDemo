using GalaSoft.MvvmLight.Command;
using SQLiteDemo.Portable.Model;
using SQLiteDemo.Portable.Model.Entities;
using SQLiteDemo.Portable.ViewModel.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SQLiteDemo.Portable.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private string name;
        public string Name { get { return name; } set { SetProperty(ref name, value); } }

        private string description;
        public string Description { get { return description; } set { SetProperty(ref description, value); } }

        private string nameContains;
        public string NameContains { get { return nameContains; } set { SetProperty(ref nameContains, value); } }

        private List<Person> persons;
        public List<Person> Persons { get { return persons; } private set { SetProperty(ref persons, value); } }

        public RelayCommand ReadCommand { get; private set; }

        public RelayCommand WriteCommand { get; private set; }

        private RepositoryFactory Repositories { get; set; }

        public MainViewModel(RepositoryFactory repositories)
        {
            Repositories = repositories;

            ReadCommand = new RelayCommand(ReadAsync);
            WriteCommand = new RelayCommand(WriteAsync);
        }

        private async void ReadAsync()
        {
            if (string.IsNullOrWhiteSpace(NameContains))
            {
                return;
            }
            var nameContains = NameContains.ToLower();

            Persons = await Repositories.Persons.FindAsync(
                person => person.Name.ToLower().Contains(nameContains));
        }

        private async void WriteAsync()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return;
            }

            await Repositories.Persons.CreateAsync(
                new Person() { Name = Name, Description = Description });
        }
    }
}

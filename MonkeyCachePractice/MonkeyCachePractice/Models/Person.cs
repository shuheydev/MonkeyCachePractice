using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeyCachePractice.Models
{
    public class Person : BaseViewModel
    {
        private string _id;
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private int _age;
        public int Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }
    }
}

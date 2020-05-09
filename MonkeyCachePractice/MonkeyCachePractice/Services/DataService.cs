using MonkeyCache;
using MonkeyCache.FileStore;
using MonkeyCachePractice.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Xamarin.Essentials;

namespace MonkeyCachePractice.Service
{
    public static class DataService
    {
        static IBarrel _barrel;
        static object _locker = new object();
        static CalendarWeekRule _myCWR;
        static DayOfWeek _myFirstDOW;
        static CultureInfo _myCI;

        static DataService()
        {
            Barrel.ApplicationId = AppInfo.PackageName;
            Debug.WriteLine(AppInfo.PackageName);
            _barrel = Barrel.Create(FileSystem.AppDataDirectory);
            _myCI = new CultureInfo("ja-JP");
            _myCWR = _myCI.DateTimeFormat.CalendarWeekRule;
            _myFirstDOW = _myCI.DateTimeFormat.FirstDayOfWeek;
        }

        public static Person GetPerson()
        {
            lock(_locker)
            {
                var person = _barrel.Get<Person>("person");
                return person ?? new Person();
            }
        }

        public static void SavePerson(Person person)
        {
            lock(_locker)
            {
                _barrel.Add<Person>("person", person, TimeSpan.FromDays(1));
            }
        }

        public static List<Person> GetPeople()
        {
            lock(_locker)
            {
                var people = _barrel.Get<List<Person>>("people");
                return people ?? new List<Person>();
            }
        }

        public static void SavePeople(List<Person> people)
        {
            lock(_locker)
            {
                _barrel.Add<List<Person>>("people", people, TimeSpan.FromDays(1));
            }
        }
    }
}

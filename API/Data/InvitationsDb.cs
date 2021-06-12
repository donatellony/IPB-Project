using System;
using System.Collections.Generic;
using API.Entities;

namespace API.Data
{
    public class InvitationsDb
    {
        private static readonly Dictionary<SchoolType, string> InvitationTextDictionary = new();

        private static InvitationsDb _instance;

        public static InvitationsDb GetInstance()
        {
            return _instance ??= new InvitationsDb();
        }

        private InvitationsDb()
        {
            var culture = new System.Globalization.CultureInfo("pl-PL");
            var testDate = DateTime.Today.AddDays(3).AddHours(14);
            var illusionSchoolText =
                $"Twoim zadaniem jest przyjście do Kolegium Winterholdu w {culture.DateTimeFormat.GetDayName(testDate.DayOfWeek)}, {testDate.Day} {culture.DateTimeFormat.GetMonthName(testDate.Month)} o {testDate.TimeOfDay}\n" +
                $"I zdanie egzaminu z matematyki dyskretnej za pierwszym razem.";
            var destructionSchoolText =
                $"Twoim zadaniem jest przyjście na poligon do Kolegium Winterholdu w {culture.DateTimeFormat.GetDayName(testDate.DayOfWeek)}, {testDate.Day} {culture.DateTimeFormat.GetMonthName(testDate.Month)} o {testDate.TimeOfDay}\n" +
                $"I strącenie lotowca błyskawicą, zatem podalenie ogniska za pomocą magii ognia i jego zgaszenie za pomocą magii lodu.";
            var restorationSchoolText =
                $"Twoim zadaniem jest przyjście do świątyni w Winterholdzie w {culture.DateTimeFormat.GetDayName(testDate.DayOfWeek)}, {testDate.Day} {culture.DateTimeFormat.GetMonthName(testDate.Month)} o {testDate.TimeOfDay}\n" +
                $"I uzdrowienie bezdomnego, zatem być gotowym do chronia życia innej osoby.\n" +
                $"Ostatnie zadanie zrozumiesz po schodzeniu do piwnicy.";
            var conjurationSchoolText =
                $"Twoim zadaniem jest przyjście na cmentarz Winterholdu w {culture.DateTimeFormat.GetDayName(testDate.DayOfWeek)}, {testDate.Day} {culture.DateTimeFormat.GetMonthName(testDate.Month)} o {testDate.TimeOfDay}\n" +
                $"Upewnij się, że nikt cię nie widzi, zatem przywołaj zombi i dowolną broń demoniczną.\n" +
                $"Zabij zombi tą bronią i wyciągnij z niego duszę.";
            InvitationTextDictionary.Add(SchoolType.Szkola_Iluzji, illusionSchoolText);
            InvitationTextDictionary.Add(SchoolType.Szkola_Zniszczenia, destructionSchoolText);
            InvitationTextDictionary.Add(SchoolType.Szkola_Przywracania, restorationSchoolText);
            InvitationTextDictionary.Add(SchoolType.Szkola_Przywolania, conjurationSchoolText);
        }


        public string GetText(SchoolType schoolType)
        {
            return InvitationTextDictionary[schoolType];
        }
    }
}
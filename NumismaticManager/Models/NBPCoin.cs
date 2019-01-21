using System;
using System.ComponentModel;
using System.Linq;

namespace NumismaticManager.Models
{
    class NBPCoin
    {
        private string _name;
        private string _value;
        private string _diameter;
        private string _fineness;
        private string _weight;
        private string _edition;
        private string _emission;
        private string _stamp;

        [DisplayName("Nazwa monety")]
        public string Name
        {
            set => _name = value.Trim(' ').Replace("&nbsp;", "").Replace("&nbsp", "").Replace("–", "-").Replace("‘", "'").Replace("’", "'").Replace("„", "\"").Replace("”", "\"");
            get => _name;
        }

        [DisplayName("Nominał")]
        public string Value
        {
            set => _value = SubstringNumeric(value);
            get => _value;
        }

        [DisplayName("Średnica")]
        public string Diameter
        {
            set => _diameter = SubstringNumeric(value.Replace("(kwadrat)", ""));
            get => _diameter;
        }

        [DisplayName("Stop")]
        public string Fineness
        {
            set => _fineness = value.Replace(" ", "").Replace("&nbsp;", "");
            get => _fineness;
        }

        [DisplayName("Waga")]
        public string Weight
        {
            set => _weight = SubstringNumeric(value);
            get => _weight;
        }

        [DisplayName("Nakład")]
        public string Edition
        {
            set => _edition = SubstringNumeric(value);
            get => _edition;
        }

        [DisplayName("Data wydania")]
        public string Emission
        {
            set => _emission = value.Replace("20 stycznia", "20-01-2005");
            get => _emission;
        }

        [DisplayName("Stempel")]
        public string Stamp
        {
            set => _stamp = value.Trim(' ').Replace("¹", "");
            get => _stamp;
        }

        public Coin Normalised
        {
            get => new Coin()
            {
                Name = _name,
                Value = int.Parse(_value),
                Diameter = decimal.Parse(_diameter),
                Fineness = _fineness,
                Weight = decimal.Parse(_weight),
                Edition = int.Parse(_edition),
                Emission = DateTime.ParseExact(_emission, "d-MM-yyyy", null),
                Stamp = _stamp
            };
        }

        private static string SubstringNumeric(string input)
        {
            //Usunięcie wszystkich dziwnych znaków
            char[] chars = input.Replace("&nbsp;", "").Replace("&#8239;", "").ToCharArray();
            string output = "";
            bool wasPrevDigit = false;

            //Przejście po wszystkich znakach w ciagu
            foreach (char x in chars)
            {
                //Jeżeli jest cyfrą lub przecinkiem to dodaj do wyniku
                if (x >= '0' && x <= '9' || x == ',')
                {
                    wasPrevDigit = true;
                    output += x;
                }
                //Jeżeli jest kropką to zamień na przecinek
                else if (x == '.') output += ',';
                //Jeżeli nie jest cyfrą, kropką ani przecinkiem ale jest spacją a poprzedni znak był cyfrą lub przecinkiem to przejdź do następnego znaku
                else if (x == ' ' && wasPrevDigit) continue;
                //Jeżeli w przeciwnym wypadku zakończ wycinanie liczby z ciągu znaków
                else if (wasPrevDigit) break;
            }

            //Jeżeli liczba przecinków jest większa niż 1 oznacza to że uzyto ich jako separatora tysięcy
            if ((from c in chars select c).Count(c => c == ',') > 1)
            {
                //Usunięcie zbędnych przecinków
                output = output.Replace(",", "");
            }

            //Jeżeli po przecinku jest więcej niż dwie cyfry to użyto go do odseparowania tysiąca lub miliona
            if (output.Length - output.IndexOf(',') > 3)
            {
                //Usunięcie zbędnego przecinka
                output = output.Replace(",", "");
            }

            //Zwrot liczby
            return output;
        }
    }
}

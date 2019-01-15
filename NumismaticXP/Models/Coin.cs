using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Levenshtein;

namespace Numismatic.Models
{
    class Coin
    {
        [DisplayName("Nazwa monety")]
        public string Name { get; set; }

        [DisplayName("Nominał")]
        public uint Value { get; set; }

        [DisplayName("Średnica")]
        public decimal Diameter { get; set; }

        [DisplayName("Stop")]
        public string Fineness { get; set; }

        [DisplayName("Waga")]
        public decimal Weight { get; set; }

        [DisplayName("Nakład")]
        public uint Edition { get; set; }

        [DisplayName("Data wydania")]
        public DateTime Emission { get; set; }

        [DisplayName("Stempel")]
        public string Stamp { get; set; }

        public override string ToString()
        {
            return $"{Name} {Value} {Diameter} {Fineness} {Weight} {Edition} {Emission} {Stamp}";
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 5;
                hash = hash * 7 + Name.GetHashCode();
                hash = hash * 7 + Value.GetHashCode();
                hash = hash * 7 + Diameter.GetHashCode();
                hash = hash * 7 + Fineness.GetHashCode();
                hash = hash * 7 + Weight.GetHashCode();
                hash = hash * 7 + Edition.GetHashCode();
                hash = hash * 7 + Emission.GetHashCode();
                hash = hash * 7 + Stamp.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Coin && this == (Coin)obj;
        }

        public static bool operator !=(Coin x, Coin y)
        {
            return !(x == y);
        }

        public static bool operator ==(Coin x, Coin y)
        {
            return x.Name == y.Name
                && x.Value == y.Value
                && x.Diameter == y.Diameter
                && x.Fineness == y.Fineness
                && x.Weight == y.Weight
                && x.Edition == y.Edition
                && x.Emission == y.Emission
                && x.Stamp == y.Stamp;
        }

        public static double[] Similarity(Coin x, Coin y)
        {
            //double[] fieldsSimilarity = new double[typeof(Coin).GetFields().Length];
            double[] fieldsSimilarity = new double[8];

            fieldsSimilarity[0] = LevenshteinDistance.CalculateSimilarity(x.Name, y.Name);
            fieldsSimilarity[1] = LevenshteinDistance.CalculateSimilarity(x.Value.ToString(), y.Value.ToString());
            fieldsSimilarity[2] = LevenshteinDistance.CalculateSimilarity(x.Diameter.ToString(), y.Diameter.ToString());
            fieldsSimilarity[3] = LevenshteinDistance.CalculateSimilarity(x.Fineness, y.Fineness);
            fieldsSimilarity[4] = LevenshteinDistance.CalculateSimilarity(x.Weight.ToString(), y.Weight.ToString());
            fieldsSimilarity[5] = LevenshteinDistance.CalculateSimilarity(x.Edition.ToString(), y.Edition.ToString());
            fieldsSimilarity[6] = LevenshteinDistance.CalculateSimilarity(x.Emission.ToString(), y.Emission.ToString());
            fieldsSimilarity[7] = LevenshteinDistance.CalculateSimilarity(x.Stamp, y.Stamp);

            return fieldsSimilarity;
        }

        public double[] Similarity(Coin coin)
        {
            return Similarity(this, coin);
        }

        public static double AverageSimilarity(Coin x, Coin y)
        {
            return Similarity(x, y).Average();
        }

        public double AverageSimilarity(Coin coin)
        {
            return AverageSimilarity(this, coin);
        }

        public static bool AreSimilar(Coin x, Coin y, double threshold)
        {
            return Similarity(x, y).All(similarity => similarity > threshold);
        }

        public bool AreSimilar(Coin coin, double threshold)
        {
            return AreSimilar(this, coin, threshold);
        }

        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>()
            {
                { "name", Name },
                { "value", Value },
                { "diameter", Diameter },
                { "fineness", Fineness },
                { "weight", Weight },
                { "edition", Edition },
                { "emission", Emission },
                { "stamp", Stamp }
            };
        }
    }
}

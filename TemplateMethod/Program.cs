using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm algorithm;
            Console.WriteLine("Men");
            algorithm = new MenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.WriteLine("\nWomen");
            algorithm = new WomenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.WriteLine("\nChildren");
            algorithm = new ChildrenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.ReadKey();
        }
    }

    abstract class ScoringAlgorithm
    {
        public int GenerateScore(int hits, TimeSpan time) // template method
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverallScore(score, reduction);
        }

        internal abstract int CalculateOverallScore(int score, int reduction);
        internal abstract int CalculateReduction(TimeSpan time);
        public abstract int CalculateBaseScore(int hits);
    }

    class MenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        internal override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        internal override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }
    }

    class ChildrenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }

        internal override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        internal override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }
    }

    class WomenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        internal override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        internal override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }
    }


}

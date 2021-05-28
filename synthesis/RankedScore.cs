using Microsoft.ProgramSynthesis;
using Microsoft.ProgramSynthesis.AST;
using Microsoft.ProgramSynthesis.Features;

namespace ProseMath
{
    public class RankingScore : Feature<double>
    {
        public RankingScore(Grammar grammar) : base(grammar, "Score")
        {
        }

        protected override double GetFeatureValueForVariable(VariableNode variable)
        {
            return 0;
        }

        [FeatureCalculator(nameof(Semantics.Sum))]
        public static double Sum(double v, double start, double end)
        {
            return start * end;
        }

        [FeatureCalculator(nameof(Semantics.Mul))]
        public static double Mul(double v, double start, double end)
        {
            return start * end;
        }

        [FeatureCalculator(nameof(Semantics.Div))]
        public static double Div(double v, double start, double end)
        {
            return start * end;
        }

        [FeatureCalculator(nameof(Semantics.ElementAt))]
        public static double ElementAt(double v, double k)
        {
            return k;
        }

        [FeatureCalculator("pos", Method = CalculationMethod.FromLiteral)]
        public static double K(int k)
        {
            return 0;
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.ProgramSynthesis;
using Microsoft.ProgramSynthesis.Learning;
using Microsoft.ProgramSynthesis.Rules;
using Microsoft.ProgramSynthesis.Specifications;

namespace ProseMath
{
    public class WitnessFunctions : DomainLearningLogic
    {
        public WitnessFunctions(Grammar grammar) : base(grammar)
        {
        }
        
        /// <summary>
        ///     Witness function (Inverse Semantics) to deduce specification of second parameter (index 1) 
        ///     of the Sum operator given specification of entire operator.
        /// <summary>
        /// <param name="rule">The Sum operator's rule</param>
        /// <param name="spec">The specification for the Sum operator</param>
        /// <returns>The specification for the second parameter of Sum operator.</returns>

        [WitnessFunction(nameof(Semantics.Sum), 1)]
        public DisjunctiveExamplesSpec WitnessSumOne(GrammarRule rule, DisjunctiveExamplesSpec spec)
        {
            var result = new Dictionary<State, IEnumerable<object>>();;
            foreach (var example in spec.DisjunctiveExamples)
            {
                State inputState = example.Key;
                var input = (int[]) inputState[rule.Body[0]];
                var occurrences = new HashSet<int?>();
                foreach (int? val in example.Value)
                {   
                    List<List<int>> Pairs =  SumPairs(input, (int) val);
                    foreach (List<int> Pair in Pairs)
                    {
                        occurrences.Add(Pair[0]);
                    }
                }
                result[inputState] = occurrences.Cast<object>();
            }
            return new DisjunctiveExamplesSpec(result);
        }

        /// <summary>
        ///     Witness function (Inverse Semantics) to deduce specification of the dependent third parameter (index 2) 
        ///     of the Sum operator given specification of entire operator and the specification of second parameter (index 1).
        /// <summary>
        /// <param name="rule">The Sum operator's rule</param>
        /// <param name="spec">The specification for the Sum operator</param>
        /// <param name="startspec">The specification for the Second parameter in Sum operator</param>
        /// <returns>The specification for the third parameter of Sum operator.</returns>

        [WitnessFunction(nameof(Semantics.Sum), 2, DependsOnParameters = new[] {1})]
        public ExampleSpec WitnessSumTwo(GrammarRule rule, ExampleSpec spec, ExampleSpec startSpec)
        {
            var result = new Dictionary<State, object>();
            foreach (var example in spec.Examples)
            {
                State inputState = example.Key;
                var input = (int[]) inputState[rule.Body[0]];
                var output = (int) example.Value;
                var start = (int) startSpec.Examples[inputState];
                result[inputState] =  output - start;
            }
            return new ExampleSpec(result);
        }

        /// <summary>
        ///     Witness function (Inverse Semantics) to deduce specification of second parameter (index 1) 
        ///     of the Mul operator given specification of entire operator.
        /// <summary>
        /// <param name="rule">The Mul operator's rule</param>
        /// <param name="spec">The specification for the Mul operator</param>
        /// <returns>The specification for the second parameter of Mul operator.</returns>

        [WitnessFunction(nameof(Semantics.Mul), 1)]
        public DisjunctiveExamplesSpec WitnessMulOne(GrammarRule rule, DisjunctiveExamplesSpec spec)
        {
            var result = new Dictionary<State, IEnumerable<object>>();;
            foreach (var example in spec.DisjunctiveExamples)
            {
                State inputState = example.Key;
                var input = (int[]) inputState[rule.Body[0]];
                var occurrences = new HashSet<int?>();
                foreach (int? val in example.Value)
                {   
                    List<List<int>> Pairs =  MulPairs(input, (int) val);
                    foreach (List<int> Pair in Pairs)
                        occurrences.Add(Pair[0]);
                        
                }
                result[inputState] = occurrences.Cast<object>();
            }
            return new DisjunctiveExamplesSpec(result);
        }

        /// <summary>
        ///     Witness function (Inverse Semantics) to deduce specification of the dependent third parameter (index 2) 
        ///     of the Mul operator given specification of entire operator and the specification of second parameter (index 1).
        /// <summary>
        /// <param name="rule">The Mul operator's rule</param>
        /// <param name="spec">The specification for the Mul operator</param>
        /// <param name="startspec">The specification for the Second parameter in Mul operator</param>
        /// <returns>The specification for the third parameter of Mul operator.</returns>

        [WitnessFunction(nameof(Semantics.Mul), 2, DependsOnParameters = new[] {1})]
        public ExampleSpec WitnessMulTwo(GrammarRule rule, ExampleSpec spec, ExampleSpec startSpec)
        {
            var result = new Dictionary<State, object>();
            foreach (var example in spec.Examples)
            {
                State inputState = example.Key;
                var input = (int[]) inputState[rule.Body[0]];
                var output = (int) example.Value;
                var start = (int) startSpec.Examples[inputState];
                result[inputState] =  output / start;
            }
            return new ExampleSpec(result);
        }

        /// <summary>
        ///     Witness function (Inverse Semantics) to deduce specification of second parameter (index 1) 
        ///     of the Div operator given specification of entire operator.
        /// <summary>
        /// <param name="rule">The Div operator's rule</param>
        /// <param name="spec">The specification for the Div operator</param>
        /// <returns>The specification for the second parameter of Div operator.</returns>

        [WitnessFunction(nameof(Semantics.Div), 1)]
        public DisjunctiveExamplesSpec WitnessDivOne(GrammarRule rule, DisjunctiveExamplesSpec spec)
        {
            var result = new Dictionary<State, IEnumerable<object>>();;
            foreach (var example in spec.DisjunctiveExamples)
            {
                State inputState = example.Key;
                var input = (int[]) inputState[rule.Body[0]];
                var occurrences = new HashSet<int?>();
                foreach (int? val in example.Value)
                {   
                    List<List<int>> Pairs =  DivPairs(input, (int) val);
                    foreach (List<int> Pair in Pairs)
                        occurrences.Add(Pair[0]);
                }
                result[inputState] = occurrences.Cast<object>();
            }
            return new DisjunctiveExamplesSpec(result);
        }

        /// <summary>
        ///     Witness function (Inverse Semantics) to deduce specification of the dependent third parameter (index 2) 
        ///     of the Div operator given specification of entire operator and the specification of second parameter (index 1).
        /// <summary>
        /// <param name="rule">The Div operator's rule</param>
        /// <param name="spec">The specification for the Div operator</param>
        /// <param name="startspec">The specification for the Second parameter in Div operator</param>
        /// <returns>The specification for the third parameter of Div operator.</returns>

        [WitnessFunction(nameof(Semantics.Div), 2, DependsOnParameters = new[] {1})]
        public ExampleSpec WitnessDivTwo(GrammarRule rule, ExampleSpec spec, ExampleSpec startSpec)
        {
            var result = new Dictionary<State, object>();
            foreach (var example in spec.Examples)
            {
                State inputState = example.Key;
                var input = (int[]) inputState[rule.Body[0]];
                var output = (int) example.Value;
                var start = (int) startSpec.Examples[inputState];
                result[inputState] =  start/output;
            }
            return new ExampleSpec(result);
        }

        /// <summary>
        ///     Witness function (Inverse Semantics) to deduce specification of second parameter (index 1) 
        ///     of the ElementAt operator given specification of entire operator.
        /// <summary>
        /// <param name="rule">The ElementAt operator's rule</param>
        /// <param name="spec">The specification for the ElementAt operator</param>
        /// <returns>The specification for the second parameter of ElementAt operator.</returns>

        [WitnessFunction(nameof(Semantics.ElementAt),1)]
        public DisjunctiveExamplesSpec WitnessElementAt(GrammarRule rule, DisjunctiveExamplesSpec spec)
        {
            var result = new Dictionary<State, IEnumerable<object>>();;
            foreach (var example in spec.DisjunctiveExamples)
            {
                State inputState = example.Key;
                var v = (int[]) inputState[rule.Body[0]];
                var occurrences = new HashSet<int?>();
                foreach (int? val in example.Value)
                {
                    occurrences.Add(Array.IndexOf(v,val));
                }
                result[inputState] = occurrences.Cast<object>();
            }
            return new DisjunctiveExamplesSpec(result);
        }
        
        /// <summary>
        ///     Helper function to generate sum pairs given a list of integers and a target sum.
        /// <summary>
        /// <param name="arr">Input array of intergers</param>
        /// <param name="Target">Target sum required</param>
        /// <returns>2D list of all sum pairs with the given target sum.</returns>
        public static List<List<int>> SumPairs(int[] arr, int sum)
        {
 
            List<List<int>> Pairs = new List<List<int>>();

            for (int i = 0; i < arr.Length; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if ((arr[i] + arr[j]) == sum)
                        Pairs.Add(new List<int> {arr[i], arr[j]});
        
            return Pairs;
        }

        /// <summary>
        ///     Helper function to generate Multiplication pairs given a list of integers and a target multiplication value.
        /// <summary>
        /// <param name="arr">Input array of intergers</param>
        /// <param name="Target">Target value required</param>
        /// <returns>2D list of all Mul pairs with the given target multiplication value.</returns>
        public static List<List<int>> MulPairs(int[] arr, int sum)
        {
 
            List<List<int>> Pairs = new List<List<int>>();

            for (int i = 0; i < arr.Length; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if ((arr[i] * arr[j]) == sum)
                        Pairs.Add(new List<int> {arr[i], arr[j]});
        
            return Pairs;
        }

        /// <summary>
        ///     Helper function to generate Division pairs given a list of integers and a target Division value.
        /// <summary>
        /// <param name="arr">Input array of intergers</param>
        /// <param name="Target">Target value required</param>
        /// <returns>2D list of all Div pairs with the given target division value.</returns>
        public static List<List<int>> DivPairs(int[] arr, int sum)
        {
 
            List<List<int>> Pairs = new List<List<int>>();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if ((arr[i] / arr[j]) == sum && (arr[i] % arr[j]) == 0)
                    {
                        Pairs.Add(new List<int> {arr[i], arr[j]});
                    }
                    else if ((arr[j] / arr[i]) == sum && (arr[j] % arr[i]) == 0)
                    {
                        Pairs.Add(new List<int> {arr[j], arr[i]});
                    }
                }
                
            }
            return Pairs;
        }
    }
}
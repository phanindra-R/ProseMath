namespace ProseMath
{
    public static class Semantics
    {
        
        //  Semantics function for Sum DSL operator.
        public static int? Sum(int[] v,int? ValueOne,int? ValueTwo)
        {
            if (ValueOne == null || ValueTwo == null) return null;

            return ValueOne +  ValueTwo;
        }

        // Semantic function for Mul DSL operator.
        public static int? Mul(int[] v,int? ValueOne,int? ValueTwo)
        {
            if (ValueOne == null || ValueTwo == null) return null;

            return ValueOne * ValueTwo;
        }

        // Semantic function for Div DSL operator.
        public static int? Div(int[] v,int? ValueOne,int? ValueTwo)
        {
            if (ValueOne == null || ValueTwo == null) return null;

            return  ValueOne /  ValueTwo;
        }

        // Semantic function for ElementAt DSL operator.
        public static int? ElementAt(int[] v,int? pos)
        {
            if (pos == null) return null;

            return v[(int) pos];
        }
    }
}
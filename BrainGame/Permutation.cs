namespace BrainGame
{
    internal static class Permutation
    {
        public static List<List<Figure>> permute(List<Figure> figures)
        {
            var list = new List<List<Figure>>();

            return doPermutate(figures, 0, figures.Count - 1, list);
        }

        private static List<List<Figure>> doPermutate(List<Figure> figures, int start, int end, List<List<Figure>> list)
        {
            if (start == end)
            {
                list.Add(new List<Figure>(figures));
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    swap(figures, start, i);
                    doPermutate(figures, start + 1, end, list);
                    swap(figures, start, i);
                }
            }

            return list;
        }

        private static void swap(List<Figure> figures, int start, int current)
        {
            var temp = figures[start];
            figures[start] = figures[current];
            figures[current] = temp;
        }
    }
}

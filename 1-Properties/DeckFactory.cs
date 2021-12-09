namespace Properties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A factory class for building <see cref="ISet{T}">decks</see> of <see cref="Card"/>s.
    /// </summary>
    public class DeckFactory
    {
        private string[] seeds;

        private string[] names;
        
        public IList<string> Seeds
        {
            get => seeds.ToList(); 
            set => seeds = value.ToArray();  
        }
        
        public IList<string> Names
        {
            get => names.ToList(); 
            set => names = value.ToArray(); 
        }

        // TODO improve
        public int GetDeckSize() => names.Length * seeds.Length;
        

        /// TODO improve
        public ISet<Card> GetDeck()
        {
            if (names == null || seeds == null)
            {
                throw new InvalidOperationException();
            }

            return new HashSet<Card>(Enumerable
                .Range(0, names.Length)
                .SelectMany(i => Enumerable
                    .Repeat(i, seeds.Length)
                    .Zip(
                        Enumerable.Range(0, seeds.Length),
                        (n, s) => Tuple.Create(names[n], seeds[s], n)))
                .Select(tuple => new Card(tuple))
                .ToList());
        }
    }
}

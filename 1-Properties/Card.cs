namespace Properties
{
    using System;

    /// <summary>
    /// The class models a card.
    /// </summary>
    public class Card
    {
        private readonly string _seed;//{ get; }
        private readonly string _name;//{ get; }
        private readonly int _ordinal;//{ get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="name">the name of the card.</param>
        /// <param name="seed">the seed of the card.</param>
        /// <param name="ordinal">the ordinal number of the card.</param>
        public Card(string name, string seed, int ordinal)
        {
            _name = name;
            _ordinal = ordinal;
            _seed = seed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="tuple">the informations about the card as a tuple.</param>
        internal Card(Tuple<string, string, int> tuple) : this(tuple.Item1, tuple.Item2, tuple.Item3)
        {
        }

        // TODO improve
        public string GetSeed() => _seed;
        
        public string GetName() => _name;
        
        public int GetOrdinal() => _ordinal;
        
        // TODO improve
       /* public string GetName()
        {
            return this.name;
        }*/

        // TODO improve
        /*public int GetOrdinal()
        {
            return this.ordinal;
        }*/

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            // TODO understand string interpolation
            return $"{this.GetType().Name}(_Name={this.GetName()}, Seed={this.GetSeed()}, Ordinal={this.GetOrdinal()})";
        }
        
        
        // TODO generate Equals(object obj)
        protected bool Equals(Card other)
        {
            return _seed == other._seed && _name == other._name && _ordinal == other._ordinal;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Card) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_seed, _name, _ordinal);
        }
        // TODO generate GetHashCode()
    }
}

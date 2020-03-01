﻿namespace projectCS.physic_components
{
    public class AngleBracket : CupboardComponents
    {
        private int _height;
        public override int height
        {
            get => _height;
        }

        private double _price;
        public override double price
        {
            get => _price;
        }

        public AngleBracket() : this(0, "null", "0000", 0, false, 0)
        {
        }

        public AngleBracket(double price,
                     string reference,
                     string code,
                     int size,
                     bool inStock,
                     int height) : base(reference, code, size, inStock)
        {
            this._price = price;
            this._height = height;
        }

        /// <summary>
        ///     resize the angle bracket
        /// </summary>
        /// <param name="size">
        ///     size to deduct
        /// </param>
        public void cutHeight(int size)
        {
            _height -= size;
        }
    }
}

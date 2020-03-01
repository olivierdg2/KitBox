﻿using projectCS.physic_components;
using System.Collections.Generic;

namespace projectCS
{
    public class OrderForm
    {
        /// <summary>
        ///     the first emplacement take the cupboard build by the client, the second take the number of this cupboard
        /// </summary>
        private Dictionary<Cupboard, int> _cupboardDictionnary;
        public Dictionary<Cupboard, int> cupboardDictionnary
        {
            get => _cupboardDictionnary;
        }

        private Client _client; 
        public Client client
        {
            get => _client;
        }

        private static int _OrderID = 0;
        public int OrderID
        {
            get => _OrderID;
        }
        
        public OrderForm() : this(new Client())
        {
        }
        
        public OrderForm(Client client)
        {
            this._client = client;
            this._cupboardDictionnary = new Dictionary<Cupboard, int>();
            this._client.addOrderForm(this);
            _OrderID++;
        }

        public void addCupboard(Cupboard cupboard)
        {
            _cupboardDictionnary.Add(cupboard, 1);
        }

        public void choiceNumberOfCupboard(Cupboard cupboard, int number)
        {
            _cupboardDictionnary[cupboard] = number;
        }

        /// <summary>
        ///     reset initial id from which it count
        /// </summary>
        private void resetID()
        {
            _OrderID = 0;
        }
    }
}

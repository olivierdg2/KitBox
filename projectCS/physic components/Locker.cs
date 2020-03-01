﻿using System.Collections.Generic;

namespace projectCS
{
    public class Locker : CupboardComponents
    {
        /// <summary>
        ///     group all maximum value for each components which the locker can have
        /// </summary>
        private static readonly int maximumCrossBar = 8;
        private static readonly int maximumPannel = 5;
        private static readonly int maximumDoor = 2;
        private static readonly int maximumCleat = 4;

        public override int height 
        { 
            get => height;
        }

        public override double price
        {
            get
            {
                double componentsPrice = 0;
                foreach (LockerComponents component in _componentsList)
                {
                    componentsPrice += component.price;
                }
                return componentsPrice;
            }
        }

        private int _width;
        public int width
        {
            get => _width;
        }

        private int _depth;
        public int depth
        {
            get => _depth;
        }

        // TODO : a refactorer si inutile par la suite
        /*
        private int _numberOfLCrossBar;
        public int numberOfLCrossBar
        {
            get => _numberOfLCrossBar;
        }

        private int _numberOfPannel;
        public int numberOfPannel
        {
            get => _numberOfPannel;
        }

        private int _numberOfDoor;
        public int numberOfDoor
        {
            get => _numberOfDoor;
        }

        private int _numberOfCleat;
        public int numberOfCleat
        {
            get => _numberOfCleat;
        }
        */
        private List<LockerComponents> _componentsList;
        public List<LockerComponents> componentsList
        {
            get => _componentsList;
        }

        public Locker() : this("null", "0000", 0, false)
        {
        }

        public Locker(string reference,
                     string code,
                     int size,
                     bool inStock) : base(reference, code, size, inStock)
        {
            _width = 0;
            _depth = 0;
            _componentsList = new List<LockerComponents>();
        }

        // TODO : vérifier dans l'ajout qu'il ya encore de la place dans le locker et qu'on a pas atteint le nbr de composant max
        public void addComponent(LockerComponents component)
        {
            bool isOk = false;
            switch (component)
            {
                case CrossBar c:
                    if (numberOfComponentInList(component) < maximumCrossBar)
                        isOk = true;
                    break;
                case Pannel p:
                    if (numberOfComponentInList(component) < maximumPannel)
                        isOk = true;
                    break;
                case Door d:
                    if (numberOfComponentInList(component) < maximumDoor)
                        isOk = true;
                    break;
                case Cleat cl:
                    if (numberOfComponentInList(component) < maximumCleat)
                        isOk = true;
                    break;
                default:
                    break;
            }          
            
            if (isOk)
                _componentsList.Add(component);
        }

        // TODO : pareil que pour le add component simple, vérifier si il ya encore de la place
        public void addComponent(List<LockerComponents> componentList)
        {
            _componentsList.AddRange(componentList);
        }

        // TODO : vérifier si ca ne bugge pas quand on enlève un composant qui n'existe pas
        public void removeComponent(LockerComponents component)
        {
            _componentsList.Remove(component);
        }

        /// <summary>
        ///     check if the locker have all components that it must have 
        /// </summary>
        /// <returns>
        ///     return true if the locker have all components, false in other case
        /// </returns>
        public bool isComplete()
        {
            bool isOk = false;
            int numberOfCrossBar = numberOfComponentInList(new CrossBar());
            int numberOfPannel = numberOfComponentInList(new Pannel());
            int numberOfCleat = numberOfComponentInList(new Cleat());

            // check if the locker has 8xcrossbar + 5xPannel + 4xCleat
            if ((numberOfCrossBar == maximumCrossBar) && (numberOfPannel == maximumPannel) && (numberOfCleat == maximumCleat))
                isOk = true;

            return isOk;
        }

        /// <summary>
        ///     this function return the number of component which is a LockerComponent type and owned by locker class
        /// </summary>
        /// <param name="component">
        ///     take a component to search in locker component list
        /// </param>
        /// <returns>
        ///     return the number of component found
        /// </returns>
        private int numberOfComponentInList(LockerComponents componentGiven)
        {            
            int numberofComponent = 0;
            foreach (LockerComponents componentInList in _componentsList)
            {
                if(componentInList.GetType() == componentGiven.GetType())
                    numberofComponent++;
            }
            return numberofComponent;
        }
    }
}

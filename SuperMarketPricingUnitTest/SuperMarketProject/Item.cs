namespace SuperMarketProject
{
    public class Item
    {
        private string _Name;
        private double _Discount;
        public double _PricePerGram;

        private double _PricePerItem;
        private double[] _SpecialDiscount;

        public Item(string name, double discount, double pricePerGram, double pricePerItem, double[] specialDiscount)
        {
            this.Name = name;
            this._Discount = discount;
            this._PricePerGram = pricePerGram;
            this._PricePerItem = pricePerItem;
            this._SpecialDiscount = specialDiscount;

        }

        public string Name
        {
            get
            { 
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public double Discount
        {
            get
            {
                return _Discount;
            }
            set
            {
                _Discount = value;
            }
        }

        public double PricePerGram
        {
            get
            {
                return _PricePerGram;
            }
            set
            {
                _PricePerGram = value;
            }
        }

        public double PricePerItem
        {
            get
            {
                return _PricePerItem;
            }
            set
            {
                _PricePerItem = value;
            }
        }

        public double[] SpecialDiscount
        {
            get
            {
                return _SpecialDiscount;
            }
            set
            {
                _SpecialDiscount = value;
            }
        }





    }
}

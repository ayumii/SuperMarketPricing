using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketProject
{
    public class PricingSystem
    {
        private List<Item> _cart;
        private double _TotalPrice = 0;
      
        public PricingSystem(List<Item> cart)
        {
            this._cart = cart;
        }

        [STAThread]
        static void Main()
        {

        }


        public double ComputeTotalPrice(double weight)
        {
            foreach (Item i in _cart)
            {
                _TotalPrice += i.PricePerGram* weight;
               
            }
            return _TotalPrice;
         
        }


        public double ComputeTotalPrice(int quantity)
        {
            foreach (Item i in _cart)
            {
                int num = (int) i.SpecialDiscount[0];

                double perItemDiscount = i.Discount;

                if (perItemDiscount > 0 && num >= 0)
                {
                    double priceOne = CalculateTotalPerItemDiscountPrice(i, perItemDiscount, quantity);
                    double priceTwo;

                    if (quantity >= num && num >= 0)
                    {
                        priceTwo = CalculateTotalSpecialDiscountPrice(i, num, quantity);
                    }
                    else
                    {
                        priceTwo = i.PricePerItem * quantity;
                    }

                    _TotalPrice += Math.Min(priceOne, priceTwo);


                }

                if (perItemDiscount > 0)
                {
                    _TotalPrice += CalculateTotalPerItemDiscountPrice(i, perItemDiscount, quantity);
                } 

                else if (quantity >= num && num >= 0)
                {
                    _TotalPrice += CalculateTotalSpecialDiscountPrice(i, num, quantity);
                }
                else
                {
                    _TotalPrice += i.PricePerItem * quantity;
                }


            }
            return _TotalPrice;
        }



        private double CalculateTotalPerItemDiscountPrice(Item i, double perItemDiscount, int quantity)
        {
            double perItemDiscountedPrice = i.PricePerItem * perItemDiscount / 100.0;
            return  perItemDiscountedPrice * quantity;
        }

        private double CalculateTotalSpecialDiscountPrice(Item i, int num, int quantity)
        {
            int start = quantity / num;
            int remainder = quantity % num;
            return i.SpecialDiscount[1] * start + i.PricePerItem * remainder;
        }

    }



}

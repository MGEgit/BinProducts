using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinProducts.Core
{
    public class OrderItem
    {
        private int _quantity;

        public OrderItem(ProductType productType, int quantity)
        {
            ProductType = productType;
            Quantity = quantity;
        }
        public ProductType ProductType { get; private set; }
        public int Quantity
        {
            get { return _quantity; }
            private set
            {
                if (value < 1)
                    throw new DomainException("the quantity should be more than zero.");

                if (value > 100)
                    throw new DomainException("the quantity shouldn't be more than 100.");

                RequiredBinWidth = CalculateRequiredBinWidth(value);

                _quantity = value;
            }
        }

        public float RequiredBinWidth { get; private set; }

        private float CalculateRequiredBinWidth(int quantity)
        {
            Product product;
            switch (ProductType)
            {
                case ProductType.PhotoBook:
                    product = new PhotoBook();
                    break;
                case ProductType.Calendar:
                    product = new Calendar();
                    break;
                case ProductType.Canvas:
                    product = new Canvas();
                    break;
                case ProductType.Cards:
                    product = new Cards();
                    break;
                case ProductType.Mug:
                    product = new Mug();
                    break;
                default:
                    throw new DomainException("invalid product.");
            }

            return product.CalculateWidth(quantity);
        }

    }
}

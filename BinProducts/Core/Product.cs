using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinProducts.Core
{
    public abstract class Product
    {
        public abstract float Width { get; }

        public virtual float CalculateWidth(int quantity)
        {
            return Width * quantity;
        }
    }

    public class PhotoBook : Product
    {
        public const float PhotoBook_Width = 19;
        public override float Width => PhotoBook_Width;
    }

    public class Calendar : Product
    {
        public const float Calendar_Width = 10;
        public override float Width => Calendar_Width;
    }

    public class Canvas : Product
    {
        public const float Canvas_Width = 16;
        public override float Width => Canvas_Width;
    }

    public class Cards : Product
    {
        public const float Cards_Width = 4.7f;
        public override float Width => Cards_Width;
    }

    public class Mug : Product
    {
        public const float Mug_Width = 96;
        public override float Width => Mug_Width;

        public override float CalculateWidth(int quantity)
        {
            int units = quantity / 4;
            int remaining = quantity % 4;

            return (units * Width) + (remaining > 0 ? Width : 0);
        }
    }

}

using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Utility
{
    public static class SD
    {
        public const string DeafultFoodImage = "default_food.png";

        public const string ManageUser = "Manager";
        public const string KitchenUser = "Kitchen";
        public const string FrontDeskUser = "FrontDesk";
        public const string CustomerEndUser = "Customer";

        public const string ssShopingCartCount = "ssCartCount";
        public const string ssCouponCode = "ssCouponCode";


        public const string StatusSubmitted = "Submitted";
        public const string StatusInProcess = "Being Prepared";
        public const string StatusReady = "Ready For Pickup";
        public const string StatusCompleted = "Completed";
        public const string StatusCancelled = "Cancelled";
        
        
      public const string PaymentStatusPending = "Pending";
      public const string PaymentStatusApproved = "Approved";
      public const string PaymentStatusRejected = "Rejected";






        public static string ConvertToRawHtml(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char lets = source[i];
                if (lets == '<')
                {
                    inside = true;
                    continue;
                }
                if (lets == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = lets;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }


        public static double DiscountedPrice(Coupon couponFromDb, double OriginalOrderTotal)
        {
            if (couponFromDb == null)
            {
                return OriginalOrderTotal;
            }
            else
            {
                if (couponFromDb.MinimumAmount > OriginalOrderTotal)
                {
                    return OriginalOrderTotal;
                }
                else
                {
                    //Everything is valid
                    //$10 off $100
                    if (Convert.ToInt32(couponFromDb.CouponType) == (int)Coupon.ECouponType.Dollar)
                    {
                        return Math.Round(OriginalOrderTotal - couponFromDb.Discount, 2);
                    }
                    //10% off 100%
                    if (Convert.ToInt32(couponFromDb.CouponType) == (int)Coupon.ECouponType.Percent)
                    {
                        return Math.Round(OriginalOrderTotal - (OriginalOrderTotal - couponFromDb.Discount / 100), 2);
                    }
                }
            }
            return OriginalOrderTotal;
        }
    }

}

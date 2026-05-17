using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerApp
{
    public static class CartManager
    {
        public static List<CartItemModel> Items { get; private set; } = new List<CartItemModel>();

        // รับ Object ของ CartItemModel
        public static void AddToCart(CartItemModel newItem)
        {
            // เช็กว่ามีสินค้านี้ในตะกร้าหรือยังจากชื่อสินค้า
            var existingItem = Items.FirstOrDefault(i => i.Title == newItem.Title);

            if (existingItem != null)
            {
                // ถ้ามีอยู่แล้ว ให้บวกจำนวนสะสมเพิ่มตามที่ลูกค้ากดเลือกเข้ามา
                existingItem.Quantity += newItem.Quantity;
            }
            else
            {
                // ถ้ายังไม่มี ให้เพิ่มรายการใหม่
                Items.Add(newItem);
            }
        }
    }

    // Class โครงสร้างข้อมูลของสินค้าในตะกร้า
    public class CartItemModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = "";
        public int Quantity { get; set; }
    }
}
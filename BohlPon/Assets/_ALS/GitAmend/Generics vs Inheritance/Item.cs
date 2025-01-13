using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ALS.GitAmend.LootSystem
{
    public class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Item(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public override string ToString() => $"{Quantity} x {Name}";
    }

    public class LootBag<T> where T : Item
    {
        List<T> items = new List<T>();

        public void AddItem(T item)
        {
            items.Add(item);
            Debug.Log($"Added: {item}");
        }

        public IEnumerable<T> GetAllItems() => items;
    }
}

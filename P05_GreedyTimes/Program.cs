using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Potato
{
    static void Main(string[] args)
    {
        long bagCapacity = long.Parse(Console.ReadLine());

        string[] itemsInput = Console.ReadLine()
            .Split();

        var goldPack = new Dictionary<string, long>();
        long goldQuantity = 0;
        var gemPack = new Dictionary<string, long>();
        long gemQuantity = 0;
        var cashPack = new Dictionary<string, long>();
        long cashQuantity = 0;

        for (int i = 0; i < itemsInput.Length; i += 2)
        {
            string itemsName = itemsInput[i];
            long itemsAmount = long.Parse(itemsInput[i + 1]);

            string itemType = GetItemType(itemsName);

            bool canInsertItem = CanPutItemInBag(itemType, itemsAmount, bagCapacity, goldQuantity, gemQuantity, cashQuantity);
            if (itemType == "Invalid" || !canInsertItem)
            {
                continue;
            }

            switch (itemType)
            {
                case "Gold":
                    InsertItem(goldPack, itemsName, itemsAmount);
                    goldQuantity += itemsAmount;
                    break;
                case "Gem":
                    InsertItem(gemPack, itemsName, itemsAmount);
                    gemQuantity += itemsAmount;
                    break;
                case "Cash":
                    InsertItem(cashPack, itemsName, itemsAmount);
                    cashQuantity += itemsAmount;
                    break;
            }
        }
        if (goldPack.Any())
        {
            Console.WriteLine(PtintBag(goldPack, "Gold", goldQuantity));
            if (gemPack.Any())
            {
                Console.WriteLine(PtintBag(gemPack, "Gem", gemQuantity));
                if (cashPack.Any())
                {
                    Console.WriteLine(PtintBag(cashPack, "Cash", cashQuantity));
                }
            }
        }
    }

    private static string PtintBag(Dictionary<string, long> bag, string type, long totalAmaunt)
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"<{type}> ${totalAmaunt}");

        foreach (var item in bag.OrderByDescending(n => n.Key).ThenBy(v => v.Value))
        {
            resultBuilder.AppendLine($"##{item.Key} - {item.Value}");
        }
        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }

    private static void InsertItem(Dictionary<string, long> bag, string itemsName, long itemsAmount)
    {
        if (!bag.ContainsKey(itemsName))
        {
            bag[itemsName] = 0;
        }
        bag[itemsName] += itemsAmount;
    }

    private static bool CanPutItemInBag(string itemType, long itemsAmount, long bagCapacity, long goldQuantity, long gemQuantity, long cashQuantity)
    {
        long bagOccupiet = goldQuantity + gemQuantity + cashQuantity;
        if (bagCapacity < bagOccupiet + itemsAmount)
        {
            return false;
        }
        switch (itemType)
        {
            case "Gold":
                return true;
            case "Gem":
                gemQuantity += itemsAmount;
                return gemQuantity <= goldQuantity;
            case "Cash":
                cashQuantity += itemsAmount;
                return cashQuantity <= gemQuantity;
        }
        return false;
    }


    private static string GetItemType(string itemsName)
    {
        if (itemsName.Length == 3)
        {
            return "Cash";
        }
        if (itemsName.ToLower().EndsWith("gem"))
        {
            return "Gem";
        }
        if (itemsName.ToLower() == "gold")
        {
            return "Gold";
        }
        return "Invalid";
    }
}


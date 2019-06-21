using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemData
{
    //this is going to act like a database
    public static Item CreateItem(int itemId)
    {
        string name = "";
        int value = 0;
        string description = "";
        string icon = "";
        string mesh = "";
        ItemType type = ItemType.Food;
        int heal = 0;
        int damage = 0;
        int armour = 0;
        int amount = 0;

        switch(itemId)
        {
            #region Food 0-99
            case 0:
                name = "Berries";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Food/Berries_Icon";
                mesh = "Food/Berries_Mesh";
                type = ItemType.Food;
                heal = 5;
                amount = 1;
                break;

            case 1:
                name = "Cheese";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Food/Cheese_Icon";
                mesh = "Food/Cheese_Mesh";
                type = ItemType.Food;
                heal = 5;
                amount = 1;
                break;
            case 2:
                name = "Bone";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Food/Bone_Icon";
                mesh = "Food/Bone_Mesh";
                type = ItemType.Food;
                heal = 5;
                amount = 1;
                break;

            #endregion

            #region Weapon 100-199
            case 100:
                name = "Bow";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Weapon/Bow_Icon";
                mesh = "Weapon/Bow_Mesh";
                type = ItemType.Weapon;
                damage = 5;
                amount = 1;
                break;

            case 101:
                name = "Dagger";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Weapon/Dagger_Icon";
                mesh = "Weapon/Dagger_Mesh";
                type = ItemType.Weapon;
                damage = 5;
                amount = 1;
                break;

            case 102:
                name = "Sword";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Weapon/Sword_Icon";
                mesh = "Weapon/Sword_Mesh";
                type = ItemType.Weapon;
                damage = 5;
                amount = 1;
                break;
            #endregion

            #region Apparel 200-299
            case 200:
                name = "Armour";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Apparel/Armour_Icon";
                mesh = "Apparel/Armour_Mesh";
                type = ItemType.Apparel;
                armour = 5;
                amount = 1;
                break;

            case 201:
                name = "Boots";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Apparel/Boots_Icon";
                mesh = "Apparel/Boots_Mesh";
                type = ItemType.Apparel;
                armour = 5;
                amount = 1;
                break;

            case 202:
                name = "Helmet";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Apparel/Helmet_Icon";
                mesh = "Apparel/Helmet_Mesh";
                type = ItemType.Apparel;
                armour = 5;
                amount = 1;
                break;
            #endregion

            #region Crafting 300-399
            case 300:
                name = "Nail";
                value = 5;
                description = "Her";
                icon = "Crafting/Nails_Icon";
                mesh = "Crafting/Nails_Mesh";
                type = ItemType.Crafting;
                amount = 10;
                break;

            case 301:
                name = "Gears";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Crafting/Gears_Icon";
                mesh = "Crafting/Gears_Mesh";
                type = ItemType.Crafting;
                armour = 5;
                amount = 5;
                break;

            case 302:
                name = "Blueprint";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Crafting/Blueprint_Icon";
                mesh = "Crafting/Blueprint_Mesh";
                type = ItemType.Crafting;
                armour = 5;
                amount = 1;
                break;
            #endregion

            #region Quest 400-499
            case 400:
                itemId = 0;
                name = "Feather";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Quest/Feather_Icon";
                mesh = "Quest/Feather_Mesh";
                type = ItemType.Quest;
                amount = 1;
                break;

            case 401:
                itemId = 0;
                name = "Orb";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Quest/Orb_Icon";
                mesh = "Quest/Orb_Mesh";
                type = ItemType.Quest;
                amount = 1;
                break;

            case 402:
                itemId = 0;
                name = "Heart";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Quest/Heart_Icon";
                mesh = "Quest/heart_Mesh";
                type = ItemType.Quest;
                amount = 1;
                break;
            #endregion

            #region Ingredients 500-599
            case 500:
                name = "Mushroom";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Ingredient/Mushroom_Icon";
                mesh = "Ingredient/Mushroom_Mesh";
                type = ItemType.Ingredients;
                amount = 1;
                break;

            case 501:
                name = "Roots";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Ingredient/Roots_Icon";
                mesh = "Ingredient/Roots_Mesh";
                type = ItemType.Ingredients;
                amount = 1;
                break;

            case 502:
                name = "Herbs";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Ingredient/Herbs_Icon";
                mesh = "Ingredient/Herbs_Mesh";
                type = ItemType.Ingredients;
                amount = 1;
                break;
            #endregion

            #region Potions 600-699
            case 600:
                name = "Health";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Potions/Health_Icon";
                mesh = "Potions/Health_Mesh";
                type = ItemType.Potion;
                amount = 5;
                break;

            case 601:
                name = "Mana";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Potions/Mana_Icon";
                mesh = "Potions/Mana_Mesh";
                type = ItemType.Potion;
                amount = 5;
                break;

            case 602:
                name = "Stamina";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Potions/Stamina_Icon";
                mesh = "Potions/Stamina_Mesh";
                type = ItemType.Potion;
                amount = 5;
                break;
            #endregion

            #region Scrolls 700-799
            case 700:
                name = "Identification";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Scrolls/Identification_Icon";
                mesh = "Scrolls/Identification_Mesh";
                type = ItemType.Scroll;
                amount = 5;
                break;

            case 701:
                name = "Necromancy";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Scrolls/Necromancy_Icon";
                mesh = "Scrolls/Necromancy_Mesh";
                type = ItemType.Scroll;
                amount = 5;
                break;

            case 702:
                name = "Sleep";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Scrolls/Sleep_Icon";
                mesh = "Scrolls/Sleep_Mesh";
                type = ItemType.Scroll;
                amount = 5;
                break;
            #endregion
            default:
                itemId = 0;
                name = "Apple";
                value = 5;
                description = "Munchy And Curnchy";
                icon = "Food/Apple_Icon";
                mesh = "Food/Apple_Mesh";
                type = ItemType.Food;
                heal = 5;
                amount = 1;
                break;
        }

        Item temp = new Item
        {
            Name = name,
            Description = description,
            ID = itemId,
            Value = value,
            Damage = damage,
            Armour = armour,
            Amount = amount,
            Heal = heal,
            Type = type,
            Mesh = Resources.Load("Prefabs/" + mesh) as GameObject,
            Icon = Resources.Load("Icon/" + icon) as Texture2D


        };
        return temp;
    }
}

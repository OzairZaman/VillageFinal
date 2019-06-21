using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region variables
    public static List<Item> inv = new List<Item>();
    public static bool showInv;
    public static int money;
    public Item selectedItem;

    //Movement.CanMove
    public Vector2 scr;
    public Vector2 scrollPos; //scrollable are if more items that can fit on screen

    public string[] sortType;
    public string selectedType;

    public Transform[] equippedLocations;
    // 0 = right
    // 1 = left hand
    public Transform dropLocation;
    public GameObject currentWeapon;
    public GameObject currentHelmet;

    //health
    public LinearhealthBar.Health health;


    #endregion
    void Start()
    {
        sortType = new string[] { "All", "Food", "Weapon", "Apparel", "Crafting", "Quest", "Ingredients", "Potion", "Scroll" };
        inv.Add(ItemData.CreateItem(0));
        inv.Add(ItemData.CreateItem(2));
        inv.Add(ItemData.CreateItem(100));
        inv.Add(ItemData.CreateItem(102));
        inv.Add(ItemData.CreateItem(200));
        inv.Add(ItemData.CreateItem(201));
        inv.Add(ItemData.CreateItem(300));
        for (int i = 0; i < inv.Count; i++)
        {
            Debug.Log(inv[i].Name);
        }
    }

    public bool ToggleInv()
    {
        Debug.Log("IN HERE");

        if (showInv)
        {
            showInv = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Movement.canMove = true;
            return false;
        }
        else
        {
            if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;
            }

            showInv = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Movement.canMove = false;
            
            return true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(showInv);

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //if(!PauseMenu.isPaused
            ToggleInv();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            inv.Add(ItemData.CreateItem(0));
            inv.Add(ItemData.CreateItem(2));
            inv.Add(ItemData.CreateItem(100));
            inv.Add(ItemData.CreateItem(102));
            inv.Add(ItemData.CreateItem(200));
            inv.Add(ItemData.CreateItem(201));
            inv.Add(ItemData.CreateItem(300));
        }
    }

    void DisplayInv(string sortType)
    {
        if (!(sortType == "All" || sortType == "")) 
        {
            //a item type is picked
            ItemType type = (ItemType)System.Enum.Parse(typeof(ItemType), sortType);
            int a = 0; // amount of this type
            int s = 0; // slot position of item
            for (int i = 0; i < inv.Count; i++)
            {
                if (inv[i].Type == type)
                {
                    a++; // increase the amount of this type
                }
            }

            if (a <= 34) // if its less than the amount we can display on screen
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].Type == type)
                    {
                        if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + s * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i]; // select the item from its postion in the inventory
                            Debug.Log(selectedItem.Name);
                        }
                        s++;
                    }
                }
            }
            else
            {
                scrollPos = GUI.BeginScrollView(new Rect(0.5f*scr.x, 0.25f*scr.y, 3.5f*scr.x, 8.5f*scr.y), scrollPos, new Rect(0,0,0,8.5f*scr.y + ((a-34)*(0.25f*scr.y))), true, true);
                #region Items in View Area
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].Type == type)
                    {
                        if (GUI.Button(new Rect(0,s*(0.25f*scr.y),3f*scr.x,0.25f*scr.y), inv[i].Name)) //inside this scroll view 0 is the edges of scroll view
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                        s++; // increase the slot position so the next one slides under
                    }
                }
                #endregion
                GUI.EndScrollView();
            }
        }
        else
        {
            //we showing all baby!
            if (inv.Count <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    
                    if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i]; // select the item from its postion in the inventory
                        Debug.Log(selectedItem.Name);
                           
                    }
                    //i++;



                }
            }
            else
            {
                scrollPos = GUI.BeginScrollView(new Rect(0.5f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + ((inv.Count - 34) * (0.25f * scr.y))), true, true);
                #region Items in View Area
                for (int i = 0; i < inv.Count; i++)
                {
                    
                        if (GUI.Button(new Rect(0, i * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name)) //inside this scroll view 0 is the edges of scroll view
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                        
                    
                }
                #endregion
                GUI.EndScrollView();
            }
        }
    }

    void DisplayItem()
    {
        switch (selectedItem.Type)
        {
            case ItemType.Food:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), 
                                    selectedItem.Name + "\n" +
                                    selectedItem.Description + "\nValue" +
                                    selectedItem.Value + "\nHeal: " +
                                    selectedItem.Heal + "\nAmount" +
                                    selectedItem.Amount
                        );
                if (health.curHealth < health.maxHealth)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Eat"))
                    {
                        health.curHealth += selectedItem.Heal;
                        DepleteAmount();
                    }
                }
                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }

                break;
            case ItemType.Weapon:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y),
                                    selectedItem.Name + "\n" +
                                    selectedItem.Description + "\nValue" +
                                    selectedItem.Value + "\nDamage: " +
                                    selectedItem.Heal + "\nAmount" +
                                    selectedItem.Amount
                        );
                EquipItem(currentWeapon, 0);
                //if (health.curHealth < health.maxHealth)
                //{
                //    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                //    {
                //        health.curHealth += selectedItem.Heal;
                //        DepleteAmount();
                //    }
                //}
                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Apparel:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y),
                                    selectedItem.Name + "\n" +
                                    selectedItem.Description + "\nValue" +
                                    selectedItem.Value + "\nArmour: " +
                                    selectedItem.Heal + "\nAmount" +
                                    selectedItem.Amount
                        );
                EquipItem(currentHelmet, 1);
                //if (health.curHealth < health.maxHealth)
                //{
                //    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                //    {
                //        health.curHealth += selectedItem.Heal;
                //        DepleteAmount();
                //    }
                //}
                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Crafting:

                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y),
                                    selectedItem.Name + "\n" +
                                    selectedItem.Description + "\nValue" +
                                    //selectedItem.Value + "\nHeal: " +
                                    selectedItem.Heal + "\nAmount" +
                                    selectedItem.Amount
                        );
                
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Use"))
                {
                       
                    DepleteAmount();
                }
              
                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }

                break;
            case ItemType.Quest:
                break;
            case ItemType.Ingredients:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y),
                                    selectedItem.Name + "\n" +
                                    selectedItem.Description + "\nValue" +
                                    //selectedItem.Value + "\nHeal: " +
                                    selectedItem.Heal + "\nAmount" +
                                    selectedItem.Amount
                        );
                
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "use"))
                {
                    
                    DepleteAmount();
                }
                
                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Potion:

                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y),
                                    selectedItem.Name + "\n" +
                                    selectedItem.Description + "\nValue" +
                                    selectedItem.Value + "\nHeal: " +
                                    selectedItem.Heal + "\nAmount" +
                                    selectedItem.Amount
                        );
                if (health.curHealth < health.maxHealth)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Drink"))
                    {
                        health.curHealth += selectedItem.Heal;
                        DepleteAmount();
                    }
                }
                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }

                break;
            case ItemType.Scroll:

                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y),
                                    selectedItem.Name + "\n" +
                                    selectedItem.Description + "\nValue" +
                                    //selectedItem.Value + "\nHeal: " +
                                    selectedItem.Heal + "\nAmount" +
                                    selectedItem.Amount
                        );
                
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Use"))
                {
                        
                    DepleteAmount();
                }
                
                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }

                break;
            default:
                break;
        }
    }

    void DepleteAmount()
    {
        if (selectedItem.Amount > 1)
        {
            selectedItem.Amount--;
        }
        else
        {
            inv.Remove(selectedItem);
            selectedItem = null;
        }
        return;
    }

    void Discard()
    {
        //prevent dupes
        if (selectedItem.Type == ItemType.Weapon)
        {
            if (currentWeapon != null && selectedItem.Mesh.name == currentWeapon.name)
            {
                Destroy(currentWeapon);
            }
        }
        else if (selectedItem.Type == ItemType.Apparel)
        {
            if (currentHelmet != null && selectedItem.Mesh.name == currentHelmet.name)
            {
                Destroy(currentHelmet);
            }
        }
        GameObject clone = Instantiate(selectedItem.Mesh, dropLocation.position, Quaternion.identity);
        clone.AddComponent<Rigidbody>().useGravity = true;
        //this shit needs a collider 
        if (clone.GetComponent<Collider>() == null)
        {
            clone.AddComponent<BoxCollider>();
        }
        DepleteAmount();
    }

    void EquipItem(GameObject item, int location)
    {

        if (item == null || selectedItem.Mesh.name != item.name)
        {
            if (GUI.Button(new Rect(15* scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
            {
                if (item != null)
                {
                    Destroy(item);
                }
                item = Instantiate(selectedItem.Mesh, equippedLocations[location]);
                if (selectedItem.Type == ItemType.Weapon)
                {
                    currentWeapon = item;
                }
                else if(selectedItem.Type == ItemType.Apparel)
                {
                    currentHelmet = item;
                }

                if (item.GetComponent<ItemHandler>() != null)
                {
                    item.GetComponent<ItemHandler>().enabled = false;
                }
                item.name = selectedItem.Mesh.name;
            }
        }
        else
        {

            if (item != null && selectedItem.Mesh.name == item.name)
            {
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "UnEquip"))
                {
                    
                        Destroy(item);
                    
                    
                }
            }


        }

       
    }
    private void OnGUI()
    {
        //if (!PauseMenu.paused)
        if (showInv)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory");
            for (int i = 0; i < sortType.Length; i++)
            {
                if (GUI.Button(new Rect(5.5f * scr.x + i * (scr.x), 0.25f * scr.y,scr.x, 0.25f * scr.y), sortType[i]))
                {
                    print(sortType[i]); 
                    selectedType = sortType[i];
                }
            }
            DisplayInv(selectedType);
            if (selectedItem != null)
            {
                GUI.DrawTexture(new Rect(11 * scr.x, 1.5f * scr.y, 2 * scr.x, 2 * scr.y), selectedItem.Icon);
                DisplayItem();
            }
        }
    }
}












/*
 *
 * Notes: 
 * making our inventory static cos one player
 * 
 */

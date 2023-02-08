using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{

    public enum ItemType { Item , Weapon, Armor}
    public ItemType itemType;

    public string itemName ,itemDescription;
    public int valueInCois;
    public Sprite itemImage;

    public int amountOfEffect;
    public enum AffectType
    {
        HP,Mana
    }
    public AffectType affectType;

    public int WeaponDexterity, armorDefence;
    public int amount;
    public bool isStackable;

    public void UseItem()
    {
        if(itemType == ItemType.Item)
        {
            if(affectType == AffectType.HP)
            {
                PlayerStats.instance.AddHP(amountOfEffect);
            }
            else if(affectType == AffectType.Mana)
            {
                PlayerStats.instance.AddMana(amountOfEffect);
            }

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddItems(this);
            gameObject.SetActive(false);
        }
    }
}

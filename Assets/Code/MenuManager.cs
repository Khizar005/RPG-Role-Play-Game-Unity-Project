using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] Image image;
    [SerializeField] GameObject menu;
    private PlayerStats[] playerStats;
    [SerializeField] TextMeshProUGUI[] nameText, hpText, manaText, currentXpText, xpText;
    [SerializeField] Slider[] xpSlider;
    [SerializeField] Image[] characterImage;
    [SerializeField] GameObject[] characterPanel;

    [SerializeField] GameObject[] statsButtons;

    [SerializeField] TextMeshProUGUI statName, statHP, statMana, statDex, statDef;
    [SerializeField] Image characterstatImage;

    [SerializeField] Transform itemSlotContainerParent;
    [SerializeField] GameObject itemSlotContainer;

    public TextMeshProUGUI itemName, itemDescription;
    public ItemsManager activeItem;




    void Start()
    {
        instance = this;
        menu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (menu.activeInHierarchy)
            {
                menu.SetActive(false);
                GameManager.instance.gameMenuOpned = false;
            }
            else
            {
                UpdateStats();
                menu.SetActive(true);
                GameManager.instance.gameMenuOpned = true;

            }

        }
    }
   public void UpdateStats()
    {
        playerStats = GameManager.instance.GetPlayerStats();
        for(int i = 0; i < playerStats.Length; i++)
        {
            characterPanel[i].SetActive(true);
            nameText[i].text = playerStats[i].playerName;
            hpText[i].text = "HP: " + playerStats[i].currentHp + "/" + playerStats[i].maxHp;
            manaText[i].text = "Mana: " + playerStats[i].currentMana + "/" + playerStats[i].maxMana;
            currentXpText[i].text = "Current xp: " + playerStats[i].currentXP ;

            characterImage[i].sprite = playerStats[i].characterImage;
            xpText[i].text = playerStats[i].currentXP.ToString() + "/" + playerStats[i].xpForNextLevel[playerStats[i].playerLevel];
            xpSlider[i].maxValue = playerStats[i].xpForNextLevel[playerStats[i].playerLevel];
            xpSlider[i].value = playerStats[i].currentXP;
            
        }
    }

    public void StatsMenu()
    {
        for(int i = 0; i< playerStats.Length; i++)
        {
            statsButtons[i].SetActive(true);
            statsButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = playerStats[i].playerName;
        }
        StatMenuUpdate(0);
    }

    public void StatMenuUpdate(int playerSelectedNumber)
    {
        PlayerStats playerSelected = playerStats[playerSelectedNumber];
        statName.text = playerSelected.playerName;
        statHP.text = playerSelected.currentHp.ToString() + "/" + playerSelected.maxHp;
        statMana.text = playerSelected.currentMana.ToString() + "/" + playerSelected.maxMana;
        statDex.text = playerSelected.dexterity.ToString();
        statDef.text = playerSelected.Defence.ToString();
        characterstatImage.sprite = playerSelected.characterImage;

    }

    public void UpdateItemsInventory()
    {
        foreach(Transform itemSlot in itemSlotContainerParent)
        {
            Destroy(itemSlot.gameObject);
        }

        foreach(ItemsManager item in Inventory.instance.GetItemsList())
        {
            RectTransform itemSlot = Instantiate(itemSlotContainer, itemSlotContainerParent).GetComponent<RectTransform>();
            Image itemImage = itemSlot.Find("Image").GetComponent<Image>();
            itemImage.sprite = item.itemImage;
            TextMeshProUGUI itemAmountText = itemSlot.Find("Item Text").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1)
            {

                itemAmountText.text = item.amount.ToString();
            }
            else
            {

               itemAmountText.text = "";
            }

            itemSlot.GetComponent<ItemButton>().itemOnButton = item;

        }
    }

    public void DiscardItem()
    {
        Inventory.instance.RevomeItem(activeItem);
        UpdateItemsInventory();
    }
    public void UseItem()
    {
        activeItem.UseItem();
        DiscardItem();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void FadeImage()
    {
        image.GetComponent<Animator>().SetTrigger("Fade");
    }
}

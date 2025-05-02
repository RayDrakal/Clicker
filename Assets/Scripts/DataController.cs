using UnityEditor.Search;
using UnityEngine;

public class DataController : MonoBehaviour
{
    private static DataController instance;

    public static DataController Instance
    {
        get {
            if (instance == null)
            {
                instance = FindAnyObjectByType<DataController>();

                if (instance == null)
                {
                    GameObject container = new GameObject("DataController");

                    instance = container.AddComponent<DataController>();
                }
            }
            return instance;
        }
    }

    private ItemButton[] itemButtons;

    public long gold
    {
        get
        {
            if(!PlayerPrefs.HasKey("Gold"))
                return 0;
            string tmpGold = PlayerPrefs.GetString("Gold");
            return long.Parse(tmpGold);
        }
        set
        {
            PlayerPrefs.SetString("Gold", value.ToString());
        }
    }
    public long goldPerClick
    {
        get
        {
            if (!PlayerPrefs.HasKey("GoldPerClick")) 
                return 1;
            string tmpGoldPerClick = PlayerPrefs.GetString("GoldPerClick");
            return long.Parse(tmpGoldPerClick);
        }
        set
        {
            PlayerPrefs.SetString("GoldPerClick", value.ToString());
        }
    }

    private void Awake()
    {
        itemButtons = FindObjectsByType<ItemButton>(FindObjectsSortMode.None);
    }

    public void LoadUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;

        upgradeButton.level = PlayerPrefs.GetInt(key + "_level", upgradeButton.level);
        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);
    }

    public void SaveUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;

        PlayerPrefs.SetInt(key + "_level", upgradeButton.level);
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", upgradeButton.currentCost);
    }

    public void LoadItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;

        itemButton.level = PlayerPrefs.GetInt(key + "_level", itemButton.level);
        itemButton.currentCost = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);
        itemButton.goldPerSec = PlayerPrefs.GetInt(key + "_goldPerSec");

        if(PlayerPrefs.GetInt(key+"_isPurchased") == 1) itemButton.isPurchased = true;
        else itemButton.isPurchased = false;
    }

    public void SaveItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;

        PlayerPrefs.SetInt(key + "_level", itemButton.level);
        PlayerPrefs.SetInt(key + "_cost", itemButton.currentCost);
        PlayerPrefs.SetInt(key + "_goldPerSec", itemButton.goldPerSec);

        if (itemButton.isPurchased) PlayerPrefs.SetInt(key + "_isPurchased", 1);
        else PlayerPrefs.SetInt(key + "_isPurchased", 0);
    }

    public int GetGoldPerSec()
    {
        int goldPerSec = 0;

        for(int i=0;i<itemButtons.Length;i++)
        {
            goldPerSec += itemButtons[i].goldPerSec;
        }

        return goldPerSec;
    }
}

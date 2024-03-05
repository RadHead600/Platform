using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _amountMoney;
    [SerializeField] private List<ItemShopParameters> _itemShopParameters;
    [SerializeField] private ShopItemButton _weaponButton;
    [SerializeField] private GameObject _weaponsPanel;

    private void Awake()
    {
        SetStaticParameters();
        _amountMoney.text = SaveParameters.money.ToString();
        CreateWeaponPanels();
        UnlockWeapons();
        gameObject.SetActive(false);
    }

    private void Start()
    {
        Equip(SaveParameters.weaponEquip);
    }

    private void SetStaticParameters()
    {
        if (SaveParameters.weaponsBought == null)
        {
            SaveParameters.levelCount = SceneManager.sceneCountInBuildSettings;
            SaveParameters.levelComplete = new bool[SaveParameters.levelCount];
            SaveParameters.levelPoints = new int[SaveParameters.levelCount];
            SaveParameters.levelStars = new int[SaveParameters.levelCount];
            SaveParameters.levelActive = 1;

            SaveParameters.money = 0;
            _amountMoney.text = SaveParameters.money.ToString();
            SaveParameters.weaponsBought = new Weapon[_itemShopParameters.Count()];
            SaveParameters.weaponEquip = 0;
            Weapon defaultWeapon = _itemShopParameters[0].Item.GetComponent<Weapon>();
            SaveParameters.weaponsBought[0] = defaultWeapon;
        }
    }

    private void CreateWeaponPanels()
    {
        for (int i = 0; i < _itemShopParameters.Count; i++)
        {
            int saveI = i;
            ShopItemButton button = Instantiate(_weaponButton);
            button.transform.SetParent(_weaponsPanel.transform);
            button.transform.localPosition = new Vector3(button.transform.position.x, button.transform.position.y, 0);
            button.transform.localScale = Vector3.one;
            button.Button.onClick.AddListener(() => Equip(saveI));
            button.ItemImage.sprite = _itemShopParameters[i].Sprite;
            button.CostText.text = _itemShopParameters[i].Cost.ToString();
            button.NameText.text = _itemShopParameters[i].Name;
        }
    }

    public void Equip(int weaponNum)
    {
        if (SaveParameters.weaponsBought[weaponNum] != null)
        {
            SaveParameters.weaponEquip = weaponNum;

            for (int i = 0; i < SaveParameters.weaponsBought.Length; i++) 
            {
                if (SaveParameters.weaponsBought[i] != null)
                    _weaponsPanel.GetComponentsInChildren<ShopItemButton>()[i].ItemImage.color = Color.white;
            }

            _weaponsPanel.GetComponentsInChildren<ShopItemButton>()[weaponNum].ItemImage.color = Color.green;
            return;
        }
        BuyWeapon(weaponNum);
    }

    private void UnlockWeapons()
    {
        int i = 0;

        foreach (var itemBought in SaveParameters.weaponsBought)
        {
            if (itemBought == null)
                continue;

            foreach (var item in _itemShopParameters)
            {
                if (itemBought.gameObject.Equals(item.Item))
                {
                    UnlockWeapon(i);
                }
                
                i++;
            }

            i = 0;
        }
    }

    private void UnlockWeapon(int buttonNum)
    {
        _weaponsPanel.GetComponentsInChildren<ShopItemButton>()[buttonNum].ItemImage.material = null;
        _weaponsPanel.GetComponentsInChildren<ShopItemButton>()[buttonNum].CostText.alpha = 0;
    }

    private void BuyWeapon(int weaponNum)
    {
        if (SaveParameters.money < _itemShopParameters[weaponNum].Cost)
        {
            return;
        }

        _weaponsPanel.GetComponentsInChildren<ShopItemButton>()[weaponNum].ItemImage.material = null;
        _weaponsPanel.GetComponentsInChildren<ShopItemButton>()[weaponNum].CostText.alpha = 0;
        SaveParameters.weaponsBought[weaponNum] = _itemShopParameters[weaponNum].Item.GetComponent<Weapon>();
        SaveParameters.money -= _itemShopParameters[weaponNum].Cost;
        _amountMoney.text = SaveParameters.money.ToString();
    }
}

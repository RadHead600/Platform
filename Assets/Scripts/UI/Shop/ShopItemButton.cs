using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemButton : MonoBehaviour
{ 
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Image _itemImage;

    public Button Button => _button;
    public TextMeshProUGUI CostText => _costText;
    public TextMeshProUGUI NameText => _nameText;
    public Image ItemImage => _itemImage;
}

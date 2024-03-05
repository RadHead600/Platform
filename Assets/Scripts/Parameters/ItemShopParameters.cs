using UnityEngine;

[CreateAssetMenu(fileName = "ItemShopParameters", menuName = "CustomParameters/ItemShopParameters")]
public class ItemShopParameters : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _cost;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private GameObject _item;

    public string Name => _name;
    public int Cost => _cost;
    public Sprite Sprite => _sprite;
    public GameObject Item => _item;
}

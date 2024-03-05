using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private TextMeshProUGUI _armorText;
    [SerializeField] private TextMeshProUGUI _bulletsText;

    public TextMeshProUGUI HpText => _hpText;
    public TextMeshProUGUI ArmorText => _armorText;
    public TextMeshProUGUI BulletsText => _bulletsText;

    public void ChangeText(TextMeshProUGUI text, string content)
    {
        text.text = content;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text goldDisplayer;
    public Text goldPerClickDisplayer;
    public Text goldPerSecDisplayer;

    private void Update()
    {
        goldDisplayer.text = "GOLD: " + DataController.Instance.gold;
        goldPerClickDisplayer.text = "GOLD PER CLICK: " + DataController.Instance.goldPerClick;
        goldPerSecDisplayer.text = "GOLD PER SEC: " + DataController.Instance.GetGoldPerSec();
    }
}

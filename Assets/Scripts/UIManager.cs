using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text goldDisplayer;
    public Text goldPerClickDisplayer;
    public Text goldPerSecDisplayer;

    private void Update()
    {
        goldDisplayer.text = "GOLD: " + DataController.GetInstance().GetGold();
        goldPerClickDisplayer.text = "GOLD PER CLICK: " + DataController.GetInstance().GetGoldPerClick();
        goldPerSecDisplayer.text = "GOLD PER SEC: " + DataController.GetInstance().GetGoldPerSec();
    }
}

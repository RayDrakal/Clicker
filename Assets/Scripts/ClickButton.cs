using UnityEngine;

public class ClickButton : MonoBehaviour
{

    public void OnClick()
    {
        int goldPerClick = DataController.GetInstance().GetGoldPerClick();
        DataController.GetInstance().AddGold(goldPerClick);
    }
}

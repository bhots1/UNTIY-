using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
enum CardState //卡片状态
{
    Disable, //等待使用
    Cooling,//冷却
    WaitingSun,//等待阳光
    Ready //可以使用
}


public enum PlantType
{
    Sunflower,//向日葵
    PeaShooter//射击植物
}
public class Cards : MonoBehaviour
{
    public GameObject cardLight;
    public GameObject cardGray;
    public Image cardMask;
    //冷却 可以被点击  不可用
    private CardState cardState = CardState.Disable;
    public PlantType plantType = PlantType.Sunflower;

    private float cdTime = 2;//冷却CD时间
    private float cdTimer = 0;

    [SerializeField]
    private int needSunPoint = 50;


    private void Update()
    {
        switch (cardState)
        {
            case CardState.Cooling:
                CoolingUpdate();//冷却状态更新
                break;
            case CardState.WaitingSun:
                WaitingSunUpdate();//等待阳光状态更新
                break;
            case CardState.Ready:
                ReadyUpdate();
                break;
            default:
                break;
        }
    }

    void CoolingUpdate()
    {
        cdTimer += Time.deltaTime;

        cardMask.fillAmount = (cdTime - cdTimer) / cdTime;

        if (cdTimer >= cdTime)
        {
            TransitionToWaitingSun();
        }

    }
    void WaitingSunUpdate()
    {
        //if (needSunPoint <= SunManager.Instance.SunPoint)
        //{
        //    TransitionToReady();
        //}
    }
    void ReadyUpdate()
    {
        //if (needSunPoint > SunManager.Instance.SunPoint)
        //{
        //    TransitionToWaitingSun();
        //}

    }

    void TransitionToWaitingSun()
    {
        cardState = CardState.WaitingSun;

        cardLight.SetActive(false);
        cardGray.SetActive(true);
        cardMask.gameObject.SetActive(false);
    }
    void TransitionToReady()
    {
        cardState = CardState.Ready;

        cardLight.SetActive(true);
        cardGray.SetActive(false);
        cardMask.gameObject.SetActive(false);
    }
    void TransitionToCooling()
    {
        cardState = CardState.Cooling;
        cdTimer = 0;
        cardLight.SetActive(false);
        cardGray.SetActive(true);
        cardMask.gameObject.SetActive(true);
    }


}

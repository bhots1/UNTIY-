using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
enum CardState //��Ƭ״̬
{
    Disable, //�ȴ�ʹ��
    Cooling,//��ȴ
    WaitingSun,//�ȴ�����
    Ready //����ʹ��
}


public enum PlantType
{
    Sunflower,//���տ�
    PeaShooter//���ֲ��
}
public class Cards : MonoBehaviour
{
    public GameObject cardLight;
    public GameObject cardGray;
    public Image cardMask;
    //��ȴ ���Ա����  ������
    private CardState cardState = CardState.Disable;
    public PlantType plantType = PlantType.Sunflower;

    private float cdTime = 2;//��ȴCDʱ��
    private float cdTimer = 0;

    [SerializeField]
    private int needSunPoint = 50;


    private void Update()
    {
        switch (cardState)
        {
            case CardState.Cooling:
                CoolingUpdate();//��ȴ״̬����
                break;
            case CardState.WaitingSun:
                WaitingSunUpdate();//�ȴ�����״̬����
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

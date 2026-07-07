using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
public class ShotP3 : MonoBehaviour
{
    [SerializeField] private int Scnt;
    [SerializeField] private int ShotDistance;//動き出す範囲
    public GameObject NormalShot;
    [SerializeField] private int shotlate,shotlenge;//撃つ感覚,撃つ角度
    [SerializeField] private int shotspeed;//球の速さ
    [SerializeField] private float shellY;//発生する高さ
    private int R;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    float countdown = 3f;
    int count;
    void FixedUpdate()
    {
        if (countdown >= 0)
        {
            countdown -= Time.deltaTime;
            count = (int)countdown;
        }

        if (countdown <= 0)
        {
            Supponn MV;//呼ぶスクリプトにあだ名をつける
            GameObject obj = GameObject.Find("suppon");//Circleというゲームオブジェクトを探す
            MV = obj.GetComponent<Supponn>();//スクリプトを取得
            Vector3 Pvec = new Vector3(MV.playerX, transform.position.y, MV.playerZ);//プレイヤーの座標を保存
            Vector3 vec = Pvec - this.transform.position;//プレイヤーの位置から敵の位置を引く
            if (ShotDistance > vec.magnitude)
            {
                Scnt = Scnt + 1;//発射する間隔
                if (Scnt % shotlate == 0)
                {

                    var s = Instantiate(NormalShot, this.transform.position + new Vector3(0, shellY, 0), Quaternion.identity);
                    //Vector3 vet = this.transform.position;
                    //vet = vet.normalized * shotspeed;
                    //s.GetComponent<Rigidbody>().velocity = vet;
                    float rad = R * Mathf.Deg2Rad;
                    Vector3 direction = new Vector3(Mathf.Cos(rad), shellY, Mathf.Sin(rad));
                    Vector3 vet = direction * shotspeed;
                    s.GetComponent<Rigidbody>().velocity = vet;
                    Scnt = 0;
                    R = R + shotlenge;
                    if (R >= 360)
                    {
                        R = 0;
                    }
                }
            } 
        }
    }
}
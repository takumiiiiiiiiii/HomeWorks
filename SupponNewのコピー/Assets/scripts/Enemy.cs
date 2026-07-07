using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [SerializeField] private BoxCollider BC;
    [SerializeField] private int Scnt;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        Supponn MV;//呼ぶスクリプトにあだ名をつける
        GameObject obj = GameObject.Find("suppon");//Circleというゲームオブジェクトを探す
        MV = obj.GetComponent<Supponn>();//スクリプトを取得
        //当たり判定の設定
        if (MV.Bcnt >= 50)//スッポンの大きさが10以上だとboxcolliderのistriggerが有効
        {
            BC.isTrigger = true;
        }
        else
        {
            BC.isTrigger = false;
            Scnt = Scnt + 1;
            if (Scnt % 100 == 0)
            {
                Instantiate(Bullet, this.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                Scnt = 0;
            }
        }
    }

    void OnTriggerEnter(Collider t)
    {
        Supponn MV;//呼ぶスクリプトにあだ名をつける
        GameObject obj = GameObject.Find("suppon");//Circleというゲームオブジェクトを探す
        MV = obj.GetComponent<Supponn>();//スクリプトを取得
        if (t.gameObject.tag == "Player")
        {
            
            MV.Bcnt += 1;
            Destroy(this.gameObject);
        }
        if (t.gameObject.tag == "Player" && MV.Bcnt >= 50)
        {
            MV.Bcnt += 10;
            Destroy(this.gameObject);
        }
    }
}

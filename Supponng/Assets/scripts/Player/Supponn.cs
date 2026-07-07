using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Supponn : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CapsuleCollider cd;
    [SerializeField] private int moveSpeed, spr, MM, SS;//移動速度,すっぽん落下速度,移動速度追加,落下速度追加
    [SerializeField] public int Bcnt;//大きくなるカウント
    [SerializeField] public float Bw;//大きさ
    [HideInInspector] public bool up,ground;//上昇,地面に接触しているか
    [HideInInspector] public bool NM;//動けなくする
    private int NMcnt;//動けない時間
    [HideInInspector] public float playerX, playerZ;//プレイヤーの座標を保存
    [SerializeField] public Vector3 Npos; //最初の座標
    [SerializeField] public int big1, big2, big3, big4;
    public AudioClip sound1, sound2;//音関係
    AudioSource audioSource;
    public bool pong;
    public GameObject pate, pate2, pate3, pate4, pate5;//衝撃波パーティクル
    // Start is called before the first frame update
    void Start()
    {
        up = false;
        Npos = transform.position;//最初のy座標
        audioSource = GetComponent<AudioSource>();
    }
    float countdown = 3f;
    int count;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (countdown >= 0)
        {
            countdown -= Time.deltaTime;
            count = (int)countdown;
        }
        //大きさを変えるプログラム
        if (countdown <= 0)
        {
            if (Bcnt >= big1)
            {
                if (Bw < 0.1f)
                {
                    Bw = Bw + 0.01f;
                    this.transform.localScale = new Vector3(this.transform.localScale.x + Bw, this.transform.localScale.y + Bw, +this.transform.localScale.z + Bw);
                    Npos = new Vector3(Npos.x, Npos.y + Bw * 3, Npos.z);
                }
            }
            if (Bcnt >= big2)
            {
                if (Bw < 0.2f)
                {
                    Bw = Bw + 0.01f;
                    this.transform.localScale = new Vector3(this.transform.localScale.x + Bw, this.transform.localScale.y + Bw, +this.transform.localScale.z + Bw);
                    Npos = new Vector3(Npos.x, Npos.y + Bw * 3, Npos.z);
                }
            }
            if (Bcnt >= big3)
            {
                if (Bw < 0.4f)
                {
                    Bw = Bw + 0.02f;
                    this.transform.localScale = new Vector3(this.transform.localScale.x + Bw, this.transform.localScale.y + Bw, +this.transform.localScale.z + Bw);
                    Npos = new Vector3(Npos.x, Npos.y + Bw * 3, Npos.z);
                }
                MM = 2;//移動速度アップ
                SS = 120;//落下速度アップ
            }
            if (Bcnt >= big4)
            {
                if (Bw < 0.5f)
                {
                    Bw = Bw + 0.01f;
                    this.transform.localScale = new Vector3(this.transform.localScale.x + Bw, this.transform.localScale.y + Bw, +this.transform.localScale.z + Bw);
                    Npos = new Vector3(Npos.x, Npos.y + Bw * 3, Npos.z);
                }
                MM = 4;//移動速度アップ
                SS = 240;//落下速度アップ
            }
            //移動に関するプログラム
            if (NM == false)//移動できる状態か
            {
                //スッポンの移動
                if (Input.GetKey(KeyCode.Space))//すっぽん落下
                {
                    rb.velocity = new Vector3(0, -(spr + SS), 0);
                }
                else//すっぽん上昇
                {
                    if (transform.position.y < Npos.y)//現在のY座標が最初のY座標より小さい時
                    {
                        rb.velocity = new Vector3(rb.velocity.x, spr + SS, rb.velocity.z);//上方向に力を加える
                    }
                    else
                    {//Y座標が最初のY座標と同じになったら
                        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);//上方向への力を無くす
                        up = false;
                    }
                    if (transform.position.y > Npos.y)
                    {
                        this.transform.position = new Vector3(transform.position.x, Npos.y, transform.position.z);
                        ground = false;
                    }
                    //移動
                    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
                    {
                        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * (moveSpeed + MM), rb.velocity.y, Input.GetAxisRaw("Vertical") * (moveSpeed + MM));//移動 
                    }
                }
            }

            if (NM == true)
            {
                NMcnt += 1;
                Debug.Log(NMcnt);
                if (NMcnt == 50)
                {
                    NMcnt = 0;
                    NM = false;
                    //gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
            }

            //現在の座標を保存
            playerX = transform.position.x;
            playerZ = transform.position.z;

        }
    }
    private void Update()
    {
        //効果音の再生
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(sound1);
            pong = true;
        }
        if (Input.GetKey(KeyCode.Space) == false && pong == true)
        {
            audioSource.PlayOneShot(sound2);
            pong = false;
        }
    }
    void OnCollisionEnter(Collision CD)
    {
        if (CD.gameObject.tag == "ground")
        {
            Debug.Log("ground");
            if (Bcnt < big1)
            {
                Instantiate(pate, this.transform.position + new Vector3(0, -1.5f, 0), Quaternion.AngleAxis(90.0f, new Vector3(1.0f, 0.0f, 0.0f)));//衝撃は発生
            }
            if (Bcnt >= big1 && Bcnt < big2)
            {
                Instantiate(pate2, this.transform.position + new Vector3(0, -2.0f, 0), Quaternion.AngleAxis(90.0f, new Vector3(1.0f, 0.0f, 0.0f)));//衝撃は発生
            }
            if (Bcnt >= big2 && Bcnt < big3)
            {
                Instantiate(pate3, this.transform.position + new Vector3(0, -3.0f,0), Quaternion.AngleAxis(90.0f, new Vector3(1.0f, 0.0f, 0.0f)));//衝撃は発生
            }
            if (Bcnt >= big3 && Bcnt < big4)
            {
                Instantiate(pate4, this.transform.position + new Vector3(0, -4.0f,0), Quaternion.AngleAxis(90.0f, new Vector3(1.0f, 0.0f, 0.0f)));//衝撃は発生
                Instantiate(pate3, this.transform.position + new Vector3(0, 0, 0), Quaternion.AngleAxis(90.0f, new Vector3(1.0f, 0.0f, 0.0f)));//衝撃は発生
            }
            if (Bcnt >= big4)
            {
                Instantiate(pate5, this.transform.position + new Vector3(0, -7.0f,0), Quaternion.AngleAxis(90.0f, new Vector3(1.0f, 0.0f, 0.0f)));//衝撃は発生
                Instantiate(pate3, this.transform.position + new Vector3(0, 0, 0), Quaternion.AngleAxis(90.0f, new Vector3(1.0f, 0.0f, 0.0f)));//衝撃は発生
                Instantiate(pate3, this.transform.position + new Vector3(0, 3, 0), Quaternion.AngleAxis(90.0f, new Vector3(1.0f, 0.0f, 0.0f)));//衝撃は発生
            }
            ground = true;
        }
    }
    void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.tag == "balet"&&Input.GetKey(KeyCode.Space) == false)
        {
            NM = true;//動けなくする
            Debug.Log("hit");
            rb.velocity = Vector3.zero;
            //gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        Debug.Log(Bcnt);
    }
}
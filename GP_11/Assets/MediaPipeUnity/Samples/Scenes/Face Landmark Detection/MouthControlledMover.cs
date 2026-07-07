// MouthControlledMover.cs

using UnityEngine;

public class MouthControlledMover : MonoBehaviour
{
    [SerializeField] private float openThreshold = 0.5f;
    [SerializeField] private Color closedMouthColor = Color.blue;    // 口を閉じているときの色
    [SerializeField] private Color openMouthColor = Color.red;       // 口を開けているときの色

    private Renderer objectRenderer;
    private bool lastMouthState = false; // 前回の口の状態

    void Start()
    {
        // Rendererコンポーネントを取得
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
           Debug.LogError("Renderer component not found on " + gameObject.name);
        }

        // 初期色を設定
        objectRenderer.material.color = closedMouthColor;
    }

    void Update()
    {
        // 口の開閉状態をチェック
        bool isMouthOpen = GameInput.Instance.MouthOpen > openThreshold;
        Debug.Log("値"+GameInput.Instance.MouthOpen);
        // 状態が変わったときのみ色を変更
        if (isMouthOpen != lastMouthState)
        {
            if (isMouthOpen)
            {
                // 口を開けたとき：赤色に変更
                objectRenderer.material.color = openMouthColor;
                Debug.Log("口を開けました！色を赤に変更");
            }
            else
            {
                // 口を閉じたとき：青色に変更
                objectRenderer.material.color = closedMouthColor;
                Debug.Log("口を閉じました！色を青に変更");
            }

            lastMouthState = isMouthOpen;
        }
    }
}

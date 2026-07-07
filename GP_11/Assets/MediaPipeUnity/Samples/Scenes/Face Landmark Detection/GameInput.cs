// GameInput.cs

using UnityEngine;

public class GameInput : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameInput Instance { get; private set; }
    public float MouthOpen { get; private set; }

    void Awake() => Instance = this;

    // FaceLandmarkerRunner から呼ばれる
    public void SetMouthOpen(float value)
    {
        MouthOpen = value;  // 0.0～1.0 の範囲
    }
}
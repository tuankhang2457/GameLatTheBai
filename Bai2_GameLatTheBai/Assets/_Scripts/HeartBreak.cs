using UnityEngine;
using TMPro;

public class HeartBreak : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI heartBreak;

    [SerializeField] protected int count = 0;

    [SerializeField] public static HeartBreak instance;

    public void Awake()
    {
        if (HeartBreak.instance != null) return;
        HeartBreak.instance = this;
    }
    public void IncreaseScore()
    {
        count++;
        heartBreak.text = "" + count;
    }
}

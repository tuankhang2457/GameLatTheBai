using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    Button currentBtn;
    Animator animator;
    public Image icon;
    public int id;

    protected bool isFlipped = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentBtn = GetComponent<Button>();
        currentBtn.onClick.AddListener(OnCardClicked);
    }

    public void InitCard(int _id, Sprite iconSprite)
    {
        id = _id;
        icon.sprite = iconSprite;
    }

   public void OnCardClicked()
    {
        if (isFlipped || GameManager.Instance.isChecking) return;

        FlipCard(true);
        GameManager.Instance.CardSelected(this);
    }

    public void FlipCard(bool state)
    {
        isFlipped = state;
        animator.SetBool("isFlip", state);
    }
    void Update()
    {

    }
}
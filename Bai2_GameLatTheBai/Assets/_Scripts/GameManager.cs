using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AdaptivePerformance;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Transform cardContainer;
    public GameObject cardPrefabs;
    public Sprite[] cardIcons;
    [HideInInspector] public bool isChecking = false;
    [SerializeField] List<CardController> FlippedCard = new List<CardController>();
    [SerializeField] List<GameObject> Cards = new List<GameObject>();

    static private GameManager instance;
    static public GameManager Instance => instance;

    private void Awake()
    {
        if (Instance != null) return;
        GameManager.instance = this;
    }


    void Start()
    {
        for (int i = 0; i < cardIcons.Length; i++)
        {
            GameObject card1 = Instantiate(cardPrefabs, cardContainer);
            GameObject card2 = Instantiate(cardPrefabs, cardContainer);
            Cards.Add(card1);
            Cards.Add(card2);
            
            
            card1.GetComponent<CardController>().InitCard(i, cardIcons[i]);
            card2.GetComponent<CardController>().InitCard(i, cardIcons[i]);
        }
        
        for (int i = 0; i < 30; i++)
        {
            int rand = Random.Range(0, cardContainer.childCount);
            cardContainer.GetChild(rand).SetAsFirstSibling();
        }

    }

    public void CardSelected(CardController card)
    {
        if (FlippedCard.Contains(card)) return;
        FlippedCard.Add(card);

        if(FlippedCard.Count == 2)
        {
            isChecking = true;
            StartCoroutine(CheckMathRoutine());
        }
    }

    protected virtual IEnumerator CheckMathRoutine()
    {
        CardController card1 = FlippedCard[0];
        CardController card2 = FlippedCard[1];

        yield return new WaitForSeconds(0.8f);

        if(card1.id == card2.id)
        {
            CheckWIn.instance.UpdateDoneScore();
            card1.GetComponent<Button>().interactable = false;
            card2.GetComponent<Button>().interactable = false;
            Cards.Remove(card1.gameObject);
            Cards.Remove(card2.gameObject);
        }
        else
        {
            HeartBreak.instance.IncreaseScore();
            card1.FlipCard(false);
            card2.FlipCard(false);
        }

        FlippedCard.Clear();
        isChecking = false;
    }

    void Update()
    {
   
    }
}

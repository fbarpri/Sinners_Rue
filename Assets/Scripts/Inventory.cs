using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerInventory : MonoBehaviour
{
    public bool hasKey = false;
    public bool gotCorrectTemp = false;
    public bool windowOpenable = false;
    public bool hasScissors = false;
    public bool hasMail = false;
    public bool hasFamilyPhoto = false;
    public bool hasFoundBox = false;
    public bool hasFoundCookbook = false;
    public bool hasFoundMakeup = false;
    public bool lust = false;
    public bool sloth = false;
    public bool envy = false;
    public bool pride = false;
    public bool wrath = false;
    public bool greed = false;
    public HoverText hoverText;
    public bool hasCandle = false;
    public bool candleLit = false;
<<<<<<< HEAD
    public bool hasMatches = false;
=======
    public bool hasWine = false;
>>>>>>> 469bfb98cec72745ab3eb9bbf90891858f3d56c1
    public Light2D candleLight;
    private Animator animator;
    public bool allSins = false;
    public bool hasPushedChair = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
{
    animator.SetBool("hasCandle", hasCandle);
    animator.SetBool("candleLit", candleLit);
    animator.SetBool("hasWine", hasWine);

    if (lust && sloth && envy && pride && wrath && greed)
    {
        allSins = true;
        hoverText.ShowText("God. I need a drink.");
    }
}
}
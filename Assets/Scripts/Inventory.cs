using UnityEngine;

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


    void Update()
{
    if (lust && sloth && envy && pride && wrath && greed)
    {
        Debug.Log("ALL SINS FOUND.");
        allSinsLogged = true;
    }
}
}
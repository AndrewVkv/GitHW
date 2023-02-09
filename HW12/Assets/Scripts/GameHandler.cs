using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameHandler : MonoBehaviour
{
    private Movement heroMovement;
    private UIPannel uiPannel;
    private Loose looseEv;
    private Win winEv;
    private HeroCollision heroCollision;

    public Movement GetMovement() => heroMovement;
    public UIPannel GetUIPannel() => uiPannel;
    public Loose GetLooseEv() => looseEv;
    public Win GetWinEv() => winEv;
    public HeroCollision GetHeroCollision() => heroCollision;

    private void OnEnable()
    {
        heroMovement = GetComponentInChildren<Movement>();
        uiPannel = GetComponentInChildren<UIPannel>();
        looseEv = GetComponentInChildren<Loose>();
        winEv = GetComponentInChildren<Win>();
        heroCollision = GetComponentInChildren<HeroCollision>();
    }

}



using Assets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class GameUnlockable : MonoBehaviour
{
    public GameObject step1Sprite;
    public GameObject step2Sprite;
    public GameObject step3Sprite;
    public GameObject step4Sprite1;
    public GameObject step4Sprite2;
    public GameObject step0Banner;
    public GameObject step1Banner;
    public GameObject step2Banner;

    public TextMeshProUGUI counter;
    public TextMeshProUGUI step2QoL;
    public TextMeshProUGUI step3QoL;

    public Button step1Button;
    public Button step2Button;
    public Button step3Button;
    public Button step4Button;

    private float timeRemainingStep1 = -99;
    private float timeRemainingStep2 = -99;
    private float timeRemainingStep3 = -99;

    private bool isStep1ButtonInteractable = false;
    private bool isStep2ButtonInteractable = false;
    private bool isStep3ButtonInteractable = false;

    private bool interactableFlag1 = true;
    private bool interactableFlag2 = true;
    private bool interactableFlag3 = true;


    // Start is called before the first frame update
    void Start()
    {
        step1Banner.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        step2Banner.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        step4Sprite1.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        step4Sprite2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemainingStep1 > 0)
        {
            isStep1ButtonInteractable = false;
            timeRemainingStep1 -= Time.deltaTime;
        }
        else if(timeRemainingStep1 > -99)
        {
            isStep1ButtonInteractable = true;
        }

        if (timeRemainingStep2 > 0)
        {
            isStep2ButtonInteractable = false;
            timeRemainingStep2 -= Time.deltaTime;
        }
        else if (timeRemainingStep2 > -99)
        {
            isStep2ButtonInteractable = true;
        }

        if (timeRemainingStep3 > 0)
        {
            isStep3ButtonInteractable = false;
            timeRemainingStep3 -= Time.deltaTime;
        }
        else if (timeRemainingStep3 > -99)
        {
            isStep3ButtonInteractable = true;
        }

        if (isStep1ButtonInteractable)
        {
            step1Button.interactable = true;
        }
        else
        {
            step1Button.interactable = false;
        }

        if (isStep2ButtonInteractable)
        {
            step2Button.interactable = true;
        }
        else
        {
            step2Button.interactable = false;
        }

        if (isStep3ButtonInteractable)
        {
            step3Button.interactable = true;
        }
        else
        {
            step3Button.interactable = false;
        }
    }

    public void incrementThingCounterText0()
    {
        Game.incrementThingCounter(1);
        counter.text = "Things: " + Game.getThingCounter().ToString();

        verifyStep();
    }

    public void incrementThingCounterText1()
    {
        Game.incrementThingCounter(5);
        counter.text = "Things: " + Game.getThingCounter().ToString();

        verifyStep();

        timeRemainingStep1 = 1;
    }

    public void incrementThingCounterText2()
    {
        Game.incrementThingCounter(25);
        counter.text = "Things: " + Game.getThingCounter().ToString();

        verifyStep();

        timeRemainingStep2 = 3;
    }

    public void incrementThingCounterText3()
    {
        Game.incrementThingCounter(75);
        counter.text = "Things: " + Game.getThingCounter().ToString();

        verifyStep();

        timeRemainingStep3 = 6;
    }

    private void verifyStep()
    {
        if (interactableFlag1 && Game.verifyUnlockableStep() == 1)
        {
            isStep1ButtonInteractable = true;
            step1Sprite.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            step0Banner.SetActive(false);
            step1Banner.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            step2Button.gameObject.SetActive(true);
            step2QoL.gameObject.SetActive(true);
            step2Sprite.SetActive(true);
            step2Sprite.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);

            interactableFlag1 = false;
        }
        else if (interactableFlag2 && Game.verifyUnlockableStep() == 2)
        {
            isStep2ButtonInteractable = true;
            step2Sprite.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            step1Banner.SetActive(false);
            step2Banner.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            step3Button.gameObject.SetActive(true);
            step3QoL.gameObject.SetActive(true);
            step3Sprite.SetActive(true);
            step3Sprite.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);

            interactableFlag2 = false;
        }
        else if (Game.verifyUnlockableStep() == 3 && interactableFlag3)
        {
            isStep3ButtonInteractable = true;
            step3Sprite.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            step2Banner.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            step4Button.gameObject.SetActive(true);
            step4Sprite1.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            step4Sprite2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);

            interactableFlag3 = false;
        }
        else if (Game.verifyUnlockableStep() == 4)
        {
            step4Button.interactable = true;
            step4Sprite1.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            step4Sprite2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
}

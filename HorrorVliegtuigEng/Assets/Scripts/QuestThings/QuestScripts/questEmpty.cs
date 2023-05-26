using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questEmpty : MonoBehaviour
{
    public bool isActive;
    public int stage;
    public Quest quest;
    public QuestManager manager;
    //public PickupObject pickup;       //checken of je iets moet oppakken

    //public StartConvo convo;          //gesprek starten
    //public BoxCollider door;          //collider die de quest verder laat gaan
    //public MakeCartFollow cart;       //checken of je de cart meeneemt

    private void Start()
    {
        isActive = false;
    }

    private void Update()
    {
        isActive = quest.isActive;

        if (isActive)
        {
            stage = quest.currentObjective;
            switch (stage)
            {
                case 0:
                    //door.enabled = true;      //je kan een collider in een bepaalde fase aanzetten,
                                                // omdat hij anders op elk punt de quest verder laat gaan
                    break;
                case 1:
                    //if (pickup.CurrentObject != null)     //als je iets in je hand hebt
                    //{
                    //    if (pickup.CurrentObject.gameObject.tag == "tag")
                    //    {
                    //        
                    //    }
                    //}
                    break;
                case 2:
                    //if (cart.getPushCart())               //als je de cart pushed
                    //{
                    //    manager.advanceQuest(quest);      //advance deze quest
                    //}
                    break;
            }
        }
        else
        {
            //door.enabled = false;             //standaard de collider uit
        }
    }
}

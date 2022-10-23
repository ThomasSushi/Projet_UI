using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public BackgroundController backgroundController;

    void Start()
    {
        bottomBar.PlayScene(currentScene);
        backgroundController.SetBackground(currentScene.background);
    }

    public void GererClic(){  //se lance lorsque l'on clic sur le boutton
       
            if (bottomBar.IsCompleted())  //si l'action est terminé
            {
                if (bottomBar.IsLastSentence())  //si on arrive dans la dernier phrase de la scene on lance la nouvelle scene
                {
                    currentScene = currentScene.nextScene;
                    bottomBar.PlayScene(currentScene);
                    backgroundController.SwitchBackground(currentScene.background);
                }
                else //sinon on lance la prochaine phrase
                {
                    bottomBar.PlayNextSentence();
                }
            }
        
    }
}

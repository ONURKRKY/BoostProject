using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

   [SerializeField] float LevelLoadDelay=2f;
     void OnCollisionEnter(Collision other)
   {

   switch(other.gameObject.tag)
   {
       case"Friendly":
       Debug.Log("friendly");
       break;

       case"Finish":
       StartSuccessSequence();
       break;
 
         default:
       
         StartCrashSequence();
        break;

   }

   }

void StartSuccessSequence()
   {
   GetComponent<Movement>().enabled=false;  
   Invoke("LoadNextLevel", LevelLoadDelay );
   }
   void StartCrashSequence()
   {
      GetComponent<Movement>().enabled=false;   
      Invoke("ReloadLevel", LevelLoadDelay );

   }

void LoadNextLevel()
{
 int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
 int nextSceneIndex=currentSceneIndex+1;

 if(nextSceneIndex==SceneManager.sceneCountInBuildSettings)
 {
      nextSceneIndex=0;
 }
   SceneManager.LoadScene(nextSceneIndex );


}
void ReloadLevel()
{
   int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
   SceneManager.LoadScene(currentSceneIndex);
}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

   [SerializeField] float LevelLoadDelay=2f;

   [SerializeField] AudioClip success;
   [SerializeField] AudioClip crash;
   AudioSource audioSource;

   bool isTransitioning=false;

   void Start()    
   {
    audioSource=GetComponent<AudioSource>();

   }

     void OnCollisionEnter(Collision other)
   {
      if(isTransitioning){return;}

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
      isTransitioning=true;
      audioSource.Stop();
      audioSource.PlayOneShot(success);
   GetComponent<Movement>().enabled=false;  
   Invoke("LoadNextLevel", LevelLoadDelay );
   }
   void StartCrashSequence()
   {
      isTransitioning=true;
      audioSource.Stop();
      audioSource.PlayOneShot(crash);
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

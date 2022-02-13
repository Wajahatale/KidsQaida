/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        public Transform TextTargetName;

        //------------Begin Sound----------
        public AudioSource soundTarget;
        public AudioClip clipTarget;
        private AudioSource[] allAudioSources;

        //function to stop all sounds
        void StopAllAudio()
        {
            allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource audioS in allAudioSources)
            {
                audioS.Stop();
            }
        }

        //function to play sound
        void playSound(string ss)
        {
            clipTarget = (AudioClip)Resources.Load(ss);
            soundTarget.clip = clipTarget;
            soundTarget.loop = false;
            soundTarget.playOnAwake = false;
            soundTarget.Play();
        }

        //-----------End Sound------------




        #region PRIVATE_MEMBER_VARIABLES

        private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
            //Register / add the AudioSource as object
            soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();

        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

            //Play Sound, IF detect an target

            if (mTrackableBehaviour.TrackableName == "alifmarker")
            {
                TextTargetName.GetComponent<Text>().text = "Annanas(Pineapple)";

                playSound("sounds/Alif");
            }

            if (mTrackableBehaviour.TrackableName == "Baymarker")
            {
                TextTargetName.GetComponent<Text>().text = "Bakri(Goat)";
                playSound("sounds/Bay");
            }

            if (mTrackableBehaviour.TrackableName == "Paymarker")
            {
                TextTargetName.GetComponent<Text>().text = "Pankha(Fan)";
                playSound("sounds/Pay");
            }

            if (mTrackableBehaviour.TrackableName == "teymarker")
            {
                TextTargetName.GetComponent<Text>().text = "Titli(Butterfly)";
                playSound("sounds/Tey");
            }

            if (mTrackableBehaviour.TrackableName == "Taymarker")
            {
                TextTargetName.GetComponent<Text>().text = "Tamatar(Tomato)";
                playSound("sounds/Tay");
            }

            if (mTrackableBehaviour.TrackableName == "Saymarker")
            {
                TextTargetName.GetComponent<Text>().text = "Samar(Fruit)";
                playSound("sounds/Say");
            }

            if (mTrackableBehaviour.TrackableName == "Geemmarker")
            {
                TextTargetName.GetComponent<Text>().text = "Jahaz(Ship)";
                playSound("sounds/Geem");
            }

            if (mTrackableBehaviour.TrackableName == "Chaymarker")
            {
                TextTargetName.GetComponent<Text>().text = "Chaku(Knife)";
                playSound("sounds/Chay");
            }

            if (mTrackableBehaviour.TrackableName == "Haymarker")
            {
                TextTargetName.GetComponent<Text>().text = "Hookah";
                playSound("sounds/Hay");
            }

            if (mTrackableBehaviour.TrackableName == "Khaymarker")
            {
                TextTargetName.GetComponent<Text>().text = "Khargosh(Rabbit)";
                playSound("sounds/Khay");
            }

            if (mTrackableBehaviour.TrackableName == "Daalmarker")
            {
                TextTargetName.GetComponent<Text>().text = "Darakht(Tree)";
                playSound("sounds/Daal");
            }

            if (mTrackableBehaviour.TrackableName == "dulmarker")
            {
                TextTargetName.GetComponent<Text>().text = "DoubleRoti(Bread)";
                playSound("sounds/dul");
            }

            if (mTrackableBehaviour.TrackableName == "Zaalmarker")
            {
                TextTargetName.GetComponent<Text>().text = "Zakheera(Storage)";
                playSound("sounds/Zaal");
            }

            if (mTrackableBehaviour.TrackableName == "Raymarker")
            {
                TextTargetName.GetComponent<Text>().text = "Railgari(Train)";
                playSound("sounds/Ray");
            }

            if (mTrackableBehaviour.TrackableName == "rdaymarker")
            {
                TextTargetName.GetComponent<Text>().text = "Kulhari(Axe)";
                playSound("sounds/Rday");
            }

            if (mTrackableBehaviour.TrackableName == "Zaymarker")
            {
                TextTargetName.GetComponent<Text>().text = "Zameen(Earth)";
                playSound("sounds/Zay");
            }

            if (mTrackableBehaviour.TrackableName == "Zsaymarker")
            {
                TextTargetName.GetComponent<Text>().text = "Television";
                playSound("sounds/Zsay");
            }

            if (mTrackableBehaviour.TrackableName == "Seenmarker")
            {
                TextTargetName.GetComponent<Text>().text = "Saib(Apple)";
                playSound("sounds/Seen");
            }

            if (mTrackableBehaviour.TrackableName == "Sheenmarker")
            {
                TextTargetName.GetComponent<Text>().text = "Shair(Lion)";
                playSound("sounds/Sheen");
            }

            if (mTrackableBehaviour.TrackableName == "Soadmarker")
            {
                TextTargetName.GetComponent<Text>().text = "Sandook(Chest)";
                playSound("sounds/Soad");
            }
            if (mTrackableBehaviour.TrackableName == "Zoadmarker")
            {
                TextTargetName.GetComponent<Text>().text = "Zaeef(Old)";
                playSound("sounds/Zoad");
            }

            if (mTrackableBehaviour.TrackableName == "Toamarker")
            {
                TextTargetName.GetComponent<Text>().text = "Tota(Parrot)";
                playSound("sounds/Toa");
            }

            if (mTrackableBehaviour.TrackableName == "Zoazmarker")
            {
                TextTargetName.GetComponent<Text>().text = "Zaruuf(Pottery)";
                playSound("sounds/Zoaz");
            }

            if (mTrackableBehaviour.TrackableName == "Aeinmarker")
            {
                TextTargetName.GetComponent<Text>().text = "Uqaab(Eagle)";
                playSound("sounds/Aein");
            }

            if (mTrackableBehaviour.TrackableName == "Ghainmarker")
            {
                TextTargetName.GetComponent<Text>().text = "Ghubara(Balloon)";
                playSound("sounds/Ghain");
            }

            if (mTrackableBehaviour.TrackableName == "Faymarker")
            {
                TextTargetName.GetComponent<Text>().text = "Fawara(Fountain)";
                playSound("sounds/Fay");
            }

            if (mTrackableBehaviour.TrackableName == "Qafmarker")
            {
                TextTargetName.GetComponent<Text>().text = "Qalam(Pen)";
                playSound("sounds/Qaf");
            }
            if (mTrackableBehaviour.TrackableName == "kiafmarker")
            {
                TextTargetName.GetComponent<Text>().text = "Kashti(Boat)";
                playSound("sounds/Kiaf");
            }

            if (mTrackableBehaviour.TrackableName == "Gafmarker")
            {
                TextTargetName.GetComponent<Text>().text = "Gaind(Ball)";
                playSound("sounds/Gaaf");
            }

            if (mTrackableBehaviour.TrackableName == "Laammarker")
            {
                TextTargetName.GetComponent<Text>().text = "Lattu(Top)";
                playSound("sounds/Laam");
            }

            if (mTrackableBehaviour.TrackableName == "Meemmarker")
            {
                TextTargetName.GetComponent<Text>().text = "MomBatti";
                playSound("sounds/Meem");
            }

            if (mTrackableBehaviour.TrackableName == "Noonmarker")
            {
                TextTargetName.GetComponent<Text>().text = "Narial(Coconut)";
                playSound("sounds/Noon");
            }

            if (mTrackableBehaviour.TrackableName == "Wowmarker")
            {
                TextTargetName.GetComponent<Text>().text = "Whale";
                playSound("sounds/Wow");
            }

            if (mTrackableBehaviour.TrackableName == "Heymarker")
            {
                TextTargetName.GetComponent<Text>().text = "Haathi(Elephant)";
                playSound("sounds/Hey");
            }

            if (mTrackableBehaviour.TrackableName == "Humzamarker")
            {
                TextTargetName.GetComponent<Text>().text = "Gae (Cow)";
                playSound("sounds/Humza");
            }

            if (mTrackableBehaviour.TrackableName == "Yaymarker")
            {
                TextTargetName.GetComponent<Text>().text = "Yak";
                playSound("sounds/Chotiyay");
            }

            if (mTrackableBehaviour.TrackableName == "BariYaymarker")
            {
                TextTargetName.GetComponent<Text>().text = "Yakka(Cart)";
                playSound("sounds/BariYay");
            }

        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

            //Stop All Sounds if Target Lost
            StopAllAudio();


        }

        #endregion // PRIVATE_METHODS
    }
}

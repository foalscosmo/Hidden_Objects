using UnityEngine;

namespace GardenScripts
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private DownPanel downPanel;
        [SerializeField] private TouchObject touchObject;
        [SerializeField] private AudioSource backgroundMusic;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip correctSound;
        [SerializeField] private AudioClip scaledObjSound;
        [SerializeField] private AudioClip finishSound;
         private void OnEnable()
        {
            touchObject.OnCorrectTouch += PlayCorrectSound;
            downPanel.OnObjectScaled += PlayScaledObjSound;
            downPanel.OnMaxObjectAnswered += PlayFinishSound;
        }

        private void OnDisable()
        {
            touchObject.OnCorrectTouch -= PlayCorrectSound;
            downPanel.OnObjectScaled -= PlayScaledObjSound;
            downPanel.OnMaxObjectAnswered -= PlayFinishSound;
        }

        private void Awake()
        {
            backgroundMusic.playOnAwake = true;
            backgroundMusic.loop = true;
        }

        private void PlayCorrectSound() => audioSource.PlayOneShot(correctSound);
        private void PlayScaledObjSound() => audioSource.PlayOneShot(scaledObjSound);
        private void PlayFinishSound() => audioSource.PlayOneShot(finishSound);
    }
}
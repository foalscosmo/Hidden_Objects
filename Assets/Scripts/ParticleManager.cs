using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private DownPanel downPanel;
    [SerializeField] private TouchObject touchObject;
    [SerializeField] private ParticleSystem correctParticle;
    [SerializeField] private ParticleSystem scaleParticle;
        
    private void OnEnable()
    {
        touchObject.OnCorrectTouch += PlayCorrectParticle;
        downPanel.OnObjectScaled += PlayScaledObjParticle;
    }

    private void OnDisable()
    {
        touchObject.OnCorrectTouch -= PlayCorrectParticle;
        downPanel.OnObjectScaled -= PlayScaledObjParticle;

    }

    private void PlayCorrectParticle()
    {
        correctParticle.transform.position = touchObject.TargetObjects[touchObject.CurrentObjectIndex].position;
        correctParticle.Play();
    } 
    private void PlayScaledObjParticle()
    {
        scaleParticle.transform.position = downPanel.DownPanelObjects[touchObject.CurrentObjectIndex].transform.position;
        scaleParticle.Play();
    }
}
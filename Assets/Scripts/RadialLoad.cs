///////////////////////////////////////////////////////////////////////////
// Author:  Zac King            ///////////////////////////////////////////
// Contact: ZacKingx@Gmail.com  ///////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////
// Usage:                                                                //
// //////                                                                //
// Notes:                                                                //
///////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RadialLoad : MonoBehaviour
{
    #region Variables
    [SerializeField] private Image progressCircle;  // Load image
    [SerializeField] private Gradient loadGradient; // Gradient over time for load
    [SerializeField] private float timeToPlay = 3f; // Seconds to complete load
    public bool isLoading = false;                  // Bool for current state of loading

    [SerializeField] GameObject room;
    [SerializeField]
    GameObject eye;
    #endregion

    // MonoBehaviour ///////////////////////////////////////////////////////////////////////////////////
    [ContextMenu("Set the Type to Fill")]
    void Awake()    // If not already set up, it will be fixed on awake
    {
        progressCircle.type = Image.Type.Filled;    // Amount visible dictacted by value
        progressCircle.fillAmount = 0;              // Zero it out
        progressCircle.fillOrigin = 2;              // Fill Origin = top
        progressCircle.fillClockwise = false;       // FIll Counter clockwise
    }

    // Functions ///////////////////////////////////////////////////////////////////////////////////////
    public void StopLoad()  // Public function allowing asessing obj halt the Load Coroutine 
    {
        isLoading = false;
    }

    public void LoadTarget(Vector3 pos)  //
    {
        isLoading = true;
        StartCoroutine(LoadCircle(pos));
    }

    IEnumerator LoadCircle(Vector3 pos)    // Load coroutine
    {
        bool startLoad = false;
        float timer = 0;
        while (timer <= timeToPlay && isLoading)
        {
            progressCircle.fillAmount = timer / timeToPlay;
            progressCircle.color = loadGradient.Evaluate(timer / timeToPlay);
            timer += Time.deltaTime;

            if (timer >= (timeToPlay / 2) && !startLoad)
            {
                startLoad = true;
            }

            yield return null;
        }

        if (isLoading)
        {
            Vector3 adjust = new Vector3 (eye.transform.localPosition.x, 0, eye.transform.localPosition.z);
            room.transform.position = pos - adjust;
        }

        progressCircle.fillAmount = 0;   // Reset
    }
}

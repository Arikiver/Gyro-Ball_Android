using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

namespace OccaSoftware.Musemi
{
    // This MonoBehaviour should be assigned to the object that should be treated as the Wind Receiver.
    // This will cache a reference to the SetGlobalWind component.

    [ExecuteAlways]
    public class GetGlobalWind : MonoBehaviour
    {
        private VisualEffect vfx = null;
        private SetGlobalWind windController = null;
        private int windVelocityParamID = 0;

        [SerializeField, Min(0), Tooltip("How many times per second to update wind velocity for this effect. Default: 30hz.")] private float refreshRate = 30f;
        private float refreshTiming = 0f;

        void OnEnable()
        {
            windController = FindObjectOfType<SetGlobalWind>();
            vfx = GetComponent<VisualEffect>();
            windVelocityParamID = Shader.PropertyToID("Wind Velocity");

            bool configured = 
                (
                windController != null && 
                vfx != null && 
                windVelocityParamID != 0
                );

            if (configured)
            {
                refreshTiming = 1.0f / refreshRate;
                StartCoroutine(UpdateShaderParameters());
            }
            else
            {
                Debug.Log("Get Global Wind for " + gameObject.name + " is missing a critical reference. Any Visual Effect on this Game Object will not use the Global Wind until re-enabled with the correct configuration. Verify that this asset has a valid Visual Effect Graph asset component and further verify there is a SetGlobalWind component in scene.", this);
            }   
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        IEnumerator UpdateShaderParameters()
        {
            while (true)
            {
                vfx.SetVector3(windVelocityParamID, windController.GetGlobalWindVelocity());
                yield return new WaitForSeconds(refreshTiming);
            }
        }
    }

}

//BASEADO EM https://www.youtube.com/watch?v=m9hj9PdO328&ab_channel=KetraGames

using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] public Light DirectionalLight;
    [SerializeField] public LightingPreset Preset;
    //Variables
    [SerializeField, Range(0, 24)] public float TimeOfDay;
    private static LightingManager _instance;
    
    public bool OnStartEvent;
    public bool OnFinishEvent;


    private void Update()
    {
        Debug.Log(OnStartEvent);
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            if (OnStartEvent == false){
                if (TimeOfDay < 12) { 
                    TimeOfDay += Time.deltaTime;
                    TimeOfDay %= 24; //Modulus to ensure always between 0-24
                    UpdateLighting(TimeOfDay / 24f);
                }
            }
            if (OnStartEvent == true){
                if (TimeOfDay < 22) { 
                    TimeOfDay += Time.deltaTime;
                    TimeOfDay %= 24; //Modulus to ensure always between 0-24
                    UpdateLighting(TimeOfDay / 24f);
                }
            }
            if (OnFinishEvent == true){
                if (TimeOfDay < 12) { 
                    TimeOfDay += Time.deltaTime;
                    TimeOfDay %= 24; //Modulus to ensure always between 0-24
                    UpdateLighting(TimeOfDay / 24f);
                }
                if (TimeOfDay > 15) { 
                    TimeOfDay += Time.deltaTime;
                    TimeOfDay %= 24; //Modulus to ensure always between 0-24
                    UpdateLighting(TimeOfDay / 24f);
                }
            }
        }
            //(Replace with a reference to the game time)
        
        else
        {
            UpdateLighting(TimeOfDay / 24f);

            if (Application.isPlaying) {
            
                if (TimeOfDay < 22) { 
                    TimeOfDay += Time.deltaTime;
                    TimeOfDay %= 24; //Modulus to ensure always between 0-24
                    UpdateLighting(TimeOfDay / 24f);
                }
            }
        }

        

        
    }

    //  public static LightingManager GetInstance()
    
    // {
        
    //     if (_instance == null) {
    //         _instance = new LightingManager();
    //     }
    //     return _instance;
    // }
    // private LightingManagerr() {
    //     OnStartEvent = false;
    // }

    public void OtofujiEventOnStart() {
        
        
        TimeOfDay = 22;


        
    }

    public void OtofujiEventOnFinish() {
        if (Preset == null)
            return;
        if (TimeOfDay > 24) {TimeOfDay = 1;}
        if (Application.isPlaying)
        {
            if (TimeOfDay > 21 || TimeOfDay < 12) { 
                TimeOfDay += Time.deltaTime;
                TimeOfDay %= 24; //Modulus to ensure always between 0-24
                UpdateLighting(TimeOfDay / 24f);
            }
        }
            //(Replace with a reference to the game time)
            
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }


        
    }
   

    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }

    //Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        //Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        //Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}
using System.Collections; // Allows use of basic collections
using System.Collections.Generic; // Allows use of generic collections
using UnityEngine; // Import Unity engine functions/classes

// Only include UnityEditor tools while inside editor. Prevents editor code from being included in final game build
#if UNITY_EDITOR
using UnityEditor;
#endif

// LightFlicker class: Creates dynamic flickering light effects
public class LightFlicker : MonoBehaviour
{
    /* ==== FLICKER MODES ==== */
    public enum FlickerMode // Enum lets you choose flicker behavior
    {
        Random, // Random flickering intensity
        AnimationCurve  // Controlled flicker using animation curve
    }

    /* ==== LIGHT SETTINGS ==== */
    public Light flickeringLight; // Light component to flicker
    public Renderer flickeringRenderer; // Renderer affected by emission glow
    public FlickerMode flickerMode; // Selected flicker mode
    public float lightIntensityMin = 1.25f; // Minimum light brightness
    public float lightIntensityMax = 2.25f; // Maximum light brightness
    public float flickerDuration = 0.075f; // How often random flicker changes
    public AnimationCurve intensityCurve; // Animation curve for custom flicker pattern

     /* ==== INTERNAL VARIABLES ==== */
    Material m_FlickeringMaterial; // Material used for glowing emission
    Color m_EmissionColor; // Original emission color
    float m_Timer; // Timer for flicker updates
    float m_FlickerLightIntensity; // Current light intensity value

     /* ==== SHADER CONSTANTS ==== */    
    static readonly int k_EmissionColorID = Shader.PropertyToID (k_EmissiveColorName);  // Optimized shader property ID, faster than repeatedly using string lookup
    
    const string k_EmissiveColorName = "_EmissionColor"; // Shader emission color property name
    const string k_EmissionName = "_Emission"; // Shader keyword for emission
    const float k_LightIntensityToEmission = 2f / 3f; // Converts light intensity into glow intensity

    /* ==== START: called once when game starts ==== */
    void Start()
    {
        m_FlickeringMaterial = flickeringRenderer.material; // Get material from renderer
        m_FlickeringMaterial.EnableKeyword(k_EmissionName);  // Enable material emission/glow
        m_EmissionColor = m_FlickeringMaterial.GetColor(k_EmissionColorID); // Store original emission color
    }

     /* ==== UPDATE: Called every frame ==== */
    void Update()
    {
        m_Timer += Time.deltaTime; // Increase timer over time

        if (flickerMode == FlickerMode.Random) // RANDOM FLICKER MODE
        {
            if (m_Timer >= flickerDuration) // Change intensity after timer duration
            {
                ChangeRandomFlickerLightIntensity ();
            }
        }
        else if(flickerMode == FlickerMode.AnimationCurve)  // ANIMATION CURVE MODE
        {
            ChangeAnimatedFlickerLightIntensity (); // Use animation curve for flicker
        }
            
        flickeringLight.intensity = m_FlickerLightIntensity; // Apply brightness to light component
        m_FlickeringMaterial.SetColor (k_EmissionColorID, m_EmissionColor * m_FlickerLightIntensity * k_LightIntensityToEmission); // Apply glow/emission brightness to material
    }

     /* ==== RANDOM FLICKER: Creates random light intensity changes ==== */
    void ChangeRandomFlickerLightIntensity ()
    {
        m_FlickerLightIntensity = Random.Range(lightIntensityMin, lightIntensityMax); // Random brightness between min/max

        m_Timer = 0f; // Reset timer
    }

    /* ==== ANIMATION CURVE FLICKER: Uses animation curve for controlled flicker pattern ==== */
    void ChangeAnimatedFlickerLightIntensity ()
    {
        m_FlickerLightIntensity = intensityCurve.Evaluate (m_Timer); // Evaluate brightness from animation curve

        if (m_Timer >= intensityCurve[intensityCurve.length - 1].time) // Restart curve when reaching end
            m_Timer = intensityCurve[0].time;
    }
}

/* ==== CUSTOM UNITY INSPECTOR ==== */
#if UNITY_EDITOR

// Custom inspector for LightFlicker component
[CustomEditor(typeof(LightFlicker))]
public class LightFlickerEditor : Editor
{
    /* ==== SERIALIZED PROPERTIES ==== */
    SerializedProperty m_ScriptProp;
    SerializedProperty m_FlickeringLightProp;
    SerializedProperty m_FlickeringRendererProp;
    SerializedProperty m_FlickerModeProp;
    SerializedProperty m_LightIntensityMinProp;
    SerializedProperty m_LightIntensityMaxProp;
    SerializedProperty m_FlickerDurationProp;
    SerializedProperty m_IntensityCurveProp;

    /* ==== INITIALIZATION: called when editor loads inpector ==== */
    void OnEnable ()
    {
        // Connect inspector fields to script variables
        m_ScriptProp = serializedObject.FindProperty ("m_Script");
        m_FlickeringLightProp = serializedObject.FindProperty ("flickeringLight");
        m_FlickeringRendererProp = serializedObject.FindProperty ("flickeringRenderer");
        m_FlickerModeProp = serializedObject.FindProperty ("flickerMode");
        m_LightIntensityMinProp = serializedObject.FindProperty ("lightIntensityMin");
        m_LightIntensityMaxProp = serializedObject.FindProperty ("lightIntensityMax");
        m_FlickerDurationProp = serializedObject.FindProperty ("flickerDuration");
        m_IntensityCurveProp = serializedObject.FindProperty ("intensityCurve");
    }

     /* ==== CUSTOM INSPECTOR UI ==== */
    public override void OnInspectorGUI ()
    {
        serializedObject.Update ();  // Update serialized object

        // Prevent editing script reference
        GUI.enabled = false;
        EditorGUILayout.PropertyField (m_ScriptProp);
        GUI.enabled = true;

        // Draw normal inspector fields
        EditorGUILayout.PropertyField (m_FlickeringLightProp);
        EditorGUILayout.PropertyField (m_FlickeringRendererProp);
        EditorGUILayout.PropertyField (m_FlickerModeProp);

        // RANDOM MODE SETTINGS
        if (m_FlickerModeProp.enumValueIndex == 0)
        {
            EditorGUILayout.PropertyField (m_LightIntensityMinProp);
            EditorGUILayout.PropertyField (m_LightIntensityMaxProp);
            EditorGUILayout.PropertyField (m_FlickerDurationProp);

        }
        else if (m_FlickerModeProp.enumValueIndex == 1) // ANIMATION CURVE SETTINGS
        {
            EditorGUILayout.PropertyField (m_IntensityCurveProp);
        }

        serializedObject.ApplyModifiedProperties (); // Apply changes in inspector
    }

    /*public Light flickeringLight;
    public Renderer flickeringRenderer;
    public FlickerMode flickerMode;
    public float lightIntensityMin = 1.25f;
    public float lightIntensityMax = 2.25f;
    public float flickerDuration = 0.075f;
    public AnimationCurve intensityCurve;*/
}
#endif

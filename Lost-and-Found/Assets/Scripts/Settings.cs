using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    public static readonly float VAL_CHAR_INTERACT_MAX_DISTANCE = 2.0f;

    public static readonly KeyCode KEYCODE_HOLD = KeyCode.Mouse0;
    public static readonly string STR_KEYCODE_HOLD_OVRRDE = "M1";
    public static readonly string STR_KEYCODE_HOLD_ACTION_OVRRDE = "hold";

    public static readonly KeyCode KEYCODE_INTERACT = KeyCode.E;
    public static readonly string STR_KEYCODE_INTERACT_OVRRDE = "E";
    public static readonly string STR_KEYCODE_HOLD_SPEECH_OVRRDE = "speak";

    public static readonly float VAL_TIME_TO_FADE_DIALOGUE = 3.5f;
    public static readonly float VAL_TIME_FADE_TIMESTEP = 0.01f;
    public static readonly string STR_TEXT_FUZZ_CHARACTER = "x";
    public static readonly int VAL_NUMBER_SCREEN_FLICKER_COLOUR_VARIANTS = 4;

    public static readonly string STR_INTERACT_KEYBIND = "Press";
    public static readonly string STR_INTERACT_KEYBIND_BRACKETS = "[{0}]";
    public static readonly string STR_INTERACT_TODO = "to {0}.";

    public static readonly string PATH_CROSSHAIR_DEFAULT = "Images/2DnUI/ChevronCrosshair";
    public static readonly string PATH_CROSSHAIR_CIRCLE = "Images/2DnUI/ThinCircleCrosshair";
    public static readonly string PATH_CROSSHAIR_SPEECH = "Images/2DnUI/SpeechCrosshair";

    public static readonly float VAL_PLUG_DISCONNECT_FORCE = 2.0f;
    public static readonly float VAL_PLUG_DELAY_TIME = 1.0f;
}

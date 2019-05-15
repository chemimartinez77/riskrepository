using UnityEngine;

public static class GameConstants {
    public enum Phase {Start, Reinforcement, Combat, Relocate, None};

    public static Color ConvertColor (float r, float g, float b, float a) {
        return new Color(r/255.0f, g/255.0f, b/255.0f, a/255.0f);
    }

}

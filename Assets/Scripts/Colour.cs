using UnityEngine;

public static class Colour
{
    private static Color CreateColour(int r, int g, int b) => new Color(r / 255f, g / 255f, b / 255f);

    public static Color White = new Color(1, 1, 1);
    public static Color Black = new Color(0, 0, 0);
    public static Color LightGrey = new Color(0.6f, 0.6f, 0.6f);
    public static Color DarkGrey = new Color(0.4f, 0.4f, 0.4f);
    public static Color LightYellow = CreateColour(252, 232, 131);
    public static Color DarkYellow = CreateColour(230, 198, 74);
}

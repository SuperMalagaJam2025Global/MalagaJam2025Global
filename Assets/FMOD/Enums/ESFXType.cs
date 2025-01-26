public enum ESFXType
{
    Back,
    Press,
    Dead,
    BubblesMate,
    step1,
    step2,
    step3,
    Pause,
    FishCollision,
    FillBubble,
    glowfishA,
    glowfishA2,
    BackToTheGame,
    BackToTheMenu
}
public static class SoundBank
{
    public static string GetID(ESFXType sfxSound) =>
        sfxSound switch
        {
            ESFXType.Back => "Back",
            ESFXType.Press => "aceptar",
            ESFXType.Dead => "muerteconvozgato",
            ESFXType.BubblesMate => "burbujas",
            ESFXType.step1 => "paso1",
            ESFXType.step2 => "paso2",
            ESFXType.step3 => "paso3",
            ESFXType.BackToTheGame => "volveraljuego",
            ESFXType.BackToTheMenu => "volveralmenu",
            ESFXType.FillBubble => "rellenoburbuja",
            ESFXType.FishCollision => "colisionpez",
            ESFXType.Pause => "pause",
            ESFXType.glowfishA => "pezgloboa",
            ESFXType.glowfishA2 => "pezgloboa2",
            _ => "",
        };
}

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
        ESFXType.Dead => "muerte con voz (gato)",
        ESFXType.BubblesMate => "burbujas (mate)2",
        ESFXType.step1 =>"paso1",
        ESFXType.step2 =>"paso2",
        ESFXType.step3 =>"paso3",
        ESFXType.BackToTheGame => "volver al juego",
        ESFXType.BackToTheMenu => "volver al menu",
        ESFXType.FillBubble => "relleno burbuja",
        ESFXType.FishCollision => "colision pez",
        ESFXType.Pause => "pause",
        ESFXType.glowfishA => "pez globo a",
        ESFXType.glowfishA2 => "pez globo a 2",
        _ => "",
    };
}
    
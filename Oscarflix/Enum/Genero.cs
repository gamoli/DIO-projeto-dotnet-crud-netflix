using System.Runtime.Serialization;

namespace Oscarflix
{
    public enum Genero
    {
        Ação = 1,
        Animação = 2,
        Aventura = 3,
        Biografia = 4,
        Comédia = 5,
        [EnumMember(Value = "Curta-Metragem")]
        CurtaMetragem = 6,
        Documentário = 7,
        Drama = 8,
        Fantasia = 9,
        Faroeste = 20,
        [EnumMember(Value = "Ficção Científica")]
        Ficção_Científica = 11,
        Guerra = 12,
        Infantil = 13,
        Mudo = 14,
        Musical = 15,
        Romance = 16,
        Suspense = 17,
        Terror = 18
    }
}
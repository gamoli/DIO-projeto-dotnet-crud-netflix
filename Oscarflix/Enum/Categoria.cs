using System.Runtime.Serialization;

namespace Oscarflix
{
    public enum Categoria
    {
        [EnumMember(Value = "Melhor Ator")]
        MelhorAtor = 1,
        [EnumMember(Value = "Melhor Ator Secundário")]
        MelhorAtorSecundário = 2,
        [EnumMember(Value = "Melhor Atriz")]
        MelhorAtriz = 3,
        [EnumMember(Value = "Melhor Atriz Secundária")]
        MelhorAtrizSecundária = 4,
        [EnumMember(Value = "Melhor Banda Sonora")]
        MelhorBandaSonora = 5,
        [EnumMember(Value = "Melhor Canção Original")]
        MelhorCançãoOriginal = 6,
        [EnumMember(Value = "Melhor Cinematografia")]
        MelhorCinematografia = 7,
        [EnumMember(Value = "Melhor Curta-Metragem")]
        MelhorCurtaMetragem = 8,
        [EnumMember(Value = "Melhor Direção De Arte")]
        MelhorDireçãoDeArte = 9,
        [EnumMember(Value = "Melhor Diretor")]
        MelhorDiretor = 10,
        [EnumMember(Value = "Melhor Documentário")]
        MelhorDocumentário = 11,
        [EnumMember(Value = "Melhor Documentário De Curta-Metragem")]
        MelhorDocumentárioDeCurtaMetragem = 12,
        [EnumMember(Value = "Melhor Edição")]
        MelhorEdição = 13,
        [EnumMember(Value = "Melhor Edição De Som")]
        MelhorEdiçãoDeSom = 14,
        [EnumMember(Value = "Melhor Figurino")]
        MelhorFigurino = 15,
        [EnumMember(Value = "Melhor Filme")]
        MelhorFilme = 16,
        [EnumMember(Value = "Melhor Filme De Animação")]
        MelhorFilmeDeAnimação = 17,
        [EnumMember(Value = "Melhor Filme Estrangeiro")]
        MelhorFilmeEstrangeiro = 18,
        [EnumMember(Value = "Melhor Fotografia")]
        MelhorFotografia = 19,
        [EnumMember(Value = "Melhor Mistura De Som")]
        MelhorMisturaDeSom = 20,
        [EnumMember(Value = "Melhor Realizador")]
        MelhorRealizador = 21,
        [EnumMember(Value = "Melhor Roteiro")]
        MelhorRoteiro = 22,
        [EnumMember(Value = "Melhor Roteiro Adaptado")]
        MelhorRoteiroAdaptado = 23,
        [EnumMember(Value = "Melhor Roteiro Original")]
        MelhorRoteiroOriginal = 24,
        [EnumMember(Value = "Melhor Trilha Sonora")]
        MelhorTrilhaSonora = 25,
        [EnumMember(Value = "Melhor Trilha Sonora Adaptada")]
        MelhorTrilhaSonoraAdaptada = 26,
        [EnumMember(Value = "Melhor Trilha Sonora Original")]
        MelhorTrilhaSonoraOriginal = 27,
        [EnumMember(Value = "Melhores Efeitos Visuais")]
        MelhoresEfeitosVisuais = 28,

    }
}
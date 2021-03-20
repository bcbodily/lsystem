namespace bc.Framework.Language.Phonetics.InternationalPhoneticAlphabet
{
    /// <summary>
    /// The configurations of speech articulators when making a speech sound
    /// </summary>
    public enum MannerOfArticulations
    {
        /// <summary>
        /// A nasal occlusive
        /// </summary>
        Nasal,

        /// <summary>
        /// A plosive; an oral occlusive
        /// </summary>
        Stop,

        /// <summary>
        /// A sibilant (higher pitch and amplitude made by directing air towards the teeth) that begins as a stop and releases as a fricative (sound produced by guiding air through a narrow channel between two articulators)
        /// </summary>
        SibilantAffricate,

        /// <summary>
        /// A non-sibilant that begins as a stop and releases as a fricative
        /// </summary>
        NonsibilantAffricate,

        /// <summary>
        /// A sibilant (higher pitch and amplitude made by directing air towards the teeth) fricative (where air is directed through a narrow enough passage to cause turbulence)
        /// </summary>
        SibilantFricative,

        /// <summary>
        /// A non-sibilant fricative (where air is directed through a narrow enough passage to cause turbulence)
        /// </summary>
        NonsibilantFricative,

        /// <summary>
        /// A sound that involves the articulators approaching each other but not narrowly enough to create turbulent airflow
        /// </summary>
        Approximant,

        /// <summary>
        /// A sound produced by a single contraction that throws one articulator into another
        /// </summary>
        Tap,

        /// <summary>
        /// A sound produced by vibrations between the active and passive articulators
        /// </summary>
        Trill,

        /// <summary>
        /// A consonant affricate in which the air flows on both sides of the tongue but is blocked by the tongue from flowing through the middle
        /// </summary>
        LateralAffricate,

        /// <summary>
        /// A consonant fricative in which the air flows on both sides of the tongue but is blocked by the tongue from flowing through the middle
        /// </summary>
        LateralFricative,

        /// <summary>
        /// A lateral (along the sides of the tongue) approximant (through a narrow passage, but not so narrow as to cause turbulence) sound
        /// </summary>
        LateralApproximant,

        /// <summary>
        /// A lateral (along the sides of the tongue) tap (sound produced by a single contraction that throws one articulator into another)
        /// </summary>
        LateralTap
    }
}
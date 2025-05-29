namespace CinemaApp.Data.Common
{
    public static class EntityConstants
    {
        public static class Movie
        {
            /// <summary>
            /// Movie Title should be able to store text with length up to 100 characters.
            /// </summary>
            public const int TitleMaxLength = 100;

            /// <summary>
            /// Movie Genre should be able to store text with length up to 50 characters.
            /// </summary>
            public const int GenreMaxLength = 50;

            /// <summary>
            /// Movie Director should be able to store text with length up to 100 characters.
            /// </summary>
            public const int DirectorMaxLength = 100;

            /// <summary>
            /// Movie Description should be able to store text with length up to 1000 characters.
            /// </summary>
            public const int DescriptionMaxLength = 1000;

            ///<summary>
            ///Movie Duration should be between 1 and 300 minutes.
            ///</summary>
            public const int DurationMin = 1;
            public const int DurationMax = 300;
        }
    }
}

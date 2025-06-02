namespace CinemaApp.Data.Common
{
    public static class EntityConstants
    {
        public static class Movie
        {
            /// <summary>
            /// Movie Title should be at least 2 characters and up to 100 characters.
            /// </summary>
            public const int TitleMinLength = 2;

            /// <summary>
            /// Movie Title should be able to store text with length up to 100 characters.
            /// </summary>
            public const int TitleMaxLength = 100;

            /// <summary>
            /// Genre must be at least 3 characters.
            /// </summary>
            public const int GenreMinLength = 3;

            /// <summary>
            /// Movie Genre should be able to store text with length up to 50 characters.
            /// </summary>
            public const int GenreMaxLength = 50;

            /// <summary>
            /// Director name must be at least 2 characters.
            /// </summary>
            public const int DirectorNameMinLength = 2;

            /// <summary>
            /// Movie Director should be able to store text with length up to 100 characters.
            /// </summary>
            public const int DirectorNameMaxLength = 100;

            /// <summary>
            /// Movie Description must be at least 10 characters.
            /// </summary>
            public const int DescriptionMinLength = 10;

            /// <summary>
            /// Movie Description should be able to store text with length up to 1000 characters.
            /// </summary>
            public const int DescriptionMaxLength = 1000;

            /// <summary>
            /// Movie Duration should be between 1 and 300 minutes.
            /// </summary>
            public const int DurationMin = 1;

            /// <summary>
            /// Movie Duration should be between 1 and 300 minutes.
            /// </summary>
            public const int DurationMax = 300;

            /// <summary>
            /// Maximum allowed length for image URL.
            /// </summary>
            public const int ImageUrlMaxLength = 2048;

            /// <summary>
            /// Movie ReleaseDate should be formatted using this pattern.
            /// </summary>
            public const string ReleaseDateFormat = "yyyy-MM-dd";

            // Error messages

            public const string TitleRequiredMessage = "Title is required.";
            public const string TitleMinLengthMessage = "Title must be at least 2 characters.";
            public const string TitleMaxLengthMessage = "Title cannot exceed 100 characters.";

            public const string GenreRequiredMessage = "Genre is required.";
            public const string GenreMinLengthMessage = "Genre must be at least 3 characters.";
            public const string GenreMaxLengthMessage = "Genre cannot exceed 50 characters.";

            public const string DirectorRequiredMessage = "Director is required.";
            public const string DirectorNameMinLengthMessage = "Director name must be at least 2 characters.";
            public const string DirectorNameMaxLengthMessage = "Director name cannot exceed 100 characters.";

            public const string DescriptionRequiredMessage = "Description is required.";
            public const string DescriptionMinLengthMessage = "Description must be at least 10 characters.";
            public const string DescriptionMaxLengthMessage = "Description cannot exceed 1000 characters.";

            public const string DurationRequiredMessage = "Duration is required.";
            public const string DurationRangeMessage = "Duration must be between 1 and 300 minutes.";

            public const string ReleaseDateRequiredMessage = "Release date is required.";

            public const string ImageUrlMaxLengthMessage = "Image URL cannot exceed 2048 characters.";
        }
    }
}

namespace ReportsVerification.Web.Utills.Interfaces
{
    /// <summary>
    /// Прочитанные данные файла
    /// </summary>
    public class UploadFileInfo
    {
        public UploadFileInfo(string fileName, string content)
        {
            FileName = fileName;
            Content = content;
        }

        /// <summary>
        /// Наименование файла
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Контент файла
        /// </summary>
        public string Content { get; }

        public string ErrorMessage { get; private set; }

        public void SetError(string message)
        {
            ErrorMessage = message;
        }

        public bool IsValid()
        {
            return string.IsNullOrEmpty(ErrorMessage);
        }
    }
}
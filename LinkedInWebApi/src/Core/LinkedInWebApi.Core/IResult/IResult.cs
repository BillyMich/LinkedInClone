namespace LinkedInWebApi.Core
{
    /// <summary>
    /// This class is used to return the result of the operation.
    /// </summary>
    /// <typeparam name="DataType"></typeparam>
    public class IResult<DataType>
    {
        /// <summary>
        /// Data to be returned.
        /// </summary>
        public DataType Data { get; set; }

        /// <summary>
        /// Indicates whether the operation is successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Error code of the operation.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Error message of the operation.
        /// </summary>
        public string ErrorMessage { get; set; }

    }
}

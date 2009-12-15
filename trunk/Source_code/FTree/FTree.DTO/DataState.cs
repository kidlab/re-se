namespace FTree.DTO
{
    /// <summary>
    /// Defines the status of a data object.
    /// </summary>
    public enum DataState
    {
        /// <summary>
        /// The data object was copied from other object.
        /// </summary>
        Copied,

        /// <summary>
        /// The data object was initialized or brand new.
        /// </summary>
        New,

        /// <summary>
        /// The data object was changed.
        /// </summary>
        Modified,

        /// <summary>
        /// The data object was deleted.
        /// </summary>
        Deleted
    }
}

using System;
/// <summary>
/// Classes that implement this interface encapsulate the functionality
/// of saving a packet to the data store appropriately. The included
/// implementation is WatchDataSaver.
/// </summary>
public interface IWatchDataSaver
{
    /// <summary>
    /// Fires if data is saved succesfully.
    /// </summary>
    event Action OnSuccessfulSave;
    /// <summary>
    /// Fired if packet cannot be saved to data store for any reason.
    /// </summary>
    event Action OnFailureToSave;
    /// <summary>
    /// Fired  if there is no watch that matches with the packet.
    /// Passes in the packet recieved.
    /// </summary>
    event Action<uint> IfNoMatchingWatch;
    void SavePacket(uint packet);
}

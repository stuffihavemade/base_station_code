using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using WatchCommunication;
using Models;

public class WatchDataSaver : IWatchDataSaver
{
    public event Action OnSuccessfulSave;
    public event Action OnFailureToSave;
    public event Action<uint> IfNoMatchingWatch;
    private IRepository repository;
    private IWatchPool watchPool;
    private IAccessPoint accessPoint;

    public WatchDataSaver(IRepository repository,
                       IWatchPool watchPool,
                       IAccessPoint accessPoint) {
        OnSuccessfulSave += () => { };
        OnFailureToSave += () => { };
        IfNoMatchingWatch += (x) => { };
        this.repository = repository;
        this.watchPool = watchPool;
        this.accessPoint = accessPoint;
    }

    public void SavePacket(uint packet) {
        if (watchPool.HasWatchWithIdentifier(packet)) {
            var watch = watchPool.WatchWithIdentifier(packet);
            try {
                if (watch.IsPaired()) {
                    watch.RecordBehavior(new Behavior());
                    repository.Commit();
                    OnSuccessfulSave();
                }
            }
            catch {
                repository.Rollback();
                OnFailureToSave();
            }
        }
        else {
            IfNoMatchingWatch(packet);
        }
    }
}

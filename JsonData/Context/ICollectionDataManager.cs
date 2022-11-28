namespace JsonData.Context;

public interface ICollectionDataManager
{
    ViaLabData LoadData();
    void SaveData(ViaLabData viaLabData);
}